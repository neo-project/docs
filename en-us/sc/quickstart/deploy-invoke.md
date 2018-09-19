# Deploying and Invoking Smart Contracts

This section describes how to deploy and invoke the smart contract in the NEO blockchain using NEO-GUI. The instructions in this section are generic and applicable to all contract types including NEP-5 tokens. 
## Before you start
Make sure you have done the following:

- Confirmed that your contract should be deployed. For more information, refer to [Which smart contracts need to be deployed](overview.md##deploying-smart-contracts).
- Compiled an .avm contract file.
- Installed NEO-GUI and completed block synchronization. For more information, refer to [NEO-GUI](../../node/gui/install.md).

## Deploying the smart contract

1. From NEO-GUI, click `Advanced` -> `Deploy Contract`。

2. In the Deploy Contract dialog，Click `Load` and select the smart contract file you have compiled.

   The code field is populated with the script hash of the contract. Copy it for use in a later step.

3. Specify the information and metadata fields.

   For metadata related parameters, you can refer to [Parameters and Return Values](../Parameter.md).

   If need be, check the `Need Storage` option. The NEP5 standard uses storage to maintain accounts so make sure this is checked when deploying an NEP5 token.

4. Click `Deploy`.

   Deploying a smart contract costs 100 ~1000 GAS. For more information, refer to [System Fees](../systemfees.md).

## Creating a smart contract account   

You need to create a smart contract account using the contract script hash if the contract will receive assets.

1. After a wallet is created in NEO-GUI, right-click on the address area and select `Create Contract Address` -> `Custom`.
2. Specify the following options：
   a. `Parameter List`：refer to [Parameters and Return Values](../Parameter.md)
   b. `Script`：enter the contract script hash copied beforehand. 
   c. `Private Key`：optional. Specify the private key used for signing if the signature is required during contract execution.
3. Click `Confirm`.

## Invoking the smart contract

### Invoking another contract from one contract

To invoke another contract from the contract, you need to first add a statement in C# using Appcall and the script hash of the contract to invoke, and then you can invoke it in the code. 

```c#
[Appcall("XXXXXXXXXX")]//ScriptHash
public static extern int AnotherContract(string arg);

public static void Main()
{
    AnotherContract("Hello");    
}
```

### Invoking a deployed contract

To invoke a smart contract that has been deployed in the blockchain, do the following:

1. In NEO-GUI，right-click on the contract address and select `View Contract`. 

2. Copy the value in the Script Hash field.

3. Click on the `Advanced` menu option and select `Invoke Contract`.

4. Enter the `Script Hash` field with the value copied in Step 2. 

   The Smart Contract information should be automatically filled in the remaining `Invoke Function` fields.

5. Click `Test ` to run the contract in a test environment. If no issue, click `Invoke`。

You can also use the [invoke method](../../node/cli/latest-version/api/invoke.html) provided in NEO-CLI to invoke the contract.