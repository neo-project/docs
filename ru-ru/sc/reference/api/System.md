# Пространство имен System 

Пространство имен System это API, предоставленный движком выполнения Smart Contract (NeoVM) для доступа к среде выполнения смарт-контракта.


| API | Описание |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Получает контейнер скрипта для данного смарт-контракта  |
| System.ExecutionEngine.GetExecutingScriptHash | Получает хэш скрипта выполняющего смарт-контракта  |
| System.ExecutionEngine.GetCallingScriptHash | Получает хэш скрипта инициатора вызова для данного смарт-контракта  |
| System.ExecutionEngine.GetEntryScriptHash | Получает хэш скрипта точки входа для данного смарт-контракта (начальная точка цепочки вызовов контракта) |

Примечание: исходный код для API, указанного выше, находится в каталоге `Neo.VM`, в файле `src\Neo.VM\InteropService.cs`.