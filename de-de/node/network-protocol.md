# Netzwerkprotokoll


NEO nutzt ein Peer-to-Peer Netzwerk, in welchem Nodes über das TCP/IP-Protokoll miteinander kommunizieren können. In dieser Struktur gibt es zwei unterschiedliche Nodetypen. Peer Nodes und Consensus Nodes (früher Bookkeeping Nodes). Peer Nodes können Transaktionen und Blocks senden, empfangen und übertragen, während Consensus Nodes Blocks erzeugen.

Das NEO Netzwerkprotokoll ist grob mit dem von Bitcoin zu vergleichen, auch wenn Datenstrukturen wie z.B. Blocks oder Transaktionen sich unterscheiden.

Konventionen
----

1. Byte Reihenfolge

	Alle Integerwerte in NEO sind Little Endian, abgesehen von IP-Adressen und Ports (beide Big Endian).

2. Hash
	
	In NEO werden zwei unterschiedliche Hashfunktionen genutzt: SHA256 und RIPEMD160. SHA256 wird genutzt um lange Hashwerte zu generieren, RIPEMD160 für kurze Hashwerte. Generell wird ein Hashwert eines Objekts erzeugt, indem die Hashfunktion zweimal darauf angewendet wird. Zum Beispiel wird die SHA256-Funktion zweimal genutzt, um den Hashwert von Blöcken oder Transaktionen zu erzeugen. Wenn eine Contract-Adresse erzeugt wird, wird erst die SHA256-Funktion und dann die RIPEMD160-Funktion genutzt.

	Zusätzlich nutzen Blöcke die `Merkle Tree` genannte Hashstruktur. Diese berechnet den Hash jeder Transaktion, kombiniert die Hashwerte miteinander und bildet erneut einen Hash. Dieser Prozess wird wiederholt, bis nur ein Hashwert übrig bleibt (Merkle Root).

	
	
3. Datentyp mit variabler Länge

   + Variante: Integer mit variabler Länge können codiert werden, um Speicherplatz entsprechend dem eingegebenen Wert zu sparen.

      |Wert|Länge|Format|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + Varstr: String variabler Länge, bestehend aus Integer mit variabler Länge, gefolgt von Strings. Zeichenkette, UTF8 codiert.

      |Größe|Feld|Datentyp|Beschreibung|
      |---|---|---|---|
      |?|length|variant|Die Länge des Strings in Bytes|
      |length|string|uint8[length]|Der String|

   + Array: Das Array besteht aus einem Integer mit variabler Länge, gefolgt von einer Folge von Elementen.

4. Festkommazahl

   Daten in NEO wie Betrag oder Preis sind 64-Bit-Festkommazahlen und die Genauigkeit des Dezimalteils ist 10<sup>-8</sup>，Bereich：[-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>)

Datentyp
-------

1. Blockchain

Die Blockchain ist eine Art logische Struktur, die in Reihe mit einer einseitig verknüpften Liste verbunden ist. Es wird verwendet, um die Daten des gesamten Netzwerks zu speichern, z. B. Transaktionen oder Assets.

2. Block

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |4|Version|uint32|Version es Blocks, aktuell 0|
   |32|PrevBlock|uint256|Hashwert des vorausgehenden Blocks|
   |32|MerkleRoot|uint256|Roothash der Transaktionsliste|
   |4|Timestamp|uint32|Zeitstempel|
   |4|Height|uint32|Höhe des Blocks|
   |8|Nonce|uint64|Zufallszahl|
   |20|NextMiner|uint160|Contractadresse des nächsten Miners|
   |1|-|uint8|Festgelegt auf 1|
   |?|Script|script|Script, das genutzt wird, um den Block zu validieren|
   |?*?|Transaktions|tx[]|Transaktionsliste|

	Wenn Sie den Hash-Wert des Blocks berechnen, werden anstatt des gesamten Blocks nur die ersten sieben Felder im Blockheader berechnet, also Version, PrevBlock, MerkleRoot, Zeitstempel und Höhe, die Nonce, NextMiner. Da der MerkleRoot bereits den Hash-Wert aller Transaktionen enthält, beeinflusst die Änderung der Transaktion den Hash-Wert des Blocks.
	
   Datenstruktur des Blockheaders:

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |4|Version|uint32|Version des Blocks, aktuell 0|
   |32|PrevBlock|uint256|Hashwert des vorausgehenden Blocks|
   |32|MerkleRoot|uint256|Roothash der Transaktionsliste|
   |4|Timestamp|uint32|Zeitstempel|
   |4|Height|uint32|Höhe des Blocks|
   |8|Nonce|uint64|Zufallszahl|
   |20|NextMiner|uint160|Contractadresse des nächsten Miners|
   |1|-|uint8|Festgelegt auf 1|
   |?|Script|script|Script, das genutzt wird, um den Block zu validieren|
   |1|-|uint8|Festgelegt auf 0|

	Der Zeitstempel jedes Blocks muss nach dem Zeitstempel des vorherigen Blocks liegen. Im Allgemeinen beträgt die Differenz des Zeitstempels von zwei Blöcken etwa 15 Sekunden und eine Ungenauigkeit ist zulässig. Die Höhe des Blocks muss genau der Höhe des vorherigen Blocks plus 1 entsprechen.

3. Transaktion

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |1|Type|uint8|Transaktionstyp|
   |1|Version|uint8|Trading Version, aktuell 0|
   |?|-|-|Datensatz spezifisch für die Transaktion|
   |?*?|Attributes|tx_attr[]|Zusätzliche Features der Transaktion|
   |34*?|Inputs|tx_in[]|Input|
   |60*?|Outputs|tx_out[]|Output|
   |?*?|Scripts|script[]|Liste der Scripte die genutzt wurden, um eine Transaktion zu validieren|

   Alle Prozesse im NEO System werden als Transaktionen aufgezeichnet. Es gibt unterschiedliche Arten von Transaktionen

   |Wert|Name|Systemgebühr|Beschreibung|
   |---|---|---|---|
   |0x00|MinerTransaktion|0|Zuweisung der Gebühren|
   |0x01|IssueTransaktion|500\|0|Ausgabe des Assets|
   |0x02|ClaimTransaktion|0|GAS zuweisen|
   |0x20|EnrollmentTransaktion|1000|Anmeldung als Validator|
   |0x40|RegisterTransaktion|10000|Assets registrieren|
   |0x80|ContractTransaktion|0|Contract Transaktion|
   |0xd0|PublishTransaktion|500 * n|(Nicht nutzbar) Spezielle Transaktionen für Smart Contracts|
   |0xd1|InvocationTransaktion|0|Spezielle Transaktion zum Aufrufen von Smart Contracts|

	Jeder Transaktionstyp hat zusätzlich zum öffentlichen Feld auch ein eigenes exklusives Feld. Im Folgenden werden diese exklusiven Felder im Detail beschrieben.

   + MinerTransaction

      |Größe|Feld|Datentyp|Beschreibung|
      |---|---|---|---|
      |4|Nonce|uint32|Zufallszahl|

      Die erste Transaktion in jedem Block muss eine MinerTransaktion sein. Diese wird verwendet, um alle Transaktionsgebühren des aktuellen Blocks an den Validator zu vergüten.

      Die Zufallszahl in der Transaktion wird verwendet, um eine Hash-Kollision zu vermeiden.

   + IssueTransaction

      Es gibt keine speziellen Felder für eine Ausgabentransaktion.

      Asset Manager können die Assets, die über IssueTransaktion in der Blockchain von NEO registriert wurden, erstellen und an eine beliebige Adresse senden.

      Insbesondere wenn die Vermögenswerte, die ausgegeben werden, NEO sind, wird die Transaktion kostenlos gesendet.

      Die Zufallszahl in der Transaktion wird verwendet, um eine Hash-Kollision zu vermeiden.

   + ClaimTransaction

      |Größe|Feld|Datentyp|Beschreibung|
      |---|---|---|---|
      |34*?|Claims|tx_in[]||

   + EnrollmentTransaction

      |Größe|Feld|Datentyp|Beschreibung|
      |---|---|---|---|
      |33|PublicKey|ec_point|Öffentlicher Schlüssel des Validators|

      Die Transaktion stellt ein Art Anmeldeformular dar, das angibt, dass der Herausgeber der Transaktion sich als Validator anmelden möchte.

	  Der Weg zur Anmeldung ist: Um einen Typ der Transaktion "EnrollmentTransaktion" zu erstellen und eine Einzahlung an die Adresse des öffentlichen Schlüssels zu senden.

      Um die Registrierung zu stornieren, tun Sie Folgendes: Geben Sie die hinterlegten NEO an die Adresse des öffentlichen Schlüssels aus.

   + RegisterTransaction

      > [!Warnung]
      Wurde deaktiviert und durch Neo.Asset.Create für Smart Contracts ersetzt.

      Siehe [Alternatives .NET Smart Contract Framework](../sc/fw/dotnet/neo/Asset/Create.md)

      Siehe [Alternative Smart Contract API](../sc/api/neo.md)

   + ContractTransaktion

      Es gibt keine speziellen Attribute für einen Vertrag. Dies ist eine sehr häufige Art von Transaktion, da sie es einer Geldbörse erlaubt, NEO zu einer anderen zu senden. Die "Inputs" - und "Outputs" -Transaktionsfelder sind normalerweise für diese Transaktion wichtig (zum Beispiel, um zu bestimmen, wie viel NEO gesendet wird und an welche Adresse).

   + PublishTransaction

      > [!Warnung]
      Wurde deaktiviert und durch Neo.Contract.Creat für Smart Contracts ersetzt.Has been deactivated and replaced by Neo.Contract.Create for the smart contract.

      Siehe [Alternatives .NET Smart Contract Framework](../sc/fw/dotnet/neo/Contract/Create.md)

      Siehe [Alternative Smart Contract API](../sc/api/neo.md)

   + Eine Transaktion aufrufen

      | Größe   | Feld     | Datentyp    | Beschreibung              |
      | ---- | ------ | ------- | --------------- |
      | -    | -      | -       | Öffentliche Felder für Transaktionen        |
      | ?    | Script | uint8[] | Wird durch Smart Contract aufgerufen   |
      | 8    | Gas    | int64   | Benötigte Gebühren, um einen Smart Contract ausführen zu lassen |
      | -    | -      | -       | Öffentliche Felder für Transaktionen         |

4. Transaktionsattribute

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |1|Usage|uint8|Nutzung|
   |0\|1|length|uint8|Länge der Daten(Kann unter bestimmten Umständen ausbleiben)|
   |length|Data|uint8[length]|Externe Daten|

   Manchmal enthält die Transaktion einige Daten zur externen Verwendung, diese Daten werden in das Feld Attribute der Transaktion abgelegt.

   Jedes Transaktionsattribut hat einen anderen Nutzen:

   |Wert|Name|Beschreibung|
   |---|---|---|
   |0x00|ContractHash|Hashwert des Contracts|
   |0x02-0x03|ECDH02-ECDH03|Öffentlicher Schlüssel für ECDH Schlüsselaustausch|
   |0x20|Script|Zusätzliche Validierung von Transaktionen|
   |0x30|Vote|Für den Wahlmechanismus|
   |0x80|CertUrl|URL des Zertifikats|
   |0x81|BeschreibungUrl|URL der Beschreibung|
   |0x90|Beschreibung|Kurzbeschreibung|
   |0xa1-0xaf|Hash1-Hash15|Wird genutzt um eigene Hashwerte zu speichern|
   |0xf0-0xff|Remark-Remark15|Bemerkungen|

	Für ContractHash, ECDH-Serie und Hash-Serie ist die Datenlänge auf 32 Byte festgelegt und das Feld Länge wird weggelassen;

	Für CertUrl, DescriptionUrl, Description und Remark-Serie muss die Datenlänge klar definiert sein, und die Länge sollte 255 nicht überschreiten.
	
5. Input einer Transaktion

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |32|PrevHash|uint256|Hash der vorherigen Transaktion|
   |2|PrevIndex|uint16|Index der vorherigen Transaktion|

6. Output einer Transaktion

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |32|AssetId|uint256|Asset ID|
   |8|Wert|int64|Wert|
   |20|ScriptHash|uint160|Addresse des Empfängers|

   Jede Transaktion kann einen Output von bis zu 65536 haben.

7. Validationsscript

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |?|StackScript|uint8[]|Stackscriptcode|
   |?|RedeemScript|uint8[]|Contractscriptcode|

	   Das Stackskript kann nur für die PUSH-Operationen verwendet werden, mit denen Daten wie Signaturen in den Stack übertragen werden. Der Skriptinterpreter führt zuerst den Stackskriptcode aus und führt dann den COntractskriptcode aus.

   In einer Transaktion muss der Hash-Wert des Contractscriptcodes mit dem Transaktionsoutput konsistent sein, welcher Teil der Validierung ist. Der spätere Abschnitt beschreibt den Ausführungsprozess des Skripts im Detail.

Netzwerknachrichten
-------

Alle Nachrichten im Netzwerk haben folgende Struktur:

|Größe|Feld|Datentyp|Beschreibung|
|---|---|---|---|
|4|Magic|uint32|Protokoll ID|
|12|Command|char[12]|Kommando|
|4|length|uint32|Länge der Payload|
|4|Checksum|uint32|Checksumme|
|length|Payload|uint8[length]|Inhalt der Nachricht|

Definierter Magic Wert:

|Wert|Beschreibung|
|---|---|
|0x00746e41|Produktionsmodus|
|0x74746e41|Testmodus|

Der Befehl ist utf8-Code mit einer Länge von 12 Bytes. Der Extrateil ist gefüllt mit 0.

Die Checksumme ist die ersten 4 Bytes des Werts, die zweimal SHA256-Hash der Payload sind.

Nach verschiedenen Aufträgen hat Payload ein anderes Format, siehe unten:

1. version

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |4|Version|uint32|Version des Protokolls, aktuell 0|
   |8|Services|uint64|Der Service, den die Node zur Verfügung stellt. Aktuell 1|
   |4|Timestamp|uint32|Aktuelle Zeit|
   |2|Port|uint16|Port auf dem der Server hört. Ist 0 wenn unbenutzt|
   |4|Nonce|uint32|Wird genutzt, um mehrere Nodes auf einer öffentlichen IP zu unterscheiden|
   |?|UserAgent|varstr|Client ID|
   |4|StartHeight|uint32|Höhe der Blockchain|
   |1|Relay|bool|Ob empfangen oder weitergeleitet werden soll |


   Wenn eine Node eine Verbindungsanfrage erhält, sendet sie automatisch die Versionsnummer. Es kommt keine Kommunikation zustande, bis beide Seiten die Version des jeweils anderen erhalten haben.

2. verack

   Wenn eine Node eine version-Message erhält, antwortet sie sofort mit einer verack-Nachricht.

   Diese Nachricht hat keine Payload.

3. getaddr

   Generiert eine Anfrage an eine Node, um Informationen zu aktiven Nodes zu erhalten und so die Anzahl aktiver Verbindungen zu erhöhen.

   Diese Nachricht hat keine Payload

4. addr

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|Other nodes' address in network|

   Nachdem die Node eine getaddr-Nachricht erhält, sendet sie eine addr-Nachricht als Antwort und liefert Informationen über bekannte Nodes des Netzwerks.

5. getheaders

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hash des aktuellsten Blocks, den die Node anfordert|
   |32|HashStop|uint256|Hash des letzten Blocks, den die Node anfordert|

   Macht eine Anfrage an eine Node für Header-Pakete von höchsten 2000 Blöcken, die HashStart bis HashStop enthalten. Um weitere Blockhashes zu erhalten müssen Sie die getheaders-Nachricht erneut senden. Diese Nachricht kann verwendet werden, um die Blockchain ohne Transaktionsdaten schnell herunterzuladen.

6. headers

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |?*?|Headers|header[]|Header des Blocks|

   Wenn eine Node eine getheaders-Nachricht erhält, sendet die Node eine header-Nachricht als Antwort und liefert Informationen über die bekannten Nodes des Netzwerks.

7. getblocks

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|Hasn des aktuellsten Blocks, den die Node anfordert|
   |32|HashStop|uint256|Hash des letzten Blocks, den die Node anfordert|

   Sendet eine inv-Nachricht an eine Node, welche von HashStart bis Hashstop läuft. Die Nummer von Blocks geht dabei bis 500. Wenn Sie mehr als 500 Blockhashes benötigen müssen Sie eine zweite getblocks-Nachricht senden.

8. inv

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Bestandsdaten|

   Die Node kann Objektinformationen, die zu ihr gehören, mit dieser Nachricht senden. Diese Nachricht kann automatisch gesendet oder als Antwort auf getblocks-Nachrichten gesendet werden.

   Objektinformationen sind in der Liste inkludiert:

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |4|Type|uint32|Type des Objekts|
   |32|Hash|uint256|Hash des Objekts|

   Objekttypen:

   |Wert|Name|Beschreibung|
   |---|---|---|
   |0x01|TX|Transaktion|
   |0x02|Block|Block|
   |0xe0|Consensus|Konsensdaten|

9. getdata

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|Bestandsdaten|

   Um ein bestimmtes Objekt von einer Node abzufragen: Wird normalerweise gesendet nachdem ein inv-Paket empfangen wurde und das bekannte Element gelöscht wurde.

10. block

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |?|Block|block|Block|
   
   Sendet einen Block an eine Node, um auf eine getdata Nachricht zu antworten.

11. tx

   |Größe|Feld|Datentyp|Beschreibung|
   |---|---|---|---|
   |?|Transaktion|tx|Transaktion|

   Sendet eine Transaktion an eine Node, um auf eine getdata Nachricht zu antworten.

   |Größe|Feld|Datentyp|Beschreibung|
   |----|---------|--------- |----------------- |
   |32 *?|HashStart|uint256[]|Die Node ist bekannt als der letzte Blockhash|
   |32|hashStop|uint256|Fragt den letzten Block ab|
