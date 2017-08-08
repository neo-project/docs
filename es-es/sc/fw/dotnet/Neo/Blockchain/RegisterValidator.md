# Método Blockchain.RegisterValidator(byte[])

Registro para convertirse en una persona de consenso, sólo la operación de registro, puede ser elegida para votar por otras personas.

El método reemplaza a RegisterTransaction en la versión 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern object RegisterValidator(byte[] pubkey)
```

Parámetros:

Pubkey: clave pública, array de 33 bytes.

Valor de retorno: actualmente sin uso, reservado para extensiones futuras en los contratos inteligentes, de tipo object type.

## Ejemplo

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] pubKey = new byte[] {2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202};
         var result = Blockchain.RegisterValidator(pubKey);
     }
}
```



[volver arriba](../Blockchain.md)
