# 智能合约示例——HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Storage 类是操纵 NEO 智能合约私有化存储区的静态类，通过 Storage.Put() 方法可以向私有化存储区中以 key-value 方式存储数据，详情可参考 [Storage 类](../fw/dotnet/neo/Storage.md)。

完整代码请参考 [Github](https://github.com/neo-project/examples)。 
