---
typora-root-url: ..\..
---

### Wie man Java verwendet um einen NEO smart contract zu schreiben

Smart contracts werden in  höheren Programmiersprachen wie Java, C#,  Python, Kotlin (usw...) geschrieben und in AVM (Neo´s Virtual Machine bytecode) kompiliert damit Sie im NEO Netzwerk lauffähig sind. 

Zum jetzigen Stand empfehelen wir für die Entwicklung von Smart Contracts C# einzusetzen. Der Java compiler befindet sich momentan immer noch in der Entwicklung, bis jetzt kann die  derzeitige Version (neoj) mit Basis Methoden umgehen. 

Dieser Abschnitt enthält ein Tutorial das dich bei der Konfiguration des Java development enviroment für NEO smart contracts unterstützt und dir eine Vorstellung gibt ​​wie ein Smart contract project erstellt und kompilert wird. 

Notitzen: Der Prozess enthält folgende Schritte:
1. Schreibe Java code (.java) für Klassen die FunctionCode oder VerificationCode der Neo Framework Library (JAR) enthalten
2. Benutze den normalen Java compiler um den Code in Java bytecode (.class) zu kompilieren
3. Konfiguriere den neoj (C#) compiler der den JVM code in AVM code (neoj.exe in Windows) konvertiert
4. Benutze neoj um dein .class file (.avm) zu kompilieren
5. Lade dir die Neo Node GUI herunter um dich mit dem Neo Testnet Network zu verbinden 
6. Benutze dein .avm script um den smart contract im Netzwerk zu veröffentlichen
7. Rufe dein .avm script auf um deinen smart contract auszuführen


### Ausführliche Anleitung

## Werkzeuge

The most efficient way of getting these steps done is to download and compile all the tools you will need:
Der beste Weg um all diese Schritte umzusetzen ist es die folgenden benötigten Werkzeuge runterzuladen und zu komplieren:

1. Herunterladen von Neo´s Node GUI. Im Moment wird empfholen die BETA developer GUI einzusetzen da diese hilfreiche extras zum debugging enthält. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Standardmäßig ist die GUI für das Testnet konfiguriert. Dieses wird nach dem start syncronisert was bis zu ein paar Stunden dauern kann.  
2. Herunterladen von Neo Framework Library JAR. Die neuste Version befindet sich hier:  [Antshares.SmartContract.Framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)
3. Lade eine IDE für Java (Optional aber Empfholen), wie z.B. IntelliJ oder Eclipse herunter.
4.Lade dir eine IDE für C# herunter: Im Moment muss der neoj compiler noch manuall erstellt werden da es sich noch nicht um einen veröffentlichten Release handelt. Empfholen wird Visual Studio 2017 da es kostenlos ist. 

## Entwickler Werkzeuge

### 1. Visual Studio 2017

Wenn du bereits Visual Studio 2017 & .NET Cross-Plattform Developent auf deinem Computer installiert hast kannst du diese Anleitung überspringen. 


Download und installieren: 

[Visual Studio Download Addresse](https://www.visualstudio.com/products/visual-studio-community-vs)

Der Installations Prozess ist sehr einfach, folge den Installationsanweisungen Schritt-für-Schritt, dabei sollte darauf geachtet werden das die Checkbox bei `.NET Core cross-platform development` ausgewählt ist da ansonsten sich das neo-vm project im Schritt #3 nicht öffnen lässt. 
Die Installation braucht zwischen zehn Minuten und einer Stunde. 

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
