---
typora-root-url: ..\..
---

### How to use C# to write an AntShares smart contract

We currently recommend C# for developing smart contracts (though we support or plan to support Java, Kotlin, Go, C/C++, Python, JavaScript and other programming languages)

This section contains a short tutorial that guides you in configuring the C# development environment for AntShares smart contracts and gives you an idea of ​​how to create a smart contract project and how to compile it.

   > [!Note]
   > At present, all the projects have been upgraded to the Visual Studio 2017 version, if you want to use Visual Studio 2015 to create intelligent contracts can refer to [how to use C # to write ants intelligent contract for VS2015](getting-started-2015.md)

## Development Tools

### 1. Visual Studio 2017

If you have already installed Visual Studio 2017 on your computer and checked for .NET .NET Cross-Platform Development at the time of installation, you can skip this section.

Download and install:

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

The installation process is very simple, follow the operation prompts step-by-step, it should be noted that you need to check the installation of `.NET Core cross-platform development`, otherwise you will not be able to open AntShares.VM project in step #3. The installation takes about ten minutes or up to an hour.

![install net core cross-platform development toolset](en-us\sc\assets\1 - Install .NET Core cross-platform development toolset.png)

### 2.AntShares.SmartContract plugin

Installation method:

Open Visual Studio 2017, open Tools, click on Extensions and Updates, click on the Online tab on the left side of the window, search AntShares in the search box on the top right corner of the window, download the AntShares.SmartContract plugin (this step requires internet access).

![download and install antshares smart contract plugin](en-us\sc\assets\1.1 - Download and Install AntShares Smart Contract plugin.png)

### 3. AntShares.Compiler.MSIL

Installation and configuration steps:

Download the [AntShares.VM](https://github.com/AntShares/AntShares.VM) project on Github, open the solution with Visual Studio 2017, publish the AntShares.Compiler.MSIL project,

![publish antshares compiler msil project](en-us\sc\assets\2 - Publish AntShares.Compiler.MSIL project.png)

![publish and profile settings](en-us\sc\assets\3 - Publish and Profile Settings.png)


After the release is successful, the AntShares.Compiler.MSIL.exe file is generated in `bin\Release\PublishOutput`.

We now need to add this directory to our execution path. The PATH is the system variable that your operating system uses to locate needed executables from the command line or Terminal window.

**Windows 10 and Windows 8:**

  In Search, search for and then select: System (Control Panel)
  Click the Advanced system settings link.
  Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New.
  In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK.

**Windows 7:**

  From the desktop, right click the Computer icon.
  Choose Properties from the context menu.
  Click the Advanced system settings link.
  Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New.
  In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK.

![edit environmental variables](en-us\sc\assets\3.2 - Edit Environmental variables.png)

Now run Command or PowerShell, and enter Antshares.Compiler.Msil. If there is no error and the output shows the version number (as shown) the environment variable configuration is successful

![powershell enviornment variabled updated correctly](en-us\sc\assets\3.3 PowerShell Enviornment Variabled updated correctly.png)


NOTE. Windows 7 SP1 users might encounter an error "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. This error can be resolved by obtaining a copy of 'api-ms-win-core-console-l2-1-0.dll' and putting it in the directory C:\Windows\System32.

## Create project

After the above installation configuration is successful, you can create an AntShares.SmartContract.Template project in Visual Studio 2017.

![new smart contract project](en-us\sc\assets\4 - New Smart Contract Project.png)

Once you create a project, it will automatically generate a C# file, the default class inherited from the FunctionCode, as shown in the following:

![4 1 smart contract function code](en-us\sc\assets\4.1 Smart Contract Function code.png)


## Compile the Project

Everything is now ready to add the entry method that defines the smart contract:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

After you compiled it successfully, you will see` SmartContract1.avm` in the `bin/Debug` directory, which is the file that is generated as the AntShares smart contract.

![compile smart contract](en-us\sc\assets\5 - Compile Smart Contract.png)


Now that you have completed the configuration of the AntShares smart contract development environment, please refer to the [AntShares smart contract tutorial](tutorial.md)
