# Account Class

The class that represents the account, providing a way to query the balance. The account here refers to the hash of a contract script which corresponds to an address on the blockchain

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Account
```

## Attributes

| | Name | Description | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Get the script hash of the contract account | [ScriptHash](Account/ScriptHash.md) | Returns the script hash of the contract account |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | Returns the information of the votes from this account to others.

## Methods

| | Name | Description | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Returns the balance of asset identified by asset ID provided.

## Constructor

The Account object is constructed through [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
