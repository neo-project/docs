# Classe Storage 

Fornisce un set di metodi per inserire, interrogare, ed eliminare dati nella memoria persistente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static class Storage
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | Restituisce il contesto corrente della memoria |

## Metodi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | Elimina un valore dalla memoria permanente in base alla chiave specificata|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | Elimina un valore dall'archivio permanente basato sulla chiave data |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | Restituisce un valore dall'archivio permanente in base alla chiave specificata |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | Restituisce un valore dall'archivio permanente in base alla chiave specificata |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | Inserisce un dato valore nella chiave specificata nell'archivio permanente |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | Inserisce un dato valore nella chiave specificata nell'archivio permanente |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | Inserisce un determinato valore nella chiave specificata nell'archivio permanente |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | Inserisce un dato valore nella chiave specificata nell'archivio permanente |

## Costruttore

La classe Store è una classe statica e non richiede un costruttore.
