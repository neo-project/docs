# Transaction Fees
Some transactions on the NEO network require fees. The network uses a fee structure with two types of fees; system fees and network fees. All fees are paid in the native utility token GAS (NeoGas).

| Type        | Description                                                         |
|-------------|---------------------------------------------------------------------|
| Network Fee | Fee to pay the validator for including the transaction in the block |
| System Fee  | Fixed fee to pay the network for operations                         |

## Network fee
Network fees are currently optional for transactions below 1024 bytes in size. Adding a network fee (minimum of 0.001 GAS) will grant the transaction higher priority. The NEO network currently allows only 20 low priority transactions per block, so paying a higher network fee during high traffic times can result in a faster transaction.

Transactions larger than 1024 bytes require 0.001 GAS as a base fee, in addition to 0.00001 GAS per byte of the transaction. Most basic NEP-5 transfers remain well under the 1024 byte threshold, however transactions with more complex logic or large quantities of [inputs](2-Structure_of_NEO_transactions.md#inputs) and [outputs](2-Structure_of_NEO_transactions.md#outputs) may exceed the threshold and require a network fee.

Priority for transactions in the mempool is determined by the fee paid per byte. The network fee can be collected and distributed by the validator to any contract address.

## System fee
The system fee is a fixed fee calculated by [transaction type](3-NEO_transaction_types.md) and instructions to be executed by the NEO virtual machine. Generally speaking, transaction costs scale with the network resources required. There is a system fee discount of `10` GAS for each transaction, so most user interaction with the network and smart contracts will be free. Unlike network fees, system fees are distributed to NEO holders.

### System calls

| System calls                | Fee (GAS)                                                                       |
|-----------------------------|---------------------------------------------------------------------------------|
| *Default*                   | `0.001` for all system calls                                                    |
| `Runtime.CheckWitness`      | `0.2`                                                                           |
| `Blockchain.GetHeader`      | `0.1`                                                                           |
| `Blockchain.GetBlock`       | `0.2`                                                                           |
| `Blockchain.GetTransaction` | `0.1`                                                                           |
| `Blockchain.GetAccount`     | `0.1`                                                                           |
| `Blockchain.GetValidators`  | `0.2`                                                                           |
| `Blockchain.GetAsset`       | `0.1`                                                                           |
| `Blockchain.GetContract`    | `0.1`                                                                           |
| `Transaction.GetReferences` | `0.2`                                                                           |
| `Account.SetVotes`          | `1`                                                                             |
| `Validator.Register`        | `1000`                                                                          |
| `Contract.Create`           | `100` per contract, `400` for enabled storage, `500` for enabled dynamic invoke |
| `Contract.Migrate`          | `100` per contract, `400` for enabled storage, `500` for enabled dynamic invoke |
| `Storage.Get`               | `0.1`                                                                           |
| `Storage.Put`               | `1` per kiB                                                                     |
| `Storage.Delete`            | `0.1`                                                                           |

### Instructions

| Instruction               | Fee (GAS)                                           |
|---------------------------|-----------------------------------------------------|
| *Default*                 | `0.001` for all instructions in the virtual machine |
| `OpCode.PUSH16` (or less) | `0`                                                 |
| `OpCode.NOP`              | `0`                                                 |
| `OpCode.APPCALL`          | `0.01`                                              |
| `OpCode.TAILCALL`         | `0.01`                                              |
| `OpCode.SHA1`             | `0.01`                                              |
| `OpCode.SHA256`           | `0.01`                                              |
| `OpCode.HASH160`          | `0.02`                                              |
| `OpCode.HASH256`          | `0.02`                                              |
| `OpCode.CHECKSIG`         | `0.1`                                               |
| `OpCode.CHECKMULTISIG`    | `0.1` per signature                                 |

## Utility fee in applications
Any deployed application in the network is able to require an application fee in order to use the smart contract. This fee is often charged using a NEP-5 compatible utility token, but smart contracts are able to charge GAS as well.

## What's next?

[Introduction to blocks & blockchain](../4-blocks/1-Introduction_to_blocks_and_blockchain.md)

