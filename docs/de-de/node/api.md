# NEO Node API

Jede Node mit NEO-CLI bietet ein API Interface, mit dem Blockchaininformationen von einer Node geholt werden können. Dies macht es einfacher, Blockchainanwendungen zu entwickeln. Das Interface wird mittels [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) bereitgestellt; das darunterliegende Protokoll nutzt HTTP/HTTPS für die Kommunikation. Um eine Node für den RPC Service zu starten, nutzen Sie folgenden Befehl:

`dotnet neo-cli.dll /rpc`

Um auf den RPC Server mittels HTTPS zuzugreifen, müssen Sie die Konfigurationsdatei `config.json` vor dem Starten der Node ändern sowie einen Domainnamen, ein Zertifikat und ein Passwort setzen:

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

Der JSON-RPC Server hört nach dem Start auf folgenden Ports:


|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

P2P und WebSocket Informationen finden Sie [hier](introduction.md).

## Befehle

| Command                                  | Reference                                      | Beschreibung                       | Kommentar      |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getaccountstate](api/getaccountstate.md)          | \<address>                             | Prüft Assetinformationen eines Accounts  |    |
| [getassetstate](api/getassetstate.md)    | \<asset_id>                              | Fragt Asset Informationen zu einer bestimmten Assetnummer ab             |          |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Gibt den Kontostand eines Assets in der Wallet aus, basierend auf der spezifischen Asset-ID.   | Die Wallet muss geöffnet sein!   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Holt den Hashwert des höchsten Blocks der Blockchain.           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Holt die zu einem bestimmten Hashwert gehörenden Blockinformationen.         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Holt die zu einem bestimmten Index gehörenden Blockinformationen.         |          |
| [getblockcount](api/getblockcount.md)    |                                         | Holt die Anzahl der Blocks aus der Hauptblockchain.                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Gibt den Hashwert eines bestimmten Blocks anhand des Block Index aus.         |          |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | Gibt die Systemgebühren eines bestimmten Blocks basierend auf dem Index aus    |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Holt die aktuelle Zahl an Verbindungen für eine Node.                |          |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Gibt Informationen zu einem Contract basierend auf dem Scripthash aus. |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | Holt die Liste der noch nicht bestätigten Transaktionen aus dem Speicher.           |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Gibt die, zu einem bestimmten Transaktionshash gehörenden, Informationen aus.         |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Gibt den gespeicherten Wert basierend auf dem Scripthash und dem Schlüssel aus |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Gibt die entsprechenden Transaktionsoutput Informationen (zurückgegebene Änderung) basierend auf dem angegebenen Hash und Index zurück.|          |
| [invoke](api/invoke.md)      | \<script_hash> \<params>      | Ruft einen Smart Contract auf einem bestimmten Scripthash mit gegebenen Parametern auf |         |
| [invokefunction](api/invokefunction.md) | \<script_hash>  \<operation>  \<params>   | Ruft einen Smart Contract auf einem bestimmten Script Hash auf und übergibt Operationen und Parameter. |     |
| [invokescript](api/invokescript.md) | \<script>   | Lässt ein Script durch die VM ausführen und gibt das Ergebnis aus. |      |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Sendet eine Transaktion über das NEO Netzwerk. Es gibt mehrere Arten von Transaktionen, wie in der Dokumentation zum [Netzwerkprotokoll](../network-protocol.md) dargestellt.                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Transferiert an eine bestimmte Adresse.                     | Die Wallet muss geöffnet sein  |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | Vielfachtransaktionen                      | Die Wallet muss geöffnet sein.   |
| submitblock                              | \<hex>                                  | Sendet neue Blöcke                     | Erfordert eine Consensus Node |
| [getnewaddress](api/getnewaddress.md)    |                                          | Generiert eine neue Adresse                    | Die Wallet muss geöffnet sein  |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | Exportiert den privaten Schlüssel einer Adresse | Die Wallet muss geöffnet sein   |
| [getpeers](api/getpeers.md)              |                                          | Holt eine Liste der Nodes die aktuell verbunden / nicht verbunden sind.          |          |
| [validateaddress](api/validateaddress.md) | \<address>                               | Überprüft, ob eine Adresse eine gültige NEO-Adresse ist.           |          |
| [getversion](api/getversion.md)              |                                          | Holt die Versionsinformationen der Node       |          |

## GET request Beispiel

Eine typische JSON-RPC GET Request sieht folgendermaßen aus:

Das folgende Beispiel zeigt, wie die Zahl der Blöcke in der Hauptchain abgefragt werden können:

Request URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Nach dem Senden der Request erhält man folgende Antwort:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## POST request Beispiel

Das Format einer typischen JSON-RPC Post Request sieht folgendermaßen aus:

Das folgende Beispiel zeigt, wie die Zahl der Blöcke in der Hauptchain abgefragt werden können:

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

Nach dem Senden der Request erhält man folgende Antwort:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## Test Tools

Sie können die Chromeerweiterung Postman nutzen, um die Tests zu erleichtern (Die Installation von Chromeerweiterungen erfordert eine Internetverbindung):

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Verweise

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

