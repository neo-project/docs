# CLI Command Referenz

Öffnen Sie die Kommandozeile und navigieren Sie in den Installationsordner von NEO-CLI. Geben Sie 

`dotnet neo-cli.dll`

ein um die Kommandozeilen-Wallet zu starten.

Dieses Tutorial stellt alle Befehle für die Kommandozeilen-Wallet vor. Sie können in NEO-CLI eine Wallet erstellen, private Schlüssel im- und exportieren, Assets transferieren, an der Konsensbildung beteiligen etc.

Zuerst werden wir verschiedene Befehle kennenlernen, die in der Kommandozeile gelistet sind. Geben sie `help` ein und drücken sie `Enter` damit Ihnen folgende Liste angezeigt wird:

![image](/assets/cli_2.png)

Im Folgenden werden alle Befehle und die Anordnung der Klammern erklärt:
Winkelklammern ``<>`` markieren Parameter.
Eckige Klammern ``[]`` markieren optionale Parameter.
Das Symbol ``|`` zeigt einen beliebigen Füllparameter an.
Das Gleichheitszeichen `=` definiert den Standardwert für optionale Parameter ohne Input.

## 1. Kommandozeilen Befehle

| Command      | Funktion     |
| ------- | --------- |
| version | Zeigt die aktuelle Versionsnummer |
| help    | Hilfemenü      |
| clear   | Bildschirm leeren     |
| exit    | Programm beenden      |

## 2. Wallet Operatoren

Command | Funktion | Anmerkungen |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | Wallet anlegen |
| open wallet \<path> | Wallet öffnen |
| rebuild wallet index | | Wallet muss für diese Funktion geöffnet sein |
| list address | Listet alle Accounts der Wallet auf | Wallet muss für diese Funktion geöffnet sein |
| list asset | Listet alle Adressen der Wallet auf | Wallet muss für diese Funktion geöffnet sein |
| list key | Listet alle öffentlichen Schlüssel der Wallet auf | Wallet muss für diese Funktion geöffnet sein |
| create address [n = 1] | Adresse generieren / Mehrere Adressen generieren | Wallet muss für diese Funktion geöffnet sein |
| import key \<wif\|path> | Importiere privaten Schlüssel / Mehrfachimport privater Schlüssel | Wallet muss für diese Funktion geöffnet sein |
| export key \[address] [path] | Exportiert privaten Schlüssel| Wallet muss für diese Funktion geöffnet sein |
| send \<id\|alias> \<address> \<value> [fee=0]| Sendet an bestimmte Adresse |Wallet muss für diese Funktion geöffnet sein |

Die folgenden Befehle werden im Detail erklärt:

ðŸ‘‰ `rebuild index`

Mit diesem Befehl wird der Wallet Index wiederhergestellt.
Warum ist dies überhaupt erforderlich?

Es gibt ein Feld in der Wallet, dass die Höhe des aktuell synchronisierten Blocks mitschreibt. Für jeden neuen Block synchronisiert die Wallet die Blocks und aktualisiert die Assets und Transaktionen, die die Wallet betreffen. Angenommen, die Blockhöhe ist aktuell 100 und Sie importieren einen privaten Schlüssel, dann berechnet die Wallet Ihre Assets ab der Blockhöhe 100. Wenn Ihre Adresse Transaktionen vor der Blockhöhe 100 hatte, dann werden diese nicht berücksichtigt. Durch den Rebuild wird das Programm gezwungen, Ihre Assets ab Block 0 neu zu berechnen und anzuzeigen.

Eine neu generierte Wallet benötigt keinen Wallet Index Rebuild. Lediglich nach dem Import eines privaten Schlüssels ist ein Rebuild nötig.

ðŸ‘‰ `create address [n = 1]`

Mit diesem Befehl kann eine neue Adresse angelegt werden. Sie können auch 100 Adressen gleichzeitig generieren, indem Sie `create address 100` eingeben. Mehrfachgenerierungen führen automatisch zu einem Adressenexport in die address.txt-Datei.

ðŸ‘‰ `export key [address] [path]`

Sie können spezifizieren, zu welcher Adresse der private Schlüssel exportiert werden soll. Auch können Sie bestimmen, in welche Datei und in welchen Ordner der Schlüssel exportiert werden soll. Dieser Befehl benötigt eine Passworteingabe zur Bestätigunt.

Export key

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

ðŸ‘‰ `import key <wif | path>`

Wenn Sie einen privaten Schlüssel importieren, können Sie entweder einen einzelnen privaten Schlüssel oder aber eine Datei mit mehreren Schlüsseln importieren. 

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

Die zu importierende Datei muss das `private key format` haben um erfolgreich importiert werden zu können. Bitte sehen Sie sich zum Vergleich eine Export-Datei an.

ðŸ‘‰ `send <id | alias> <address> <value> [fee = 0]`

Für Transfers gibt es insgesamt vier Parameter. Der erste Parameter ist die Asset-ID, der zweite die Ziel-Adresse, der dritte die Menge und der vierte Parameter ist die Gebühr (der letzte Parameter kann leergelassen werden, da die Gebühr zur Zeit 0 beträgt). Dieser Befehl muss durch Eingabe des Wallet-Passworts bestätigt werden. Wenn Sie z.B. 100 NEO an die Adresse: "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b" transferieren wollen, müssen Sie folgende Befehle eingeben:

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

Wenn Sie sich über die Asset-ID nicht im Klaren sind, nutzen Sie den `list asset`-Befehl um alle Assets Ihrer Wallet anzeigen zu lassen.

## 3. Node Informationen anzeigen lassen

Command | Funktion |
| ---------- | ----------------------- |
show state | Zeigt den Status der Blockchainsynchronisation an
show node | Zeigt IP-Adresse und Port der verbundenen Node |
show pool | Zeigt die Transaktionen im Memory-Pool an (Transaktionen mit 0 Bestätigungen) 

## 4. Fortgeschrittene

Command | Funktion |
| --------------- | ---- |
Start consensus | Beginnt Teilnahme an der Konsensbildung

Dieser Befehl funktioniert nur, wenn die Wallet eine Berechtigung hat, an der Konsensbildung teilzunehmen. Die Berechtigung kann auf dem MainNet durch den Wahlmechanimus erlangt werden. In einem privaten Netzwerk kann der öffentliche Schlüssel in die `protocol.json` eingetragen werden. 
Für weitere Informationen lesen Sie bitte [hier](private-chain.md).
