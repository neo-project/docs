# Clase ExecutionEngine

El motor de ejecución de la máquina virtual, obtener el solicitante del contrato actua y el contenedor de ejecución de contrato actual.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public class ExecutionEngine
```

## Atributos

| | Nombre | Descripción |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | Devuelve el hash del script del solicitante del contrato inteligente |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | Devuelve el punto de entrada para el contrato inteligente (contract call chain). [Entry@html] The starting point of the script hash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | Devuelve el hash del script de la ejecución del contrato inteligente
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | Devuelve el contenedor del script para el contrato inteligente (los primeros desencadenadores)
