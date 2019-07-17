# Método Validator.Register(byte[])

Se registra como nodo consenso/bookpeeper. Esto es solo para el registro, requiere votos para ser seleccionado.

[!NOTE] Este método reemplaza en la versión 2.0 el método RegisterTransaction.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Validator Register(byte[] pubkey)
```

Parámetros

pubkey： clave públca como arra de bye de longitud de 33.

Valor retorno:: [Validator](../Validator.md)

## Ejemplo

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = new byte[] { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        var result = Validator.Register(pubKey);
    }
}
```



[Volver arriba](../Validator.md)