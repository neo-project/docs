# Перечисление TriggerType 

Перечисление, используемое для представления типа триггера смарт-контракта. Вы можете узнать тип триггера текущего смарт-контракта (**Verification** или **Application**) с помощью [Runtime.Trigger](Runtime/Trigger.md).

Дополнительную информацию по триггерам см. в  [Smart Contract Triggers](../../../../trigger.md)

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public enum TriggerType : byte
{
    Verification = 0x00,
    Application = 0x10
}
```

