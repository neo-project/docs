# Policy Class

Provides a series of methods of the native contract Policy, which contract hash is `0xcc5e4edd9f5f8dba8bb65734541df7a1c081c67b`.

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Policy
```

## Attribute

| Name | Description       |
| ---- | ----------------- |
| Hash | The contract hash |

## Methods

| Name                                                         | Description                               |
| ------------------------------------------------------------ | ----------------------------------------- |
| [GetMaxTransactionsPerBlock()](Policy/GetMaxTransactionsPerBlock.md) | Gets max transaction number per block     |
| [GetMaxBlockSize()](Policy/GetMaxBlockSize.md)               | Gets max block size                       |
| [GetMaxBlockSystemFee()](Policy/GetMaxBlockSystemFee.md)     | Gets the maximum system fee for the block |
| [GetFeePerByte()](Policy/GetFeePerByte.md)                   | Gets fee per byte                         |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md)            | Verifies whether the account is blocked   |
| [BlockAccount(UInt160 account)](Policy/BlockAccount.md)      | Sets the blocked accounts                 |
| [UnblockAccount(UInt160 account)](Policy/UnblockAccount.md)  | Unblocks accounts                         |
