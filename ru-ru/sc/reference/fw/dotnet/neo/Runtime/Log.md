# Runtime.Log Method (string)

Отправляет сообщение журнала клиенту, выполняющему смарт-контракт. Данный метод может инициировать событие в клиенте (однако клиент должен быть совместимым).

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Log(string message)
```

Параметры: 

message: Журнал в виде строки.

## Пример

```c#
public class Contract1 : FunctionCode
{
    public static void Main(bool debug)
    {
        if(debug)
        {
            Runtime.Log("Execution successful");
        }
    }
}
```



[Back](../Runtime.md)