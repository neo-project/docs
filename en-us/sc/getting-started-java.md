---
typora-root-url: ..\..
---

### How to use Java to write an NEO smart contract

We currently recommend C# for developing smart contracts. The Java compiler is still in development but the current version (neoj) can handle basic methods.

This section contains a short tutorial that guides you in configuring the Java development environment for NEO smart contracts and gives you an idea of ​​how to create a smart contract project and how to compile it.

Note: You will need to first compile the neoj compiler which is written in C#.

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

    public static void Main(String[] args){
        Storage.Put(Storage.getCurrentContext(), "Greeting to the World", "Hello World!");
    }

}
```

Build the project which will give you `HelloWorld.class` in your out folder.

Then using neoj, run cmd.exe and execute:
> neoj.exe HelloWorld.class

If successful, it will create HelloWorld.avm which you can now use as smart contract bytecode.

For more information and to see working Java examples please refer here: [Java Examples](https://github.com/neo-project/examples-java)
