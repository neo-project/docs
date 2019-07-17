---
typora-root-url: ..\..
---

### Come usare C# per scrivere uno smart contract NEO

Attualmente raccomandiamo C# per lo sviluppo degli smart contract (anche se supportiamo o abbiamo pianificato di supportare Java, Kotlin, Go, C/C++, Python, JavaScript e altri linguaggi di programmazione)

Questa sezione contiene un breve tutorial che vi guida nella configurazione dell'ambiente di sviluppo in C# per gli smart contract NEO, inoltre da un'idea su ​​come creare un progetto smart contract e su come compilarlo.

   > [!Nota]
   > Al momento, tutti i progetti sono stati aggiornati alla versione Visual Studio 2017, se vuoi usare visual Studio 2015 per creare smart contract fai riferimento a [come usare C# per scrivere smart contract NEO per VS2015](getting-started-2015.md)

## Strumenti di sviluppo

### 1. Visual Studio 2017

Se hai già installato Visual Studio 2017 sul tuo computer e spuntato la casella .NET Cross-Platform Development al momento dell'installazione, puoi saltare questa sezione.

Scaricare e installare:

[Indirizzo di download di Visual Studio](https://www.visualstudio.com/products/visual-studio-community-vs)

Il processo di installazione è davvero semplice, basta seguire le istruzioni suggerite passo dopo passo, va notato che é necessario controllare l'installazione di `.NET Core cross-platform development`, altrimenti non sará possibile aprire il progetto neo-vm nello step #3. L'installazione richiede da 10 minuti fino a un'ora di tempo.

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin

Metodo di installazione:

Aprire Visual Studio 2017, aprire Tools, cliccare su Estensioni e Aggiornamenti, cliccare sulla scheda Online sul lato sinistro della finestra, cercare neo nel box di ricerca nell'angolo in alto a destra della finestra, scaricare NeoContractPlugin (questo passo richiede l'accesso a internet).

![download e installazione del plugin NEO smart contract](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

Passaggi per l'installazione e la configurazione:

Scaricare il progetto [neo-compiler](https://github.com/neo-project/neo-compiler) su Github, aprire la soluzione con Visual Studio 2017 e pubblicare il progetto neon

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

> [!Nota]
>
> Durante il processo di pubblicazione di neon, se il file neon.dll non può essere copiato, vi è la possibilità di copiare manualmente il file con lo stesso nome dalla cartella di livello superiore. 

A rilascio avvenuto con successo, il file neon.exe viene generato in `bin\Release\PublishOutput`.

Adesso occorre aggiungere questa directory al nostro percorso di esecuzione. La PATH è la variabile di sistema che il tuo sistema operativo usa per localizzare eseguibili richiesti dalla linea di comando o dalla finestra del Terminal.

**Windows 10 e Windows 8:**

  In Ricerca, cercare e poi selezionare: Sistema (Pannello di Controllo)
  Cliccare sul link Impostazioni Avanzate di Sistema. 
  Cliccare su Variabili di Ambiente. Nella sezione Variabili di Sistema, trovare la variabile di ambiente PATH e selezionarla. Cliccare Modifica. Se la variabile di ambiente non esiste, cliccare su Nuova.
  Nella finestra Modifica Variabile di Sistema (o Nuova Variabile di Sistema), specificare il valore della variabile PATH. Cliccare OK. Chiudere tutte le finestre rimanenti cliccando su OK.

**Windows 7:**

  Dal Desktop, cliccare con il tasto destro sull'icona Computer. 
  Scegliere Proprietà dal menu contestuale.
  Cliccare sul link Impostazioni Avanzate di Sistema.
  Cliccare Variabili Ambientali. Nella sezione Variabili di Sistema, trovare la variabile di ambiente PATH e selezionarla. Cliccare su Modifica. Se la variabile di ambiente PATH non esiste, cliccare su nuova.
  Nella finestra Modifica Variabile di Sistema (o Nuova Variabile di Sistema), specificare il valore della variabile di ambiente PATH. Cliccare OK. Chiudere tutte le finestre rimaste aperte cliccando su OK.

![edit environmental variables](/assets/edit_environmental_variables.png)

Adesso eseguire il Command o la PowerShell, e inserire neon.exe. Se non ci sono errori e il prodotto mostra il numero di versione (come mostrato), la configurazione della variabile ambiente è avvenuta con successo

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


NOTA. Gli utenti di Windows 7 SP1 potrebbero incorrere all'errore "Unhandled Exception: System.DllNotFoundException: unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found". il file richiesto 'api-ms-win-core-console-l2-1-0.dll' è solo disponibile in Windows 8 o versioni successive. Questo errore può essere risolto ottenendo una copia di 'api-ms-win-core-console-l2-1-0.dll' e spostandolo nella directory C:\Windows\System32.

## Creare un Progetto

Dopo l'installazione della configurazione precedente, é possibile creare un progetto NeoContract in Visual Studio 2017.

![new smart contract project](/assets/new_smart_contract_project.png)

Una volta creato un progetto, esso genererà automaticamente un file C#, la classe predefinita viene ereditata dallo SmartContract, come mostrato di seguito:

![smart contract function code](/assets/smart_contract_function_code.png)


## Compilare il Progetto

Adesso è tutto quanto pronto per aggiungere il nuovo metodo entry che definisce lo smart contract:

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


Adesso che hai completato la configurazione dell'ambiente di sviluppo NEO smart contract, si prega di fare riferimento al [Tutorial NEO smart contract](tutorial.md)
