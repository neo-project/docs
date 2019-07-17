# Tutorial NEO Smart Contract

Dopo aver letto i precedenti tutorial, dovresti essere capace di usare C# in Visual Studio 2015 o 2017 per creare progetti smart contract. Qui discuteremo come gli smart contract vengono eseguiti su NeoVM (Neo Virtual Machine).

## Attivazione degli smart contract

Ci sono due modi per innescare gli smart contact:

1. Contract User Authentication: Qui lo Smart Contract é un account di contratto. Quando l'utente richiede di utilizzare l'account di contratto in un asset, attiverá lo smart contract. 

2. Chiamata manuale allo smart contract: Qui l'utente invia una transazione (Invocation Transaction) per avviare l'implementazione di uno smart contract.

## NeoVM

NeoVM é la macchina virtuale che esegue il codice smart contract NEO. Ci riferiamo al concetto di macchina virtuale in senso stretto, non con riferimento a sistemi operativi o programmi che possono simulare gli stessi come VMware o Hyper-V.

Per esempio, nel Jva JVM o .NET CLR, il codice sorgente verrá compilato nel codice byte pertinente per poi essere eseguito sulla macchina virtuale corrispondente. Il JVM o CLR eseguiranno il codice byte, il quale é simile alle istruzioni eseguibili su una vera macchina fisica. In particolare, le istruzioni binarie corrispondenti vengono ancora eseguite su una macchina fisica. La macchina fisica recupera le istruzioni dalla memoria, le trasmette alla CPU tramite il bus, poi decodifica, esegue, e memorizza il risultato.

### Architettura della macchina virtuale

   ![](../../assets/neo-vm.jpg)

Il diagramma precedente é il diagramma dell'architettura del sistema della macchina virtuale di Neo (NeoVM), dove l'implementazione nella casella tratteggiata é la parte principale della macchina virtuale.

#### Motore di esecuzione

Quello verde sulla sinistra é il motore di esecuzione della macchina virtuale (l'equivalente della CPU). Puó eseguire istruzioni comuni come il controllo del flusso, operazioni stack, operazioni sui bit, operazioni aritmetiche, operazioni logiche, metodi crittografici, e tanto altro. Puó interagire a livello di servizio interoperabile (descritto sotto) tramite chiamate al sistema. 

#### Stack di valutazione

La parte grigia al centro della macchina virtuale é lo Stack di Valutazione (equivalente alla memoria). Al giorno d'oggi ci sono due modi per realizzare una macchina virtuale 1) basata sullo stack 2) basato sul registro. Entrambi i metodi hanno i loro vantaggi e svantaggi, ed entrambi hanno degli ottimi esempi di implementazione. Ci sono macchine virtuali basate sullo stack come JVM, CPython, e .NET CLR. Dall'altra parte ci sono le VM basate sul registro, come Dalvik e Lua5.0. Le macchine virtuali basate sullo stack hanno un concetto di computazione stak che permette alle macchine virtuali di interagire direttamente con lo stack (Stack di Valutazione) quando stanno performando operazioni reali. 

Poiché il comportamente predefinito di una VM basata sullo stack é quello di recuperare i dati dallo stack degli operandi, non c'é bisogno di specificare un operando. Confrontalo con, ad esempio, il seguente assembly x86 `"ADD EAX, EBX"`. Questa operazione richiede di specificare gli operandi di origine e la destinazione del risultato. Le istruzioni delle macchine virtuali basate sullo stack non hanno bisogno della specificazione di questi parametri. Ad esempio, l'aggiunta di una singola operazione "ADD" verrá eseguita direttamente sull'operando dello stack. I dati possono essere riempiti direttamente e il risultato viene conservato allo stop dello stack.

#### Livello di servizio interoperabile

La parte blu del lato destro é il livello di servizio interoperabile della macchina virtuale (equivalente alle periferiche). Al momento, il livello di servizio interoperabile fornisce alcune API per accedere ai dati chain-chain dello smart contract. Questo puó accedere alle informazioni del blocco, informazioni sulla transazione, informazioni sul contratto, informazioni sull'asset, e altro ancora.

In aggiunta, il livello di servizio interoperabile fornisce anche un area di memorizzazione persistente per ogni contratto. Ciasciun contratto é opzionalmente creato con spazio di archiviazione privato, che ha la forma di un oggetto valore-chiave determinato dal destinatario del contratto piuttosto che dal contesto dell'archivio persistente. Il chiamante deve passare il proprio contesto di archiviazione al destinatario (per completare l'autorizzazione) prima che il chiamante possa eseguire operazioni di lettura e di scrittura.

### Modalitá di carica

Uno smart contract puó essere programmato per caricare una certa commissione, divisa in costi di implementazione e in costi di esecuzione. 

I costi di implementazione si riferiscono alla necessitá di uno sviluppatore di pagare una commissione per implementare un contratto sulla blockchain (al momento 500 GAS). I costi di esecuzione si riferiscono alla commissione che gli utenti pagano per l'esecuzione di uno smart contract. Tutte le operazioni hanno un costo, la maggior parte delle operazioni hanno un costo di 0.001 GAS. I primi 10 GAS sono gratis. E' possibile ottenere l'elaborazione prioritaria incrementando manualmente la commissione per l'esecuzione. Leggi di piú a proposito delle commissioni sugli smart contract [qui](systemfees.md#smart-contract-fees).

## Uno smart contract semplice

Ecco alcuni semplici smart contract:

```c#
public static bool Main ()
{
    return true;
}
```

Qui il valore restituito dallo smart contract é sempre vero (true), indicando che chiunque puó spendere indirizzo di contratto dell'asset (inteso come denaro).

Il client wallet di NEO ha una funzione per l'eliminazione di un asset. Quando si elimina un asset, l'asset é inviato a un'indirizzo specifico generato dallo stesso smart contract di sopra. Chiunque puó spendere l'asset nell'indirizzo. Gli asset nell'indirizzo sono asset che gli altri non vogliono.

```c#
public static bool Main ()
{
    return false
}
```

Il valore restituito dal contratto é sempre `false`, indicando che gli asset di questo contratto non possono essere usati (ció puó essere interpretato come bruciare o distruggere un asset). Questo contratto puó essere applicato per le azioni di una compagnia che sono state cancellate/stornate.

Per altri esempi vedere:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
