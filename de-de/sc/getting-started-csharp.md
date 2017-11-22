---
typora-root-url: ..\..
---

### Wie man C# verwendet um einen NEO smart contract zu schreiben

Zum jetzigen Stand empfehlen wir C# für die Entwicklung von Smart Contracts einzusetzen.(Auch wenn wir andere Programmiersprachen wie Java, Kotlin, Go, C/C++, Python, JavaScript und weitere Programmiersprachen unterstützen)

Dieser Abschnitt enthält ein Tutorial das Sie bei der Konfiguration des C# development enviroment für NEO smart contracts unterstützt und Ihnen eine Vorstellung gibt wie ein Smart contract project erstellt und kompiliert werden kann. 

   > [!Notiz]
   > Alle Projekte wurden auf Visual Studio 2017 upgedatet, wenn Sie Visual Studio 2015 verweden wollen um ihre intelligent contracts zu erstellen beziehen Sie sich bitte auf [how to use C # to write NEOs intelligent contract for VS2015](getting-started-2015.md)

## Entwickler Werkzeuge

### 1. Visual Studio 2017

Wenn Sie bereits Visual Studio 2017 & .NET Cross-Plattform Development auf Ihrem Computer installiert haben können Sie diese Anleitung überspringen. 

Downloaden und installieren: 

[Visual Studio Download Addresse](https://www.visualstudio.com/products/visual-studio-community-vs)

Der installations Prozess ist sehr einfach, folgen Sie den Installationsanweisungen Schritt-für-Schritt, dabei sollte darauf geachtet werden das die Checkbox bei `.NET Core cross-platform development` ausgewählt ist da ansonsten sich das neo-vm project im Schritt #3 nicht öffnen lässt. 
Die Installation braucht zwischen zehn Minuten und einer Stunde. 

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Installations Methode:

Starten Sie Visual Studio 2017, öffnen Sie Werkzeuge, clicken Sie auf Erweiterungen und Updates, klicken Sie auf den Online Reiter auf der linken Seite, suchen Sie noch NEO in der Suchbox, laden Sie das NeoContractPlugin herunter (dieser Schritt benötigt eine Internetverbindung).

![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

Installations und Konfigurationsschritte: 

Laden Sie das [neo-compiler](https://github.com/neo-project/neo-compiler) project auf Github herunter, öffnen Sie das Project mit Visual Studio 2017, veröffentlichen Sie das neoj project, 

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)


Nachdem die Veröffentlichung erfolgreich war wird eine neoj.exe Datei in `bin\Release\PublishOutput` erzeugt.

Nun müssen Sie dieses Verzeichnis in Ihren Ausführungspfad einfügen. Der Pfad ist die System Variable die unser Betriebssystem benutzt um benötigte ausführbare Dateien in der command line oder dem Terminal window zu finden 

**Windows 10 und Windows 8:**

  In der Suche, suche nach System und wähle es aus.
  Klicke auf die erweiterten Systemeinstellungen.
  Klicke auf Umgebungsvariablen. In dem Reiter Systemvariablen, suche die Variable PATH und wähle Sie aus. Klicke auf Bearbeiten. Wenn die PATH Variable nicht existiert gehe auf Neu.
  Im Umgebungsvariable bearbeiten oder Neue System Variable Fenster klicke auf Bearbeiten, definiere den Pfad der variable. Klick auf OK und schließe alle weiteren Fenster mit OK. 

**Windows 7:**

  Mache einen Rechtsklick auf das Computer Symbol.
  Wähle Eigenschaften aus dem Menü aus.
  Wähle die erweiterten Systemeigenschaften aus. 
  Klicke auf Umgebungsvariablen. In dem Reiter Systemvariablen, suche die Variable PATH und wähle Sie aus. Klicke auf Bearbeiten. Wenn die PATH Variable nicht existiert gehe auf Neu.
  Im Umgebungsvariable bearbeiten oder Neue System Variable Fenster Klick auf Bearbeiten, definiere den Pfad der variable. Klick auf OK und schließe alle weiteren Fenster mit OK. 
![edit environmental variables](/assets/edit_environmental_variables.png)

Führen Sie nun die Commandline oder die PowerShell aus und öffnen Sie die neoj.exe. Wenn es keinen Fehler gibt und die Ausgabe die Versionsnummer anzeigt ist die Systemvariablen Konfiguration erfolgreich abgeschlossen. 

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


Notiz: Windows 7 SP1 Benutzer bekommen eventuell einen Fehler angezeigt "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. Diesen Fehler können Sie durch kopieren der 'api-ms-win-core-console-l2-1-0.dll' in das Verzeichnis C.\Windows\System32 beheben.


## Erstellen des Projektes

Wenn die oben genannte Installation fertig ist können Sie damit starten ein NeoContract project in Visual Studio 2017 zu erstellen. 

![new smart contract project](/assets/new_smart_contract_project.png)

Wenn Sie ein Projekt erstellt haben wird automatisch eine C# Datei erzeugt, das ist die vererbte Standardklasse des SmartContracts wie in folgendem Beispiel gezeigt.

![smart contract function code](/assets/smart_contract_function_code.png)


## Kompilieren des Projektes

Alles ist nun soweit um die entry methode die die smart contracts definiert hinzuzufügen.

```c#
public class Contract1: SmartContract
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

Wenn der Befehl erfolgreich ausgeführt wurde, sehen Sie eine Datei namens ` SmartContract1.avm` im `bin/Debug` Verzeichnis, diese Datei ist der generierte NEO smart contract.

![compile smart contract](assets/compile_smart_contract.png)


Da Sie nun die Konfiguration des NEO smart contract development environment durchgeführt haben, bitten wir Sie für weitere Informationen folgendes Tutorial zu beachten.  [NEO smart contract tutorial](tutorial.md)
