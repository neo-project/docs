# 系统费用

系统费用是根据NeoVM要执行的指令计算得出的费用。NEO3取消了每笔交易10 GAS的免费额度，系统费用总额受合约脚本的指令数量和指令类型影响。计算公式如下所示：

![system fee](../assets/system_fee.png)

其中，*OpcodeSet* 为指令集，𝑂𝑝𝑐𝑜𝑑𝑒𝑃𝑟𝑖𝑐𝑒<sub>𝑖</sub>为第 *i* 种指令的费用，𝑛<sub>𝑖</sub>为第 *i* 种指令在合约脚本中的执行次数。

每条互操作服务和指令的费用请参见下表。

### 互操作服务费用

| 互操作服务 | 费用 (GAS) |
|--|--|
| System.ExecutionEngine.GetScriptContainer | 0.0000025  |
| System.ExecutionEngine.GetExecutingScriptHash| 0.000004  |
| System.ExecutionEngine.GetCallingScriptHash | 0.000004  |
| System.ExecutionEngine.GetEntryScriptHash | 0.000004  |
| System.Runtime.Platform | 0.0000025  |
| System.Runtime.GetTrigger | 0.0000025  |
| System.Runtime.CheckWitness | 0.0003  |
| System.Runtime.Notify | 0.0000025  |
| System.Runtime.Log | 0.003  |
| System.Runtime.GetTime | 0.0000025  |
| System.Runtime.Serialize | 0.001  |
| System.Runtime.Deserialize | 0.005  |
| System.Runtime.GetInvocationCounter | 0.000004  |
| System.Crypto.Verify | 0.01  |
| System.Blockchain.GetHeight | 0.000004  |
| System.Blockchain.GetHeader | 0.00007  |
| System.Blockchain.GetBlock | 0.025  |
| System.Blockchain.GetTransaction | 0.01  |
| System.Blockchain.GetTransactionHeight | 0.01  |
| System.Blockchain.GetContract | 0.01  |
| System.Header.GetIndex | 0.000004  |
| System.Header.GetHash | 0.000004  |
| System.Header.GetPrevHash | 0.000004  |
| System.Header.GetTimestamp | 0.000004  |
| System.Block.GetTransactionCount | 0.000004  |
| System.Block.GetTransactions | 0.0001  |
| System.Block.GetTransaction | 0.000004  |
| System.Transaction.GetHash | 0.000004  |
| System.Contract.Call | 0.01  |
| System.Contract.Destroy | 0.01  |
| System.Storage.GetContext | 0.000004  |
| System.Storage.GetReadOnlyContext | 0.000004  |
| System.Storage.Get | 0.01  |
| System.Storage.Put | (Key.Size + Value.Size) * GasPerByte |
| System.Storage.PutEx | (Key.Size + Value.Size) * GasPerByte |
| System.Storage.Delete | 0.01  |
| System.StorageContext.AsReadOnly | 0.000004  |
| Neo.Native.Deploy | 0 |
| Neo.Crypto.CheckSig| 0.01  |
| Neo.Crypto.CheckMultiSig| 0.01 * n |
| Neo.Header.GetVersion| 0.000004  |
| Neo.Header.GetMerkleRoot| 0.000004  |
| Neo.Header.GetNextConsensus| 0.000004  |
| Neo.Transaction.GetScript| 0.000004  |
| Neo.Transaction.GetWitnesses| 0.0001  |
| Neo.Witness.GetVerificationScript| 0.000004  |
| Neo.Account.IsStandard| 0.0003  |
| Neo.Contract.Create| (Script.Size + Manifest.Size) * GasPerByte |
| Neo.Contract.Update| (Script.Size + Manifest.Size) * GasPerByte |
| Neo.Contract.GetScript| 0.000004  |
| Neo.Contract.IsPayable| 0.000004  |
| Neo.Storage.Find| 0.01  |
| Neo.Enumerator.Create| 0.000004  |
| Neo.Enumerator.Next| 0.01  |
| Neo.Enumerator.Value| 0.000004  |
| Neo.Enumerator.Concat| 0.000004  |
| Neo.Iterator.Create| 0.000004  |
| Neo.Iterator.Key| 0.000004  |
| Neo.Iterator.Keys| 0.000004  |
| Neo.Iterator.Values| 0.000004  |
| Neo.Iterator.Concat| 0.000004  |
| Neo.Json.Serialize| 0.001  |
| Neo.Json.Deserialize| 0.005  |

关于表格中API的含义，请参见 [NEO命名空间](../reference/scapi/api/neo.md)。

### 指令费用

| 指令         | 费用 (GAS) |
|---------------------|-------------|
| PUSH0               | 0.00000030 |
| PUSHBYTES1~PUSHBYTES75     | 0.00000120 |
| PUSHDATA1                  | 0.00000180 |
| PUSHDATA2                  | 0.00013000 |
| PUSHDATA4                  | 0.00110000 |
| PUSHM1                     | 0.00000030 |
| PUSH1~PUSH16               | 0.00000030 |
| NOP                        | 0.00000030 |
| JMP                        | 0.00000070 |
| JMPIF                      | 0.00000070 |
| JMPIFNOT                   | 0.00000070 |
| CALL                   | 0.00022000 |
| RET                  | 0.00000040 |
| SYSCALL                   | 根据系统调用的具体互操作服务计费 |
| DUPFROMALTSTACKBOTTOM   | 0.00000060 |
| DUPFROMALTSTACK                   | 0.00000060 |
| TOALTSTACK                   | 0.00000060 |
| FROMALTSTACK                   | 0.00000060  |
| XDROP                   | 0.00000400 |
| XSWAP                   | 0.00000060 |
| XTUCK                  | 0.00000400 |
| DEPTH                   | 0.00000060 |
| DROP                   | 0.00000060 |
| DUP                   | 0.00000060 |
| NIP                   | 0.00000060 |
| OVER                   | 0.00000060 |
| PICK                   | 0.00000060 |
| ROLL                   | 0.00000400 |
| ROT                  | 0.00000060 |
| SWAP                   | 0.00000060 |
| TUCK                   | 0.00000060 |
| CAT                   | 0.00080000 |
| SUBSTR                   | 0.00080000 |
| LEFT                   | 0.00080000 |
| RIGHT                   | 0.00080000 |
| SIZE                   | 0.00000060 |
| INVERT                   | 0.00000100 |
| AND                   | 0.00000200 |
| OR                   | 0.00000200 |
| XOR                   | 0.00000200 |
| EQUAL               | 0.00000200 |
| INC                   | 0.00000100 |
| DEC                   | 0.00000100 |
| SIGN                   | 0.00000100 |
| NEGATE                   | 0.00000100 |
| ABS                   | 0.00000100 |
| NOT                   | 0.00000100 |
| NZ                   | 0.00000100 |
| ADD                   | 0.00000200 |
| SUB                   | 0.00000200 |
| MUL                  | 0.00000300 |
| DIV                   | 0.00000300 |
| MOD                   | 0.00000300 |
| SHL                   | 0.00000300 |
| SHR                   | 0.00000300 |
| BOOLAND                   | 0.00000200 |
| BOOLOR                   | 0.00000200 |
| NUMEQUAL                   | 0.00000200 |
| NUMNOTEQUAL                   | 0.00000200 |
| LT                   | 0.00000200 |
| GT                   | 0.00000200 |
| LTE                   | 0.00000200 |
| GTE                   | 0.00000200 |
| MIN                   | 0.00000200 |
| MAX                   | 0.00000200 |
| WITHIN                   | 0.00000200 |
| ARRAYSIZE                   | 0.00000150 |
| PACK                   | 0.00007000 |
| UNPACK                   | 0.00007000 |
| PICKITEM                   | 0.00270000 |
| SETITEM                   | 0.00270000 |
| NEWARRAY                   | 0.00015000 |
| NEWSTRUCT                   | 0.00015000 |
| NEWMAP                   | 0.00000200 |
| APPEND                   | 0.00015000 |
| REVERSE                   | 0.00000500 |
| REMOVE                   | 0.00000500 |
| HASKEY                   | 0.00270000 |
| KEYS                   | 0.00000500 |
| VALUES                   | 0.00007000 |
| THROW                   | 0.00000030 |
| THROWIFNOT              | 0.00000030 |
