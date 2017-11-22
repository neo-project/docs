# Smart Contract .NET framework

The .NET Framework is an encapsulation of the Smart Contract API so that .NET programmers can use the classes, methods, and properties of .NET directly to interact with the API to obtain blockchain data, storage data and so on.
Das .NET Framework ist eine Datenkapselung der Smart Contract API sodass .NET Progammierer mithilfe von Klassen, Methoden und Eigenschaften von .NET direkt mit der API interagieren können um so Daten, Speicherdaten und mehr zu erhalten.

## Interoperability Layer Methods
## Kompatibilitätsschicht Methoden

The namespace for interoperability layer is divided into `Neo.SmartContract.Framework.Services.NEO` and `Neo.SmartContract.Framework.Services.System`. Click on the links for more details. 
Der Namensraum der Kompatibilitätsschicht ist in `Neo.SmartContract.Framework.Services.NEO` und `Neo.SmartContract.Framework.Services.System` unterteilt. Klicken Sie auf den Link für weitere Details.

| Namensraum                 | Beschreibung                             |
| -------------------------- | ---------------------------------------- |
| [Neo](dotnet/neo.md)       | Der NEO Namensraum ist die API der NEO Blockchain, mithilfe der API kann man kann man auf Blockchaindaten zugreifen und diese verändern. |
| [System](dotnet/system.md) | Der System Namensraum ist die API der Smart Contract Execution Engine (NeoVM), mithilfe der API kann man auf die Ausführungsumgebung zugreifen. |


## Framework Methods
## Framework Mehoden

In addition to calling methods from the Interoperability layer, smart contracts can also call methods provided by the framework. These methods are found within `Neo.SmartContract.Framework` and can be called directly by smart contracts.
Ergänzend zu den Aufrufsmethoden der Kompatibilitässchicht gibt es noch Smart Contract Aufrufsmethoden die von dem Framework unterstützt werden. Diese Methoden befinden sich im `Neo.SmartContract.Framework´ und können direkt mit einem Smart Contract ausgeführt werden.

### SmartContract Class Methods
### SmartContract Klassenmethoden

The `SmartContract` class provides us with the hash algorithms and signature methods.
Die `SmartContract` Klasse stellt Verschlüsslungs Algorithmen und Signaturemethoden bereit.

|                                          | Name                                     | Beschreibung                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                             | Verschlüsselt den Inhalt mit SHA1 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                           | Verschlüsselt den Inhalt mit SHA256 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                          | Verschlüsselt den Inhalt mit SHA256, und im Nachgang mit RIPEMD160 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                          | Verschlüsselt den Inhalt doppelt mit SHA256 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] pubkey, byte[] signature) | Verifizert das die Signatur den gültigen Public Key verwendet|

### Byte Array Helper Methods
### Byte Array Helper Methods

The methods below are helper methods for byte arrays provided by the .NET framework's Helper class.
Die unten genannten Methoden sind Hilfsmethoden für die Byteanordnung. Die Methoden werden durch das .NET Framework´s Helper Klassen bereitgestellt.

|                                          | Name                         | Beschreibung                             |
| ---------------------------------------- | ---------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | Verknüpft 2 byte arrays                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | Gibt einen Teil der byte array parameter zurück: index, count |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | Gibt die Bytes ganz links vom Byte Array zurück parameter: count |
