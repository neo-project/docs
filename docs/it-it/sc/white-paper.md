# NeoContract White Paper

## 1. Introduzione

Gli smart contracts (contratti intelligenti) si riferiscono a protocolli per computer che possono eseguire automaticamente dei termini presenti in contratti pre-programmati. Il crittografo Nick Szabo, nel 1994, fu il primo a proporre il concetto di smart contract. A causa di una mancanza di un ambiente di sviluppo adatto, gli smart contract non furono mai utilizzati in larga scala. 

Nel 2008, un uomo sotto il nome di Satoshi Nakamoto rilasciò Bitcoin così delineando il concetto fondamentale della blockchain. 
Nella blockchain di Bitcoin, Nakamoto utilizza un set di linguaggi di scripting in modo da assistere gli utenti nell’acquisire una maggiore flessibilità per controllare i propri conti e le proprie transazioni, questo eventualmente viene considerato come una forma embrionale di un sistema di smart contracts basati su una chain. 

Nel 2014, un ragazzo chiamato Vitalik Buterin rilasciò Ethereum, Ethereum è una blockchain dotata di un sistema di smart contract, Turing completo che può essere usato per creare una grande varietà di applicazioni decentralizzate basate sulla blockchain. 

La blockchain di NEO è un asset digitale e una piattaforma per applicazioni, che fornisce un nuovo sistema di smart contract, NeoContract. Alla base della piattaforma di NEO, vi è un network che fornisce multiple funzionalità come capacità di gestire digital assets, NeoAsset, e identità digitali (c.d. digital identity), NeoID, il tutto consente gli utenti a involgersi con estrema facilità in un sistema di business digitalizzato e di non essere più limitati dalla sola emissione di tokens nativi della blockchain. 

Questo articolo introdurrà caratteristiche di NeoContract e esplorerà dettagli non tecnici. Siete pregati di riferirvi alla documentazione tecnica per trovare dettagli tecnici: [docs.neo.org](http://docs.neo.org).

## 2. Funzionalità

### 2.1 Certezza

Se un programma è in esecuzione su diversi computers, o in tempi diversi sullo stesso computer, il comportamento del programma è deterministico se vi è input che garantisce la produzione delle stesso output e vice versa. 

La blockchain è un’archiviazione multipartitatica, e un metodo computazionale, dove i dati all’interno di questo sistema distribuito sono risultati provenienti da calcoli affidabili che non possono essere manomessi. Gli smart contracts operano all’interno di un network basato su una blockchain distribuita su più nodi. Se uno smart contract non è deterministico, il risultato di alcuni nodi potrebbe essere incoerente. Di conseguenza, il consenso tra diversi nodi non potrà essere raggiunto e il network diverrà stagnante. Dunque, nella progettazione di un sistema di smart contract, vi è il bisogno di escludere qualunque fattore che potrebbe indurre a azioni non deterministiche.

#### 2.1.1 Tempi

Ottenere orari di sistema (c.d. system-time) è una funzione molto comune che potrebbe essere spesso applicata in certe procedure di contratti con tempistiche urgenti. Tuttavia, ottenere orari di sistema è una funzione non deterministica, ed è complicato ottenere un tempo preciso e unificato in un sistema distribuito dal momento che i risultati di diversi nodi saranno inconsistenti. NeoContract fornisce una chiamata di sistema basata su blocchi che opera nell’intera blockchain, facendo da server timestamp (marca temporale), e che ottiene il timestamp ogni qualvolta un blocco viene generato. In genere, il network di NEO genera un blocco ogni 15 secondi, dunque il contratto è eseguito ad un tempo approssimativamente uguale a quello dell’ultimo blocco, più o meno 15 secondi. 

#### 2.1.2 Casualità

Molti programmi basati su smart contract, come contratti su scommesse e mini giochi, usano funzionalità numeriche casuali.  Tuttavia, funzioni numeriche casuali sono tipiche di funzioni non deterministiche, in questo modo ogni chiamata di sistema otterrà risultati differenti. In un sistema distribuito, vi sono molti modi per risolvere questo problema: prima di tutto, lo stesso seed casuale può essere usato per tutti i nodi, così che la sequenza di ritorno dell’intera funzione casuale sia deterministica, tuttavia questo metodo rivela l’intero risultato casuale in anticipo, riducendo notevolmente il valore pratico del numero casuale generato. Un’altra possibile soluzione, è di lasciare tutti i nodi comunicare tra di loro in una maniera collaborativa in modo da generare numeri casuali. Questo può essere ottenuto usando tecniche di crittografia per produrre un buon numero casuale, lo svantaggio è da trovarsi nelle prestazioni molto scarse e nella necessità di ulteriori tempi di comunicazione. Un fornitore di numeri casuali centralizzato può essere usato per generare numeri garantendo sia le prestazioni che la consistenza ma l’inconveniente di questo approccio è ovvio; Gli utenti dovranno fidarsi incondizionatamente del fornitore di numeri casuali centralizzato. 

Ci sono due modi per generare numeri casuali su NEO:

1. Quando un blocco è generato, il nodo di consenso giungerà ad un accordo per un numero casuale e lo riempirà sul campo dedicato al Nonce del nuovo blocco. Il programma del contratto può facilmente ottenere il numero casuale di ogni blocco facendo riferimento al campo Nonce. 

2. Il programma del contratto può usare l’hash del blocco come un generatore di numeri casuali, poiché il valore contenuto nell’hash del blocco ha una certa causalità intrinseca. Il metodo può essere utilizzato per ottenere un numero casuale debole. 

#### 2.1.3 Fonte dei dati 

Se un programma ottiene dati durante il tempo di esecuzione (c.d. run-time), potrebbe diventare un programma non deterministico se la fonte dei dati fornisce dati non deterministici. Per esempio, usando diversi motori di ricerca per ottenere i top 10 risultati per una particolare parola chiave, può fornire risultati e ordini diversi se sono stati usati indirizzi IP differenti. 

Per gli smart contracts, NEO fornisce due tipi di fonti di dati deterministici: 

1. **Blockchain Ledger (mastro)**

   La procedura del contratto può accedere a tutti i dati sull’intera chain tramite servizi interoperabili, questi includono blocchi e transazioni, e ciascuno dei loro campi. I dati nei blocchi sono deterministici e consistenti, così che possano essere accessibili con sicurezza da parte degli smart contracts. 

2. **Spazio di archiviazione del contratto**

   Ogni contratto dispiegato nel network di NEO, ha un’area di archiviazione (c.d storage) privata che è accessibile solo dallo smart contract stesso. Il meccanismo di consenso di NEO garantisce una consistenza dello stato di archiviazione, di ogni nodo nel network.

Per situazioni in cui è necessario l’accesso a dati non appartenenti alla blockchain, NEO non offre un modo diretto per interagire con questi dati.  Dati non appartenenti alla blockchain dovranno essere trasferiti nella blockchain di NEO usando transazioni, e successivamente trasformate nelle fonti di dati summenzionate, in modo da rendere i dati accessibili agli smart contracts. 

#### 2.1.4 Invocazione del contratto (c.d. contract call)

Gli smart contracts di NeoContract possono invocarsi a vicenda, ma non possono essere invocati ricorsivamente. La ricorsione può essere raggiunta all’interno del contratto, ma non può superare i confini del contratto stesso. Inoltre, l’invocazione tra contratti deve essere statico: la destinazione non può essere specificata in fase di esecuzione. Questo consente che il funzionamento del programma sia interamente determinato prima dell’esecuzione, e che l’invocazione sia completamente definito prima che possa essere eseguito. Basato su ciò, contratti multipli possono essere partizionati dinamicamente in modo da conseguire un’esecuzione parallela. 

### 2.2 Alte prestazioni 

L’ambiente di esecuzione di uno smart contract svolge un ruolo fondamentale per le sue prestazioni. Quando analizziamo le prestazioni di qualunque ambiente di esecuzione, vi sono due indicatori critici: 

1. Velocità di esecuzione dell’istruzione
2. Velocità di avvio dell’ambiente di esecuzione stesso

Per gli smart contracts, l’ambiente di esecuzione è spesso più importante della velocità di esecuzione delle istruzioni. Gli smart contracts sono più coinvolti in operazioni di Input/Output per determinare le istruzioni, dove l'implementazione di queste istruzioni può essere facilmente ottimizzato. Ogni qualvolta che lo smart contract è invocato, deve avviare una nuova macchina virtuale (VM) / container. Perciò, la velocità di esecuzione dell’ambiente stesso (avviare una macchina virtuale / container) ha un maggior impatto sulle prestazioni del sistema degli smart contracts. 

NEO utilizza il leggero NeoVM (Macchina Virtuale NEO) come ambiente di esecuzione degli smart contracts, il quale ha un tempo di avvio molto veloce e occupa pochissime risorse, questo è perfetto per programmi brevi come gli smart contracts. Usando la compilazione e la memorizzazione cache di hotspot smart contract con JIT (real-time compiler) può migliorare in modo significativo l'efficienza delle macchine virtuali. 

### 2.3 Scalabilità 

#### 2.3.1 Concorrenza elevata e partizionamento dinamico

Quando si dibatte sulla scalabilità di un sistema, vi sono due aree principali coinvolte: scalabilità verticale e scalabilità orizzontale. La scalabilità verticale si riferisce a un’ottimizzazione del flusso di lavoro di elaborazione, consentendo al sistema di sfruttare a pieno le capacità dell’attrezzatura esistente. Con questo approccio, i limiti del sistema sono facilmente raggiungibili visto che la capacità di elaborazione basata in serie si fonda sul limite hardware di un singolo dispositivo. Quando abbiamo bisogno di scalare il sistema vi è un modo per trasformare il sistema di serie in un sistema parallelo? Teoricamente, abbiamo solo bisogno di aumentare il numero di dispositivi e saremmo in grado di raggiungere una scalabilità quasi illimitata. Potremmo mai raggiungere una scalabilità illimitata in reti di blockchain distribuite? In altre parole, la blockchain può eseguire programmi in parallelo? 

La blockchain è un mastro distribuito, che registra una varietà di dati di stato e le regole che dirigono i cambiamenti di stato di questi dati. Gli smart contracts sono utilizzati come corrieri per registrare queste regole. Le blockchains possono elaborare programmi in parallelo, solo se, più smart contracts possono essere eseguiti contemporaneamente e in modo non sequenziale. In pratica, se i contratti non interagiscono l’uno con l’altro, o se il contratto non modifica lo stesso dato di stato, allo stesso tempo, la loro esecuzione è non sequenziale e può essere eseguita simultaneamente. Altrimenti, può solo essere eseguito in serie, seguendo un ordine sequenziale, e la rete non sarà in grado di scalare orizzontalmente. 

Basandoci sull’analisi soprastante, possiamo facilmente ideare una “scalabilità illimitata” nei sistemi di smart contracts. Tutto ciò che dobbiamo fare è impostare delle regole semplici: 

 * **Uno smart contract può modificare solo il record dello stato del contratto a cui appartiene**

 * **Nello stesso blocco di transazioni (batch), un contratto può essere eseguito solo una volta**

Di conseguenza, tutti gli smart contracts possono essere processati in parallelo visto che l’ordine sequenziale è irrilevante per il risultato. Tuttavia, se uno “smart contract può solo modificare il record dello stato del contratto a cui appartiene”, implicherebbe che i contratti non possano invocarsi l’un l’altro. Ogni contratto, è un’isola desolata; Se “nello stesso blocco di transazioni (batch), un contratto può essere eseguito solo una volta”, questo implica che un asset digitale emesso con uno smart contract può solo gestire una transazione per blocco. Questa è una differenza enorme con gli obbiettivi originali degli “smart” contracts, che cessano di essere intelligenti (c.d. smart). Dopo tutto, i nostri obbiettivi designati includono sia l’invoco reciproco tra contratti, che la multipla esecuzione dello stesso invoco nel medesimo blocco. 

Fortunatamente, gli smart contracts in NEO hanno una relazione di invocazione statica, e la destinazione dell’invoco non può essere specificato in fase di esecuzione. Questo consente che il funzionamento del programma sia completamente determinato prima dell’esecuzione, e che la relazione di invoco sia completamente definita prima che possa essere eseguita. Richiediamo che ogni contratto indichi esplicitamente i contratti che potrebbero essere invocati, così che l’ambiente operativo possa calcolare l’albero di chiamate completo prima che esegua la procedura del contratto, così da partizionare l’esecuzione dei contratti basandosi sull’albero delle chiamate. I contratti che potrebbero modificare lo stesso record di stato, sono eseguiti in modo sequenziale nella stessa partizione, con ciò possono essere eseguite diverse partizioni in parallelo.

#### 2.3.2 Low coupling (Basso accoppiamento)

Coupling (o accoppiamento) è una misura della dipendenza tra due o più entità. Il sistema di NeoContract usa un design a basso accoppiamento, che è eseguito nella NeoVM, e che comunica con dati non appartenenti alla blockchain attraverso il layer del servizio interoperabile. Di conseguenza, la maggior parte degli aggiornamenti alle funzioni dello smart contract possono essere raggiunti aumentando l’API dei servizi interoperabili. 

## 3. Uso del contratto 

### 3.1 Verifica del Contratto 

A differenza di Bitcoin che utilizza un sistema di account a chiave pubblica, NEO si basa su un sistema di account contrattuale. Ogni account di NEO corrisponde a un contratto di verifica, e il valore hash del contratto di verifica è l’indirizzo dell’account; La logica del programma di verifica del contratto controlla la proprietà dell’account. Quando si trasferisce da un account, in primo luogo è necessario eseguire la verifica del contratto per tale account. Un contratto di validazione può accettare una serie di parametri (di solito una firma digitale o altri criteri), e restituire un valore booleano dopo la verifica, segnalando il successo della verifica al sistema. 

L’utente può distribuire la verifica del contratto alla blockchain in anticipo, o pubblicare il contenuto del contratto direttamente nella transazione durante il processo di trasferimento. 

### 3.2 Applicazione del Contratto 

Il contratto di applicazione è attivato da una transazione speciale, che può accedere e modificare lo stato globale del sistema e lo stato privato del contratto (area di archiviazione) in fase di esecuzione. Per esempio, potreste creare un asset digitale globale in un contratto, votare, salvare i dati, nonché effettuare una creazione dinamica di un nuovo contratto, quando il contratto è in esecuzione. 

L’esecuzione del contratto di applicazione richiede un addebito in base alle istruzioni. Quando la tassa sulla transazione è consumata, il contratto fallirà e interromperà l’esecuzione, inoltre tutti i cambi di stato verranno ripristinati. Il successo del contratto non influisce sulla validità della transazione. 

### 3.3 Funzione del Contratto 

Il contratto di funzione è usato per fornire funzioni pubbliche o comunemente usate che possono essere invocate da altri contratti. Il codice dello smart contract può essere riutilizzato, così che gli sviluppatori siano in grado di scrivere logiche funzionali sempre più complesse. 

Ogni contratto di funzione, quando distribuito, ha la possibilità di scegliere un’area di archiviazione privata che può essere letta o scritta su dati di un contratto futuro, ottenendo uno stato di persistenza. Il contratto di funzione deve essere pre-distribuito nella chain per essere invocato e rimosso dalla chain da una funzione di sistema “auto-distruttiva” che non sarà più usata, inoltre l’archiviazione privata sarà distrutta. I dati del contratto più datati possono essere migrati automaticamente verso un altro subcontratto prima che sia distrutto, usando strumenti di migrazione del contratto. 

## 4. Macchina Virtuale 

### 4.1 Hardware Virtuale

NeoVM offre un livello (c.d. layer) di hardware virtuale che supporta l’esecuzione di smart contracts, questo include:

 * **CPU**

   La CPU si occupa della lettura e dell’ordinamento sequenziale delle esecuzioni di istruzioni nel contratto, secondo la funzione del controllo del flusso di istruzioni, di operazioni aritmetiche e di operazioni logiche. Il futuro della funzione CPU può essere ampliato con l’introduzione della funzione JIT (real-time compiler), migliorando così l’efficienza di esecuzione delle istruzioni.

 * **Call Stack**

   Il call stack (stack delle invocazioni a funzioni) è usato per	memorizzare le informazioni di contesto del programma in       esecuzione durante ogni invocazione di funzione. 

 * **Calculate Stack**

   Tutti i dati di runtime di NeoVM sono conservati nel calculation stack (stack di calcolo) quando dopo un implementazione di diverse istruzioni, lo stack sarà calcolato sui corrispondenti elementi di dati dell’operazione. Per esempio, quando vengono eseguite funzioni aggiuntive, le due operazioni che partecipano all’aggiunta sono espulse dal calculation stack (stack di calcolo), e il risultato dell’aggiunta è mandato in cima allo stack. I parametri delle invocazioni di funzione devono anch’essi essere calcolati da destra a sinistra, seguendo l’ordine dello stack. Dopo che la funzione è stata eseguita con successo, la funzione di recupero in cima dello stack restituisce il valore.  

 * **Stack di Riserva**

   Quando c'è bisogno di pianificare o riorganizzare elementi nello stack, si possono memorizzare temporaneamente gli elementi nello stack di riserva (c.d. spare stack) e recuperarli in futuro. 

### 4.2 Set di Instruzioni

NeoVM fornisce un set semplice e pratico di istruzioni per lo sviluppo di programmi smart contract. A seconda dei bisogni, le categorie principali sono le seguenti: 

 * Istruzione costante
 * Istruzione di controllo del processo 
 * Stack di istruzioni operative 
 * Istruzione di string
 * Istruzioni logiche 
 * Istruzione operativa aritmetica 
 * Istruzione crittografica 
 * Istruzioni dati operazionale

Va osservato che il set di istruzioni di NeoVM offre una serie di istruzioni crittografiche, come l’ECDSA, lo SHA e altri algoritmi volti a ottimizzare l’efficienza di implementazione degli algoritmi crittografici negli smart contract. Inoltre, le istruzioni di manipolazione dei dati supportano direttamente matrici (c.d. arrays) e strutture dati complesse.

### 4.3 Layer di servizi interoperabili

La macchina virtuale dove lo smart contract viene eseguito è un ambiente sandbox, questo richiede un layer di servizio interoperabile nei momenti in cui ha bisogno di accedere a dati al di fuori della sandbox o di mantenere i dati di runtime persistenti. Nel layer di servizi interoperabili, il contratto di NEO può aprire una serie di funzioni di sistema e di servizi nel programma dello smart contract, questi contratti possono essere accessibili e invocabili, come normali funzioni. Tutte le funzioni di sistema vengono svolte contemporaneamente, quindi non è necessario preoccuparsi della scalabilità.

### 4.4 Funzione di Debug	

Spesso, lo sviluppo di smart contracts è difficile a causa della mancanza di metodi convenienti di debug e di test. NeoVM fornisce un supporto per il debug del programma direttamente nel livello della macchina virtuale, dove puoi impostare il breakpoint sul codice del contratto, oppure un esecuzione a singolo processo o a step unico. Grazie al design di accoppiamento ridotto tra la macchina virtuale e la blockchain, è semplice integrare NeoVM direttamente con vari IDEs, in modo da offrire un ambiente di test che rimane coerente con l'ambiente di produzione finale.

## 5. Linguaggio di programmazione di alto grado 

### 5.1 C#, VB.Net, F#

Gli sviluppatori possono usare NeoContract per quasi ogni linguaggio di programmazione di alto livello alla quale sono competenti. Il primo gruppo di linguaggi di programmazione supporti sono  C #, VB.Net, F #, ecc. Per questi linguaggi forniamo compilers e plugins che consentono la compilazione di questi linguaggi di programmazione di alto grado nel set di istruzioni supportati da NeoVM. Il compiler si concentra sull’MSIL (Microsoft intermediate language) durante la compilazione, quindi teoricamente, ogni linguaggio .Net può essere tradotto in un linguaggio MSIL, ed essere supportato direttamente. 

Un’enorme quantità di sviluppatori sono abili in questi linguaggi di programmazione, e i linguaggi sopraindicati hanno un ambiente di sviluppo integrato molto robusto. Gli sviluppatori possono sviluppare, generare ed effettuare test e debug tutto nella piattaforma di Visual Studio, dove sono in grado di trarre vantaggio sfruttando appieno i modelli di sviluppo degli smart contract che forniamo.

### 5.2 Java, Kotlin

Java e Kotlin fanno parte del secondo gruppo di linguaggi supportati, anche per questi linguaggi forniamo compilers e plugins IDE per assistere gli sviluppatori nell’utilizzazione di linguaggi di programmazione basati su JVM per sviluppare applicazioni smart contract di NEO. 

Java è largamente usato, e Kotlin è di recente stato ufficialmente raccomandato da Google come linguaggio di sviluppo per Android. Crediamo che supportando questi linguaggi si possa contribuire a un aumento drastico nel numero di sviluppatori per gli smart contract di NEO. 

### 5.3 Other Languages

Successivamente, NeoContract aggiungerà il supporto ad altri linguaggi di programmazione di alto grado nel processo di sviluppo del compilatore, basandosi sul livello di difficoltà. Alcuni dei linguaggi che potrebbero essere supportati, includono:

 * C, C++, GO
 * Python, JavaScript

In futuro, continueremo a supportare sempre più linguaggi di programmazione. Il nostro scopo è di avere più del 90% degli sviluppatori di NEO utilizzare NeoContract, senza il bisogno di apprendere un nuovo linguaggio, ed eventualmente trasferire i codici di sistemi aziendali esistenti direttamente nella blockchain. 

## 6. Servizio 	

### 6.1 Blockchain Ledger (Mastro) 

Gli Smart Contracts di NEO possono ottenere blocchi di dati completi per la blockchain di NEO, comprendendo blocchi completi e transazioni, e ognuno dei loro campi durante la fase di esecuzione attraverso le funzioni di sistema fornite dal servizio interoperabile. Nello specifico, si possono interrogare i seguenti dati: 

 * Altezza della blockchain
 * Block head, blocco corrente
 * Transazioni
 * Tipo di transazioni, attributi, input, output, ecc.

Con questi dati, si possono sviluppare applicazioni interessanti, come pagamenti automatici, smart contracts basati sulla prova del carico di lavoro (c.d. proof of workload).

### 6.2 Digital Assets

Attraverso i servizi interoperabili forniti dall’interfaccia degli asset digitali, gli smart contracts non solo possono interrogare la blockchain di NEO su proprietà e statistiche delle varie risorse digitali, ma anche creare nuovi assets digitali durante la fase di esecuzione (fase di runtime). Gli asset digitali creati da smart contract possono essere emessi, trasferiti e scambiati all’infuori del contratto. Questi sono uguali alle risorse digitali su NEO, e possono essere gestite con ogni portafoglio compatibile con NEO. Le interfacce specifiche sono: 

 * Richiesta di attributo dell’asset (c.d. Asset attribute inquiry)
 * Query delle statistiche di asset (c.d. Asset statistics query) 
 * Asset di gestione del ciclo vitale: creare, modificare, distruggere, ecc.
 * Gestione degli asset: nome multi-linguaggio, cambiamento assoluto, cambiamento preciso e cambiamenti nell’amministratore. 
 
### 6.3 Persistenza

Ogni programma smart contract distribuita nella blockchain di NEO, avrà un’area di memorizzazione privata che può essere letta e scritta solo dal contratto stesso. Gli smart contracts hanno piena autorizzazione operativa sui dati in loro possesso: possono essere letti, scritti, modificati e cancellati. I dati vengono memorizzati sotto forma di coppie chiave/valore e prevedono le seguenti interfacce: 

 * Attraversa tutti i record memorizzati 
 * Ritorno a un record specifico in base alla chiave specificata 
 * Modifica o scrivi nuovi record in base alla chiave specificata 
 * Elimina il record in base alla chiave specificata

In generale, un contratto può solo leggere e scrivere dati che memorizza al proprio interno, con una eccezione: quando un contratto è richiamato, il contratto richiamato può accedere alla memoria del chiamante attraverso una richiesta tra domini a condizione che il chiamante fornisca l’autorizzazione. Inoltre, per un sub-contratto creato dinamicamente al momento dell’esecuzione del contratto, il contratto principale ottiene l'accesso immediato alla sua memoria. 

Richieste tra domini consentono NeoContract di implementare funzionalità di raccolta più ricche, ciò fornisce ai chiamanti una capacità di gestione dei dati altamente scalabile. 

## 7. Tasse

### 7.1 Tasse di Distribuzione

L’architettura distribuita di NEO fornisce un’elevata ridondanza della capacità di archiviazione, e l’uso di questa capacità non è gratuito. La distribuzione di uno smart contract nella rete di NEO richiede una tassa, al momento fissa a 500GAS, che è raccolta dal sistema e registrata come guadagno del sistema. Tasse future saranno regolate in base al costo operativo effettivo del sistema. Lo smart contract distribuito nel sistema può essere usato più volte, fino a quando il contratto non viene distrutto dal distributore. 

### 7.2 Tasse di Implementazione

NEO fornisce un ambiente credibile per l’esecuzione degli smart contracts, l'esecuzione di contratti richiede il consumo di risorse di calcolo per ogni nodo, dunque gli utenti sono tenuti a pagare per l'esecuzione di smart contracts. La commissione è determinata dalle risorse computazionali consumate da ciascuna esecuzione, il prezzo unitario è anch’esso in GAS. Se l’esecuzione dello smart contract fallisce a causa di una mancanza di GAS, il costo dei consumi non verrà restituito, e ciò impedisce attacchi dannosi al consumo di energia del network. 

I contratti più semplici possono essere eseguiti gratuitamente, fintanto che i costi di esecuzione rimangano inferiori a 10 GAS, riducendo notevolmente i costi per l’utente. 

## 8. Scenari di Applicazione

### 8.1 Transazioni superconduttrici

Gli asset digitali sulla blockchain richiedono intrinsecamente una qualche forma di liquidità e di solito le transazioni point-to-point non possono fornirle a sufficienza. Pertanto, vi è la necessità di exchanges che forniscano agli utenti servizi di trading. Gli exchanges di asset digitali possono essere divisi in due categorie: 

1. **Exchanges centralizzati:** nei quali l’utente deve depositare gli assets nell’exchange, e in seguito piazzare ordini pendenti per il trading, nel sito. 
2. **Exchanges decentralizzati:** nei quali il sistema di trading è integrato nella blockchain, e il sistema fornisce servizi di corrispondenza. 

Gli exchanges centralizzati possono fornire prestazioni molto elevate e servizi diversificati, ma devono avere una forte garanzia di credito, altrimenti ci saranno rischi morali; come appropriazione indebita di fondi utente, frodi, ecc. Comparativamente, gli exchanges decentralizzati non hanno rischi morali, ma l'esperienza utente è scarsa, e c'è un bottleneck nelle prestazioni maggiore. Esiste un modo per combinare entrambe le soluzioni e ottenere il meglio di entrambi i mondi?

Le transazioni superconduttrici sono parte di un meccanismo che possono risolvere il problema. Gli utenti non hanno bisogno di depositare assets, dove sono in grado di utilizzare i propri assets sulla blockchain per il trading. Il regolamento delle operazioni completo è sulla blockchain, ma il processo di abbinamento degli ordini avviene fuori dalla chain da un exchange centralizzato che fornisce servizi corrispondenti. Visto che l’abbinamento è off-chain, la sua efficienza è quella degli exchanges centralizzati, ma gli assets rimangono sotto il controllo dell'utente. Gli exchanges usano l’intento di effettuare trading dell’utente per svolgere servizi di corrispondenza, senza rischi morali coinvolti, come appropriazione indebita di fondi utente, frodi, ecc.

Al momento, nella comunità di NEO, è emerso lo sviluppo di smart contracts destinati alla realizzazione di transazioni superconduttrici nella blockchain, come l’OTCGO. 

### 8.2 Smart Fund

Gli smart funds (fondi intelligenti) basati sulla blockchain hanno il vantaggio di essere decentralizzati, aperti e trasparenti, detenendo un alto grado di sicurezza e libertà se comparati ai fondi tradizionali. Questi smart funds sono anche cross-border e aperti agli investitori di tutto il mondo, dove progetti eccezionali possono essere finanziati con capitali da tutto il mondo.

Nest è un progetto smart fund basato su NeoContract, molto simile al progetto TheDAO basato su Ethereum, nel quale sono necessarie migliorie nelle misure di sicurezza per evitare gli errori di TheDAO (hacker).

### 8.3 Interoperabilità Cross-chain

In un prossimo futuro, ci saranno molte chains pubbliche e migliaia di alliance chains o di chains private esistenti in tutto il mondo. Questi sistemi isolati di blockchain sono isole di valore e di informazione, che non sono interoperabili l’uno con l’altro. Attraverso il meccanismo di interoperabilità della cross-chain, numerose blockchain isolate possono essere collegate, in modo che i valori in diverse blockchain possano essere scambiati tra loro, così da realizzare il vero valore di Internet. 

NeoContract fornisce il supporto per l'implementazione dell'interoperabilità della cross-chain, assicurando una coerenza dello scambio di asset nella cross-chain, transazioni distribuite della cross-chain e l’esecuzione di smart contracts su diverse blockchains. 

### 8.4 Macchine Oracle

Il concetto di oracles (oracoli) nelle leggende popolari risiede nelle abilità di alcune entità soprannaturali che possono rispondere a una serie particolare di domande. Nella blockchain, le macchine oracles aprono la porta al mondo esterno per gli smart contracts, rendendo possibile agli smart contracts l’utilizzo di informazioni del mondo reale come condizione per l'esecuzione del contratto.

NeoContract non fornisce la possibilità di accedere direttamente ai dati esterni, come l'accesso alle risorse su Internet, poiché ciò introdurrà un comportamento non deterministico, causando incoerenze tra i nodi durante l'esecuzione del contratto. L’implementazione della macchina oracle in NeoContract richiede che i dati esterni siano inviati alla blockchain da una terza parte fidata (TTP trusted third party), integrando questi feed di dati come parte del ledger della blockchain, eliminando così il fattore non-deterministico.

La terza parte fidata summenzionata, può essere una persona o un'istituzione che è fidata da entrambe le parti nel contratto, o un fornitore di dati decentralizzato che è garantito da incentivi economici. In questo modo, NeoContract può essere usato nell’implementazione di tali macchine Oracle. 

### 8.5 Ethereum DAPP

Bitcoin ha creato l'era delle blockchain e del denaro digitale, ed Ethereum ha creato l'era degli smart contracts. Ethereum, i pionieri dello smart contract sulla blockchain, ha dato un gran contributo all'idea progettuale, al modello economico e alla realizzazione tecnologica di un sistema di smart contract. Nel contempo, la piattaforma di Ethereum ha avuto molte DAPPs (applicazioni distribuite), dove funzionalità come: scommesse, assets digitali, oro elettronico, piattaforme di gioco, assicurazione sanitaria, piattaforme di matrimonio, hanno un uso diffuso su molte industrie. In teoria tutte queste DAPPs possono essere facilmente trasferite sulla piattaforma NeoContract, come un’applicazione NEO. 
