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

The installation process is very simple, follow the operation prompts step-by-step, it should be noted that you need to check the installation of `.NET Core cross-platform development`, the installation takes about ten minutes or up to an hour.

![image](en-us\sc\assets\1 - Install .NET Core cross-platform development toolset.png)

### 2.AntShares.SmartContract plugin

Installation method:

Open Visual Studio 2017, open Tools, click on Extensions and Updates, click on the Online tab on the left side of the window, search AntShares in the search box on the top right corner of the window, download the AntShares.SmartContract plugin (this step requires internet access).

![image](http://docs.antshares.org/images/2017-06-02_18-28-37.jpg)

### 3. AntShares.Compiler.MSIL

Installation and configuration steps:

Download the [AntShares.VM](https://github.com/AntShares/AntShares.VM) project on Github, open the solution with Visual Studio 2017, publish the AntShares.Compiler.MSIL project,

![image](http://docs.antshares.org/images/2017-06-02_18-21-53.jpg)

![image](http://docs.antshares.org/images/2017-06-02_18-37-44.jpg)

After the release is successful, the AntShares.Compiler.MSIL.exe file is generated in `bin\Release\PublishOutput`.

We now need to add this directory to our execution path:

Press the Windows + S key, enter the "environment variable", select "edit the account environment variable" carriage return

![image](http://docs.antshares.org/images/2017-06-07_12-07-03.png)

Then select Path and click `Edit '

![image](http://docs.antshares.org/images/2017-06-07_11-35-28.png)

In the pop-up window, click "New" input AntShares.Compiler.MSIL.exe where the directory, click `OK`, `OK`

![image](http://docs.antshares.org/images/2017-06-07_11-29-16.png)

Add the path, run Command or PowerShell, and enter Antshares.Compiler.Msil. If there is no error and the output shows the version number (as shown) the environment variable configuration is successful

![image](http://docs.antshares.org/images/2017-06-07_11-48-23.png)

NOTE. Windows 7 SP1 users might encounter an error "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. This error can be resolved by obtaining a copy of 'api-ms-win-core-console-l2-1-0.dll' and putting it in the directory C:\Windows\System32.

## Create project

After the above installation configuration is successful, you can create an AntShares.SmartContract.Template project in Visual Studio 2017.

![image](http://docs.antshares.org/images/2017-06-07_11-51-20.png)

Once you create a project, it will automatically generate a C# file, the default class inherited from the FunctionCode, as shown in the following:

![image](http://docs.antshares.org/images/2017-06-07_11-55-41.png)

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

![image](http://docs.antshares.org/images/2017-05-11_13-21-21.jpg)

Now that you have completed the configuration of the AntShares smart contract development environment, please refer to the [AntShares smart contract tutorial](tutorial.md)
