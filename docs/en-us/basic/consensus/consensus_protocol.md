# Consensus Protocol

## Consensus Message Format

### ExtensiblePayload

| Size | Field | Type  | Description |
|----|------|-------|------|
| ? | Category | String | Message category, currently is `dBFT` |
| 4 | ValidBlockStart | uint | Starting height where message is valid |
| 4 | ValidBlockEnd | uint | Ending height where message is valid |
| 20 | Sender | UInt160 | The address hash of the current consensus node |
| ?  |  Data | byte[] | The data includes `ChangeView`, `PrepareRequest`, `PrepareResponse`, `Commit`, `RecoveryMessage`, `RecoveryRequest` |
| ? | Witness | Witness | Witness contains invocation script and verification script |

### ConsensusMessage

ConsensusMessage is the basic abstract type of all consensus message types. Other consensus message types are all inherited from this type.

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 1 | Type | ConsensusMessageType | Includes `ChangeView`, `PrepareRequest`, `PrepareResponse`, `Commit`, `RecoveryMessage`, `RecoveryRequest` |
| 4 | BlockIndex | uint | Height where message is created |
| 1 | ValidatorIndex | byte | The index of the sender in validators array |
| 1 | ViewNumber | byte | View number where message is created |

### ChangeView

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 8 | Timestamp | ulong | Timestamp when the ChangeView message is created |
| 1 | Reason | ChangeViewReason |  Reason for the view change |

### Commit

| Size| Field | Type | Description |
|----|------|-----|-------|
| ? | Signature | byte[] | Message signature |

### PrepareRequest

| Size | Field | Type  | Description |
|----|------|-----|-------|
| 4 | Version | uint | Default value is 0 |
| 32 | PrevHash | UInt256 | Previous block's hash |
| 8 | Timestamp | ulong | Timestamp when the PrepareRequest message is created |
| ? | TransactionHashes | UInt256[] |  The transaction hashes in the block |

### PrepareResponse

| Size | Field | Type | Description |
|----|------|-----|-------|
| 32 | PreparationHash | UInt256 | Hash of corresponding prepare request |

### RecoveryMessage

| Size | Field | Type | Description |
|----|------|-----|-------|
|  ?  | ChangeViewMessages | Dictionary<int, ChangeViewPayloadCompact> | ChangeView messages |
|  ?  | PrepareRequestMessage | PrepareRequest | The current PrepareRequest message |
|  32  | PreparationHash | UInt256 | Hash of prepare request |
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

Both inv and getdata messages use InvPayload as the message carrier, which is defined as follows:

### InvPayload

| Size | Field | Type  | Description |
|------|------|-------|------|
| 1 | Type | InventoryType | Message type |
| ? | Hashes | UInt256[] | Hashes broadcasted / requested |

There are 3 kinds of  `InventoryType`:

- `0x2b`: Transaction. `Hashes` is assigned to the transaction.
- `0x2c`: Block. `Hashes` is assigned to the block.
- `0x2e`: Consensus. `Hashes` is assigned to the `ConsensusPayload` message.

## Consensus Message Process

###  Verification

1. Ignore the message if `ValidBlockStart` is lower than `ValidBlockEnd`.

2. Ignore the message if current block height is out of `[ValidBlockStart, ValidBlockEnd)`.

3. Ignore the message if sender is not listed in the consensus white list.

4. Ignore the message if the verification script failed or `Category` is not "dBFT".

5. Ignore the message if the node has sent out the new block.

6. Ignore the message if the consensus message data is in a wrong format.

7. Ignore the message if the `message.BlockIndex` is lower than the current block height.

8. Ignore the message if the `ConsensusPayload.ValidatorIndex` is out of index of the current consensus nodes array, or `payload.Sender` is different from the correct hash.

### Process

1. On receiving a `PrepareRequest` sent by speaker, attached with proposal block data.

    1. Ignore if the `PrepareRequest` has already been received or the node is trying to change the view.

    2. Ignore if the `message.ValidatorIndex` is not the index of the current round speaker or the `PrepareRequest.ViewNumber` is not equal to the current view number.

    3. Ignore if `message.Version` or `message.PrevHash` is different from the local context.

    4. Ignore if transactions' amount is over `MaxTransactionsPerBlock`.

    5. Ignore if the `message.Timestamp` is not more than the timestamp of the previous block, or is more than 8 blocks above current time.

    6. Ignore if any proposed transaction has already been included in the blockchain

    7. Renew consensus context and clear invalid signatures that have been received (Prepare-Reponse may arrive first)

    8. Save the signature of the speaker into current context.

    9. If there's no transaction in this request, directly check the local collection of `PrepareResponse`, and broadcast the `Commit` message in case of enough `PrepareResponse` collected.

    10. Collect and verify transactions in the proposal block from memory pool.

        1. Ignore if the transaction failed to pass verification or the transaction did not meet strategic requirements.
        
        2. Otherwise the transaction will be saved into current consensus context.
    
    11. Verify the transactions required by blocks in the unconfirmed transaction pool and add them into current context.

    12. Broadcast a `getdata` message with a list of transaction hashes if they were missed in the block.

2. On receiving a `PrepareResponse` sent by consensus nodes with their signature.

    1. Ignore it if the message view is not the same as the current view

    2. Ignore it if current node has already saved the sender's signature or the current node is trying to change the view.

    3. Save it temporarily if current node has not received PrepareResponse yet (Clear it after receiving PrepareResponse), or go to next step.

    4. Verify the signature. Save the signature if it pass the verification. Ignore it if not.

    5. Ignore it if the node has already sent `Commit`.

    6. Verify the signature number if the node has already sent or received `PrepareRequest`. If there are at least `N-f` signatures, broadcast `Commit` and generate the block if there are `N-f` `Commit` messages have been received.

3. On receiving a `Changeview` sent by consensus nodes.

    1. Send `RecoveryMessage` if the new view number in the message is less than or equal to the view number in current context.

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

    2. Then receive and handle `PrepareRequest` and `PrepareResponse` inside if the message  view number is equal to the node view number, and the node is not in the process of changing view or has not sent `Commit` before.

    3. Then receive and handle `Commit` inside if the message view number is not greater than the node view number. 

7. On receiving an `OnTimer`

    1. Ignore if timer's height or view number is different from local context.

    2. If the speaker timeout, the consensus node will broadcast `PrepareRequest` for the first timeout. For subsequent timeouts, it will broadcast `RecoveryMessage` if `Commit` message has been sent, otherwise `ChangeView`.

    3. If the delegate timeout, the consensus node will broadcast `RecoveryMessage` if `Commit` message has been sent, otherwise `ChangeView`.

8. On receiving a `PersistCompleted`

    Resetting consensus process

9. On receiving a `New Transaction` for consensus

    1. Ignore if the current node has sent `PrepareRequest` or `PrepareResponse` message, or in process of change view, or has sent new block in this round

    2. Ignore if the transaction has been received before.

    3. Ignore if the received transaction isn't in the proposal block.

    4. Broadcast `ChangeView` if the transaction verification fails.

    5. Save the transaction into the proposal block.

    6. Handle the corresponding logic if this is an Oracle transaction.

    7. If the receiver is a delegate, broadcast the `ChangeView` message if the new block doesn't accord with `MaxBlockSize` or `MaxBlockSystemFee`. It also checks local collection of `PrepareResponse`, and broadcasts the `Commit` message in case of enough `PrepareResponse` collected.
