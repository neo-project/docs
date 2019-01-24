# Contract.Create Method (byte[], byte[], byte, bool, string, string, string, string, string)

Вызов данного метода в смарт-контракте инициирует опубликование нового контракта..

Заменяет PublishTransaction в версии 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Параметры:

script: Байт-код контракта в виде байтового массива.

parameter_list: Список параметров в виде байтового массива. См. [Smart Contract Parameters and Return Values](../../../../../Parameter.md).

return_type: Тип возвращаемого значения в виде байта. См. [Smart Contract Parameters and Return Values](../../../../../Parameter.md).

need_storage: Если контракту требуется постоянное хранилище; булево значение.

name: Имя контракта в виде строки.

version: Версия в виде строки.

author: Имя автора в виде строки.

email: Email автора в виде строки.

description: Описание контракта в виде строки.

Возвращаемое значение: [Contract](../Contract.md).

## Пример

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        //This is the new contract as bytecode
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = false;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@abc.com";
        string description = "This is an Addition Contract. It takes in 2 inputs, adds them and returns the result.";
      
        Blockchain.CreateContract(script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[Back](../Contract.md)