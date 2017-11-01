# Smart Contract .NET Framework

Het .NET Framework is een inkapseling van de Smart Contract API, zodat .NET-programmeurs de classes, methods en properties van .NET direct kunnen laten werken met de API om blockchaindata, opslagdata et cetera te verkrijgen.

## Interoperability Layer Methods

De namespace voor de interoperability layer is onderverdeeld in `Neo.SmartContract.Framework.Services.NEO` en `Neo.SmartContract.Framework.Services.System`. Klik op de links voor meer details. 

| Namespace                          | Omschrijving     	                                                      |
| :--------------------------------- | :-------------------------------------------------------- |
| [Neo](dotnet/neo.md)               | De NEO Namespace is de API die wordt verschaft door de NEO blockchain, waardoor toegang tot blockchaindata en het manipuleren van de opslag mogelijk zijn |
| [System](dotnet/system.md)         | De System namespace is de API die wordt verschaft door de Smart Contract Execution Engine (NeoVM), waardoor toegang tot de uitvoeringsomgeving van smart contracts mogelijk is. |

## Framework Methods

Naast het aanroepen van methods vanuit de Interoperability layer, kunnen smart contracts ook methods aanroepen van het framework. Deze methods zijn te vinden in `Neo.SmartContract.Framework` en kunnen direct aangeroepen worden door smart contracts.

### SmartContract Class Methods

In de [NEO Smart Contract Handleiding](../tutorial.md) is te zien dat contracten hun basis danken aan `FunctionCode` of `VerificationCode`. Deze twee classes zijn gebaseerd op de `SmartContract` class; deze geeft ons hash-algoritmes en signature methods.

|                                                        | Naam                                             | Omschrijving                                             |
|: ------------------------------------------------------ |: ------------------------------------------------ |: ------------------------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                  | Hasht de input bytes met SHA1                       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])       	      | Hasht de input bytes met SHA256                     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[]) 	      | Hasht de input bytes met SHA256, gevolgd door RIPEMD160|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])          | Hasht de input bytes tweemaal met SHA256               |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] pubkey, byte[] signature) | Verifiëert de signature a.d.h.v. de gegeven public key           |


### Byte Array Helper Methods

De onderstaande methods zijn helper methods voor byte-arrays en worden mogelijk gemaakt door de .NET Framework Helper class.

|                                                        | Naam                         | Omschrijving                                                      |
| ------------------------------------------------------ | ---------------------------- | ---------------------------------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | Schakelt 2 byte arrays aaneen                                        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | Geeft als return een deel van de byte-array, met als parameters: index, count        |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | Geeft als return X-aantal linker bytes van de byte-array, met als parameter: count |
