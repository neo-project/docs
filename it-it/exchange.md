# Documento per Sviluppatori Exchange

Questo documento é destinato a guidare gli sviluppatori di exchange nella configurazione dei nodi NEO sul server exchange e nel completamento dei programmi di sviluppo correlati per le transazioni di asset in NEO. Prima di procedere con la lettura, assicurati di aver letto [NEO White Paper](index.html) e compreso le tecnologie e le conoscenze base di NEO.

In genere, un exchange ha bisogno di fare quanto segue:

- [Implementazione di un Nodo NEO su Server](#deploying-a-neo-node-on-server)
- [Creazione di un Wallet e un Indirizzo di Deposito](#creating-a-wallet-and-deposit-addresses)
- [Gestione delle Transazioni di Asset Globali](#dealing-with-global-assets-transactions)
- [Gestione delle Transazioni di Asset NEP-5 ](#dealing-with-nep-5-assets-transactions)
- [(Opzionale) Distribuzione di GAS agli utenti](#optional-distributing-gas-to-users)



## Implementazione di un Nodo NEO su Server

Per implementare un nodo NEO sul server exchange, esegui quanto segue:

1.  Installare [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime) sul server, 2.0 e le versioni successive.
2.  Scaricare il programma [Neo-CLI](https://github.com/neo-project/neo-cli/releases) da Github e abilitare il nodo NEO.

Per maggiori informazioni, fare riferimento a [Installazione e implementazione di un nodo NEO](node/setup.html).

## Creazione di un Wallet e un Indirizzo di Deposito

### NEO-CLI

NEO-CLI é un client a linea di comando (wallet) per sviluppatori. Gli sviluppatori possono interagire con il client in due modi:

- Usando i comandi CLI (interfaccia a linea di comando). Per esempio, é possibile creare un wallet, generare un indirizzo, ecc.
- Usando la Remote Procedure Call (RPC). Per esempio, é possibile trasferire all'indirizzo designato, acquisire le informazioni del blocco dell'altezza designata, acquisire le informazioni del trade designato, ecc.

NEO-CLI fornisce le seguenti funzionalitá： 

- Come wallet, gestisce gli assets tramite la linea di comando.

  Per abilitare il wallet，inserire il seguente comando sotto la directory di NEO-CLI：

  ```
  dotnet neo-cli.dll
  ```

  Per controllare tutti i comandi disponibili, inserire il seguente comando：

  ```
  help
  ```

  Per maggiori informazioni, fare riferimento a [Riferimento dei Comandi CLI](node/cli.html).

- Fornisce API per recuperare i dati blockchain dai nodi. Le interfaccie sono fornite tramite  [JSON-RPC](http://www.jsonrpc.org/specification)，e le comunicazioni sottostanti usano i protocollo HTTP/HTTPS.

  Per avviare un nodo che fornisce il servizio RPC, immettere il seguente comando nella directory NEO-CLI：

  ```
  dotnet neo-cli.dll /rpc
  ```

  Per maggiori informazioni sull'API, fare riferimento a [Riferimento API](node/api.html).


### Creazione di un Wallet

L'exchange deve creare un wallet online per gestire gli indirizzi di deposito degli utenti. Il wallet é usato per memorizzare le informazioni degli account (entrambe chiavi private e chiavi pubbliche) e dei contratti. È la prova piú importante in possesso dell'utente. Gli utenti devono mantenere i file del wallet e la password del wallet al sicuro. Essi non devono divulgare o perderne i dati. 

> [!Nota]
>
> Gli Exchange non devono creare un wallet per ogni indirizzo. Di solito un wallet online tiene tutti gli indirizzi di deposito degli utenti. Un "cold wallet" (un wallet offline) rappresenta un'altra opzione di memorizzazione che offre una maggiore sicurezza.

Per creare un wallet, eseguire la seguente procedura：

1. Inserire  `create wallet <path>`.

   <path> é il percorso del wallet e del nome file del wallet. L'estensione del file puó essere di ogni tipo, per esempio,  creare il wallet mywallet.db3.

2. Impostare una password per il wallet. 

> [!Nota]
>
> Il wallet deve rimanere sempre aperto tutto il tempo per rispondere alle richieste di preglievo degli utenti. Per motivi di sicurezza, i wallet devono essere eseguiti in un server indipendente su cui il firewall è configurato in modo appropriato, come mostrato di seguito. 

|                    | Mainnet | Testnet |
| ------------------ | ------- | ------- |
| JSON-RPC via HTTPS | 10331   | 20331   |
| JSON-RPC via HTTP  | 10332   | 20332   |
| P2P                | 10333   | 20333   |
| websocket          | 10334   | 20334   |

### Generazione Indirizzi di Deposito

Un wallet puó memorizzare indirizzi multipli. L'exchange deve generare un indirizzo di deposito per ogni utente. 

Ci sono due metodi per generare indirizzi di deposito: 

- Quando l'utente deposita (NEO/NEO GAS) per la prima volta, il programma genera dinamicamente un indirizzo NEO. Il vantaggio é che non é necessario generare indirizzi a intervalli di tempo fissi, mentre lo svantaggio consiste nel non poter effettuare il backup del wallet.

  Per sviluppare il programma per la generazione dinamica degli indirizzi, usare l'API NEO-CLI [Metodo getnewaddress](node/api/getnewaddress.html). L'indirizzo creato é restituito.

- L'exchange crea in anticipo un lotto di indirizzi NEO. Quando l'utente paga (NEO/NEO GAS) per la prima volta, l'exchange assegna un indirizzo NEO a lui o lei. Il vantaggio consiste nella convenienza di fare il backup del wallet, mentre lo svantaggio consiste nel dover generare manualmente gli indirizzi NEO.
  Per generare indirizzi in lotto, eseguire il comando NEO- CLI `create address [n]`. Gli indirizzi vengono esportati automaticamente nel file address.txt. [n] é opzionale. Il suo valore predefinito é 1. Per esempio, per generare 100 indirizzi alla volta, inserire `create address 100`.


> [!Nota]
>
> In entrambi i casi, l'exchange deve importare gli indirizzi nel database e distribuirli agli utenti

## Gestione delle Transazioni di Asset Globali

### Sviluppo di Programmi destinati ai Depositi e Prelievi dell'Utente

Per gli asset globali, l'exchange deve sviluppare programmi che svolgono le seguenti funzioni:

1. Monitorare i nuovi blocchi tramite l'API NEO-CLI ([Metodo getblock](node/api/getblock2.html)).
2. Gestire i depositi dell'utente in base alle informazioni sulla transazione.
3. Memorizzare i record delle transazioni relativi all'exchange.

#### Depositi dell'Utente 

Per quanto riguarda i depositi degli utenti, l'exchange deve tenere presente quanto segue:

- La blockchain NEO ha una sola chain principale senza chain laterali, che non ha blocchi isolati e di cui non si può effettuare il fork.
- Una transazione registrata nella blockchain NEO non può essere manomessa, il che significa che una conferma rappresenta il successo di un deposito.
- In genere, il saldo di un indirizzo di deposito nell'exchange non è uguale al saldo che l'utente ha nell'exchange. Potrebbe essere perché:
  - Quando si trasferisce o si preleva, il wallet NEO cerca uno o più indirizzi nel wallet, trova gli spiccioli che soddisfano il requisito e li somma fino al raggiungimento del totale della transazione per poi utilizzarlo come input invece di prelevare dall'indirizzo specificato (a meno che l'exchange riscriva alcune funzioni del wallet NEO per soddisfare i propri bisogni).
  - Altre operazioni che possono portare alla disuguaglianza dell'equilibrio, ad esempio, l'exchange trasferisce parte degli asset ai suoi wallet offline (c.d. cold wallet).
- In un indirizzo NEO vi sono più di due asset (NEO e NEO GAS). Più asset emessi dagli utenti (come stock o token) possono essere archiviati. L'exchange dovrebbe determinare il tipo di asset quando l'utente li deposita. Inoltre non dovrebbe confondere altri asset per NEO GAS o NEO né confondere il prelevamento di NEO con quello di NEO GAS.
- Il wallet NEO è un nodo completo che deve rimanere online per sincronizzare i blocchi. È possibile visualizzare lo stato di sincronizzazione dei blocchi attraverso lo stato di visualizzazione nella CLI, qui il lato sinistro rappresenta l'altezza del blocco locale mentre il lato destro rappresenta l'altezza del blocco del nodo.
- Nell'exchange, il trasferimento tra gli utenti non dovrebbe essere registrato attraverso la blockchain. In generale, il saldo dell'utente viene modificato direttamente nel database. Solo i depositi e i prelievi vengono registrati sulla blockchain.

#### Registri dei Depositi

L'exchange deve scrivere codice per monitorare tutte le transazioni in un blocco e per registrare tutte le transazioni relative agli indirizzi dell'exchange nel database. Se si verifica un deposito, il saldo dell'utente deve essere aggiornato. 

Gli sviluppatori possono usare il metodo  `getblock <index> [verbose]` dell'API NEO-CLI per recuperare le informazioni del blocco. `<index>` è l'indice di blocco. `[verbose]` equivale a 0 di default. Quando `[verbose]` è 0, il metodo restituisce le informazioni del blocco serializzato con il sistema numerico esadecimale. Dovresti deserializzare la stringa esadecimale per ottenere le informazioni dettagliate del blocco. Quando `[verbose]` è 1, il metodo restituisce le informazioni del blocco corrispondente in formato JSON. Per ulteriori informazioni, fare riferimento a [Metodo getblock](node/api/getblock2.html).

Le informazioni del blocco includono le transazioni in input e output. L'exchange deve registrare tutte le sue transazioni correlate. L'output delle transazioni è in effetti la registrazione delle transazioni dei prelievi di un utente. Quando l'exchange vede uno dei suoi indirizzi nell'output delle transazioni, aggiorna il bilancio NEO/NEO GAS dell'utente corrispondente che possiede questo indirizzo di deposito. Alcuni exchange possono anche procedere nel seguente modo: se trova un indirizzo all'interno dell'exchange come output della transazione, registrerà il deposito nel suo database e modificherà il saldo dell'utente dopo diverse conferme (A meno che non debba rispettare l'operazione di altre blockchain, questo modo non è raccomandato) . 

> [!Nota]
>
> - Il metodo getblockcount restituisce la somma di blocchi nella chain principale. Il primo parametro del Metodo getblock é `<index>` che rappresenta l'indice del blocco. Indice del blocco = Altezza del blocco = Somma dei blocchi -1. Se getblockcount restituisce 1234, dovresti usare getblock 1233 per ottenere le informazioni dell'ultimo blocco.
> - Le transazioni di deposito e prelievo (NEO/ NEO GAS) sono tutte di una tipologia denominata ContractTransaction. Gli exchange devono solo preoccuparsi di quelle di tipo ContractTransaction quando controllano le transazioni in un blocco. 
> - Poiché la prima transazione di ogni blocco deve essere MinerTransaction, puoi saltarla o trascurarla quando stai traversando la blockchain. 
> - Il sistema NEO tratta la transazione come unitá di registrazione.
>

### Gestione dei Prelievi degli Utenti

Per gestire i prelievi degli utenti per gli asset globali, l'exchange deve fare quanto segue:

1. In NEO-CLI, eseguire `open wallet <path>` per aprire il wallet.

2. Registrare le transazioni di prelievo dell'utente e modificare il saldo dell'utente.

3. (Facoltativo) Il servizio clienti gestisce le richieste di prelievo.

4. inviare la tranzazione all'indirizzo di prelievo dell'utente utilizzando il metodo API di NEO-CLI, `sendtoaddress <asset_id> <address> <value>`. Per maggiori informazioni, fare riferimento a [Metodo sendtoaddress](node/api/sendtoaddress.html).

   - `<asset_id>` ：ID dell'asset
   - `<address>` ：Indirizzo di prelievo
   - `<value>` ：Importo del prelievo
   
   E' possibile anche inviare una transazione a un lotto di indirizzi utilizzando l'API del [Metodo sendmany](node/api/sendmany.html).

5. Estrarre l'ID della transazione dai dettagli della transazione restituiti nel formato JSON e in seguito registrarlo nel database.

6. Una volta confermata dalla blockchain, contrassegnare la transazione di prelievo come avvenuta. 
  
   Similarmente al monitoraggio dei depositi, anche i prelievi devono essere monitorati. Se l'ID della transazione di prelievo viene trovato nella blockchain, significa che questa transazione è già stata confermata ed è un prelievo avvenuto con successo.

> [!Nota]
>
> -  Qui <value> si riferisce all'importo effettivo, invece che dell'importo moltiplicato per  10^8.
> -  La quantità dei NEO trasferiti deve essere un numero intero; altrimenti, la blockchain non lo confermerà poiché le monete nel wallet saranno imprecise. Sarà necessario ricostruire l'indice del wallet, per ricalcolare le transazioni e il cambiamento del wallet.

## Gestione delle Transazioni di Asset NEP-5

### Ricezione di Notifiche sui Depositi degli Utenti 

Per gli asset NEP-5, l'exchange deve ottenere la notifica dei depositi degli utenti. La notifica per ogni blocco viene registrata in un file JSON, il quale include tutte le informazioni di ogni transazione NEP-5.

Per ottenere i file di notifica, esegui il seguente comando:

```
dotnet neo-cli.dll --rpc --record-notifications
```

Una cartella "Notifications" è generata sotto il percorso root, come mostrato di seguito:

![1](../assets/notification_1.jpg)

#### ![2](../assets/notification_2.jpg)

#### Notifiche del file JSON

Quanto segue mostra un esempio del contenuto del file di notifica.

```json
[
{
    "txid": "0x65d62a736a73c4d15dc4e4d0bfc1e4bbc4ef220e163625d770eb05577b1afdee",
    "contract": "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "state":
    {
        "type": "Array",
        "value": [
        {
            "type": "ByteArray",
            "value": "7472616e73666572"
        },
        {
            "type": "ByteArray",
            "value": "d336d7eb9975a29b2404fdb28185e277a4b299bc"
        },
        {
            "type": "ByteArray",
            "value": "eab336cac807707295afa7e7da2f4683237f612a"
        },
        {
            "type": "ByteArray",
            "value": "006ad42d100100"
        }]
    }
}]
```

In questo file, c'è un array di notifiche con un solo oggetto, il che significa che un solo evento NEP-5 è innescato nel blocco. I parametri relativi a una transazione nel file sono i seguenti:

-  **contract**: L'hash dello script di uno smart contract, dal quale l'exchange può identificare il tipo di asset. Per esempio, "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9" è l'hash dello script e l'identificazione unica dell'asset RPX.

-  I quattro oggetti inclusi nell'array "state":

   [evento, dall'account, all'account, quantità]

   -  Il primo oggetto di tipo "bytearray" e il valore "7472616e73666572", come mostrato nell'esempio, può essere convertito nella stringa "transfer". "transfer" è un metodo in NEP5 che rappresenta il trasferimento di un asset.
   -  Il secondo oggetto nell'array è l'indirizzo dell'account dal quale l'asset è trasferito. Il suo tipo "bytearray" e il valore "d336d7eb9975a29b2404fdb28185e277a4b299bc“ può essere convertito in "Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU". Nota che per la stringa esadecimale con il prefisso "0x", è processato come Big-Endian (Alto/Basso); altrimenti, è processato come Small-Endian (Basso/Alto).
   -  Il terzo oggetto nel'array è l'indirizzo dell'account al quale l'asset è trasferito. Se l'indirizzo è un indirizzo di un account exchange, è una transazione di deposito.
   -  Il quarto oggetto nell'array è la quantità trasferita. Ci sono due tipi di quantità, integer e bytearray. Quando si tratta di questo valore, l'exchange dovrebbe prestare particolare attenzione per le transazioni di tipo integer.

### Interrogazione del Saldo dell'Utente

Per interrogare il saldo dell'utente, l'exchange deve fare quanto segue:

1. Costruire i file JSON per invocare tre metodi (`balanceOf`, `decimals`, e `symbol`) tramite l'API PRC invokefunction. 
2. Inviare i file JSON al server NEO RPC.
3. Calcolare il saldo dell'utente in base ai valori restituiti.

#### invokefunction

In JSON, Il corpo della richiesta di un'invokefunction generale è nel seguente formato: 

```
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "script hash",
    "method name",
    [
      {
        "optional arguments"
      }
    ]
  ],
  "id": 1
}
```

È necessario sostituire queste stringhe quando si esegue una query sul saldo dell'utente:

- script hash

  Lo script hash di un token NEP-5 che stai interrogando. Ad esempio, puoi trovare che l'hash dello script di RPX è: *0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9*.


- method name

  Il nome del metodo che stai invocando. Per interrogare il saldo dell'utente, è necessario invocare questi tre metodi:

  **balanceOf**

  - Sintassi: `public static BigInteger balanceOf(byte[] account)`
  - Osservazioni: "balanceOf" restituisce il saldo del token dell' '''account'''.

  **decimals**

  - Sintassi: `public static byte decimals()`
  - Osservazioni: "decimals" restituisce il numero dei decimali usati dal token.

  **symbol**

  - Sintassi: `public static string symbol()`
  - Osservazioni: "symbol" Restituisce il simbolo del token.


- Argomenti opzionali

  Opzionale. Se il metodo che stai invocando richiede argomenti, puoi passarli costruendo questi parametri in un array. Per esempio, "balanceOf" in NEP-5 restituisce il saldo del token dell' "account":

  `public static BigInteger balanceOf(byte[] account)`

  Quindi è necessario passare l'account come argomento nel metodo "balanceOf".

#### Esempio

##### **Invocare il balanceOf**

Supponiamo che l'indirizzo dell'account sia AJShjraX4iMJjwVt8WYYzZyGvDMxw6Xfbe, è necessario convertirlo in tipo Hash160 e costruire questo parametro come oggetto JSON:

```json
{
    "type": "Hash160",
    "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
}
```

In seguito è possibile costruire il messaggio JSON come segue:

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
      }
    ]
  ],
  "id": 3
}
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00e1f505"
            }
        ]
    }
}
```

Restituisce "00e1f505" che può essere convertito in numero intero 100000000.

##### **Invocare i decimali**

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "decimals", 
    []
    ],
  "id": 2
}
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 2,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.156",
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ]
    }
}
```

Restituisce un'integer 8.

##### **Invocazione del symbol**

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "symbol", 
    []
    ],
  "id": 1
}
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.141",
        "stack": [
            {
                "type": "ByteArray",
                "value": "525058"
            }
        ]
    }
}
```

Restituisce "525058" che può essere convertito nella stringa "RPX".

##### **Calcolo del Saldo dell'Utente**

In base a tutti i valori restituiti, possiamo calcolare il saldo dell'utente come segue:
Saldo = 100000000/10<sup>8</sup> RPX = 1 RPX

### Trattare con i Prelievi degli Utenti

Lo scambio può scegliere uno dei seguenti modi per inviare risorse NEP-5 agli utenti:

- Comando NEO-CLI: `send`

- Metodo RPC: `sendtoaddress`
- Metodo PRC: `sendmany`

#### Comando NEO-CLI: send

##### Sintassi

`send <txid|script hash> <address> <value> [fee = 0]`

##### Parametri

- txid|script hash: l'ID dell'asset.

- address: l'indirizzo di pagamento.

- value: l'importo del trasferimento.

- fee: Questo parametro può essere lasciato vuoto. Il valore predefinito è 0.


Questo comando verifica la password del wallet.

##### Esempio

Per trasferire 100 RPX all'indirizzo *AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b*, inserire quanto segue:

```
send 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100
```

Se è necessario inviare asset globali, è sufficiente modificare il primo parametro in txid. Ad esempio, 
Il txid di NEO: 0Xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b
Il txid di GAS: 0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

#### Metodo RPC: sendtoaddress

La chiave "param" include un array di almeno tre parametri.

`"params":[script hash, address, amount, fee(optional), change address(optional)]`

Ad esempio, per inviare 1 RPX a *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* , costruire il file JSON come segue e inviarlo al server RPC.

Corpo di richiesta:

```json
{
    "jsonrpc":"2.0",
    "method":"sendtoaddress",
    "params":[
        "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
        "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg",
        "1",
        "0",
        "ARkJ8QcVdYL68WRvN3wj3TSvXX8CgmC73Z"
    ],
    "id":1
}
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
    "jsonrpc":"2.0",
    "id":1,
    "result":{
        "txid":"0xc6d4bf7c62fb47e0b2a6e838c3a1ca297622a1b1df7ceb2d30fa4ef8b7870700",
        "size":219,
        "type":"InvocationTransaction",
        "version":1,
        "attributes":[
            {
                "usage":"Script",
                "data":"5305fbbd4bd5a5e3e859b452b7897157eb20144f"
            }
        ],
        "vin":[

        ],
        "vout":[

        ],
        "sys_fee":"0",
        "net_fee":"0",
        "scripts":[
            {
                "invocation":"4054fbfca678737ae164ebf0e476da0c8215782bc42b67ae08cf4d8a716eeef81fcc17641e7f63893c3e685fb7eb1fb8516161c5257af41630f4508dde3afa3a8c",
                "verification":"210331d1feacd79b53aeeeeb9de56018eadcd07948675a50258f9e64a1204b5d58d1ac"
            }
        ],
        "script":"0400e1f50514d710f6f3f0bad2996a09a56d454cfc116a881bfd145305fbbd4bd5a5e3e859b452b7897157eb20144f53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166187b7883718089c8",
        "gas":"0"
    }
}
```

#### Metodo RPC: sendmany

La chiave "param" include un array di almeno un parametro:

`"params":[[], fee(optional), change address(optional)]`

Ad esempio, per inviare 15.5 RPX e 0.0001 GAS a *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* e il `change address` è anch'esso *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg*, è possibile costruire il file JSON come segue e inviarlo al server RPC.

Corpo di richiesta:

```json
{
    "jsonrpc":"2.0",
    "method":"sendmany",
    "params":[
        [
            {
                "asset":"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
                "value":"15.5",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value":"0.0001",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],"0.00001","AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
    ],
    "id":1
}
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xe1351c9c9f2205a801d1b04f0df2d65fb4b1692d7d3b06cf41e0712fd1b12c9c",
        "size": 373,
        "type": "InvocationTransaction",
        "version": 1,
        "attributes": [
            {
                "usage": "Script",
                "data": "6d64dc9e50af8e911247436b264c8f7d791ad58c"
            }
        ],
        "vin": [
            {
                "txid": "0x9f0a28a912527604ab4b7d5e8b8d1a9b57631fcbab460132811ae7b6ed1ccaff",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.0001",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.01359",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0.00001",
        "scripts": [
            {
                "invocation": "40644ab915419dbf855a52d5c75596e80b78c8e928cc0ce91ae6afc3b75a0c31ee54efe1836f9ec232f6c42dcb3ace0bfdc688e626944fa20970a76064975eade9",
                "verification": "2103d4b6fc2d116855f86a483d151182f68e88e6ddd13f3f1f3631e36300aac122bfac"
            }
        ],
        "script": "04801f635c14d710f6f3f0bad2996a09a56d454cfc116a881bfd146d64dc9e50af8e911247436b264c8f7d791ad58c53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166f871fb30fc859b77",
        "gas": "0"
    }
}
```

### Vedi anche

[NEP-5 Token Standard](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki "NEP5")

[Esempi di Trasformazione dei Dati](https://github.com/PeterLinX/NeoDataTransformation)

## (Facoltativo) Distribuzione di GAS agli Utenti

L'exchange può determinare se distribuire GAS agli utenti. Il GAS è utilizzato per pagare la blockchain NEO per la registrazione e i servizi aggiuntivi.

### Cos'è GAS?

NeoGas (abbreviato GAS) rappresenta il diritto di utilizzare la Blockchain di Neo. Ci saranno 100 milioni di GAS in totale. I GAS vengono generati insieme a ogni nuovo blocco. L'emissione rallenterà a un ritmo lentamente decrescente, GAS passerà attraverso un processo di generazione che lo farà passare da zero a 100 milioni di GAS totali. Una volta ottenuto NEO, GAS verrà generato nel sistema seguendo i vari algoritmi.

### Calcolo dell'importo disponibile di GAS

- *GAS disponibile = f(neo_amount, Δt_const)*

  -  Δt_const = t_end - t_start
    -  t_end = il momento in cui Neo entra nello stato di spesa
    -  t_start = il momento in cui Neo entra nello stato di non speso

  Δt_const è fisso, quindi anche il Gas disponibile è di una quantità fissa. Questo importo è una funzione della quantità di Neo detenuta dall'utente e la durata tra il momento in cui ha trasferito questa quantità di Neo nel suo indirizzo e all'infuori del suo indirizzo.


- *GAS non disponibile = f(neo_amount, Δt_var)*

  - Δt_var = t - t_start
    - t è l'ora corrente
    - t_start = nel momento in cui Neo entra nello stato di non speso

  L'ora corrente è una variabile, quindi anche la quantità di GAS non disponibile aumenta nel tempo, il che significa che è anch'essa una variabile.

### Distribuzione di GAS agli Utenti

Supponiamo che tutti gli indirizzi di exchange siano memorizzati in un unico portafoglio, la seguente tabella mostra la procedura e la formula di calcolo con la quale l'exchange distribuisce GAS all'utente A.

![gasflow_en](sc/assets/gasflow_en.png)

Più breve è l'intervallo dello snapshot, più preciso è il calcolo. Se l'intervallo dello snapshot non è uniforme, utilizzare il metodo di calcolo della media ponderata.

### Reclamo del GAS

GAS diventa rivendicabile dopo che l'utente ha trasferito il proprio NEO. Ad esempio, **qualcuno ha NEO nell'indirizzo A e i GAS non sono reclamabili, quando trasferisce il suo NEO a se stesso (indirizzo A) i NEO GAS sono reclamabili.**

Nella seguente tabella sono elencati i passaggi di rivendicazione GAS e i comandi corrispondenti.

| #    | Steps                                    | Comandi                                  |
| ---- | :--------------------------------------- | ---------------------------------------- |
| 1    | Esegui NEO-CLI                              | `./neo-cli.dll /rpc`                     |
| 2    | Controlla la versione del client                 | `version`                                |
| 3    | Controlla l'altezza sincronizzata del client ( Altezza: altezza / altezza intestazione, Nodi: quantità di nodi connessi). | `show state`                             |
| 4    | Crea un wallet                          | `create wallet /home/NeoNode/test.db3`   |
| 5    | Apri il wallet creato nell'ultimo passaggio | `open wallet /home/NeoNode/test.db3`     |
| 6    | Controlla l'elenco degli indirizzi nel wallet     | `list address`                           |
| 7    | Controlla l'elenco degli indirizzi nel wallet           | `list asset`                             |
| 8    | Controlla il saldo di GAS nel wallet | `show gas`                               |
| 9    | Trasferisci NEO al tuo indirizzo（e.g. AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1）cambiare lo stato di Gas per essere reclamato. | `send NEO AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 10   | Ottieni nuovamente i dettagli del saldo di GAS nel wallet. Ora lo stato di tutti i GAS dovrebbe essere disponibile alla reclamazione. | `show gas`                               |
| 11   | Reclama GAS.                               | `claim gas`                              |
| 12   | Controlla nuovamente il saldo.                     | `list asset`                             |

