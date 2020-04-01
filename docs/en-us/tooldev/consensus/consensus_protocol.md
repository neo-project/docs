# Consensus Protocol

## Consensus Message Format

### P2P message format

| Size | Field | Type  | Description |
|------|------|-------|------|
|  4   | Magic |  uint | Protocol ID, defined in the configuration file `protocol.json`, mainnet is `7630401`, testnet is `1953787457`   |
| 12   | Command | string | Command, all consensus messages' command is `consensus`  |
| 4     | Length  | uint32 | Length of payload|
| 4     | Checksum | uint | Checksum |
| Length  | Payload | byte[] | Content of message, all consensus messages' payload is `ConsensusPayload`  |

### ConsensusPayload

| Size | Field | Type  | Description |
|----|------|-------|------|
| 4  | Version |  uint | 	Version of protocol, 0 for now |
| 32  | PrevHash | UInt256 | Previous block's hash |
| 4 | BlockIndex |uint | Height of the block |
| 2 | ValidatorIndex | ushort | The index of the current consensus node in validators array |
| 4  | Timestamp | uint | Timestamp |
| ?  |  Data | byte[] | Includes `ChangeView`, `PrepareRequest` and `PrepareResponse` |
| 1 |  - | uint8 | It's fixed to 1 |
| ? | Witness | Witness | Witness contains invocation script and verificatioin script |

### ChangeView

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 1 | Type | ConsensusMessageType | `0x00` |
| 1 | ViewNumber | byte | Current view number |
| 1 | NewViewNumber | byte |  New view number |

### PrepareRequest

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 1 | Type | ConsensusMessageType | `0x20` |
| 1 | ViewNumber | byte | Current view number |
| 8 | Nonce | ulong |  block nonce |
| 20  | NextConsensus | UInt160 |  The script hash of the next round consensus nodes' multi-signature contract  |
| 4 + 32 * length   | TransactionHashes | UInt256[] |  The proposal block's transaction hashes |
| 78  | MinerTransaction | MinerTransaction |  It is used to sum all the transaction fees of the current block as a reward for the speaker. |
|  64 | Signature | byte[] |  Block signature |

### PrepareResponse

| Size | Field | Type | Description |
|----|------|-----|-------|
| 1 | Type | ConsensusMessageType | `0x21` |
| 1 | ViewNumber | byte | Current view number |
| 64 | Signature | byte[] | Block signature |

## Transport Protocol

When a consensus message enters the P2P network, it's broadcasted and transmitted like other messages. That is because consensus nodes do not have IP address of other consensus nodes. Consensus nodes are not directly connected. That is to say, ordinary nodes can also receive consensus message. The broadcast flow of consensus messages is as follows.

[![consensus_msg_seq](../images/consensus/consensus_msg_seq.jpg)](../../images/consensus/consensus_msg_seq.jpg)

  1. Consensus node A will directly broadcast 'consensus' message to connected nodes(e.g. node B).

  2. After receiving the `consensus` message, node B firstly process the received consensus message and then forwards it. Before forwarding the consensus message, it sends an `inv` message which carries the hash data of the `payload` of the `consensus` message (to node C).

  3. If the node C has already known the data corresponding to the hash, it does not process the inv message. Otherwise, it proceeds to step 4.

  4. Node C sends a `getdata` message to node B, with the hash data in the `inv` message.

  5. After receiving the `getdata` message, node B sends a `consensus` message to node C.

  6. After receiving the `consensus` message, the node C triggers the consensus module to process the message, and forwards the consensus message, and then returns to step 2.

### inv message format

| Size | Field | Type  | Description |
|------|------|-------|------|
| 4    | Magic |  uint | Protocol ID |
| 12   | Command | string | `inv`  |
| 4    | Length    | uint32 | Length of payload|
| 4    | Checksum | uint | Checksum |
| Length | Payload | byte[] | Format: `0xe0` + `0x00000001` + `ConsensusPayload.Hash` |

> [!Note] 
>
> Payload's format： `inv.type + inv.payloads.length + inv.payload`
> `inv` message's payload has three types listed as follow:
>
> - `0x01`: Transaction. `inv.payload` is assigned to transaction's hash.
> - `0x02`: Block. `inv.payload` is assigned to `ConsensusPayload` message's hash.
> - `0xe0`: Consensus. `inv.payload` is assigned to block's hash.

### getdata message format

| Size | Field | Type  | Description |
|------|------|-------|------|
| 4    | Magic |  uint | Protocol ID |
| 12   | Command | string | `getdata` |
| 4    | Length | uint32 | Length of payload |
| 4    | Checksum | uint | Checksum |
| Length | Payload | byte[] | Format: `0xe0` + `0x00000001` + `ConsensusPayload.Hash` |

> [!Note]
>
> The `getdata` message is mainly used to get the specific content in `inv` message.

## Consensus Message Process

###  Verification

1. Ignore the message if the `ConsensusPayload.BlockIndex` is lower than current block height.

2. Ignore the message if the verification script failed or the script hash does not equal to `ConsensusPayload.ValidatorIndex` address's script hash.

3. Ignore the message if the `ConsensusPayload.ValidatorIndex` equals to current node index.

4. Ignore the message if the `ConsensusPayload.Version` does not equal to current consensus version.

5. Ignore the message if the `ConsensusPayload.PrevHash` and `ConsensusPayload.BlockIndex` do not equal to the values in current node's context.

6. Ignore the message if the `ConsensusPayload.ValidatorIndex` is out of index of the current consensus nodes array.

7. Ignore the message if the `ConsensusMessage.ViewNumber` does not equal to the value in current node's context except that the consensus message is a `ChangeView`.

### Process

1. On receiving a **PrepareRequest** sent by speaker, attached with proposal block data.

  1. Ignore if the `PrepareRequest` has already been received.

  2. Ignore if the `ConsensusPayload.ValidatorIndex` is not the index of the current round speaker.

  3. Ignore if the `ConsensusPayload.Timestamp` is not more than the timestamp of the previous block, or is more than 10 minutes above current time.

  4. Ignore if the signature of the message is incorrect.

  5. Clear signatures saved in the context that does not match the received proposal message.

  6. Save the signature of the speaker into current context.

  7. Collect and verify transactions in the proposal block from memory pool.

    1. If the transaction failed to pass verification or policy check provided by plugin, it will stop the process and request ChangeView.

    2. Otherwise the transaction will be saved into current context.
      
    3. If all the transactions in the proposal block are collected, broadcast `PrepareResponse` message.

  8. Collect and verify transactions in the proposal block from unverified memory pool.

  9. Verify the MinerTransaction and add it into current context.
    
  10. If all transactions are collected verified, it will request PrepareResponse. Otherwise it will broadcast a getdata message to retrieve transactions from other nodes.

2. On receiving a **PrepareResponse** sent by consensus nodes with their signture.

  1. Ignore it if current node has already saved the sender's signature.

  2. Save it temporarily if current node does not have information of corresponding PrepareRequest of the received PrepareResponse yet.

  3. Otherwise verify the signature. Save the signature if it pass the verification. Ignore it if not.

  4. If there are at least `N-f` signatures, accept the new block and broadcast it.

3. On receiving a **Changeview** sent by consensus nodes.

  1. Ignore it if the view number in the message is less than the view number in current context.

  2. If current node received at least `N-f` `ChangeView` messages with the same new view number, then ViewChange will happen. The current node reset the consensus process with the new view number.

4. On **Timeout** happens

  1. If the process above timeout, the consensus node will broadcast `ChangeView` message directly.

  2. Timeout time starts from 30 seconds. Timeout interval doubles when each timeout happens.

5. On receiving a **New Block**

  1. resetting consensus process

6. On receiving a **New Transaction** for consensus

  1. Ignore if the transaction is a `MinerTransaction`. (A `MinerTransaction` should not be broadcasted).

  2. Ignore if current node is speaker, or the node has sent `PrepareRequest` or `PrepareResponse` message, or in process of change view.

  3. Ignore if the transaction has been received before.

  4. Ignore if the received transacion isn't in the propoal block.

  5. Save the transaction into current context.
