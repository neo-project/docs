# Класс Header 

Представляет структуру данных заголовка блока.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Header: IScriptContainer
```

## Атрибуты

|                                          | Имя                                     | Описание                              |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | Возвращает данные консенсуса для блока (генерируются узлами консенсуса) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | Возвращает хэш блока                   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Index](Header/Index.md)                 | Возвращает высоту блока                 |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | Возвращает корень дерева Меркла для всех транзакций в блоке  |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | Возвращает хэш следующего буккипера    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | Возвращает хэш предыдущего блока    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | Возвращает временную метку блока       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | Возвращает версию блока         |

## Конструктор

Объект Header строится с помощью  [Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md).

Объект Header строится с помощью  [Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md).
