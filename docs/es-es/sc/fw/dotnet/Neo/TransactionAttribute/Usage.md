# Propiedad TransactionAttribute.Usage

Devuelve el proposito de la transacción.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public extern byte Usage {get;}
```

Valor del atributo: el proposito de la transacción, byte array.

Descripción del valor del atributo:

```c#
// Valor hash del contrato externo
ContractHash = 0x00,
// Clave pública para el intercambio de claves ECDH, el primer byte de la clave pública es 0x02
ECDH02 = 0x02,
// Clave pública para el intercambio de claves ECDH, el primer byte de la clave pública es 0x03
ECDH03 = 0x03,
// Verificación adicional de la transacción
Script = 0x20,
// Información sobre votación
Vote = 0x30,
// URL de la descripción de la transacción
DescriptionUrl = 0x81,
// Descripción
Description = 0x90,
// Puede ser usado para crear los datos almacenados en la hash
Hash1 = 0xa1,
Hash2 = 0xa2,
Hash3 = 0xa3,
Hash4 = 0xa4,
Hash5 = 0xa5,
Hash6 = 0xa6,
Hash7 = 0xa7,
Hash8 = 0xa8,
Hash9 = 0xa9,
Hash10 = 0xaa,
Hash11 = 0xab,
Hash12 = 0xac,
Hash13 = 0xad,
Hash14 = 0xae,
Hash15 = 0xaf,
// Notas de la transacción
Remark = 0xf0,
Remark1 = 0xf1,
Remark2 = 0xf2,
Remark3 = 0xf3,
Remark4 = 0xf4,
Remark5 = 0xf5,
Remark6 = 0xf6,
Remark7 = 0xf7,
Remark8 = 0xf8,
Remark9 = 0xf9,
Remark10 = 0xfa,
Remark11 = 0xfb,
Remark12 = 0xfc,
Remark13 = 0xfd,
Remark14 = 0xfe,
Remark15 = 0xff
```



[Volver arriba](../TransactionAttribute.md)
