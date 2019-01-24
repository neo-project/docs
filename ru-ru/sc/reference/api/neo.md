# Пространство имен NEO

Пространcтво имен Neo содержит API, предоставляемый блокчейном NEO. API -методы позволяют опрашивать блокчейн и управлять постоянным хранилищем.

Примечание: тэги `New` и `Deprecated` обозначают различия между версией 1.6 и версией 2.0.

## Read-only API

API запросов к блокчейну:

| API                           | Описание                              |
| ----------------------------- | ---------------------------------------- |
| Neo.Blockchain.GetHeight      | Получает текущую высоту блока             |
| Neo.Blockchain.GetHeader      | Находит заголовок блока по высоте блока или хэшу блока  |
| Neo.Blockchain.GetBlock       | Находит блок по высоте блока или хэшу блока |
| Neo.Blockchain.GetTransaction | Находит транзакцию через ID транзакцииD      |
| Neo.Blockchain.GetAccount     | Получает аккаунт на основе хэша скрипта контракта |
| Neo.Blockchain.GetValidators  | `New` Получает открытый ключ узла консенсуса |
| Neo.Blockchain.GetAsset       | Получает актив на основе ID актива              |
| Neo.Blockchain.GetContract    | `New` Получает содержание контракта на основе хэша контракта   |

API класса Block:

| API                           | Описание                              |
| ----------------------------- | ---------------------------------------- |
| Neo.Header.GetHash            | Получает хэш блока                |
| Neo.Header.GetVersion         | Получает номер версии блока                 |
| Neo.Header.GetPrevHash        | Получает хэш предыдущего блока       |
| Neo.Header.GetIndex           | Получает высоту текущего блока             |
| Neo.Header.GetMerkleRoot      | Получает корень дерева Меркла для всех транзакций в данном блоке|
| Neo.Header.GetTimestamp       | Получает временную метку блока            |
| Neo.Header.GetConsensusData   | Получает данные консенсуса для данного блока (псевдослучайное число, сгенерированное узлом консенсуса)|
| Neo.Header.GetNextConsensus   | Получает хэш-значение для следующего bookkeeper contract |
| Neo.Block.GetTransactionCount | Получает количество транзакций в текущем блоке |
| Neo.Block.GetTransactions     | Получает все транзакции в текущем блоке |
| Neo.Block.GetTransaction      | Получает транзакцию, указанную в текущем блоке |

API класса Transaction:

| API                           | Описание                              |
| ----------------------------- | ---------------------------------------- |
| Neo.Transaction.GetHash       | Получает хэш для текущей транзакции     |
| Neo.Transaction.GetType       | Получает тип текущей транзакции          |
| Neo.Enrollment.GetPublicKey   | `Deprecated` Заменен на Neo.Blockchain.GetValidators |
| Neo.Transaction.GetAttributes | Запрашивает все свойства текущей транзакции |
| Neo.Transaction.GetInputs     | Запрашивает все транзакции для текущих транзакций |
| Neo.Transaction.GetOutputs    | Запрашивает все выводы (outputs) транзакции для текущей транзакции |
| Neo.Transaction.GetReferences | Запрашивает вывод (output) транзакции, на который ссылаются все входы (inputs) текущей транзакции |
| Neo.Attribute.GetUsage        | Получает цель транзакции               |
| Neo.Attribute.GetData         | Получает дополнительные данные, не имеющие отношение к цели транзакции |
| Neo.Input.GetHash             | Получает хэш предыдущей транзакции |
| Neo.Input.GetIndex            | Индекс входа (input) в списке выходов (outputs) предыдущей  транзакции |
| Neo.Output.GetAssetId         | Получает ID актива                             |
| Neo.Output.GetValue           | Получает сумму транзакции               |
| Neo.Output.GetScriptHash      | Получает хэш скрипта                          |

API класса Account:

| API                       | Описание                              |
| ------------------------- | ---------------------------------------- |
| Neo.Account.GetScriptHash | Получает хэш скрипта учетной записи (счета) контракта |
| Neo.Account.GetVotes      | Получает информацию о голосах, отданных этой учетной записью |
| Neo.Account.GetBalance    | Получает баланс данного актива в учетной записи (при имеющемся ID актива) |

API класса Asset:

| API                    | Описание                              |
| ---------------------- | ---------------------------------------- |
| Neo.Asset.GetAssetId   | Получает ID актива                      |
| Neo.Asset.GetAssetType | Получает тип актива            |
| Neo.Asset.GetAmount    | Получает общий баланс актива        |
| Neo.Asset.GetAvailable | Получает количество актива, который был выпущен  |
| Neo.Asset.GetPrecision | Получает число делений для данного актива, число символов после десятичной точки (запятой)  |
| Neo.Asset.GetOwner     | Получает владельца актива (открытый ключ) |
| Neo.Asset.GetAdmin     | Получает администратора (адрес контракта) актива |
| Neo.Asset.GetIssuer    | Получает эмитента (адрес контракта) актива |

API класса Contract:

| API                    | Описание                        |
| ---------------------- | ---------------------------------- |
| Neo.Contract.GetScript | Получает хэш скрипта контракта |

API класса Storage:

| API                    | Описание                              |
| ---------------------- | ---------------------------------------- |
| Neo.Storage.GetContext | `New` Получает текущий контекст хранения      |
| Neo.Storage.Get        | Возвращает значение из хранилища на основе представленного ключа |

API класса Runtime:

| API                      | Описание                              |
| ------------------------ | ---------------------------------------- |
| Neo.Runtime.CheckWitness | `New` Верифицирует, что вызывающий контракт верифицировал необходимые хэши скрипта транзакции/блока |
| Neo.Runtime.Notify       | `New` Во время выполнения смарт-контракта посылает уведомление  |
| Neo.Runtime.Log          | `New` Во время выполнения смарт-контракта уведомляет клиента с помощью сообщения лога |

Примечание: исходный код находится в каталоге `NEO`, в файле [`SmartContract/StateReader.cs`](https://github.com/neo-project/neo/blob/master/neo/SmartContract/StateReader.cs).

## Read/Write API

Данный тип API изменяет статус смарт-контракта.

| API                            | Описание                              |
| ------------------------------ | --------------------------------------- |
| Neo.Account.SetVotes           | Устанавливает данные о голсовании для аккаунта |
| Neo.Validator.Register         | `New` Регистрирует в качестве буккипера           |
| Neo.Asset.Create               | `New` Регистрирует новый актив               |
| Neo.Asset.Renew                | `New` Обновляет актив                     |
| Neo.Contract.Create            | `New` Публикует смарт-контракт           |
| Neo.Contract.Migrate           | `New` Мигрирует смарт-контракт     |
| Neo.Contract.Destroy           | `New` Удаляет смарт-контракт           |
| Neo.Contract.GetStorageContext | `New` Получает контекст хранения контракта |
| Neo.Storage.Put                | Добавляет значение в постоянное хранилище на основе данного ключа |
| Neo.Storage.Delete             | Удаляет значение из постоянного хранилища на основе данного ключа |

Примечание: исходный код для API, указанного выше, находится в каталоге  `NEO`, в файле [`SmartContract/StateMachine.cs`](https://github.com/neo-project/neo/blob/master/neo/SmartContract/StateMachine.cs).
