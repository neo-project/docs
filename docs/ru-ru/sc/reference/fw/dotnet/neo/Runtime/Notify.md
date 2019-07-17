# Runtime.Notify Method (params object[])

Данный метод аналогичен Runtime.Log: он уведомляет клиента, выполняющего смарт-контракт. метод может инициировать событие в клиенте (однако клиент должен быть совместимым).

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Notify(params object[] state)
```

Параметры: 

state: Сообщение-уведомление (может быть любой длины и типа).

## Пример

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        Runtime.Notify("Hello", "World", Blockchain.GetHeight());
    }
}
```



[Back](../Runtime.md)