# SetMaxBlockSystemFee 方法

设置区块最大系统手续费。

命名空间：[Neo.SmartContract.Framework.Native](../../Neo.SmartContract.Framework.Native.md)

程序集：Neo.SmartContract.Framework

> [!Note]
> 
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 语法

```c#
public static extern bool SetMaxBlockSystemFee(long value);
```

参数：

- value: 待设置的区块最大系统手续费

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxBlockSystemFee(4007800L);
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

- Boolean类型：true表示设置区块最大系统手续费成功。

- 其他：失败。

> [!Note]
>
> 设置的手续费值应不小于4007600。

[返回上级](../Policy.md)