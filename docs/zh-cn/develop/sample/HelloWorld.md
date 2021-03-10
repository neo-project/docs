# 智能合约示例——HelloWorld

```c#
public class HelloWorld : SmartContract
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Storage 类是操纵 NEO 智能合约私有化存储区的静态类，通过 Storage.Put() 方法可以向私有化存储区中以 key-value 方式存储数据，详情可参考 [Storage 类](../../reference/scapi/fw/dotnet/neo/Storage.md)。
*原来的继承VerificationCode和FunctionCode现都改为继承SmartContract。

完整代码请参考 [Github](https://github.com/neo-project/examples)。 
