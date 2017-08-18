---
typora-root-url: ..\..
---

### Die Erstellung eines NEO Smart Contracts mit C#

Aktuell empfehlen wir C# für die Entwicklung von Smart Contracts (obwohl die Unterstützung von Java, Kotlin, GO, C/C++, Python, JavaScript und anderen Programmiersprachen vorhanden bzw. geplant ist). 

Dieser Abschnitt enthält ein kurzes Tutorial, das die Konfiguration eines C# Entwicklungsumfeldes für NEO Smart Contracts erklärt und die grundlegende Idee der ​​Erstellung und Kompilierung eines Smart Contract Projekts vermittelt. 

Anmerkung: Aktuell wurden alle Projekte auf Visual Studio 2017 upgegradet. Wenn Sie Visual Studio 2015 verwenden möchten um Smart Contracts zu erstellen, dann lesen sie bitte, [wie man C# in VS2015 verwenden kann, um NEO Smart Contracts zu erstellen](https://github.com/neo-project/docs/blob/master/en-us/sc/getting-started-2015.md) 

## Entwicklungstools 

### 1. Visual Studio 2017

Wenn Sie Visual Studio 2017 bereits auf ihrem Computer installiert haben und .NET Cross-Plattform Entwicklung bei der Installation ausgewählt haben, dann überspringen Sie bitte dieses Kapitel. 

Herunterladen und Installieren:

[Visual Studio Download Link](https://www.visualstudio.com/de/vs/)

Die Installation ist äußerst einfach, folgen Sie einfach den Schritt-für-Schritt Anweisungen. Bitte beachten Sie, dass die Installation von .Net Cross-Plattorm Entwicklung ausgewählt werden muss, da Sie sonst neo-vm project in Schritt #3 nicht öffnen können. Die Installation dauert zwischen 10 Minuten und einer Stunde. 

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)
 
### 2. NeoContractPlugin

Installation:

Öffnen Sie Visual Studio 2017, wählen Sie Tools aus, klicken Sie auf Erweiterungen und Updates, klicken Sie auf den Online Tab auf der linken Seite, suchen Sie NEO in dem Suchfeld in der rechten oberen Ecke und downloaden Sie NeoContractPlugin (Internetverbindung erforderlich).
 
 ![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)
 
### 3. Neo-Compiler 

Installation und Konfiguration:

Downloaden Sie das [neo-compiler](https://github.com/neo-project/neo-compiler) Projekt auf Github, öffnen Sie den Solution Explorer in Visual Studio 2017 und veröffentlichen Sie das neon Projekt. 
 
![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)
 
Nach erfolgter Veröffentlichung wird das neon.exe File in `bin\Release\PublishOutput` generiert.

Nun müssen wir dieses Datenverzeichnis zu unserem Ausführungspfad hinzufügen. Der PATH ist die Systemvariable, die das Betriebssystem benützt, um erforderte ausführbare Programme von der Kommandozeile oder dem Terminal zu lokalisieren. 

**Windows 10 und Windows 8:**

Verwenden Sie die Suchfunktion um die Systemeigenschaften zu lokalisieren und zu öffnen. Navigieren sie zu den erweiterten Einstellungen. Wählen Sie Umgebungsvariablen aus. Suchen sie die PATH Umgebungsvariable in der Kategorie Systemvariablen und wählen sie aus. Klicken Sie Bearbeiten. Sollte die PATH Umgebungsvariable nicht existieren, dann klicken sie Neu. Definieren Sie in beiden Fällen die PATH Umgebungsvariable. Klicken Sie OK und schließen Sie alle Fenster mittels OK.

**Windows 7:**

Rechtsklicken Sie das Computer Icon. Wählen Sie Eigenschaften in dem Kontextmenü aus. Klicken Sie erweiterte Eigenschaften. Klicken Sie Umgebungsvariablen. Suchen sie die PATH Umgebungsvariable in der Kategorie Systemvariablen und wählen sie aus. Klicken Sie Bearbeiten. Sollte die PATH Umgebungsvariable nicht existieren, dann klicken Sie Neu. Definieren Sie in beiden Fällen die PATH Umgebungsvariable. Klicken Sie OK und schließen Sie alle Fenster mittels OK. 
 
![edit environmental variables](/assets/edit_environmental_variables.png)

Starten Sie die Kommandozeile oder PowerShell und geben neon.exe ein. Wenn keine Fehlermeldung erscheint und die Version Nummer angezeigt wird, dann war die Konfiguration der Umgebungsvariable erfolgreich. 

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)
 
Hinweis: Unter Windows 7 SP1 könnte die Fehlermeldung „Unhandled Exception: System.DllNotFoundException: Unable to load DLL ‚api-ms-core-console-l2-1-0-dll‘: The specified module could not be found“ erscheinen. Die benötigte api-ms-core-console-l2-1-0-dll Datei gibt es nur unter Windows 8 und späteren Versionen. Mittels Download eines api-ms-core-console-l2-1-0-dll Files und Kopieren in C:\Windows\System32 kann diese Fehlermeldung behoben werden. 

## Projekt erstellen

Nach erfolgter Installation können Sie ein neues NeoContract Projekt in Visual Studio 2017 erstellen.
 
![new smart contract project](/assets/new_smart_contract_project.png)

Bei Erstellung eines neuen Projekts wird automatisch ein C# File kreiert. Es ist die standardmäßige Objektklasse von FuntionCode, wie im Folgenden demonstriert wird:

![smart contract function code](/assets/smart_contract_function_code.png)
 
## Kompilierung eines Projekts

Nun ist alles bereits für die Hinzufügung der Entry Method, die den Smart Contract definiert:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```
 
Nachdem die Kompilierung erfolgreich war, wird im bin/Debug Verzeichnis SmartContract1.avm angezeigt, was das generierte Neo Smart Contract File darstellt. 

![compile smart contract](/assets/compile_smart_contract.png)
 
Da die Konfiguration des Neo Smart Contract Entwicklungsumfeldes nun abgeschlossen ist, öffnen Sie nun bitte das [NEO Smart Contract Tutorial](https://github.com/neo-project/docs/blob/master/en-us/sc/tutorial.md) 
 


