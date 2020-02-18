# Contract.Call 方法 (byte[], string, object[])

调用合约。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern object Call(byte[] scriptHash, string method, object[] arguments)
```

参数：

scriptHash：合约脚本哈希；
method：合约方法名；
arguments：合约方法参数。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main(string method, object[] args)
    {
        string scriptHash = "0x43cf98eddbe047e198a3e5d57006311442a0ca15";
        if (Runtime.Trigger == TriggerType.Application)
        {
            if (method == "name") {
            string name = Contract.Call(scriptHash.HexToBytes(), "name", new object[]{});
            return name;
            }
        }  
    }
}
```



[返回上级](../Contract.md)