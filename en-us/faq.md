# Frequently Asked Questions (FAQ)

## The basics

**What browsers are available for NEO blockchain?**

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

**How can I obtain the NEP-5 assets TXID?**

Currently we recommend you use the blockchain browser https://scan.nel.group to view the NEP-5 assets TXID.

1. In the browser, click Assets in the top navigation bar. 
2. In the Assets drop-down list, select NEP-5.
3. Click the desired asset to view its TXID in the details page that appears.

**Why is it prompted that there is no object's private key in the wallet when withdrawing assets from a multi-party signature contract which requires a minimum signature of 3?**

After the private chain is set up, you need to make the same configurations in all four wallets, that is, add the multi-party signed addresses and then rebuild the wallet index. 

## Smart contract

**Why is it prompted the NuGet package cannot be restored when I try to publish neon? Even if I use Visual Studio 2017, the problem still occurs.**

To solve it:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root  of the neo-compiler project. 
2. Run Power Shell or command line (CMD) 
3. Go to the neo-compiler root and run `nuget restore` .

**Why can't neon.dll be copied when publishing a neon project?**

This may caused by a VS 2017 bug. In some versions of VS 2017 (e.g.15.4, 15.5), the following error may occur:  

Cannot copy "obj\Release\netcoreapp1.0\win10-x64\neon.dll" because the file could not be found.

To solve it, you can manually copy the file `\obj\Release\netcoreapp1.0\neon.dll` to the directory `\obj\Release\netcoreapp1.0\win10-x64\` and then republish.

**Why can't NEO namespace be found in the new-created NeoContract project?**

After creating the NeoContract project, there are many red underlines in the code indicating that the NEO namespace is not found, and there is an exclamation mark in the project reference.

To solve this problem, right-click on the solution file in Visual Studio and click `restore NuGet package`. After all the packages are restored successfully, if the issue still exists and there is still an exclamation mark in References in the right panel, try double-clicking the exclamation mark to solve the issue.

If you still cannot solve the issue, try this way:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root of the NeoContract project. 
2. Run Power Shell or command line (CMD) 
3. Go to the NeoContract root and run `nuget restore`.

**After publishing neon in Windows 7 and setting the environment variable, why is it prompted that api-ms-win-core-console-l2-1-0.dll is missing when I am running neon?**

This is caused by the publishing system configuration. As the default publishing system for the neon project is win 10-x64, when you publish neon in Windows 7 the missing .dll file is prompted. 

To solve this problem, edit the neon.csproj file and change  `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` to `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>`. Then republish the project in Visual Studio or using the command `dotnet publish -r win7-x64 -c debug`.

For more information about RID refer to [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) .

Although you can download the file and copy it to the neon.exe directory, this method is not recommended due to potential security issues.

**Why can't neon be found in CMD after I set the environment variable?**

This is because you did not restart CMD after you changed the environment variable. The CMD still read the parameters changed before. To solve this, restart the CMD.

**After publishing neon and adding neon.exe directory to path, why does compiling NeoContract hang at the step "Start NeoContract converter"?**

This is because you did not restart Visual Studio after modifying the environment variable. The Visual Studio still read the environment variable changed before. 

To solve this problem, restart Visual Studio. If not solved, restart your system.

**Why does smart contract complied with the old version of neon fail to run on the test net or main net?**

NEO smart contracts require development framework, compiler, and NEOVM versions are consistent. The code compiled with the old framework and compiler may not be able to work in the new version of NEOVM. It does not affect the smart contracts already published on the blockchain. So before you start developing smart contracts, make sure you use the latest version of framework (e.g. NeoContractPlugin) and compiler (e.g. neon).

Some parts of this article is excerpted from [NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7). Thanks for **cybourgeoisie**'s contribution.

If you are still having trouble or you do not find a relevant issue, you can open an issue or pull request on [GitHub NEO Doc project](https://github.com/neo-project/docs).