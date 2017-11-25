# System Namespace

Der System Namespace ist die API die von der Smart Contract Execution Engine (NeoVM) zur Verfügung gestellt wird, um Zugang zu der Ausführungsumgebung (Execution Environment) des Smart Contract zu erhalten.

| API | Beschreibung |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Sie erhalten den Script Container für diesen Smart Contract (der erste Auslöser) |
| System.ExecutionEngine.GetExecutingScriptHash | Sie erhalten das Scripthash des ausführenden Smart Contract |
| System.ExecutionEngine.GetCallingScriptHash | Sie erhalten das Scripthash für denjenigen der den Smart Contract anruft |
| System.ExecutionEngine.GetEntryScriptHash | Sie erhalten das Scripthash für den Einstiegspunkt des Smart Contract (den Anfangspunkt der Contract Call Chain) |

Anmerkung: Der Sourcecode für diese API finden Sie unter 'Neo.VM' in der 'src\Neo.VM\InteropService.cs' Datei.
