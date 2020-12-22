# SetGasPerBlock 方法 (BigInteger)

设置每出一个区块所产生的GAS数。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 语法

```c#
public static extern bool SetGasPerBlock(BigInteger gasPerBlock);
```

参数：

- gasPerBlock: 每区块所产生的GAS数

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        BigInteger gasPerBlock  = 10;
        bool result = NEO.SetGasPerBlock(gasPerBlock);
        return result;
    }
}
```

响应正文：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示成功转账。

- 其他：失败。

[返回上级](../Neo.md)