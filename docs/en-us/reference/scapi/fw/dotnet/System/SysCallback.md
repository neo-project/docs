# SyscallCallback Enumeration Class

Defines the callback types related to syscall.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum SyscallCallback : uint
{
    System_Binary_Serialize = 0x24011c3f,
    System_Binary_Deserialize = 0xdfd07c52,
    System_Binary_Base64Encode = 0x7653bfac,
    System_Binary_Base64Decode = 0xc384a3db,
    System_Binary_Base58Encode = 0x67b0573f,
    System_Binary_Base58Decode = 0x3792f76d,
    System_Blockchain_GetHeight = 0x1f72f57e,
    System_Blockchain_GetBlock = 0x2d924783,
    System_Blockchain_GetTransaction = 0x488d55e6,
    System_Blockchain_GetTransactionHeight = 0xb188324a,
    System_Blockchain_GetTransactionFromBlock = 0x69fd567e,
    System_Contract_IsStandard = 0x859d6bd7,
    System_Contract_CreateStandardAccount = 0x28799cf,
    Neo_Crypto_RIPEMD160 = 0xd2d6d126,
    Neo_Crypto_SHA256 = 0x1174acd7,
    Neo_Crypto_VerifyWithECDsaSecp256r1 = 0x780d4495,
    Neo_Crypto_VerifyWithECDsaSecp256k1 = 0xb7533c7e,
    Neo_Crypto_CheckMultisigWithECDsaSecp256r1 = 0xafef8d13,
    Neo_Crypto_CheckMultisigWithECDsaSecp256k1 = 0xb2efc657,
    System_Json_Serialize = 0x4b268d24,
    System_Json_Deserialize = 0xe479ca7,
    System_Runtime_Platform = 0xf6fc79b2,
    System_Runtime_GetTrigger = 0xa0387de9,
    System_Runtime_GetTime = 0x388c3b7,
    System_Runtime_GetScriptContainer = 0x3008512d,
    System_Runtime_GetExecutingScriptHash = 0x74a8fedb,
    System_Runtime_GetCallingScriptHash = 0x3c6e5339,
    System_Runtime_GetEntryScriptHash = 0x38e2b4f9,
    System_Runtime_CheckWitness = 0x8cec27f8,
    System_Runtime_GetInvocationCounter = 0x43112784,
    System_Runtime_GetNotifications = 0xf1354327,
    System_Runtime_GasLeft = 0xced88814,
    System_Binary_Itoa = 2109399931,
    System_Binary_Atoi = 3946854428,
}
```