# Método Account.GetBalance (byte[])

Devuelve el balance del activo de la cuenta a través del id. del activo.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern long GetBalance (byte[] asset_id)
```

Parámetros: Id. del activo, el id. de la transacción de RegistTransaction cuando se registra el activo. Array de 32-bytes.

Valor devuelto: El balance del activo en la cuenta. 

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account account = Blockchain.GetAccount (scriptHash);
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Long balance = account.GetBalance (asset);
    }
}
```



[Volver arriba](../Account.md)
