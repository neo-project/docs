# Método Blockchain.GetAccount(byte[])

Devuelve una cuenta (dirección) basada en el hash del script del contrato.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Account GetAccount (byte[] script_hash)
```

Parámetros: Hash del script, del tipo array de 20 bytes.

Valor de retorno: [Account](../Account.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account acc = Blockchain.GetAccount (scriptHash);
    }
}
```

El hash del script que se puede obtener previamente, también se puede pasar como parámetro en el contrato inteligente. A continuación se muestra la llamada en el código externo del SDK que retorna un array de bytes correspondiente al hash del script.

```c#
static void Main (string[] args)
{
    byte[] scriptHash = Neo.Wallets.Wallet.ToScriptHash ("AK4if54jXjSiJBs6jkfZjxAastauJtjjse"). ToArray ();
}
```



[Volver arriba](../Blockchain.md)
