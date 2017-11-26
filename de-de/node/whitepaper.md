# Der 'Byzantine Fault Tolerance' Algorithmus für Blockchains

Erik Zhang

erik@vcage.com 

## Abstrakt

Dieser Artikel schlägt einen verbesserten, an ein Blockchainsystem angepassten, 'Byzantine Fault Tolerance' Algorithmus vor. Hypothetisch können Nachrichten in einem solchen System Verlust, Beschädigung, hoher Latenz und Wiederholungen unterliegen. Außerdem muss die Sendereihenfolge nicht notwendigerweise mit der Empfangsreihenfolge von Nachrichtne übereinstimmen. Die Aktivitäten von Nodes sind ebenfalls nicht berechenbar, sie können jederzeit das Netzwerk betreten oder verlassen; sie können Informationen verlieren, verfälschen oder einfach aufhören zu arbeiten. Künstlich herbeigeführte und andere Störungen können ebenso auftreten. Der vorgestellte Algorithmus liefert eine Fehlertoleranz von 𝑓 = ⌊ (𝑛−1) / 3 ⌋ für ein Konsenssystem, das n Nodes umfasst. Diese Toleranzkapazität beinhaltet Sicherheit und Benutzerfreundlichkeit und eignet sich für jede Netzwerkumgebung.

## Überblick

Eine Blockchain ist ein dezentral verteiltes Buchhaltungssystem. Es kann für die Registrierung und Ausgabe von digitalisierten Vermögenswerten, Eigentumsrechten, Kreditpunkten und anderen Dingen verwendet werden. Es ermöglicht Übertragung, Zahlung und Transaktion per Peer-to-Peer-Netzwerk. Die Blockchaintechnologie wurde ursprünglich von "Satoshi Nakamoto" in einer Mailingliste für Kryptographie vorgeschlagen, es entstand daraus Bitcoin. Seitdem sind zahlreiche Anwendungen auf Basis der Blockchaintechnologie entstanden, wie zum Beispiel E-Cash-Systeme, Börsen und Smart-Contract-Systeme.

Ein Blockchain-System ist gegenüber einem traditionell zentralisierten Buchhaltungssytem wegen seiner Offenheit, Unveränderlichkeit und des Mechanismus zur Verhinderung von Mehrfachausgaben von Vorteil. Es ist außerdem nicht auf eine vertrauenswürdige Drittpartei angewiesen.

Wie alle dezentralen Systeme sind Blockchain-Systeme jedoch mit einer hohen Netzwerklatenz, Übertragungsfehlern, Softwarefehlern, Sicherheitslücken und Hackerangriffen konfrontiert. Darüber hinaus legt die dezentrale Natur nahe, dass keinem Teilnehmer des Systems vertraut werden kann. Böswillige Nodes können ebenso auftreten wie Datenunterschiede aufgrund widersprüchlicher Interessen der Teilnehmer.

Um diesen potenziellen Fehlern entgegenzuwirken, benötigt ein Blockchain-System einen effizienten Konsensmechanismu, um sicherzustellen, dass jede Node eine Kopie einer allgemein anerkannten Version der Blockchain hat. Traditionelle Fehlertoleranzmechanismen, die bestimmte Probleme betreffen, können möglicherweise nicht vollständig in der Lage sein, die Probleme anzugehen, mit denen dezentrale Blockchainsysteme konfrontiert sind. Eine universelle Fehlertoleranzlösung ist erforderlich.

Der Proof-of-Work-Mechanismus [1], der bei Bitcoin eingesetzt wird, löst dieses Problem ziemlich brilliant. Aber der Mechanismus hat einen offensichtlichen Preis, d.h. erhebliche Strom- und Materialkosten. Außerdem müssen andere Blockchains andere Hash-Algorithmen nutzen, um Angriffe zu verhindern. Zum Beispiel nutzt Litecoin SCRYPT anstelle von Bitcoins SHA256.

Der 'Byzantine Fault Tolerance' Mechanismus ist eine unverselle Lösung für dezentralisierte Systeme [5]. In diesem Artikel, der auf der von Castro und Liskov 1999 vorgeschlagenen praktischen byzantinischen Fehlertoleranz (PBFT) [3] basiert, wird ein verbesserter Algorithmus für die Byzantinische Fehlertoleranz speziell für Blockchainsysteme vorgeschlagen.

## Systemmodell

Eine Blockchain ist ein dezentralisiertes Buchhaltungssystem, in dem sich alle Teilnehmer über ein Peer-to-Peer-Netzwerk miteinander verbinden. Alle darin enthaltenen Nachrichten werden per Broadcast gesendet. Es gibt zwei verschiedene Rollen: normale Nodes und Bookkeeping Nodes. Normale Nodes nutzen das System, um Blockchaindaten zu übertragen und auszutauschen. Bookkeeping Nodes stellen einen Buchhaltungsdienst für das Netzwerk bereit und schreiben die Blockchain.

Hypothetisch können Nachrichten in diesem System Verlust, Beschädigung, hohen Latenzen oder Wiederholungen unterliegen. Außerdem muss die Sendereihenfolge nicht notwendigerweise mit der Empfangsreihenfolge von Nachrichten übereinstimmen. Die Aktivitäten von Nodes können unberechenbar sein. Sie können das Netzwerk jederzeit betreten oder verlassen, Informationen verlieren, verfälschen oder einfach aufhören zu arbeiten. Auch können künstlich herbeigeführte sowie natürliche Störungen auftreten.

Integrität und Authentizität der Informationsübertragung werden durch Kryptographie sichergestellt. Absender müssen dazu Signaturen an den Hash-Wert der gesendeten Nachricht anhängen. Hier definieren wir: 〈𝑚〉<sub>𝜎𝑖</sub> ist die digitale Signatur der Nachricht m der Node i, während D(m) der Hash-Wert der Nachricht m ist. Ohne besondere Erläuterungen sind alle in diesem Artikel genannten Signaturen Signaturen für den Nachrichten Hash-Wert.


## Der Algorithmus

Unser Algorithmus sorgt für Sicherheit und Benutzerfreundlichkeit. Mit fehlerhaften Nodes im Konsens von nicht mehr als ⌊ (𝑛-1) / 3 ⌋ ist die Funktionalität und Stabilität des Systems gewährleistet. Darin schlägt 𝑛 = | 𝑅 | die Gesamtanzahl von Nodes vor, die an der Konsensbildung beteiligt sind, während R für die Menge von Konsensnodes steht. Wenn 𝑓 = ⌊ (𝑛-1) / 3 </s> gegeben ist, steht f für die maximale Anzahl von fehlerhaften Nodes, die in dem System erlaubt sind. Tatsächlich wird die gesamte Blockchain von Bookkeeping Nodes verwaltet, während gewöhnliche Nodes nicht an der Konsensfindung beteiligt sind. 

Alle Konsensnodes müssen eine Logdatei unterhalten, um den aktuellen Konsensstatus aufzuzeichnen. Der für einen Konsens von Anfang bis Ende verwendete Datensatz wird als View bezeichnet. Wenn in der aktuellen View kein Konsens erreicht werden kann, ist eine Änderung des View erforderlich. Wir identifizieren jede View mit einer Zahl v, beginnend bei 0, und sie kann sich bis zum Erreichen des Konsenses erhöhen.

Wir identifizieren jede Konsensnode mit einer Zahl, beginnend bei 0, die  letzte Node ist mit n - 1 nummeriert. Für jede Runde der Konsensfindung wird eine Node Sprecher des Hauses spielen, während andere Nodes Kongressabgeordnete spielen. Die Sprecherzahl p wird durch den folgenden Algorithmus bestimmt: Hypothetisch ist die aktuelle Blockhöhe h, dann ist 𝑝 = (ℎ - 𝑣) 𝑚𝑜𝑑 𝑛, der Wertebereich von p ist 0 ≤ 𝑝 <𝑛.

Bei jeder Konsensrunde wird ein neuer Block mit mindestens 𝑛 - 𝑓 Signaturen von Bookkeeping Nodes generiert. Bei der Erzeugung eines Blocks soll eine neue Runde der Konsensbildung beginnen, wobei v = 0 zurückgesetzt wird.


### Allgemeine Verfahren

Wenn Sie die Zeitintervalle der Blockgenerierung als t festlegen, wird  unter normalen Umständen der Algorithmus in den folgenden Prozeduren durchgeführt:

1) Eine Node sendet Transaktionsdaten mit der Absendersignatur an das gesamte Netzwerk.

2) Alle Bookkeeping Nodes überwachen unabhängig die Transaktionsdatenübertragung und speichern die Daten jeweils in ihrem Speicher;

3) Nach der Zeit t sendet der Sprecher 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉𝜎𝑝〉；

4) Nach dem Empfang des Vorschlags senden die Kongressabgeordneten i <𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒, ℎ, 𝑣, 𝑖, <𝑏𝑙𝑜𝑐𝑘> σ𝑖>;

5) Jede Node, die mindestens 𝑛 - 𝑓 <𝑏𝑙𝑜𝑐𝑘> σ𝑖 erhält, erreicht einen Konsens und veröffentlicht einen vollständigen Block.

6) Jede Node löscht, nachdem sie den vollen Block erhalten hat, die fragliche Transaktion aus dem Speicher und beginnt die nächste Konsensrunde.

Es ist erforderlich, dass für alle Konsensnodes mindestens 𝑛 - 𝑓 Nodes in demselben ursprünglichen Zustand sind. Das heißt, für alle Nodes i sind die Blockhöhe h und die Viewanzahl v gleich. Die Konsistenz von h kann durch die Synchronisation der Blöcke erreicht werden,  während die Konsistenz von v durch Ändern der View erreicht werden kann. Die Blocksynchronisierung wird in diesem Artikel nicht behandelt. Überprüfen Sie für die Änderung der View den nächsten Abschnitt.

Nodes validieren die Transaktionen, nachdem sie das Senden und Empfangen des Vorschlags überwacht haben. Sie können eine illegale Transaktion nicht in den Speicher schreiben, sobald diese freigegeben ist. Wenn eine illegale Transaktion im Vorschlag enthalten ist, wird diese Konsensrunde abgebrochen und die Änderung der View erfolgt sofort. Die Validierungsprozeduren sind wie folgt:

1) Stimmt das Datenformat der Transaktion mit den Systemregeln überein? Falls nein, wird die Transaktion für illegal erklärt.

2) Befindet sich die Transaktion bereits in der Blockchain? Falls ja, wird die Transaktion für illegal erklärt.

3) Werden alle Smart Contract-Skripte der Transaktion korrekt ausgeführt? Falls nein, wird die Transaktion für illegal erklärt.

4) Gibt es mehrere Ausgaben in der Transaktion? Falls ja, wird die Transaktion für illegal erklärt.

5) Wenn die Transaktion in den obigen Verfahren nicht für rechtswidrig erklärt wurde, wird dies gesetzlich geregelt.

### View Änderung 

Wenn nach einem Zeitintervall von 2𝑣 + 1 ⋅ die Knoten nicht zu einem Konsens gelangen können oder wenn sie Vorschläge erhalten, die illegale Transaktionen enthalten, findet die Viewänderung statt:

1) Gegeben sei k = 1, 𝑣𝑘 = 𝑣 + 𝑘;

2) Node i sendet View-Änderungsanforderung <𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤, ℎ, 𝑣, 𝑖, 𝑣𝑘>;

3) Sobald eine beliebige Node mindestens 𝑛 - 𝑓 dasselbe vk von verschiedenen i empfängt, ist die Viewänderung abgeschlossen. Setze 𝑣 = 𝑣𝑘 und die Konsensfindung beginnt;

4) Wenn nach 2𝑣 + 1 ⋅ 𝑡 Zeitintervallen die Viewänderung nicht abgeschlossen ist, wird k erhöht und es geht zurück zu Schritt 2);

Mit zunehmendem k wird die Wartezeit exponentiell ansteigen, so dass häufige Viewänderungen vermieden werden und Nodes dazu angehalten werden, Konsistenz über v zu erreichen.

Vor dem Abschluss der Viewänderung ist die ursprüngliche View v weiterhin gültig, sodass unnötige Viewänderungen, die durch gelegentliche Netzwerklatenz verursacht werden, vermieden werden können.


### Flow Chart

![](~/assets/consensus_flowchart.jpg)

## Fehlertoleranzkapazität

Unser Algorithmus liefert 𝑓 = ⌊ (𝑛-1) / 3 ⌋ Fehlertoleranz zu einem Konsenssystem, das n Nodes umfasst. Diese Toleranzkapazität umfasst Sicherheit und Benutzerfreundlichkeit und ist für jede Netzwerkumgebung geeignet.

Die Anforderungsdaten von Nodes enthalten Absendersignaturen, so dass bösartige Bookkeeping Nodes keine Anforderungen fälschen können. Stattdessen werden sie versuchen, den Systemstatus zurück in die Vergangenheit zu setzen, wodurch das System gezwungen wird, zu forken.

Hypothetisch sind Konsensusnodes in der Netzwerkumgebung des Systems in 3 Teile unterteilt: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 und 𝑅1 ∩ 𝑅2 = ∅, 𝑅1 ∩ 𝐹 = ∅, 𝑅2 ∩ 𝐹 = ∅. Auch hypothetisch sind sowohl R1 als auch R2 ehrliche Bookkeeping Nodes in einem Informationssilo, die nur mit Nodes in ihrer Gruppe kommunizieren können. F sind alle bösartigen Nodes in Koordination; Darüber hinaus ermöglicht die Netzwerkbedingung von F die Kommunikation mit einer beliebigen Node, einschließlich R1 und R2. Wenn F das System forken möchte, muss es einen Konsens mit R1 erreichen und Blöcke veröffentlichen und dann einen zweiten Konsens erreichen, ohne den R2 zu informieren, wodurch der Konsens mit R1 widerrufen wird. Um dies zu erreichen, ist es notwendig, dass | 𝑅1 | + | 𝐹 | ≥ 𝑛 - 𝑓 und | 𝑅2 | + | 𝐹 | ≥ 𝑛 - 𝑓. Im schlimmsten Fall wird | 𝐹 | = 𝑓, d.h. die Anzahl der böswilligen Nodes ist maximal, so dass das System die oben erwähnte Beziehung tolerieren könnte, dann wird | 𝑅1 | ≥ 𝑛 - 2𝑓 und | 𝑅2 | ≥ 𝑛 - 2𝑓. Zusammen hinzugefügt, | 𝑅1 | + | 𝑅2 | ≥ 2𝑛 - 4𝑓, was als 𝑛 ≤ 3𝑓 vereinfacht werden kann. Da 𝑓 = ⌊ (𝑛-1) / 3 ⌋ ist, was im Widerspruch zu ersterem steht, kann bewiesen werden, dass das System nicht innerhalb des Toleranzbereichs geforkt werden kann.

## Verweise

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012.

