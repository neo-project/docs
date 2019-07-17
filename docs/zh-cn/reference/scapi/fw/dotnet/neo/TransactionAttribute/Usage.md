# TransactionAttribute.Usage 属性

获得该交易特性中的用途。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern byte Usage { get; }
```

属性值：交易特性中的用途，字节数组。

属性值说明：

```c#
//外部合同的散列值
ContractHash = 0x00,
//用于ECDH密钥交换的公钥，该公钥的第一个字节为0x02
ECDH02 = 0x02,
//用于ECDH密钥交换的公钥，该公钥的第一个字节为0x03
ECDH03 = 0x03,
//用于对交易进行额外的验证
Script = 0x20,
//投票信息
Vote = 0x30,
//交易描述URL
DescriptionUrl = 0x81,
//描述信息
Description = 0x90,
//可用来做存证的数据Hash
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
//交易备注
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



[返回上级](../TransactionAttribute.md)