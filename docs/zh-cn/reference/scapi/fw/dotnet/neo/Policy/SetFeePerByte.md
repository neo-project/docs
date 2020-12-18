# SetFeePerByte 方法 (long)

设置每字节手续费。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 语法

```c#
public static extern bool SetFeePerByte(long value);
```

参数：

- value: 待设置的每字节手续费

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main()
    {
        bool result = Policy.SetFeePerByte(1200);
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

- Boolean类型：true表示设置交易每字节网络费成功。

- 其他：失败。

[返回上级](../Policy.md)
