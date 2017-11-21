# Der 'Byzantine Fault Tolerance' Algorithmus für Blockchains

Erik Zhang

erik@vcage.com 

## Abstrakt

Dieser Artikel schlägt einen verbesserten Byzantinischen Fehlertoleranzalgorithmus vor, der für ein Blockchain-System angepasst wurde. Hypothetisch können Nachrichten in diesem System Verlust, Beschädigung, Latenz und Wiederholung unterliegen. Außerdem muss die Sendereihenfolge nicht notwendigerweise mit der Empfangsreihenfolge von Nachrichten übereinstimmen. Die Aktivitäten von Knoten können beliebig sein, sie können jederzeit beitreten und das Netzwerk beenden; sie können Informationen auch abladen und verfälschen oder einfach aufhören zu arbeiten. Künstliche oder nicht-künstliche Störungen können ebenfalls auftreten. Unser Algorithmus liefert eine Fehlertoleranz 𝑓 = ⌊ (𝑛−1) / 3 ⌋ to für ein Konsenssystem, das n Knoten umfasst. Diese Toleranzkapazität umfasst Sicherheit und Benutzerfreundlichkeit und eignet sich für jede Netzwerkumgebung.

Dieser Artikel schlägt einen verbesserten, an ein Blockchainsystem angepassten, 'Byzantine Fault Tolerance' Algorithmus vor. Hypothetisch können Nachrichten in einem solchen System Verlust, Beschädigung, hoher Latenz und Wiederholungen unterliegen. Außerdem muss die Sendereihenfolge nicht notwendigerweise mit der Empfangsreihenfolge von Nachrichtne übereinstimmen. Die Aktivitäten von Nodes sind ebenfalls nicht berechenbar, sie können jederzeit das Netzwerk betreten oder verlassen; sie können Informationen verlieren, verfälschen oder einfach aufhören zu arbeiten. Künstlich herbeigeführte und andere Störungen können ebenso auftreten. Der vorgestellte Algorithmus liefert eine Fehlertoleranz von ð‘“ = âŒŠ (ð‘›âˆ’1) / 3 âŒ‹ für ein Konsenssystem, das n Nodes umfasst. Diese Toleranzkapazität beinhaltet Sicherheit und Benutzerfreundlichkeit und eignet sich für jede Netzwerkumgebung.

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


## The Algorithm 

â€‹Our algorithm ensures security as well as usability. With erroneous nodes in the consensus making no more than âŒŠ (ð‘›âˆ’1) / 3 âŒ‹ , the functionality and stability of the system is guaranteed. In it, ð‘› = |ð‘…| suggests the total number of nodes joined in the consensus making while R stands for the set of consensus nodes. Given ð‘“ = âŒŠ (ð‘›âˆ’1) / 3 âŒ‹ , f stands for the maximum number of erroneous nodes allowed in the system. In fact, the total ledger is maintained by bookkeeping nodes while ordinary nodes do not participate in the consensus making. This is to show the entire consensus making procedures.

All consensus nodes are required to maintain a state table to record current consensus status. The data set used for a consensus from its beginning to its end is called a View. If consensus cannot be reached within the current View, a View Change will be required. We identify each View with a number v, starting from 0 and it may increase till achieving the consensus.

â€‹We identify each consensus node with a number, starting from 0, the last node is numbered n âˆ’ 1. For each round of consensus making, a node will play speaker of the house while other nodes play congressmen. The speakerâ€™s number p will be determined by the following algorithm: Hypothetically the current block height is h, then ð‘ = (â„Ž âˆ’ ð‘£) ð‘šð‘œð‘‘ ð‘›, pâ€™s value range will be  0 â‰¤ ð‘ < ð‘› .

â€‹A new block will be generated with each round of consensus, with at least ð‘› âˆ’ ð‘“ signatures from bookkeeping nodes. Upon the generation of a block, a new round of consensus making shall begin, resetting v=0.

###  General Procedures 

Set the time intervals of block generation as t, under normal circumstances, the algorithm executes in the following proceduresï¼š

1) A node broadcasts transaction data to the entire network, attached with the sender signature;

2) All bookkeeping nodes monitors transaction data broadcasting independently and stores the data in its memory respectively; 

3) After the time t, the speaker sends âŒ©ð‘ƒð‘’ð‘Ÿð‘ð‘Žð‘Ÿð‘’ð‘…ð‘’ð‘žð‘¢ð‘’ð‘ ð‘¡,â„Ž,ð‘£,ð‘,ð‘ð‘™ð‘œð‘ð‘˜,âŒ©ð‘ð‘™ð‘œð‘ð‘˜âŒª<sub>ðœŽð‘</sub>âŒªï¼› 

4) After receiving the proposal, congressmen i send âŒ©ð‘ƒð‘’ð‘Ÿð‘ð‘Žð‘Ÿð‘’ð‘…ð‘’ð‘ ð‘ð‘œð‘›ð‘ ð‘’,â„Ž,ð‘£,ð‘–,âŒ©ð‘ð‘™ð‘œð‘ð‘˜âŒª<sub>ðœŽð‘–</sub>âŒª ;

â€‹5) Any node, upon receiving at least ð‘› âˆ’ ð‘“  âŒ©ð‘ð‘™ð‘œð‘ð‘˜âŒª<sub>ðœŽð‘–</sub>, reaches a consensus and publishes a full block;

6) Any node, after receiving the full block, deletes the transaction in question from its memory and begins the next round the consensus;

It is required that, for all the consensus nodes, at least ð‘› âˆ’ ð‘“ nodes are in the same original state. This is to say, for all the nodes i, the block height h and View number v are the same. This is not difficult, consistency of h could be reached by synchronizing the blocks while consistency of v could reached by changing the View. Block synchronizing is not covered in this article. For View change, check next section.

Nodes, after monitoring the broadcasting and receiving the proposal, shall validate the transactions. They cannot write an illegal transaction in the memory once the latter is exposed. If an illegal transaction is contained in the proposal, this round of consensus will be abandoned and the View change will take place immediately. The validation procedures are as follows:

1) Is the data format of the transaction consistent with the system rules? If no, the transaction is ruled illegal;

2) Is the transaction already in the blockchain? If yes, the transaction is ruled illegal;

3) Are all the contract scripts of the transaction correctly executed? If no, the transaction is ruled illegal;

4) Is there multiple-spend in the transaction? If yes, the transaction is ruled illegal;

5) If the transaction had not been ruled illegal in the above procedures, it will be ruled legal;

### View Change 

If, after 2<sup>ð‘£+1</sup> â‹… ð‘¡ time interval, the nodes i cannot reach a consensus or should they receive proposals that contain illegal transactions, the View Change will take place: 

1) Given k=1, ð‘£<sub>ð‘˜</sub> = ð‘£ + ð‘˜ ;

2) Nodes i send View Change request âŒ©ð¶â„Žð‘Žð‘›ð‘”ð‘’ð‘‰ð‘–ð‘’ð‘¤,â„Ž,ð‘£,ð‘–,ð‘£<sub>ð‘˜</sub>âŒª ;

3) Once any node receives at least ð‘› âˆ’ ð‘“  same v<sub>k</sub> from different i, the View Change is
completed. Set ð‘£ = ð‘£<sub>ð‘˜</sub> and the consensus making begins;

4) If, after 2<sup>ð‘£+1</sup> â‹… ð‘¡ time interval, the View Change is not completed, the k will increase and back to step 2);

With the k increasing, the overtime waiting time will increase exponentially, so frequent View Change will be avoided and nodes are urged to reach consistency over v.

Before the completion of View Change, the original View v is still valid, so unnecessary View Change caused by occasional network latency can be avoided. 

### Flow Chart

![](~/assets/consensus_flowchart.jpg)

## Fault Tolerance Capacity 

â€‹Our algorithm provides ð‘“ = âŒŠ (ð‘›âˆ’1) / 3 âŒ‹ fault tolerance to a consensus system that comprises n nodes. This tolerance capacity includes security and usability and is suite for any network environment.

Request data from nodes contain sender signatures, so malicious bookkeeping nodes cannot falsify requests. Instead, they will try to reverse the system status back to the past, forcing the system to fork.

Hypothetically, in the network environment of the system, consensus nodes are divided into 3 parts: ð‘… = ð‘…1 âˆª ð‘…2 âˆª ð¹ , and ð‘…1 âˆ© ð‘…2 = âˆ… , ð‘…1 âˆ© ð¹ = âˆ… ï¼Œð‘…2 âˆ© ð¹ = âˆ… . Also hypothetically,
both R1 and R2 are honest bookkeeping nodes in an information silo that they can only communicate with nodes in their set; F are all malicious nodes in coordination; moreover, the network condition of F allows them to communicate with any node, including R1 and R2.
If F wishes to fork the system, they have to reach consensus with R1 and publish blocks, and
then reach a second consensus without informing the R2, revoking the consensus with R1.
â€‹To reach this, it is necessary that |ð‘…1| + |ð¹| â‰¥ ð‘› âˆ’ ð‘“ and |ð‘…2| + |ð¹| â‰¥ ð‘› âˆ’ ð‘“ .
In the worst case scenario, |ð¹| = ð‘“â€‹ , i.e. the number of malicious nodes is at the maximum that the system could tolerate the aforementioned relation becomes |ð‘…1| â‰¥ ð‘› âˆ’ 2ð‘“â€‹ and â€‹|ð‘…2| â‰¥ ð‘› âˆ’ 2ð‘“. Added together, |ð‘…1| + |ð‘…2| â‰¥ 2ð‘› âˆ’ 4ð‘“â€‹, which could be simplified as â€‹ð‘› â‰¤ 3ð‘“. Given that ð‘“ = âŒŠ (ð‘›âˆ’1) / 3 âŒ‹, which contradicts with the former, it can be proven that the system cannot be forked within the tolerance range. 

## Reference 

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] èŒƒæ·, æ˜“ä¹å¤©, èˆ’ç»§æ­¦. æ‹œå åº­ç³»ç»ŸæŠ€æœ¯ç ”ç©¶ç»¼è¿°[J]. è½¯ä»¶å­¦æŠ¥, 2013, 6: 012. 

