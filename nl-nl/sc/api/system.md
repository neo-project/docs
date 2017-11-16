# System Namespace

De System Namespace is onderdeel van de API die wordt verschaft door de Smart Contract Execution Engine (NeoVM). Het geeft toegang tot de uitvoeringsomgeving van smart contracts.

| API                                           | Description                                                              |
| --------------------------------------------- | ------------------------------------------------------------------------ |
| System.ExecutionEngine.GetScriptContainer     | Krijg de scriptcontainer voor dit smart contract (de eerste trigger) |
| System.ExecutionEngine.GetExecutingScriptHash | Krijg de scripthash van het smart contract dat wordt uitgevoerd |
| System.ExecutionEngine.GetCallingScriptHash   | Krijg de scripthash van de aanvrager van het smart contract |
| System.ExecutionEngine.GetEntryScriptHash     | Krijg de scripthash van het 'entry point' van het smart contract (het beginpunt van de contract call chain) |

> [!Note]
> De broncode voor bovenstaande API kan worden gevonden onder `Neo.VM` in `src/Neo.VM/InteropService.cs`.
