# Come usare C# per scrivere uno smart contract NEO per VS2015

Attualmente raccomandiamo C# per lo sviluppo di smart contract (anche se supportiamo o pianifichiamo di supportare Java, Kotlin, Go, C/C + +, Python, JavaScript e altri linguaggi di programmazione)

Questa sezione contiene un breve tutorial che ti guida nella configurazione dell'ambiente di sviluppo in C# per gli smart contract NEO, inoltre ti da un'idea su come creare un progetto smart contract e su come compilarlo.

## Strumenti di sviluppo

### 1. Visual Studio 2015

Metodo di download e di installazione:

Se hai già installato Visual Studio 2015 (qualsiasi versione) sul tuo computer, puoi saltare questa sezione.

Visual Studio 2015 è stato rimosso dalla Home del sito web, ma può essere scaricato.

Aprire la [pagina di download della versione precedente di Visual Studio](https://www.visualstudio.com/en/vans/vs/older-downloads/), cliccare `free to join`

   ![](assets/install_core_cross_platform_development_toolset.jpg)

Utilizzare il proprio account di accesso Microsoft, inserire Visual Studio Dev Essentials nel menu di navigazione e cliccare `download`

![image](assets/2017-05-10_13-47-10.jpg)

Nel box di ricerca, Inserire Visual Studio Community 2015 con Update 3, e quindi selezionare i risultati della ricerca in una buona versione, linguaggio, ecc., cliccare la parte sinistra del bottone `download`
![image](assets/2017-05-10_13-45-48.jpg)

Il metodo di installazione e il software generale sono fondamentalmente gli stessi, nel processo di installazione non si richiede di selezionare funzionalità aggiuntive, è possibile installare solo la parte principale di VS2015

![image](assets/2017-05-10_9-48-54.jpg)

### 2. NET Core strumenti Preview 2 per Visual Studio 2015

Metodo di download e di installazione:

Aprire la [pagina di download .Net Core](https://www.microsoft.com/net/download/core)

Scaricare e installare NET Core strumenti Preview 2 per Visual Studio 2015

![image](assets/2017-05-10_15-38-46.jpg)

### 3. NeoContractPlugin

Metodo di installazione:

Aprire Visual Studio 2015, aprire lo strumento, esteso e aggiornato, cliccare sulla parte sinistra per la ricerca online dell'installazione di NEO, Neo.SmartContract

![image](assets/2017-05-10_15-50-48.jpg)

### 4. Neo-compiler

Metodi di installazione e di configurazione:

Scaricare il progetto [neo-compiler](https://github.com/neo-project/neo-compiler) su Github, aprire la soluzione con Visual Studio 2015 e compilare il progetto neon,

![image](assets/2017-05-10_18-22-39.jpg)

Dopo il completamento della compilazione, il file neon.exe sarà generato in `bin\Debug\netcoreapp1.0\win10-x64`

   > [!Nota]
   > 
   > Se il tuo computer ha un sistema operativo a 32 bit, è necessario cambiare la sezione da win10-x64 a win10-x86 nel file project.json.

Ora occorre aggiungere un percorso, in modo che qualsiasi posizione possa accedere al programma. Per aggiungere il metodo del percorso, aprire proprietà del computer (o accedere al pannello di controllo, sistema e sicurezza, sistema), aprire le impostazioni di sistema avanzate, seleziona la scheda Avanzate, fare clic sul pulsante della variabile di ambiente, come mostrato in figura

![image](assets/2017-05-10_18-37-05.jpg)

Quindi selezionare Percorso e fare clic su `Modifica` 

![image](assets/2017-05-10_18-46-05.jpg)

Nella finestra pop-up, cliccare "Nuovo" input neon.exe dov'è la directory, cliccare `OK`, `OK`

![image](assets/2017-05-10_18-48-11.jpg)

Aggiungere il percorso, eseguire il test cmd, inserire neon.exe, se non ci sono errori e l'output è come il seguente, la configurazione della variabile di ambiente ha avuto un esito positivo

![image](assets/2017-05-10_18-52-10.jpg)

## Creare un progetto

Dopo il completamento della precedente installazione in 4 step, è possibile creare un progetto smart contract NEO in Visual Studio 2015.

![image](assets/2017-05-10_16-08-48.jpg)

Ciò genererà automaticamente un file C#, la classe predefinita ereditata dal FunctionCode, come mostrato dalla seguente immagine:

![image](assets/2017-05-10_16-25-09.jpg)

- Nota: Se appare la seguente immagine perchè il progetto in Neo.SmartContract.Framework non è stato ripristinato correttamente, è possibile ripristinare il pacchetto NuGet nel seguente modo (il processo senza rete)

![image](assets/2017-05-10_16-27-40.jpg)

Nel Solution Explorer, selezionare la soluzione, eseguire un clic destro, e selezionare `Restore NuGet Package`

![image](assets/2017-05-10_16-28-39.jpg)

Successivamente aprire il progetto di riferimento e cliccare `Neo.SmartContract.Framework`. Come fare se alcuni casi ancora non riescono a ripristinare il pacchetto Nuget? Si prega di riavviare Visual Studio 2015 o provare a generare direttamente una soluzione.

![image](assets/2017-05-10_16-31-55.jpg)

## Compilare il progetto

Ora tutto è pronto per aggiungere il metodo entry al progetto:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```
Dopo la compilazione con successo, vedrai il file `SmartContract1.avm` generato nella directory `bin/Debug`, il quale è il file generato dallo smart contract di NEO.

![image](/assets/compile_smart_contract.jpg)


!Nota:
   Se lo hai generato, e non vi è un output dei risultati della mappa, non importa, è possibile inserire direttamente il comando per compilare il file dll avm

   Aprire il prompt dei comandi, navigare fino alla directory Debug, inserire il seguente codice (SmartContract1.dll è il nome del dll generato dal precedente step).
```
	> C: \ ... \ bin \ Debug> `./neon SmartContract1.dll`
	>
	> Neo.Compiler.MSIL console app v1.6.4.2
	>   
	> Find function entry point: System.Void SmartContract1.Contract1 :: Main ()
	>   
	> Convert succ
	>   
 	> Write: SmartContract1.avm
 	>
 	> SUCC
  	>
	> C: \ ... \ bin \ Debug>
```

Adesso, una volta completata la configurazione dell'ambiente di sviluppo dello smart contract, si prega di fare riferimento a [Art Experiment Guide per Tomids](tutorial.md)
