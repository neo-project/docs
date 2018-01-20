# Classe Account

Sarebe la classe che rappresenta l'account, fornisce un modo per interrogare il saldo. Qui l'account si riferisce all'hash dello script del contratto il quale corrisponde un'indirizzo sulla blockchain.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Account
```

## Attributi

| | Nome  | Descrizione | 
| ---------------------------------------- | ----------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[ScriptHash](Account/ScriptHash.md) | Ottenere lo script hash dell'account del contratto | [ScriptHash](Account/ScriptHash.md) | Restituisce lo script hash dell'account del contratto |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) |[Votes](Account/Votes.md) | Restituisce le informazioni sui voti da questo account ad altri.

## Metodi

| | NOme | Descrizione | 
| ---------------------------------------- | ---------------------------------------- | ------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBalance (byte[])](Account/GetBalance.md) | Restituisce il saldo dell'asset indentificato dall'asset ID fornito.

## Costruttore

L'oggetto Account viene costruito tramite [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
