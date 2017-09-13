# Enumeración TriggerType

Se utiliza para indicar una enumeración de condiciones de activación (Triggers) de contrato inteligentes[Runtime.Trigger](Runtime/Trigger.md) puede obtener si el contrato inteligente actual se activa 
mediante **(Verification）** o un contrato de aplicación **（Application）**

| Trigger      | Verification | Application          |
| ---------------- | ----------------- | -------------------------------- |
| Clase base heredada  | VerificationCode  | FunctionCode                 |
| Modo de activación   | La transferencia desde una dirección del contrato activará automáticamente el contrato  | 1. （Invocation Transaction） Al activar un contrato. 2. La transferencia desde una dirección del contrato activará automáticamente el contrato. |
| Se puede contabilizar en la cadena de bloques mediante otras convocatorias | No    | Sí     | 

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Ejemplo

```c#
public enum TriggerType : byte
{
    Verification = 0x00,
    Application = 0x10
}
```
