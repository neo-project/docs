# Developing a contract sample

We have completed setting up the private chain and configuring the node. In this section we will walk you through configuring the environment, writing, and compiling an NEP17 contract using C#.

You can choose either Visual Studio or Visual Studio Code to develop contracts. The latter way is more simplified and suitable for macOS users.

## Setting up development environment

### Installing tools

1. Download and install [Visual Studio 2019](https://www.visualstudio.com/products/visual-studio-community-vs).

   Note that you need to select `.NET Core cross-platform development` and `Visual Studio Extension Development` option during installation.

2. Install [.NET Core 5.0 Developer Pack](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.202-windows-x64-installer) 

3. Install [.NET Framework 4.6.2 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net462-developer-pack-offline-installer), which helps you load the project correctly.

4. Download  [neo-devpack-dotnet](https://github.com/neo-project/neo-devpack-dotnet) from GitHub.

### Configuring environment variable

1. In Visual Studio open the solution file `neo-devpack-dotnet.sln`
2. Compile the project `Installer` and output Neo.SmartContract.Installer
3. Install Neo.SmartContract.Installer
4. Compile the project `Neo.Compiler.CSharp` and output nccs.dll
5. Add the path where nccs.dll locates to the environment variable path.

### Upgrading dependency

Option 1：

1. Add the file NuGet.Config to the solution directory:

   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
    <packageSources>
    <clear />
    <add key="MyGet-neo" value="https://www.myget.org/F/neo/api/v3/index.json" />
    <add key="NuGet.org" value="https://api.nuget.org/v3/index.json" />
    </packageSources>
   </configuration>
   ```

2. Upgrade Neo.SmartContract.Framework to the latest.

   ![](assets/nuget.png)

Option 2：

1. Delete the reference Neo.SmartContract.Framework in NuGet.
2. Add reference to Neo.SmartContract.Framework in the solution neo-devpack-dotnet or the complied dll.

## Creating a NEP17 contract project

### Creating a project

1. In Visual Studio 2019 click `File` -> `New` -> `Project`.

2. In the project template dialog that appears, search for `neocontract` and select NeoContract for C#. Follow the wizard to create the project.

   ![neocontract](assets/neocontract.png)

### Editing NEP17 Code

When the project is created, a simple smart contract template is automatically created, which writes a key-value pair of "Hello" "World" to the storage.

Since many developers are concerned about how to publish their own contract assets on the Neo block chain, now let's work through the process on private chain.

Download the NEP17 template from [NEP17 example of Neo N3](https://github.com/neo-project/examples/tree/bcad04d6e634592e7fa4ceeb78e9fbebab2b07a2/csharp/NEP17).

> [!Note]
>
> In comparison with Neo Legacy, the Neo N3 NEP17 sample has the following changes:
>
> - Added the customized attributes above the smart contract class
>
>    ```c#
>    [DisplayName("Token Name")]
>    [ManifestExtra("Author", "Neo")]
>    [ManifestExtra("Email", "dev@neo.org")]
>    [ManifestExtra("Description", "This is a NEP17 example")]
>    [SupportedStandards("NEP-17")]
>    [ContractPermission("*", "onNEP17Payment")]
>    public class NEP17 : SmartContract
>    ……
>    ```
>
> - Removed the Name method
>
> - Added _deploy method, which will be executed immediately after the contract is deployed
>
> - Added the Update and Destroy methods
>
> - All the Crowdsale methods are in the NEP17.Crowdsale.cs file. Developers can choose to use this file if need be.
>
> - Called the onNEP17Payment method of the recipient in the Transfer method
>
> - Implemented onNEP17Payment to automatically execute the smart contract when NEP17 assets are received.
>

Reference: [NEP-17](../develop/write/nep17.md)

## Compiling contract file

Option 1:

When you complete coding, click `Build` -> `Build Solutions` (hotkeys: Ctrl + Shift + B) in the menu to start compilation.

Option 2:

From the solution or project directory, start the command line and run `nccs`.

When the compilation is done, the following files are generated under the `bin/Debug` directory of the project.

- `NEP17.nef` : The smart contract execution file for Neo N3, just as .avm for Neo Legacy.
- `NEP17.manifest.json` : The descriptive file of the smart contract, covering descriptions of functions, ScriptHash, entry, method, parameters, and return values of the contract.
