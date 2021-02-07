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

| 名称     | 说明              |
| -------- | ----------------- |
| Hash     | Gets the contract hash          |
| Symbol   | Gets the symbol, NNS |
| Decimals | Gets decimals        |

## Methods

| Name | Description |
| ---- | ---- |
| [TotalSupply()](NameService/TotalSupply.md) | Gets the total supply of the domain token                                |
| [BalanceOf(UInt160 owner)](NameService/BalanceOf.md) | Gets the balance of the domain token with the specified owner address     |
| [OwnerOf(string name)](NameService/OwnerOf.md) | Gets the owner of the domain token|
| [Properties(string name)](NameService/Properties.md) | Gets the properties of the domain token |
| [Tokens()](NameService/Tokens.md) | Gets all registered domains in the name service contract |
| [TokensOf(UInt160 owner)](NameService/TokensOf.md) | Gets all the domains owned by the specified address |
| [Transfer(UInt160, string)](NameService/Transfer.md) | Transfers the ownership of the domain                                  |
| [IsAvailable(string name)](NameService/IsAvailable.md) | Checks if the domain is available |
| [Register(string name, UInt160 owner)](NameService/Register.md) | Registers a domain |
| [Renew(string name)](NameService/Renew.md) | Renews a domain |
| [SetAdmin(string name, UInt160 admin)](NameService/SetAdmin.md) | Sets the admin of the domain |
| [SetRecord(string name, RecordType type, string data)](NameService/SetRecord.md) | Sets the type data of the domain |
| [GetRecord(string name, RecordType type)](NameService/GetRecord.md) | Gets the type data of the domain |
| [DeleteRecord(string name, RecordType type)](NameService/DeleteRecord.md) | Deletes the type data of the domain |
| [Resolve(string name, RecordType type)](NameService/Resolve.md) | Resolves a domain |
| [GetPrice()](NameService/GetPrice.md) | Gets the price of registering or renewsing a domain |
