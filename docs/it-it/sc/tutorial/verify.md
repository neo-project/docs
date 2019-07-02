# Tutorial Autenticazione del Contratto

Questo tutorial é basato su Visual Studio 2017, per favore assicurati che il tuo Visual Studio sia aggiornato alla versione 2017. Inoltre, questo tutorial é basato sulla demo di Smart Contract 2.0, si prega di scaricare ed eseguire il **test network** da [GitHub](https://github.com/neo-project/neo-gui/releases).

Indirizzo di download dell'ultimo client **test network** al momento della stesura di questo documento: [neo-gui-2.0.1](https://github.com/neo-project/neo-gui/releases/download/v2.0.1/neo-gui-windows.zip).

## Compilare gli script del contratto

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
namespace Neo.SmartContract
{
    public class Test : SmartContract
    {
        public static bool Main(byte[] signature)
        {
            return true;
        }
    }
}
```

> [!Nota]
> Se non sai come scrivere e generare script di smart contract, vedi [Come usare C# per preparare uno Smart Contract](../getting-started.md)
>

Il contratto precedente sará compilato in Test.avm, Il suo contratto script (Test.avm dati binari) é:
 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

Imparerai come ottenere lo script del contratto per un file `.avm` successivamente in questo tutorial.

## Creare un wallet

Creare un nuovo wallet secondo il tutorial mostrato di seguito:

![Creare un wallet](/assets/verify_1.png)

## Ottenere lo script del contratto

Ci sono molti modi per ottenere lo script del contratto, un modo é quello di leggerlo direttamente dal file `.avm` usando il codice C# seguente.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
for (int i = 0; i < bytes.Length; i++)
    Console.Write(bytes[i].ToString("x2"));
```

Se non vuoi ottenere lo script del contratto tramite codice, allora il client `Deploy Contract` fornisce un modo semplice per ottenere il codice del contratto:

Cliccare su `Advanced`, `Deploy Contract`, cliccare sul bottone `Load` nell'angolo in basso a destra. Scegliere il file `Test.avm` generato precedentemente. Dovresti vedere lo script del contratto visualizzato nel box `Code`, come mostrato nella figura. Copialo.

![Ottenere lo script del contratto](/assets/verify_5.png)

## Creare un indirizzo del contratto

Dopo aver creato il tuo wallet, cliccare con il tasto destro del mouse, e creare un indirizzo del contratto con il tuo script del contratto generato:

![Creare un indirizzo del contratto](/assets/verify_6.png)

Associare l'indirizzo del contratto al proprio account e inserire i parametri corrispondenti. Poiché il nostro contratto ha un parametro per la firma, devi inserire `00` in `parameter list` (per maggiori dettagli, vedere [Parametro](Parameter.md)), in seguito inserire lo script del contratto dallo step precedente nel box `Code`. 

La ragione per associare un account è associare un contratto con una coppia di chiavi pubblica-privata, cosí quando il contratto ha bisogno di essere firmato, il client firmerá automaticamente con la chiave privata dell'account associato.

![Creare un indirizzo del contratto](/assets/verify_7.png)

Dopo aver cliccato `OK`, l'account di autenticazione dello smart contract è stato creato correttamente.

## Testing

Quanto segue é un test dell'account di autenticazione dello smart contrat, quando si trasferiscono asset da un account smart contract, il nodo di consenso eseguirá il contratto quando convalida la transazione. Se la validazione del contratto avviene con successo (restituisce il risultato `true`), la transazione é confermata. Fino al ricevimento del risultato `true`, la transazione avrà lo stato non confermato. Il miglior modo é di trasferire prima alcuni asset all'account di autenticazione del contratto, per poi trasferirli nuovamente.

> [!Nota]
> Al fine di garantire l'accuratezza del test, non avere altri asset nel wallet. Altrimenti potresti non sapere se l'asset é stato trasferito da un account standard o trasferito dall'account del contratto, a meno che tu non comprenda l'algoritmo di cambio del client e possa confermare che la transazione proviene dall'indirizzo dello smart contract.


### Trasferire asset all'indirizzo del contratto

Trasferire una certa quantitá di asset nel tuo account di contratto:

![Transfer asset to contract address](/assets/verify_9.png)

### Trasferire asset di contratto

Trasferire asset fuori dal tuo account smart contract:

![Transfer the contract amount](/assets/verify_10.png)



> [!Nota]
> Il saldo degli asset nel client é la somma del saldo nell'account standard e il saldo nell'indirizzo del contratto, quindi, gli asset di tutti gli indirizzi combinati. Se o no puoi usare gli asset nell'indirizzo del contratto dipende dal risultato dell'esecuzione dello smart contract, se il contratto ha successo (il risultato é `true`) allora l'asset puó essere trasferito, altimenti non puó essere trasferito.
