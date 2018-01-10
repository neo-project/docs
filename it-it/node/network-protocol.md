# Protocollo di Rete

NEO adotta una struttura di rete P2P, in cui i nodi possono comunicare tra loro tramite il protocollo TCP/IP. In questa struttura, ci sono due diversi tipi di nodi: nodi peer e nodi convalidatori (indicati come Bookkeper nel whitepaper di NEO). I nodi peer possono trasmettere, ricevere e trasferire transazioni o blocchi, mentre i nodi convalidatori possono creare blocchi.


Il protocollo di rete NEO è approssimativamente simile a quello di Bitcoin, comunque, le strutture dati, come blocchi o transazioni, sono piuttosto diverse.

Convenzione
----

1. Ordine byte

    Tutti gli integer di NEO sono Little Endian tranne per l'indirizzo IP e il numero di porta, questi 2 sono Big Endian.

1. Hash

   Vengono utilizzate due diverse funzioni hash in NEO: SHA256 e RIPEMD160. Lo SHA256 è usato per generare valori hash lunghi, e RIPEMD160 è usato per generare valori hash corti. In generale, otteniamo il valore hash di un oggetto usando la funzione hash due volte. Per esempio, usiamo SHA256 due volte quando vogliamo generare il valore hash del blocco o della transazione. Quando si genera un indirizzo di contratto, useremo prima la funzione SHA256 e poi useremo la funzione RIPEMD160.

   Inoltre, il blocco utilizzerà anche una struttura hash chiamata Merkle Tree. Calcola l'hash di ogni transazione e combina l'un l'altro di nuovo con l'hash, ripetendo questo processo finché non esiste un solo hash di root (Merkle Root).

1. Tipo di Lunghezza Variabile

   + Variant: Integer di lunghezza variabile, può essere codificato per risparmiare spazio in base al valore digitato.

      |Valore|Lunghezza|Formato|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + Varstr: Stringa di lunghezza variabile, composta da un integer di lunghezza variabile seguito da stringhe. Stringa codificata da UTF8.

      |Dimensione|Campo|Tipo di Dato|Descrizione|
      |---|---|---|---|
      |?|length|variant|La lunghezza di una stringa in bytes|
      |length|string|uint8[length]|La stringa stessa|

   + Array: L'array consiste in un integer di lunghezza variabile seguito da una sequenza di elementi.

1. Numero Fixed-point 

   I dati in NEO come quantità o prezzo sono numeri fixed-point a 64 bit e la precisione della parte decimale è 10<sup>-8</sup>，intervallo：[-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>)

Tipo di dati
-------

1. Blockchain

   La blockchain è una sorta di struttura logica, che è collegata in serie con una lista unidirezionale collegata. È usata per memorizzare i dati dell'intera rete, come transazioni o asset.

1. Blocco

   |Dimensione|Campo|Tipo di Dato|Descrizione|
   |---|---|---|---|
   |4|Version|uint32|Versione del blocco che è 0 per il momento|
   |32|PrevBlock|uint256|Valore hash del blocco precedente|
   |32|MerkleRoot|uint256|Hash root di un elenco di transazioni |
   |4|Timestamp|uint32|Time-stamp|
   |4|Height|uint32|Altezza del blocco|
   |8|Nonce|uint64|Numero casuale|
   |20|NextMiner|uint160|Indirizzo del contratto del prossimo miner|
   |1|-|uint8|È fissato a 1|
   |?|Script|script|Script utilizzato per convalidare il blocco|
   |?*?|Transactions|tx[]|Lista di transazioni|

   Quando si calcola il valore hash del blocco, invece di calcolare l'intero blocco, verranno calcolati solo i primi sette campi della testa del blocco, i quali sono version, PrevBlock, MerkleRoot, timestamp, e height, il nonce, NextMiner. Poiché MerkleRoot contiene già il valore hash di tutte le transazioni, la modifica della transazione influenzerà il valore hash del blocco.

   Struttura dei dati della testa del blocco:

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |4|Version|uint32|Versione del blocco che è momentaneamente 0 |
   |32|PrevBlock|uint256|Valore hash del blocco precedente|
   |32|MerkleRoot|uint256|Hash root di un elenco di transazioni|
   |4|Timestamp|uint32|Time-stamp|
   |4|Height|uint32|Altezza del blocco|
   |8|Nonce|uint64|Numero casuale|
   |20|NextMiner|uint160|Indirizzo del contratto del prossimo miner|
   |1|-|uint8|È fissato a 1|
   |?|Script|script|Script utilizzato per convalidare il blocco|
   |1|-|uint8|È fissato a 0|

   Il timestamp di ciascun blocco deve essere successivo al timestamp del blocco precedente. Generalmente la differenza del timestamp di due blocchi è di circa 15 secondi ed è consentita un po di imprecisione. L'altezza del blocco deve essere esattamente uguale all'altezza del blocco precedente più 1.

1. Transazione

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |1|Type|uint8|Tipo di transazione|
   |1|Version|uint8|Versione trading, Correntemente 0|
   |?|-|-|Dati specifici per i tipi di transazione|
   |?*?|Attributes|tx_attr[]|Funzionalità aggiuntive della transazione|
   |34*?|Inputs|tx_in[]|Input|
   |60*?|Outputs|tx_out[]|Output|
   |?*?|Scripts|script[]|Elenco di script utilizzati per convalidare la transazione|

  Tutti i processi nel sistema NEO sono registrati come transazioni. Esistono diversi tipi di transazioni:

   |Valore|Nome|Sistema di commissioni|Descrizione|
   |---|---|---|---|
   |0x00|MinerTransaction|0|Assegna commissioni byte|
   |0x01|IssueTransaction|500\|0|Emissione di asset|
   |0x02|ClaimTransaction|0|Assegna GAS|
   |0x20|EnrollmentTransaction|1000|Iscrizione per validatore|
   |0x40|RegisterTransaction|10000|Registrazione di assets|
   |0x80|ContractTransaction|0|Transazione contratto|
   |0xd0|PublishTransaction|500 * n|(Non usabile) Transazioni speciali per smart contracts|
   |0xd1|InvocationTransaction|0|Transazioni speciali per la chiamata di Smart Contracts|

   Ogni tipo di transazione, oltre al campo pubblico, ha anche un suo campo esclusivo. Quanto segue descriverà questi campi esclusivi in dettaglio.

   + MinerTransaction

      |Dimensione|Campo|Tipo di dato|Descrizione|
      |---|---|---|---|
      |4|Nonce|uint32|Numero casuale|

      La prima transazione in ogni blocco deve essere MinerTransaction. Viene utilizzato per pagare tutte le spese di transazione del blocco corrente per il validator.

      Un numero casuale nella transazione viene utilizzato per evitare la collisione hash.

   + IssueTransaction

      Non ci sono campi speciali per una transazione di emissione.

     Gli asset manager possono creare gli asset che sono stati registrati nella blockchain di NEO tramite IssueTransaction, e inviarli a qualsiasi indirizzo.

     In particolare, se gli asset emessi sono NEO, la transazione verrà inviata gratuitamente.

      Un numero casuale nella transazione viene utilizzato per evitare la collisione hash.

   + ClaimTransaction

      |Dimensione|Campo|Tipo di dato|Descrizione|
      |---|---|---|---|
      |34*?|Claims|tx_in[]|NEO per distribuzione|

   + EnrollmentTransaction

      |Dimensione|Campo|Tipo di dato|Descrizione|
      |---|---|---|---|
      |33|PublicKey|ec_point|validatore chiave pubblica|

     La transazione rappresenta un modulo di iscrizione, che indica che lo sponsor della transazione vorrebbe registrarsi come validatore.

      Il modo per iscriversi è: Per costruire un tipo di transazione EnrollmentTransaction e inviare un deposito all'indirizzo della PublicKey.

      Il modo per cancellare la registrazione è: Spendi il deposito sull'indirizzo della PublicKey.

   + RegisterTransaction

      > [!Attenzione]
      È stato disattivato e sostituito da Neo.Asset.Create per lo smart contract.

      Vedi [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/neo/Asset/Create.md)

      Vedi [Alternative Smart Contract API](../sc/api/neo.md)

   + ContractTransaction

      Non ci sono attributi speciali per una transazione di contratto. Questo è un tipo di transazione molto comune in quanto consente a un wallet di inviare NEO a un altro. I campi di transazione `inputs` e `outputs` saranno di solito importanti per questa transazione (per esempio, per governare quanti NEO verranno inviati, e a quale indirizzo).

   + PublishTransaction

      > [!Warning]
      È stato disattivato e sostituito da Neo.Contract.Create per lo smart contract.

      Vedi [Alternative .NET Smart Contract Framework](../sc/fw/dotnet/neo/Contract/Create.md)

      Vedi [Alternative Smart Contract API](../sc/api/neo.md)

   + Invocare una transazione

      | Dimensione   | Campo     | Tipo di dato   | Descrizione              |
      | ---- | ------ | ------- | --------------- |
      | -    | -      | -       | Campi pubblici per le transazioni         |
      | ?    | Script | uint8[] | Invocato da uno smart contract     |
      | 8    | Gas    | int64   | Costo richiesto per eseguire uno smart contract |
      | -    | -      | -       | Campi pubblici per le transazioni         |

1. Attributi della transazione

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |1|Usage|uint8|Uso|
   |0\|1|length|uint8|Lunghezza dei dati (circostanze specifiche verranno omesse)|
   |length|Data|uint8[length]|dati esterni|

   A volte la transazione conterrà alcuni dati per uso esterno, questi dati verranno inseriti nel campo degli attributi della transazione.

   Ogni attributo di transazione ha usi diversi:

   |Valore|Nome|Descrizione|
   |---|---|---|
   |0x00|ContractHash|Valore hash del contratto|
   |0x02-0x03|ECDH02-ECDH03|Chiave pubblica per lo scambio di chiavi ECDH|
   |0x20|Script|Ulteriori convalide delle transazioni|
   |0x30|Vote|Per votare |
   |0x80|CertUrl|Indirizzo URL del certificato|
   |0x81|DescriptionUrl|Indirizzo URL della descrizione|
   |0x90|Description|Breve descrizione|
   |0xa1-0xaf|Hash1-Hash15|Utilizzato per memorizzare valori hash personalizzati|
   |0xf0-0xff|Remark-Remark15|Osservazioni|

   Per ContractHash, ECDH series, Hash series, la lunghezza dei dati è fissata a 32 bytes e il campo lunghezza è omesso;

   Per CertUrl, DescriptionUrl, Description, Remark series, la lunghezza dei dati deve essere chiaramente definita, e la lunghezza non dovrebbe superare 255;

1. Input della transazione

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |32|PrevHash|uint256|Hash della transazione precedente|
   |2|PrevIndex|uint16|Indice della transazione precedente|

1. Output della transazione

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |32|AssetId|uint256|ID dell'Asset|
   |8|Value|int64|Valore|
   |20|ScriptHash|uint160|Indirizzo del beneficiario|

   Ogni transazione può avere degli output fino a 65536.

1. Script di convalida

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |?|StackScript|uint8[]|Codice di script stack|
   |?|RedeemScript|uint8[]|Codice di script del contratto|

   lo script tack può essere utilizzato solo per le operazioni PUSH, che viene utilizzato per inviare dati come le firme nello stack. L'interprete script eseguirà prima il codice script stack, e poi esegue il codice dello script del contratto.

   In una transazione, il valore hash del codice dello script del contratto deve essere coerente con l'output della transazione, che fa parte della convalida. La sezione successiva descriverà in dettaglio il processo di esecuzione dello script.

Messaggio di Rete
-------

Tutti i messaggi di rete sono inviati in questa struttura:

|Dimensione|Campo|Tipo di dato|Descrizione|
|---|---|---|---|
|4|Magic|uint32|ID del protocollo|
|12|Command|char[12]|Comando|
|4|length|uint32|lunghezza del payload|
|4|Checksum|uint32|Checksum|
|length|Payload|uint8[length]|Contenuto del messaggio|

Valore magico definito:

|Valore|Descrizione|
|---|---|
|0x00746e41|Modalità di produzione|
|0x74746e41|Modalità di prova|

Il comando è codice utf8, di cui la lunghezza è 12 byte, la parte extra è riempita con 0.

Checksum sono i primi 4 bytes del valore che due volte hash SHA256 del payload.

Secondo diversi ordini, il Payload ha un diverso formato dettagliato, vedi sotto:

1. Versione

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |4|Version|uint32|Versione del protocollo, 0 per adesso|
   |8|Services|uint64|Il servizio fornito dal nodo è attualmente 1|
   |4|Timestamp|uint32|Tempo corrente|
   |2|Port|uint16|Porta su cui il server è in ascolto, è 0 se non utilizzato.|
   |4|Nonce|uint32|È usato per distinguere il nodo dall'IP pubblico|
   |?|UserAgent|varstr|ID del client|
   |4|StartHeight|uint32|Altezza della blockchain|
   |1|Relay|bool|Se ricevere e inoltrare


   Quando un nodo riceve una richiesta di connessione, dichiara immediatamente la sua versione. non ci sarà altra comunicazione fino a quando entrambe le parti non avranno le versioni l'una dell'altra.

1. verack

   Quando un nodo riceve il messaggio di versione, risponde immediatamente con un verack.

   Questo messaggio non ha payload.

1. getaddr

   Effettuare richieste a un nodo per un gruppo di nuovi nodi attivi al fine di aumentare il numero di connessioni.

   Questo messaggio non ha payload.

1. addr

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|Indirizzo di altri nodi nella rete|

   Dopo aver ricevuto il messaggio getaddr, il nodo restituisce un messaggio addr come risposta e fornisce informazioni sui nodi noti sulla rete.

1. getheaders

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hash dell'ultimo blocco richiesto dal nodo|
    |32|HashStop|uint256|Hash dell'ultimo blocco richiesto dal nodo|

   Effettua richieste a un nodo per un massimo di pacchetti header di 2000 blocchi che contengono HashStart a HashStop. Per ottenere l'hash del blocco, è necessario inviare nuovamente il messaggio getheaders. Questo messaggio viene utilizzato per scaricare rapidamente la blockchain che non contiene le transazioni.

1. headers

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |?*?|Headers|header[]|Testa del blocco|

   Dopo aver ricevuto il messaggio getheaders, il nodo restituisce un messaggio di intestazione come risposta e fornisce informazioni sui nodi noti sulla rete.

1. getblocks

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hash dell'ultimo blocco richiesto dal nodo|
   |32|HashStop|uint256|Hash dell'ultimo blocco richiesto dal nodo|

   Effettua richieste a un nodo per il messaggio inv che parte da HashStart a HashStop. Il numero di blocchi che inizia da HashStart a HashStop arriva fino a 500. Se vuoi ottenere un blocco di hash più di quello, è necessario inviare nuovamente il messaggio getblocks.

1. inv

   |Dimensione|campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Dati degli inventari|

  Il nodo può trasmettere le informazioni sull'oggetto che possiede con questo messaggio. Il messaggio può essere inviato automaticamente o può essere utilizzato per rispondere ai messaggi getblocks.

   Le informazioni sugli oggetti sono incluse nell'elenco:

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |4|Type|uint32|Tipo di oggetto|
   |32|Hash|uint256|Hash dell'oggetto|

   Tipi di oggetti:

   |Valore|Nome|Descrizione|
   |---|---|---|
   |0x01|TX|Transazione|
   |0x02|Block|Blocco|
   |0xe0|Consensus|Dati sul consenso|

1. getdata

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Dati di inventari|

   Per richiedere un oggetto specificato da un nodo: Di solito viene inviato dopo che il pacchetto di inv viene ricevuto e l'elemento conosciuto rimosso.

1. Blocco

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |---|---|---|---|
   |?|Block|block|Blocco|

   Invio di un blocco a un nodo, per rispondere al messaggio getdata.

1. tx

   |Dimensione|Campo|Tipo di dato|descrizione|
   |---|---|---|---|
   |?|Transaction|tx|Transazione|

   Invio di una transazione a un nodo, per rispondere al messaggio getdata.

   |Dimensione|Campo|Tipo di dato|Descrizione|
   |----|---------|--------- |----------------- |
   |32 *?|HashStart|uint256[]|Il nodo è noto come l'ultimo hash del blocco|
   |32|hashStop|uint256|Richiedi l'ultimo blocco|
