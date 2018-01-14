# Utilizzo del Client NEO-GUI

## Prerequisiti


### Download del client

Il client stesso non richiede alcuna installazione. Scaricare e installare i file in una posizione a tua scelta, in seguito fare doppio clic su neo-gui.exe per aprire il client. Se vi sono problemi durante il processo e il client non puó essere aperto normalmente, si prega di posizionare il file error.log nella stessa directory di neo-gui, successivamente contattare il nostro staff tecnico che vi assisterà nella risoluzione del problema.

> [!Nota]
>
> Il client neo-gui é compatibile con le seguenti versioni di Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
>
>La versione preliminare del sistema operativo Windows 10 richiede l'installazione di [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### Sincronizzazione dei dati della blockchain

Il client deve essere completamente sincronizzato prima dell'uso. L'angolo in basso a sinistra indica il numero di blocchi sincronizzati e il numero totale di blocchi nella rete (vedi l'esempio in basso). Questi numeri si aggiornano regolarmente.

![image](/assets/gui_1.png)

Al fine di aumentare la velocitá di sincronizzazione della rete puoi scaricare una copia della blockchain fino ad una determinata altezza. Ció significa che il client avrá bisogno di sincronizzare solo i blocchi aggiuntivi dalla rete NEO e non l'intera blockchain. 

1. Per iniziare, scaricare il file collocato qui [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

2. Chiudere il client neo-gui e aprire chain.acc.zip. Estrarre il file chain.acc nella cartella neo-gui come mostrato nella figura seguente:

   ![](/assets/gui_58.png)

3. Dopo la riapertura del client neo-gui vedrai che il client é sincronizzato fino ad un certo punto e che lo stesso continuerá la sincronizzazione del resto della blockchain. Come mostrato nella figura successiva:

   ![](/assets/gui_59.png)

Quando la sincronizzazione arriva a un certo punto, il file (chain.acc) verrá eliminato e la sincronizzazione dalla rete NEO continuerá. Come mostrato nella figura successiva:

![](/assets/gui_60.png)

I dati di fianco a "Height" corrispondono a altezza/client e altezza/blockchain. Quando il wallet viene aperto, vengono mostrati i dati sull'altezza del wallet.

### Glossario

#### Wallet 

Il file wallet (portafoglio) memorizza un riferimento ai tuoi NEO, GAS e le informazioni dell'account nel database con l'estensione .db3 o .json. Questo file è molto importante e deve essere eseguito un backup per garantirne la sicurezza.

> [!Importante]
>
> La perdita del file wallet o della password del wallet risulterà in una perdita dei tuoi asset. Si prega di assicurarsi che il file wallet sia archiviato in modo sicuro e di ricordare la password del wallet.

#### Account

Usato per tenere traccia degli asset in un blocco NEO.

Le informazioni legate all'account includono: Indirizzo, chiave privata, chiave pubblica, tipo.

(1) Indirizzo: L'equivalente di un conto bancario o il numero di carta bancaria, è usato per ricevere asset durante le transazioni. 

(2) Tipo: Neo.Wallets.SignatureContract Indica che l'indirizzo consiste di una chiave pubblica ed è un indirizzo multi-firma 1-a-1. Neo.Wallets.MultiSigContract indica che l'indirizzo consiste di molteplici chiavi pubbliche ed è un indirizzo multifirma m-a-n, usato per smart contract. 

(3) Chiave privata: Un numero casuale da 256-bit, tenuto dall'utente e non divulgato pubblicamente. Questo rappresenta la proprietà dell'account e la proprietà degli asset all'interno dell'account. 

(4) Chiave pubblica: Ogni chiave privata ha una chiave pubblica corrispondente (Nota: Le informazioni sulla chiave pubblica e la chiave privata possono essere viste effettuando un doppio click sull'indirizzo.)

> [!Importante]
>
> In nessun caso la chiave privata deve essere divulgata a terze parti. Una volta che la chiave privata viene divulgata, ciò potrebbe risultare in una perdita dei propri asset.

#### Asset

Gli asset dell'account, le informazioni sugli asset, che includono: Asset (NEO, GAS, gli asset creati dall'utente), tipo, saldo e l'emittente.

#### Record delle Transazioni

Un record di tutte le informazioni sulle transazioni associate all'account.

#### Trasferimento

Il trasferimento di asset a un'indirizzo ricevente. Se il tipo di asset è NEO, viene richiesto a entrambe le parti di confermare con la propria firma. Altri tipi di asset possono essere trasferiti senza la conferma da parte di entrambe le parti.

#### Trade

Effettua lo scambio online di asset tra due parti, dove entrambe le parti devono confermare prima di scambiare gli asset con successo.

#### Firma

La firma di informazioni, significa confermare le informazioni da parte del firmatario. Per le transazioni che coinvolgono allocazioni di capitale e trasferimento di asset, la firma è richiesta come prova del consenso da parte delle parti coinvolte.

#### Asset Registrati

Creare un nuovo asset emesso dall'utente nel blocco NEO. L'utente può definire il tipo, il nome, il totale, ecc. dell'asset e specificare l'amministratore dell'account dell'asset. La creazione di asset consuma una certa quantità  di GAS come servizio di commisione addizionale, il prezzo corrente è di 10,000 GAS. (la commissione per la rete di test è dell'1% della rete principale).

#### Asset Distribuiti

Nei limiti massimi della  quantità totale impostata dal creatore dell'asset, l'asset viene emesso all'indirizzo specificato dall'emittente. La distribuzione di asset consuma una certa quantità di piccole monete come servizio di commissione addizionale, il prezzo corrente è di 500 GAS. (Sulla rete Test la commissione corrisponde all'1% della rete principale).

#### Elezioni

Coloro che vogliono divenire validatori NEO devono registrarsi tramite un processo di elezione. Attraverso il deposito di una certa quantità di NEO, è possibile ottenere la qualificazione di validatore. Questa funzione non è attualmente supportata. Si prega di attendere ulteriori aggiornamenti.

#### Voto

I detentori di NEO possono votare i candidati validatori e questo meccaniscmo di voto determinerà se un validatore è selezionato. Questa funzione non è attualmente supportata. Si prega di attendere ulteriori aggioramenti.

#### Trasmissione

Dopo aver firmato, l'informazione sulla transazione viene trasmessa all'intera rete, dove la conferma da parte di un nodo completa la transazione. In questo momento, questa caratteristica appare solo nella firma.

#### Indirizzo di Monitoraggio

dopo aver importato l'indirizzo di una terza parte come indirizzo di monitoraggio, sarai capace di vedere gli asset in quell'indirizzo.

## Wallet
### Creazione del Database del Wallet

(1) cliccare su `wallet`, `create the wallet database`, apparirà la pagina `new wallet`.

![image](/assets/gui_2.png)

(2) cliccare su `Browse` per selezionare la posizione di archiviazione del file wallet, impostare il nome del file e cliccare su Salva.

![image](/es-es/node/assets/gui/gui_3.png)

(3) Inserire `password` e `repeat password` e salvare la propria password.

![image](/assets/gui_4.png)

(4) Cliccare su `OK` e il wallet verrà creato con successo, di default sarà disponibile con un account standard. Da notare che a causa del ruolo del meccanismo di cambiamento, il resto degli asset verrá trasferito al primo indirizzo come impostazione predefinita. Quindi, occorre fare il backup della corrispondente chiave privata e del wallet. 

### Aprire il Database del Wallet

(1) Ogni volta che il client viene riaperto, occorre fare clic su `open wallet database` per selezionare quale file del wallet aprire, come mostrato in figura:

![image](/assets/gui_5.png)

(2) Cliccare su `Browse`  per selezionare il wallet (di solito quello predefinito è l'ultimo wallet aperto), inserire la password e cliccare `OK` per accedere al wallet. Va notato che quando il wallet mostra un errore, è possibile tentare il "repair mode" per aprire il wallet. 

### Cambiare la Password

Usato per modificare la password del wallet.

![image](/assets/gui_6.png)

Dopo aver cambiato la password, si prega di ricordarsi di eseguire nuovamente il backup del wallet dato che i precedenti backup non contengono la nuova password.

### Ricostruzione dell'Indice del Wallet

Questa opzione viene usata per ripristinare gli errori nel client quando si verifica un'eccezione. L'Indice del wallet va ricostruito nei seguenti casi:

1. Dopo l'importazione di una chiave privata.

2. Se una transazione non è stata confermata dopo un lungo periodo di tempo.

3. Gli asset del wallet mostrano errori e i dati della blockchain non corrispondono.

Siccome l'altezza del blocco corrente è molto alta, ricostruire l'Indice del wallet potrebbe richiedere diversi minuti. Si prega di essere pazienti.

## Trade

### Trasferimento

#### Trasferimento di Token Asset 

(1) Cliccare su `transaction`, `transfer`, `+`, e inserire le informazioni per il trasferimento.

![image](/assets/gui_10.png)

(2) Cliccare OK.

![image](/assets/gui_11.png)

(3) Cliccare OK.

![image](/zh-cn/node/assets/i.png)

#### Trasferimento di un Asset Capitale

(1) Cliccare su `transaction`, `transfer`, `+`, e inserire le informazioni per il trasferimento.

![image](/zh-cn/node/assets/j.png)

(2) Cliccare OK.

![image](/zh-cn/node/assets/k.png)

(3) Cliccare OK, come mostrato nel display, dove sono mostrate più firme richieste:

![image](/zh-cn/node/assets/l.png)

(4) Per la funzione firma vedi [firma](#sign).

#### Trasferimento in Lotto

Questa funzione è usata per semplificare il trasferimento di uno stesso asset a differenti indirizzi.

![image](/assets/gui_14.png)

Il formato dei dati è `address transfer amount` (separato da spazi).

![image](/assets/gui_15.png)

Va notato che il formato dei dati va inserito in conformità ai criteri esposti precedentemente, uno spazio aggiuntivo potrebbe portare al fallimento del trasferimento.

#### Osservazioni

Questa funzione è usata per registrare le informazioni delle transazioni nella blockchain NEO. Il [blockchain browser di NEO](https://www.antchain.xyz/) può essere usato per individuare le informazioni delle transazioni.

![image](/zh-cn/node/assets/o.png)

Al momento non vi sono requisiti per il formato del messaggio.

![image](/zh-cn/node/assets/p.png)

Le osservazioni sulla transazione possono essere trovate sul [blockchain browser di NEO](https://www.antchain.xyz/)

![image](/zh-cn/node/assets/oo.png)

### Trade

#### Iniziare un'Operazione

(1) Questa transazione richiede ad entrambe le parti di avviare una richiesta di transazione al fine di determinare i dettagli dell'asset inviati al destinatario corrispondente.

![image](/assets/gui_18.png)

(2) Cliccare OK per generare una richiesta di transazione. E' possibile usare la richiesta di transazione per ottenere dettagli sui termini di invio dalla parte corrispondente.

![image](/assets/gui_19.png)

#### Fusione dell'Operazione

(1) Dopo aver chiuso la finestra di richiesta di transazione avviata vi verrà mostrata l'interfaccia di richiesta di fusione della transazione.

![image](/assets/gui_20.png)

(2) Ciò permette di visualizzare la richiesta di transazione dell'altra parte. Per verificare la legittimità della richiesta della controparte, cliccare "verify". A seconda della legittimità della richiesta, è possibile scegliere di accettare o di rifiutare.

![image](/assets/gui_24.png)

(3) Se si sceglie di accettare, le due parti in questione devono firmare e trasmettere. Per maggiori dettagli, vedere [Firma](#sign). <a id="sign"> </a>

### Firma
(1) Ciò fa sì che la transazione inviata dall'altra parte sia incollata all'interno della casella di input. Cliccare su `sign`, e i dati di output saranno generati. Allo stesso tempo, verrà visualizzato il bottone `broadcast`.

![image](/zh-cn/node/assets/u.png)

(2) Cliccare su `broadcast` per inviare la transazione. Questa transazione è adesso completa e l'ID della transazione (TXID) verrà mostrato una volta che la transazione avverrà con successo. 

![image](/assets/gui_30.png)

<a  id="offline"></a>

## Avanzate


### Estrazione del GAS

Il GAS viene generato da ogni nuovo blocco e sarà allocato agli indirizzi che contengono NEO. (Il numero all'interno delle parentesi nel saldo degli asset rappresenta la quantità di GAS che può essere reclamata) In qualsiasi momento, Un possessore di NEO può iniziare una richiesta per reclamare questi GAS all'indirizzo corrispondente di NEO. Al momento, solo la versione del client per PC ha la funzionalità di estrarre GAS.

I passaggi specifici sono:

(1) Trasferire tutti i NEO all'interno del wallet usando un'operazione di trasferimento. (è possibile inviare i NEO direttamente all'indirizzo corrente) Una volta che la richiesta di GAS viene saldata, il GAS può essere prelevato. (Fare riferimento al white paper per una spiegazione tecnica del suddetto processo). 

(2) Cliccare `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Richiedere un Certificato

Notare che questa operazione genera solo una richiesta per generare il file certificato, l'utente dovrà ancora riferirsi all'autorità rilevante dei certificati digitali in modo da richiedere il detto certificato.

Cliccare `Advanced`, `Request certificate`, e compilare il form in conformità alle istruzioni date.

![image](/assets/gui_39.png)

Il file generato verrà mostrato come nella figura seguente:

![image](/zh-cn/node/assets/y.png)

### Asset Registrati

Vi sono due tipi di asset, Token e Azioni. usando i token come esempio, riempire quanto segue:

![image](/assets/gui_43.png)

Occorre notare che per la registrazione di asset vanno sostenute commissioni importanti. (Per la rete principale la commissione è di 10000 GAS, per la rete di test è di 100 monete NEO) si prega di prestare attenzione.

### Distribuire gli asset

![image](/assets/gui_46.png)

Occorre notare che la distribuzione di asset comporta commissioni importanti. (La commissione per la rete principale è di 500 monete NEO, sulla rete di test la commissione è di 5 monete NEO) Si prega di prestare attenzione e, se possibile, scegliere la distribuzione in un'unica soluzione.

### Elezioni

Questa funzione è usata per registrarsi come candidato validatore della blockchain NEO.

![image](/assets/gui_57.png)

Occorre notare che l'elezione richiede importanti commissioni. (Per la rete principale la commissione è di 1000 GAS, per la rete di test è di 10 GAS) Si prega di prestare attenzione. La funzione di validatore non è ancora disponibile, attendere aggiornamenti futuri.

