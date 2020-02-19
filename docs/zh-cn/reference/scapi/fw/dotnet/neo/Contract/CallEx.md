# Contract.CallEx 方法 (byte[], string, object[], CallFlags)

调用合约。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern object CallEx(byte[] scriptHash, string method, object[] arguments, CallFlags flag)
```

参数：

- scriptHash：合约脚本哈希；
- method：合约方法名；
- arguments：合约方法参数;
- flag: 合约调用模式。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main(string method, object[] args)
    {
        string scriptHash = "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789";
        if (Runtime.Trigger == TriggerType.Application)
        {
            if (method == "name") {
            string name = Contract.CallEx(scriptHash.HexToBytes(), "name", new object[]{}, CallFlags.ReadOnly);
            return name;
            }
        }  
    }
}
```



[返回上级](../Contract.md)