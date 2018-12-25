# Contract.Migrate Method (byte[], byte[], byte, bool, string, string, string, string, string)

Перемещает/ продлевает смарт-контракт. Данный метод аналогичен `Contract.Create`. Единственное его отличие заключается в том, что он добавляет логику для перемещения частной зоны хранения. При выполнении этого метода все **существующие данные** перемещаются в постоянное хранилище нового контракта.

Если контракт не использует постоянное хранилище, то `Contract.Migrate` выполняет те же функции, что и  `Contract.Create`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract Migrate(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Параметры: 

script: Байт-код контракта в виде байтового массива.

parameter_list: Список параметров в виде байтового массива. См. [Smart Contract Parameters and Return Values](../../../../../Parameter.md).

return_type: Тип возвращаемого значения в виде байта. См. [Smart Contract Parameters and Return Values](../../../../../Parameter.md).

need_storage: Если контракту требуется постоянное хранение; булево значение.

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
    public static void Main(byte[] signature)
    {
        if(VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature))
          {
                    //This is the scripthash of the new contract
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = true;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@neo.org";
        string description = "DescriptionHere";
      
        Contract.Migrate(script, parameter_list, return_type, need_storage, name, version, author, email, description);
          }

    }
}
```



[Back](../Contract.md)