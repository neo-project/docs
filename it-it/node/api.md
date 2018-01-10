# Riferimento API

Ogni nodo in Neo-CLI fornisce un'interfaccia API per ottenere i dati sulla blockchain da un nodo, rendendo facile lo sviluppo di applicazioni blockchain. L'interfaccia è fornita mediante [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), e il protocollo sottostante utilizza HTTP/HTTPS per le comunicazioni. Per iniziare un nodo che fornisca un servizio RPC, eseguire i seguenti comandi:

`dotnet neo-cli.dll /rpc`

Per accedere al server RPC via HTTPS, modificare il file di configurazione config.json prima di avviare il nodo e impostare il nome di dominio, il certificaro e una password:

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```
dopo l'avvio del server JSON-RPC, esso monitorerà le seguenti porte, corrispondenti alla rete Main (rete principale) e alla rete Test:

Per le informazioni P2P e Websocket vedi [Nodo/Introduzione](introduction.md).

|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Lista dei Comandi

| Comando                                       | Riferimento                                      | Spiegazione                         | Commenti       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getaccountstate](api/getaccountstate.md)          | \<address>                             |controlla le informazioni sugli asset dell'account dell'indirizzo di riferimento  |    |
| [getassetstate](api/getassetstate.md)    | \<asset_id>                              | Interroga le informazioni sugli asset in base al numero di asset specificato            |          |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Restituisce il saldo degli asset corrispondenti nel wallet secondo il numero di asset specificato.   | Occorre aprire il wallet   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Ottiene l'hash del blocco più alto nella chain           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Restituisce le informazioni corrispondenti al blocco secondo il valore hash specificato        |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Restituisce le corrispondenti informazioni sul blocco secondo l'indice specificato          |          |
| [getblockcount](api/getblockcount.md)    |                                         |Ottiene il numero dei blocchi nella Main chain                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Restituisce il valore hash del corrispondente blocco basato sull'indice specificato        |          |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | Restitusce la commissione di sistema prima del blocco secondo l'indice specificato      |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Ottiene il numero corrente di connessioni per il nodo                 |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | Ottiene un lista delle transazioni non confermate in memoria          |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Restituisce le informazioni sulle transazioni correnti basate su uno specifico valore hash         |          |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Restituisce il valore salvato basato sullo scripthash e chive del contratto  |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Restituisce le corrispondenti informazioni sul prodotto delle transazioni (cambio) basate su uno specifico hash o indice |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Trasmette una transazione nella rete. vedi la documentazione [network protocol](network-protocol.md).                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Trasferisce a un indirizzo specifico                     | Occorre aprire il wallet   |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | Ordina un trasferimento in lotto                       | Occorre aprire il wallet   |
| [getnewaddress](api/getnewaddress.md)    |                                          | Crea un nuovo indirizzo                     | Occorre aprire il wallet   |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | Esporta la chiave privata dell'indirizzo specificato | Occorre aprire il wallet   |
| submitblock                              | \<hex>                                  | Invia nuovi blocchi                      | Occorre essere un nodo di consenso |
| [validateaddress](api/validateaddress.md) | \<address>                               | Verifica che l'indirizzo sia un indirizzo NEO corretto          |          |
| [getpeers](api/getpeers.md)              |                                          | Ottiene una lista di nodi che sono correntemente connessi/disconnessi da questo nodo        |          |

## Esempio di richiesta GET

Una tipico formato di richiesta JSON-RPC GET avviene come di seguito:

Quanto segue è un esempio di come ottenere il numero di blocchi nella chain principale.

Richiesta URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Dopo aver inviato la richiesta, riceverai la seguente risposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## Esempio di richiesta POST

Il formato di una tipica richiesta JSON-RPC POST avviene come di seguito:

Qaunto segue è un esempio di come ottenere il numero dei blocchi nella chain principale.

richiesta URL:

```
http://somewebsite.com:10332
```

Richiesta Body：

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

Puoi usare l'estensione di Chrome in Postman per facilitare il test (L'installazione dell'estensione di Chrome richiede una connessione a internet), quanto segue è uno screenshot del test:

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Altro

[C# JSON-RPC Lista di Comandi](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)
