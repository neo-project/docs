# Riferimento dei Comandi CLI

Aprire la linea di comando, navigare fino alla directory dove il programma è collocato, inserire il seguente codice per avviare il wallet a linea di comando (nel nodo NEO).

`dotnet neo-cli.dll`

Questo tutorial introdurrà tutti i comandi presenti nel wallet a linea di comando. E' possibile manipolare il proprio wallet con i comandi per creare un wallet, per l'importazione e l'esportazione della chiave privata, per il trasferimento, per l'avvio del consenso, ecc.

Per iniziare esploreremo i vari comandi elencati nella linea di comando. Nella linea di comando, inserire `help` seguito da un comando di ritorno per visualizzare l'elenco dei comandi, come mostrato.

![image](/assets/cli_2.png)

Quanto segue è una descrizione di tutti i comandi e l'ordine delle parentesi:
Le parentesi angolari ``<> ``  indicano un parametro.
Le parentesi quadre `[]` sono per parametri opzionali.
Il simbolo `|` visualizza i parametri di riempimento, che possono essere qualsiasi di qualsiasi tipo.
Il simbolo uguale `=` indica il valore predefinito del parametro opzionale senza un input. 

## 1. Istruzioni della Console

| Comando      | Descrizione della funzione      |
| ------- | --------- |
| version | Mostra la versione corrente del software |
| help    | Menu di aiuto      |
| clear   | Cancellazione schermo      |
| exit    | Esce dal programma      |

## 2. Operazioni con il Wallet

Comando | Descrizione della funzione | Osservazioni |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | Creazione del file wallet|
| open wallet \<path> | Apertura del file wallet |
| rebuild wallet index | |  | Occorre aprire il wallet |
| list address | Elenca tutti gli account nel wallet | Occorre aprire il wallet |
| list asset | Elenca tutti gli asset nel wallet| Occorre aprire il wallet |
| list key | Elenca tutte le chiavi pubbliche nel tuo wallet | Occorre aprire il wallet |
| create address [n = 1] | Creazione di un indirizzo/creazione di un insieme di indirizzi | Occorre aprire il wallet |
| import key \<wif\|path> | Importazione della chiave privata/importazione in lotto delle chiavi private | Occorre aprire il wallet |
| export key \[address] [path] | Esportazione della chiave privata | Occorre aprire il wallet |
| send \<id\|alias> \<address> \<value> [fee=0]| Invio all'indirizzo specificato | Occorre aprire il wallet |

I seguenti comandi sono spiegati in dettaglio:

👉 `rebuild index`

Questo comando è utilizzato per ricostruire l'indice del wallet.
Perchè è necessario ricostruire l'indice del wallet?

C'è un campo nel wallet che registra l'altezza della sincronizzazione del blocco corrente. Per ogni nuovo blocco, il client del wallet sincronizza i blocchi e aggiorna gli asset e le transazioni nel wallet. Supponendo che l'altezza del blocco correntemente registrato sia 100, e si stia eseguendo il comando di importazione della chiave privata, il wallet continua a calcolare i tuoi asset dal blocco di altezza 100. Se l'indirizzo importato ha delle transazioni quando l'altezza del blocco è minore di 100, le transazioni e gli asset corrispondenti non saranno riflessi nel wallet, quindi andrebbe ricostruito l'indice del wallet, forzando il wallet a calcolare i vostri asset dall'altezza del blocco 0. 

Il wallet appena creato non ha bisogno di ricostruire l'indice del wallet, é richiesta solo la chiave privata importata per ricostruire l'indice del wallet.

👉 `create address [n = 1]`

Questo comando può essere usato per creare un nuovo indirizzo. Vi è anche la possibilità di inserire 'create address 100' per creare 100 nuovi indirizzi in lotto; La creazione in lotto dell'indirizzo sarà automaticamente esportata nel file address.txt.

👉 `export key [address] [path]`

È possibile specificare verso quali indirizzi esportare le corrispondenti chiavi private. Inoltre, è possibile specificare l'esportazione in un file determinato. (Vedere gli esempi successivi). Il comando richiede anche la verifica della password del wallet.

Export key

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉 `import key <wif | path>`

Quando si sta importando la chiave privata, è possibile specificare di importare una chiave privata, oppure di importare un file con un numero di chiavi private. (Vedere i seguenti comandi).

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

Se c'è un file specificato, il file è nel formato della chiave privata. Si riferisce all'output dell'esportazione key.txt.

👉 `send <id | alias> <address> <value> [fee = 0]`

Per i trasferimenti, vi è un totale di quattro parametri. Il primo parametro e l'ID dell'asset, il secondo parametro è l'indirizzo di pagamento, il terzo parametro è la quantità da trasferire e il quarto parametro è la commissione. (Questo parametro può essere lasciato vuoto, di default è 0) Il comando deve verificare la password del wallet. Ad esempio, al fine di trasferire 100 NEO all'indirizzo "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", occorre inserire il seguente comando.

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

Se non si é sicuri dell'ID dell'asset, si prega di eseguire il comando per visualizzare la lista di tutti gli asset nel proprio wallet.

## 3. Vedere le Informazioni del Nodo

Comando | Descrizione della Funzione |
| ---------- | ----------------------- |
show state | Mostra lo stato corrente della sincronizzazione della blockchain |
show node | Mostra l'indirizzo e la porta dei nodi connessi |
show pool | Mostra le transazioni nella pool della memoria (queste transazioni sono nello stato di 0 conferme) 

## 4. Istruzioni Avanzate

Comando | Descrizione della Funzione|
| --------------- | ---- |
Start consensus | avvia il consenso 
Iniziare il consenso sulla premessa che il wallet abbia l'autorità di consenso, permette che l'autorità di consenso stessa possa essere ottenuta sulla rete principale tramite votazione. Se è implementata una chain privata, la chiave pubblica del consenso può essere configurata in `protocol.json`. Si prega di fare riferimento a [Chain privata](private-chain.md) per maggiori dettagli.
