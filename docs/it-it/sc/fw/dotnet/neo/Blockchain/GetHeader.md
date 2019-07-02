# Metodo (byte[]) Blockchain.GetHeader 

Restituisce l'intestazione di un blocco dato l'hash di un blocco.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(byte[] hash)
```

Parametri: Hash del blocco come array di byte di lunghezza 32.

Valore Restituito: [Header](../Header.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] Header = new byte[] {206, 240, 165, 25, 76, 228, 58, 100, 117, 184, 213, 171, 61, 96, 34, 234, 129, 116, 60, 71, 11, 231, 143, 195, 123, 5, 190, 250, 182, 14, 152};
         Header bl = Blockchain.GetHeader(Header);
     }
}
```



[Indietro](../Blockchain.md)
