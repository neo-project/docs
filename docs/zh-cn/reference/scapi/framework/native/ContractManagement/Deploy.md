# ContractManagement.Deploy 方法

部署合约。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Contract Deploy(ByteString nefFile, string manifest);
public static extern Contract Deploy(ByteString nefFile, string manifest, object data);
```

参数：

- nefFile：合约nef数据，字节数组；
- manifest：定义合约的元数据信息，Json字符串。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static byte[] nef = "4e4546336e656f6e00000000000000000000000000000000000000000000000000000000332e302e302e30000000000000000000000000000000000000000000000000000211407060ba5f".HexToBytes();
    private static string manifest = "{\"name\":\"\",\"groups\":[],\"supportedstandards\":[],\"abi\":{\"methods\":[{\"name\":\"update\",\"parameters\":[],\"offset\":0,\"returntype\":\"Any\",\"safe\":false}],\"events\":[]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"extra\":null}";

    public static object Deploy()
    {
        Contract contract = ContractManagement.Deploy(nef, manifest);
        return contract.Hash;
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{
    "type":"ByteString",
    "value":"fbKpbpzeGaTQ5xgyBeVh0JkNcPo="
}]
```

响应说明：

- ByteString类型：已部署合约的哈希。

- 其他：失败。

通常，可在合约内定义`_deploy`方法，并直接通过neo-cli执行命令`deploy contract.nef`部署合约。系统将在合约部署之后自动执行`_deploy`方法内的相关逻辑。方法定义如下：

```c#
public static void _deploy(object data, bool update)
{
    if (update) return;
    // Add other logics after the contract is deployed
}
```

[返回上级](../ContractManagement.md)
