# Smart Contract .NET framework

Das .NET Framework ist eine Datenkapselung der Smart Contract API sodass .NET Programmierer mithilfe von Klassen, Methoden und Eigenschaften von .NET direkt mit der API interagieren können, umso Daten, Speicherdaten und mehr zu erhalten.

## Kompatibilitätsschicht Methoden

Der Namespace der Kompatibilitätsschicht ist in `Neo.SmartContract.Framework.Services.NEO` und `Neo.SmartContract.Framework.Services.System` unterteilt. Klicken Sie auf den Link für weitere Details.

| Namespace                 | Beschreibung                             |
| -------------------------- | ---------------------------------------- |
| [Neo](dotnet/neo.md)       | Der NEO Namespace ist die API der NEO Blockchain, mithilfe der API können Sie auf Blockchaindaten zugreifen und diese verändern. |
| [System](dotnet/system.md) | Der SystemNamespace ist die API der Smart Contract Execution Engine (NeoVM), mithilfe der API können Sie auf die Ausführungsumgebung zugreifen. |


## Frameworkmethoden

Ergänzend zu den Aufrufsmethoden der Kompatibilitätsschicht gibt es noch die von dem Framework unterstützten Smart Contract Aufrufsmethoden. Diese Methoden befinden sich im `Neo.SmartContract.Framework´ und können direkt mit einem Smart Contract ausgeführt werden.

### SmartContract Klassenmethoden

Die `SmartContract` Klasse stellt Verschlüsslungsalgorithmen und Signaturmethoden bereit.

|                                                        | Name                                             | Beschreibung                                                 |
| ------------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha1(byte[])                                     | Verschlüsselt den Inhalt mit SHA1                            |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Sha256(byte[])                                   | Verschlüsselt den Inhalt mit SHA256                          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash160(byte[])                                  | Verschlüsselt den Inhalt mit SHA256, und im Nachgang mit RIPEMD160 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Hash256(byte[])                                  | Verschlüsselt den Inhalt doppelt mit SHA256                  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | VerifySignature(byte[] signature, byte[] pubkey) | Verifiziert das die Signatur den gültigen Public Key verwendet |

### Byte Array Helper Methods

Die unten genannten Methoden sind Hilfsmethoden für die Byteanordnung. Die Methoden werden durch die .NET Framework´s Helper Klassen bereitgestellt.

|                                          | Name                         | Beschreibung                             |
| ---------------------------------------- | ---------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(this byte[], byte[])  | Verknüpft 2 Byte Arrays                |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Range(this byte[], int, int) | Gibt einen Teil der Byte Array Parameter zurück: index, count |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Take(this byte[], int)       | Gibt die Bytes ganz links vom Byte Array zurück Parameter: count |
