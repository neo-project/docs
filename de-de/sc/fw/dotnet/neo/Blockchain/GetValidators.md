# Blockchain.GetValidators Methode ()

Gibt die Public Keys auf Basis des Validators (Consensus Nodes) zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern byte[][] GetValidators()
```

Rückgabewert: Ein Public Key Array, jedes Element ist ein Byte Array mit der einer Länge von 33.

## Beispiel

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[][] validators = Blockchain.GetValidators();
     }
}
```



[Back](../Blockchain.md)
