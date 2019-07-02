# TransactionAttribute.Usage Property

Returns the purpose of the transaction.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte Usage {get;}
```

Attribute value: The purpose of the transaction as a byte array.

Purposes:

```c#
// The hash value of the external contract
ContractHash = 0x00,
// The public key for ECDH key exchange, the first byte of the public key is 0x02
ECDH02 = 0x02,
// The public key for ECDH key exchange, the first byte of the public key is 0x03
ECDH03 = 0x03,
// for additional verification of the transaction
Script = 0x20,
// vote information
Vote = 0x30,
// Transaction description URL
DescriptionUrl = 0x81,
//Description
Description = 0x90,
// can be used to do the data stored in Hash
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
// Transaction Notes
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



[Return to superior](../TransactionAttribute.md)
