# Implementare un Contratto di Blocco

Leggi i seguenti tutorial prima di proseguire con l'articolo:

[Come Scrivere Smart Contract NEO in C#](../getting-started-csharp.md)

[Tutorial Smart Contract NEO](../tutorial.md)

[Esempio Smart Contract - Lock (lock)](Lock.md)

Assumendo che hai giá la conoscenza di base riguardo agli smart contract, mosteremo come implementare un contratto di blocco a un indirizzo usando il wallet.

In aggiunta, questo tutorial é basato sulla demo di Smart Contract 2.0. Si prega di scaricare l'ultimo **test network client** da [GitHub](https://github.com/neo-project/neo-gui/releases).

PS: In questo momento, l'ultimo **test network client** scaricabile é: [Neo GUI v2.2.0](https://github.com/neo-project/neo-gui/releases/tag/v2.2.0).

> [!Nota]
> Le seguenti operazioni saranno eseguite nel **test network**. Perché la main network non ha ancora implementato Smart Contract 2.0, le seguenti operazioni nella main network falliranno.
> Al fine di usare la TestNet devi fare due cambiamenti nei file config: 
1. Estrarre il client NEO GUI nella tua cartella. Noterai i file config.json, config.mainnet.json, config.testnet.json, protocol.json, protocol.mainnet.json, protocol.testnet.json. Di default, `config.json` e `protocol.json` sono identici al quelli della versione MainNet.
2. Devi copiare il codice dai file della TestNet nei file `config.json` e `protocol.json` potrai in tal modo accedere alla TestNet invece della MainNet (quindi copia e incolla `config.testnet.json` in `config.json`, e `protocol.testnet.json` in `protocol.json`).

## Creare un wallet

Questo step é veramente semplice. Aprire la versione del PC del client, cliccare `wallet`, `create the wallet database `, selezionare la posizione di archiviazione del wallet e impostare il nome e la password del wallet.

![](../../../assets/lock2_1.png)

## Ottenere la chiave pubblica

Il nuovo wallet appena creato genererá automaticamente un account standard. Doppio clic destro sull'account, vedi la chiave privata e copiare la chiave pubblica dalla seconda linea, come mostrato nell'immagine:

![](../../../assets/lock2_2.png)

> [!Attenzione]
> Per favore nota: Non divulgare la tua chiave privata.

Qui scriviamo un programma locale per trasformare la chiave pubblica in un array di byte, in C# é il seguente:

```c#
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 这里替换为上一步复制的公钥
            byte[] b = HexToBytes("0285eab65f4a0126e4b85b4e5d8b7e303aff7efb360d595f2e3189bb90487ad5aa");
            foreach (var item in b)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();
        }

        static byte[] HexToBytes(string hexString)
        {
            hexString = hexString.Trim();
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
    }
}
```

Dopo averlo eseguito, lo schermo mostrerá l'array di byte creato dalla chiave pubblica. Copialo da qualche parte in quanto verrá usato successivamente. 

## Scrivi uno smart contract

Creare un progetto smart contract e scrivere il seguente smart contract.

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Lock : SmartContract
    {
        public static bool Main(byte[] signature)
        {
            Header header = Blockchain.GetHeader(Blockchain.GetHeight());
            if (header.Timestamp < 1499328600) // 2017-6-6 18:10
                return false;
            // Paste the public key byte array here
            return VerifySignature(signature，new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 });
        }
    }
}
```

Il contratto di blocco ha due importanti variabili da cambiare: la chiave privata e il Lock Time.

1. nel codice del contratto, incollare la precedente copia dell'array di byte della chiave pubblica.

2. Cambiare il Lock Time del codice esempio, il quale é un timestamp Unix. Calcolalo, potresti voler usare qualche strumento online. [Unix timestamp online conversion](https://unixtime.51240.com/).

Dopo aver rimpiazzato le due variabili, compilare il contratto per ottenere il file Lock.avm.

## Implementare un Lock Contract

Per implementare il contratto, abbiamo prima bisogno di ottenere lo script del contratto. Ci sono molti modi per farlo. Possiamo utilizzare il codice C# sottostante per leggere il .avm in modo da ottenere il codice di byte.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```
Se pensi che scrivere uno script per questo sia fastidioso, la funzione `Deploy Contract` del client permette di ottenere il codice di byte in modo più semplice:

Cliccare su `Advanced`, `Deploy Contract`, cliccare sul bottone `Load` nell'angolo in basso a destra. Scegliere il file `Lock.avm` generato precedentemente. Dovresti ora vedere lo script del contratto mostrato nel box `Code`, come in figura. Copialo di nuovo.

![](../../../assets/lock2_5.png)

Nel client, sotto la finestra `Account`, fare doppio click sullo spazio bianco, selezionare `Create Contract Add.`, `Custom`, e incollare lo script del contratto nel box: 

![](../../../assets/lock2_7.png)

Qui, dobbiamo scegliente un account associato (per essere specifici, stiamo associando una coppia di chiavi private/pubbliche). L'associazione significa che se lo smart contract richiede un'operazione di firma, il client userá la chiave privata associata per firmare. In questo step, dobbiamo selezionare la stessa chiave pubblica del primo step, altrimenti la firma non corrisponde e l'esecuzione del contratto fallirá. Siccome esiste un parametro di firma nel nostro contratto, completa il form con 00 del paramentro entry (per capire cosa compilare in parametri, fai riferimento a [Parametro](Parameter.md)), e compilalo con il codice script mostrato precedentemente. Una volta fatto, vedremo l'indirizzo del contratto come mostrato in figura.

![](../../../assets/lock2_8.png)



## Test

Quanto segue é un test dell'autenticazione dell'account di uno smart contract. Nel trasferimento di asset da un account di autenticazione di uno smart contract, il nodo di consenso eseguirá lo smart contract mentre verifica la transazione. Se il contratto viene validato con successo (il risultato é True), la transazione viene confermata. Altrimenti la transazione resterá sempre non confermata. Il nostro metodo di testing sará di trasferire alcuni asset nell'indirizzo dell'account, e poi trasferirli al di fuori di questo.

> [! Nota]
> Al fine di garantire l'accuratezza del test, non avere altri asset nel wallet. Altrimenti potresti non sapere se l'asset é stato trasferito da un account standard o trasferito dall'account del contratto, a meno che tu non comprenda l'algoritmo di cambio del client e possa confermare che la transazione proviene dall'indirizzo dello smart contract.

### Trasferire asset a un indirizzo di contratto

Aprire il wallet con gli asset sulla **testnet** e trasferire una certa quantitá di asset all'account di contratto.

### Trasferire gli asset fuori dall'indirizzo di contratto

Trasferire gli asset dal tuo account smart contract:

![Transfer contract amount](../../../assets/lock2_11.png)

Se l'operazione sopra mostrata é corretta, quando gli asset vengono trasferiti succederá quanto segue:

Quando il tempo corrente é inferiore al tempo di lockout, il trasferimento non sará confermato, quindi il trasferimento fallirá.

Dopo aver cliccato `Rebuild Index`, dopo circa 5 minuti, il trasferimento non riconosciuto sparirà e gli asset torneranno allo stato precedente.

Se il tempo corrente é maggiore del Lock Time, il trasferimento avrà esito positivo.
