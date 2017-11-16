# Storage Class

Geeft een set van methods om data in de opslag in te voegen, op te vragen en te verwijderen.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Storage
```

## Eigenschappen

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | Geeft als `return` de huidige opslaglocatie |

## Methods

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | Verwijder een waarde uit de opslag a.d.h.v. een gegeven key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | Verwijder een waarde uit de opslag a.d.h.v. een gegeven key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | Geeft als `return` een waarde uit de opslag a.d.h.v. een gegeven key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | Geeft als `return` een waarde uit de opslag a.d.h.v. een gegeven key |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | Voegt een gegeven waarde toe aan de gegeven key in de opslag |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | Voegt een gegeven waarde toe aan de gegeven key in de opslag |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | Voegt een gegeven waarde toe aan de gegeven key in de opslag |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | Voegt een gegeven waarde toe aan de gegeven key in de opslag |

## Constructor

De Storage class is een statische class en heeft geen constructor nodig.
