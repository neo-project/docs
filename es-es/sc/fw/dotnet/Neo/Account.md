# Clase Account

La clase que representa la cuenta, proporciona una forma de consultar el saldo. La cuenta aquí se refiere al hash del script de contrato, es decir, una dirección en la cadena correspondiente.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class account
```

## Atributos

| Nombre | Descripción | 
| ---------------------------------------- | ----------------------------------- |
[ScriptHash](Account/ScriptHash.md) | Devuelve el hash del script de la cuenta contrato. |
[Votes](Account/Votes.md) | Devuelve la información de votación de la cuenta del contrato a otras personas. |


## Método

| Nombre | Descripción | 
| ---------------------------------------- | ---------------------------------------- |
[GetBalance (byte[])](Account/GetBalance.md) | Devuelve el balance via id. del activo |

## Método del constructor

El objecto account se contruye con [Blockchain.GetAccount (byte[])](Blockchain/GetAccount.md).
