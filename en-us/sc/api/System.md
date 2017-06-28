# System namespace

The System namespace is the API provided by the Smart Contract Execution Engine (AVM), which provides a way to access the execution environment of the smart contract.

| API | Description |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Get the script container for this smart contract (the first trigger) |
| System.ExecutionEngine.GetExecutingScriptHash | Get the script hash of the smart contract execution |
| System.ExecutionEngine.GetCallingScriptHash | Get the script hash of the caller for this smart contract |
| System.ExecutionEngine.GetEntryScriptHash | Get the script hash of the entry point for the smart contract (the starting point of the contract call chain) |
