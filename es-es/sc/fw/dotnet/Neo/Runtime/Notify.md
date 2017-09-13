# Método Runtime.Notify (params object[])

Al igual que Runtime.Log, notifica al cliente en la ejecución del contrato inteligente. Este método puede desencadenar un evento en el cliente pero requerirá que el cliente sea compatible.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern void Notify(params object[] state)
```

Parámetros:

state: El mensaje de notificación, puede ser de cualquier longitud o tipo.

## Ejemplo

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```



[Volver arriba](../Runtime.md)