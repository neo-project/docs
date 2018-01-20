# Metodo (byte[]) Runtime.CheckWitness 

Verifica che le transazioni/blocco del contratto chiamante abbiano convalidato gli hash degli script richiesti.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi:

```c#
public static extern bool CheckWitness(byte[] hashOrPubkey)
```

Parametri:

hashOrPubkey: scripthash come un array di byte di lunghezza 20 o chiave pubblica come array di byte di lunghezza 33.

Valore restituito: Se la verifica è stata eseguita, boolean.

## Esempio

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        bool result = Runtime.CheckWitness(pubKey);
        //byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        //bool result = Runtime.CheckWitness(scriptHash);
    }
}
```



[Indietro](../Runtime.md)
