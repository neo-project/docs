# An Introduction to Contract Development on Neo

In this tutorial, we will work you through an example contract on Neo blockchain, which includes the tasks of setting up and configuring the development environment, compiling, deploying, and invoking the smart contract on a private chain and testnet. This one is simply meant to get us up and running with a basic development and testing environment, highlighting some key technical concepts along the way.

This tutorial contains the following topics:

- [Development Environment](#development-environment)
- [Developing a contract](#developing-a-contract)
- [Compiling the contract](#compiling-the-contract)
- [Deploying the contract](#deploying-the-contract)
- [Invoking the contract](#invoking-the-contract)
- [Interfacing using NeoLine wallet](#interfacing-using-neoline-wallet)

## Development environment

### System environment
You are recommended to run Neo-CLI in the following environments that we have tested:
- Windows 10
- Ubuntu 16.04/18.04
- CentOS 7.4/7.6
- macOS Big Sur/version 11.1

### Connecting to network

Neo provides the Test network where you can develop, debug, and test your programs before publishing them on the live network. To connect your node to test net, see detailed instructions [here](https://docs.neo.org/docs/en-us/develop/network/testnet.html). 

Alternatively, you can also set up your own private chain where you can get more flexibility with plenty of test tokens. 

#### Setting up a private chain

You can pick one of the following options:

- Build a private chain with one node

  Neo-CLI supports generating blocks without consensus nodes, which means you can set up a private chain with one node. There are two ways to achieve this, you can choose either of them of your will. 

  - Directly download the project [Neo-Private-Net](https://github.com/neo-ngd/NEO-Private-Net) to run the private chain quickly. 
  - Or build a private chain with one node from scratch, more details please check at the [guide](https://docs.neo.org/docs/en-us/develop/network/private-chain/solo.html#prerequisites).

- Build a private chain with multiple nodes

  You can also choose to build a private chain with multiple nodes to practise the consensus mechanism. The [guide](https://docs.neo.org/docs/en-us/develop/network/private-chain/private-chain2.html) here shows you the way to build a private chain on a windows system computer. 

Refer to the instructions from above links to set up your private chain and withdraw NEO and GAS from genesis block.

### Preparing a wallet file

Now let's create a new wallet file used for deploying smart contracts:

1. Create a new wallet file named 0.json and copy the default address for later use.
2. Open the wallet where you have withdrawn NEO and GAS from genesis block, transfer all the assets in the wallet to 0.json and wait for the transaction to be confirmed.
3. Open 0.json to check if the assets are received.

## Developing a contract

### Configuring the development tool

Refer to the official [guide](https://docs.neo.org/docs/en-us/gettingstarted/develop.html#installing-tools) to install tools and contract template, and then create a contract project named Contract1 with the following command:

```
dotnet new neo3-contract -n Contract1
```

### Editing the contract

Here we provide a simple smart contract written in C#. The source code is here:

```csharp
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
using System.ComponentModel;
using Neo;
using Neo.SmartContract;

namespace Example
{
    [ManifestExtra("Email", "dev@neo.org")]
    [ManifestExtra("Description", "This is a example contract")]
    public class Contract1 : SmartContract
    {
        //TODO: Replace it with your own address.
        [InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default;

        private static bool IsOwner() => Runtime.CheckWitness(Owner);

        // When this contract address is included in the transaction signature,
        // this method will be triggered as a VerificationTrigger to verify that the signature is correct.
        // For example, this method needs to be called when withdrawing token from the contract.
        public static bool Verify() => IsOwner();

        // TODO: Replace it with your methods.
        public static string MyMethod()
        {
            return Storage.Get(Storage.CurrentContext, "Hello");
        }

        // This method will be executed immediately after the contract is deployed.
        public static void _deploy(object data, bool update)
        {
            if (update) return;

            // It will be executed during deploy
            Storage.Put(Storage.CurrentContext, "Hello", "World");
        }

        public static void Update(ByteString nefFile, string manifest)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Update(nefFile, manifest, null);
        }

        public static void Destroy()
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            ContractManagement.Destroy();
        }
    }
}
```
In the example contact above, note these methods:

-  `Update`：This method enables the contract update function.  When it is invoked, the contract is upgraded and neither the contract hash nor the storage area is changed. You can refer to [here](https://docs.neo.org/docs/en-us/develop/write/update.html) to update your contract.
- `Destroy`: This method takes no arguments. When it is invoked, the contract and its storage, if any, are deleted. Then the contract is no longer available.

## Compiling the contract

Run the following command to build your contract：

```
dotnet build
```

Related contract files are outputted under `\bin\Debug\net5.0` path in the contract project directory.

## Deploying the contract

Previously, we have compiled an example contract file (Contract1.nef) and contract descriptive file (Contract1.manifest.json), next we will move on to deployment and invocation of the contract with Neo-CLI.

In Neo-CLI, input the deploy command `deploy <nefFilePath> [manifestFile]` , for example:
```
deploy Contract1.nef
```
or
```
deploy Contract1.nef Contract1.manifest.json
```

After the command is executed, the contract is deployed and the related fee is charged by the system automatically. For more information, refer to the [official guide](https://docs.neo.org/docs/en-us/develop/deploy/deploy.html). 

## Invoking the contract

After you deployed a smart contract on the blockchain, you can then invoke it by its script hash. You can query contract details, such as the contract general information, methods, notifications, etc.

In `Neo-CLI`, invoke the contract using the  command line:
```
invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]
```

For example:
```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 symbol
```
After executed successfully, the following information is printed：
```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"VG9rZW5TeW1ib2w="}]

relay tx(no|yes):
```
Where:

- VM State: `HALT` indicates the vm executed successfully; `FAULT` indicates the vm exited during execution due to an exception.

- Evaluation Stack: the result of contract execution, where the value is encoded with Base64 when it is a string or ByteArray.

- You can do the data format conversion [here](https://neo.org/converter/) `VG9rZW5TeW1ib2w= => TokenSymbol`

For more details, please check at the [guide](https://docs.neo.org/docs/en-us/develop/deploy/invoke.html) here.

## Interfacing using NeoLine wallet

The interaction between smart contracts deployed on the blockchain and its users can happen in many different devices and platforms.

In our example, we'll use the NeoLine extension plugin wallet to interface with the chain and expose the results in a simple user interface. 

### Installation

The following options are available for you to install the NeoLine plugin, you can choose one of your will.

- Directly download the [NeoLine extension plugin wallet](https://chrome.google.com/webstore/detail/neoline/cphhlgmgameodnhkjdmkpanlelnlohao?utm_source=chrome-ntp-icon) to run the desired chain quickly.
- Get the latest `crx` release from [here](https://github.com/NeoNEXT/neoline/releases).
- Or build the project. For more details check at [README](https://github.com/NeoNEXT/neoline#readme)

### Using NeoLine

After you installed the NeoLine and pined it to the browser shortcut, then see the gif below to create a wallet.

<img src="./images/create.gif" alt="create" style="zoom:50%;" />

The following shows that how to transfer `N3 Gas`. you can check the transaction at [N3 NeoTube](https://neo3.neotube.io).

![transfer](./images/transfer.gif)

### Calling the dAPI

After you completed the instructions above, you can call the dAPI of NeoLine and run it directly on the browser, without deploying the full node of Neo.</br>

Initialize NeoLine N3 dAPI example.</br>

```js
window.addEventListener('NEOLine.NEO.EVENT.READY', () => {
    const neoline = new neoline.Init();
    const neolineN3 = new neolineN3.Init();
});

neolineN3.getBalance().then(result => console.log(result));
```

For more details check the following links:

- [Neo2 dAPI Docs](https://neoline.io/dapi/)
- [N3 dAPI Docs](https://neoline.io/dapi/N3.html)







