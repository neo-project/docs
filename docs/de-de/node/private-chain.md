# Ein privates NEO Netzwerk erstellen

In einem vorrausgehenden Tutorial wurde erklärt, wie Sie eine NEO Node für Windows und Linux erstellen können. Dieses Tutorial wird zeigen, wie eine private Blockchain erstellt werden kann und wie sie die NEO und GAS Token dieser Blockchain nutzen können.

Die Erstellung einer privaten NEO Blockchain benötigt mindestens vier Server um Konsens zu erreichen, wobei jeder Server eine Consensus Node und eine eigene NEO Wallet darstellt.

## 1. Konfiguration der virtuellen Maschine

Die Erstellung einer privaten NEO Blockchain benötigt mindestens vier Server um Konsens zu erreichen. Jeder Server stellt dabei eine Consensus Node dar. Für Demonstrationszwecke werden im Folgenden vier virtuelle Windows Maschinen (Standard DS1 v2, 1 Core, 3,5 GB RAM) auf Azure erstellt. Sie können die private Blockchain auch in einem LAN mit verschiedenen PCs erstellen.

![image](/assets/privatechain_1.png)

Nach der Erstellung der Maschinen müssen die Ports 10331-10334 in der Firewall freigegeben werden. Öffnen Sie dafür `firewall`, `advanced settings`, `inbound rules` und fügen Sie die Ports 10331 - 10334 hinzu.

> [!Anmerkung]
> Wenn Sie eine virtuelle Maschine auf einem Cloudserver erstellen, loggen Sie sich in das Administratorportal ein und erstellen Sie eine Netzwerksicherheitsgruppe.
>
> Für Azure gilt: `network interface` `network security group` `inbound security rules` `add`. Fügen Sie dort die Ports 10331-10334 hinzu.

Sobald die virtuelle Maschine erstellt ist, speichern Sie die IP-Adressen der vier virtuellen Maschinen für später.

## 2. Installation der NEO Node

Der Installationsprozess der NEO Node wurde bereits in einem anderen Tutorial beschrieben. Sie finden dieses [hier](setup.md).

## 3. Wallet erzeugen

Zuerst müssen vier Wallet-Files erzeugt werden (wallet1.db3 - wallet4.db3). Dieser Schritt kann sowohl in der NEO-GUI als auch in der NEO-CLI erfolgen. Die folgende Abbildung zeigt die NEO-CLI-Wallet

![image](/assets/privatechain_3.png)

Sobald die Wallet generiert und der dazugehörige öffentliche Schlüssel in einem Textdokument gespeichert wurde, kopieren Sie den Schlüssel für später.

Anschließend kopieren Sie die vier Wallets in die Verzeichnisse der vier virtuellen Maschinen.

## 4. Modifikation der Konfigurationsdatei

Öffnen Sie die Konfigurationsdatei der Node `protocol.json`.

Als erstes verändern Sie den Wert von `Magic`. Magic wird genutzt um die das Netzwerk zu identifizieren. Ein neuer Magic-Wert stellt sicher, dass Ihre virtuellen Maschinen während der Übertragung nicht Teil eines anderen NEO-Netzwerks werden.

> [!Anmerkung]
> Der Wert von Magic kann Werte von [0 - 4294967295] annehmen.

Verändern Sie den Wert der `StandbyValidators`, and fügen Sie die vier privaten Schlüssel aus Schritt 3 hier ein.

Abschließend muss die `SeedList` modifiziert werden. Fügen Sie hier die IP-Adressen aus Schritt 1 ein. Die Ports bleiben unverändert. Als Beispiel folgende modifizierte Konfiguration:

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```

SystemFee ist die Systemgebühr, die aktuellen Gebühren sind wie folgt (in GAS Einheiten):

Registrierung als Consensus Node - 1000, Ausgabe von Assets - 500, Smart Contract - 500, Registrierung von Assets - 10000

Sie können die Gebühren für Ihre private Blockchain hier festlegen.

Abschließend kopieren sie die modifizierte `protocol.json` in die Verzeichnisse der vier Nodes und überschreiben Sie die alte Datei.

Geben Sie daraufhin in den vier virtuellen Maschinen folgende Befehle ein um die Node zu starten, die Wallet zu öffnen und die Konsensfindung zu beginnen. Bitte lesen Sie [hier](cli.md) noch einmal nach, wenn Sie sich unsicher sind.

Node starten:

`Dotnet neo-cli.dll`

Wallet öffnen:

`Open wallet wallet1.db3`

Anmerkung: Öffnen Sie auf jeder Node jeweils eine Wallet der Wallet 1-4.

`Start consensus`

Wenn der Befehl erfolgreich war, beginnen die vier Nodes mit der Konsensbildung wie gezeigt:

![image](/assets/privatechain_8.png)

Vier Nodes können auch einen Konsens bilden, wenn eine Maschine abgeschaltet ist:

![image](/assets/privatechain_9.png)



## 5. NEO und GAS Token extrahieren

Installieren Sie die PC-Version des Clients (NEO-GUI) und modifizieren sie die Datei `protocol.json` ebenfalls, um sich mit der privaten Blockchain zu verbinden.

Öffnen Sie die Wallet. Wenn die, in der unteren linken Ecke, angezeigte Nummer höher als Null ist und bis zum selben Block synchronisiert ist, heißt das, dass der Client sich erfolgreich mit der privaten Blockchain verbunden hat.

Öffnen Sie die Wallet wallet1.db3 im PC-Client, fügen Sie eine Multisignatur-Adresse hinzu und fügen Sie die vier öffentlichen Schlüssel der Nodes ein. Setzen Sie die Anzahl der minimalen Signaturen auf drei (Zahl der Consensus Nodes/2 + 1) wie gezeigt:

![image](/assets/privatechain_12.png)

Klicken Sie auf Ok. Nachdem Sie einen Wallet Index Rebuild durchgeführt haben, werden 100 Millionen NEO in der Contract-Adresse angezeigt:

![image](/assets/privatechain_14.png)

> [!Anmerkung]
> Sie müssen diesen Schritt auf allen vier Nodes durchführen!

Die NEO müssen anschließend von der Contract-Adresse auf eine normale Adresse übertragen werden. Für die Transaktion öffnen Sie eine beliebige Node-Wallet, klicken auf `transaction`, `transfer` und geben die Zieladresse ein, um die 100 Millionen NEO zu dieser Adresse zu übertragen.

Das System wird Sie darauf hinweisen, dass Sie nicht genug Signaturen haben, um die Transaktion abzuschließen. Kopieren Sie den Code, öffnen Sie die zweite Wallet, klicken Sie auf `transaction`, `signature` und fügen Sie den Code hier ein. Klicken Sie anschließend auf `signature` und kopieren den Code. Öffnen Sie die dritte Wallet, klicken Sie auf `transaction`, `signature` und fügen Sie den grade kopierten Code hier. ein. Klicken Sie abermals auf `signature`. Der `broadcast` Button wird nun in der unteren linken Ecke angezeigt, was bedeutet, dass alle erforderlichen Signaturen eingesammelt wurden. Klicken Sie auf `broadcast`. Nachdem die Transaktion gesendet wurde, dauert es ca. 15 Sekunden bis eine Gutschrift auf der Zieladresse erfolgt.

![image](/assets/privatechain_20.png)

GAS wird auf ähnliche Weise extrahiert. Klicken Sie auf `Advanced`, `Claim GAS`, `Claim` wie in der Abbildung gezeigt. Merken Sie sich die Adresse der Wallet, diese wird später gebraucht.

![image](/assets/privatechain_21.png)

Der nächste Schritt funktioniert genauso wie der Transfer der NEO Token. Kopieren Sie den Code, öffnen die zweite Wallet, klicken auf `transaction`, `signature` und fügen den Code hier ein. Klicken Sie auf `signature` und kopieren den Code. Öffnen Sie die dritte Wallet, klicken Sie auf `transaction`, `signature` und fügen Sie den grade kopierten Code hier. ein. Klicken Sie abermals auf `signature`. Der `broadcast` Button wird nun in der unteren linken Ecke angezeigt, was bedeutet, dass alle erforderlichen Signaturen eingesammelt wurden. Klicken Sie auf `broadcast`. Nachdem die Transaktion gesendet wurde, dauert es ca. 15 Sekunden bis eine Gutschrift auf der Zieladresse erfolgt.

Nach erfolgreicher Extraktion wird das GAS der ersten Standardadresse der Wallet (die oberste Adresse), von der Sie die Extraktion gestartet haben, gutgeschrieben.

![image](/assets/privatechain_26.png)
