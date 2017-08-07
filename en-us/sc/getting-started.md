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

![install net core cross-platform development toolset](assets/install_core_cross_platform_development_toolset.png)



## Smart contract development process

### 1. Download and clone neo-compiler 

In Team explorer Click Clone and insert the neo-compiler's link: https://github.com/neo-project/neo-compiler

![gettingstarted1](assets/getting_started_1.png)

Click Clone.

Double click on neo-compiler.sln

![gettingstarted2](assets/getting_started_2.PNG)
 
Click Solution explorer:

![gettingstarted3](assets/getting_started_3.png)

### 2. Neon 

Right click on ’neon’ and select Publish

![gettingstarted4](assets/getting_started_4.png)
 
Click on Publish.

Check your Output window:

![gettingstarted5](assets/getting_started_5.png)

After the release is successful, the neon.exe file is generated in bin\Release\PublishOutput.

![gettingstarted6](assets/getting_started_6.png)

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

![gettingstarted7](assets/getting_started_7.png)


Now run Command or PowerShell, and enter neon. If there is no error and the output shows the version number (as shown) the environment variable configuration is successful.

![gettingstarted8](assets/getting_started_8.png)

NOTE. Windows 7 SP1 users might encounter an error "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. This error can be resolved by obtaining a copy of 'api-ms-win-core-console-l2-1-0.dll' and putting it in the directory C:\Windows\System32.

### 3. Create project 

Create a new project in Visual Studio 2017: File->New->Project

    
![gettingstarted9](assets/getting_started_9.png)

Select Console App (.NET Core) and type ’HelloProject’ in the Name field. Then click OK.

Right click on Dependencies:

![gettingstarted10](assets/getting_started_10.png)
 
Add reference. Click Browse, and select and add neon.dll

![gettingstarted11](assets/getting_started_11.png)


Navigate to NuGet package manager:

![gettingstarted12](assets/getting_started_12.png)


Click Browse, then select and Neo.SmartContract.Framework.
 
![gettingstarted13](assets/getting_started_13.png)


We can insert our Hello world code:

![gettingstarted14](assets/getting_started_14.png)

### 4. Compile project 

Build the project, then Publish::
 
![gettingstarted15](assets/getting_started_15.png) 
 
![gettingstarted16](assets/getting_started_16.png)

Navigate to the directory whick contains .dll file:

![gettingstarted17](assets/getting_started_17.png)

To compile it, type: neon HelloProject.dll

![gettingstarted18](assets/getting_started_18.png)

![gettingstarted19](assets/getting_started_19.png) 

  
Now we get the .avm file:
![gettingstarted20](assets/getting_started_20.png)



Now that you have completed the configuration of the AntShares smart contract development environment, please refer to the [AntShares smart contract tutorial](tutorial.md)

