# RPC 调用方法

`Neo RPC SDK` 封装了所有 `RpcServer` 提供的接口，可以通过该模块中提供的标准方法在代码中发送 RPC 请求，只需要传入相应的参数，SDK 就会根据参数构造相应的 JSON-RPC 请求，进而获得节点返回的数据。


## 初始化
发送 RPC 请求需要先初始化 `RpcClient` 类型，可以根据自己的需要选择一个 Neo 节点的 RPC Server 端口，这里举例说明：

测试网节点：

```c#
// TestNet Node
RpcClient client = new RpcClient("http://seed1t.neo.org:20332");
```

本地节点（本地节点是本地维护的 Neo-CLI，可以根据配置连接主网，测试网或者私链）：

```c#
// Local Node
RpcClient client = new RpcClient("http://localhost:10332");
```

> [!Note]
>
> 一个应用程序中一般只需要初始化一个 `RpcClient` 实例，而不需要在每个方法中初始化。

## 区块链数据

### 获取最新区块哈希
获取区块链中高度最大的区块的哈希：

```c#
string hexString = client.GetBestBlockHash();
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### 获取区块完整信息
可以通过区块散列值或者区块索引获取具体的区块信息：

```c#
Block block = client.GetBlock("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e").Block;
```

或者

```c#
Block block = client.GetBlock("10000").Block;
```

也可以通过区块散列值或者区块索引获取序列化后的区块信息：

```c#
string serializedBlock = client.GetBlockHex("773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e");
```

### 获取当前区块数量
区块索引（Index） = 区块高度（Height） = 区块数量（Count） - 1

```c#
uint blockCount = client.GetBlockCount();
```

### 根据区块索引获取区块的散列：

```c#
string hexString = client.GetBlockHash(10000);
byte[] hashBytes = hexString.HexToBytes();
UInt256 hash256 = UInt256.Parse(hexString);
```

### 获取区块头信息
可以通过区块散列值或者区块索引获取具体的区块头信息：

```c#
Header header = client.GetBlockHeader("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957").Header;
```

或者

```c#
Header header = client.GetBlockHeader("10000").Header;
```

也可以通过区块散列值或者区块索引获取序列化后的区块头信息：

```c#
string serializedBlockHeader = client.GetBlockHeaderHex("a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957");
```

### 获取系统手续费
通过指定的索引获取截止到该区块前的系统手续费：

```c#
BigInteger sysFee = client.GetBlockSysFee(10000);
```

### 获取合约信息
通过合约哈希获取合约信息：

```c#
ContractState contractState = client.GetContractState("dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f");
```

通过合约Id获取合约信息：

```c#
ContractState contractState = client.GetContractState(-1);
```

### 获取内存中的交易列表
只获取内存中已确认的交易散列列表：

```c#
string[] verifiedTransactions = client.GetRawMempool();
```

同时获取内存中已确认和未确认的交易散列列表：

```c#
RpcRawMemPool memPool = client.GetRawMempoolBoth();
string[] verifiedTransactions = memPool.Verified;
string[] unverifiedTransactions = memPool.UnVerified;
```

### 获取交易信息
通过交易 ID 来获取对应的交易信息：

```c#
RpcTransaction rpcTransaction = client.GetRawTransaction("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
Transaction transaction = rpcTransaction.Transaction;
```

也可以通过交易 ID 来获取对应的序列化后的交易：

```c#
string serializedTransaction = client.GetRawTransactionHex("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
```

### 获取合约存储区的值
通过合约脚本散列和存储的`键`（需要转化为 hex string）获取对应存储的值：

```c#
string value = client.GetStorage("03febccf81ac85e3d795bc5cbd4e84e907812aa3", "5065746572");
```

### 获取指定交易的高度
通过交易 ID 获取指定交易所在的区块高度：

```c#
uint height = client.GetTransactionHeight("f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657");
```

### 获取当前共识节点的信息
获取当前网络中共识节点的信息及投票情况：

```c#
RpcValidator[] rpcValidators = client.GetValidators();
foreach (var validator in rpcValidators)
{
    string publicKey = validator.PublicKey;
    BigInteger voteCount = validator.Votes;
    bool isActive = validator.Active;
}
```

## 节点

### 获取节点连接数
获取连接到该节点的节点数量：

```c#
int connectionCount = client.GetConnectionCount();
```

### 获取已连接/未连接的节点
获得该节点当前已连接/未连接的节点列表，包括 IP 地址和端口：

```c#
RpcPeers rpcPeers = client.GetPeers();
RpcPeer[] connected = rpcPeers.Connected;
RpcPeer[] unconnected = rpcPeers.Unconnected;
if (connected.Length > 0)
{
    RpcPeer peer = connected[1];
    string address = peer.Address;
    int port = peer.Port;
}
```

### 获取节点的版本信息
获取接收 RPC 请求的节点的版本信息：

```c#
RpcVersion rpcVersion = client.GetVersion();
string version = rpcVersion.UserAgent;
```

### 广播交易
发送并广播序列化后的交易：

```c#
bool result = client.SendRawTransaction("80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac");
```

当 `result` 为 `true` 时表明当前交易广播成功；
当 `result` 为 `false` 时表示当前交易广播失败，原因可能有双重花费、签名不完整等。

### 广播区块
发送并广播序列化后的区块：

```c#
bool result = client.SubmitBlock("000000000000000000000000000000000000000000000000000000000000000000000000845c34e7c1aed302b1718e914da0c42bf47c476ac4d89671f278d8ab6d27aa3d65fc8857000000001dac2b7c00000000be48d3a3f5d10013ab9ffee489706078714f1ea2010001510400001dac2b7c00000000400000455b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e882a1227d2c7b226c616e67223a22656e222c226e616d65223a22416e745368617265227d5d0000c16ff28623000000da1745e9b549bd0bfa1a569971c77eba30cd5a4b00000000400001445b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e5b881227d2c7b226c616e67223a22656e222c226e616d65223a22416e74436f696e227d5d0000c16ff286230008009f7fd096d37ed2c0e3f7f0cfc924beef4ffceb680000000001000000019b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50000c16ff2862300be48d3a3f5d10013ab9ffee489706078714f1ea201000151");
```

当 `result` 为 `true` 时表明区块广播成功；
当 `result` 为 `false` 时，区块广播失败并引发异常。

## 智能合约

### 调用智能合约的特定方法
通过指定的智能合约脚本散列、方法名和参数在虚拟机中运行后返回结果：

```c#
RpcStack rpcStack = new RpcStack()
{
    Type = "Hash160",
    Value = "91b83e96f2a7c4fdf0c1688441ec61986c7cae26"
};
UInt160 scriptHashesForVerifying = UInt160.Parse("0x20e22e16cfbcfdd29f347268427b76863b7679fa");
RpcInvokeResult rpcInvokeResult = client.InvokeFunction("af7c7328eee5a275a3bcaee2bf0cf662b5e739be", "balanceOf", new RpcStack[] { rpcStack },scriptHashesForVerifying);
string script = rpcInvokeResult.Script;
string engineState = rpcInvokeResult.State;
long gasConsumed = long.Parse(rpcInvokeResult.GasConsumed);
ContractParameter[] resultStacks = rpcInvokeResult.Stack;
foreach (var item in resultStacks)
{
    ContractParameterType contractParameterType = item.Type;
    object value = item.Value;
}
string transaction = rpcInvokeResult.Tx;
```

### 调用指定脚本
通过在虚拟机中运行指定脚本后返回结果：

```c#
byte[] script = "00046e616d656724058e5e1b6008847cd662728549088a9ee82191".HexToBytes();
UInt160 scriptHashesForVerifying = UInt160.Parse("0x20e22e16cfbcfdd29f347268427b76863b7679fa");
RpcInvokeResult rpcInvokeResult = client.InvokeScript(script,scriptHashesForVerifying);
```



## 工具

### 获取插件信息
显示节点已加载的插件列表：

```c#
RpcPlugin[] rpcPlugins = client.ListPlugins();
foreach (var item in rpcPlugins)
{
    string name = item.Name;
    string version = item.Version;
}
```

### 验证地址
验证指定地址是否是正确的 Neo 地址：

```c#
RpcValidateAddressResult result = client.ValidateAddress("AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i");
bool isValid = result.IsValid;
```

## 节点本地钱包
节点本地钱包接口包含可以访问节点本地钱包文件的功能，使用该部分的方法之前需要先通过 `openwallet` 方法打开钱包。
节点的配置文件默认禁用此方法，因为有很高的安全风险。

### 关闭钱包
关闭钱包将清除内存中的钱包信息：

```c#
bool result = client.CloseWallet();
```

### 导出私钥
导出指定地址的私钥：

```c#
string wif = client.DumpPrivKey("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ");
```

### 余额查询
根据指定的资产编号，返回钱包中对应资产的余额信息。该方法适用于原生合约资产及符合 NEP-5 标准的合约资产：

```c#
BigInteger balance = client.GetBalance(NativeContract.NEO.Hash.ToString());
```

### 创建账号
在打开的钱包文件中创建一个新的账号，并返回该账号的地址：

```c#
string address = client.GetNewAddress();
```

### 获取可提取的 GAS 数量
显示钱包中未提取的 GAS 数量:

```c#
BigInteger amount = client.GetUnclaimedGas();
```

### 导入私钥
导入私钥到钱包：

```c#
string wif = "KyoYyZpoccbR6KZ25eLzhMTUxREwCpJzDsnuodGTKXSG8fDW9t7x";
RpcAccount account = client.ImportPrivKey(wif);
```

### 列出钱包账号
列出当前钱包内的所有地址:

```c#
List<RpcAccount> acoounts = client.ListAddress();
```

### 打开钱包
打开节点所在机器中的钱包文件：

```c#
string path = "D:/temp/123.json";
string pass = "Password***";
bool result = client.OpenWallet(path, pass);
```

### 从指定地址转账
从指定地址，向指定地址转账：

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string fromAddress = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
string toAddress= "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = client.SendFrom(assetId, fromAddress, toAddress, amount);
```
返回JSON交易详情说明交易发送成功，否则交易发送失败。
如果签名不完整会返回待签名的交易。
如果余额不足会返回错误信息。

### 批量转账
批量转账命令，并且可以指定发送地址：

```c#
List<RpcTransferOut> outs = new List<RpcTransferOut>();
outs.Add(new RpcTransferOut
{
    Asset = NativeContract.NEO.Hash,
    ScriptHash = Utility.GetScriptHash("NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ"),
    Value = "100"
});
outs.Add(new RpcTransferOut
{
    Asset = NativeContract.GAS.Hash,
    ScriptHash = Utility.GetScriptHash("NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW"),
    Value = "100.12345678"
});
JObject result = client.SendMany("", outs);
```
返回JSON交易详情说明交易发送成功，否则交易发送失败。
如果签名不完整会返回待签名的交易。
如果余额不足会返回错误信息。

### 向指定地址转账
向指定地址转账：

```c#
string assetId = NativeContract.NEO.Hash.ToString();
string toAddress = "NZs2zXSPuuv9ZF6TDGSWT1RBmE8rfGj7UW";
string amount = "100";
JObject result = client.SendToAddress(assetId, toAddress,amount);
```
返回JSON交易详情说明交易发送成功，否则交易发送失败。
如果签名不完整会返回待签名的交易。
如果余额不足会返回错误信息。

## 插件

### 查询交易日志
根据指定的交易 ID 获取合约日志：
需要节点安装 ApplicationLogs 插件才可以调用。

```c#
string txHash = "0x23bf33766d00b4bb3314185f1ff0c2c85182d4d5e4e96f7c2df7506e7f99098b";
RpcApplicationLog log = client.GetApplicationLog(txHash);
```

### 查询 NEP-5 资产余额
返回指定地址内的所有 NEP-5 资产余额：
需要节点安装 RpcNep5Tracker  插件才可以调用。

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep5Balances balances = client.GetNep5Balances(address);
```

### 查询交易记录
返回指定地址内的所有 NEP-5 交易记录：
需要节点安装 RpcNep5Tracker  插件才可以调用。
如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
如果不设置此参数，则返回近七天内的交易信息。

```c#
string address = "NVVwFw6XyhtRCFQ8SpUTMdPyYt4Vd9A1XQ";
RpcNep5Transfers transfers = client.GetNep5Transfers(address, 0);
```

### 阅读下节

[获取区块信息](monitor.md)

