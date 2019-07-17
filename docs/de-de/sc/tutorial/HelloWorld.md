# Smart Contract Beispiel - HelloWorld

```c#
public class HelloWorld : SmartContract
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Die Storage Klasse ist eine Static Klasse die den Privaten Contract Speicher manipuliert. Die 'Storage.Put()' Methode erlaubt es Ihnen Daten im Privaten Speicher im key-value format zu speichern. Details finden sie unter [Storage](../fw/dotnet/neo/Storage.md).

Komplette Beispiele finden sie hier: [Github](https://github.com/neo-project/examples) for complete examples.
