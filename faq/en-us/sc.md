# Smart contract

## Why can't NEO namespace be found in the new-created NeoContract project?

After creating the NeoContract project, there are many red underlines in the code indicating that the NEO namespace is not found, and there is an exclamation mark in the project reference.

To solve this problem, right-click on the solution file in Visual Studio and click `restore NuGet package`. After all the packages are restored successfully, if the issue still exists and there is still an exclamation mark in References in the right panel, try double-clicking the exclamation mark to solve the issue.

If you still cannot solve the issue, try this way:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root of the NeoContract project. 
2. Run Power Shell or command line (CMD) 
3. Go to the NeoContract root and run `nuget restore`.

## Why do I fail to publish C# smart contract compiler?

Before you publish the C# smart contract compiler, make sure you have done the following:

- Installed .net core 2.1 the latest version
- If using VS2017, selected the target as win10-64
- If using VS2019, changed the target to win10-64 and then selected the "Self-contained deployment" mode. 

## After publishing neon in Windows 7 and setting the environment variable, why is it prompted that api-ms-win-core-console-l2-1-0.dll is missing when I am running neon?

This is caused by the publishing system configuration. As the default publishing system for the neon project is win 10-x64, when you publish neon in Windows 7 the missing .dll file is prompted. 

To solve this problem, edit the neon.csproj file and change  `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` to `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>`. Then republish the project in Visual Studio or using the command `dotnet publish -r win7-x64 -c debug`.

For more information about RID refer to [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) .

Although you can download the file and copy it to the neon.exe directory, this method is not recommended due to potential security issues.

## Why can't neon be found in CMD after I set the environment variable?

This is because you did not restart CMD after you changed the environment variable. The CMD still read the parameters changed before. To solve this, restart the CMD.

## After publishing neon and adding neon.exe directory to path, why does compiling NeoContract hang at the step "Start NeoContract converter"?

This is because you did not restart Visual Studio after modifying the environment variable. The Visual Studio still read the environment variable changed before. 

To solve this problem, restart Visual Studio. If not solved, restart your system.

## Why does smart contract complied with the old version of neon fail to run on the test net or main net?

NEO smart contracts require development framework, compiler, and NEOVM versions are consistent. The code compiled with the old framework and compiler may not be able to work in the new version of NEOVM. It does not affect the smart contracts already published on the blockchain. So before you start developing smart contracts, make sure you use the latest version of framework (e.g. NeoContractPlugin) and compiler (e.g. neon).

Some parts of this article is excerpted from [NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7). Thanks for **cybourgeoisie**'s contribution.

If you are still having trouble or you do not find a relevant issue, you can open an issue or pull request on [GitHub NEO Doc project](https://github.com/neo-project/docs).

## I have deployed my contract successfully, but why do I fail to invoke it? 

This issue is caused by confliction between the old NEOVM opcodes and the new NEP-8 opcodes with which neon compiles contracts. To solve it, you need to compile the contract in compatible mode:

1. Publish the C# compiler neon.exe and add its path to environment parameter
2. Compile and build the contract in Visual Studio 2017
3. Compile the contract in compatible mode in your command line: `neon contract.dll --compatible`
4. Deploy the new contract file after it is generated.