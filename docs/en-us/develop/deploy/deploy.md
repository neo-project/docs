# Deploying Smart Contracts

When a smart contract is deployed on the blockchain, it can be used by other users or invoked by other contracts. This section describes how to deploy and invoke the smart contract in the Neo blockchain using Neo-CLI or Neo-GUI. The instructions in this section are generic and applicable to all contract types including NEP-17 assets. 

## What contracts need to be deployed?

When a smart contract needs to store data or to be invoked by another smart contract  through syscall `System.Contract.Call` on the blockchain, it needs to be deployed. Contracts triggered only by the verification trigger, such as the lock contract and multi-signature contract, do not need to be deployed as they will not be invoked by other contracts. Contracts such as  `return 1+1`  do not need to be deployed as they do not require any input parameters.

From the programming language perspective, only when a smart contract will be used as a class library, it needs to be deployed. For example: 

- When a smart contract has variable incoming parameters, it must serve as a storage. The caller or other smart contracts provide the parameters.
- When a smart contract uses storage it must serve as a class library.
- When a smart contract implements NEP-17 standard assets, the contract needs to be deployed on the blockchain.

### How to deploy?

Smart contracts are deployed by invoking APIs. Usually we use Neo-CLI or Neo-GUI to deploy smart contracts. 

Deploying and invoking smart contracts cost fees. For more information, refer to [Fees](../../reference/fees.md).

## Before you start
Make sure you have done the following:

- Confirmed that your contract should be deployed. 
- Compiled a contract file (\*.nef) and a descriptive file of contract (\*.manifest.json).
- Installed Neo-CLI or Neo-GUI and completed block synchronization. For more information, refer to  [Neo-CLI](../../node/cli/setup.md) and [Neo-GUI](../../node/gui/install.md)

## Deploying contract with Neo-CLI

In Neo-CLI run the following command to deploy your contract:

 `deploy <nefFilePath> [manifestFile]`

-  `<nefFilePath>` : mandatory. The contract file
- `[manifestFile]` : optional. The descriptive file of contract

### Example

```
deploy NEP17.nef
```

or

```
deploy NEP17.nef NEP17.manifest.json
```

After the command is executed, the program deploys the smart contract and pays the fee automatically.

```
neo> deploy NEP17.nef
Contract hash: 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
Gas consumed: 10.0107577
Network fee: 0.0345352
Total fee: 10.0452929 GAS
Relay tx? (no|yes): yes

Signed and relayed transaction with hash=0xe03aade81fb96c44e115a1cc9cfe984a9df4a283bd10aa0aefa7ebf3e296f757
```

### The contract scripthash

When a contract has been deployed a scripthash is generated as a unified identifier of the contract. The contract scripthash can be converted into the standard 20-byte address for receiving assets from transfer transactions. In that case the contract scripthash is used in big endian format. For example:

- Contract ScriptHash (big endian): 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 

- Corresponding address: NPRCE9me1CdXBA6StQ7kff52p61rHQqnS7

### Common errors

`Engine faulted`

- Contract already exists
- .nef  is not matched with .manifest
- either .nef or .manifest is wrong
- Insufficient fee

## Deploying contracts with Neo-GUI

1. In Neo-GUI click `Contract` -> `Deploy Contract`。
2. Select the desired *.nef and *.manifest.json files.
3. Click `Deploy`.

