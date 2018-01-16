# Un Algoritmo Byzantine Fault Tolerance per la Blockchain 

Erik Zhang

erik@vcage.com 

## Sommario

​Questo articolo propone un algoritmo Byzantine Fault Tolerance migliorato, adeguato per un sistema blockchain. Ipoteticamente, in questo sistema, i messaggi possono essere soggetti a perdita, danno, latenza e ripetizione. Inoltre, l'ordine di invio potrebbe non essere necessariamente coerente con l'ordine di ricezione dei messaggi. Le attività dei nodi potrebbero essere arbitrarie, questi possono unirsi e uscire dalla rete in qualsiasi momento; Possono anche scaricare e falsificare informazioni o semplicemente smettere di funzionare. Possono anche verificarsi anomalie artificiali o non artificiali. Il nostro algoritmo fornisce una tolleranza ai guasti di 𝑓 = ⌊ (𝑛−1) / 3 ⌋ a un sistema di consenso che comprende n nodi. Questa capacità di tolleranza include sicurezza e usabilità ed è adatta per qualsiasi ambiente di rete. 

## Panoramica 

Un sistema blockchain è un mastro distribuito e decentralizzato. Potrebbe essere utilizzato per la registrazione e l'emissione di assets digitalizzati, certificati di proprietà, punti di credito e così via. Consente trasferimenti, pagamenti e transazioni in maniera peer-to-peer. La tecnologia blockchain è stata inizialmente proposta da Satoshi Nakamoto in una mailing list crittografica, il Bitcoin. Da allora sono emerse numerose applicazioni basate sulla blockchain, come sistemi di e-cash, di capitali azionari e sistemi di Smart Contract.

Un sistema blockchain è vantaggioso rispetto a un tradizionale sistema basato su un registro centralizzato grazie alla sua piena apertura, immutabilità e caratteri "anti spese multiple", inoltre non si affida a nessun tipo di ente terzo attendibile.

Tuttavia, come tutti i sistemi distribuiti, i sistemi blockchain devono fare i conti con latenza di rete, errori di trasmisione, bugs nei software, falle di sicurezza e minacce provenienti da hacker black-hat. Peraltro, la sua natura decentralizzata suggerisce che nessun partecipante al sistema è affidabile. Potrebbero emergere nodi malevoli, così come differenze tra dati dovute a un conflitto di interessi.

Per contrastare questi potenziali errori, un sistema blockchain ha bisogno di un meccanismo di consenso efficiente per poter garantire che ogni nodo abbia una copia di una versione riconosciuta del registro pubblico. I tradizionali sistemi basati sulla tolleranza ai guasti riguardanti determinate difficoltà potrebbero non essere completamente capaci di affrontare i problemi che i sistemi distribuiti e i sistemi blockchain devono fronteggiare. E' necessaria una cura universale per tutte le soluzioni di tolleranza ai guasti.

Il meccanismo Proof-of-Work[1], impiegato dal Bitcoin, affronta il problema in modo piuttosto brillante. Ma c'è un prezzo da pagare, ossia i costi di elettricitá significativi e consumo di energia. Ulteriormente, con l'esistenza del Bitcoin, nuove blockchain devono trovare algoritmi di hashing diversi, in modo da prevenire attacchi computazionali dallo stesso. Per esempio, Litecoin usa SCRYPT, invece di SHA256 che viene usato dal Bitcoin.

Il meccanismo Byzantine Fault Tolerance rappresenta una soluzione universale per sistemi distribuiti[5]. Qui in questo articolo, basato sul Practical Byzantine Fault Tolerance (PBFT)[3] proposto da Castro e Liskov in 1999, un algoritmo migliorato basato sul Byzantine Fault Tolerance viene proposto per i sistemi blockchain。 

## Modello di Sistema 

Una blockchain è un registro distribuito in cui i partecipanti si connettono tra loro tramite una rete peer-to-peer. Tutti i messaggi al suo interno verranno inviati tramite trasmissione. Esistono due tipi di ruoli: Nodi ordinari e nodi di "Bookkeeping" (contabilitá). I nodi ordinari usano il sistema per trasferire, scambiare e accettare i dati del registro; Mentre i nodi bookkeeping forniscono servizi di contabilità per l'intera rete e mantengono il registro. 

Ipoteticamente, in questo sistema, i messaggi possono essere soggetti a perdita, danno, latenza e ripetizione. Inoltre, l'ordine di invio potrebbe non essere necessariamente coerente con l'ordine di ricezione dei messaggi. Le attività dei nodi potrebbero essere arbitrarie, essi possono unirsi e uscire dalla rete in qualsiasi momento; Possono anche scaricare e falsificare informazioni o semplicemente smettere di funzionare. Possono anche verificarsi anomalie artificiali o non artificiali.

L'integrità e l'autenticità della trasmissione delle informazioni sono garantite dalla crittografia mentre i mittenti devono allegare firme al valore hash del messaggio inviato. Definiamo che 〈𝑚〉<sub>𝜎𝑖</sub> è il messaggio delle m firme digitali dal nodo i, mentre D(m) è il valore hash del messaggio m. Senza particolari chiarimenti, tutte le firme a cui si fa riferimento in questo articolo sono firme per il valore hash del messaggio.

## Algoritmo

​Il nostro algoritmo garantisce sicurezza e usabilità. Con un numero di nodi erronei nel consenso non maggiore di ⌊ (𝑛−1) / 3 ⌋ , la funzionalità e la stabilità del sistema sono garantite. In esso, 𝑛 = | 𝑅 | suggerisce il numero totale di nodi entrati nel consenso mentre R corrisponde al numero di nodi di consenso. Data 𝑓 = ⌊ (𝑛−1) / 3 ⌋, f indica il numero massimo di nodi erronei ammessi nel sistema. Di fatto, il registro è mantenuto dai nodi Bookkepping mentre i nodi ordinari non partecipano al processo di consenso. Ciò per mostrare l'intera procedura di consenso.

Tutti i nodi di consenso sono tenuti a mantenere una tabella di stato per registrare lo stato di consenso corrente. Il set di dati utilizzato per un consenso dal suo inizio fino alla sua fine è chiamato View. Se non è possibile raggiungere il consenso all'interno della View corrente, sarà necessario un cambiamento di View. Identifichiamo ciascuna View con un numero v, iniziante per 0 e può aumentare fino al raggiungimento del consenso.

​Identifichiamo ciascun nodo di consenso con un numero, a partire da 0, l'ultimo nodo è numerato n - 1. Per ogni round di realizzazione del consenso, un nodo fará lo "speaker" (oratori) della casa mentre gli altri nodi fanno i "congressman" (deputati). Il numero p di "speaker" sarà determinato dall'algoritmo seguente: Ipoteticamente l'attuale altezza del blocco è h, poi 𝑝 = (ℎ − 𝑣) 𝑚𝑜𝑑 𝑛, l'intervallo di valori di p sarà  0 ≤ 𝑝 < 𝑛 .

​Un nuovo blocco verrà generato in ogni round di consenso, con almeno 𝑛 − 𝑓 firme dai nodi bookkeeping. Alla generazione di un blocco, inizierà un nuovo round di consenso, resettando v=0.

###  Procedure Generali

Essendo t l'intervallo di tempo nella generazione dei blocchi, sotto normali circostanze, l'algoritmo verrà eseguito nelle seguenti procedure: 

1) Un nodo trasmette i dati della transazione all'intera rete, in allegato con la firma del mittente;

2) Tutti i nodi bookkepper monitorano la trasmissione dei dati delle transazioni in modo indipendente e memorizzano i dati nella rispettiva memoria; 

3) Dopo il tempo t, lo speaker invia 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑞𝑢𝑒𝑠𝑡,ℎ,𝑣,𝑝,𝑏𝑙𝑜𝑐𝑘,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑝</sub>〉； 

4) Dopo aver ricevuto la proposta, il congressmen i invia 〈𝑃𝑒𝑟𝑝𝑎𝑟𝑒𝑅𝑒𝑠𝑝𝑜𝑛𝑠𝑒,ℎ,𝑣,𝑖,〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>〉 ;

​5) Ogni nodo, dopo aver ricevuto almeno 𝑛 − 𝑓  〈𝑏𝑙𝑜𝑐𝑘〉<sub>𝜎𝑖</sub>, raggiunge il consenso e pubblica un blocco intero;

6) Ogni nodo, dopo aver ricevuto il blocco completo, elimina la transazione in questione dalla sua memoria e inizia il prossimo round di consenso;

Viene richiesto che, per tutti i nodi di consenso, almeno 𝑛 − 𝑓 nodi si trovino nello stato originiale. Vale a dire, per tutti i nodi i, l'altezza del blocco h e il numero di View v sono uguali. Questo non è difficile, la consistenza di h potrebbe essere raggiunta sincronizzando i blocchi mentre la consistenza di v potrebbe essere raggiunta cambiando la View. La sincronizzazione dei blocchi non è trattata in questo articolo. Per il cambio di View, controllare la prossima sezione.

I nodi, dopo aver monitorato la trasmissione e ricevuto la proposta, convalidano le transazioni. Non possono scrivere una transazione illegale nella memoria una volta che quest'ultimo si è esposto. Se una transazione illegale è contenuta nella proposta, questo specifico round di consenso sarà abbandonato e la modifica della View avverrà immediatamente. Le procedure di convalida sono le seguenti:

1) Il formato dei dati della transazione è coerente con le regole di sistema? Se no, la transazione è illegale;

2) La transazione è già nella blockchain? Se si, la transazione è illegale;

3) Tutti gli script del contratto della transazione sono stati eseguiti correttamente? Se no, la transazione è illegale;

4) C'è una "spesa multipla" nella transazione? Se si, la transazione è illegale;

5) Se la transazione non è stata dichiarata illegale nelle suddette procedure, sarà giudicata legale;

### Cambi di View

Se, dopo l'intervallo di tempo 2<sup>𝑣+1</sup> ⋅ 𝑡, i nodi i non possono raggiungere il consenso o se dovessero ricevere proposte contenenti transazioni illegali, avrà luogo il cambio View: 

1) Dato k=1, 𝑣<sub>𝑘</sub> = 𝑣 + 𝑘 ;

2) I nodi i inviano una richiesta di Cambio di View 〈𝐶ℎ𝑎𝑛𝑔𝑒𝑉𝑖𝑒𝑤,ℎ,𝑣,𝑖,𝑣<sub>𝑘</sub>〉 ;

3) Una volta che un nodo riceve almeno 𝑛 − 𝑓  uguali v<sub>k</sub> da un i diverso, il cambio di View è completo. Stabilito 𝑣 = 𝑣<sub>𝑘</sub> il processo di consenso inzia;

4) Se, l'intervallo di tempo 2<sup>𝑣+1</sup> ⋅ 𝑡, il cambio di View non è completato, il valore k aumenterà e ritornerà allo step 2);

Con l'aumentare di k, il tempo di attesa extra aumenterà in modo esponenziale, quindi frequenti cambiamenti di View verranno evitati e i nodi verranno sollecitati a raggiungere la coerenza su v.

Prima del completamento del cambio di View, l'originale View v è ancora valida, dunque i cambiamenti non necessari di View causati da una latenza occasionale della rete possono essere evitati. 

### Diagramma di Flusso

![](~/assets/consensus_flowchart.jpg)

## Capacità di Tolleranza ai Guasti

​Il nostro algoritmo fornisce 𝑓 = ⌊ (𝑛−1) / 3 ⌋ tolleranza ai guasti a un sistema di consenso che comprende n nodi. Questa capacità di tolleranza include sicurezza e usabilità ed è adatta a qualsiasi ambiente di rete. 

La richiesta di dati dai nodi contiene le firme dei mittenti, quindi i nodi bookkepper malevoli non possono falsificare le richieste. Invece, cercheranno di invertire lo stato del sistema nel passato, forzando il sistema a forkare.

Ipoteticamente, nell'ambiente di sistema della rete, i nodi di consenso sono divisi in 3 parti: 𝑅 = 𝑅1 ∪ 𝑅2 ∪ 𝐹 , e 𝑅1 ∩ 𝑅2 = ∅ , 𝑅1 ∩ 𝐹 = ∅ ，𝑅2 ∩ 𝐹 = ∅ . Anche ipoteticamente,
entrambi R1 e R2 sono nodi bookkeeping onesti in un silo di informazioni che possono comunicare solo con i nodi nel loro set; F sono tutti nodi malevoli in coordinazione; Inoltre, la condizione di rete di F consente loro di comunicare con qualsiasi nodo, inclusi R1 e R2.
Se F desidera forkare il sistema, devono raggiungere il consenso con R1 e pubblicare i blocchi, e quindi raggiungere un secondo consenso senza informare R2, revocando il consenso con R1.
​Per raggiungere questo, è necessario che |𝑅1| + |𝐹| ≥ 𝑛 − 𝑓 and |𝑅2| + |𝐹| ≥ 𝑛 − 𝑓 .
Nel peggiore dei casi, |𝐹| = 𝑓​ , Cioè il numero dei nodi malevoli è il massimo che il sistema può tollerare e la relazione summenzionata diventa |𝑅1| ≥ 𝑛 − 2𝑓​ e ​|𝑅2| ≥ 𝑛 − 2𝑓. Sommate insieme, |𝑅1| + |𝑅2| ≥ 2𝑛 − 4𝑓​, il quale può essere semplificato come ​𝑛 ≤ 3𝑓. Dato che 𝑓 = ⌊ (𝑛−1) / 3 ⌋, che contraddice il primo, può essere dimostrato che il sistema non può essere forkato all'interno del campo di tolleranza.

## Riferimenti 

[1] Nakamoto S. Bitcoin: A peer-to-peer electronic cash system[J]. 2008. 

[2] Lamport L, Shostak R, Pease M. The Byzantine generals problem[J]. ACM Transactions on Programming Languages and Systems (TOPLAS), 1982, 4(3): 382-401. 

[3] Castro M, Liskov B. Practical Byzantine fault tolerance[C]//OSDI. 1999, 99: 173 186.

[4] Bracha G, Toueg S. Asynchronous consensus and broadcast protocols[J]. Journal of the ACM (JACM), 1985, 32(4): 824-840. 

[5] 范捷, 易乐天, 舒继武. 拜占庭系统技术研究综述[J]. 软件学报, 2013, 6: 012. 
