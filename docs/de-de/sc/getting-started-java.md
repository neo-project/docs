
### Wie man Java verwendet, um einen NEO Smart Contract zu schreiben

Smart Contracts werden in high-level Programmiersprachen wie Java, C#,  Python, Kotlin (usw...) geschrieben und in AVM (Neo´s Virtual Machine Bytecode) kompiliert, damit sie im NEO Netzwerk lauffähig sind. 

Zum jetzigen Stand empfehlen wir C# für die Entwicklung von Smart Contracts einzusetzen. Der Java Compiler befindet sich momentan immer noch in der Entwicklung, bis jetzt kann die derzeitige Version (Neoj) mit Basis Methoden umgehen. 

Dieser Abschnitt enthält ein Tutorial, das Sie bei der Konfiguration des Java Development Enviroment für NEO Smart Contracts unterstützt und Ihnen eine Vorstellung gibt, wie ein Smart Contract Project erstellt und kompiliert werden kann. 

Notizen: Der Prozess enthält folgende Schritte:
1. Schreiben Sie Java code (.java) für Klassen, die FunctionCode oder VerificationCode der Neo Framework Library (JAR) enthalten
2. Benutzen Sie den normalen Java Compiler, um den Code in Java Bytecode (.class) zu kompilieren
3. Konfigurieren Sie den Neoj (C#) Compiler, der den JVM Code in AVM Code (neoj.exe in Windows) konvertiert
4. Benutzen Sie Neoj, um dein .class file (.avm) zu kompilieren
5. Laden Sie die Neo Node GUI herunter, damit Sie sich mit dem Neo Testnet Network verbinden können 
6. Benutzen Sie Ihr .avm Script, um den Smart Contract im Netzwerk zu veröffentlichen
7. Rufen Sie Ihr .avm Script auf, um Ihren Smart Contract auszuführen

### Ausführliche Anleitung

## Werkzeuge

Der beste Weg, um all diese Schritte umzusetzen, ist es die folgenden benötigten Werkzeuge herunterzuladen und zu kompilieren:

1. Herunterladen von Neo´s Node GUI. Im Moment wird empfohlen die BETA developer GUI einzusetzen, da diese hilfreiche Extras zum debugging enthält. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Standardmäßig ist die GUI für das Testnet konfiguriert. Dieses wird nach dem Start synchronisiert, was mehrere Stunden dauern kann.     
2. Herunterladen von Neo Framework Library JAR. Die neuste Version befindet sich hier: [Antshares.SmartContract.Framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)   
3. Laden Sie eine IDE für Java (Optional aber Empfohlen), wie z.B. IntelliJ oder Eclipse herunter.       
4. Laden Sie eine IDE für C# herunter: Im Moment muss der Neoj Compiler noch manuell erstellt werden, da es sich noch nicht um einen veröffentlichten Release handelt. Empfohlen wird Visual Studio 2017 da es kostenlos ist.


## Entwickler Werkzeuge

### 1. Visual Studio 2017

Wenn Sie bereits Visual Studio 2017 & .NET Cross-Plattform Development auf Ihrem Computer installiert haben, können Sie diese Anleitung überspringen. 


Downloaden und installieren: 

[Visual Studio Download Addresse](https://www.visualstudio.com/products/visual-studio-community-vs)

Der Installationsprozess ist sehr einfach, folgen Sie den Installationsanweisungen Schritt-für-Schritt, dabei sollte darauf geachtet werden, dass die Checkbox bei `.NET Core cross-platform development` ausgewählt ist, da sich ansonsten das Neo-VM Project im Schritt #3 nicht öffnen lässt. 
Die Installation braucht zwischen zehn Minuten und einer Stunde. 

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. Neo-Compiler

Installations- und Konfigurationsschritte: 

Laden Sie das [neo-compiler](https://github.com/neo-project/neo-compiler) Project auf Github herunter, öffnen Sie das Projekt mit Visual Studio 2017, veröffentlichen Sie das Neoj Project.

Veröffentlichen Sie den Neoj Compiler (welcher Java Bytecode in AVM Bytecode konvertiert)

![publish NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

Nachdem die Veröffentlichung erfolgreich war, wird eine Neoj.exe Datei in `bin\Release\PublishOutput` erzeugt.

Nun müssen Sie dieses Verzeichnis in Ihren Ausführungspfad einfügen. Der Pfad ist die Systemvariable, die unser Betriebssystem benutzt, um benötigte ausführbare Dateien in der Command Line oder dem Terminal Window zu finden. 

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


Führen Sie nun die Commandline oder die PowerShell aus und öffnen Sie die Neoj.exe. Wenn es keinen Fehler gibt und die Ausgabe die Versionsnummer anzeigt, ist die Systemvariablen Konfiguration erfolgreich abgeschlossen. 

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


Notiz: Windows 7 SP1 Benutzer bekommen eventuell einen Fehler angezeigt "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. Diesen Fehler können Sie durch kopieren der 'api-ms-win-core-console-l2-1-0.dll' in das Verzeichnis C.\Windows\System32 beheben.


## Erstellen des Projektes

Wenn die oben genannte Installation fertig ist, können Sie damit starten, ein Java Projekt mit bspw. Eclipse oder IntelliJ
zu erstellen.                                       

Sie müssen auch noch das AntShares.SmartContract.Framework.jar (das ist das neo compiler project) als eine externe Library hinzufügen.


## Kompilieren des Projektes

Alles ist nun soweit, um die Entry Methode die die Smart Contracts definiert hinzuzufügen. 

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

Erstellen Sie das Projekt, welches Ihnen als Ausgabe `HelloWorld.class` in Ihren Ausgabeordner erstellt. 

Benutzen Sie dann die Neoj in der cmd.exe und geben Sie folgenden Befehl ein: 
> neoj.exe HelloWorld.class

Wenn der Befehl erfolgreich ausgeführt wurde, wird die Datei HelloWorld.avm erzeugt. Diese können Sie nun als Smart Contract Bytecode verwenden. 

Für weitere Informationen und Beispiele klicken Sie hier: [Java Examples](https://github.com/neo-project/examples-java)


## Ausführen von Smart Contracts


Wenn Sie bereit sind Ihren Smart Contract auszuführen, folgen Sie diesem Link: [Deploy a lock contract](http://docs.neo.org/en-us/sc/tutorial/Lock2.html) Die Anleitung ist dieselbe, egal für welche Programmiersprache Sie sich entschieden haben. 
