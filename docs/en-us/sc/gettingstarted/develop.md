# Compiling a contract sample

So far, we have learned how to build a private chain and connect nodes to the chain. The following part will proceed to environment configuration, NEO smart contract coding and compilation and NEO smart contract deployment and invocation on private chain using C# and Windows 10. 

We will complete the following tasks in this section: 

- Install contract development environment
- Create a NEP-5 contract project
- Compile a contract

## Installing development environment

### Install Visual Studio 2017

Download and install [Visual Studio 2017](https://www.visualstudio.com/products/visual-studio-community-vs) . Select `.NET Core cross-platform development` option during installation.

![3_install_core_cross_platform_development_toolset](assets/3_install_core_cross_platform_development_toolset.jpg)

### Install NeoContractPlugin 

Open Visual Studio 2017 and click `tool` -> `extensions and Updates`，click `online`on the left column, search NEO and install NeoContractPlugin (the process must be completed online).

![3_download_and_install_smart_contract_plugin](assets/3_download_and_install_smart_contract_plugin.jpg)

### Configure neo-compiler 

1. Download [neo-compiler](https://github.com/neo-project/neo-compiler) project to your localhost.

2. Click `file` -> `open` -> `project/solutions` in Visual Studio 2017 and select neo-compiler.sln in the project file.

3. Right click neon project in the list and click `release`.

   ![3_publish_neo_compiler_msil_project](assets/3_publish_neo_compiler_msil_project.jpg)

4. After the release path is configured, click `release`. 

   Upon successful release, a neon.exe file is generated in bin\Release\PublishOutput。

> [!Note]
>
>  In case of error warning in the process of release: unable to copy file "obj\Release\netcoreapp1.0\win10-x64\neon.dll" as the file cannot be located, which may be be traced to a bug in VS 2017 (e.g. v15.4, 15.5), what you need to do is manually copy `\obj\Release\netcoreapp1.0\neon.dll` to `\obj\Release\netcoreapp1.0\win10-x64\` folder and release it again.

### Change environment parameter settings

Next we need to add path using the following method to allow neon.exe to be accessible from any point: 

1. For Windows10, press Windows+S, input environment parameter and select `edit the account's environment parameters`. 

   ![3_2017-06-07_12-07-03](assets/3_2017-06-07_12-07-03.png)

2. Select Path and click `edit`:

   ![3_environment_variable](assets/3_environment_variable.png)

3. Click `create` in the popped up window and input your file filer directory that contains neon.exe, then press `confirm`.

> [!Note]
>
> Do not add a path that contains“…… neon.exe” in the environment parameter field. Remember to input the path of the **file folder directory** that contains neon.exe instead of the path of neon.exe file.

![3_edit_environment_variable](assets/3_edit_environment_variable.png)

After the path is added, run CMD or PowerShell for testing purpose (if CMD starts working before the path is added, remember to restart it after adding the path).  If no error is reported after inputting neon and  the system sends the prompt message containing version number as follows, it means that the environment parameter configuration is successful.

![3_1545037391347](assets/3_1545037391347.png)

## Creating a NEO contract project

Upon completion of the previous steps, you may start to create NEO smart contract project in Visual Studio 2017 (no specific requirement for .NET Framework version):

1. Click `file` -> `create` -> `project`.
2. Select `NeoContract` in the list and change settings where necessary, then click `confirm`.

![3_new_smart_contract_project](assets/3_new_smart_contract_project.png)

A C# file will be auto-generated after the project is created with a default class inherited from the SmartContract. As indicated in the screenshot below, now you have a Hello World contract.

![3_smart_contract_function_code](assets/3_smart_contract_function_code.png)

Nevertheless, the above only demonstrates a simple data storage method - to store data in private storage area using key-value method.

## Editing NEP-5 code

Many developers are curious about how to release their own contract assets on NEO public chain. Now let's walk through the process on private chain.

1. Download the NEP-5 template from [Github](https://github.com/neo-project/examples).

2. Create a NEO smart contract project in Visual Studio 2017 and name it NEP5.

3. Open NEP5.cs

   The code contains basic information of the assets and the methods available to be invoked. You can make changes when needed.

   > [!NOTE]
   >
   > If there are red underlines under the code warning that the system is unable to find NEO name space and there is "!" in project references, you may take the following steps: 
   >
   > Right click the solution file in VS, click `manage NuGet package` and update the Neo.SmartContract.Framework to the latest official version in a new page.  If the red underlines still exist when program update is completed, you may try double clicking the "!". If the problem remains unsolved, you may resort to the solutions below: 
   >
   > 1. Download nuget.exe [here](https://www.nuget.org/downloads)  and copy it to the root directory of NeoContract project.
   > 2. Open Power Shell or command prompt (CMD).
   > 3. Redirect to the root directory of NeoContract project and run `nuget restore`.

4. Here we make certain modifications to the example files as follows:

   - Define total assets and `deploy` method.
   - Replace "Owner" with the address in 0.json (otherwise the wallet assets won't be accessible).

   The code is as follows:

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NEP5
{
    public class NEP5 : SmartContract
    {
        [DisplayName("transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        private static readonly byte[] Owner = "Ad1HKAATNmFT5buNgSxspbW68f4XVSssSw".ToScriptHash(); //Owner Address
        private static readonly BigInteger TotalSupplyValue = 10000000000000000;

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return Runtime.CheckWitness(Owner);
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                var callscript = ExecutionEngine.CallingScriptHash;

                if (method == "balanceOf") return BalanceOf((byte[])args[0]);

                if (method == "decimals") return Decimals();

                if (method == "deploy") return Deploy();

                if (method == "name") return Name();

                if (method == "symbol") return Symbol();

                if (method == "supportedStandards") return SupportedStandards();

                if (method == "totalSupply") return TotalSupply();

                if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2], callscript);
            }
            return false;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] account)
        {
            if (account.Length != 20)
                throw new InvalidOperationException("The parameter account SHOULD be 20-byte addresses.");
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            return asset.Get(account).AsBigInteger();
        }
        [DisplayName("decimals")]
        public static byte Decimals() => 8;

        private static bool IsPayable(byte[] to)
        {
            var c = Blockchain.GetContract(to);
            return c == null || c.IsPayable;
        }

        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            contract.Put("totalSupply", TotalSupplyValue);
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            asset.Put(Owner, TotalSupplyValue);
            Transferred(null, Owner, TotalSupplyValue);
            return true;
        }

        [DisplayName("name")]
        public static string Name() => "GinoMo"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "GM"; //symbol of the token

        [DisplayName("supportedStandards")]
        public static string[] SupportedStandards() => new string[] { "NEP-5", "NEP-7", "NEP-10" };

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));
            return contract.Get("totalSupply").AsBigInteger();
        }
#if DEBUG
        [DisplayName("transfer")] //Only for ABI file
        public static bool Transfer(byte[] from, byte[] to, BigInteger amount) => true;
#endif
        //Methods of actual execution
        private static bool Transfer(byte[] from, byte[] to, BigInteger amount, byte[] callscript)
        {
            //Check parameters
            if (from.Length != 20 || to.Length != 20)
                throw new InvalidOperationException("The parameters from and to SHOULD be 20-byte addresses.");
            if (amount <= 0)
                throw new InvalidOperationException("The parameter amount MUST be greater than 0.");
            if (!IsPayable(to))
                return false;
            if (!Runtime.CheckWitness(from) && from.AsBigInteger() != callscript.AsBigInteger())
                return false;
            StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));
            var fromAmount = asset.Get(from).AsBigInteger();
            if (fromAmount < amount)
                return false;
            if (from == to)
                return true;

            //Reduce payer balances
            if (fromAmount == amount)
                asset.Delete(from);
            else
                asset.Put(from, fromAmount - amount);

            //Increase the payee balance
            var toAmount = asset.Get(to).AsBigInteger();
            asset.Put(to, toAmount + amount);

            Transferred(from, to, amount);
            return true;
        }
    }
}

```

When the editing is done, the coding part of the smart contract is done.

## Compiling contract file

Click `generate`->`generate solutions` (hotkeys: Ctrl + Shift + B) in the menu to start compilation.

![](assets/compile.png)

When the compilation is done, NEO smart contract file named`NEP5.avm` is generated in the `bin/Debug` directory of the project.

![](assets/contractfile.png)

``NEP5.abi.json` is a descriptive file of the smart contract, which contains desciptions of the ScriptHash, entry, parameters and return values of the contract. More information about the smart contract ABI can be found in [NeoContract ABI](https://github.com/neo-project/proposals/blob/master/nep-3.mediawiki).

> [!Note] 
>
> Given that neon compiles .dll with nep-8 by default, which conflicts with older versions of NeoVM, you need to execute .dll using the neon compatible mode; otherwise the contract cannot be invoked properly.
>
> Open Power Shell or command prompt (CMD), enter bin/Debug directory and input the following command (replace nep5.dll with your own project file): 
>
> ```
> neon nep5.dll --compatible
> ```
>
>  The new `nep5.avm`  file and `nep5.abi.json`  file will overwrite the old files.

## What's next?

[Deploying and invoking contract](deploy.md)

