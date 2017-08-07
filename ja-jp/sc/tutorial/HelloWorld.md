# スマートコントラクトの例 - HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Storageクラスは、プライベートコントラクトストレージゾーンを操作する静的クラスです。 Storage.Put（）メソッドを使用すると、プライベートストレージ領域にkey-valueでデータを格納できます。 詳細については、[Storageクラス](../fw/dotnet/neo/Storage.md)を参照してください。

完全なコードについては[Github](https://github.com/neo-project/examples)を参照してください。
