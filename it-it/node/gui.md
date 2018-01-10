# Utilizzo del Client NEO-GUI

## Prerequisiti


### Scaricamento del client

Il client stesso non richiede alcuna installazione. Scaricare e installare i file in una posizione a tua scelta, dopo fare doppio clic su neo-gui.exe per aprire il client. Se ci sono problemi durante il processo e il client non puó essere aperto normalmente, per favore posizionare il file error.log nella stessa directory di neo-gui, successivamente contattare il nostro sraff tecnico per assisterti nella risoluzione del problema.

> [!Nota]
>
> Il client neo-gui é compatibile con le seguenti versioni di Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
>
>La pre-versione del sistema Window 10 richiede l'installazione di [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### Sincronizzazione dati blockchain

Il client deve essere completamente sincronizzaro prima dell'uso. L'angolo in basso a sinistra indica il numero di blocchi sincronizzati e il numero totale di blocchi nella rete (vedi l'esempio in basso). Questi numeri si aggiornano regolarmente.

![image](/assets/gui_1.png)

Al fine di aumentare la velocitá di sincronizzazione della rete puoi scaricare una copia della blockchain fino ad una determinata altezza. Ció significa che il client avrá bisogno di sincronizzare soltanto i blocchi aggiuntivi dalla rete NEO invece dell'intera blockchain. 

1. Per iniziare, scaricare il file collocato a [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

2. Chiudere il client neo-gui client e aprire chain.acc.zip. Estrarre il file chain.acc nella cartella neo-gui folder come mostrato nella figura seguente:

   ![](/assets/gui_58.png)

3. Dopo la riapertura del client neo-gui vedrai che il client é sincronizzato fino ad un certo punto e che lo stesso continuerá la sincronizzazione del resto della blockchain. Come mostrato nella figura successiva:

   ![](/assets/gui_59.png)

Quando la sincronizzazione arriva a un certo punto, il file (chain.acc) verrá eliminato e la sincronizzazione dall rete NEO continuerá. Come mostrato nella figura successiva:

![](/assets/gui_60.png)

I dati di fianco "Height" corrispondono a altezza/client altezza/blockchain. Quando il wallet viene aperto, vengono mostrati i dati sull'altezza del wallet.

### Glossario

#### Wallet 

Il file wallet memorizza un riferimento ai tuoi NEO, GAS e le informazioni dell'account nel database con l'estensione .db3 o .json. Questo file è molto importante e deve essere eseguito un backup in sicurezza dello stesso.

> [!Importante]
>
> La perdita del file wallet o della password del wallet risulterà in una perdita dei tuoi asset. Per favore, assicurati che il file wallet sia archiviato in sicurezza e ricorda la password del wallet.

#### Account

Usato per tenere traccia degli asset in un blocco NEO.

Le informazioni legate all'account includono: Indirizzo, chiave privata, chiave pubblica, type.

(1) Indirizzo: L'equivalente di un conto bancario o il numero di carta bancaria, usato per ricevere asset durante le transazioni. 

(2) Type: Neo.Wallets.SignatureContract Indica che l'indirizzo consiste in una chiave pubblica ed è  un indirizzo multi-firma 1-a-1. Neo.Wallets.MultiSigContract indica che l'indirizzo consiste in molteplici chiavi pubbliche ed è un indirizzo multifirma m-a-n, usato per i contratti smart. 

(3) Chiave privata: Un numero casuale da 256-bit, tenuto dall'utente e non divulgato pubblicamente. Rappresenta la proprietà dell'account e la proprietà degli asset all'interno dell'account. 

(4) Chiave pubblica: Ogni chiave privata ha una chiave pubblica corrispondente (Nota: Le informazioni sulla chiave pubblica e la chiave privata possono essere viste facendo doppio click sull'indirizzo.)

> [!Importante]
>
> In nessun caso la chiave privata deve essere divulgata a terze parti. Una volta che la chiave privata viene divulgata, ciò potrebbe risultare in una perdita dei tuoi asset.

#### Asset

Gli asset dell'account, le informazioni sugli asset, che includono: Asset (NEO, GAS, gli asset creati dall'utente), tipo, saldo e l'emittente.

#### Record delle Transazioni

Un record di tutte le informazioni sulle transazioni associate all'account.

#### Trasferimento

Il trasferimento di asset a un indirizzo ricevente. Se il tipo di asset è NEO, viene richiesto a entrambe le parti di confermare con la propria firma. Altri tipi di asset possono essere trasferiti senza la conferma da parte di entrambe le parti.

#### Scambio

Effettuare lo scambio online di asset tra due parti, dove entrambe le parti devono confermare prima di scambiare gli asset con successo.

#### Firma

La firma di informazioni, significa confermare le informazioni da parte del firmatario.
per le transazioni che coinvolgono allocazioni di capitale e trasferimento di asset, la firma è richiesta come prova del consenso da parte delle parti coinvolte.

#### Asset Registrati

Creare un asset emesso dall'utente nel blocco NEO. L'utente può definire il tipo, il nome, il totale, etc. dell'asset e specificare l'amministratore dell'account dell'asset. la creazione di asset consuma una certa quantità  di NEO come servizio di commisione addizionale, il prezzo corrente è di 10,000 GAS. (la commissione per la rete in test è  l'uno percento della rete principale).

#### Asset Distribuiti

Nei limiti massimi della  quantità totale impostata dal creatore dell'asset, l'asset viene emesso all'indirizzo specificato dall'emittente. La distribuzione di asset consuma una certa quantità di piccole monete come servizio addizionale con commissione, il prezzo corrente è di 500 GAS. (Sulla rete test corrisponde all'un percento della rete principale).

#### Elezioni

Coloro che vogliono diventare validatori NEO devono registrarsi tramite elezione. Attraverso il deposito di una certa quantità di NEO, è possibile ottenere la qualificazione di validator. Questa funzione non è correntemente supportata. Per favore aspettare aggiornamenti successivi.

#### Voto

I detentori di NEO possono votare i candidati validatori e questo meccaniscmo di voto determinerà se un validatore è eletto. Questa funzione non è correntemente supportata. Per favore aspettare aggiornamenti successivi.

#### Trasmissione

Dopo aver firmato, l'informazione sulla transazione viene trasmette all'intera rete, la conferma da parte di un nodo completa la transazione. In questo momento, questa caratteristica appare solamente nella firma.

#### Indirizzo di Monitoraggio

dopo aver importato l'indirizzo di terza parte come indirizzo da monitorare, sarai capace di vedere gli asset in questo indirizzo.

## Wallet
### Creazione del Database del Wallet

(1) clicca su `wallet`, `create the wallet database`, apparirà una nuova pagina `new wallet`.

![image](/assets/gui_2.png)

(2) clicca su `Browse` per selezionare la posizione di archiviazione del file wallet, scegli il nome del file e clicca su Salva.

![image](/es-es/node/assets/gui/gui_3.png)

(3) Inserici `password` e `ripeat password` e salva la tua password.

![image](/assets/gui_4.png)

(4) Clicca su `OK` e il wallet verrà creato con successo, di default sarà reso disponibile con un account standard. Da notare che a causa del ruolo del meccanismo di cambiamento, il resto degli asset sarà trasferito al primo indirizzo predefinito. quindi, c'è il bisogno di fare il corrispondente backup della chiave privata e del wallet. 

### Apri il Database del Wallet

(1) Ogni volta che il client viene ri-aperto, occorre fare clic su `open wallet database` per selezionare quale file del wallet aprire, come mostrato in figura:

![image](/assets/gui_5.png)

(2) Clicca su `Browse`  per selezionare il wallet (di solito quello predefinite è l'ultimo wallet aperto), inserisci la password, clicca `OK` per accedere al wallet. Va notato che quando il wallet mostra un errore, è possibile tentare il "repair mode" per aprire il wallet. 

### Cambiare Password

Usato per modificare la password del wallet.

![image](/assets/gui_6.png)

Dopo aver cambiato la password, per favore ricorda di eseguire nuovamente il backup del wallet dato che i precedenti backup del wallet non contengono la nuova password.

### Ricostruire L'Index del Wallet

Questa opzione viene usata per ripristinare gli errori nel client quando si verifica un'eccezione. L'Index del waller va ricostruito nei seguenti casi:

1. Dopo l'importazione di una chiave privata.

2. Se una transazione non è stata confermata dopo un lungo periodo di tempo.

3. Gli asset del wallet mostrano errori e i dati della blockchain non corrispondono.

siccome l'altezza del blocco corrente è molto alta, ricostruire l'Index del wallet potrebbe richiedere diversi minuti. Per favore sii paziente.

### Ripristinare L'account

Questa opzione viene usata per ripristinare l'indirizzo del file wallet che è stato accidentalmente cancellato e i suoi asset. Va notato che non è generalmente raccomandato eliminare le operazioni all'interno del client, per evitare la perdita di asset.

## Commercio

### Trasferire

#### Trasferimento di Token Asset 

(1) Clicca su `transaction`, `transfer`, `+`, e inserisci le informazioni per il trasferimento.

![image](/assets/gui_10.png)

(2) Clicca OK.

![image](/assets/gui_11.png)

(3) Clicca OK.

![image](/zh-cn/node/assets/i.png)

#### Trasferimento di un Asset Capitale

(1) Clicca su `transaction`, `transfer`, `+`, e inserisci le informazioni per il trasferimento.

![image](/zh-cn/node/assets/j.png)

(2) Clicca OK.

![image](/zh-cn/node/assets/k.png)

(3) Clicca OK, come mostrato nel display, dove sono mostrate più firme richieste:

![image](/zh-cn/node/assets/l.png)

(4) Per la funzione di firma vedi [signature](#sign).

#### Trasferimenti in Lotto

Questa funzione è usata per semplificare il trasferimento di uno stesso asset a differenti indirizzi.

![image](/assets/gui_14.png)

Il formato dei dati è `address transfer amount` (separato da spazi).

![image](/assets/gui_15.png)

Va notate che il formato dei dati va inserito in conformità ai criteri esposti precedentemente, uno spazio aggiuntivo potrebbe portare al fallimento del trasferimento.

#### Osservazioni

Questa funzione è usata per registrare le informazioni sulle transazioni nella blockchain di NEO. Il [blockchain browser di NEO](https://www.antchain.xyz/) può essere usato per individuare le informazioni sulle transazioni.

![image](/zh-cn/node/assets/o.png)

Al momento non vi sono requisiti per il formato del messaggio.

![image](/zh-cn/node/assets/p.png)

Le osservazioni sulla transazione possono essere trovate sul [blockchain browser di NEO](https://www.antchain.xyz/)

![image](/zh-cn/node/assets/oo.png)

### Commercio

#### Iniziare un'Operazione

(1) Questa transazione richiede ad entrambe le parti di iniziare una richiesta di transazione al fine di determinare i dettagli dell'asset inviati al destinatario corrispondente.

![image](/assets/gui_18.png)

(2) Clicca OK per generare una richiesta di transazione. Possiamo usare la richiesta di transazione per ottenere dettagli sui termini di invio dalla parte corrispondente.

![image](/assets/gui_19.png)

#### Fuosione dell'Operazione

(1) Dopo aver chiuso la finestra di transazione avviata ti verrà mostrata l'interfaccia di richiesta di fuosione delle transazioni.

![image](/assets/gui_20.png)

(2) Ciò permette di visualizzare la richiesta di transazione dell'altra parte. Per verificare la legittimità della richiesta della controparte , cliccare verify. sulla legittimità della richiesta, è possibile scegliere di accettare o rifiutare.

![image](/assets/gui_24.png)

(3) Se si sceglie di accettare le due parti in questione devono firmare la trasmissione. Per maggiori dettagli, vedere [Firma](#sign). <a id="sign"> </a>

### Firma
(1) Ciò fa sì che la transazione inviata dall'altra parte sia incollata all'interno della casella di input. Cliccare su `sign`, e i dati di output saranno generati. Allo stesso tempo, verrà visualizzato il bottone `broadcast`.

![image](/zh-cn/node/assets/u.png)

(2) Clicca su `broadcast` per inviare la transazione. Questa transazione è adesso completa e un ID della transazione (TXID) verrà mostrato una volta che la transazione avverrà con successo. 

![image](/assets/gui_30.png)

<a  id="offline"></a>

## Avanzate

### Scarica e Sincronizza Dati Offline

Al fine di velocizzare la sincronizzazione della rete puoi scaricare una copia della blockchain fino a un certo blocco. Ciò significa che il client ha bisogno solo di sincronizzare i blocchi aggiuntivi dalla rete NEO invece dell'intera blockchain.

**Scarica**

Per iniziare, scarica il file collocato in [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

**Aggiungi**

Chiudi il client neo-gui e apri chain.acc.zip. estrai il file chain.acc nella cartella neo-gui come mostrato dalla figura seguente:
Close the neo-gui client and open chain.acc.zip.  Extract the chain.acc file in the neo-gui folder as shown in the figure below:

![](/assets/gui_58.png)

**sincronizzazione**

dopo aver riaperto il client neo-gui vedrai che il client è sincronizzato fino ad un certo livello e che lo stesso non continuerà la sincronizzazione del resto della blockchain. come mostrato in figura:

![](/assets/gui_59.png)

**Completare**

Quando sincronizzato fino ad un certo punto, il file (chain.acc) verrà cancellato e la sincronizzazione dalla rete NEO continuerà. come mostrato nella figura sottostante:

![](/assets/gui_60.png)





### Estrazione del GAS

Il GAS viene generato da ogni nuovo blocco e sarà allocato agli indirizzi che contengono NEO. (Il numero all'interno delle parentesi nel saldo degli asset rappresenta la quantità di GAS che può essere rivendicata) In qualsiasi momento, Un possessore di NEO può iniziare una richiesta per rivendicare questo GAS all'indirizzo corrispondente di NEO. Al momento, solo la versione del client per PC ha la funzionalità di estrarre GAS.

I passaggi specifici sono:

(1) Trasferire tutti i NEO all'interno del wallet usando un'operazione di trasferimento. (è possibile inviare i NEO all'indirizzo corrente) Una volta che la richiesta di GAS viene risolta, il GAS può essere prelevato. (Fare riferimento al white paper per una spiegazione tecnica del suddetto processo). 

(2) Cliccare `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Richiedere un Certificato

Notare che questa operazione genera solo una richiesta per generare il file certificato, l'utente dovrà ancora andare dall'autorità rilevante per i certificati digitali per richiedere il detto certificato.

Cliccare `Advanced`, `Request certificate`, e compilare il form in conformità alle istruzioni date.

![image](/assets/gui_39.png)

Il file generato verrà mostrato come nella figura seguente:

![image](/zh-cn/node/assets/y.png)

### Asset Registrati

Vi sono due tipi di asset, Token e Azioni. usando i token come esempio, riempire come di seguito:

![image](/assets/gui_43.png)

Va notato che per la registrazione di asset vanno sostenute commissioni importanti. (Per la rete principale la commissione è di 10000 GAS, per la rete test è di 100 GAS) per favore, prestare attenzione.

### Distribute asset

![image](/assets/gui_46.png)

Occorre notare che la distribuzione degli asset richiede commissioni importanti. (La commissione per la rete principale è di 500 NEO, sulla rete test la commissione è di 5 NEO) Per favore, prestare attenzione e scegliere una distribuzione in un'unica solizione se possibile.

### eseguire Contratti

Da aggiungere

### Invocare Contratti

Da aggiungere

### Elezioni

Questa funzione è usata per registrarsi come candidato validatore della blockchain di NEO.

![image](/assets/gui_57.png)

Occorre notare che l'elezione richiede importanti commissioni. (Per la rete principale la commissione è di 1000 GAS, per la rete test è di 10 GAS) Per favore, prestare attenzione. La funzione di validatore non è ancora disponibile, aspettare aggiornamenti futuri.

### 4.8 Opzione

Nessun contenuto al momento.

## Aiuto

### Vedi Aiuto

No content yet.

### Website Ufficiale

Il website ufficiale di NEO è collocato a: https://neo.org/

### Strumenti per Sviluppatori

Da aggiungere

### Su NEO

La versione numerica del client NEO.
