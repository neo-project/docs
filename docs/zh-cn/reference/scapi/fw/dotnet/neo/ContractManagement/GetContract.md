# ManagementContract.GetContract 方法

获取合约信息。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Contract GetContract(UInt160 hash);
```

参数：

- hash: 合约哈希度；

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static byte[] ScriptHash = "0xf32bcab10aeadcd0bb60b9b4ddd7ff9fb9b9a5a0".HexToBytes(reverse: true);

    public static object GetContract()
    {
        Contract contract = ManagementContract.GetContract((UInt160)ScriptHash);
        return contract != null;
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{
    "type":"Boolean",
    "value":true
}]
```

响应说明：

- Boolean类型：true表示所查询的合约已部署。

- 其他：失败。

[返回上级](../ManagementContract.md)
