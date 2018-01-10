---
typora-root-url: ..\..
---

### Come usare Java per scrivere uno smart contract NEO

Gli smart contracts (contratti intelligenti) sono scritti in linguaggi di alto livello come Java, C#, Python, Kotlin (e altri...) e compilati in AVM (La macchina virtuale bytecode di NEO) in modo che possano essere eseguiti sulla rete Neo. 

Correntemente raccomandiamo l'uso di C# per sviluppare smart contracts. Il compilatore Java è ancora in fase di sviluppo ma la versione corrente (neoj) può gestire metodi basici.

Questa sezione contiene un tutorial che ti guida nella configurazione dell'ambiente di sviluppo Java per gli smart contracts di NEO e ti da un'idea di ​​come creare un progetto smart contract e come compilarlo.

Nota: Il processo implica i seguenti passaggi:
1. Scrivere codice Java (.java) per classi che estendono FunctionCode o VerificationCode che fanno parte della Framework Library di NEO (JAR)
2. Usare il compilatore normale di Java per compilare codice in Java bytecode (.class)
3. Costruire il compilatore di neoj che converte il codice JVM in codice AVM (neoj.exe su Windows)
4. Usare neoj per compilare il tuo file .class (.avm)
5. Scaricare la GUI Node di NEO per connettersi alla Testnet di NEO
6. Implementare il tuo script .avm per pubblicare lo smart contract sulla rete
7. Invocare il tuo script .avm per eseguire il tuo smart contract

### Istruzioni Dettagliate

## Strumenti

Il modo più efficiente di portare a termine questi passaggi è di scaricare e compilare tutti gli strumenti di cui avrai bisogno:

1. Scaricare il GUI Node di NEO. Al momento della scrittura, è raccomandato di usare la GUI di sviluppo BETA siccome ha delle funzionalità extra per il debugging utili. [CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer). Sarà configurata di default alla Testnet e dovrai aspettare (fino a poche ore) la sincronizzazione completa.
2. Scaricare il Framework Library JAR di NEO. L'ultima versione corrente si trova qui: [Antshares.SmartContract.Framework JAR](https://github.com/CityOfZion/neo-java-sdk/blob/master/target/org.neo.smartcontract.framework.jar)
3. Scaricare una IDE èer Java (opzionale ma raccomandato), come IntelliJ o Eclipse.
4. Scaricare una IDE per C# - correntemente il compilatore neoj deve essere costruito manualmente siccome non è nel formato di rilascio massiccio. E' raccomandato ottenere Visual Studio 2017 che è gratis.

## Strumenti di Sviluppo

### 1. Visual Studio 2017

Se hai già installato Visual Studio 2017 sul tuo computer e controllato per .NET Cross-Platform Development al momento dell'installazione, puoi saltare questa sezione.

Scaricare e Installare:

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

Il processo di installazione è davvero semplice, segui le istruzioni d'uso passo dopo passo, dovrebbe essere notato che hai bisogno di controllare l'installazione di `.NET Core cross-platform development`, altrimenti non sarai capace di aprire il progetto neo-vm nello step #3. l'installazione richiede da dieci minuti fino a un'ora.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. Compilatore NEO

Passaggi di installazione e configurazione:

Scaricare il progetto [compilatore neo](https://github.com/neo-project/neo-compiler) su Github, apri la soluzione con Visual Studio 2017, pubblica il progetto neoj,

Pubblicare il compilatore neoj (il quale converte Java bytecode in AVM bytecode).

![publish NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

Dopo il rilascio con successo, ilfile neoj.exe è generato in `bin\Release\PublishOutput`.

Non c'è bisogno di aggiungere questa directory al percorso di esecuzione. il PATH è la variabile di sistema che il tuo sistema operativo usa per collocare eseguibili dalla linea di comando o dalla finestra del Terminal.

**Windows 10 and Windows 8:**

  In Cerca, cercare e poi selezionare: Sistema (Pannello di Controllo)
  Cliccare il link impostazione di sistema avanzate.
  Cliccare Variabili D'ambiente. Nella sezione Variabili di Sistema, trovare la variabile d'ambiente PATH e selezionala. Cliccare Modifica. Se l'ambiente variabile PATH non esiste, cliccare su Nuova.
  Nella finestra variabile di sistema modificata (o nuova variabile di sistema), specificare il valore della variabile ambiente PATH. Cliccare OK. Chiudere tutte le rimanenti finestre cliccando su OK.

**Windows 7:**

  Dal desktop, Clic destro sull'icona del computer.
  Scegliere Proprietà dal menu.
  Cliccare su Impostazioni Avanzate di Sistema.
  Cliccare Variabili D'ambiente. Nella sezione Variabili di Sistema, trovare la Variabile D'ambiente PATH e selezionala. Cliccare Modifica. Se la Variabile D'ambiente PATH non esiste, cliccare su Nuova. 
  Nella finestra Modifica Variabile di Sistema (o Nuova Variabile di Sistema), specificare il valore della variabile d'ambiente PATH. Cliccare OK. Chiudere tutte le finestre aperte cliccando su OK.

![edit environmental variables](/assets/edit_environmental_variables.png)

Adesso eseguire il Command o PowerShell, e inserire neoj.exe. Se non vi sono errori e il prodotto mostra il numero di versione (come mostrato) la configurazione della variabile ambiente è avvenuta con successo

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)

NOTA: Gli utetni di Windows 7 SP1 potrebbero incontrarre un errore "Unhandled Exception: System.DllNotFoundException: incapace di caricare DLL 'api-ms-win-core-console-l2-1-0.dll': Il moodulo specificato non può essere trovato". I file richiesti 'api-ms-win-core-console-l2-1-0.dll' è solo disponibile in Windows 8 o versioni successive. Questo errore può essere risolto ottenendo una copia di 'api-ms-win-core-console-l2-1-0.dll' e mettendola nella directory C:\Windows\System32.

## Creare un Progetto

Dopo il completamento dell'installazione di sopra puoi creare progetti in Java (usando Eclipse o IntelliJ).

Hai bisogno di aggiungere AntShares.SmartContract.Framework.jar (il quale è  il compilatore del progetto neo) come library esterna.


## Compilare il Progetto

Adesso è tutto pronto per aggiungere il metodo entry che definisce lo smart contract:

```Java
import AntShares.SmartContract.Framework.FunctionCode;
import AntShares.SmartContract.Framework.Services.AntShares.Storage;

public class HelloWorld extends SmartContract{

    public static byte[] Main(String[] args){
        Storage.Put(Storage.getCurrentContext(), "Greeting to the World", "Hello World!");
        return Storage.Get(Storage.getCurrentContext(),"Greeting to the World");
    }

}
```

Costruisci il progetto che ti restituisce `HelloWorld.class` nella tua cartella.

Poi usando neoj, avvia cmd.exe ed esegui :
> neoj.exe HelloWorld.class

Se funziona, creerà HelloWorld.avm il quale puoi usare come smart contract bytecode.

Per maggiori informazioni e per vedere esempi Java funzionanti per favore fare riferimento a: [Esempi Java](https://github.com/neo-project/examples-java)

## Esegui un smart contracts

Una volta arrivati a questo stadio, le istruzioni sono uguali, non importa quale linguaggio hai usato per scrivere gli smart contracts 
Segui questo tutorial: [Esegui un lock contract](http://docs.neo.org/en-us/sc/tutorial/Lock2.html)
