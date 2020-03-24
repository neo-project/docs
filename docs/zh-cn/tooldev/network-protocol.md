# 网络架构：P2P

在网络结构上，NEO采用点对点网络结构，并使用TCP/IP协议进行通讯。

网络中存在两种节点类型，分别是普通节点和共识节点。普通节点可以广播、接收和转发交易、区块等，而共识节点可以创建区块。

NEO的网络协议规范与比特币的协议大致类似，但在区块、交易等的数据结构上有很大的不同。

> [!NOTE]
>
> - NEO网络中的种子节点不是共识节点，它们是普通节点的一种，向其它节点提供询问节点列表的服务。
> - NEO网络还支持WebSocket链接，以及通过UPnP协议来实现在局域网提供节点服务(Optional)。

## 通讯协议和端口：

| 协议 | 端口(主网) | 端口(测试网) |
|---|---|-----|
| TCP/IP | 10333 | 20333 |
| WebSocket | 10334 | 20334 |

> [!NOTE]
>
> 搭建NEO私有链时，可以设置端口为任意未使用的端口。节点之间也可以使用不同的端口。

## 报文：Message

报文(Message)的基本格式如下

| 类型 | 名称 | 说明 |
| --- | --- | --- |
| uint | Magic | 魔法数字用来避免网络冲突 |
| string(12) | Command | 字符串报文名称(不足12个字节时补零) |
| int | Payload length | Payload 长度 |
| uint | Payload Checksum | Payload 校验，避免篡改和传输错误 |
| byte[] | Payload | 报文的正文内容，根据报文种类不同而不同 |

## 命令列表(Command List)：

| 名称 | 唯一性 | 高优先级 | 保留 | 说明 |
| --- | --- | --- | --- | --- |
| addr | 〇 |  |  | 应答getaddr消息。发送最多不超过200条成功连接的节点地址和端口号。|
| block |  |  |  | 应答getdata消息。返回指定哈希值的Block。 |
| consensus |  | 〇 |  | 应答getdata消息。返回指定哈希值的共识数据。 |
| filteradd |  | 〇 |  | 向bloom_filter添加数据。用与轻量级钱包。 |
| filterclear |  | 〇 |  | 清空bloom_filter。用与轻量级钱包。 |
| filterload |  | 〇 |  | 初始化bloom_filter。用与轻量级钱包。 |
| getaddr | 〇 | 〇 |  | 询问其它节点的地址和端口号。 |
| getblocks | 〇 |  |  | 指定开始和结尾的哈希值，获取若干连续区块的详细信息。 |
| getdata |  |  |  | 询问其它节点获取指定种类和哈希的Inventory对象。<br>目前有以下场景发送getdata消息。<br>1)共识过程中发送获取交易(Transaction)的请求。<br>2)收到inv消息以后发送getdata消息。 |
| getheaders | 〇 |  |  | 在两个节点创建连接以后，少的一方向多的一方请求区块头。 |
| headers |  |  |  | 应答getheaders消息。最多发送不超过2000条区块头。 |
| inv |  |  |  | 发送指定种类和哈希值的若干个Inventory的哈希值数组（只有哈希值，没有完整数据）。Inventory的种类包括区块(Block)、交易(Transaction)、共识(Consensus)。目前有以下场景发送inv消息。<br>1)共识过程中发送交易。<br>2)应答getblocks消息。发送少于500个区块。<br>3)应答 mempool 消息。发送整个内存池中的交易。<br>4)传递(Relay)一个Inventory。<br>5)传递(Relay)一批交易。 |
| mempool | 〇 | 〇 |  | 请求对方节点整个内存池中的交易。 |
| tx |  |  |  | 应答getdata消息。返回指定哈希值的Transaction。 |
| verack | - | 〇 | - | 第二个指令：握手应答Version。 |
| version | - | 〇 | - | 第一个指令：携带区块头高度等信息。 |
| alert |  | 〇 | 〇 | 未实现 |
| merkleblock |  |  | 〇 | 发送已经实现，接收未实现。用于轻量级钱包。 |
| notfound |  |  | 〇 | 未实现 |
| ping |  |  | 〇 | 未实现 |
| pong |  |  | 〇 | 未实现 |
| reject |  |  | 〇 | 未实现 |
| 其它 |  |  | 〇 | 忽略 |

> [!NOTE]
>
> - 唯一性：同一时间在消息队列中只有一条此消息在排队。
> - 高优先级：系统需要保证高优先级的消息在网络中优先传播，优先处理。

## 对话协议

1. 首先NEO节点会与种子节点连接。

2. 节点连接成功后，首先会发送`version`消息，并等待接收`version`消息。`version`中携带区块高度。

3. 然后会发`verack`消息，并等待接收`verack`消息，完成握手。

4. 如果自己的区块头高度小于对方的区块高度，则向对方发送`getheaders`消息。

5. 对方收到`getheaders`消息后，通过`headers`消息应答发送不超过2000个区块头。

6. 如果区块头已经同步完成，而区块高度低于对方，则向对方发送`getblocks`消息。

7. 对方收到`getblocks`消息后，通过`inv`消息应答发送不超过500个区块的哈希值。

8. 收到`inv`消息后，通过哈希值判定本地是否需要。如果需要则发送`getdata`消息申请区块。

9. 对方收到`getdata`消息之后，发送`block`消息发送区块的完整内容。

10. NEO节点每5秒检查一次连接数，如果连接数不足10个，会主动去连接后备连接节点。后备连接节点不足时，会向已经连接的节点发送`getaddr`消息询问网络中其它节点的信息。

11. 对方节点收到`getaddr`消息后，通过`addr`消息应答发送不超过200个节点的地址和端口号。

12. 对于共识信息、区块、交易这些较大的数据，通过哈希值管理来避免同时从不同节点获取重复的数据。

13. 节点有义务将收到的共识信息、区块、交易这些信息通过`inv`消息转发给其它节点。

## 对话序列实例

| 消息方向 | 消息种类 | 说明 |
| --- | --- | --- |
| send | version | 发送version进行第一次握手 |
| receive | version | 接收version进行第一次握手 |
| send | verack | 发送verack进行第二次握手 |
| receive | verack | 接收verack进行第二次握手 |
| send | getheaders | 发送getheaders获取区块头 |
| receive | headers | 接收区块头 |
| send | getblocks | 发送getblocks获取区块 |
| receive | inv(blocks) | 收到inv若干区块的哈希值 |
| send | getdata(blocks) | 发送getdata获取若干区块的完整区块 |
| receive | inv(consensus) | 收到inv一个共识数据的哈希值 |
| send | getdata(consensus) | 发送getdata获取指定哈希值的共识数据 |
| receive | consensus | 收到一个完整的共识数据 |
| send | inv(consensus) | 将收到的共识的哈希值转发给其它节点 |
| receive | block | 收到一个完整的区块 |
| send | inv(block) | 转发区块的哈希 |
| receive | block | 收到一个完整的区块 |
| send | inv(block) | 转发区块的哈希 |
| receive | block | 收到一个完整的区块 |
| send | inv(block) | 转发区块的哈希 |
| ... | ... | ... |
