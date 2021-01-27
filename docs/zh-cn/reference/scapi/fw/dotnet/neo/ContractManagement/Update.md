# Update 方法 (byte[], string)

更新合约。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Update(byte[] nefFile, string manifest);
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

    public static void Update()
    {
        if (!Runtime.CheckWitness(Owner)) throw new Exception("No authorization.");
        ManagementContract.Update(nef, manifest);
    }
}
```

响应正文：

```json
[{"type":"Any"}]
```

响应说明：

- Void类型：更新成功。

- 其他：失败。

注意： 更新后合约哈希保持不变。

[返回上级](../ManagementContract.md)
