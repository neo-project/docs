---
typora-root-url: ..\..
---

### C# gebruiken om een NEO smart contract te schrijven

Op dit moment wordt C# aanbevolen voor het schrijven van smart contracts (hoewel ook Java, Kotlin, Go, C/C++, Python, JavaScript en andere programmeertalen ondersteund worden of zullen worden).

Deze pagina legt kort uit hoe de C# ontwikkelomgeving moet worden geconfigureerd voor NEO smart contracts en geeft een idee hoe een smart contract opgebouwd en gecompileerd kan worden.

> [!Note]
> Momenteel worden alle projecten uitgevoerd in de Visual Studio 2017 versie; zie voor het gebruiken van Visual Studio 2015 [deze link](getting-started-2015.md).

## Hulpmiddelen voor Ontwikkelaars

### 1. Visual Studio 2017

Wanneer Visual Studio 2017 al geïnstalleerd is en al nagegaan is of .NET Cross-Platform Development geïnstalleerd is, kan deze sectie worden overgeslagen. 

Download en installeer:

[Visual Studio download](https://www.visualstudio.com/products/visual-studio-community-vs)

Het installatieproces is simpel; volg de instructies in de installer stap voor stap. Het is van belang dat ook de installatie van `.NET Core Cross-Platform Development` aangevinkt dient te worden, aangezien het neo-vm project anders niet geopend kan worden in stap #3. De installatie duurt meestal tussen de 10 minuten - 1 uur.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Instructies voor installatie:

Open Visual Studio 2017, open Tools, klik op Extensions and Updates, klik op het tabblad Online aan de linkerkant van het venster, zoek naar 'NEO' in de zoekbalk in de rechterbovenhoek van het venster en download NeoContractPlugin (voor deze stap is internettoegang vereist).

![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

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

Wanneer de bovenstaande installatie en configuratie is gelukt, is het mogelijk om een NeoContract project in Visual Studio 2017 aan te maken.

![new smart contract project](/assets/new_smart_contract_project.png)

Als het project is aangemaakt, genereert het automatisch een C# bestand (de standaard klasse die past bij het SmartContract, zoals te zien is in de afbeelding hieronder).

![smart contract function code](/assets/smart_contract_function_code.png)

## Het Project Compileren

Het is nu mogelijk om de entry methode toe te voegen die smart contracts definiëert:

```c#
public class Contract1: SmartContract
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

Nadat deze gecompileerd is, zal `SmartContract.avm` in de `bin/Debug`-map verschijnen. Dit is het bestand dat wordt gegenereerd als het NEO smart contract.

![compile smart contract](/assets/compile_smart_contract.png)

Ga na het voltooien van de configuratie door naar de [NEO smart contract handleiding](tutorial.md).
