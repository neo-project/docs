# NEO Whitepaper

Una rete distribuita per la Smart Economy

## Progetti e Obiettivi di NEO: Smart Economy

NEO implementa la tecnologia blockchain e l'identità digitale per digitalizzare gli asset, gli "smart contract" (contratti intelligenti) sono utilizzati per rendere autonoma la gestione degli asset digitali, permettendo così di creare una Smart Economy tramite una rete decentralizzata.

### Asset Digitali

Gli asset digitali sono risorse programmabili esistenti sotto forma di dati digitali. Grazie alla tecnologia blockchain, la digitalizzazione degli asset può essere decentralizzata, affidabile, tracciabile, altamente trasparente e senza intermediari. Sulla blockchain di NEO gli utenti possono registrarsi, commerciare e scambiare diversi tipi di asset, dimostrando che la connessione tra asset digitali e asset fisici é possibile tramite l'implementazione dell'identità digitale. Gli asset registrati e convalidati tramite un’identità digitale sono, inoltre, protetti dalla legge.

NEO implementa due tipi di asset digitali: asset globali e asset contrattuali. Gli asset globali registrati nel sistema sono identificati da tutti gli smart contract e dai client. Gli asset contrattuali sono registrati nell' archivio privato dello smart contract in questione, quindi, é richiesto un client compatibile per riconoscerli. Gli asset contrattuali possono aderire a specifici standard rendendo possibile la compatibilità con la maggior parte dei client.


### Identità Digitale

Per identità digitale ci si riferisce alle informazioni sull'identità degli individui, organizzazioni e altre entità che esistono elettronicamente. Attualmente, Il sistema più maturo di identità digitale é basato sul PKI (Public Key Infrastructure - Infrastruttura a chiave pubblica) X.509 standard. In NEO implementeremo una serie di standard X.509 per l’ identità digitale compatibili fra loro; Questa serie di standard, unitamente a un modello di emissione X.509 certificato e compatibile, supporterà il modello di emissione di certificati Web Of Trust point-to-point. La modalità prevista di verificazione dell'identità quando vengono emesse o usate identità digitali, include: il riconoscimento facciale, le impronte digitali, la voce, gli SMS, e altri metodi di autenticazione multi-fattore. Allo stesso tempo, useremo la blockchain così sostituendo l'Online Certificate Status Protocol (OCSP) per gestire e registrare l' X.509 Certificate Revocation List (CRL).

### Smart Contract

Il crittografo Nick Szabo, nel 1994, fu il primo a proporre il concetto di smart contract (contratto programmato), solo 5 anni dopo la creazione del World Wide Web. Secondo la definizione di Szabo: quando una condizione pre-programmata viene innescata lo smart contract eseguirà i corrispondenti termini contrattuali. La tecnologia blockchain provvede un sistema decentralizzato, resistente alle manomissioni, altamente affidabile, all'interno del quale gli smart contract sono di primaria utilità. NEO implementa un sistema indipendente per gli smart contract chiamato: NeoContract.

Il sistema NeoContract rappresenta la più grande caratteristica dell'integrazione senza pari al preesistente ecosistema di sviluppo software. Gli sviluppatori non hanno più bisogno di imparare un nuovo linguaggio di programmazione, possono scegliere di utilizzare C#, Java e altri linguaggi mainstream nell'ambiente IDE a loro più familiare (Visual Studio, Eclipse, etc.) per lo sviluppo dei contratti, debugging e compilazione. La leggera macchina virtuale (VM - Virtual machine) di NEO, NeoVM, ha il vantaggio di avere un'elevato grado di sicurezza, alta concorrenza e alta scalabilità. NeoContract permetterà a milioni di sviluppatori di tutto il mondo di eseguire rapidamente lo sviluppo degli smart contract. NeoContract avrà un white paper separato per descrivere i dettagli implementativi.

### Applicazioni ed Ecosistema

L'ecosistema é il punto cardine della comunità open source. Per riuscire a raggiungere l'obiettivo di una rete economicamente intelligente, NEO si impegnerà sullo sviluppo del proprio ecosistema fornendo validi strumenti di sviluppo, migliorando lo sviluppo di documenti, organizzando attività educative e di addestramento e provvedendo supporto finanziario. Abbiamo in programma di supportare le seguenti applicazioni basate su NEO, ricompensando i miglioramenti al design e l'esperienza utente:

🔹 **Programma Per i Nodi Della Rete**

-	Un programma PC completo per i "full nodes" (nodi di rete completi)

-	Un programma PC per i "light nodes" (nodi della rete semplici) con una migliore esperienza utente

-	Client Web/ Android/iOS che non necessitano di essere sincronizzati con la blockchain

-	Un hardware wallet (portafoglio fisico)

🔹 **Blockchain Explorer**

🔹 **Kit di Sviluppo SDK**

-	Supporto per Java / Kotlin, .NET C # / VB, JavaScript / Typescript, Python, Go

🔹 **Compilatore Smart Contract e IDE Plugin**

-	C# / VB.Net / F#, Visual Studio

-	Java / Kotlin, Eclipse

-	C / C++ / GO

-	JavaScript / TypeScript

-	Python / Ruby

🔹 **Applicazioni Decentralizzate**

-	Fondo smart

-	IA legale assistita dagli smart contract

-	Social networking

-	Fornitore di liquiditá Token automatizzato

-	Exchange decentralizzato

-	Protocollo di comunicazione sicuro

-	Mercato per lo scambio di dati

-	Mercato per il commercio di proprietà intellettuale

-	Mercato delle predizioni

-	Mercato pubblicitario

-	Mercato dell'hashpower

-	Mercato per NeoGas


## Modello Di Management NEO

### Modello Economico

NEO ha due token nativi, NEO (simbolo abbreviato NEO) e NeoGas (simbolo abbreviato GAS).

NEO, con un totale di 100 milioni di token, assegna ai possessori il diritto di gestire la rete. Nei diritti di gestione é incluso il voto per il “bookkeeping" (contabilitá), il cambiamento dei parametri della rete di NEO e tanto altro. L'unità minima di misura di NEO é 1, questi token non possono essere suddivisi.

GAS é il token carburante usato per il controllo e la gestione degli asset interni della rete NEO, con un limite massimo di 100 milioni di token. Per utilizzare la rete é necessario pagare in GAS le operazioni e la conservazione dei token e dei contratti (smart contract), creando incentivi economici per i bookkeeper e prevenendo l'abuso di risorse. l'unità minima del token GAS é 0.00000001.

Nel blocco genesi (il primo blocco) della rete NEO sono stati generati 100 milioni di NEO, a differenza del GAS che invece verrà rilasciato programmaticamente. 100 milioni di GAS, corrispondenti ai 100 milioni NEO, saranno generati attraverso un algoritmo di decadimento in 22 anni all'incirca, inviati istantaneamente agli indirizzi che detengono NEO. Se NEO viene trasferito a un nuovo indirizzo, il conseguente GAS generato sarà accreditato sul nuovo indirizzo.

La rete NEO fisserà una soglia votando per esentare il GAS da una certa quantità di transazioni come trasferimenti e operazioni con smart contract per migliorare l'esperienza utente. Quando si verifica una gran quantità di transazioni spam, NeoID potrà essere utilizzato per dare priorità alle transazioni e agli smart contract con un’identità qualificata. Transazioni e smart contract senza identità digitali potranno ottenere priorità pagando in GAS.

### Meccanismo Di Distribuzione

Distribuzione di NEO:

I 100 milioni di token NEO sono divisi in due porzioni. La prima porzione di 50 milioni di token é distribuita proporzionalmente ai supporter di NEO durante il crowdfunding. Questa porzione é già stata distribuita.

La seconda porzione di 50 milioni di token é gestita dal NEO Council per promuovere lo sviluppo di NEO nel lungo termine, le operazioni, la manutenzione e l'ecosistema. Per quanto riguarda questa porzione NEO ha bloccato i fondi per il periodo di 1 anno, i quali verranno sbloccati solo dopo il 16 ottobre 2017. Questa porzione non entrerà sugli exchange e sarà utilizzata esclusivamente per il supporto finanziario dei progetti di lungo periodo. Segue il piano:

🔹 10 milioni di token (10% del totale) saranno usati per motivare e promuovere le attività degli sviluppatori e i membri del NEO Council.

🔹 10 milioni di token (10% del totale) saranno utilizzati per motivare gli sviluppatori dell'intero ecosistema NEO.

🔹 15 milioni di token (15% del totale) saranno usati per investimenti in altri progetti blockchain, di proprietà del NEO Council, e utilizzati solo per i progetti riguardanti NEO.

🔹 15 milioni (15% del totale) saranno ritenuti come contingenza.

🔹 In linea di principio l'uso annuale dei token NEO non dovrebbe eccedere i 15 milioni.

Distribuzione del GAS:

Nuovo GAS viene generato ogni volta che viene generato un nuovo blocco. La quantità iniziale di GAS é zero. Con l'aumentare del tasso di generazione di ogni nuovo blocco, il limite totale di 100 milioni di GAS potrà essere raggiunto in 22 anni. L'intervallo tra ogni nuovo blocco é all'incirca di 15-20 secondi, con 2 milioni di blocchi generati in quasi un anno.

Ogni anno vengono generati intorno ai 2 milioni di blocchi e la distribuzione iniziale sarà di 8 GAS per blocco. Avverrà una riduzione annuale graduale di 1 GAS per blocco, coincidente con i 2 milioni di blocchi generati. La riduzione continuerà fino a 1 GAS per blocco e sarà raggiunta in 22 anni all'incirca. Dopo il 44 milionesimo blocco il GAS totale generato raggiungerà 100 milioni e da questo punto si fermerà la generazione di GAS da nuovi blocchi.

Secondo questa curva di rilascio, il 16% del GAS verrà creato nel primo anno, il 52% del GAS verrà creato nei primi quattro anni e l'80% del GAS verrà creato nei primi 12 anni. Questo GAS sarà distribuito in maniera proporzionale secondo la quantità di NEO in possesso, registrato nei corrispondenti indirizzi wallet. I possessori di token NEO possono effettuare transazioni di reclamo per i GAS token in qualsiasi momento, questi saranno accreditati agli indirizzi in proprio possesso.

### Meccanismo Di Governo

Governo della chain: I possessori di token NEO sono i proprietari e manager della rete, gestendo la rete attraverso un meccanismo di voti e usando il GAS generato da NEO per utilizzare le funzioni della rete. I token NEO possono essere trasferiti.

Governo off-chain: Il Neo Council é costituito dai membri fondatori del progetto NEO, sotto il quale il comitato di gestione, il comitato tecnico e il segretariato, rispettivamente, sono responsabili del processo decisionale, delle strategie, delle decisioni tecniche e implementazioni specifiche. Il NEO Council é responsabile verso la comunità NEO per la promozione e lo sviluppo dell'ecosistema NEO come suo primario obiettivo.

## NEO Implementazioni Tecnologiche

### Meccanismo Di Consenso: dBFT

Il dBFT: Delegated Byzantine Fault Tolerant; Un meccanismo di consenso Byzantine tollerante ai guasti che abilita la partecipazione su larga scala attraverso il voto per delega (c.d proxy voting). I titolari dei token NEO possono, tramite voto, scegliere il bookkeeper supportato. Il gruppo di bookkeeper eletti, tramite l'algoritmo BFT, raggiunge il consenso generando in tal modo un nuovo blocco. Il voto, nella rete NEO, é un'operazione continua che avviene in tempo reale, a differenza di un accordo a termine prefissato.

Il dBFT provvede una tolleranza ai guasti di f = ⌊ (n-1) / 3 ⌋ per un sistema di consenso costituito da n nodi. Questa tolleranza ai guasti include entrambe sicurezza e disponibilità, resistente ai fallimenti generali e relativi al Byzantine, inoltre adatto a qualsiasi ambiente di rete. Il dBFT é "inamovibile", ciò significa che una volta che le conferme sono definitive, il blocco non può più essere biforcato, e le transazioni non possono essere revocate o reimpostate allo stato precedente.

Nel meccanismo di consenso NEO dBFT, prendendo circa dai 15 ai 20 secondi per generare un blocco, il flusso per ogni singola transazione viene conteggiato fino a 1,000 TPS, il quale rappresenta performance eccellenti tra le chain pubbliche. Attraverso appropriate ottimizzazioni, c'é il potenziale per raggiungere 10,000 TPS, permettendo l'adozione di implementazioni commerciali su larga scala.

Il dBFT combina la tecnologia di identità digitale, ciò significa che i bookkeeper possono essere un nome reale di un individuo o un'istituzione. In tal modo é possibile congelare, revocare, ereditare, recuperare e trasferire la proprietà tramite una decisione giudiziaria. Ciò facilita la registrazione di asset finanziari sulla rete NEO. La rete NEO ha pianificato di supportare queste operazioni quando necessario.

### Sistema Degli Smart Contract: NeoContract

Il sistema degli smart contract di NEO consiste in tre parti:

**NeoVM – Macchina Virtuale (VM) della Block Chain Universale::**

NeoVM é una macchina virtuale leggera (virtual machine), a scopo generale la cui architettura é molto simile a JVM e .NET Runtime, simile a una CPU virtuale che legge ed esegue in sequenza le istruzioni presenti nei contratti, esegue il controllo dei processi in base alle funzionalità delle operazioni, delle istruzioni, operazioni logiche e molto altro. Ha un'ottima velocità di avvio e versatilità, é specialmente adatta per piccoli programmi come gli smart contract, inoltre, può essere portata al di fuori della block-chain, oppure essere integrata con la IDE, fornendo in tal modo un'ottima esperienza di sviluppo. Le funzionalità di NeoVM sono estensibili, ad esempio tramite l'introduzione del meccanismo JIT (compilatore in tempo reale), potenziando in tal modo l'efficienza di implementazione.

**InteropService – Servizi Interoperabili:**

Usato per caricare il registro della blockchain, gli asset digitali, l'identità digitale, l’area di archiviazione persistente e altri servizi sottostanti. InteropService é pensato per le macchine virtuali (c.d. Virtual Machines), abilitando gli smart contract ad accedere a questi servizi in fase di esecuzione per raggiungere funzionalità più avanzate. Tramite questo design di basso attrito, **NeoVM può essere portato su qualsiasi sistema blockchain o non block-chain usato, aumentando l'utilità dei contratti.**

**DevPack - Compilatore e plugin IDE:**

DevPack include il compilatore per linguaggi di alto livello e il plugin IDE. Siccome l'architettura di NeoVM é molto simile a JVM e .NET Runtime, i compilatori nel DevPack sono capaci di compilare Java byte code e .NET MSIL nel set di istruzioni di NeoVM. Gli sviluppatori Java / Kotlin, C# non hanno bisogno di imparare nuovi linguaggi e saranno capaci di sviluppare smart contract in VS, Eclipse e altri ambienti IDE a loro familiari. **Tutto ciò riduce enormemente la curva di apprendimento degli smart contract, permettendoci di costruire una comunità intorno a NeoContract molto vivace.**

NeoContract può creare uno schema ad albero per un contratto intelligente attraverso un'analisi statica, ancor prima di eseguire lo stesso contratto. **Attraverso questo schema ad albero deterministico, un qualsiasi nodo di NEO può dinamicamente frammentare il contratto intelligente raggiungendo in tal modo un'espansione illimitata a livello teorico**, superando in tal modo il c.d. "effetto inceppamento” (jamming effect) causato dalla frammentazione statica di altri sistemi blockchain.

### Accordo Di Interoperabilità Cross-Chain: NeoX

NeoX é un protocollo che implementa l'interoperabilità cross-chain. NeoX é diviso in due parti: Il "protocollo per lo scambio di asset cross-chain" e il "protocollo per le transazioni cross-chain distribuite".

**Accordo di scambio per asset cross-chain:**

NeoX é già esteso ai protocolli di scambio Atomic Asset permettendo a più partecipanti di scambiare asset attraverso chain differenti e assicurando che tutti gli step dell'intero processo di transazione abbiano successo o falliscano insieme. Al fine di rendere possibile questa funzione, abbiamo bisogno di usare le funzioni di NeoContract per creare un account destinato ai contratti per ogni partecipante. Se le altre blockchain non sono compatibili con NeoContract, possono essere compatibili con NeoX fintanto che forniscano semplici funzionalità correlate agli smart contract.

**Protocollo per le transazioni cross-chain distribuite:**

Per transazioni cross chain distribuite s'intende che i diversi step di una transazione sono sparpagliati tra differenti blockchain e che la consistenza dell'intera transazione é assicurata. Questa é una estensione dello scambio di asset cross-chain, estendendo il comportamento dello scambio di asset in un comportamento arbitrario. In termini profani, NeoX rende possibile l'esecuzione cross chain degli smart contract dove un contratto intelligente può eseguire diverse componenti su chain differenti, avendo completo successo oppure essendo completamente ripristinato. Ciò offre un'eccellente possibilità di collaborazioni, inoltre nel frattempo stiamo esplorando gli scenari riguardanti applicazioni per gli smart contract cross-chain. 

### Protocollo Per L'archiviazione Distribuita: NeoFS

NeoFS é un protocollo di archiviazione distribuita che utilizza la tecnologia Hash Table. NeoFS indicizza i dati attraverso il contenuto del file (Hash) invece del percorso file (URI). File di grandi dimensioni verranno divisi in dati di dimensione prefissata, distribuiti e archiviati su tanti nodi diversi della rete.

Il problema principale con questo tipo di sistema consiste nella necessità di trovare un bilanciamento tra ridondanza e affidabilità. NeoFS intende risolvere questa contraddizione tramite l'incentivazione con token e l'istituzione di nodi rappresentanti la struttura della rete. Gli utenti possono scegliere i requisiti di affidabilità dei file. I file con bassi requisiti di affidabilità possono avere accesso gratis o quasi. Servizi stabili e affidabili per file con requisiti di elevata affidabilità saranno forniti dai nodi strutturali della rete.

NeoFS servirà come uno dei InteropService (servizi interoperabili) sotto il sistema di NeoContract, permettendo agli smart contract di memorizzare file di grandi dimensioni sulla blockchain e impostare i permessi di accesso a questi file. Inoltre, NeoFS può essere combinato con l'identità digitale così i certificati digitali usati possono essere assegnati, inviati e revocati senza l'uso di un server centrale che li gestisca. In futuro, i vecchi dati della blockchain potranno essere archiviati in NeoFS, così che la maggior parte dei nodi della rete possano rilasciare i vecchi dati per una migliore scalabilità e allo stesso tempo, assicurare l'integrità storica dei dati.

### Meccanismo di Crittografia Anti-Quantistica: NeoQS

L'emergere dei computers quantistici pone una maggiore sfida ai meccanismi di crittografia basati sull'RSA e ai meccanismi basati sull'ECC. I computer quantistici possono risolvere un numero elevatissimo di problemi decomposti (sui quali l'RSA fa perno) e il logaritmo discreto della curva ellittica (sul quale l’ECC fa perno) in un periodo di tempo brevissimo. NeoQS (Quantum Safe) é un meccanismo crittografico reticolare. Allo stato attuale dell'arte, i computer quantistici non sono capaci di risolvere velocemente lo Shortest Vector Problem (SVP) e il Closest Vector Problem (CVP), che è considerato essere l'algoritmo più affidabile e più resistente ai computer quantici.

## Sommario

NEO é una rete distribuita che combina asset digitali, identità digitali, e smart contract. Il sistema NEO userà DBFT, NeoX, NeoFS, NeoQS e altre tecnologie originali, come infrastruttura per l'economia intelligente del futuro.
