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

------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------


Create NEO Smart Contract in Visual Studio 2017

1. Open Visual Studio.


2. In Team explorer Click Clone and insert the neo-compiler link: https://github.com/neo-project/neo-compiler

![gettingstarted1](assets/getting_started_1.png)

3. Create the Git repo by clicking Clone



4. Double click on neo-compiler.sln


![gettingstarted2](assets/getting_started_2.PNG)

 
5. Click Solution explorer:


![gettingstarted3](assets/getting_started_3.png)


 
6. Right click on ’neon’ and select Publish

![gettingstarted4](assets/getting_started_4.png)

 
7. Click on Publish.

8. Check your Output window:

![gettingstarted5](assets/getting_started_5.png)

  
9. Navigate to your directory (Target Location), where you can find neon.exe:

![gettingstarted6](assets/getting_started_6.png)

10. You have to add this directory path to the PATH environment variable:

![gettingstarted7](assets/getting_started_7.png)

11. We can check how it works. Run cmd and type ’neon’:


![gettingstarted8](assets/getting_started_8.png)

12. Now create a new project in Visual Studio 2017:

	File->New->Project
    
![gettingstarted9](assets/getting_started_9.png)

Select Console App (.NET Core) and type ’HelloProject’ in the Name field. Then click OK.

13. Right click on Dependencies:

![gettingstarted10](assets/getting_started_10.png)
 
14. Add reference. Click Browse, and select neon.dll


![gettingstarted11](assets/getting_started_11.png)

Add it. Then OK.

15. Navigate to NuGet package manager:

![gettingstarted12](assets/getting_started_12.png)


16. Click Browse and select Neo.SmartContract.Framework. Then click Install.
 
![gettingstarted13](assets/getting_started_13.png)


17. Now we can insert our Hello world code:

![gettingstarted14](assets/getting_started_14.png)

 
18. Build the project:


 
![gettingstarted15](assets/getting_started_15.png)

 
19. Publish:
 
![gettingstarted16](assets/getting_started_16.png)

20.  Navigate to the directory whick contains .dll file:

![gettingstarted17](assets/getting_started_17.png)

21. Compile it, type: neon HelloProject.dll

![gettingstarted18](assets/getting_started_18.png)

![gettingstarted19](assets/getting_started_19.png)
 

  
Now we get the .avm file:
![gettingstarted20](assets/getting_started_20.png)



Now that you have completed the configuration of the AntShares smart contract development environment, please refer to the [AntShares smart contract tutorial](tutorial.md)

