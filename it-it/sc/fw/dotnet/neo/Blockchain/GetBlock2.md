# Metodo (uint) Blockchain.GetBlock 

Restituisce un blocco dalla blockchain data l'altezza di un blocco.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Block GetBlock(uint height)
```

Parametri: Altezza del blocco (indice del blocco) come integer non firmato.

Valore restituito: [Blocco](../Block.md).

## Esempio

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Block bl = Blockchain.GetBlock(997027);
     }
}
```



[Indietro](../Blockchain.md)
