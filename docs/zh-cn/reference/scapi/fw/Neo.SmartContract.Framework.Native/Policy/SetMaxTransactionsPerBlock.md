# SetMaxTransactionsPerBlock 方法

设置每区块最大能打包的交易个数。

命名空间：[Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 语法

```c#
public static extern bool SetMaxTransactionsPerBlock(uint value);
```

参数：

- value: 待设置的最大交易数

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxTransactionsPerBlock(1024);
        return result;
    }
}
```
部署后，调用该合约，响应正文为：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示设置区块包含最大交易量成功。

- 其他：失败。

[返回上级](../Policy.md)