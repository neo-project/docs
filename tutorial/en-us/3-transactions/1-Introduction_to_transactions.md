# Introduction to transactions
A NEO transaction is a signed data package with an instruction for the network, for example a user indicating that he wants to transfer assets to another address. Each NEO block in the blockchain ledger contains one or more transactions, making each block a transaction batch. To use the NEO blockchain we need to understand how transactions work.

**[Structure of transactions](2-Structure_of_NEO_transactions.md)**

- [type](2-Structure_of_NEO_transactions.md#type)
- [version](2-Structure_of_NEO_transactions.md#version)
- [attributes](2-Structure_of_NEO_transactions.md#attributes)
- [outputs](2-Structure_of_NEO_transactions.md#outputs)
- [inputs](2-Structure_of_NEO_transactions.md#inputs)
- [scripts](2-Structure_of_NEO_transactions.md#scripts)

## Transaction types
There are several different types of transactions on NEO, each with a different purpose and different properties. Some previously used transaction types are now deprecated or removed from the network, so these should not be used when creating new transactions on the MainNet.

**[Transaction types](3-NEO_transaction_types.md)**

- [MinerTransaction](3-NEO_transaction_types.md#minertransaction)
- [ClaimTransaction](3-NEO_transaction_types.md#claimtransaction)
- [ContractTransaction](3-NEO_transaction_types.md#contracttransaction)
- [StateTransaction](3-NEO_transaction_types.md#statetransaction)
- [InvocationTransaction](3-NEO_transaction_types.md#invocationtransaction)
- [Registering assets](3-NEO_transaction_types.md#registering-assets)

## Transaction fees
Some transactions on the NEO network require fees. The network uses a fee structure with two types of fees; system fees and network fees. All fees are paid in the native utility token GAS (NeoGas).

**[Transaction fees](4-NEO_transaction_fees.md)**

- [System fees](4-NEO_transaction_fees.md#system-fees)
- [Network fees](4-NEO_transaction_fees.md#network-fees)
- [Utility fee in applications](4-NEO_transaction_fees.md#utility-fee-in-applications)

## Broadcasting
Once a transaction has been created it can be sent to a network peer node. If the peer node determines the transaction as being valid, it will be placed in the memory pool and distributed through the rest of the network. Eventually a consensus node (validators on the NEO blockchain) will receive the transaction and process it by including it in a block.

## What's next?

[Structure of transactions on the NEO blockchain](2-Structure_of_NEO_transactions.md)

