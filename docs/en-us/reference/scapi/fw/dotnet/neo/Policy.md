# Policy Class

Provides a series of methods of the native contract Policy, which contract hash is `0x79bcd398505eb779df6e67e4be6c14cded08e2f2`.

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
| [GetMaxTransactionsPerBlock()](Policy/GetMaxTransactionsPerBlock.md) | Gets max transaction number per block     |
| [GetMaxBlockSize()](Policy/GetMaxBlockSize.md)               | Gets max block size                       |
| [GetMaxBlockSystemFee()](Policy/GetMaxBlockSystemFee.md)     | Gets the maximum system fee for the block |
| [GetFeePerByte()](Policy/GetFeePerByte.md)                   | Gets fee per byte                         |
| [IsBlocked(UInt160 account)](Policy/IsBlocked.md)            | Verifies whether the account is blocked   |
| [BlockAccount(UInt160 account)](Policy/BlockAccount.md)      | Sets the blocked accounts                 |
| [UnblockAccount(UInt160 account)](Policy/UnblockAccount.md)  | Unblocks accounts                         |
