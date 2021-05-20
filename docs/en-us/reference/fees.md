# Fees

Participants in Neo ecosystem need to pay network fees and system fees with GAS when using the Neo network.

System fees are the cost of resources consumed by the transaction execution in NeoVM. The execution of smart contracts, including the execution of its own scripts and the invocation of other contracts, requires system fees.

Network fee is the fee to pack transactions into a block. Transactions that deploy and invoke smart contracts on the blockchain and execute the Verify method requires network fees. 

Therefore, a smart contract invocation transaction requires both system fee and network fee.

Fees in Neo3 can be dynamically changed. In this document we only introduce the basic fees. 

## System fees

System fees include:

- Instruction fee (OpCode)
- SysCall fee
- CPU processing fee for native contracts
- Storage fee


### Instruction fee

| Fee（GAS） | OpCode                                                       |
| ---------- | ------------------------------------------------------------ |
| 0.00032768 | CALLT                                                        |
| 0.00008192 | APPEND, REVERSEITEMS, SETITEM, VALUES                        |
| 0.00004096 | PUSHDATA4                                                    |
| 0.00002048 | CAT, CONVERT, LEFT, MEMCPY, RIGHT, SUBSTR                    |
| 0.00000512 | CALL, CALL_L, CALLA, NEWARRAY, NEWARRAY_T, NEWSTRUCT, PACK, PUSHDATA2, THROW, UNPACK |
| 0.00000256 | NEWBUFFER                                                    |
| 0.00000064 | HASKEY,INITSLOT,PICKITEM                                     |
| 0.00000032 | EQUAL,NOTEQUAL                                               |
| 0.00000016 | CLEAR, CLEARITEMS, INITSSLOT, KEYS, NEWARRAY0, NEWSTRUCT0, POPITEM, REMOVE, REVERSEN, ROLL, XDROP |
| 0.00000008 | ADD, AND, BOOLAND, BOOLOR, DIV, GE, GT, LE, LT, MAX, MIN, MOD, MUL, NEWMAP, NUMEQUAL, NUMNOTEQUAL, OR, PUSHDATA1, SHL, SHR, SUB, WITHIN, XOR |
| 0.00000004 | ABS, DEC, ENDFINALLY, ENDTRY, ENDTRY_L, INC, INVERT, NEGATE, NOT, NZ, PUSHA, PUSHINT128, PUSHINT256, SIGN, SIZE, TRY, TRY_L |
| 0.00000002 | DEPTH, DROP, DUP, ISNULL, ISTYPE, JMP, JMP_L, JMPEQ, JMPEQ_L, JMPGE, JMPGE_L, JMPGT, JMPGT_L, JMPIF, JMPIF_L, JMPIFNOT, JMPIFNOT_L, JMPLE, JMPLE_L, JMPLT, JMPLT_L, JMPNE, JMPNE_L, LDARG, LDARG0, LDARG1, LDARG2, LDARG3, LDARG4, LDARG5, LDARG6, LDLOC, LDLOC0, LDLOC1, LDLOC2, LDLOC3, LDLOC4, LDLOC5, LDLOC6, LDSFLD, LDSFLD0, LDSFLD1, LDSFLD2, LDSFLD3, LDSFLD4, LDSFLD5, LDSFLD6, NIP, OVER, PICK, REVERSE3, REVERSE4, ROT, STARG,STARG0,STARG1,STARG2,STARG3,STARG4,STARG5,STARG6,STLOC,STLOC0,STLOC1,STLOC2,STLOC3,STLOC4,STLOC5,STLOC6,STSFLD,STSFLD0,STSFLD1,STSFLD2,STSFLD3,STSFLD4,STSFLD5,STSFLD6,SWAP,TUCK |
| 0.00000001 | ASSERT, NOP, PUSH0, PUSH1, PUSH10, PUSH11, PUSH12, PUSH13, PUSH14, PUSH15, PUSH16,PUSH2,PUSH3,PUSH4,PUSH5,PUSH6,PUSH7,PUSH8,PUSH9,PUSHINT16,PUSHINT32,PUSHINT64,PUSHINT8,PUSHM1,PUSHNULL |
| 0          | ABORT, RET, SYSCALL                                          |

Reference: [ApplicationEngine.OpCodePrices.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.OpCodePrices.cs)

### System call fee

| **Interop Service**                   | Fee（GAS）                                               |
| ------------------------------------- | -------------------------------------------------------- |
| System.Contract.Call                  | 0.00032768                                               |
| System.Contract.CallNative            | Refer to native contract fee                             |
| System.Contract.IsStandard            | 0.00001024                                               |
| System.Contract.GetCallFlags          | 0.00001024                                               |
| System.Contract.CreateStandardAccount | 0.00000256                                               |
| System.Contract.CreateMultisigAccount | 0.00000256                                               |
| Neo.Crypto.CheckSig                   | 0.00032768                                               |
| Neo.Crypto.CheckMultisig              | Dynamically calculated based on the number of signatures |
| System.Iterator.Create                | 0.00000016                                               |
| System.Iterator.Next                  | 0.00032768                                               |
| System.Iterator.Value                 | 0.00000016                                               |
| System.Runtime.Platform               | 0.00000008                                               |
| System.Runtime.GetTrigger             | 0.00000008                                               |
| System.Runtime.GetTime                | 0.00000008                                               |
| System.Runtime.GetScriptContainer     | 0.00000008                                               |
| System.Runtime.GetExecutingScriptHash | 0.00000016                                               |
| System.Runtime.GetCallingScriptHash   | 0.00000016                                               |
| System.Runtime.GetEntryScriptHash     | 0.00000016                                               |
| System.Runtime.CheckWitness           | 0.00001024                                               |
| System.Runtime.GetInvocationCounter   | 0.00000016                                               |
| System.Runtime.Log                    | 0.00032768                                               |
| System.Runtime.Notify                 | 0.00032768                                               |
| System.Runtime.GetNotifications       | 0.00000256                                               |
| System.Runtime.GasLeft                | 0.00000016                                               |

Reference:

[ApplicationEngine.Contract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[ApplicationEngine.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Crypto.cs)

[ApplicationEngine.Contract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[ApplicationEngine.Iterator.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Iterator.cs)

[ApplicationEngine.Runtime.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Runtime.cs)

[ApplicationEngine.Storage.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

### Native contract execution fee

| Native Contract    | Method                  | Fee（GAS）                                                   |
| ------------------ | ----------------------- | ------------------------------------------------------------ |
| ContractManagement | Deploy                  | Refer to storage fee. Minimum is  10 GAS.                    |
| ContractManagement | Update                  | Refer to storage fee                                         |
| LedgerContract     | GetTransactionFromBlock | 0.00065536                                                   |
| NeoToken           | UnclaimedGas            | 0.00131072                                                   |
| NeoToken           | RegisterCandidate       | Calculated dynamically. Default is 1000 GAS                  |
| NeoToken           | UnregisterCandidate     | 0.00065536                                                   |
| NeoToken           | Vote                    | 0.00065536                                                   |
| NeoToken           | GetCandidates           | 0.04194304                                                   |
| NeoToken           | GetCommittee            | 0.04194304                                                   |
| NeoToken           | GetNextBlockValidators  | 0.04194304                                                   |
| NeoToken、GasToken | Transfer                | 0.00131072                                                   |
| OracleContract     | Request                 | Calculated dynamically. The user specifies the fee when invoking. |
| StdLib             | Deserialize             | 0.00008192                                                   |
| StdLib             | JsonDeserialize         | 0.00008192                                                   |
| StdLib             | Other                   | 0.00002048                                                   |

The fee for other native contract methods not listed is 0.00032768 GAS.

Reference: [neo/SmartContract/Native](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract/Native)

### Storage fee

The storage fee is charged according to the written byte. The default unit price is 0.001 GAS / Byte. Committee members can dynamically adjust the fee, and the upper limit is 1 GAS / Byte.

For the key data written to the storage, the fee charged for the first time write-in and the subsequent write-in are different. See the following table for details.

| Scenarios                                          | Charging Rule                                                | Example                                                      | Fee<br/>(Based on unit price 0.001)   |
| -------------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------- |
| First-time write in                                | (key.Length + value.Length) × unit price                     | key = `key`, value= `hello world`, totally 14 bytes          | **0.014** GAS                         |
| Subsequent write in. New data size ≤ Old data size | No fee for key. The first byte of the value is normally charged, and the remaining bytes are charged at a 75% discount | The value modified as `hello neo3`, totally 10 bytes         | (1+(10-1)/4 )×0.001 = **0.003** GAS   |
| Subsequent write in. New data size > Old data size | The previous fee plus the new data byte fee (i.e. new data byte × unit price) | The value modified as `hello neo3.0`, totally 12 bytes       | 0.003 + (12-10)×0.001 = **0.005** GAS |
| Subsequent write in. New data size > Old data size | The same as above line                                       | The value modified as `hello neo3.0 preview5`, totally 21 bytes | 0.005 + (21-12)×0.001 = **0.014** GAS |
| The value removed                                  | 0                                                            | The value removed                                            | **0** GAS                             |

Reference: [ApplicationEngine.Storage.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

## Network fee

The network fee includes:

- Network byte fee
- Script verification fee

### Network byte fee

By default the network byte fee is 0.00001 GAS / Byte. Committee members can dynamically adjust the fee.

Reference: 

[PolicyContract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs)

[Transaction.cs#L302](https://github.com/neo-project/neo/blob/ee898bf41667cdbe3b836b3bd08c2d3199046c2e/src/neo/Network/P2P/Payloads/Transaction.cs#L302)

### Script verification fee

The script verification fee is limit to 0.5 GAS. Its formula is:

`Script verification fee`= `Execution fee of script verification` * `multiple`

Where,

`Execution fee of script verification` = `OpCode execution fee` + `SysCall fee` + `CPU processing fee for native contracts` + `Storage fee`

The multiple for script verification fee defaults to 30, which can be dynamically adjusted by committee with the upper limit of 1000.

Developers can use the API `InvokeContractVerify` to evaluate the fee for script verification.

For example:

The script verification fee for a standard address is (OpCode.PUSHDATA1 + OpCode.PUSHDATA1 + OpCode.SYSCALL + Neo.Crypto.CheckSig) ×30 = **0.0098352** GAS.

Reference: 

[PolicyContract.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs)

[Transaction.cs#L302](https://github.com/neo-project/neo/blob/ee898bf41667cdbe3b836b3bd08c2d3199046c2e/src/neo/Network/P2P/Payloads/Transaction.cs#L302)

