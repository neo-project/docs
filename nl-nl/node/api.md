# API Referentie

Elke node in de Neo-CLI verschaft een API-interface voor het verkrijgen van blockchain-data van een node, waardoor het makkelijk is om blockchain-applicaties te ontwikkelen. De interface wordt verschaft via [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) en het onderliggende protocol gebruikt HTTP/HTTPS voor communicatie. Om een node te starten die een RPC-service verschaft, dient de volgende command te worden uitgevoerd:

`dotnet neo-cli.dll /rpc`

Om toegang te krijgen tot de RPC-server via HTTPS dient het configuratie-bestand `config.json` te worden aangepast en domeinnaam, certificaat en wachtwoord te worden ingesteld, alvorens de node te starten:

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

Nadat de JSON-RPC-server is opgestart, zal het de volgende ports volgen, welke horen bij het hoofdnetwerk en testnetwerken:

(Lees voor P2P- en WebSocket-informatie [Node/Introduction](introduction.md).)

|                | (Main Net)   | (Test Net)    |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Lijst van Commands

| Command                                         | Referentie                              | Uitleg                                                                                       | Opmerkingen       |
| :---------------------------------------------- | :-------------------------------------- | :--------------------------                                                                  | :-------- 
| [getbalance](api/getbalance.md)                 | \<asset_id>                             | Weergeeft het saldo van de bijbehorende asset in de wallet a.d.h.v. het gegeven assetnummer  | Wallet moet geopend zijn
| [getbestblockhash](api/getbestblockhash.md)     |                                         | Weergeeft de hash van de hoogste block in de hoofdketen                                      |          
| [getblock](api/getblock.md)                     | \<hash> [verbose=0]                     | Weergeeft de informatie die past bij het block waarvan de hashwaarde gegeven is               |          
| [getblock](api/getblock2.md)                    | \<index> [verbose=0]                    | Weergeeft de informatie die past bij het block waarvan de index gegeven is                    |          
| [getblockcount](api/getblockcount.md)           |                                         | Weergeeft het aantal blocks in de hoofdketen                                                 |          
| [getblockhash](api/getblockhash.md)             | \<index>                                | Weergeeft de hashwaarde van het block waarvan de index gegeven is                             |          
| [getconnectioncount](api/getconnectioncount.md) |                                         | Weergeeft de huidige hoeveelheid connecties voor de node                                     |          
| [getrawmempool](api/getrawmempool.md)           |                                         | Weergeeft de lijst van nog niet bevestigde transacties in de memory pool                     |          
| [getrawtransaction](api/getrawtransaction.md)   | \<txid> [verbose=0]                     | Weergeeft de transactie-informatie die past bij de gegeven hashwaarde                        |          
| [gettxout](api/gettxout.md)                     | \<txid> \<n>                            | Weergeeft de verandering door een transactie die past bij de gegeven hashwaarde en index     |          
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Broadcast een transactie naar het network.                                                   | Zie de [network protocol](network-protocol.md)documentatie.         |
| [sendtoaddress](api/sendtoaddress.md)           | \<asset_id> \<address> \<value> [fee=0] | Maak een bedrag over naar een bepaald adres                                                  | Wallet moet geopend worden   
| submitblock                                     | \<hex>                                  | Dien een nieuw blok in                                                                       | Node moet een consensus node zijn 


## GET Request Voorbeeld

Een typische JSON-RPC Get request format is als volgt:

(Het voorbeeld hieronder geeft weer hoe het aantal blocks in de hoofdketen kan worden verkregen)

Request URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Na het sturen van de request, ontvang je het volgende antwoord:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POST Request Voorbeeld

Een typische JSON-RPC Post request format is als volgt:

(Het voorbeeld hieronder geeft weer hoe het aantal blocks in de hoofdketen kan worden verkregen)

Request URL:

```
http://somewebsite.com:10332
```

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

Na het sturen van de request, ontvang je het volgende antwoord:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## Test Tools

Het is mogelijk om de Chrome-extensie Postman te gebruiken om bij testen te helpen (het installeren van de Chrome-extensie vereist een verbinding met het internet). Hieronder volgt een screenshot van een test:

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Overig

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

