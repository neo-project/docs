# 大小端序的使用

Neo 系统中所有的整数类型都是采用小端序 (Little Endian) 编码，只有在传输 IP 地址和端口号采用大端序 (Big Endian) 编码。

开发者在实际使用过程中，特别是通过SDK构造交易来转账或者调用合约的时候，需要正确使用钱包地址ScriptHash的大小端序格式，否则可能导致资产的丢失。

本文将结合几个常见的应用场景，介绍如何正确使用钱包地址或者合约ScriptHash的字节序格式。

## 地址和 ScriptHash
### 钱包地址的ScriptHash
在Neo区块链中创建钱包时都会生成私钥、公钥、钱包地址以及对应的ScriptHash。

以下是一个钱包的标准地址和ScriptHash大小端序的示例： 

- 地址 (address): AceQbAj2xuFLiH5hQAHMnV39wtmjUKiVRj
- ScriptHash
  - 大端序：0x946d6caa602a2b85fbeb7cf05335b2c3b124f1e4
  - 小端序：e4f124b1c3b23553f07cebfb852b2a60aa6c6d94

要进行钱包地址与ScriptHash的互转，以及ScriptHash的大小端序之间的互转，可以使用以下一种方法:

- [数据转换工具](https://peterlinx.github.io/DataTransformationTools/)

### 合约的ScriptHash
每一个合约部署成功后，会生成一个ScriptHash作为该合约的唯一标识符。Neo的合约对应的ScriptHash可以转换为20个字节的标准地址，用来接收NEP5资产。这种情况下合约的ScriptHash作为大端序使用，例如：

- CGas ScriptHash (大端序)：0x 74f2dc36a68fdc4682034178eb2220729231db76 

- CGas合约对应的地址：AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM

## 大小端序使用场景
钱包地址的使用常见于全局资产转账交易和智能合约调用，这里我们主要针对这两个场景来介绍如何使用地址ScriptHash的字节序格式。
### 全局资产转账交易
当使用Neo SDK构造全局资产转账交易(ContractTransaction)时, 需要为转账资产的接收人构造相应的Output。如下所示，需要在 TransactionOutput 中填写资产接收人的钱包地址所对应的ScriptHash, 这里应该使用**大端序**的格式：

```
var outputs = new List<TransferOutput>{ new TransferOutput()
{
    AssetId = Blockchain.UtilityToken.Hash, //GAS对应的AssetId
    ScriptHash = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(), //地址对应的大端序ScriptHash
    Value = new Fixed8((long)(0.999 * (long)Math.Pow(10, 8)))
}}.ToArray();
```

### 智能合约调用
在调用智能合约时，有的场景下需要传入钱包地址对应的ScriptHash，这时要注意使用正确的大小端序格式。

#### 通过RPC接口调用合约

这里以 [InvokeFunction](../../reference/rpc/latest-version/api/invokefunction.html) 为例，调用 NEP-5 合约的 balanceOf 方法。

如果传入的地址，参数类型为Hash160，需要使用**大端序**的地址ScriptHash。

```
    {
        "jsonrpc": "2.0",
        "method": "invokefunction",
        "params": [
            "74f2dc36a68fdc4682034178eb2220729231db76",
            "balanceOf",
            [
            {
                "type": "Hash160", //数据类型使用Hash160
                "value": "946d6caa602a2b85fbeb7cf05335b2c3b124f1e4" //地址ScriptHash为大端序
            }
            ]
        ],
        "id": 3
    }
```

如果参数类型为ByteArray，需要使用**小端序**的地址ScriptHash。

```
{
    "jsonrpc": "2.0",
    "method": "invokefunction",
    "params": [
        "74f2dc36a68fdc4682034178eb2220729231db76",
        "balanceOf",
        [
        {
            "type": "ByteArray", //数据类型ByteArray
            "value": "e4f124b1c3b23553f07cebfb852b2a60aa6c6d94" //地址ScriptHash为小端序
        }
        ]
    ],
    "id": 3
}
```

#### 通过SDK构造调用合约的交易


如果使用Neo-SDK构造InvocationTransaction，调用合约的执行脚本需要通过ScriptBuilder构造，这时应该使用**小端序**的地址ScriptHash作为参数。这里我们使用Neo-SDK JavaScript [neon-js](http://cityofzion.io/neon-js/en/)版本为例：

```
const { default: Neon, api, rpc, wallet, tx, u } = require("@cityofzion/neon-js");
const privateKey = "8fdebad22fe4a13b6f430120b784606213eb123a54118b6b265bbc896015fd21";
const account = new wallet.Account(privateKey);
const cgasContractHash = "74f2dc36a68fdc4682034178eb2220729231db76"; //CGAS ScriptHash

const fromAddressLittle = Neon.u.reverseHex(wallet.getScriptHashFromAddress("Abjdb3tegQmAjXVAAYuQPHG9Lw4j2mjUhT")); // address -> ScriptHash (小端序)
const toAddressLittle = Neon.u.reverseHex(wallet.getScriptHashFromAddress("AceQbAj2xuFLiH5hQAHMnV39wtmjUKiVRj")); // address -> ScriptHash (小端序)
sb.emitAppCall(cgasContractHash, "balanceOf", [fromAddressLittle, toAddressLittle, 250000000]);
var script = sb.str;

const rpcClient = new rpc.RPCClient("http://seed10.ngd.network:20332");
rpcClient.invokeScript(script)
    .then(response => {
        console.log(response.stack);
    })
    .catch(err => {
        console.log(err);
    });
```

合约执行完成后，可以通过[getapplicationlog 方法](../../reference/rpc/latest-version/api/getapplicationlog.md) 查看执行日志，执行日志在输出地址的时候，是以ByteArray为数据类型，输出地址相对应的小端序ScriptHash。
