# Runtime.Log 方法 (string)

在智能合约中向执行该智能合约的客户端发送日志。该方法会触在客户端触发一个事件，事件的处理过程需要客户端配合。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Log(string message)
```

参数：

- message：日志信息，字符串格式。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main(bool debug)
    {
        if(debug)
        {
            Runtime.Log("程序执行成功");
        }
    }
}
```



[返回上级](../Runtime.md)