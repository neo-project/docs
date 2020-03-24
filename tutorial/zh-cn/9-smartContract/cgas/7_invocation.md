# 测试和调用 CGAS

本节课我们讲一下在 CGAS 发布后，如何对它进行测试和调用。

测试的主要技术就是通过 SDK 构造交易，然后发送到节点中，再查询执行结果。

## 构造交易

首先调用智能合约的过程就是构造一笔 InvocationTransaction 的过程，一笔 InvocationTransaction 的数据结构如下：

| 字节数 | 字段       | 类型      | 描述                           |
| ------ | ---------- | --------- | ------------------------------ |
| 1      | Type       | byte      | 交易类型                       |
| 1      | Version    | byte      | 交易版本号，目前为 0 或 1      |
| ?      | -          | -         | 特定交易的数据                 |
| ?*?    | Attributes | tx_attr[] | 该交易所具备的额外特性         |
| 34*?   | Inputs     | tx_in[]   | 输入                           |
| 60 * ? | Outputs    | tx_out[]  | 输出                           |
| ?*?    | Witnesses  | Witness[] | 用于验证该交易的脚本列表       |
| ?*?    | Script     | byte[]    | 包含该交易中智能合约的调用脚本 |

目前调用 CGAS 只能通过 SDK 来自行构造 InvocationTransaction，neo-gui，neo-cli 等客户端无法完美支持 CGAS（只支持 NEP-5 中的方法，不支持 CGAS 的 mintTokens，refund 等方法）。

具体的项目创建、引用 SDK，构造交易可以参考这个项目：[CGAS UnitTests](https://github.com/neo-ngd/CGAS-Contract/blob/master/UnitTests)。

以 MintTokens 为例，下面对构造交易的代码进行讲解。

```c#
public static void MintTokens()
{
    var inputs = new List<CoinReference> {
        new CoinReference(){
            PrevHash = new UInt256("0xf5088ce508d86197c991ff0ef7651ddf01f3e555f257039c972082250e899210".Remove(0, 2).HexToBytes().Reverse().ToArray()),
            PrevIndex = 0
        }
    }.ToArray();
    //在 UTXO 模型中，一个交易输入必定是之前某个交易的交易输出，所以这里用两个字段表示一个交易输入。一个是引用的是之前某个交易的 TxId，也就是 PrevHash，另外一个是引用的交易输出在交易中的索引，索引从 0 开始。在上面的例子中，引用了 0xf5088ce508d86197c991ff0ef7651ddf01f3e555f257039c972082250e899210 这个交易的第 0 号交易输出作为当前这个交易的交易输入。

    var outputs = new List<TransactionOutput>{ new TransactionOutput()
    {
        AssetId = Blockchain.UtilityToken.Hash, //Asset Id, this is GAS
        ScriptHash = ScriptHash, //CGAS 地址
        Value = new Fixed8((long)(1 * (long)Math.Pow(10, 8)))
    }}.ToArray();
    //交易输出包含三个字段，资产 ID，收款方的 ScriptHash，以及转账金额。在 SDK 中，转账金额的单位是聪，所以这里填写 1 亿，代表通常所说的 1。

    Transaction tx = null;
    //声明一个 Transaction 对象

    using (ScriptBuilder sb = new ScriptBuilder())
    {
        sb.EmitAppCall(ScriptHash, "mintTokens");
        sb.Emit(OpCode.THROWIFNOT);

        byte[] nonce = new byte[8];
        Random rand = new Random();
        rand.NextBytes(nonce);
        sb.Emit(OpCode.RET, nonce);
        tx = new InvocationTransaction
        {
            Version = 1,
            Script = sb.ToArray(),
            Outputs = outputs,
            Inputs = inputs,
            Attributes = new TransactionAttribute[0],
            Witnesses = new Witness[0]
        };
    }
    //这段代码参考自 neo 项目，https://github.com/neo-project/neo/blob/master/neo/Wallets/Wallet.cs#L282 照着写就好了
    
    var sign = new SignDelegate(SignWithWallet);
    sign.Invoke(tx, "1.json", "11111111");
    //打开钱包，使用该钱包对交易进行签名，需要注意的是，交易输入的 UTXO 是要在这个钱包里才可以，否则会签名失败
    
    Verify(tx);
    //验证交易
}
```

最开始是构造交易输入和交易输出，交易输入是来自自己的地址，交易输出是 CGAS 的地址。其中交易输入不可复用，每次测试都要使用未花费的交易输入。

交易输入包含以下两个字段：PrevHash，PrevIndex，分别表示所使用的交易输出的交易 ID 和索引。

这里要清楚一个概念，在 UTXO 模型中，所有的交易输入必定是之前某个交易的交易输出，这样形成了一个完成的链条。一个交易输出可以用一个“复合主键”来表示，就是交易 ID 和交易输出的索引。这就是交易输入的字段，它引用了一个交易输出的“主键”，而并非引用交易输出的完整数据。

然后开始构造一个 InvocationTransaction，最重要的就是里面的 Script 字段。这里通过 SDK 中的 ScriptBuilder 类进行创建。

交易构造完成后，对交易进行签名，签名的内容会写在交易的 Witness 字段中。

最后在本地进行交易验证，交易验证包括：

1. 交易的格式是否正确。

2. 交易的大小是否超过限制（目前是 100KB）。

3. 在一笔交易中是否使用了两个相同的 UTXO。

4. 内存池中的交易是否包括该交易所使用的 UTXO。

5. 是否双重花费（区块链中的的交易是否包括该交易所使用的 UTXO）。

6. 交易中的资产是否过期，转账精度是否符合要求，资产是否存在。

7. 交易中的输入和输出是否是平账的（GAS 除外）。

8. 系统手续费是否合法。

9. 如果交易是 MinerTransaction、 ClaimTransaction、IssueTransaction，是否满足 GAS 的规则。

10. 交易属性是否合法。

11. 交易的验证脚本是否通过（即执行 Trigger.Verify 部分的代码）。

建议开发者要构造交易的时候要本地单步调试以便发现问题所在。

## 安装 ApplicationLogs 插件

目前比较方便的查询交易结果的方式是要安装 ApplicationLogs 插件，其作为是在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。

安装方法参考：[NEO 客户端插件](https://docs.neo.org/zh-cn/node/plugin.html)

需要说明的是，一定要先安装插件，再发送交易。

## 发送交易，查询执行结果

如果交易验证无误，可以调用这个方法来输出交易的二进制数据

```c#
tx.ToArray().ToHexString();
```

关于如何发送交易，请参考：

[neo-cli API 测试工具](https://docs.neo.org/zh-cn/node/cli/latest-version/api.html#%E6%B5%8B%E8%AF%95%E5%B7%A5%E5%85%B7)

[sendrawtransaction API](https://docs.neo.org/zh-cn/node/cli/latest-version/api/sendrawtransaction.html)

查询交易执行结果，请参考：

[getapplicationlog 方法](https://docs.neo.org/zh-cn/node/plugin.html#getapplicationlog-%E6%96%B9%E6%B3%95)

执行结果包括：交易 ID，触发器，调用的合约 ScriptHash，虚拟机执行状态，GAS 花费，返回值以及通知。

下面是一个典型的执行结果：

```json
{
	"txid": "0x48bd784d0ed6000cba64d0e303117e4c10081e3268afcf3b07e8b353a7594772",
	"vmstate": "HALT, BREAK",
	"gas_consumed": "4.648",
	"stack": [],
	"notifications": [{
		"contract": "0x74f2dc36a68fdc4682034178eb2220729231db76",
		"state": {
			"type": "Array",
			"value": [{
				"type": "ByteArray",
				"value": "7472616e73666572"
			}, {
				"type": "ByteArray",
				"value": ""
			}, {
				"type": "ByteArray",
				"value": "e8e3ce08268d16d867101feaf8c0ea130a923aba"
			}, {
				"type": "Integer",
				"value": "1000000000"
			}]
		}
	}]
}
```

vmstate：HALT, BREAK 表示执行成功，其它情况表示执行失败。

gas_consumed： 其中 gas_consumed 表示该交易消耗的 GAS 数量，即交易手续费。每笔交易会有10 
GAS 的免费额度。如果数量小于 10，则不收取手续费，如果大于 10，那么收取超过 10 的那部分作为手续费并向上取整。例如 gas_consumed = 12.3，那么实际收取的手续费为 3 GAS。在测试中要注意手续费消耗，尽量控制在 10 以下。

其中通知部分如何转成可读的数据，参见 [ApplicationLogsTools](https://github.com/chenzhitong/ApplicationLogsTools) 项目。

## 返回上节

[签名与验证](6_signature_and_verification.md)

