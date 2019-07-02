# Método Runtime.Log(string)

Envia un mensaje de log al cliente que ejecuta el contrato inteligente. Este método puede desencadenar un evento en el cliente pero requerirá que el cliente sea compatible.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern void Log(string message)
```

Parámetros:

message: Log, como string

## Ejemplo

```c#
public class Contract1 : FunctionCode
{
    public static void Main(bool debug)
    {
        if(debug)
        {
            Runtime.Log("Execution successful");
        }
    }
}
```



[Volver arriba](../Runtime.md)