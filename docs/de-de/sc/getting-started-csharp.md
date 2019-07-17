
### Wie man C# verwendet, um einen NEO Smart Contract zu schreiben

Zum jetzigen Stand empfehlen wir C# für die Entwicklung von Smart Contracts.(Auch wenn wir andere Programmiersprachen wie Java, Kotlin, Go, C/C++, Python, JavaScript und weitere Programmiersprachen unterstützen.)

Dieser Abschnitt enthält ein Tutorial, das Sie bei der Konfiguration des C# Development Enviroment für NEO Smart Contracts unterstützt und Ihnen eine Vorstellung gibt, wie ein Smart Contract Project erstellt und kompiliert werden kann. 

   > [!Notiz]
   > Alle Projekte wurden auf Visual Studio 2017 geupdatet. Wenn Sie Visual Studio 2015 verwenden wollen, um ihre Smart Contracts zu erstellen, lesen Sie bitte auf [dieses Tutorial](getting-started-2015.md)

## Entwickler Werkzeuge

### 1. Visual Studio 2017

Wenn Sie bereits Visual Studio 2017 & .NET Cross-Plattform Development auf Ihrem Computer installiert haben, können Sie diese Anleitung überspringen. 

Downloaden und installieren: 

[Visual Studio Download](https://www.visualstudio.com/products/visual-studio-community-vs)

Der Installationsprozess ist sehr einfach, folgen Sie den Installationsanweisungen Schritt-für-Schritt, dabei sollte darauf geachtet werden, dass die Checkbox bei `.NET Core cross-platform development` ausgewählt ist, da sich ansonsten das Neo-Vm Project im Schritt #3 nicht öffnen lässt. 
Die Installation braucht zwischen zehn Minuten und einer Stunde. 

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)


Installation:


Starten Sie Visual Studio 2017, öffnen Sie Werkzeuge, klicken Sie auf Erweiterungen und Updates, klicken Sie auf den Online Reiter auf der linken Seite, suchen Sie nach NEO in der Suchbox, laden Sie das NeoContractPlugin herunter (dieser Schritt benötigt eine Internetverbindung).

![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. Neo-Compiler

Installations- und Konfigurationsschritte: 

Laden Sie das [neo-compiler](https://github.com/neo-project/neo-compiler) Project auf Github herunter und öffnen Sie das Projekt mit Visual Studio 2017.

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)


Nachdem die Veröffentlichung erfolgreich war, wird eine Neoj.exe Datei in `bin\Release\PublishOutput` erzeugt.

Nun müssen Sie dieses Verzeichnis in Ihren Ausführungspfad einfügen. Der Pfad ist die Systemvariable, die unser Betriebssystem benutzt, um benötigte ausführbare Dateien in der Kommandozeile oder dem Terminalwindow zu finden. 

**Windows 10 und Windows 8:**

  In der Suchoption, suchen Sie nach System und wählen Sie es aus.
  Klicken Sie nun auf die erweiterten Systemeinstellungen.
  Klicken Sie nun auf Umgebungsvariablen. In dem Reiter Systemvariablen suchen Sie die Variable PATH und wählen Sie diese aus. Klicken Sie auf Bearbeiten. Wenn die PATH Variable nicht existiert, gehen Sie auf Neu.
  Im "Umgebungsvariable bearbeiten" Menü oder im "Neue Systemvariable" Fenster klicken Sie auf Bearbeiten, definieren Sie den Pfad der Variable. Klicken Sie auf OK und schließen Sie alle weiteren Fenster mit OK. 

**Windows 7:**

  Machen Sie einen Rechtsklick auf das Computer Symbol.
  Wählen Sie Eigenschaften aus dem Menü aus.
  Wählen Sie die erweiterten Systemeigenschaften aus. 
  Klicken Sie auf Umgebungsvariablen. In dem Reiter Systemvariablen, suchen Sie die Variable PATH und wählen Sie diese aus. Klicken Sie auf Bearbeiten. Wenn die PATH Variable nicht existiert, gehen Sie auf Neu.
  Im "Umgebungsvariable bearbeiten" Menü oder im "Neue Systemvariable" Fenster klicken Sie auf Bearbeiten, definieren Sie den Pfad der Variable. Klicken Sie auf OK und schließen Sie alle weiteren Fenster mit OK. 
  
![edit environmental variables](/assets/edit_environmental_variables.png)

Führen Sie nun die Commandline oder die PowerShell aus und öffnen Sie die neoj.exe. Wenn es keinen Fehler gibt und die Ausgabe die Versionsnummer anzeigt, ist die Systemvariablen Konfiguration erfolgreich abgeschlossen. 

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


Notiz: Windows 7 SP1 Benutzer bekommen eventuell einen Fehler angezeigt "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. Diesen Fehler können Sie durch kopieren der 'api-ms-win-core-console-l2-1-0.dll' in das Verzeichnis C.\Windows\System32 beheben.


## Erstellen des Projektes

Wenn die oben genannte Installation fertig ist, können Sie damit starten, ein NeoContract Project in Visual Studio 2017 zu erstellen. 

![new smart contract project](/assets/new_smart_contract_project.png)

Wenn Sie ein Projekt erstellt haben, wird automatisch eine C# Datei erzeugt. Das ist die vererbte Standardklasse des SmartContracts wie in folgendem Beispiel gezeigt.

![smart contract function code](/assets/smart_contract_function_code.png)



Nun können Sie die Entry Methode, die die Smart Contracts definiert, hinzufügen.


```c#
public class Contract1: SmartContract
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

Wenn der Befehl erfolgreich ausgeführt wurde, sehen Sie eine Datei namens `SmartContract1.avm` im `bin/Debug` Verzeichnis, diese Datei ist der generierte NEO Smart Contract.



Da Sie nun die Konfiguration des NEO Smart Contract Development Environment durchgeführt haben, bitten wir Sie für weitere Informationen folgendes Tutorial zu beachten.  [NEO Smart Contract Tutorial](tutorial.md)

