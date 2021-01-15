# Policy Class

Provides a series of methods of the native contract Policy, which contract hash is `0xdde31084c0fdbebc7f5ed5f53a38905305ccee14`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

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
