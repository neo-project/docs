# Método Contract.Destroy

Destrucción de un contrato inteligente. El contrato inteligenet es emito a la blockchain y no puede ser destruido por nadie de fuera, si el contrato es destruido este necesita escribir la logica de la destrucción a la hora de escribir el contrato.


Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern void Destroy()
```

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         var height = Blockchain.GetHeight();
         var block = Blockchain.GetBlock(height);
         if (block.Timestamp > 1514736000) // Beijing time 2018-1-1
         {
             Neo.SmartContract.Framework.Services.Neo.Contract.Destroy();
         }
     }
}
```



[Volver arriba](../Account.md)
