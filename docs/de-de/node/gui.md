# Den NEO-GUI Client benutzen

## Voraussetzungen

### Den Client downloaden

Der Client selbst benötigt keine Installation. Nach dem Herunterladen und Entpacken der Dateien in ein Verzeichnis Ihrer Wahl, öffnet ein Doppelklick auf neo-gui.exe den Client. Sollte es beim Öffnen des Clients Probleme geben, speichern Sie die Datei error.log (im gleichen Verzeichnis wie neo-gui.exe) und kontaktieren Sie unsere technischen Mitarbeiter, die Ihnen helfen, das Problem zu lösen.

> [!Anmerkung]
>
> Der NEO-GUI Client ist kompatibel mit folgenden Windows Versionen: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
> 
> Bestimmte Windows 10 Vorabversionen benötigen eine Installation eine Installation des [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### Blockchain Daten synchronisieren

Der Client muss voll synchronisiert sein bevor er genutzt werden kann. In der unteren linken Ecke wird die Anzahl der synchronisierten Blocks sowie die Gesamtmenge an Blocks angezeigt (s. Bild unten). Diese Zahlen aktualisieren sich laufend.

![image](/assets/gui_1.png)

Um den Prozess der Synchronisation zu beschleunigen, können sie eine Kopie der Blockchain bis zu einer bestimmten Blockhöhe herunterladen. Das bedeutet, der Client muss nur die restlichen Blocks synchronisieren, anstelle der gesamten Blockchain.

1. Anfangs, laden Sie die auf [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip") gelegene Datei herunter.

2. Schließen Sie den NEO-GUI Client und öffnen Sie chain.acc.zip. Entpacken Sie die chain.acc Datei in den NEO-GUI Ordner, wie hier gezeigt:

   ![](/assets/gui_58.png)
   
3. Nachdem Sie den NEO-GUI Client neu gestartet haben, werden Sie sehen, dass der Client nun bis zu einem bestimmten Punkt synchronisiert ist und nur noch mit dem restlichen Teil der Blockchain synchronisieren muss, wie hier gezeigt:

   ![](/assets/gui_59.png)

Sobald die Synchronisation an einem bestimmten Punkt angekommen ist, wird die Datei (chain.acc) gelöscht, und die Synchronisation mit dem NEO Netzwerk wird fortfahren, wie hier gezeigt:

![](/assets/gui_60.png)

Die Daten neben "Height" (Höhe) entsprechen Wallet Height/Client Height/Blockchain. Wenn Sie eine Wallet öffnen, wird die Wallet Height angezeigt.

### Glossar

#### Wallet

Die Wallet-Datei speichert Hinweise auf Ihr NEO, GAS und weitere Accountinformationen in einer Datenbank mit .json- oder .db3-Endung. Es wird dringend empfohlen, eine redundante Sicherung dieser Datei anzulegen, da ein Verlust den Totalverlust der Assets mit sich bringen kann!

> [!Wichtig]
>
> Der Verlust der Wallet-Datei oder des Wallet-Passworts führt zum Verlust der dazugehörigen Assets. Bitte stellen Sie unbedingt sicher, dass die Wallet-Datei mehrfach gesichert wurde und erinnern sich an das Wallet-Passwort!

#### Account

Der Account wird genutzt um Assets in einem NEO-Block zu verfolgen.

Accountinformationen beinhalten: Adresse, private Schlüssel, öffentlicher Schlüssel und Accounttyp.

- Adresse: Die Adresse ist äquivalent zu einer Kontonummer und wird genutzt um Assets in einer Transaktion zu erhalten.

- Accounttyp: NEO.Wallets.SignatureContract zeigt an, dass die Adresse aus einem öffentlichen Schlüssel besteht und eine sog. 1-of-1 mehrfachsignierte Adresse ist. NEO.Wallets.MultiSigContract zeigt an, dass die Adresse aus mehreren öffentlichen Schlüsseln besteht und eine sog. m-of-n mehrfachsignierte Adresse ist, welche für "Smart Contracts" genutzt wird.

- Privater Schlüssel: Eine 256-bit Zufallszahl, die dem User gehört und NICHT öffentlich bekannt ist. Dieser Schlüssel repräsentiert einen Eigentumsnachweis für den Account und die damit verbundenen Assets.

- Öffentlicher Schlüssel: Jeder private Schlüssel hat einen passenden öffentlichen Schlüssel (Anmerkung: Informationen zu öffentlichem und privatem Schlüssel können durch einen Rechtsklick auf die Adresse eingesehen werden).

> [!Wichtig]
>
> Unter keinen Umständen darf der private Schlüssel in die Hände Anderer geraten, da dies zum Verlust Ihrer Assets führen kann! 

#### Assets

Die Assets des Accounts, Asset-Informationen inkl. Asset(NEO/GAS/andere Assets), Assettyp, Kontostand und Herausgeber.

#### Transaction History

Eine Historie aller Transaktionen des Accounts.

#### Transfer

Transfer von Assets zu einer Zieladresse. Wenn NEO transferiert werden, sind beide involvierten Parteien gezwungen, die Transaktion mit ihrer Signatur zu bestätigen. Andere Assets können ohne Bestätigung übertragen werden.

#### Exchange

Tauscht ein digitales Asset zwischen zwei Parteien aus, wobei beide Parteien die Transaktion bestätigen müssen bevor sie ausgeführt wird.

#### Signature

Das Unterzeichnen von Informationen dient der Bestätigungder Information durch den Unterzeichner.
Für Transaktionen die Assettransfers bzw. Vermögensübertragungen beinhalten ist die Signatur der Beweis dafür, dass beide Parteien mit der Transaktion einverstanden sind.

#### Asset Registration

Kreiert ein neues, usergeneriertes Asset in der NEO-Blockchain. Der User kann dabei den Typ, Namen, Menge etc. des herausgegebenen Assets bestimmen und einem Administrator-Account zuordnen. Es kostet zur Zeit 10.000 GAS ein Asset auf der NEO-Blockchain zu registrieren (Im TestNet ist die Gebühr 1% der Gebühr des MainNets).

#### Asset Distribution

Neu kreierte Assets werden in der, durch den Registrator festgelegten Menge, an die Adresse ausgegeben, die das Asset registriert hat. Die Registrierung von Assets verbraucht eine vorgegebene Menge an GAS als Servicegebühr. Die Gebühr beträgt zur Zeit 10.000 GAS (Im TestNet beträgt die Gebühr lediglich 1% vom MainNet).

#### Election

Wer eine NEO Bookkeeping Node betreiben möchte, muss sich für die Wahl registrieren. Dafür muss ein bestimmter Betrag GAS (momentan 1000 GAS) gezahlt werden. Nach der Registrierung kann man sich zur Wahl stellen. 
Diese Funktion wird zur Zeit noch nicht unterstützt. 

#### Vote

NEO Halter können NEO Bookkeeping Nodes wählen und der integrierte Wahlmechanismus entscheidet, welche Bookkeeper ausgewählt werden. 
Diese Funktion wird zur Zeit noch nicht unterstützt.

#### Broadcast

Die signierten Transaktionsinformationen werden an das gesamte Netzwerk gesendet und von jedem Knoten bestätigt, um die Transaktion abzuschließen. Derzeit wird diese Funktion nur in der Signatur angezeigt.

#### Monitor address

Importieren Sie Ihre eigene oder eine fremde Adresse, um diese zu beobachten. Sie können außerdem die zu der Adresse gehörenden Assets sehen.

## Wallet
### Wallet-Datei erstellen

1. Klicken Sie auf `Wallet`, `New Wallet Database`. Es erscheint ein PopUp `New Wallet`:

  ![image](/assets/gui_2.png)

2. Klicken Sie auf `Browse` um einen Speicherort und Dateinamen auszuwählen, danach auf `Speichern`:

  ![image](/es-es/node/assets/gui/gui_3.png)

3. Geben Sie Ihr Passwort ein und bestätigen Sie es. Es wird dringend geraten, ein starkes Passwort zu wählen!

  ![image](/assets/gui_4.png)

4. Klicken Sie auf `OK`. Die Wallet wurde nun erfolgreich erstellt. In der Wallet befindet sich nun eine Standard-Adresse. Sie können beliebig viele Adresse pro Wallet-Datei erstellen, die erste Adresse bleibt jedoch immer die Hauptadresse der Wallet. Wechselgeldtransaktionen werden immer auf diese Adresse geleitet, es ist also sinnvoll ein Backup dieser Adresse zu haben.

### Öffnen der Wallet-Datei
1. Bei jedem Öffnen des Clients müssen Sie nach dem Start zuerst die gewünschte Wallet-Datei öffnen:

  ![image](/assets/gui_5.png)

2. Klicken Sie auf `Browse`, um die gewünschte Wallet auszuwählen (normalerweise ist die letzte geöffnete Wallet vorausgewählt).

3. Wählen Sie eine der Dateitypen aus: NEP-6 (.json) oder SQLite (.db3)

  Clients vor der Version NEO GUI v2.5.2 unterstützen nur .db3 Dateien.
  
4. Geben Sie das Passwort ein und drücken Sie `OK`.

5. Falls Sie eine alte .db3 Wallet öffnen, müssen Sie sich entscheiden, ob Sie die Wallet zu dem neuen NEP-6 Format aktualisieren möchten.

  Nach einer Aktualisierung kann die NEP-6 Wallet auf mehreren Platformen geteilt werden, z.b. Mobile, PC, oder Website. Jedoch kann sie nicht in Clients vor der Version NEO GUI v2.5.2 geöffnet werden.

### Passwort ändern

Sie können das Passwort Ihrer Wallet-Datei folgendermaßen ändern:

![image](/assets/gui_6.png)

Denken Sie daran, nach dem Ändern des Passworts ein neues Backup der Wallet-Datei anzulegen, da die alten Backups noch das alte Passwort enthalten.

### Wiederherstellen des Wallet-Index 

Die Funktion `Rebuild Index` kann genutzt werden, um den Client nach einem Fehler wiederherzustellen. Der Wallet-Index muss in folgenden Fällen wiederhergestellt werden:

- Nach dem Import eines privaten Schlüssels
- Wenn eine Transaktion nach langer Zeit noch nicht bestätigt wurde
- Wenn die Assets der Wallet fehlerhaft angezeigt werden und die Daten nicht mit der Blockchain übereinstimmen.
- Wechsel zwischen dem Hauptnetz und dem Testnetz.

Da die aktuelle Blockhöhe relativ hoch ist, nimmt der Vorgang einige Minuten in Anspruch.

## Handel

### Transfer

#### Token Asset Transfer

1. Klicken Sie auf `transaction`, `transfer`, `+`, und geben Sie die Transferdetails ein:

  ![image](/assets/gui_10.png)

2. Klicken Sie `Ok`:

  ![image](/assets/gui_11.png)

3. Klicken Sie `Ok`:

  ![image](/zh-cn/node/assets/i.png)

#### Equity Asset Transfer

1. Klicken Sie auf `transaction`, `transfer`, `+`, und geben Sie die Transferdetails ein:

  ![image](/zh-cn/node/assets/j.png)
  
2. Klicken Sie `Ok`:

  ![image](/zh-cn/node/assets/k.png)

3. Klicken Sie `Ok`, es wird angezeigt, dass mehrere Signaturen benötigt werden:

  ![image](/zh-cn/node/assets/l.png)

4. Informationen zur Signaturfunktion finden Sie [hier](#sign).

#### Mehrfachtransaktionen

Die `batch transfer` Funktion kann den Transfer von gleichen Assets an mehrere Zieladressen vereinfachen.

![image](/assets/gui_14.png)

Das Datenformat ist dabei `"Adresse" "Transferbetrag"` (getrennt durch Leerzeichen):

![image](/assets/gui_15.png)

Es wird darauf hingewiesen, dass das Datenformat in der oben genannten Form eingehalten werden sollte um Transferfehler zu vermeiden.

#### Remarks

Diese Funktion wird genutzt, um zusätzliche Transaktionsdetails auf der NEO-Blockchain zu speichern. Die zusätzlichen Daten können auch über einen Blockchainexplorer gesucht werden:

![image](/zh-cn/node/assets/o.png)

Zur Zeit gibt es allerdings keinen Bedarf für dieses Nachrichtenformat:

![image](/zh-cn/node/assets/p.png)

Die Daten können von außen über einen Blockchainexplorer eingesehen werden:

![image](/zh-cn/node/assets/oo.png)

### Handel

#### Einen Handel einleiten

1. Für diese Art der Transaktion müssen beide Seiten eine Transaktion einleiten und festlegen, welches Asset in welcher Menge das Gegenüber erhalten soll:

  ![image](/assets/gui_18.png)

2. Klicken Sie auf `Ok` um die Transaktionsanfrage zu generieren. Aus der Transaktionsanfrage sind die Details der Transaktion ersichtlich. 

![image](/assets/gui_19.png)

#### Abschluss des Handels

1. Nach dem Schließen des `transaction request` Fensters erscheint das `merge transaction request` Fenster:

  ![image](/assets/gui_20.png)

2. Ihnen wird nun die Transaktionsanfrage des Gegenübers angezeigt. Um die Richtigkeit der Anfrage zu prüfen, klicken Sie auf `verify`. Abhängig von der Richtigkeit können Sie nun auf `accept` oder `refuse` klicken.

![image](/assets/gui_24.png)
3. Wenn Sie die Transaktion akzeptieren, müssen beide Seiten die Transaktion signieren und veröffentlichen. Weitere Informationen erhalten Sie [hier](#sign). <a id="sign"> </a>

### Signature
1. Dies kopiert die Transaktionsanfrage Ihres Gegenübers in das Eingabefeld. Klicken Sie auf `sign` um die Output-Daten für die Transaktion zu generieren. Anschließend wird der `broadcast`-Button freigegeben:

  ![image](/zh-cn/node/assets/u.png)

2. Klicken Sie auf `broadcast`, um die Transaktion zu senden. Die Transaktion ist nun abgeschlossen und eine Transaktions-ID wird angezeigt.

![image](/assets/gui_30.png)

## Für Fortgeschrittene

### GAS Claim Transaktion

GAS wird mit jedem neuen Block automatisch generiert und den Adressen von NEO Haltern gutgeschrieben. NEO Halter können zu jeder Zeit eine sog. GAS Claim Transaktion starten um das gutgeschriebene GAS den eigenen Assets hinzuzufügen. Momentan hat nur die PC-Version des NEO-GUI Clients eine GAS Claim Funktion.

Schritt für Schritt:

1. Transferieren Sie alle NEO Ihrer Wallet an Ihre eigene Adresse. Sobald die Transaktion durchgeführt wurde, können Sie die GAS Claim Funktion aufrufen (Für Details lesen Sie bitte das Whitepaper).
2. Klicken Sie auf `Advanced`, `Claim GAS`, `Claim All`.

  ![image](/assets/gui_37.png)

### Ein Zertifikat beantragen

Beachten Sie, dass diese Funktion lediglich eine Zertifikats-Datei anlegt. Der Nutzer muss sich trotzdem an eine Stelle für digitale Zertifikate wenden und sich dort um ein Zertifikat bemühen.
Klicken Sie auf `Advanced`, `Request certificate`, und füllen Sie das Formular nach den gegebenen Anforderungen aus:

![image](/assets/gui_39.png)

Die generierte Datei wird folgendermaßen angezeigt:

![image](/zh-cn/node/assets/y.png)

### Assets registrieren

Es gibt zwei Arten von Assets: Token und Shares. Im folgenden wird ein Token als Beispiel genutzt. Füllen Sie folgendes Formular aus:

![image](/assets/gui_43.png)

Es wird darauf hingewiesen, dass die Registrierung von Assets eine hohe Gebühr kostet. Bitte füllen Sie das Formular sorgfältig aus, Fehler können nicht rückgängig gemacht werden.

### Assets verteilen

![image](/assets/gui_46.png)

Es wird darauf hingewiesen, dass die Verteilung von Assets eine hohe Gebühr kostet. Bitte füllen Sie das Formular sorgfältig aus, Fehler können nicht rückgängig gemacht werden.

### Wahlmechanismus

Die `Election`-Funktion kann genutzt werden, um sich als Kandidat für NEO Bookkeeping Nodes zu registrieren:

![image](/assets/gui_57.png)

Es wird darauf hingewiesen, dass die Registrierung eine hohe Gebühr kostet. Bitte füllen Sie das Formular sorgfältig aus, Fehler können nicht rückgängig gemacht werden.
Diese Funktion ist zur Zeit noch nicht verfügbar. Bitte warten Sie auf weitere Updates.
