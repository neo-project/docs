# ExecutionEngine class

De uitvoerende engine van de virtual machine. Geeft toegang tot de aanvrager (caller) van het smart contract en de uitvoercontainer (execution container) van het contract.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class ExecutionEngine
```

## Eigenschappen

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CallingScriptHash](ExecutionEngine/CallingScriptHash.md) | Geeft als `return` de scripthash van de caller van het contract|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [EntryScriptHash](ExecutionEngine/EntryScriptHash.md) | Geeft als `return` de scripthash van de entry points van het contract (in de gegenereerde stamboom van contracten) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ExecutingScriptHash](ExecutionEngine/ExecutingScriptHash.md) | Geeft als `return` de scripthash van het contract dat wordt uitgevoerd |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ScriptContainer](ExecutionEngine/ScriptContainer.md) | Geeft als `return` de scriptcontainer van het huidige contract (de oorspronkelijke trigger-veroorzaker) |
