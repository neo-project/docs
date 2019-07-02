# Dokument für Exchange Developer
Dieses Dokument ist dafür vorgesehen, Exchange (Englisch für Austausch, Börse) Developern dabei zu helfen, NEO Knoten auf dem Exchange Server einzurichten und damit verbundenes Development von NEO Transaktionen abzuschließen. Bitte lesen Sie das [NEO White Paper](/de-de/index.md) und stellen Sie sicher, dass Sie die NEO Technologien und Hintergrundkenntnisse verstehen und besitzen.

Generell muss ein Exchange das Folgende tun:

- [Einen NEO Knoten (Node) auf dem Server installieren](#einen-neo-knoten-node-auf-dem-server-installieren)
- [Eine Wallet und Einzahlungsadresse erstellen](#eine-wallet-und-einzahlungsadresse-erstellen)
- [Global Assets Transaktionen behandeln](#global-assets-transaktionen-behandeln)
- [NEP-5 Assets Transaktionen behandeln](#nep-5-assets-transaktionen-behandeln)
- [(Optional) GAS an die User verteilen](#optional-gas-an-die-user-verteilen)

## Einen NEO Knoten (Node) auf dem Server installieren
Um einen NEO Knoten auf dem Exchange Server zu installieren, machen sie Folgendes:

1. Installieren Sie .NET Core Runtime auf dem Server, 1.0.1 und neuere Versionen.
2. Laden Sie das NEO-CLI Programm von Github herunter und aktivieren Sie den NEO Knoten.

Für mehr Information, siehe [NEO node introduction](/en-us/node/introduction.md).

## Eine Wallet und Einzahlungsadresse erstellen

### Über NEO-CLI

NEO-CLI ist ein Command-Line Client (Wallet) für Developer. Sie haben zwei Möglichkeiten, damit zu arbeiten:

- Benutzen Sie die CLI (Command-Line Interface) Befehle. Zum Beispiel können Sie eine Wallet erstellen, eine Adresse generieren, etc.
- Benutzen Sie den Remote Procedure Call (RPC). Zum Beispiel können Sie auf eine vorgesehene Adresse überweisen, die Informationen über einen bestimmten Block erlangen, die Informationen über eine bestimmte Transaktion oder einen bestimmten Handel erlangen, etc.

NEO-CLI bietet folgende Funktionen:

- Als eine Wallet verwaltet es Anlagen mittels der Command-Line.
	Um die Wallet zu aktivieren, geben Sie folgenden Befehl im NEO-CLI Verzeichnis ein:

  ```
  dotnet neo-cli.dll
  ```

	Um alle verfügbaren Befehle anzuzeigen, geben Sie Folgendes ein:

  ```
  help
  ```

	Für mehr Informationen, siehe [CLI Command Reference](/en-us/node/cli.md).
  
- Bietet APIs um Blockchain Daten der Knoten abzufragen. Die Interfaces werden durch [JSON-RPC](http://www.jsonrpc.org/specification) bereitgestellt, die darunterliegenden Kommunikationen benutzen HTTP/HTTPS Protokolle.
	
  Um einen Knoten zu starten, welcher RPC Dienste bietet, geben Sie folgendes im NEO-CLI Verzeichnis ein:

  ```
  dotnet neo-cli.dll /rpc
  ```

	Für mehr Informationen, siehe [API Reference](/en-us/node/api.md)
  
### Eine Wallet erstellen

Der Exchange muss eine Online Wallet erstellen, um die Einzahlungsadresse der User zu verwalten. Eine Wallet wird benutzt um die Informationen der Accounts (sowohl Public Keys als auch Private Keys), und die Verträge, zu speichern. Es ist der wichtigste Nachweis in den Händen des Users. Users müssen die Daten und die Passwörter der Wallet sicher aufbewahren. Sie dürfen diese Daten nicht verlieren oder weitergeben.
> Anmerkung:
>
> Exchanges müssen nicht für jede einzelne Adresse eine Wallet erstellen. Eine Online Wallet behält gewöhnlicherweise alle Einzahlungsadressen der User. Eine "Cold Wallet" (Offline Wallet) ist eine andere Speicheroption, die mehr Sicherheit gewährt.

Um eine Wallet zu erstellen, machen Sie Folgendes:

1. Geben sie `create wallet <path>` ein.

  `<path>` ist der Speicherort und Dateiname der Wallet. Die Datei kann jeder etwaige Typ sein, zum Beispiel:
  ```
  create wallet mywallet.db3
  ```
2. Legen Sie ein Passwort für die Wallet fest.

> Anmerkung:
>
> Die Wallet muss jederzeit offen sein, um auf Abhebungsanfragen der User zu reagieren. Aus Sicherheitsgründen sollten die Wallets auf einem unabhängigen Server ausgeführt werden, auf welchem die Firewall ordnungsgemäß konfiguriert ist, wie unten abgebildet.

|                    | Mainnet | Testnet |
| ------------------ | ------- | ------- |
| JSON-RPC via HTTPS | 10331   | 20331   |
| JSON-RPC via HTTP  | 10332   | 20332   |
| P2P                | 10333   | 20333   |
| websocket          | 10334   | 20334   |

### Einzahlungsadressen erzeugen

Eine Wallet kann mehrere Adressen lagern. Der Exchange muss eine Einzahlungsadresse für jeden User erzeugen.

Dafür gibt es zwei Möglichkeiten:

- Wenn der User das erste Mal einzahlt (NEO/NEO GAS), kann das Programm dynamisch eine NEO Adresse erzeugen. Der Vorteil hierbei ist, dass es nicht nötig ist die Adressen nach fixen Zeitintervallen zu erzeugen, während der Nachteil darin liegt, dass kein Backup der Wallet gemacht werden kann.
	
  Um dem Programm zu sagen, dynamisch Adressen zu erzeugen, benutzen Sie die NEO-CLI API [getnewaddress Methode](/en-us/node/api/getnewaddress.md). Die erzeugte Adresse wird returned.

- Der Exchange erstellt ein Bündel von NEO Adressen im Voraus. Wenn der User das erste mal NEO/NEO GAS einzahlt, ordnet der Exchange dem User eine Adresse zu. Der Vorteil hierbei ist, dass Backups der Wallets gemacht werden können. Der Nachteil liegt darin, dass man manuell Adressen erzeugen muss. 

  Um ein Bündel Adressen zu erzeugen, führen Sie den Befehl `create address [n]` aus. Die Adressen werden automatisch in die Datei address.txt exportiert. [n] ist optional. Der Standartwert ist 1. Um zum Beispiel 100 Adressen zu erzeugen, geben Sie `create address 100` ein.

> Anmerkung:
>
> Egal wofür Sie sich entscheiden, der Exchange muss die Adressen in eine Datenbank importieren und an User verteilen.

## Global Assets Transaktionen behandeln

### Programme für Einzahlungen und Auszahlungen erstellen

Für Global Assets muss der Exchange Programme erstellen, die folgende Funktionen vollziehen:

1. Neue Blocks über NEO-CLI API überwachen
2. Abhänging von den Transaktionsinformationen mit Einzahlungen umgehen
3. Die Daten aufzeichnen und speichern, welche den Exchange betreffen

#### Einzahlungen

Einzahlungen betreffend muss der Exchange Folgendes beachten:

- NEO Blockchain hat nur eine Hauptchain ohne Seitenchains, wird sich nicht teilen (fork), und wird keine isolierten Blocks haben.
- Eine Transaktion, die in der Blockchain aufgezeichnet wurde, kann nicht manipuliert werden, das heißt eine Bestätitung (confirmation) bedeutet einen Erfolg der Einzahlung.
- Allgemein ist das Guthaben einer Einzahlungsadresse in dem Exchange nicht gleichgesetzt mit dem Guthaben des Users auf dem Exchange. Dies tritt auf, weil:
  - Bei Abhebungen oder Überweisungen schaut die NEO Wallet über ein oder mehrere Adressen in der Wallet, findet das minimale Kleingeld welches die Anforderungen erfüllt, und nimmt dies als Input, anstatt von der angegebenen Adresse abzuheben (außer der Exchange schreibt einige Funktionen der NEO Wallet um, um den Bedürfnissen des Exchanges gerecht zu werden).
  - Andere Operationen welche zu Guthabenungleichheit führen können, z.B. wenn der Exchange einen Teil der Assets in die Cold Wallets transferiert.
- Es gibt mehr als zwei Assets (NEO und NEO GAS) in einer NEO Adresse. Mehrere Assets, die vom User gewünscht sind (z.b. Tokens) können dort gespeichert werden. Der Exchange sollte den Typ der Assets feststellen und festlegen, wenn ein User einzahlt. Weder dürfen andere Assets als NEO angesehen werden, noch darf NEO mit NEO GAS verwechselt werden.
- NEO Wallet ist ein voller Knoten (node), welcher online bleiben muss um mit Blocks zu synchonisieren. Sie können den Block-Synchonisationsstatus über den "show state" der CLI sehen. Die linke Seite ist die lokale Blockhöhe, die rechte Seite ist die Knoten-Blockhöhe.
- Auf dem Exchange sollte der Transfer zwischen Usern nicht auf der Blockchain aufgezeichnet werden. Generell sollte das Guthaben des Users direkt in der Datenbank bearbeitet werden. Nur Ein- und Auszahlungen sollten in der Blockchain aufgezeichnet sein.

#### Aufzeichnungen der Einzahlungen

Der Exchange muss Code schreiben, welcher jede Transaktion in einem Block überwacht und alle Transaktionen, die mit Exchange-Adressen verbunden sind, in einer Datenbank aufzeichnen. Wenn eine Einzahlung auftritt, muss das Guthaben des Users aktualisiert werden.

Developer können die `getblock <index> [verbose]` Methode des NEO-CLI API benutzen, um Informationen über einen Block zu bekommen. `<index>` ist der Block Index. `[verbose]` ist standardmäßig 0. Wenn `[verbose]` 0 ist, kehrt die serialisierte Blockinformation in Hexadezimal zurück (als return value der Methode). Sie sollten den Hex String deserialisieren, um detaillierte Informationen aus dem Block zu bekommen. Wenn `[verbose]` 1 ist, gibt die Methode die Informationen des Blocks im JSON Format wieder (als return value). Für mehr Informationen, siehe [getblock Methode](/en-us/node/api/getblock.md).

Die Information über den Block enthält den Input und Output der Transaktionen. Der Exchange muss alle mit dem Exchange verbundenen Transaktionen aufzeichnen. Der Output der Transaktionen sind Aufzeichnungen von Abhebungen der User. Wenn der Exchange eine seiner Adressen in dem Output der Transaktion sieht, muss es das NEO/NEO GAS Guthaben des Users aktualisieren, welchem diese Adresse gehört. Manche Exchange mögen es auch folgendermaßen machen: Wenn es eine Adresse des Exchanges als Output einer Transaktion findet, schreibt es die Details darüber nieder, und modifiziert das Guthaben erst nach mehreren Bestätigungen. (Außer wenn es sich mit den Operationen anderer Blockchains fügen muss wird dieses Verfahren nicht empfohlen.)

> Anmerkung:
>
> - Methode getblockcount gibt die Anzahl der Blocks in der Hauptchain wieder (return). Der erste Parameter von getblock ist "index", welcher der Block Index ist. Block Index = Block Höhe = Die Anzahl der Blöcke - 1. Wenn getblockcount 1234 wiedergibt, sollten Sie "getblock 1233" benutzen, um die Informationen zum neuesten Block zu bekommen.
> - Die Ein- und Auszahlungstransaktionen (NEO/NEO GAS) sind alle in einem Typ namens ContractTransaction. Exchanges müssen nur diesen Typ beachten, wenn Sie die Transaktionen eines Blocks prüfen.
> - Die erste Transaktion eines Blocks muss die MinerTransaction sein. Sie können diese überspringen.
> - "NEO system takes the transaction as a record unit."
> 

### Abhebungen behandeln

Um mit Abhebungen von Global Assets umzugehen, muss der Exchange Folgendes machen:

1. Führen Sie `open wallet <path>` in NEO-CLI aus, um die Wallet zu öffnen.

2. Zeichnen Sie die Transaktion auf und passen Sie das Guthaben des Users an.

3. (Optional) Customer Service kann mit manuellen Abhebungsbestätigungen umgehen.

4. Senden Sie eine Transaktion an die Abhebungsadresse des Users mit der NEO-CLI API Methode `sendtoaddress <asset_id> <address> <value>`. Für mehr Informationen, siehe [sendtoaddress Methode](/en-us/node/api/sendtoaddress.md).
  
    - `<asset_id>` : Asset ID
    - `<address>` : Abhebungsadresse
    - `<value>` : Betrag/Menge
	
    Sie können die Transaktion auch an ein Bündel Adressen schicken, mit der API [sendmany Methode](/en-us/node/api/sendmany.md).

5. Entnehmen Sie die Transaktions-ID aus den zurückgekommenen Transaktions-Details im JSON Format, dann zeichnen Sie diese in der Datenbank auf.

6. Sobald die Transaktion von der Blockchain bestätigt wurde, markieren Sie diese als "success".

Ähnlich wie Einzahlungen überwacht werden müssen, müssen dies auch Auszahlungen. Wenn die Auszahlungs-ID in der Blockchain gefunden wurde, bedeutet das, dass die Transaktion schon bestätigt wurde und die Auszahlung erfolgreich war.

> Anmerkung:
>
> - Die "value" hier bezieht sich auf den tätsächlichen Betrag, nicht auf den Betrag multipliziert mit 10^8.
> - NEO Transferbetrag muss ein Integer sein; anderenfalls wird die Blockchain die Transaktion nicht bestätigen, da das Kleingeld der Wallet ungenau ist. Es wird gebraucht um den Wallet Index zu erneuern - d.h. um die Transaktionen und das Guthaben der Wallet neu zu berechnen.

## NEP-5 Assets Transaktionen behandeln

### Benachrichtigungen für Einzahlungen der User erhalten

Bei NEP-5 Assets muss der Exchange Benachrichtigungen der Einzahlungen erhalten. Die Benachrichtigung für jeden Block ist in einer JSON Datei aufgezeichnet, welche alle Informationen von jeder NEP-5 Transaktion beinhaltet.

Um Benachrichtigungsdateien zu erhalten, geben Sie folgenden Befehl ein:

```
dotnet neo-cli.dll --rpc --record-notifications
```

Ein Ordner "Notifications" wird in dem root Pfad erstellt, wie unten gezeigt:

![1](/assets/notification_1.jpg)

![2](/assets/notification_2.jpg)

#### Benachrichtigungs-JSON Datei

Folgendes zeigt ein Beispiel für den Inhalt einer Benachrichtigungsdatei.

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

In dieser Datei ist ein Array von Benachrichtigungen mit nur einem Objekt, d.h. nur ein NEP-5 Event wurde in dem Block ausgelöst. Die Parameter der Transaktion in der Datei sind folgende:
- **contract**: der Script Hash eines Smart Contracts, mit welchem der Exchange den Typen des Assets identifizieren kann. Zum Beispiel, "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9" ist der Script Hash, und die einzigartige Identifikation, eines RPX Assets.
- Die vier Objekte in dem "state" Array:

  [event, from account, to account, amount]

  - Das erste Objekt des Typus "bytearray" mit dem Wert "7472616e73666572", wie im Beispiel gezeigt, kann in den String "transfer" konvertiert werden. "transfer" ist eine Methode in NEP-5, welche einen Transfer von Assets repräsentiert.
  - Das zweite Objekt des Arrays ist die Adresse, von der das Asset kommt. Der Typ "bytearray" und der Wert "d336d7eb9975a29b2404fdb28185e277a4b299bc" können zu "Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU" konvertiert werden. Anmerkung: Für einen hexadezimalen String mit "0x" prefix, wird es als big endian verarbeitet; andererseits wird es als small endien verarbeitet.
  - Das dritte Objekt des Arrays ist die Adresse, wo das Asset hinkommt. Wenn diese Adresse eine Adresse des Exchanges ist, ist die Transaktion eine Einzahlung.
  - Das vierte Objekt des Arrays ist der Betrag. Es gibt hier zwei Typen - Integer und Bytearray. Wenn man mit diesem Wert umgeht, sollte ein Exchange besondere Aufmerksamkeit den Transaktionen des Interger-Types widmen.

### Guthaben der User abfragen

Um das Guthaben eines Users abzufragen, muss der Exchange Folgendes machen:

1.	JSON Dateien erstellen, um drei Methoden (`balanceOf`, `decimals`, und `symbol`) über die PRC API invokefunction aufzurufen.
2.	Diese JSON Daten zu dem NEO RPC Server senden.
3.	Das Guthaben je nach wiedergegebenen Werten berechnen.

#### invokefunction

Hier sehen Sie den Aufbau des Körpers einer allgemeinen JSON invokefunction:

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

Sie müssen folgende Strings ersetzen, wenn Sie das Guthaben des Users abfragen:
- script hash

  Der Script Hash des NEP-5 Tokens, welchen Sie abfragen. Zum Beispiel, um das Guthaben von RPX abzufragen: *0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9*

- method name

  Der Name der Methode, welche Sie abrufen. Um das Guthaben abzufragen, brauchen Sie diese drei:
  
  **balanceOf**
  
  - Syntax: `public static BigInteger balanceOf(byte[] account)`
  - Anmerkung: "balanceOf" gibt das Tokenguthaben von '''account''' wieder.
  
  **decimals**
  
  - Syntax: `public static byte decimals()`
  - Anmerkung: "decimals" gibt die Anzahl der Dezimale, die der Token benutzt, wieder.

  **symbol**
  
  - Syntax: `public static string symbol()`
  - Anmerkung: "symbol" gibt das Tokensymbol wieder.
  
- optionale Argumente

  Optional. Wenn die Methode, die Sie aufrufen, Argumente benötigt, können Sie diese in den Parametern eingeben. Zum Beispiel, "balanceOf" in NEP-5 gibt das Guthaben von "account" wieder:
  
  `public static BigInteger balanceOf(byte[] account)`
  
  Also müssen Sie den account als Argument in der "balanceOf" Methode eingeben.

#### Beispiel

##### **balanceOf aufrufen**

Nehmen wir an die Kontoadresse ist *AJShjraX4iMJjwVt8WYYzZyGvDMxw6Xfbe*. Sie müssen diese zu Hash160 konvertieren und den Parameter als ein JSON Object bauen:

```json
{
    "type": "Hash160",
    "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
}
```

Danach können Sie JSON Nachrichten folgend erstellen:

Request Body:

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

Nachdem sie den Request gesendet haben, werden Sie folgende Antwort bekommen:

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

Es gibt "00e1f505" wieder, welches zu Integer 100000000 konvertiert werden kann.

##### **decimals aufrufen**

Request Body:

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

Nachdem Sie den Request gesendet haben, werden Sie folgende Antwort bekommen:

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

Es gibt den Integer 8 wieder.

##### **symbol aufrufen**

Request Body:

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

Nachdem sie den Request gesendet haben, werden Sie folgende Antwort bekommen:

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

Es gibt "525058" wieder, welches in den String "RPX" konvertiert werden kann.

##### **Das Guthaben ausrechnen**

Gemäß allen wiedergegebenen Werten, können wir das Guthaben wie folgt ausrechnen:
100000000/10^8 RPX = 1 RPX

### Mit Abhebungen umgehen

Der Exchange kann eine der folgenden Arten auswählen, um NEP-5 Assets zu seinen Usern zu senden:

- NEO-CLI Befehl: `send`

- RPC Methode: `sendtoaddress`
- PRC Methode: `sendmany`

#### NEO-CLI Befehl: send

##### Syntax

`send <txid|script hash> <address> <value> [fee = 0]`

##### Parameters

- txid|script hash: Die Asset ID

- address: Die Auszahlungsadresse

- value: Der zu transferierende Betrag

- fee: Dieser Parameter kann leer gelassen werden. Standardwert ist 0.

Dieser Befehlt prüft das Wallet Passwort.

##### Beispiel

Um 100 RPX an die Adresse *AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b* zu senden, geben Sie Folgendes ein:

```
send 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100
```

Wenn Sie ein globales Asset senden wollen, ändern Sie einfach den ersten Parameter zu txid. Zum Beispiel:

Die txid von NEO: 0Xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b 

Die txid von GAS: 0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

#### RPC Methode: sendtoaddress

Der Key "params" enthält ein Array von mindestens drei Parametern:

`"params":[script hash, address, amount, fee(optional), change address(optional)]`

Zum Beispiel, um 1 RPX an *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* zu senden, erstellen Sie eine JSON Datei wie folgt, und senden Sie diese zu dem RPC Server.

Request Body:

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

Nachdem Sie den Request gesendet haben, werden Sie folgende Antwort bekommen:

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

#### RPC Methode: sendmany

Der Key "params" enthält ein Array von mindestens einem Parameter:

`"params":[[], fee(optional), change address(optional)]`

Zum Beispiel, um 15.5 RPX und 0.0001 GAS an *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* zu senden, wenn die `change address` auch *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* ist, erstellen Sie eine JSON Datei wie folgt, und senden Sie diese zu dem RPC server.

Request Body:

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

Nachdem Sie den Request gesendet haben, werden Sie folgende Antwort bekommen:

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

### Weitere Information

[NEP-5 Token Standard](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki)

[Data Transformation Examples](https://github.com/PeterLinX/NeoDataTransformation)

## (Optional) GAS an die User verteilen

Der Exchange kann beschließen, ob er GAS an seine User verteilt oder nicht. GAS wird benutzt um die NEO Blockchain für Aufzeichnungen und andere Services zu bezahlen.

### Was ist GAS?

NeoGas (abgekürzt GAS) repräsentiert das Recht, die NEO Blockchain zu benutzen. Es wird ein Maximum von 100 Millionen GAS geben. GAS wird entlang jedem neuen Block generiert. Die Ausgabe wird langsam nachlassen, während GAS einen Prozess durchläuft und von 0 bis 100 Millionen wächst. Sobald NEO erworben ist wird GAS mit folgenden Algorithmen erzeugt:

### Die verfügbare GAS Menge ausrechnen
- Verfügbares *GAS = f(neo_menge, Δt_const)*

  - Δt_const = t_end - t_start
    - t_end = Der Moment, in dem NEO den Status "spent" erhält
    - t_start = Der Moment, in dem NEO den Status "unspent" erhält
    
  Δt_const ist festgelegt, somit ist das die verfügbare Menge von GAS auch. Diese Menge ist eine Funktion der Menge von NEO die der User besitzt, und die Dauer zwischen den Momenten in denen der User diese Menge von NEO zu bzw. von seiner Adresse geschickt hat.

- Nicht verfügbares *GAS = f(neo_amount, Δt_var)*

  - Δt_var = t - t_start
    - t = aktuelle Zeit
    - t_start = Der Moment, in dem NEO den Status "unspent" erhält

  Die aktuelle Zeit ist eine Variable, somit steigt die Menge des unerhältlichen GAS über Zeit, was bedeutet dass GAS selbst eine Variable ist.

### GAS an die User verteilen

Angenommen alle Exchange Adressen sind in einer einzigen Wallet, demonstriert die folgende Grafik den Ablauf und die rechnerischen Formeln, wie der Exchange GAS an User A ausschüttet.

![gasflow_en](/en-us/sc/assets/gasflow_en.png)

Je geringer die Snapshot Zeitspanne, desto präziser ist die Kalkulation. Wenn die Snapshot Zeitspanne nicht einheitlich ist, benutzen Sie die durchschnittliche Rechenmethode.

### GAS fordern

GAS wird beanspruchbar nachdem der User seine/ihre NEO transferiert hat. Zum Beispiel, **jemand hat NEO in Adresse A und GAS ist nicht beanspruchbar - er kann nun NEO an sich selbst schicken (Adresse A) und somit die GAS beanspruchbar machen.**

Die folgende Tabelle zeigt die GAS Forderungsschritte mit entsprechenden Befehlen:

| #    | Steps                                    | Command                                  |
| ---- | :--------------------------------------- | ---------------------------------------- |
| 1    | Run NEO-CLI                              | `./neo-cli.dll /rpc`                     |
| 2    | Check the client version                 | `version`                                |
| 3    | Check the synchronized height of the client ( Height: height/header height, Nodes: amount of connected nodes). | `show state`                             |
| 4    | Create a wallet                          | `create wallet /home/NeoNode/test.db3`   |
| 5    | Open the wallet created in the last step | `open wallet /home/NeoNode/test.db3`     |
| 6    | Check the address list in the wallet     | `list address`                           |
| 7    | Check the assets in the wallet           | `list asset`                             |
| 8    | Check the GAS balances details in the wallet | `show gas`                               |
| 9    | Transfer NEO to your address（e.g. AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1） to change the status of Gas to be claimable. | `send NEO AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 10   | Get the details of the balances of GAS in the wallet again. Now the status of all the GAS should be available to claim. | `show gas`                               |
| 11   | Claim GAS.                               | `claim gas`                              |
| 12   | Check balance again.                     | `list asset`                             |
