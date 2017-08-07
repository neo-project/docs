# Ejemplo de contrato inteligente - HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

Storage es una clase estática que manipula la parte privada del almacenamiento de contratos. El método Storage.Put() permite guardar datos en formato clave-valor en el área de almacenamiento privado. Para más detalles, ver [Storage class](../fw/dotnet/neo/Storage.md).

Por favor, ir a [Github](https://github.com/neo-project/examples) para ver el código completo.
