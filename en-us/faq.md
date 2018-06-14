# Troubleshooting

### NuGet error when publishing neon

**Problem**

When you try to publish neon, you may be blocked by an error that prompts you cannot restore the NuGet package. Even if you use Visual Studio 2017, the problem still occurs. 

**Solution**

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root  of the neo-compiler project. 
2. Run Power Shell or command line (CMD) 
3. Go to the neo-compiler root and run `nuget restore` .

### neon.dll could not be copied

**Problem**

In some versions of VS 2017 (e.g.15.4, 15.5), the following error may occur when publishing a neon project:  

Cannot copy "obj\Release\netcoreapp1.0\win10-x64\neon.dll" because the file could not be found.

**Solution**

This may caused by a VS 2017 bug. To solve it, you can manually copy the file `\obj\Release\netcoreapp1.0\neon.dll` to the directory `\obj\Release\netcoreapp1.0\win10-x64\` and then republish.

### NEO namespace could not be found in the new-created NeoContract project

**Problem**

After creating the NeoContract project, there are many red underlines in the code indicating that the NEO namespace is not found, and there is an exclamation mark in the project reference.

**Solution**

To solve this problem, right-click on the solution file in Visual Studio and click `restore NuGet package`. After all the packages are restored successfully, if the issue still exists and there is still an exclamation mark in References in the right panel, try double-clicking the exclamation mark to solve the issue.

If you still cannot solve the issue, try this way:

1. Download nuget.exe from [here](https://www.nuget.org/downloads) and place it under the root of the NeoContract project. 
2. Run Power Shell or command line (CMD) 
3. Go to the NeoContract root and run `nuget restore`.


### api-ms-win-core-console-l2-1-0.dll is missing

**Problem**

After publishing neon in Windows 7 and setting the environment variable, when you are running neon, a message is displayed prompting that the api-ms-win-core-console-l2-1-0.dll file is missing. Although you can download the file and copy it to the neon.exe directory, this method is not recommended due to potential security issues.

**Solution**

This is caused by the publishing system configuration. As the default publishing system for the neon project is win 10-x64, when you publish neon in Windows 7 the missing .dll file is prompted. To solve this problem, edit the neon.csproj file and change  `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` to `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>`. Then republish the project in Visual Studio or using the command `dotnet publish -r win7-x64 -c debug`.

For more information about RID refer to [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)

### neon could not be found in CMD after setting the environment variable

**Problem**

After setting the environment variable, when you type neon in CMD, it prompted neon could not be found.

**Solution**

This is because you did not restart CMD after you changed the environment variable. The CMD still read the parameters changed before. To solve this, restart the CMD.

### Compiling NeoContract hung at the step "Start NeoContract converter"

**Problem**

After publishing neon and adding neon.exe directory to path, compiling NeoContract hung at the step "Start NeoContract converter"

**Solution**

This is because you did not restart Visual Studio after modifying the environment variable. The Visual Studio still read the environment variable changed before. 

To solve this, restart Visual Studio. If not solved, restart your system.

### Smart contract complied with the old version of neon failed to run on the test net or main net

**Problem**

The smart contract complied with the old version of neon failed to run on the test net or main net. The code is correct.

**Solution**

NEO smart contracts require development framework, compiler, and NEOVM versions are consistent. The code compiled with the old framework and compiler may not be able to work in the new version of NEOVM. It does not affect the smart contracts already published on the blockchain. So before you start developing smart contracts, make sure you use the latest version of framework (e.g. NeoContractPlugin) and compiler (e.g. neon).

Some parts of this article is excerpted from [NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7) . Thanks for **cybourgeoisie**'s contribution.

If you are still having trouble or you do not find a relevant issue, you can open an issue or pull request on [GitHub NEO Doc project](https://github.com/neo-project/docs).