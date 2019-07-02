# Smart Contract Voorbeeld - HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

De Storage class is een statische class die de persoonlijke contractopslag aanpast. De `Storage.Put()` methode maakt het mogelijk om aanvullende data in persoonlijke opslag op te slaan in key-value format. Voor meer details over opslag, lees [Opslag](../fw/dotnet/neo/Storage.md).

Kijk voor complete voorbeelden op [GitHub(https://github.com/neo-project/examples).
