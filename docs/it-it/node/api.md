# Riferimento API

Ogni nodo in Neo-CLI fornisce un'interfaccia API per ottenere i dati della blockchain da un nodo rendendo facile lo sviluppo di applicazioni blockchain. L'interfaccia è fornita mediante [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) e il protocollo sottostante utilizza HTTP/HTTPS per la comunicazione. Per avviare un nodo che fornisca un servizio RPC, eseguire i seguenti comandi:

`dotnet neo-cli.dll /rpc`

Per accedere al server RPC via HTTPS, modificare il file di configurazione config.json prima di avviare il nodo e impostare il nome del dominio, il certificato e una password:

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "RPC": {
      "Port": 10331,
      "SslCert": "YourSslCertFile.xxx",
      "SslCertPassword": "YourPassword"
    }
  }
}                                     
```
Dopo l'avvio del server JSON-RPC, questo monitorerà le seguenti porte, corrispondenti alla rete principale (Main Net) e alla rete di test (Test Net):

Per le informazioni P2P e Websocket vedere [Nodo/Introduzione](introduction.md).

|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Lista dei Comandi

| Comando                                       | Riferimento                                      | Spiegazione                         | Commenti       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | Esporta la chiave privata dell'indirizzo specificato | Occorre aprire il wallet      |
| [getaccountstate](api/getaccountstate.md)          | \<address>                             |Controlla le informazioni dell'asset dell'account in base all'indirizzo dell'account  |    |
| [getassetstate](api/getassetstate.md)    | \<asset_id>                              | Interroga le informazioni dell'asset in base al numero di asset specificato            |          |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Restituisce il saldo dell'asset corrispondente nel wallet in base al numero di asset specificato.   | Occorre aprire il wallet   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Ottiene l'hash del blocco più alto nella chain principale          |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Restituisce le corrispondenti informazioni del blocco in base al valore hash specificato        |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Restituisce le corrispondenti informazioni del blocco in base all'indice specificato          |          |
| [getblockcount](api/getblockcount.md)    |                                         | Ottiene il numero dei blocchi nella chain principale                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Restituisce il corrispondente valore hash del blocco in base all'indice specificato        |          |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | Restitusce le commissioni di sistema prima del blocco in base all'indice specificato      |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Ottiene il numero corrente di connessioni per il nodo                 |          |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Restituisce le informazioni riguardo il contratto in base allo script hash specificato |                              |
| [getnewaddress](api/getnewaddress.md)    |                                          | Crea un nuovo indirizzo                    | Occorre aprire il wallet      |
| [getrawmempool](api/getrawmempool.md)    |                                         | Ottiene una lista delle transazioni non confermate in memoria          |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Restituisce le corrispondenti informazioni sull'output (cambio) della transazione in base al valore hash e all'indice specificato         |          |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Restituisce il valore memorizzato in base allo script hash e alla chive del contratto  |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Restituisce le corrispondenti informazioni sul prodotto delle transazioni (cambio) basate su uno specifico hash o indice |          |
| [getpeers](api/getpeers.md)              |                                          | Ottiene una lista di nodi che sono correntemente connessi/disconnessi da questo nodo        |          |
| [getversion](api/getversion.md)          |                                          | Ottiene le informazioni sulla versione di questo nodo     |                              |
| [invoke](api/invoke.md)                  | \<script_hash>  \<params>                | Invoca uno smart contract a uno script hash specificato con i parametri dati |                              |
| [invokefunction](api/invokefunction.md)  | \<script_hash>  \<operation>  \<params>  | Invoca uno smart contract a uno script hash specificato, passandogli un'operazione e i suoi parametri |                              |
| [invokescript](api/invokescript.md)      | \<script>                                | Esegue uno script attraverso la macchina virtuale e restituisce i risultati |                              |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Trasmette una transazione nella rete. Vedi la documentazione sul [Protocollo di Rete](network-protocol.md).                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Trasferisce a un indirizzo specificato                     | Occorre aprire il wallet   |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | Ordina un trasferimento in lotto                       | Occorre aprire il wallet   |
| submitblock                              | \<hex>                                  | Invia nuovi blocchi                      | Occorre essere un nodo di consenso |
| [validateaddress](api/validateaddress.md) | \<address>                               | Verifica che l'indirizzo sia un indirizzo NEO corretto          |          |


## Esempio di richiesta GET

Un tipico formato di richiesta JSON-RPC GET è il seguente:

Quanto segue è un esempio di come ottenere il numero di blocchi nella chain principale.

Richiesta URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Dopo aver inviato la richiesta, otterrai la seguente risposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## Esempio di richiesta POST

Il formato di una tipica richiesta JSON-RPC POST è il seguente:

Quanto segue è un esempio di come ottenere il numero di blocchi nella chain principale.

Richiesta URL:

```
http://somewebsite.com:10332
```

Corpo della richiesta：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

Dopo aver inviato la richiesta, otterrai la seguente risposta：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## Strumenti di Test

E' possibile usare Postman un'estensione di Chrome per facilitare il test (L'installazione dell'estensione di Chrome richiede una connessione a internet), quanto segue è uno screenshot del test:

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Altro

[Lista dei Comandi C# JSON-RPC ](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)
