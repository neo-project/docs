# Пример смарт-контракта - HelloWorld

```c#
public class HelloWorld : SmartContract
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Класс хранения является статическим классом, управляющим частным хранилищем контракта. Метод Storage.Put() позволяет хранить данные в частной зоне хранения в формате «ключ-значение» (более подробно см. в [Storage](../reference/fw/dotnet/neo/Storage.md) ).

Законченные примеры см. на [Github](https://github.com/neo-project/examples).
