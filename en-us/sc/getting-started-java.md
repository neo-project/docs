---
typora-root-url: ..\..
---

### How to use Java to write an NEO smart contract

Smart contracts are written in high-level languages such as Java, C#, Python, Kotlin (and more...) and compiled into AVM (Neo's Virtual Machine bytecode) so they can run on the Neo network.

We currently recommend C# for developing smart contracts. The Java compiler is still in development but the current version (neoj) can handle basic methods.

This section contains a tutorial that guides you in configuring the Java development environment for NEO smart contracts and gives you an idea of ​​how to create a smart contract project and how to compile it.

Notes: The process involves the following steps:
1. Write Java code (.java) for classes that extend FunctionCode or VerificationCode which is part of the Neo Framework Library (JAR)
2. Use the normal Java compiler to compile code into Java bytecode (.class)
3. Build the neoj (C#) compiler that converts JVM code into AVM code (neoj.exe on Windows)
4. Use neoj to compile your .class file (.avm)
5. Download Neo's Node GUI to connect to Neo's Testnet network
6. Deploy your .avm script to publish the smart contract to the network
7. Invoke your .avm script to execute your smart contract

### Detailed Instructions

## Tools

The most efficient way of getting these steps done is to download and compile all the tools you will need:

1. Download Neo's Node GUI. At the time of writing, it is recommended you use the BETA developer GUI as it has some extra debugging features which are helpful. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). It will have default presets to Testnet and you will have to wait (up to a few hours) for it to fully sync up.
2. Download the Neo Framework Library JAR. Current latest version is here: [Antshares.SmartContract.Framework JAR](https://github.com/neo-project/neo-compiler/blob/master/neoj/AntShares.SmartContract.Framework.jar)
3. Download an IDE for Java (optional but recommended), e.g. IntelliJ or Eclipse.
4. Download an IDE for C# - currently the neoj compiler needs to be built manually as it is not in wide distribution release format. Recommended is to get Visual Studio 2017 which is free.

## Development Tools

### 1. Visual Studio 2017

If you have already installed Visual Studio 2017 on your computer and checked for .NET Cross-Platform Development at the time of installation, you can skip this section.

Download and install:

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

The installation process is very simple, follow the operation prompts step-by-step, it should be noted that you need to check the installation of `.NET Core cross-platform development`, otherwise you will not be able to open neo-vm project in step #3. The installation takes about ten minutes or up to an hour.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. neo-compiler

Installation and configuration steps:

Download the [neo-compiler](https://github.com/neo-project/neo-compiler) project on Github, open the solution with Visual Studio 2017, publish the neoj project,

Publish the neoj compiler (which converts Java bytecode to the AVM bytecode).

![publish NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

After the release is successful, the neoj.exe file is generated in `bin\Release\PublishOutput`.

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

![edit environmental variables](/assets/edit_environmental_variables.png)

Now run Command or PowerShell, and enter neoj.exe. If there is no error and the output shows the version number (as shown) the environment variable configuration is successful

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


NOTE. Windows 7 SP1 users might encounter an error "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. This error can be resolved by obtaining a copy of 'api-ms-win-core-console-l2-1-0.dll' and putting it in the directory C:\Windows\System32.

## Create project

After the above installation is complete you can create a Java project (e.g. using Eclipse or IntelliJ).

You will need to add the AntShares.SmartContract.Framework.jar (which is the neo compiler project) as an external library.


## Compile the Project

Everything is now ready to add the entry method that defines the smart contract:

```Java
import AntShares.SmartContract.Framework.FunctionCode;
import AntShares.SmartContract.Framework.Services.AntShares.Storage;

public class HelloWorld extends FunctionCode{

    public static byte[] Main(String[] args){
        Storage.Put(Storage.getCurrentContext(), "Greeting to the World", "Hello World!");
        return Storage.Get(Storage.getCurrentContext(),"Greeting to the World");
    }

}
```

Build the project which will give you `HelloWorld.class` in your out folder.

Then using neoj, run cmd.exe and execute:
> neoj.exe HelloWorld.class

If successful, it will create HelloWorld.avm which you can now use as smart contract bytecode.

For more information and to see working Java examples please refer here: [Java Examples](https://github.com/neo-project/examples-java)

## Deploy smart contracts

Once you are at this stage, the instructions are the same no matter what language you used to write the smart contracts.
Follow this tutorial: [Deploy a lock contract](http://docs.neo.org/en-us/sc/tutorial/Lock2.html)
