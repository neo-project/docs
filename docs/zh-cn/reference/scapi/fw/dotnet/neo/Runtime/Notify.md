# Runtime.Notify 方法 (params object[])

与 Runtime.Log 类似，在智能合约中向执行该智能合约的客户端发送通知。该方法会在客户端触发一个事件，事件的处理过程需要客户端配合。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Notify(params object[] state)
```

参数：

- state：通知信息，参数数量任意，参数类型任意。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```



[返回上级](../Runtime.md)