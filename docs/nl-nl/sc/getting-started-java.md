---
typora-root-url: ..\..
---

### Een NEO smart contract schrijven in Java

Smart contracts worden geschreven in geavanceerde programmeertalen zoals Java, C#, Python en Kotlin en vervolgens gecompileerd tot AVM (de bytecode van NeoVM), zodat ze kunnen werken op het NEO-netwerk.

Momenteel wordt C# aanbevolen om smart contracts te schrijven. De Java-compiler is nog in ontwikkeling, maar de huidige versie (neoj) kan basale methodes aan.

Deze pagina legt uit hoe de Java-ontwikkelomgeving opgezet kan worden om NEO smart contracts te schrijven en demonstreert hoe een smart contract project aangemaakt en gecompileerd kan worden.

Het proces omvat de volgende stappen:
1. Java code schrijven (.java) voor classes die FunctionCode of VerificationCode uitbreiden als onderdeel van de Neo Framework Library (JAR)
2. De normale Java compiler gebruiken om de code te compileren tot Java bytecode (.class)
3. Het bouwen van de neoj (C#) compiler die JVM-code omzet in AVM-code (neoj.exe op Windows)
4. neoj gebruiken om het .class bestand te compileren (.avm)
5. Neo's Node GUI downloaden om te verbinden met het NEO TestNet
6. Het inzetten van het .avm script om het smart contract op het netwerk te plaatsen
7. Het .avm script oproepen om het smart contract uit te voeren


### Gedetailleerde Instructies

## Benodigdheden

De meest effectieve manier om deze stappen te doorlopen is door alle benodigdheden van tevoren te downloaden:
1. Download de NEO Node GUI. Het wordt momenteel aanbevolen om de BETA ontwikkelaars-GUI te gebruiken, aangezien deze enkele debug-functies heeft die nuttig kunnen zijn. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Deze staat standaard ingesteld op het TestNet; het kan tot enkele uren duren voordat het gesynchroniseerd is.
2. Download de Neo Framework Library JAR. [Meest recente versie](https://github.com/neo-project/neo-compiler/blob/master/neoj/AntShares.SmartContract.Framework.jar)
3. Download een IDE voor Java (optionele stap, wordt wel aangeraden), zoals IntelliJ of Eclipse.
4. Download een IDE voor C#. Momenteel moet de neoj-compiler handmatig gebouwd worden, aangezien deze nog niet een standaardversie heeft. Het wordt aanbevolen om Visual Studio 2017 te gebruiken (gratis).

## Development Tools

### 1. Visual Studio 2017

Wanneer Visual Studio 2017 al geïnstalleerd is en al nagegaan is of .NET Cross-Platform Development geïnstalleerd is, kan deze sectie worden overgeslagen. 

Download en installeer:

[Visual Studio download](https://www.visualstudio.com/products/visual-studio-community-vs)

Het installatieproces is simpel; volg de instructies in de installer stap voor stap. Het is van belang dat ook de installatie van `.NET Core Cross-Platform Development` aangevinkt dient te worden, aangezien het neo-vm project anders niet geopend kan worden in stap #3. De installatie duurt meestal tussen de 10 minuten - 1 uur.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. neo-compiler

Instructies voor installatie en configuratie:

Download het [neo-compiler](https://github.com/neo-project/neo-compiler)-project op GitHub, open deze met Visual Studio 2017 en klik op Publish:

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

Als deze succesvol is vrijgegeven, is neon.exe aangemaakt in de map `bin\Release\PublishOutput`.

Nu moet deze map worden toegevoegd aan het path dat wordt uitgevoerd. Het PATH is de systeemvariabele dat door het OS wordt gebruikt om de benodigde executables vanuit de command line of Terminal.

**Windows 10 en Windows 8:**
  
- Klik op Zoeken, zoek naar 'geavanceerde systeeminstellingen weergeven' en open deze (Engels: advanced system settings).
- Klik op Omgevingsvariabelen (Environment Variables). Zoek in de sectie systeemvariabelen naar de PATH variabele en selecteer deze; klik op Bewerken (Edit). Als de PATH omgevingsvariabele niet bestaat, klik dan op Nieuw.
- Geef in het Omgevingsvariabele bewerken (of nieuw-) -venster de waarde voor de PATH omgevingsvariabele op en klik op OK. Sluit alle vensters door op OK te drukken.
  
**Windows 7:**

- Klik met de rechter muisknop op het computer-logo vanaf het bureaublad.
- Klik op eigenschappen (Properties).
- Klik op geavanceerde systeeminstellingen (Advanced system settings).
- Klik op omgevingsvariabelen (Environment Variables). Zoek in de sectie systeemvariabelen naar de PATH variabele en selecteer deze; klik op Bewerken (Edit). Als de PATH omgevingsvariabele niet bestaat, klik dan op Nieuw.
- Geef in het Omgevingsvariabele bewerken (of nieuw-) -venster de waarde voor de PATH omgevingsvariabele op en klik op OK. Sluit alle vensters door op OK te drukken.

![edit environmental variables](/assets/edit_environmental_variables.png)

Voer nu Command of PowerShell uit en voer 'neon.exe' in (zonder aanhalingstekens). Als er geen foutmelding verschijnt en de output het versienummer toont (zoals hieronder), is de omgevingsvariabele succesvol geconfigureerd.

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)

> [!Note]
> Windows 7 SP1-gebruikers kunnen het volgende foutmelding ontvangen: *"Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found"*. Het bestand (`api-ms-win-core-console-12-1-0.dll`) bestaat alleen op Windows 8 of latere versies. Deze foutmelding kan worden opgelost door een kopie van `api-ms-win-core-console-12-1-0.dll` te bemachtigen en deze in de map C:\Windows\System32 te plaatsen.

## Project Aanmaken

Nadat bovenstaande installatie voltooid is, kan je een Java-project aanmaken (bijvoorbeeld m.b.v. Eclipse of IntelliJ).

Antshares.SmartContract.Framework.jar (het neo-compiler project) moet hierbij worden toegevoegd als externe library.


## Project Compileren

Nu kan de entry methode worden toegevoegd die het smart contract definiëer:

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

Bij het aanmaken van het project wordt `HelloWorld.class` aangemaakt in de out-folder.

Gebruik hierna neoj, voer cmd.exe uit en doe:
> neoj.exe HelloWorld.class

Als dit lukt, maakt het HelloWorld.avm aan, wat nu te gebruiken is als smart contract bytecode.

Kijk voor meer informatie en werkende Java-voorbeelden [hier](https://github.com/neo-project/examples-java).

Vanaf deze stap zijn de instructies voor elke programmeertaal gelijk: [Een lock contract deployen](https://docs.neo.org/nl-nl/sc/tutorial/Lock2.html).
