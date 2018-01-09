---
typora-root-url: ..\..
---

### Come usare C# per scrivere uno smart contract NEO

Correntemente raccomandiamo C# per lo sviluppo degli smart contracts (anche se supportiamo o abbiamo pianificato di supportare Java, Kotlin, Go, C/C++, Python, JavaScript e altri linguaggi di programmazioni)

Questa sezione contiene un breve tutorial guida nella configurazione dell'ambiente di sviluppo in C# per gli smart contracts NEO e ti da un'idea su ​​come creare un progetto su uno smart contract e come compilarlo.

   > [!Nota]
   > Al momento, tutti i progetti sono stati aggiornati alla versione Visual Studio 2017, se vuoi usare visual Studio 2015 per creare contratti intelligenti fai riferimento a  [come usare C # per scrivere contratti intelligenti NEO per VS2015](getting-started-2015.md)

## Strumenti di sviluppo

### 1. Visual Studio 2017

Se hai già installato Visual Studio 2017 sul tuo computer e controllato per .NET Cross-Platform Development al momento dell'installazione, puoi saltare questa sezione.

Scarica e installa:

[Indirizzo di download di Visual Studio](https://www.visualstudio.com/products/visual-studio-community-vs)

Il processo di installazione è veramente semplice, segui le istruzioni prompts passo dopo passo, va notato che devi controllare l'installazione di `.NET Core cross-platform development`, altrimenti non sarai capace di aprire il progetto neo-vm nello step #3. L'installazione richiede da 10 minuti fino ad un'ora di tempo.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Metodo di installazione:

Apri Visual Studio 2017, apri Strumenti, clicca su Estensioni e Aggiornamenti, clicca sulla scheda Online sul lato sinistro della finestra, cerca neo nel box di ricerca nell'angolo in alto a destra della finestra, scarica NeoContractPlugin (questo passo richiede l'accesso a internet).

![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

Passi per l'installazione e la configurazione:

Scarica il progetto [neo-compiler](https://github.com/neo-project/neo-compiler) su Github, apri la soluzione con Visual Studio 2017, pubblica il progetto neon,

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

dopo che il rilascio avviene con successo, viene generato il file neon.exe in `bin\Release\PublishOutput`.

Adesso occorre aggiunge questa directoru al nostro percorso di esecuzione. La PATH è la variabile di sistema che il tuo sistema operativo usa per localizzare eseguibili richiesti dalla linea di comando o dalla finestra del Terminal.

**Windows 10 e Windows 8:**

  In Ricerca, cerca e seleziona : Sistema (Pannello di Controllo)
  Fai clic sul link Impostazioni Avanzate di Sistema. 
  Clicca su Variabili di Ambiente. Nella sezione Variabili di Sistema, trova la variabile di ambiente PATH e selezionala. Clicca Modifica. Se la variabile di ambiente non esiste, clicca su nuova.
  Nella finestra Modifica Variabile di Sistema (o Nuova Variabile di Sistema), specificare il valore della variabile PATH. Clicca OK. Chiudi tutte le finestre rimanenti cliccando su OK.

**Windows 7:**

  Dal Desktop, clic con il tasto destro sull'icona Computer. 
  Scegli Proprietà dal menu contestuale.
  Clicca sul link Impostazioni Avanzate di Sistema.
  Clicca Variabili Ambientali. Nella sezione Variabili di Sistema, trova la variabile di ambiente PATH e selezionala. Clicca su Modifica. Se la variabile di ambiente PATH non esiste, clicca su nuova.
  Nella finestra Modifica Variabile di Sistema (o Nuova Variabile di sistema), specifica il valore della variabile di ambiente PATH. Clicca OK. Chiudi tutte le finestre rimaste aperte cliccando su OK.

![edit environmental variables](/assets/edit_environmental_variables.png)

Adesso esegui il Command o la PowerShell, e inserisci neon.exe. Se non ci sono errori e il prodotto mostra il numero di versione (come mostrato) la configurazione della variabile di ambiente è avvenuta con successo

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


NOTA. Gli utenti di Windows 7 SP1 potrebbero incontrare un errore "Unhandled Exception: System.DllNotFoundException: unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". il file richiesto 'api-ms-win-core-console-l2-1-0.dll' è solo disponibile in Windows 8 o versioni successive. Questo errore può essere risolto ottenendo una copia di 'api-ms-win-core-console-l2-1-0.dll' e mettendola nella directory C:\Windows\System32.

## Crea Progetto

Dopo l'installazione della configurazione precedente, puoi creare un progetto NeoContract in Visual Studio 2017.

![new smart contract project](/assets/new_smart_contract_project.png)

Una volta creato un progetto, esso genererà automaticamente un file C#, la classe predefinita viene ereditata da SmartContract, come mostrato a seguire:

![smart contract function code](/assets/smart_contract_function_code.png)


## Compila il Progetto

Adesso è tutto quanto pronto èer aggiungere il nuovo metodo di inserimento che definisce lo smart contract:

```c#
public class Contract1: SmartContract
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

Dopo averlo compilato con successo, vedrai ` SmartContract1.avm` nella directory `bin/Debug`, il quale è il file generato come smart contract NEO.

![compile smart contract](assets/compile_smart_contract.png)


Adesso che hai completato la configurazione dell'ambiente di sviluppo NEO smart contract, per favore fai riferimento al [Tutorial NEO smart contract](tutorial.md)
