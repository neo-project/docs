# Blockchain.GetAccount Methode (byte[])

Gibt einen Account (Adresse) auf Basis des Hash des Contract Scripthash zurück.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Account GetAccount(byte[] script_hash)
```

Parameter: Ein Scripthash als Byte Array mit einer Länge von 20.

Rückgabewert: [Account](../Account.md).

## Beispiel

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account acc = Blockchain.GetAccount(scriptHash);
    }
}
```
Der Scipthash kann im voraus erstellt werden und an Smart Contracts als Parameter übergeben werden. Der folgende Code benutzt die SDK um, eine Adresse in Scripthash zu konvertieren.

```c#
Static void Main(string[] args)
{
    byte[] scriptHash = Neo.Wallets.Wallet.ToScriptHash("AK4if54jXjSiJBs6jkfZjxAastauJtjjse").ToArray();
}
```



[Back](../Blockchain.md)
