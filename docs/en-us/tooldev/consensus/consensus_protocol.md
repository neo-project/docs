# Consensus Protocol

## Consensus Message Format

### ConsensusPayload

| Size | Field | Type  | Description |
|----|------|-------|------|
| 4  | Version |  uint | 	Version of protocol, 0 for now |
| 32  | PrevHash | UInt256 | Previous block's hash |
| 4 | BlockIndex |uint | Height of the block |
| 2 | ValidatorIndex | ushort | The index of the current consensus node in validators array |
| ?  |  Data | byte[] | Includes `ChangeView`, `PrepareRequest`, `PrepareResponse`, `Commit`, `RecoveryMessage`, `RecoveryRequest` |
| ? | Witness | Witness | Witness contains invocation script and verification script |

### ChangeView

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 1 | NewViewNumber | byte | Current view number+1 |
| 8 | Timestamp | ulong | Timestamp when the ChangeView message is created |
| 1 | Reason | ChangeViewReason |  Reason for the view change |

### Commit

| Size| Field | Type | Description |
|----|------|-----|-------|
| ? | Signature | byte[] | Message signature |

### PrepareRequest

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 8 | Timestamp | ulong | Timestamp when the PrepareRequest message is created |
| 8 | Nonce | ulong |  block nonce |
| ? | TransactionHashes | UInt256[] |  The transaction hashes in the block |

### PrepareResponse

| Size | Field | Type | Description |
|----|------|-----|-------|
|  32  | PreparationHash | UInt256 |  |

### RecoveryMessage

| Size | Field | Type | Description |
|----|------|-----|-------|
|  ?  | ChangeViewMessages | Dictionary<int, ChangeViewPayloadCompact> | ChangeView messages |
|  ?  | PrepareRequestMessage | PrepareRequest | The current PrepareRequest message |
|  32  | PreparationHash | UInt256 |  |
|  ?  | PreparationMessages | Dictionary<int, PreparationPayloadCompact> | Preparation messages that have been collected |
|  ?  | CommitMessages | Dictionary<int, CommitPayloadCompact> | Commit messages that have been collected |

### RecoveryRequest

| Size | Field | Type | Description |
|----|------|-----|-------|
|  8  | Timestamp | ulong | Timestamp when the message is created |

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

2. Ignore the message if the verification script failed.

3. Ignore the message if the node has sent out the new block.

4. Ignore the message if the `ConsensusPayload.Version` does not equal to current consensus version.

5. Ignore the message if the `ConsensusPayload.PrevHash` and `ConsensusPayload.BlockIndex` are not equal to the values in current node's context.

6. Ignore the message if the `ConsensusPayload.ValidatorIndex` is out of index of the current consensus nodes array.

7. Ignore the message if the verification to the message using the loaded plugin failed.

### Process

1. On receiving a `PrepareRequest` sent by speaker, attached with proposal block data.

    1. Ignore if the `PrepareRequest` has already been received or the node is trying to change the view.

    2. Ignore if the `ConsensusPayload.ValidatorIndex` is not the index of the current round speaker or the `PrepareRequest.ViewNumber` is not equal to the current view number.

    3. Ignore if the `ConsensusPayload.Timestamp` is not more than the timestamp of the previous block, or is more than 8 blocks above current time.

    4. Ignore if the proposed transaction has already been included in the blockchain

    5. Check if the signature of the block is incorrect.

    6. Clear invalid signatures that have been received (Prepare-Reponse may arrive first)

    7. Save the signature of the speaker into current context.

    8. Collect and verify transactions in the proposal block from memory pool.

        1. If the transaction failed to pass verification or the transaction did not meet strategic requirements , it will stop the process and request ChangeView.
      
        2. Otherwise the transaction will be saved into current consensus context.
    
        3. If all the transactions in the proposal block are collected, broadcast `PrepareResponse` message.
    9. Verify the transactions required by blocks in the unconfirmed transaction pool and add them into current context.

    10. Broadcast a `getdata` message with a list of transaction hashes if they were missed in the block.

2. On receiving a `PrepareResponse` sent by consensus nodes with their signature.

    1. Ignore it if the message view is not the same as the current view

    2. Ignore it if current node has already saved the sender's signature or the current node is trying to change the view.

    3. Save it temporarily if current node has not received PrepareResponse yet (Clear it after receiving PrepareResponse), or go to next step.

    4. Verify the signature. Save the signature if it pass the verification. Ignore it if not.

    5. Ignore it if the node has already sent `Commit`.

    6. Verify the signature number if the node has already sent or received `PrepareRequest`. If there are at least `N-f` signatures, broadcast `Commit` and generate the block if there are `N-f` `Commit` messages have been received.

3. On receiving a `Changeview` sent by consensus nodes.

    1. Send `RecoveryMessage` if the new view number in the message is less than the view number in current context.

    2. Ignore it if the node has sent `Commit`.

    3. If current node received at least `N-f` `ChangeView` messages with the same new view number, then ViewChange will happen. The current node reset the consensus process with the new view number.

4. On receiving a `Commit` send by consensus nodes after receiving `N-f` `PrepareResponse`.

    1. Ignore it if it has been received from the same node before.

    2. Save the message into the consensus context if the signature passed verification,  generate a block and broadcast if `N-f` Commit messages has been received.

5. On receiving a `RecoveryRequest` sent by consensus nodes when initiating a consensus or the sum of committed and failed nodes is greater than `f`.

    1. Ignore it if it has been received before.

    2. Response it if the node has sent the `Commit` message before or the node index is no more than f numbers later than the sender index

    3. Send `RecoveryMessage` if the node is obligated to response.

6. On receiving a `RecoveryMessage` broadcast by consensus nodes when receiving an accessible `RecoveryRequest` or time out after a Commit message has been sent.

    1. Receive and handle `ChangeView` inside if the message view number is greater than the node view number. 

    2. Receive and handle `PrepareRequest` and `PrepareResponse` inside if the message  view number is equal to the node view number, and the node is not in the process of changing view or has not sent `Commit` before.

    3. Receive and handle `Commit` inside if the message view number is not greater than the node view number. 

7. On `Timeout` happens

    1. If the speaker timeout, the consensus node will broadcast `PrepareRequest` for the first timeout and `ChangeView` for subsequent timeouts.

    2. If the delegate timeout, the consensus node will broadcast `ChangeView` directly.

8. On receiving a `New Block`

    resetting consensus process

9. On receiving a `New Transaction` for consensus

    1. Ignore if the current node has sent `PrepareRequest` or `PrepareResponse` message, or in process of change view, or has sent new block in this round

    2. Ignore if the transaction has been received before.

    3. Ignore if the received transaction isn't in the proposal block.

    4. Save the transaction into the proposal block.
