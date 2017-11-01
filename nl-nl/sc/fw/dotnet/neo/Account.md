# Account Class

De class die staat voor een account, waarmee het saldo opgevraagd kan worden. 'Account' verwijst hier naar de hash van een contract script dat hoort bij een adres op de blockchain.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Account
```

## Eigenschappen

| | Naam | Omschrijving | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Geeft de script hash van de contract account | 
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | Geeft als `return` de informatie van de uitgebrachte stemmen van deze account naar anderen.

## Methods

| | Naam | Omschrijving | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Geeft als `return` het saldo van een asset a.d.h.v. een gegeven asset-ID.

## Constructor

Het Account object wordt gemaakt door [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
