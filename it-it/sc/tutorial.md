# Tutorial NEO Smart Contract

Dopo aver letto i precedenti tutorials, dovresti essere capace di usare C# in Visual Studio 2015 o 2017 per creare progetti smart contract. Qui discuteremo come gli smart contract vengono eseguiti su NeoVM (Neo Virtual Machine).

## Attivazione degli smart contract

Ci sono due modi per innescare gli smart contacts:

1. Contract User Authentication: Qui lo Smart Contract é un Account Contract. Quando l'utente richiede di utilizzare il contract account in un asset, attiverá lo smart contract. 

2. Chiamata manuale allo smart contract: Qui l'utente invia una transazione (Invocation transaction) per avviare l'implementazione di uno smart contract.

## NeoVM

NeoVM é la macchina virtuale che esegue il codice smart contract NEO. Ci riferiamo al concetto di macchina virtuale in senso stretto, non con riferimento a sistemi operativi i programmi che possono simulare gli stessi come VMware o Hyper-V.

Per esempio, nel Jva JVM o .NET CLR, il codice sorgente verrá compilato nel codice byte pertinente e poi eseguito sulla macchina virtuale corrispondente. Il JVM o CLR eseguiranno il codice byte, il quale é simile alle istruzioni eseguibili su una vera macchina fisica. In particolare, le istruzioni binarie corrispondenti vengono ancora eseguite si una macchina fisica. La macchina fisica prende le istruzioni dalla memoria, li trasferisce alla CPU tramite il bus, poi decodifica, esegue, e memorizza il risultato.

### Architettura della macchina virtuale

   ![](../../assets/neo-vm.jpg)

Il diagramma precedente é il diagramma dell'architettura del sistema della macchina virtuale di Neo (NeoVM), dove l'implementazione nella casella tratteggiata é la parte principale della macchina virtuale.

#### Motore di esecuzione

Quello verde sulla sinistra é il motore di esecuzione della macchina virtuale (l'equivalente della CPU). Puó eseguire istruzioni comuni come il controllo di flusso, operazioni stack, operazioni sui bit, operazioni aritmetiche, operazioni logiche, metodi crittografici, e tanto altro. Puó interagire a livello di servizio interoperabile (Descritto sotto) tramite chiamate al sistema. 

#### Stack di valutazione

La parte grigia al centro della macchina virtuale é lo Stack di Valutazione (equivalente alla memoria). Al giorno d'oggi ci sono due modi per realizzare una macchina virtuale 1) basata sullo stack 2) basata sul registro. Entrambi i metodi hanno i loro vantaggi e svantaggi, ed entrambi hanno i loro grandi esempi di implementazione. Ci sono macchine virtuali basate sullo stack come JVM, CPython, e .NET CLR. Dall'altra parte ci sono le VM basate sul registro, come Dalvik e Lua5.0. Le macchine virtuali basate sullo stack hanno un concetto di computazione stak che permette alle macchine virtuali di interagire direttamente con lo stack (Stack di Valutazione) quando stanno performando operazioni reali. 

Poiché il comportamente predefinito di una VM basata sullo stack é quello di recuperare i dati dallo stack degli operandi, non c'é bisogno di specificare un operando. Confrontalo con, ad esempio, il seguente assembly x86 `"ADD EAX, EBX"`. Questa operazione richiede lo specificamente degli operandi fonte e la destinazione del risultato. Le istruzioni delle macchine virtuali basate sullo stack non hanno bisogno della specificazione di questi parametri. Per esempio, l'aggiunta di una singola operazione "ADD" verrá eseguita direttamente sull'operando dello stack. I dati possono essere riempiti direttamente e il risultato viene conservato allo stop dello stack.

#### Livello di servizio interoperabile

La parte blu del lato destro é il livello di servizio interoperabile della macchina virtuale (equivalente alle periferiche). Al momento, il livello di servizio interoperabile fornisce alcune API per accedere ai dati chain-chain dello smart contract. Puó accedere alle informazioni del blocco, informazioni sulla transazione, informazioni sul contratto, informazioni sull'asset, e altro ancora.

In aggiunta, il livello di servizio interoperabile fornisce anche un area di memorizzazione persistente per ogni contratto. Ciasciun contratto é opzionalmente creato con spazio di archiviazione privato, che ha la forma di un oggetto valore-chiave determinato dal destinatario del contratto piuttosto che dal contesto dell'archivio persistente. Il chiamante deve passare il proprio contesto di archiviazione al destinatario (per completare l'autorizzazione) prima che il chiamante possa eseguire operazioni di lettura e di scrittura.

### Modalitá di carica

A smart contract can programmed to charge a certain fee, divided into deployment costs and execution costs.

Deployment costs refers to the need for a developer to pay a fee to deploy a smart contract on the block chain (currently 500 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. Read more about smart contract fees [here](systemfees.md#smart-contract-fees).

## A simple smart contract

Here are some simple smart contracts:

```c#
public static bool Main ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the contract address of the assets (can be understood as money).

The NEO wallet client has a function for deleting an asset. When you delete an asset, the asset is sent to a specified address being the contract address generated by the above smart contract. Anyone can spend the assets in the address. The assets in the address are assets that others do not want.

```c#
public static bool Main ()
{
    return false
}
```

The return value of the contract is always `false`, indicating that the assets of this contract can not be used (this can be interpreted as burning or destroying an asset). Such a contract can for example be applied for shares of a company that have  been written off/canceled.

For more examples please see:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
