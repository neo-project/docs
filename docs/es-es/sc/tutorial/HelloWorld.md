# Ejemplo de contrato inteligente - HelloWorld

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

La clase Storage es una clase estática que manipula el almacenamiento privado del contratos. El método `Storage.Put()` permite almacenar datos en el área de almacenamiento privada en formato clave-valor. Para más detalles, consultar [Storage class](../fw/dotnet/Neo/Storage.md).



