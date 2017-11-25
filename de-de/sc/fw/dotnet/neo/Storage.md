# Storage Klasse

Stellt mehrere Methoden um Daten in den Persistent Store einzufügen, abzurufen oder zu löschen dar.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Attribute

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | Gibt den aktuellen Storekontext zurück |

## Methode

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | Löscht einen Wert von dem Peristent Store anhand eines vorgegebenen Keys. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | Löscht einen Wert von dem Peristent Store anhand eines vorgegebenen Keys. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | Gibt einen Wert von dem Peristent Store anhand eines vorgegebenen Keys zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | Gibt einen Wert von dem Peristent Store anhand eines vorgegebenen Keys zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | Fügt einen definierten Wert zu dem gegebenen Key in dem Persistent Store hinzu. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | Fügt einen definierten Wert zu dem gegebenen Key in dem Persistent Store hinzu. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | Fügt einen definierten Wert zu dem gegebenen Key in dem Persistent Store hinzu. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | Fügt einen definierten Wert zu dem gegebenen Key in dem Persistent Store hinzu. |

## Ersteller

Die Storageklasse ist eine statische Klasse und benötigt keinen Ersteller.
