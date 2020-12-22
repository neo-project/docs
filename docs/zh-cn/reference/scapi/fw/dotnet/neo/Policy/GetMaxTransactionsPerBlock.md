# GetMaxTransactionsPerBlock 方法 ()

获取区块包含最大交易数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern uint GetMaxTransactionsPerBlock();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        uint result = Policy.GetMaxTransactionsPerBlock();
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Integer",
	"value":"500"
}
```

响应说明：

- Integer类型：成功获取区块包含最大交易量。
- 其他：失败。

[返回上级](../Policy.md)