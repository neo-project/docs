# 合约收费机制

用户在使用 Neo 网络时，需要支付一定的费用，总手续费包含系统费 (System Fee) 和网络费 (Network Fee)，费用单位为 GAS。

其中，智能合约执行，包括自身脚本的执行和调用其他合约的脚本，所需的费用为系统手续费。

承载智能合约部署、调用的交易以及执行验证（Verify）方法所需的费用为网络手续费。

一笔调用智能合约的交易的手续费会同时包括系统手续费（sysfee）和网络手续费（netfee）。每一笔交易的 sysfee 都会被燃烧，而 netfee 会奖励给打包当前区块的共识地址。

在 Neo N3 中手续费是可以动态变化的，下面列举的是基础费用。

## 系统手续费

系统手续费（System Fee）包括以下几项：

- 操作码执行（OpCode）费用
- 系统调用（SysCall）费用
- 原生合约 CPU 使用费用
- 存储区使用费用

### 操作码执行（OpCode）费用

| 执行费用（GAS） | 操作码（OpCode）指令名称                                     |
| --------------- | ------------------------------------------------------------ |
| 0.00032768      | CALLT                                                        |
| 0.00008192      | APPEND,REVERSEITEMS,SETITEM,VALUES                           |
| 0.00004096      | PUSHDATA4                                                    |
| 0.00002048      | CAT,CONVERT,LEFT,MEMCPY,RIGHT,SUBSTR                         |
| 0.00000512      | CALL,CALL_L,CALLA,NEWARRAY,NEWARRAY_T,NEWSTRUCT,PACK,PUSHDATA2,THROW,UNPACK |
| 0.00000256      | NEWBUFFER                                                    |
| 0.00000064      | HASKEY,INITSLOT,PICKITEM                                     |
| 0.00000032      | EQUAL,NOTEQUAL                                               |
| 0.00000016      | CLEAR,CLEARITEMS,INITSSLOT,KEYS,NEWARRAY0,NEWSTRUCT0,POPITEM,REMOVE,REVERSEN,ROLL,XDROP |
| 0.00000008      | ADD,AND,BOOLAND,BOOLOR,DIV,GE,GT,LE,LT,MAX,MIN,MOD,MUL,NEWMAP,NUMEQUAL,NUMNOTEQUAL,OR,PUSHDATA1,SHL,SHR,SUB,WITHIN,XOR |
| 0.00000004      | ABS,DEC,ENDFINALLY,ENDTRY,ENDTRY_L,INC,INVERT,NEGATE,NOT,NZ,PUSHA,PUSHINT128,PUSHINT256,SIGN,SIZE,TRY,TRY_L |
| 0.00000002      | DEPTH,DROP,DUP,ISNULL,ISTYPE,JMP,JMP_L,JMPEQ,JMPEQ_L,JMPGE,JMPGE_L,JMPGT,JMPGT_L,JMPIF,JMPIF_L,JMPIFNOT,JMPIFNOT_L,JMPLE,JMPLE_L,JMPLT,JMPLT_L,JMPNE,JMPNE_L,LDARG,LDARG0,LDARG1,LDARG2,LDARG3,LDARG4,LDARG5,LDARG6,LDLOC,LDLOC0,LDLOC1,LDLOC2,LDLOC3,LDLOC4,LDLOC5,LDLOC6,LDSFLD,LDSFLD0,LDSFLD1,LDSFLD2,LDSFLD3,LDSFLD4,LDSFLD5,LDSFLD6,NIP,OVER,PICK,REVERSE3,REVERSE4,ROT,STARG,STARG0,STARG1,STARG2,STARG3,STARG4,STARG5,STARG6,STLOC,STLOC0,STLOC1,STLOC2,STLOC3,STLOC4,STLOC5,STLOC6,STSFLD,STSFLD0,STSFLD1,STSFLD2,STSFLD3,STSFLD4,STSFLD5,STSFLD6,SWAP,TUCK |
| 0.00000001      | ASSERT,NOP,PUSH0,PUSH1,PUSH10,PUSH11,PUSH12,PUSH13,PUSH14,PUSH15,PUSH16,PUSH2,PUSH3,PUSH4,PUSH5,PUSH6,PUSH7,PUSH8,PUSH9,PUSHINT16,PUSHINT32,PUSHINT64,PUSHINT8,PUSHM1,PUSHNULL |
| 0               | ABORT,RET,SYSCALL                                            |

参考：[ApplicationEngine.OpCodePrices.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.OpCodePrices.cs)

### 系统调用费用

| 系统调用名称                          | 执行费用（GAS）      |
| ------------------------------------- | -------------------- |
| System.Contract.Call                  | 0.00032768           |
| System.Contract.CallNative            | 参考原生合约费用     |
| System.Contract.IsStandard            | 0.00001024           |
| System.Contract.GetCallFlags          | 0.00001024           |
| System.Contract.CreateStandardAccount | 0.00000256           |
| System.Contract.CreateMultisigAccount | 0.00000256           |
| Neo.Crypto.CheckSig                   | 0.00032768           |
| Neo.Crypto.CheckMultisig              | 根据签名数量动态计算 |
| System.Iterator.Create                | 0.00000016           |
| System.Iterator.Next                  | 0.00032768           |
| System.Iterator.Value                 | 0.00000016           |
| System.Runtime.Platform               | 0.00000008           |
| System.Runtime.GetTrigger             | 0.00000008           |
| System.Runtime.GetTime                | 0.00000008           |
| System.Runtime.GetScriptContainer     | 0.00000008           |
| System.Runtime.GetExecutingScriptHash | 0.00000016           |
| System.Runtime.GetCallingScriptHash   | 0.00000016           |
| System.Runtime.GetEntryScriptHash     | 0.00000016           |
| System.Runtime.CheckWitness           | 0.00001024           |
| System.Runtime.GetInvocationCounter   | 0.00000016           |
| System.Runtime.Log                    | 0.00032768           |
| System.Runtime.Notify                 | 0.00032768           |
| System.Runtime.GetNotifications       | 0.00000256           |
| System.Runtime.GasLeft                | 0.00000016           |

参考：

[ApplicationEngine.Contract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[ApplicationEngine.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Crypto.cs)

[ApplicationEngine.Contract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[ApplicationEngine.Iterator.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Iterator.cs)

[ApplicationEngine.Runtime.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Runtime.cs)

[ApplicationEngine.Storage.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

### 原生合约执行费用

| 原生合约名称       | 原生合约方法            | 执行费用（GAS）                 |
| ------------------ | ----------------------- | ------------------------------- |
| ContractManagement | Deploy                  | 参考存储区使用费用，最低 10 GAS |
| ContractManagement | Update                  | 参考存储区使用费用              |
| LedgerContract     | GetTransactionFromBlock | 0.00065536                      |
| NeoToken           | UnclaimedGas            | 0.00131072                      |
| NeoToken           | RegisterCandidate       | 动态计算，默认 1000 GAS         |
| NeoToken           | UnregisterCandidate     | 0.00065536                      |
| NeoToken           | Vote                    | 0.00065536                      |
| NeoToken           | GetCandidates           | 0.04194304                      |
| NeoToken           | GetCommittee            | 0.04194304                      |
| NeoToken           | GetNextBlockValidators  | 0.04194304                      |
| NeoToken、GasToken | Transfer                | 0.00131072                      |
| OracleContract     | Request                 | 动态计算，用户调用时指定手续费  |
| StdLib             | Deserialize             | 0.00008192                      |
| StdLib             | JsonDeserialize         | 0.00008192                      |
| StdLib             | 其他                    | 0.00002048                      |

其他未列出的原生合约方法的手续费均为 0.00032768 GAS。

参考：[neo/SmartContract/Native](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract/Native)

### 存储区费用

按写入字节收费，默认单价为 0.001 GAS / Byte，委员会可动态调整，但最大不会超过 1 GAS / Byte

根据写入的 key 是初次写入还是修改数据，存储区收费规则参见下表。

| 场景                                        | 收费规则                                                     | 示例                                             | 手续费<br/>(默认单价0.001)            |
| ------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------ | ------------------------------------- |
| 首次写入                                    | (key.Length + value.Length) × 单价                           | key = `key`, value= `hello world`, 共 14 字节    | **0.014** GAS                         |
| 非首次写入存储区，且新数据大小 ≤ 旧数据大小 | 不收取 key 的费用，value 部分首字节正常计费，剩余字节 2.5 折 计费 | 修改 value 为 `hello neo3`, 共 10 字节           | (1+(10-1)/4 )×0.001 = **0.003** GAS   |
| 非首次写入存储区，且新数据大小 > 旧数据大小 | 不收取 key 的费用，value 部分旧数据大小按照上一条计费，新增数据的大小按照原价计费 | 修改 value 为`hello neo3.0`, 共 12 字节          | 0.003 + (12-10)×0.001 = **0.005** GAS |
| 非首次写入存储区，且新数据大小 > 旧数据大小 | 与上一条相同                                                 | 修改 value 为`hello neo3.0 preview5`, 共 21 字节 | 0.005 + (21-12)×0.001 = **0.014** GAS |
| 删除 value                                  | 0                                                            | 删除 value                                       | **0** GAS                             |

参考：[ApplicationEngine.Storage.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

## 网络手续费

网络手续费（Network Fee）包括以下几项：

- 网络字节费
- 验证脚本执行所需的费用

### 网络字节费

网络字节费默认 0.00001 GAS / Byte，委员会可动态调整。

参考：

[PolicyContract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs)

[Transaction.cs#L302](https://github.com/neo-project/neo/blob/ee898bf41667cdbe3b836b3bd08c2d3199046c2e/src/neo/Network/P2P/Payloads/Transaction.cs#L302)

### 脚本验证费用

验证脚本执行所需的费用最大不超过 0.5 GAS，计算公式为：

`脚本验证费` = `脚本验证执行费` * `倍率`

其中，`脚本验证执行费` = `操作码执行费` + `系统调用费` + `原生合约 CPU 使用费` + `存储区使用费`

`验证脚本默认执行费率倍率` 默认为 30，委员会可动态调整，但最大不得超过 1000。

开发者可以通过 InvokeContractVerify API 估算验证脚本执行所需费用。

例：

标准地址验证脚本费用为 (OpCode.PUSHDATA1 + OpCode.PUSHDATA1 + OpCode.SYSCALL + Neo.Crypto.CheckSig) ×30 = **0.0098352** GAS。

参考：

[PolicyContract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs)

[Transaction.cs#L302](https://github.com/neo-project/neo/blob/ee898bf41667cdbe3b836b3bd08c2d3199046c2e/src/neo/Network/P2P/Payloads/Transaction.cs#L302)