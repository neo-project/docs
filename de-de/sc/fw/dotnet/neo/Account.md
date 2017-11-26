# Account Klasse

Diese Klasse repräsentiert den Account um die Bilanz abzurufen. Der Account bezieht sich auf den Hash des Contract Scripts welcher der Adresse auf der Blockchain entspricht. 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Account
```

## Attribute

| | Name | Beschreibung | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Ruft den Scripthash des Contract Accounts ab | [ScriptHash](Account/ScriptHash.md) | Gibt den Scripthash des Contract Accounts zurück |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | Gibt die Information aus welche Stimmen dieser Account anderen gegeben hat.

## Methoden

| | Name | Beschreibung | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Gibt die Bilanz des Assets anhand der Asset ID zurück.

## Ersteller

Das Accountobjekt ist erstellt durch [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
