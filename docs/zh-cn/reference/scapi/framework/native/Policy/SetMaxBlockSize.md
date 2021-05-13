# SetMaxBlockSize 方法

设置最大区块大小。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要验证委员会的多签。签名超过委员会数量的一半的向上取整即为有效，相应操作将被执行。

## 语法

```c#
public static extern bool SetMaxBlockSize(uint value);
```

参数：

- value: 待设置的区块大小值

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        bool result = Policy.SetMaxBlockSize(1024);
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

- Boolean类型：true表示设置区块最大大小成功。

- 其他：失败。

[返回上级](../Policy.md)