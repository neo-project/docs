# GetMaxBlockSize 方法

获取区块最大大小。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern uint GetMaxBlockSize()；
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Test()
    {
        uint result = Policy.GetMaxBlockSize();
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

```json
{
	"type":"Integer",
	"value":"500"
}
```

响应说明：

- Integer类型：成功获取区块最大大小。

- 其他：失败。

[返回上级](../Policy.md)