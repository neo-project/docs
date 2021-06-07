# ContractManagement.Destroy 方法

销毁合约。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Destroy();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 Owner = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

    public static void Destroy()
    {
        if (!Runtime.CheckWitness(Owner)) throw new Exception("No authorization.");
        ContractManagement.Destroy();
    }
}
```

部署后，调用该合约，响应正文为：

```json
[{"type":"Any"}]
```

响应说明：

- Void类型：合约销毁成功。

- 其他：失败。

[返回上级](../ContractManagement.md)
