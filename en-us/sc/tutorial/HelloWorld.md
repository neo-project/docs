# Smart contract example - HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

The Storage class is a static class that manipulates the private contract storage zone. The Storage.Put () method allows you to store data in the private storage area in key-value. For details, refer to the [Storage class](../fw/dotnet/AntShares/Storage.md).

Please refer to [Github](https://github.com/AntShares/AntShares.SmartContract.Contracts) for complete code.
