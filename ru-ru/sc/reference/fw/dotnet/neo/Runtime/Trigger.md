# Runtime.Trigger Attribute

Получает тип триггера для смарт-контракта (верификационный или прикладной контракт). 

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.TriggerType Trigger { get; }
```

Атрибут：[TriggerType](../TriggerType.md).

## Пример

```c#
public static bool Main()
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        // do something;
    }
    else if (Runtime.Trigger == TriggerType.Application)
    {
        // do something;
    }
}
```

Более подробно см. в [ICO_Template](https://github.com/neo-project/examples-csharp/blob/master/ICO_Template/ICO_Template.cs).



[Back](../Runtime.md)