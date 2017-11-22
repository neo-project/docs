---
typora-root-url: ..\..
---

### Wie man Java verwendet um einen NEO smart contract zu schreiben

Smart contracts werden in höheren Programmiersprachen wie Java, C#,  Python, Kotlin (usw...) geschrieben und in AVM (Neo´s Virtual Machine bytecode) kompiliert damit Sie im NEO Netzwerk lauffähig sind. 

Zum jetzigen Stand empfehlen wir für die Entwicklung von Smart Contracts C# einzusetzen. Der Java compiler befindet sich momentan immer noch in der Entwicklung, bis jetzt kann die derzeitige Version (neoj) mit Basis Methoden umgehen. 

Dieser Abschnitt enthält ein Tutorial das dich bei der Konfiguration des Java development enviroment für NEO smart contracts unterstützt und dir eine Vorstellung gibt wie ein Smart contract project erstellt und kompiliert wird. 

Notizen: Der Prozess enthält folgende Schritte:
1. Schreibe Java code (.java) für Klassen die FunctionCode oder VerificationCode der Neo Framework Library (JAR) enthalten
2. Benutze den normalen Java compiler um den Code in Java bytecode (.class) zu kompilieren
3. Konfiguriere den neoj (C#) compiler der den JVM code in AVM code (neoj.exe in Windows) konvertiert
4. Benutze neoj um dein .class file (.avm) zu kompilieren
5. Lade dir die Neo Node GUI herunter um dich mit dem Neo Testnet Network zu verbinden 
6. Benutze dein .avm script um den smart contract im Netzwerk zu veröffentlichen
7. Rufe dein .avm script auf um deinen smart contract auszuführen

### Ausführliche Anleitung

## Werkzeuge

Der beste Weg um all diese Schritte umzusetzen ist es die folgenden benötigten Werkzeuge runterzuladen und zu kompilieren:

1.Herunterladen von Neo´s Node GUI. Im Moment wird empfohlen die BETA developer GUI einzusetzen da diese hilfreiche Extras zum debugging enthält. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Standardmäßig ist die GUI für das Testnet konfiguriert. Dieses wird nach dem Start synchronisiert was bis zu ein paar Stunden dauern kann.  
2.Herunterladen von Neo Framework Library JAR. Die neuste Version befindet sich hier:  [Antshares.SmartContract.Framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)
3.Lade eine IDE für Java (Optional aber Empfohlen), wie z.B. IntelliJ oder Eclipse herunter.
4.Lade dir eine IDE für C# herunter: Im Moment muss der neoj compiler noch manuell erstellt werden da es sich noch nicht um einen veröffentlichten Release handelt. Empfohlen wird Visual Studio 2017 da es kostenlos ist. 


## Entwickler Werkzeuge

### 1. Visual Studio 2017

Wenn du bereits Visual Studio 2017 & .NET Cross-Plattform Development auf deinem Computer installiert hast kannst du diese Anleitung überspringen. 


Download und installieren: 

[Visual Studio Download Addresse](https://www.visualstudio.com/products/visual-studio-community-vs)

Der Installations Prozess ist sehr einfach, folge den Installationsanweisungen Schritt-für-Schritt, dabei sollte darauf geachtet werden das die Checkbox bei `.NET Core cross-platform development` ausgewählt ist da ansonsten sich das neo-vm project im Schritt #3 nicht öffnen lässt. 
Die Installation braucht zwischen zehn Minuten und einer Stunde. 

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. neo-compiler

Installations und Konfigurationsschritte: 

Lade dir das [neo-compiler](https://github.com/neo-project/neo-compiler) project auf Github herunter, öffne das Project mit Visual Studio 2017, veröffentliche das neoj project, 

Veröffentliche den neoj compiler (welcher Java bytecode in AVM bytecode konvertiert)

![publish NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

Nachdem die Veröffentlichung erfolgreich war wird eine neoj.exe Datei in `bin\Release\PublishOutput` erzeugt.

Nun müssen wir dieses Verzeichnis in unseren Ausführungspfad einfügen. Der Pfad ist die System Variable die unser Betriebssystem benutzt um benötigte ausführbare Dateien in der command line oder dem Terminal window zu finden 

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


Führe nun die Commandline oder die PowerShell aus und öffne die neoj.exe. Wenn es keinen Fehler gibt und die Ausgabe die Versionsnummer anzeigt ist die Systemvariablen Konfiguration erfolgreich gewesen. 

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


Notiz: Windows 7 SP1 Benutzer bekommen eventuell einen Fehler angezeigt "Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". The required 'api-ms-win-core-console-l2-1-0.dll' file is only found in Windows 8 or later versions. Dieser Fehler kann durch kopieren der 'api-ms-win-core-console-l2-1-0.dll' in das Verzeichnis C.\Windows\System32 behoben werden.


## Erstelle ein Projekt

Wenn die oben genannte Installation fertig ist kannst du damit starten ein Java Projekt mit (z.B. mit Eclipse oder IntelliJ)
zu erstellen 
Du musst auch noch das AntShares.SmartContract.Framework.jar (das ist das neo compiler project) als eine externe library hinzufügen.


## Kompiliere das Projekt

Alles ist nun soweit um die entry methode die die smart contracts definiert hinzuzufügen. 

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

Erstelle das Projekt welches dir als Ausgabe `HelloWorld.class` in deinen Ausgabeordner erstellt. 

Benutze dann neoj in der cmd.exe und gib folgenden Befehl ein: 
> neoj.exe HelloWorld.class

Wenn der Befehl erfolgreich ausgeführt wurde wird die Datei HelloWorld.avm erzeugt. Dies kannst du nun als smart contract bytecode verwenden. 

Für weitere Informationen und Beispiele kannst du hier klicken: [Java Examples](https://github.com/neo-project/examples-java)

## Ausführen von smart contracts

Wenn du bereit bist folge diesem Link: [Deploy a lock contract](http://docs.neo.org/en-us/sc/tutorial/Lock2.html) Die Anleitung ist dieselbe egal für welche Programmiersprache du dich entschieden hast. 
