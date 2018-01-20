# Metodo (uint) Blockchain.GetHeader 

Restituisce l'intestazione del blocco data l'altezza di un blocco.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Header GetHeader(uint height)
```

Parametri: Altezza di blocco come integer non firmato.

Valore restituito: [Header](../Header.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main ()
     {
         Header bl = Blockchain.GetHeader(997027);
     }
}
```



[Indietro](../Blockchain.md)
