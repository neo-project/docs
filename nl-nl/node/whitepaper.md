# Een Byzantine Fault Tolerance Algoritme voor de Blockchain 

*Originele versie door: Erik Zhang*

[erik@vcage.com](mailto:erik@vcage.com)

## Abstract 

​Dit artikel betreft een verbeterd Byzantine Fault Tolerance algoritme, gemodificeerd voor de blockchain. Hypothetisch kunnen berichten in dit systeem verloren gaan, beschadigd raken, herhaald worden of vertraagd zijn. Daarnaast kan de volgorde van sturen niet overeenkomen met de volgorde van ontvangen berichten. De activiteit van nodes kan willekeurig zijn, ze kunnen elk moment stoppen of juist actief worden en ze kunnen zelfs valse informatie rondsturen. Ook kunnen kunstmatige of niet-kunstmatige glitches voorkomen. Ons algoritme levert een `𝑓 = ⌊ (𝑛−1) / 3 ⌋` fouttolerantie voor een consensussysteem met `n` aantal nodes. Deze fouttolerantie maakt veiligheid en gebruik van het systeem mogelijk en kan worden toegepast op elk netwerk.

## Overzicht

Een blockchain is een gedecentraliseerd ledger-systeem (grootboek). Het kan worden gebruikt voor het registreren en distribueren van digitaal bezit (digitalized assets), certificaten van bewijs van eigendom, krediet et cetera. Met de blockchain kunnen transacties peer-to-peer worden uitgevoerd. De blockchaintechnologie is als eerst gedefiniëerd door Satoshi Nakamoto in een cryptografische maillijst; hij noemde het de Bitcoin. Sindsdien zijn vele applicaties op de blockchain ontstaan, zoals e-cash systemen, aandelenbeurzen en Smart Contract systemen.

Een blockchainsysteem heeft, vergeleken met een veelgebruikt gecentraliseerd grootboek-systeem, als voordeel dat iedereen het kan inzien, dat er niet mee geknoeid kan worden, dat bezit niet dubbel kan worden uitgegeven en dat er geen vertrouwde derde nodig is om het systeem te laten werken.

Desalniettemin kampen blockchainsystemen met dezelfde uitdagingen als elk gedistribueerd systeem: netwerkvertraging, fouten in overdracht, software-bugs, gaten in veiligheidssystemen en de dreiging van black-hat hackers. Hiernaast stelt de gedecentraliseerde natuur van het systeem dat geen van de gebruikers van het systeem kan worden vertrouwd; kwaadwillende nodes kunnen de kop opsteken, met als gevolg verschillen in data door tegenstrijdige belangen.

Om deze uitdagingen aan te gaan, heeft een blockchainsysteem een efficiënt consensusmechanisme nodig om zeker te zijn dat elke node een kopie heeft van een erkende versie van het totale grootboek. Traditionele fouttolerantiemechanismes zijn vaak niet volledig in staat om deze problemen op te lossen; de behoefte bestaat voor een fouttolerantiesysteem dat alle problemen tegelijk aanpakt.

Het Proof-of-Work-mechanisme[1], dat wordt gebruikt door onder andere Bitcoin, pakt dit systeem op een bijzonder geniale manier aan. De kosten die deze methode met zich meeneemt (in elektriciteit en geld) zijn echter aanzienlijk. Daarnaast moeten nieuwe blockchainsystemen andere hashing-algoritmes gebruiken om eventuele aanvallen door Bitcoin te voorkomen. Litecoin gebruikt bijvoorbeeld SCRYPT in plaats van Bitcoin's SHA256.

Het Byzantine Fault Tolerance-mechanisme is een universele oplossing voor een gedistribueerd systeem[5]. In dit artikel leggen wij, aan de hand van het Practical Byzantine Fault Tolerance (PBFT)[3] dat is voorgesteld door Castro en Liskov in 1999, een verbeterd Byzantine Fault Tolerance-algoritme voor om gebruikt te worden in blockchainsystemen. 

## Systeemmodel

Een blockchain is een gedistribueerd grootboeksysteem waarin deelnemers verbonden zijn door middel van een peer-to-peer-netwerk. Alle berichten binnen dit netwerk worden verstuurd door ze uit te zenden. Er bestaan twee rollen in het systeem: Ordinary nodes en Bookkeeping nodes. Ordinary nodes gebruiken het systeem om te zenden en uit te wisselen, waarbij de data uit het grootboek wordt geaccepteerd, terwijl Bookkeeping nodes fungeren als accountant voor het gehele netwerk en het grootboek bijhouden.

Hypothetisch kunnen in dit systeem berichten lijden aan verlies, schade, netwerkvertraging en herhaling. Ook kan de volgorde van sturen niet overeenkomen met de volgorde van ontvangen. De activiteit van nodes kan willekeurig zijn, ze kunnen meedoen en stoppen wanneer ze maar willen en ze kunnen informatie vervalsen. Kunstmatige en niet-kunstmatige glitches kunnen hiernaast ook nog voorkomen.

De integriteit en echtheid van de informatieoverdracht worden verzekerd door middel van cryptografie, waarbij de zenders een signature (ondertekening) moeten toevoegen aan de hashwaarde van het gestuurde bericht. Hierbij wordt 〈𝑚〉<sub>𝜎𝑖</sub> gedefiniëerd als de `m`-de ondertekening van een bericht van node `i`, terwijl `D(m)` de hashwaarde van bericht `m` is. Zonder verdere toelichting wordt in dit artikel met 'ondertekening' de ondertekening van de hashwaarde van een bericht bedoeld.

## Het Algoritme

​Ons algoritme maakt veiligheid en gebruik mogelijk. Zolang het defecte aantal nodes niet groter is dan `⌊ (𝑛−1) / 3 ⌋`, is de functionaliteit en stabilitiet van het systeem gewaarborgd. In deze formule staat `n = |R|` voor het totale aantal nodes in de consensusactiviteit waarbij `R` staat voor de verzameling consensusnodes. In `𝑓 = ⌊ (𝑛−1) / 3 ⌋` staat `f` voor het maximum aantal defecte nodes dat een systeem aankan. Dit betreft consensusnodes, aangezien normale (Ordinary) nodes niet deelnemen aan de consensusactiviteit.

All consensus nodes are required to maintain a state table to record current consensus status. The data set used for a consensus from its beginning to its end is called a View. If consensus cannot be reached within the current View, a View Change will be required. We identify each View with a number v, starting from 0 and it may increase till achieving the consensus.

​We identify each consensus node with a number, starting from 0, the last node is numbered n − 1. For each round of consensus making, a node will play speaker of the house while other nodes play congressmen. The speaker’s number p will be determined by the following algorithm: Hypothetically the current block height is h, then 𝑝 = (ℎ − 𝑣) 𝑚𝑜𝑑 𝑛, p’s value range will be  0 ≤ 𝑝 < 𝑛 .

​A new block will be generated with each round of consensus, with at least 𝑛 − 𝑓 signatures from bookkeeping nodes. Upon the generation of a block, a new round of consensus making shall begin, resetting v=0.

###  General Procedures 

Set the time intervals of block generation as t, under normal circumstances, the algorithm executes in the following procedures：

1) A node broadcasts transaction data to the entire network, attached with the sender signature;

2) All bookkeeping nodes monitors transaction data broadcasting independently and stores the data in its memory respectively; 

3) After the time t, the speaker sends 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑝</sub>〉； 

4) After receiving the proposal, congressmen i send 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒,ℎ,𝑣,𝑖,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>〉 ;

​5) Any node, upon receiving at least 𝑛 − 𝑓  〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>, reaches a consensus and publishes a full block;

6) Any node, after receiving the full block, deletes the transaction in question from its memory and begins the next round the consensus;

It is required that, for all the consensus nodes, at least 𝑛 − 𝑓 nodes are in the same original state. This is to say, for all the nodes i, the block height h and View number v are the same. This is not difficult, consistency of h could be reached by synchronizing the blocks while consistency of v could reached by changing the View. Block synchronizing is not covered in this article. For View change, check next section.

Nodes, after monitoring the broadcasting and receiving the proposal, shall validate the transactions. They cannot write an illegal transaction in the memory once the latter is exposed. If an illegal transaction is contained in the proposal, this round of consensus will be abandoned and the View change will take place immediately. The validation procedures are as follows:

1) Is the data format of the transaction consistent with the system rules? If no, the transaction is ruled illegal;

2) Is the transaction already in the blockchain? If yes, the transaction is ruled illegal;

3) Are all the contract scripts of the transaction correctly executed? If no, the transaction is ruled illegal;

4) Is there multiple-spend in the transaction? If yes, the transaction is ruled illegal;

5) If the transaction had not been ruled illegal in the above procedures, it will be ruled legal;

### View Change 

If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the nodes i cannot reach a consensus or should they receive proposals that contain illegal transactions, the View Change will take place: 

1) Given k=1, 𝑣<sub>𝑘</sub> = 𝑣 + 𝑘 ;

2) Nodes i send View Change request 〈𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤,ℎ,𝑣,𝑖,𝑣<sub>𝑘</sub>〉 ;

3) Once any node receives at least 𝑛 − 𝑓  same v<sub>k</sub> from different i, the View Change is
completed. Set 𝑣 = 𝑣<sub>𝑘</sub> and the consensus making begins;

4) If, after 2<sup>𝑣+1</sup> ⋅ 𝑡 time interval, the View Change is not completed, the k will increase and back to step 2);

With the k increasing, the overtime waiting time will increase exponentially, so frequent View Change will be avoided and nodes are urged to reach consistency over v.

Before the completion of View Change, the original View v is still valid, so unnecessary View Change caused by occasional network latency can be avoided. 

### Flow Chart

![](~/assets/consensus_flowchart.jpg)

## Fault Tolerance Capacity 

​Our algorithm provides 𝑓 = ⌊ (𝑛−1) / 3 ⌋ fault tolerance to a consensus system that comprises n nodes. This tolerance capacity includes security and usability and is suite for any network environment.

Request data from nodes contain sender signatures, so malicious bookkeeping nodes cannot falsify requests. Instead, they will try to reverse the system status back to the past, forcing the system to fork.

Hypothetically, in the network environment of the system, consensus nodes are divided into 3 parts: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 , and 𝑅1 ∩ 𝑅2 = ∅ , 𝑅1 ∩ 𝐹 = ∅ ，𝑅2 ∩ 𝐹 = ∅ . Also hypothetically,
both R1 and R2 are honest bookkeeping nodes in an information silo that they can only communicate with nodes in their set; F are all malicious nodes in coordination; moreover, the network condition of F allows them to communicate with any node, including R1 and R2.
If F wishes to fork the system, they have to reach consensus with R1 and publish blocks, and
then reach a second consensus without informing the R2, revoking the consensus with R1.
​To reach this, it is necessary that |𝑅1| + |𝐹| ≥ 𝑛 − 𝑓 and |𝑅2| + |𝐹| ≥ 𝑛 − 𝑓 .
In the worst case scenario, |𝐹| = 𝑓​ , i.e. the number of malicious nodes is at the maximum that the system could tolerate the aforementioned relation becomes |𝑅1| ≥ 𝑛 − 2𝑓​ and ​|𝑅2| ≥ 𝑛 − 2𝑓. Added together, |𝑅1| + |𝑅2| ≥ 2𝑛 − 4𝑓​, which could be simplified as ​𝑛 ≤ 3𝑓. Given that 𝑓 = ⌊ (𝑛−1) / 3 ⌋, which contradicts with the former, it can be proven that the system cannot be forked within the tolerance range. 

## Reference 

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012.  
    (FAN JIE, YI Le-tian, SHU Ji-Wu. Analyse van Byzantine System Technology [J]. Journal of Software, 2013, 6: 012)

