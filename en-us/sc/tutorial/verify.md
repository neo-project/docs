# Contract Authentication Tutorial

This tutorial is based on Visual Studio 2017，please ensure that your Visual Studio is upgraded to the 2017 version. Additionally, this tutorial is based on the demo of Smart Contract 2.0, please download and run the **test network** from [GitHub](https://github.com/neo-project/neo-gui/releases).

At the time of writing this document, the latest **test network** client download address: [neo-gui-2.0.1](https://github.com/neo-project/neo-gui/releases/download/v2.0.1/neo-gui-windows.zip).

## Compile contract script

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
namespace Neo.SmartContract
{
    public class Test : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            return true;
        }
    }
}
```

> [!Note]
> If you do not know how to write and generate smart contract scripts, see [How to use C# to prepare Smart Contract](../getting-started.md)
>

The above contract will be compiled into Test.avm, its contract script (Test.avm binary data) is: 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

You will learn how to abtain the contract script for an `.avm` file later in this tutorial.

## Create a wallet

Create a new wallet according to the tutorial shown below:

![Create a wallet](/assets/verify_1.png)

## Obtaining the contract script

There are many ways to obtain the contract script, one way is to read it directly from the `.avm` file using the C# code below.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

If you do no want to get the contract script through coding, then the client's `Deploy Contract` provides a simple way to obtain the contract code:

Click on `Advanced`, `Deploy Contract`, click on the `Load` button on the bottom right corner. Choose the `Test.avm` file generated earlier. You should see the contract script displayed in the `Code` box, as seen in figure. Copy this down again.

![Obtaining the contract script](/assets/verify_5.png)

## Create a contract address

After creating your own wallet, click the right mouse button, and create a contract address with your generated contract script:

![Create a contract address](/assets/verify_6.png)

Bind the contract address to your account and fill in the corresponding parameters. Because our contract has a parameter for signature, you have to fill in `00` in `Parameter List` (for details, please see [Parameter](Parameter.md)), and then enter the contract script from previous step in the `Code` box. 

The reason to associate an account is to bind a contract with a public-private key pair, so when the contract needs to be signed, the client will automatically sign with the private key of the bound account. 

![Create a contract address](/assets/verify_7.png)

After clicking `OK`, the smart contract authentication account is created successfully.

## Testing

The following is a test of the smart contract authentication account, when transferring assets out of a smart contract account, the consensus nodes will execute the contract when validating the transaction. If the contract validation is successful (returns result `true`), then the transaction is confirmed. Until result `true` is received, the transaction will have status unconfirmed. The test method is to first transfer some assets to the contract authentication account, and then transfer it out.

> [!Note]
> In order to ensure the accuracy of the test, do not have any other assets in the wallet. Otherwise you may not know whether the asset was transferred from the standard account or transferred from the contract account, unless you understand the client's change search algorithm and can confirm that the transaction is transferred from the smart contract address.


### Transfer asset to contract address

Transfer a set amount of assets into your contract account:

![Transfer asset to contract address](/assets/verify_9.png)

### Transfer contract assets

Transfer assets out from your smart contract account:

![Transfer the contract amount](/assets/verify_10.png)



> [!Note]
> The balance of the assets in the client is the sum of the balance in the standard account and the balance in the contract address, that is, assets of all addresses combined. Whether or not you can use the assets in the contract address depends on the result of the smart contract execution, if the contract is successful (the result is `true`) then the asset can be transferred out, otherwise it cannot be transferred.
