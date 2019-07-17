# Método Runtime

Proporcionar funciones a la hora de ejecutar contratos inteligentes.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static class Runtime
```

## Atributos

|                                          | Nombre                            | Descripción                        |
| ---------------------------------------- | ----------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Trigger](Runtime/Trigger.md) | Obtiene el tipo de activación del contrato inteligente  |

## Método

|                                          | Nombre                                        | Descripción                            |
| ---------------------------------------- | ---------------------------------------- | ----------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CheckWitness(byte[])](Runtime/CheckWitness.md) | Verifica que la transacción / bloque que invocó el contrato inteligente tiene un scriphash valido. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Log(string)](Runtime/Log.md)            | Crea un registro/log en el contrato inteligente ejecutado.       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Notify(params object[])](Runtime/Notify.md) | Envia una notificación en el contrato inteligente ejecutado.      |


# Método de contrucción

La clase Runtime es estática y no necesita un contructor.
