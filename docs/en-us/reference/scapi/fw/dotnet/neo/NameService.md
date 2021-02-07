# NameService Class

Provides a series of attributes and methods of the native contract NameService, which contract hash is  `0xa2b524b68dfe43a9d56af84f443c6b9843b8028c`.

NameService is also an NFT（Non-fungible token）contract that inherits all attributes and methods of NFT contracts.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class NameService 
```

## Attributes

| Name     | Description          |
| -------- | -------------------- |
| Hash     | Contract hash        |
| Symbol   | Gets the symbol, NNS |
| Decimals | Gets the precision   |

## Methods

| Name | Description |
| ---- | ---- |
| [TotalSupply()](NameService/TotalSupply.md) | Gets the total supply of NNS assets. |
| [BalanceOf(UInt160 owner)](NameService/BalanceOf.md) | Gets the number of domains the one owns |
| [OwnerOf(string name)](NameService/OwnerOf.md) | Gets owner of the domain |
| [Properties(string name)](NameService/Properties.md) | Gets properties of the domain |
| [Tokens()](NameService/Tokens.md) | Gets all domains contained in the contract |
| [TokensOf(UInt160 owner)](NameService/TokensOf.md) | Gets owner's domain |
| [Transfer(UInt160 from, UInt160 to, BigInteger amount)](NameService/Transfer.md) | Transfer assets                       |
| [IsAvailable(string name)](NameService/Transfer.md) | Is the domain available |
| [Register(string name, UInt160 owner)](NameService/Register.md) | Registers a domain |
| [Renew(string name)](NameService/Renew.md) | Renews the domain |
| [SetAdmin(string name, UInt160 admin)](NameService/SetAdmin.md) | Sets domain administrator |
| [SetRecord(string name, RecordType type, string data)](NameService/SetRecord.md) | Sets DNS record |
| [GetRecord(string name, RecordType type)](NameService/GetRecord.md) | Gets DNS record |
| [DeleteRecord(string name, RecordType type)](NameService/DeleteRecord.md) | Deletes DNS record |
| [Resolve(string name, RecordType type)](NameService/Resolve.md) | Resolves DNS |
| [GetPrice()](NameService/GetPrice.md) | Gets the domain proce |
