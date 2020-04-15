# 共识协议

## 共识消息格式

### ConsensusPayload

| 尺寸 | 字段 | 类型  | 说明 |
|----|------|-------|------|
| 4  | Version |  uint | 共识版本号， 目前为`0` |
| 32  | PrevHash | UInt256 | 上一个区块的hash |
| 4 | BlockIndex |uint | 当前Block高度 |
| 2 | ValidatorIndex | ushort | 发送共识消息的议员，在议员列表中的序号 |
| ?  |  Data | byte[] | 具体消息内容包括`ChangeView`, `PrepareRequest`, `PrepareResponse`, `Commit`, `RecoveryMessage`, `RecoveryRequest` |
| ? | Witness | Witness | 见证人 |

### Changeview 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
| 1 | NewViewNumber | byte | 当前视图编号加1 |
| 8 | Timestamp | ulong | 创建ChangeView消息时的时间戳 |
| 1 | Reason | ChangeViewReason |  视图更改原因 |

### Commit 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
| ? | Signature | byte[] | 消息签名 |

### PrepareRequest 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
| 8 | Timestamp | ulong | 创建PrepareRequest消息时的时间戳 |
| 8 | Nonce | ulong | 区块随机值 |
| ?  | TransactionHashes | UInt256[] |  区块中交易的哈希列表 |

### PrepareResponse 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
|  32  | PreparationHash | UInt256 |  |

### RecoveryMessage 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
|  ?  | ChangeViewMessages | Dictionary<int, ChangeViewPayloadCompact> | ChangeView信息 |
|  ?  | PrepareRequestMessage | PrepareRequest | 当前PrepareRequest信息 |
|  32  | PreparationHash | UInt256 |  |
|  ?  | PreparationMessages | Dictionary<int, PreparationPayloadCompact> | 当前收集到的Preparation信息 |
|  ?  | CommitMessages | Dictionary<int, CommitPayloadCompact> | 当前收集到的Commit信息 |

### RecoveryRequest 消息格式

| 尺寸| 字段 | 类型 | 说明  |
|----|------|-----|-------|
|  8  | Timestamp | ulong | 创建信息的时间 |

## 传输协议

共识消息进入P2P网络后，和其他数据包一样，进行广播传输，（因为共识节点之间并不知道对方的IP地址), 即普通节点都可能收到共识数据包。共识消息的广播流程如下图。

![](..\images\consensus\consensus_msg_seq.jpg)

  1. 共识节点A， 直接将共识消息`consensus` 广播连接上的节点B

  2. 节点B在收到`consensus`消息后，先进行共识消息处理，再进行共识消息的转发。转发共识消息前，先发送`inv`消息，并携带上`consensus`消息的`payload`的hash数据。

  3. 若节点C已经收到过该hash对应的数据，或在短时间内，已经重复获取该`inv`消息时，则不处理；否则，进入步骤四。

  4. C向B发送`getdata`消息，附带上`inv`消息中的hash数据。

  5. 节点B收到`getdata`消息后，则发送`consenus`消息给对方。

  6. C节点收到`consensus`消息后，则触发共识模块对消息处理，以及转发该共识消息，回到步骤二。

### inv 消息格式

| 尺寸 | 字段 | 类型  | 说明 |
|------|------|-------|------|
|  4    | Magic |  uint | 网络p2p协议魔法数|
| 12   | Command | string | `inv`  |
| 4     | length    | uint32 | Payload长度|
| 4     | Checksum | uint | 校验码 |
| length   | Payload | byte[] | `0xe0` + `0x00000001` + `ConsensusPayload.Hash` |

> [!Note] 
>
> Payload格式为： `inv.type + inv.payloads.length + inv.payload`
> `inv` 消息的payload，有三种类型:
>
> - `0x01`: 交易， `inv.payload`存放为交易hash列表
> - `0x02`: 区块， `inv.payload`存放共识消息`ConsensusPayload`的hash列表
> - `0xe0`: 共识， `inv.payload`存放区块的hash列表

### getdata 消息格式

| 尺寸 | 字段 | 类型  | 说明 |
|------|------|-------|------|
|  4    | Magic |  uint | 网络p2p协议魔法数|
| 12   | Command | string | `getdata`  |
| 4     | length    | uint32 | Payload长度|
| 4     | Checksum | uint | 校验码 |
| length   | Payload | byte[] | `0xe0` + `0x00000001` + `ConsensusPayload.Hash` |

> [!Note] 
>
> `getdata` 消息主要用来获取 `inv`消息附带hash列表对应的具体内容。

## 共识消息处理

###  校验

1. 检查`ConsensusPayload.BlockIndex`。若小于或等于当前高度，则忽略该消息。

2. 检查验证脚本是否通过，若不通过则忽略消息。

3. 若本节点已经在该轮发出新区快，则忽略消息。

4. 检查共识版本号。若不等于当前共识协议版本号时，则忽略。

5. 检查`ConsensusPayload.PreHash` 和 `ConsensusPayload.BlockIndex`, 是否等于当前共识节点上下文的`PreHash`与`BlockIndex`。 若不是，则忽略。

6. 检查`ConsensusPayload.ValidatorIndex`，若超过当前议员总数时，则忽略。

7. 如有加载插件，使用插件对该消息进行校验，如失败则忽略。

### 处理

1. **PrepareRequest** 由一轮共识的议长发出，其中附带了`block`相关的数据：

    1. 检查节点自身，若`PrepareRequest`已接收过，或该节点正在尝试改变视图，则忽略该消息。

    2. 根据`ConsensusPayload.ValidatorIndex` 确定对方是不是本轮的议长，若不是，或信息的视图PrepareRequest.ViewNumber编号与当前视图不一致，则忽略。 

    3. 检查 `ConsensusPayload.Timestamp`， 若小于等于上一个区块的时间戳，或者超过了当前时间8个区块时间以上，则认为消息过期，忽略。

    4. 若提议包含的交易已经在区块链中，忽略消息。

    4. 检查对block的签名是否对。

    5. 过滤在此之前收到的不合法签名（Prepare-Reponse 消息可能先到达）。

    6. 收下议长附带的签名。

    7. 从内存池收集和验证提案block所需的交易。
    
        1. 若交易验证失败，或交易不满足策略要求，则认为交易数据不对，发起`ChangeView`消息.

        2. 否则收下该交易，存放到共识上下文中。

        3. 若提案块中的交易，已全部收集齐全，则对外广播`PrepareResponse`消息。

    8. 检查未确认交易池中包含的block所需的交易，首先进行交易验证，再将交易存放到共识上下文中，以便构建完整的区块。

    9. 若缺少`block`中的交易时，则广播`getdata`消息，附带缺少交易的hash列表。

2. **PrepareResponse** 是议员对议长发的`PrepareRequest`消息回应，并附带了对block的签名：

    1. 若消息的视图和当前视图不匹配，则忽略。

    2. 若对方签名已经收到过，或当前节点正在尝试改变视图，则忽略。
    
    3. 若在此之前尚未收到 `PrepareRequest` 消息时，则先收下该签名（后续收到PrepareRequest时，进行过滤）。否则进入步骤 4）。
    
    4. 校验对方的签名，若通过，则收下签名，否则忽略。

    5. 若本节点已发送过`Commit`信息，则忽略。
    
    6. 若本节点发送或接收过`PrepareRequest`，则检查签名数，若已经满足`N-f`个签名，则广播`Commit`信息，并检查本地已收到的Commit信息数量，若已收到`N-f`个，则出块并广播。

3. **Changeview** 议员或者议长，在遇到超时（议长第一次超时例外，发送`PrepareRequest`消息），或者校验失败时，则发送`ChangeView`消息。议员，议长收到`ChangeView`消息做如下处理：

    1. 若新视图编号，小于该议员之前的视图编号，则发送`RecoveryMessage`信息。

    2. 若该节点已发送过`Commit`信息，则忽略。
    
    3. 若有不少于`N-f`个议员的视图编号等于新视图编号时，则切换视图成功，当前议员重置共识流程，视图编号为新的视图编号。

4. **Commit** 议员或议长在接收到`N-f`个`PrepareResponse`后发出的信息，通知其他节点准备出块。

    1. 若之前已接收过同一节点发出的`Commit`信息，则忽略。

    2. 校验信息签名，若校验通过，将信息存放到共识上下文中，并检查本地已收到的Commit信息数量，若已收到`N-f`个，则出块并广播。

5. **RecoveryRequest** 议员或议长在开启共识，或已Commit节点与失效节点之和大于`f`个，则会广播该信息以获取最新共识状态。

    1. 若已接受过该信息，则忽略。

    2. 检查该节点是否有义务答复该信息（已发送过`Commit`信息，或编号在信息发出节点的编号后`f`内）

    3. 若该节点有义务答复，则发送`RecoveryMessage`信息

6. **RecoveryMessage** 议员或议长在接收到自己有回复权限的`RecoveryRequest`信息，或在已发送过`Commit`信息后超时，将广播该信息帮助其他节点获取最新共识状态。

    1. 若消息的视图编号大于本节点视图编号，则接收并处理消息中的`ChangeView`信息。

    2. 若消息的视图编号等于本节点视图编号，且本节点并未正在尝试改变视图或已发送过`Commit`信息，则接收并处理消息中的`PrepareRequest`和`PrepareResponse`信息。

    3. 若消息的视图编号小于等于本节点视图编号，则接收并处理消息中的`Commit`信息。

4. **onTimeout** 消息处理
  
    1. 若是议长超时，第一次超时发送`PrepareRequest`消息，后续则发起`ChangeView`消息。
    
    2. 若是议员超时，则直接发送`ChangeView`消息

5. **NewBlock** 事件处理

   重置共识过程。

6. **New Tx** 事件处理

    1. 若当前节点已经发送过`PrepareRequset`或者`PrepareResponse`消息，或正在切换视图中，或已经在本轮发出新块，则忽略该交易。

    2. 若已经收到过该交易，则忽略。

    3. 若交易不在待打包block里面，则忽略。

    4. 将交易收下，放到待打包的block里。
