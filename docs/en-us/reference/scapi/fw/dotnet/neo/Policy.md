# Policy Class

Provides a series of methods of the native contract Policy, which contract hash is `0x1ca594b36b6b6b3f05efce8b106c824053d18713`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Policy
```

## Methods

| Name                                                         | Description                               |
| ------------------------------------------------------------ | ----------------------------------------- |
| Name()                                                       | The contract name                         |
| [GetMaxTransactionsPerBlock()](Policy/GetMaxTransactionsPerBlock.md) | Gets max transaction number per block     |
| [GetMaxBlockSize()](Policy/GetMaxBlockSize.md)               | Gets max block size                       |
| [GetMaxBlockSystemFee()](Policy/GetMaxBlockSystemFee.md)     | Gets the maximum system fee for the block |
| [GetFeePerByte()](Policy/GetFeePerByte.md)                   | Gets fee per byte                         |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md)            | Verifies whether the account is blocked   |
| [SetMaxBlockSize(uint value)](Policy/SetMaxBlockSize.md)     | Sets the max block size                   |
| [SetMaxTransactionsPerBlock(uint value)](Policy/SetMaxTransactionsPerBlock.md) | Sets the maximum system fee for the block |
| [SetMaxBlockSystemFee(long value)](Policy/SetMaxBlockSystemFee.md) | Sets max transaction per block            |
| [SetFeePerByte(long value)](Policy/SetFeePerByte.md)         | Sets fee per byte                         |
| [BlockAccount(UInt160 account)](Policy/BlockAccount.md)      | Sets the blocked accounts                 |
| [UnblockAccount(UInt160 account)](Policy/UnblockAccount.md)  | Unblocks accounts                         |
