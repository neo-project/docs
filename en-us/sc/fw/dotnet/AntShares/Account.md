# Account class

The class that represents the account provides a way to query the balance. The account here refers to the hash of a contract script, that is, an address in the corresponding chain.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class account
```

## Attributes

| | Name | description | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
[ScriptHash](Account/ScriptHash.md) | Get the script hash of the contract account | [ScriptHash](Account/ScriptHash.md) | Get the script hash of the contract account |
[Votes](Account/Votes.md) | Get the vote for the contract account to vote for other people (vb) Information

## method

| | Name | description | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
[GetBalance (byte[])](Account/GetBalance.md) | Get the account via the asset ID |[][](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) The balance of such assets

## Construction method

The Account object is constructed by [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
