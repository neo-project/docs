# Classe dell'Account

La classe che rappresenta l'account, fornendo un modo per interrogare il saldo. Qui l'account si riferisce all'hash dello script del contratto il quale corrisponde all'indirizzo sulla blockchain

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Account
```

## Attributi

| | Nome  | Descrizione | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Get the script hash of the contract account | [ScriptHash](Account/ScriptHash.md) | Returns the script hash of the contract account |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | Returns the information of the votes from this account to others.

## Methods

| | Name | Description | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Returns the balance of asset identified by asset ID provided.

## Constructor

The Account object is constructed through [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
