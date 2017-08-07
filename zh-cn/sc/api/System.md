# System 命名空间

System 命名空间是智能合约执行引擎（NeoVM）提供的 API，提供了访问该智能合约的执行环境的方法。

| API                                      | 说明                         |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | 获得该智能合约的脚本容器（最开始的触发者）      |
| System.ExecutionEngine.GetExecutingScriptHash | 获得该智能合约执行的脚本散列             |
| System.ExecutionEngine.GetCallingScriptHash | 获得该智能合约的调用者的脚本散列           |
| System.ExecutionEngine.GetEntryScriptHash | 获得该智能合约的入口点（合约调用链的起点）的脚本散列 |

参考：以上 API 的源码位于 Neo.VM 项目中的 src\Neo.VM\InteropService.cs 文件。