# Deploying Smart Contracts

When a smart contract is deployed on the blockchain, it can be used by other users or invoked by other contracts. This section describes how to deploy and invoke the smart contract in the NEO blockchain using NEO-GUI. The instructions in this section are generic and applicable to all contract types including NEP-5 tokens. 

## What contracts need to be deployed?

When a smart contract will be invoked by another smart contract (called appcall), it needs to be deployed. Contracts triggered only by the verification trigger, such as the lock contract and multi-signature contract, do not need to be deployed as they will not be invoked by other contracts. Contracts such as "Return 1+1" do not need to be deployed as they do not require any input parameters.

From the programming language perspective, only when a smart contract will be used as a class library, it needs to be deployed. For example: 

- When a smart contract has variable incoming parameters, it must serve as a storage. The caller (Invocation transaction) or other smart contracts provide the parameters.
- When a smart contract uses storage and dynamic calls it must serve as a class library.
- When a smart contract implements NEP-5 standard assets, the contract needs to be deployed on the blockchain.

### How to deploy?

Smart contracts are deployed by invoking API through an Invocation transaction (The Publish transaction for deployment of the old version system has been deprecated). We recommend you use NEO-GUI to deploy smart contracts. 

Deploying and invoking smart contracts will cost fees. For more information, refer to [Fees](../fees.md).

## Before you start
Make sure you have done the following:

- Confirmed that your contract should be deployed. 
- Compiled an .avm contract file.
- Installed NEO-GUI and completed block synchronization. For more information, refer to [NEO-GUI](../../node/gui/install.md).

## Deploying the smart contract

1. From NEO-GUI, click `Advanced` -> `Deploy Contract`。

2. In the Deploy Contract dialog，Click `Load` and select the smart contract file you have compiled.

   The code field is populated with the script hash of the contract. Copy it for use in a later step.

3. Specify the information and metadata fields.

   For metadata related parameters, you can refer to [Parameters and Return Values](Parameter.md).

   If need be, check the `Need Storage` option. The NEP5 standard uses storage to maintain accounts so make sure this is checked when deploying an NEP5 token.

4. Click `Deploy`.

   Deploying a smart contract costs 100 ~1000 GAS. For more information, refer to [Fees](../fees.md).

## Creating a smart contract account   

You need to create a smart contract account using the contract script hash if the contract will receive assets.

1. After a wallet is created in NEO-GUI, right-click on the address area and select `Create Contract Address` -> `Custom`.
2. Specify the following options：
   a. `Parameter List`：refer to [Parameters and Return Values](Parameter.md)
   b. `Script`：enter the contract script hash copied beforehand. 
   c. `Private Key`：optional. Specify the private key used for signing if the signature is required during contract execution.
3. Click `Confirm`.

