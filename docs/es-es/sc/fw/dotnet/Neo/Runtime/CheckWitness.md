# Método Runtime.CheckWitness(byte[])

Verifica que la transacciones / bloque del contrato llamado ha validado el scripthash necesario.


Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern bool CheckWitness(byte[] hashOrPubkey)
```

Parámetros:

hashOrPubkey: scripthash como un array de byte de longitud 20 o una clave pública como array de byte de longitud 33.

Return value: Si la verificación se ha relizado, booleano.

## Ejemplo

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



[Volver arriba](../Runtime.md)