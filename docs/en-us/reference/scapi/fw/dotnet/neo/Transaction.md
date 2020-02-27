# Transaction Class

Used to represent the base class of a transaction.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Transaction
```

## Attributes

| Name            | Description                                                  |
| --------------- | ------------------------------------------------------------ |
| Hash            | Hash of the current transaction                              |
| Version         | Transaction version number. For now it is 0                  |
| Nonce           | Random number                                                |
| Sender          | Address script hash of the sender                            |
| SystemFee       | System fee, which is paid to the network for resource cost   |
| NetworkFee      | Network fee, which is paid to the verifier for packaging the transaction |
| ValidUntilBlock | Validity period of the transaction                           |
| Script          | Contract script hash of the transaction                      |

## Constructor

The Transaction object is constructed through [Blockchain.GetTransaction(byte[])](Blockchain/GetTransaction.md).
