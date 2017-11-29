# NEO Whitepaper

Una rete distribuita per l'Economia Smart


## Progetti e Obiettivi di NEO: Economia Smart

NEO implementa la tecnologia blockchain e l'identitá digitale per digitalizzare gli assets, usa i c.d. "smart
contract" (contratti intelligenti) per rendere autonoma la gestione degli assets digitali, permettendo cosí
di creare una Economia Smart (economia intelligente) per tramite una rete decentralizzata.

### Assets Digitali

Gli assets digitali sono assets programmabili esistenti in forma di dati elettronici. Grazie alla tecnologia
blockchain, la digitalizzazione degli assets puó essere decentralizzata, affidabile, tracciabile, altamente
trasparente e libera da intermediari. Sulla blockchain di NEO gli utenti possono registrarsi, commerciare
e far girare diversi tipi di assets, dimostrando che la connessione tra assets digitali e assets fisici é
possibile tramite l'implementazione dell'identitá digitale. Gli assets registrati tramite una identitá
digitale convalidata sono protetti dalla legge.

NEO implementa due tipi di assets digitali: assets globali e assets contrattuali. Gli assets globali registrati
nel sistema sono identificati da tutti gli smart contracts e clients. Gli asset contrattuali sono registrati
nell' archivio privato dello stesso smart contract in questione, quindi, é richiesto un client compatibile
per riconoscerli. Gli assets contrattuali possono aderire a specifici standards rendendo possibile la
compatibilitá con la maggior parte dei clients.

### Identitá Digitale

Per identitá digitale ci si riferisce alle informazioni sull'identitá degli individui, orgaizzazioni e altre entitá
che esistono elettronicamente. Attualmente, Il sistema piú maturo di identitá digitale é basato sul PKI (
Public Key Infrastructure) X.509 standard. In NEO implementeremo un set di X.509 Digital Identity
Standards compatibili fra loro; Questo set, unitamente al modello di emissione X.509 certificato, sará
compatibile con il modello di emissione Web Of Trust point-to-point certificate.
la modalitá prevista di verificazione dell'identitá, quando vengono emesse o usate identitá digitali,
inculde: il riconoscimento facciale,le impronte digitali,la voce,gli SMS, e altri metodi di autenticazione
multifattore. Allo stesso tempo, useremo la blockchain sostituendo L'Online Certificate Status Protocol
(OCSP) per gestire e registrare l' X.509 Certificate Revocation List (CRL).

### Smart Contract

(contratto intelligente)
Il crittografo Nick Szabo, nel 1994, fu il primo a proporre il concetto di smart contract, solamente 5 anni
piú tardi alla crezione del World Wide Web. Secondo la definizione di Szabo: quando una condizione
pre-programmata viene innescata lo smart contract eseguirá i corrispondenti termini contrattuali. La
tecnologia blockchain provvede un sistema decentralizzato, resistente alle manomissioni, altamente
affidabile, all'interno del quale gli smart contracts sono di primaria utilitá. NEO implementa un sistema
indipendente per gli smart contracts chiamato: NeoContract.

Il sistema NeoContract rappresenta la piú grande caratteristica dell'integrazione senza pari al presistente ecosistema di sviluppo. Gli sviluppatori non hanno bisogno di imparare un nuovo linguaggio di
programmazione, scegliendo di utilizzare C#, Java e altri linguaggi mainstream nell'ambiente IDE a loro
piú familiare (Visual Studio, Eclipse, etc.) per lo sviluppo degli smart contracts, debugging e
compilazione. La leggera virtual machine di NEO, NeoVM, ha il vantaggio di avere un'elevato grado di
sicurezza, alta "concurrency" e alta scalabilitá. NeoContract permetterá a milioni di sviluppatori di tutto
il mondo di eseguire rapidamente lo sviluppo degli smart contracts. NeoContract avrá un white paper
separato per descrivere i dettagli implementativi.

### Applicazioni ed Ecosistema

L'ecosistema é il punto cardine della comunitá open source. Per riuscir a raggiungere l'obiettivo di
una rete economica intelligente, NEO si impegnerá allo sviluppo di detto ecosistema, fornendo validi
strumenti di sviluppo, migliorando lo sviluppo di documenti, organizzando attivitá educative e di
addestramento e provvedendo supporto finanziario. Abbiamo in programma di supportare le seguenti
applicazioni basate su NEO, ricompensando i miglioramenti al design e l'esperienza utente:

🔹 **Programma Per i Nodi Della Rete**

-	un programma PC completo per i "full nodes".

-	un programma PC piú leggero per i nodi della rete con una migliore esperienza utente.

-	clients web/ Android/iOS che non necessitano di essere sincronizzati con la blockchain.

-	un hardware wallet (portafoglio fisico)

🔹 **Blockchain Explorer**

🔹 **Kit di Sviluppo SDK**

-	supporto Java / Kotlin, .NET C # / VB, JavaScript / Typescript, Python, Go

🔹 **Compilatore Smart Contract e IDE Plugin**

-	C# / VB.Net / F#, Visual Studio

-	Java / Kotlin, Eclipse

-	C / C++ / GO

-	JavaScript / TypeScript

-	Python / Ruby

🔹 **Applicazioni Decentralizzate**

-	fondo smart (fondo intelligente)

-	AI legale assistita da smart contract

-	Social networking

-	token fornitore automatico di liquiditá

-	exchange decentralizzato

-	protocollo di comunicazione sicuro

-	mercato per lo scambio di dati

-	mercato per il commercio di proprietá intellettuale

-	mercato delle predizioni

-	mercato pubblicitario

-	mercato dell' hashpower

-	mercato per NeoGas


## NEO Modello Di Management

### Modello Economico

NEO, con un totale di 100 milioni di tokens, assegna ai possessori il diritto di gestire la rete. Nei diritti
di gestione é incluso il voto per il c.d. "bookkeeping", il cambiamento nei paramentri della rete di NEO e
tanto altro. L'unitá minima di misura di NEO é 1, i token non possono essere suddivisi.

Gas é il token carburante usato per il controllo e la gestione delle risorse interne della rete NEO, con un
limite massimo di 100 milioni di tokens. Per utilizzare la rete é necessario pagare in GAS le operazioni e
la conservazione dei tokens e degli smart contracts, in tal modo vengono creati gli incentivi economici
per i bookkeepers insieme alla prevenzione di abusi delle risorse della rete. l'unitá minima del token GAS
é 0.00000001.

Nel blocco genesi (il primo blocco) della rete NEO sono stati generati 100 milioni di NEO, a differenza del
GAS che invece verrá rilasciato programmaticamente. 100 milioni di GAS, corrispondenti ai 100 milioni
NEO, saranno generati attraverso un algoritmo di decadimento in 22 anni all'incirca, inviato
istantaneamente agli indirizzi che detengono NEO. Se NEO viene trasferito a un nuovo indirizzo, il
conseguente GAS generato sará accreditato al nuovo indirizzo.

La rete NEO fisserá una soglia, votando, per esentare il GAS da una certa quantitá di transazioni, come
trasferimenti e operazioni con smart contract per potenziare l'esperienza utente.
Qaundo si verificano grosse quantitá di transazioni "spam" NeoID potrá essere utilizzato per dare
prioritá alle transazioni e smart contracts con identitá qualificata. Transazioni e smart contracts senza
alcuna identitá digitale potranno ottenere la prioritá soltanto pagando GAS.

### Meccanismo Di Distribuzione

Distribuzione di NEO:

I 100 milioni di token NEO sono divisi in due porzioni. La prima porzione é di 50 milioni di tokens
distribuiti proporzionalmente ai supporters di NEO durante il crowdfunding. Questa porzione é giá stata
distribuita.

La seconda porzione di 50 milioni di tokens é gestita dal NEO Council per promuovere lo sviluppo di NEO
nel lungo termine, le operazioni, la manutenzione e l'ecosistema. Per qaunto riguarda questa porzione
NEO ha bloccato i fondi per il periodo di 1 anno, i quali verranno sbloccati solo dopo il 16 ottobre 2017.
Questa porzione non entrerá sugli exchanges e sará utilizzata esclusivamente per il supporto finanziario
dei progetti di lungo periodo. Segue il piano:

🔹 10 milioni di tokens (10% del totale) saranno usati per motivare e promuovere le attivitá degli
sviluppatori e i membri del NEO council.

🔹 10 milioni di tokens (10% del totale) saranno utilizzati per motivare gli sviluppatori dell'intero
ecosistema NEO.

🔹 15 milioni di tokens (15% del totale) saranno usati per investimenti in altri progetti blockchain, di
proprietá del NEO Council, e utilizzati solo per i progetti riguardanti NEO.

🔹 15 milioni (15% del totale) saranno ritenuti come contingenza

🔹 In linea di principio l'uso annuale dei tokens NEO non dovrebbe eccedere i 15 milioni.

Distribuzione del GAS:

Nuovo GAS viene generato ongi volta che un nuovo blocco viene scoperto. La quantitá iniziale di GAS é
zero. Con l'aumentare del tasso di crescita di ogni nuovo blocco, il limite totale di 100 milioni GAS sará
raggiunto in 22 anni. L'intervallo tra ogni nuovo blocco é all'incirca di 15-20 secondi, con 2 milioni di
blocchi generati in quasi un anno.

Ogni anno vengono generati intorno ai 2 milioni di blocchi e la distribuzione iniziale sará di 8 GAS per
blocco. Avverrá una riduzione annuale graduale di 1 GAS per blocco, coincidente con i 2 milioni di
blocchi generati. La riduzione continuerá fino a 1 GAS per blocco e sará raggiunta in 22 anni all'incirca.
Dopo il 44 milionesimo blocco il GAS totale generato raggiungerá 100 milioni e da questo punto si
fermerá la generazione di GAS da nuovi blocchi.

Secondo questa curva di rilascio, il 16% del GAS verrá creato nel primo anno, il 52% del GAS verrá creato
nei primi quattro anni e l'80% del GAS verrá creato nei primi 12 anni. Questo GAS sará distribuito in
maniera proporzionale secondo la quantitá di NEO in possesso, registrato nei corrispondenti indirizzi
wallet. I possessori di tokens NEO posso cominciare a fare transazioni in qualsiasi momento e richiedere
GAS tokens agli indirizzi in proprio possesso.

### Meccanismo Di Governo

Governo della chain: I possessori di tokens NEO sono loro stessi proprietari e managers della rete,
gestendo la rete attraverso un meccanismo di voti e usando il GAS generato da NEO per utilizzare le
funzioni della rete. I token NEO possono essere trasferiti.

Governo off-chain: Il Neo council é costituito dai membri fondatori del progetto NEO, sotto il quale il
comitato di gestione, il comitato tecnico e il segretariato, rispettivamente, sono responsabili del
processo decisionale, delle strategie, delle decisioni tecniche e implementazioni specifiche. Il NEO
Council é responsabile verso la comunitá NEO per la promozione e lo sviluppo dell'ecosistema NEO
come suo primario obiettivo.

## NEO Implementazioni Tecnologiche

### Meccanismo Di Consenso: dBFT

Il dBFT: Delegated Byzantine Fault Tolerant; Un meccanismo Byzantine fault-tolerant di consenso che
abilita la partecipazione su larga scala attraverso il voto per delega (c.d proxy voting). I titolari dei tokens
NEO possono, tramite voto, scegliere il bookkeeper supportato. Il gruppo di bookkeepers eletto, tramite
l'algoritmo BFT, raggiunge il consenso generando in tal modo un nuovo blocco. Il votare, nella rete
NEO, é un'operazione continua che avviene in tempo reale, a differenza di un accordo a termine
prefissato.

il dBFT provvede una tolleranza d'errore di f = ⌊ (n-1) / 3 ⌋ per un sistema costituito da n nodi. Questa
tolleranza d'errore include entrambe sicurezza e disponibilitá, resistente alle falle generali e del
Byzantine consensus, inoltre adatto a qualsiasi ambiente di rete. Il dBFT é "inamovibile", ció significa che
una volta che le conferme sono definitive, il blocco non puó essere piú biforcato, e le transazioni non
possono essere revocate o reimpostate allo stato precedente.

Nel meccanismo di consenso NEO dBFT, prendendo circa dai 15 ai 20 secondi per generare un blocco, il
flusso per ongi singola transazione viene conteggiato fino a 1,000 TPS, il quale rappresenta performance
eccellente tra le chain pubbliche. attraverso appropriate ottimizzazioni, c'é il potenziale per raggiungere
10,000 TPS, permettendo l'adozione di implementazioni commerciali su larga scala.

il dBFT utilizza la tecnologia dell'identitá digitale, ció significa che i bookkeepers possono essere un
nome reale di un individio o un'istituzione. In tal modo é possibile congelare, revocare, ereditare,
recuperare e trasferire la proprietá tramite una decisione giudiziaria.
Ció facilita la registrazione di assets finanziari nella rete NEO. La rete NEO ha pianificato di supportare
queste operazioni quando necessario.

### Sistema Degli Smart Contract: NeoContract

Il sistema degli smart contracts di NEO consiste in tre parti:

**NeoVM – Block Chain Universale Virtul Machine:**

NeoVM é una leggera, multi-scopo virtual machine (macchina virtuale) la cui architettura é molto simile
a JVM e .NET Runtime, similarmente a una CPU virtuale che legge ed esegue in sequenza le istruioni
presenti nei contratti, esegue il controllo dei processi in base alle funzionalitá delle operazioni,delle
istruzioni, operazioni logiche e molto altro. Ha un'ottima velocitá di avvio e versatilitá, é specialmente
adatta per piccoli programmi come gli smart contracts, inoltre, puó essere portata al di fuori della
block-chain, oppure essere integrata con la IDE, provvedendo in tal modo un'ottima esprienza di
sviluppo. Le funzionalitá di NeoVM sono estensibili, ad esempio tramite l'introduzione del meccanismo
JIT ( real-time compiler), in tal modo potenziando l'efficienza implementativa.

**InteropService – Servizi Interoperabili:**

Usato per caricare il registro della blockchain, gli assets digitali, L'identitá digitale, area di archiviazione
persistente e altri servizi sottostanti. InteropService é pensato per le macchine virtuali (c.d. Virtual
Machines), abilitando gli smart contract ad accedere a questi servizi in fase di esecuzione per raggiungere funzionalitá avanzate. Tramite questo design di basso attrito, NeoVM puó esserte
supportata da qualsiasi sistema blockchain o non block-chain, aumentando l'utilitá degli smart
contracts.

**DevPack - Compilatore e IDE plugin:**

DevPack include il compilatore per linguaggi di alto livello e L'IDE plugin. Siccome l'architettura di
NeoVM é molto simile a JVM e .NET Runtime, i compilatori nel DevPack sono capaci di compilare Java
byte code e .NET MSIL nel set di istruzioni di NeoVM. Gli sviluppatori Java / Kotlin, C # non hanno
bisongo di imparare nuovi linguaggi, saranno capaci di sviluppare smart contracts in VS, Eclipse e altri
ambienti IDE a loro familiari. Tutto ció riduce enormemente la curva di apprendimento per gli
smart contracts, permettendoci di costruire facilmente una vivace comunitá intorno a
NeoContract.

NeoContract puó creare uno schema ad albero per uno smart contract attraverso un'analisi statica,
ancor prima di eseguire lo stesso smart contract. Attraverso questo schema ad albero
deterministico, un qualsiasi nodo di NEO puó dinamicamente frammentare lo smart contract
raggiungendo in tal modo un'espansione illimitata a livello teorico, superando in tal modo il c.d.
"effetto inceppamento" causato dalla frammentazione statica di altri sistemi basati sulla blockchain.

### Accordo Di Interoperabilitá Cross-Chain: NeoX

NeoX é un protocollo che implementa l'interoperabilitá cross-chain. NeoX é diviso in due parti: Il
"protocollo per lo scambio di assets cross-chain" e il "protocollo per le transazioni cross-chain
distribuite".

**Accordo di scambio cross-chain assets:**

NeoX é esteso ai giá esistenti protocolli Atomic Assets exchanges permettendo a piú partecipanti di
scambiare assets attraverso chain differenti e assicurando che tutti gli step dell'intero processo di
transazione abbiano successo o falliscano insieme. Al fine di rendere possibile questa funzione, abbiamo
bisogno di usare le funzioni di NeoContract creando un c.d contract account per ogni partecipante alla
transazione. Se le altre blockchain non sono compatibili con NeoContract, possono essere compatibili
con NeoX fintanto che forniscano funzionalitá correlate agli smart contracts.

*Protocollo per le transazioni cross-chain distribuite:**

Per Transazioni cross chain distribuite s'intende che i diffenti steps di una transazione sono sparpagliati
tra differenti blockchain e che la consistenza dell'intera transazione é assicurata. Questa é una
estensione della cross chain assets exchange, estendendo il comportamento degli assets in un
comportamento arbitrario. In termini profani, NeoX rende possibile l'esecuzione cross chain degli smart
contracts dove uno smart contract puó essere performato su differenti chains, avendo completo
successo oppure essere completamente ripristinato. Ció offre un'eccellente possibilitá di collaborazioni
e noi stiamo esploranod lo scenario delle applicazioni per gli smart contracts cross chain.

### Protocollo Per L'archiviazione Distribuita : NeoFS

NeoFS é un protocollo di archiviazione distribuita che utilizza la tecnologia Hash Table. NeoFS indicizza i
dati attraverso il contenuto del file (Hash) invece del percorso file (URI). File di grandi dimensioni verranno divisi in dati di dimensione prefissata, distribuiti e archiviati su tanti nodi differenti della rete.

Il problema principale con questo tipo di sistema consiste nella necessitá di trovare un bilanciamento
tra ridondanza e affidabilitá. NeoFS intende risolvere questa contraddizione tramite l'incentivazione con
tokens e l'istituzione di nodi rappresentanti la dorsale (backbone) della rete. Gli utenti possono scegliere
i requisiti di affidabilitá dei files. I files con bassi requisiti di affidabilitá possono avere accesso gratis o
quasi. Servizi stabili e affidabili per file con requisiti di elevata affidabilitá saranno forniti dai nodi dorsali
della rete.

NeoFS servirá come un dei InteropService servizi interoperabili sotto il sistema di NeoContract,
permettendo agli smart contract di memorizzare files di grandi dimensioni sulla blockchain e
impostare i permessi di accesso a questi files. Inoltre, NeoFS puó essere combinato con l'identitá
digitale cosí i certificati digitali usati possono essere assegnati, inviati e revocati senza l'uso di un server
centrale che li gestisca. In futuro, i vecchi dati della blockchain potranno essere archiviati in NeoFS, cosí
che la maggior parte dei nodi della rete possano rilasciare i vecchi dati per una migliore scalabilitá e allo
stesso tempo, assicurare l'integritá storica dei dati.

### Anti Crittografia Quantistica: NeoQS

L'emergere dei computers quantitstici pone una maggiore sfida ei meccanismi di crittografia RSA e ECC. I
computer quantistici possono risolvere un numero elevatissimo di problemi decomposti (sui quali l'RSA
fa perno) e il logaritmo discreto della curva ellittica (ECC) in un periodo di tempo brevissimo. NeoQS (
Quantum Safe) é un meccanismo crittografico reticolare. Allo stato attuale dell'arte, i computer
quantistici non sono capaci di risolvere velocemente lo Shortest Vector Problem (SVP) e il Closest Vector
Problem (CVP), che é considerato essere l'algoritmo piú affidabile e resistente ai computer quantici

## Sommario

NEO é una rete distribuita che combina assets digitali, identitá digitali, e smart contracts. Il sistema NEO
userá DBFT, NeoX, NeoFS, NeoQS e altre tecnologie origianali, come infrastruttura per l'economia
intelligente del futuro.
