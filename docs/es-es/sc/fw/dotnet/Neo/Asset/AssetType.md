# Propiedad Asset.AssetType

Retorna la categoría del activo.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern byte AssetType {get;}
```

Valor del atributo: El valor de la enumeración de la clase asset (no el nombre de la enumeración). La clase de la enumeración `Asset` está definida de la siguiente forma:

```c#
public enum AssetType: byte
{
     CreditFlag = 0x40,
     DutyFlag = 0x80,

     SystemShare = 0x00,
     SystemCoin = 0x01,
     Currency = 0x08,
     Share = DutyFlag | 0x10,
     Invoice = DutyFlag | 0x18,
     Token = CreditFlag | 0x20,
}
```



[Volver arriba](../Asset.md)
