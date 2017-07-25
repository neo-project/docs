# How to use C # to write ants intelligent contract for VS2015

We currently recommend C# for developing smart contracts (though we support or plan to support Java, Kotlin, Go, C/C + +, Python, JavaScript and other programming languages)

This section contains a short tutorial that guides you in configuring the C# development environment for AntShares smart contracts and gives you an idea of how to create a smart contract project and how to compile it.

## development tools

### 1. Visual Studio 2015

Download and install method:

If you have already installed Visual Studio 2015 (any version) on your computer, you can skip this section.

Visual Studio 2015 has been off the official website from home, but can be downloaded.

Open the [Visual Studio old version download page](https://www.visualstudio.com/en/vans/vs/older-downloads/) click `free to join`

   ![](http://docs.antshares.org/images/2017-06-02_18-18-13.jpg)

Use your own Microsoft account login, enter Visual Studio Dev Essentials in the navigation menu, click `download`

![image](http://docs.antshares.org/images/2017-05-10_13-47-10.jpg)

In the search box, enter Visual Studio Community 2015 with Update 3, and then select the search results in a good version, language, etc., click the right side of the `download` button
![image](http://docs.antshares.org/images/2017-05-10_13-45-48.jpg)

Installation method and the general software is basically the same, the installation process without the need to select additional features, only the core part of the VS2015 can be installed

![image](http://docs.antshares.org/images/2017-05-10_9-48-54.jpg)

### 2. NET Core tools Preview 2 for Visual Studio 2015

Download and install method:

Open the [.Net Core download page](https://www.microsoft.com/net/download/core)

Download and install NET Core tools Preview 2 for Visual Studio 2015

![image](http://docs.antshares.org/images/2017-05-10_15-38-46.jpg)

### 3. AntShares.SmartContract plugin

installation method:

Open Visual Studio 2015, open the tool, extended and updated, click on the left for online search for AntShares installation, AntShares.SmartContract

![image](http://docs.antshares.org/images/2017-05-10_15-50-48.jpg)

### 4. AntShares.Compiler.MSIL

Installation and configuration methods:

Download the [AntShares.VM](https://github.com/AntShares/AntShares.VM) project on Github, open the solution with Visual Studio 2015, compile the AntShares.Compiler.MSIL project,

![image](http://docs.antshares.org/images/2017-05-10_18-22-39.jpg)

After the compilation is successful, the AntShares.Compiler.MSIL.exe file will be generated in `bin\Debug\netcoreapp1.0\win10-x64`
   > [!Note]
   > If your computer is a 32-bit operating system, you need to change the win10-x64 in the project.json file to win10-x86

You now need to add a path, so that any location can access the program. To add the path method, open the computer properties (or turn on the control panel, system and security, system), open the advanced system settings, select the Advanced tab, click the environment variable button, as shown in Figure

![image](http://docs.antshares.org/images/2017-05-10_18-37-05.jpg)

Then select Path and click `Edit '

![image](http://docs.antshares.org/images/2017-05-10_18-46-05.jpg)

In the pop-up window, click "New" input AntShares.Compiler.MSIL.exe where the directory, click `OK`, `OK`

![image](http://docs.antshares.org/images/2017-05-10_18-48-11.jpg)

Add the path, run cmd test, enter antshares.compiler.msil, no error, the output as shown in the figure that the environment variable configuration is successful

![image](http://docs.antshares.org/images/2017-05-10_18-52-10.jpg)

## Create project

After the above four-step installation is successful, you can create an AntShares smart contract project in Visual Studio 2015.

![image](http://docs.antshares.org/images/2017-05-10_16-08-48.jpg)

This will automatically generate a C# file, the default class inherited from the FunctionCode, as shown in the following:

![image](http://docs.antshares.org/images/2017-05-10_16-25-09.jpg)

- Note: If the following image appears, because the project in the AntShares.SmartContract.Framework did not successfully restore, you can restore the NuGet package in the following way (the process without networking)

![image](http://docs.antshares.org/images/2017-05-10_16-27-40.jpg)

In the Solution Explorer, select the solution, right-click, and click `Restore NuGet Package`

![image](http://docs.antshares.org/images/2017-05-10_16-28-39.jpg)

Then open the project reference, click `AntShares.SmartContract.Framework`. A few cases still can not restore Nuget package how to do? Please restart Visual Studio 2015 or try to generate a solution directly.

![image](http://docs.antshares.org/images/2017-05-10_16-31-55.jpg)

## Compile the project

Everything is now ready to add the entry method to the project:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```
After this compiles successfully, you will see the generated `SmartContract1.avm` file in the `bin/Debug` directory, which is the file that is generated by the AntShares smart contract.

![image](http://docs.antshares.org/images/2017-05-11_13-21-21.jpg)


!Note:
   If you are generated, there is no output of the results of the map, it does not matter, you can also directly enter the command to compile the dll avm file

   Open a command prompt, navigate to the Debug directory, enter the following highlight (SmartContract1.dll is the name of the dll generated by the previous step).
```
	> C: \ ... \ bin \ Debug> `antshares.compiler.msil SmartContract1.dll`
	>
	> AntShars.Compiler.MSIL console app v1.6.4.2
	>   
	> Find function entry point: System.Void SmartContract1.Contract1 :: Main ()
	>   
	> Convert succ
	>   
 	> Write: SmartContract1.avm
 	>
 	> SUCC
  	>
	> C: \ ... \ bin \ Debug>
```

Now that you have completed the configuration of the smart contract development environment, please refer to the [Art Experiment Guide for Tomids](tutorial.md)
