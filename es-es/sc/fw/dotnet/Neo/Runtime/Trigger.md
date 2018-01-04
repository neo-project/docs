# Método Runtime.Trigger

Obtiene el tipo de activación del contrato inteligente (contrato o contrato de aplicación)

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.TriggerType Trigger { get; }
```

Valor de los atributos：[TriggerType](../TriggerType.md)。

## Ejemplo

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

Ejemplo detallado: [ICO_Template](https://github.com/neo-project/examples-csharp/blob/master/ICO_Template/ICO_Template.cs)。



[Volver arriba](../Runtime.md)