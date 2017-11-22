# NEO Node API

Jede Node mit NEO-CLI bietet ein API Interface, mit dem Blockchaininformationen von einer Node geholt werden können. Dies macht es einfacher, Blockchainanwendungen zu entwickeln. Das Interface wird mittels [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) bereitgestellt; das darunterliegende Protokoll nutzt HTTP/HTTPS für die Kommunikation. Um eine Node für den RPC Service zu starten, nutzen Sie folgenden Befehl:

`dotnet neo-cli.dll /rpc`

Um auf den RPC Server mittels HTTPS zuzugreifen, müssen Sie die Konfigurationsdatei `config.json` vor dem Starten der Node ändern sowie einen Domainnamen, ein Zertifikat und ein Passwort setzen:

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

Der JSON-RPC Server hört nach dem Start auf folgenden Ports:


|                | （Main Net） | （Test Net） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

P2P und WebSocket Informationen finden Sie [hier](introduction.md).

## Befehle

| Command                                  | Reference                                      | Beschreibung                       | Kommentar      |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Gibt den Kontostand eines Assets in der Wallet aus, basierend auf der spezifischen Asset-ID.   | Die Wallet muss geöffnet sein!   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Holt den Hashwert des höchsten Blocks der Blockchain.           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Holt die zu einem bestimmten Hashwert gehörenden Blockinformationen.         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Holt die zu einem bestimmten Index gehörenden Blockinformationen.         |          |
| [getblockcount](api/getblockcount.md)    |                                         | Holt die Anzahl der Blocks aus der Hauptblockchain.                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Gibt den Hashwert eines bestimmten Blocks anhand des Block Index aus.         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | Holt die aktuelle Zahl an Verbindungen für eine Node.                |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | Holt die Liste der noch nicht bestätigten Transaktionen aus dem Speicher.           |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Gibt die, zu einem bestimmten Transaktionshash gehörenden, Informationen aus.         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Gibt die entsprechenden Transaktionsoutput Informationen (zurückgegebene Änderung) basierend auf dem angegebenen Hash und Index zurück.|          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Sendet eine Transaktion über das NEO Netzwerk. Es gibt mehrere Arten von Transaktionen, wie in der Dokumentation zum [Netzwerkprotokoll](../network-protocol.md) dargestellt.                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Transferiert an eine bestimmte Adresse.                     | Die Wallet muss geöffnet sein  |
| submitblock                              | \<hex>                                  | Neuen Block senden                     | Erfordert eine Consensus Node |

## GET request Beispiel

Eine typische JSON-RPC GET request sieht folgendermaßen aus:

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

Das Format einer typischen JSON-RPC Post request sieht folgendermaßen aus:

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

