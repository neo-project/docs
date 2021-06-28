# 给用户分发 GAS

交易所可以选择是否给用户分发 GAS。GAS 用来支付 Neo 区块链的记账费和附加服务费。

## 什么是 GAS ?

GAS（缩写符号 GAS）代表了 Neo 区块链的使用权。只要获得 NEO，GAS 便会在系统中按照算法自动生成。

在 Neo N3 中，每当一个地址有 NEO 转入或转出时，就会自动提取 GAS，所提取的数量是该地址自上次 NEO 转账后到现在所产生的 GAS 数。

## 计算提取的 GAS 总量

提取的 *GAS = f(neo_amount, Δt_const)*

-  Δt_const = t_end - t_start
   -  t_end = 该地址的 NEO 此次发生转入或转出操作的时刻
   -  t_start = 该地址的 NEO 上次发生转入或转出操作的时刻

由于 Δt 是定量，所以提取的 GAS 也是一个定量。提取 GAS 的大小取决于所持有的 NEO 数量以及两个状态的时间差。

## 给用户分发 GAS

假设交易所的所有地址都在一个钱包里，下图显示了交易所向某用户 A 分发 GAS 的流程和计算公式：



![gasflow](../node/assets/gasflow.png)



快照间隔越短，计算越精确。如果快照时间间隔不均匀，可以采用加权平均算法。

> [!Note]
>
> 在 NEO N3 中，由于交易所用户无法参与投票，所以固定收益为计算提取的 GAS 总量的10%。具体可见[GAS 分配规则](https://docs.neo.org/docs/zh-cn/basic/governance.html#gas-%E5%88%86%E9%85%8D%E8%A7%84%E5%88%99)。

## RPC 方法

以下 RPC 方法可以帮助交易所查询用户 GAS 信息。要查看调用的 JSON 文件示例，点击表格中的链接。

| 方法                                                         | 描述                                    |
| ------------------------------------------------------------ | --------------------------------------- |
| [getunclaimedgas](../reference/rpc/latest-version/api/getunclaimedgas.md) | 显示当前钱包内所有地址生成的 GAS 数量。 |

## 交易所提取 GAS

对某地址完成一次 NEO 转入或转出即可自动提取 GAS，例如：地址 A 中有 NEO，GAS 为未提取状态， 那么只需要将 NEO 转给自己，GAS 即会被自动提取到该地址。

具体提取步骤和命令请参见下表。

| #    | 步骤                                                         | 输入命令                                        |
| ---- | :----------------------------------------------------------- | ----------------------------------------------- |
| 1    | 运行客户端                                                   | `dotnet neo-cli.dll`                            |
| 2    | 查看客户端版本                                               | `version`                                       |
| 3    | 查看客户端同步高度（Height: 区块高度 / 区块头高度，Nodes: 连接节点数量） | `show state`                                    |
| 4    | 打开钱包                                                     | `open wallet /home/NeoNode/test.json`           |
| 5    | 查看钱包里的地址和资产                                       | `list asset`                                    |
| 6    | 获取钱包里未提取的 GAS 余额详情                              | `show gas`                                      |
| 7    | 给自己的钱包地址 （如 NTdzVdQ8SmFobD1XWCA1fR9tQr7gFv1SXf）转账，GAS 将会被自动提取到该地址 | `send neo NTdzVdQ8SmFobD1XWCA1fR9tQr7gFv1SXf 1` |
| 8    | 查看钱包资产，确认提取成功                                   | `list asset`                                    |

