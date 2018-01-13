# Come usare C# per scrivere uno smart contract NEO per VS2015

Correntemente raccomandiamo C# per lo sviluppo di smart contract (anche se supportiamo o pianifichiamo di supportare Java, Kotlin, Go, C/C + +, Python, JavaScript e altri linguaggi di programmazione)

Questa sezione contiene un breve tutorial che ti guida nella configurazione dell'ambiente di sviluppo in C# per gli smart contract NEO e inoltre da un'idea su come creare un progetto smart contract e come compilarlo.

## Strumenti di sviluppo

### 1. Visual Studio 2015

Metodo di scaricamente e installazione:

Se hai già installato Visual Studio 2015 (qualsiasi versione) sul tuo computer, puoi saltare questa sezione.

Visual Studio 2015 è stato rimosso dalla Home del sito web, ma può essere scaricato.

Apri la [pagina di download della versione precedente di Visual Studio](https://www.visualstudio.com/en/vans/vs/older-downloads/), cliccare `free to join`

   ![](assets/install_core_cross_platform_development_toolset.jpg)

Utilizzare il proprio account di accesso Microsoft, inserire Visual Studio Dev Essentials nel menu di navigazione, cliccare `download`

![image](assets/2017-05-10_13-47-10.jpg)

Nel box di ricerca, Inserire Visual Studio Community 2015 con Update 3, e quindi selezionare i risultati della ricerca in una buona versione, linguaggio, etc., cliccare la parte sinistra del bottone `download`
![image](assets/2017-05-10_13-45-48.jpg)

Il metodo di installazione e il software generale sono fondamentalmente gli stessi, il processo di installazione senza la necessità di selezionare funzionalità aggiuntive, è possibile installare solo la parte principale di VS2015

![image](assets/2017-05-10_9-48-54.jpg)

### 2. NET Core strumenti Preview 2 per Visual Studio 2015

Metodo di scaricamente e installazione:

Aprire la [pagina di download .Net Core](https://www.microsoft.com/net/download/core)

Scaricare e installare NET Core strumenti Preview 2 per Visual Studio 2015

![image](assets/2017-05-10_15-38-46.jpg)

### 3. NeoContractPlugin

Metodo di installazione:

Aprire Visual Studio 2015, aprire lo strumento, esteso e aggiornato, cliccare sulla sinistra per la ricerca online dell'installazione di NEO, Neo.SmartContract

![image](assets/2017-05-10_15-50-48.jpg)

### 4. Neo-compiler

Metodi di installazione e configurazione:

Scaricare il progetto [neo-compiler](https://github.com/neo-project/neo-compiler) su Github, aprire la soluzione con Visual Studio 2015, compilare il progetto neon,

![image](assets/2017-05-10_18-22-39.jpg)

Dopo il completamento della compilazione, il file neon.exe sarà generato in `bin\Debug\netcoreapp1.0\win10-x64`
   > [!Nota]
   > 
   > Se il tuo computer ha un sistema operativo a 32 bit, devi cambiare win10-x64 nel file project.json a win10-x86

Ora devi aggiungere un percorso, in modo che qualsiasi posizione possa accedere al programma. Per aggiungere il metodo del percorso, apri le proprietà del computer (o accendere il pannello di controllo, sistema e sicurezza, sistema), apri le impostazioni di sistema avanzate, seleziona la scheda Avanzate, fare clic sul pulsante della variabile di ambiente, come mostrato in figura

![image](assets/2017-05-10_18-37-05.jpg)

Quindi selezionare Percorso e fare clic su `Modifica '

![image](assets/2017-05-10_18-46-05.jpg)

Nella finestra pop-up, cliccare "Nuovo" input neon.exe dove la directory, cliccare `OK`, `OK`

![image](assets/2017-05-10_18-48-11.jpg)

Aggiungere il percorso, eseguire il test cmd, inserire neon.exe, nessun errore, l'output come mostrato nella figura che la configurazione della variabile di ambiente ha esito positivo

![image](assets/2017-05-10_18-52-10.jpg)

## Creare un progetto

After the above four-step installation is successful, you can create an NEO smart contract project in Visual Studio 2015.

![image](assets/2017-05-10_16-08-48.jpg)

This will automatically generate a C# file, the default class inherited from the FunctionCode, as shown in the following:

![image](assets/2017-05-10_16-25-09.jpg)

- Note: If the following image appears, because the project in the Neo.SmartContract.Framework did not successfully restore, you can restore the NuGet package in the following way (the process without networking)

![image](assets/2017-05-10_16-27-40.jpg)

In the Solution Explorer, select the solution, right-click, and click `Restore NuGet Package`

![image](assets/2017-05-10_16-28-39.jpg)

Then open the project reference, click `Neo.SmartContract.Framework`. A few cases still can not restore Nuget package how to do? Please restart Visual Studio 2015 or try to generate a solution directly.

![image](assets/2017-05-10_16-31-55.jpg)

## Compile the project

Everything is now ready to add the entry method to the project:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```
After this compiles successfully, you will see the generated `SmartContract1.avm` file in the `bin/Debug` directory, which is the file that is generated by the NEO smart contract.

![image](/assets/compile_smart_contract.jpg)


!Note:
   If you are generated, there is no output of the results of the map, it does not matter, you can also directly enter the command to compile the dll avm file

   Open a command prompt, navigate to the Debug directory, enter the following highlight (SmartContract1.dll is the name of the dll generated by the previous step).
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

Now that you have completed the configuration of the smart contract development environment, please refer to the [Art Experiment Guide for Tomids](tutorial.md)
