# Consenso

## 1 - Elenco dei Termini

* **Proof of Stake** `PoS` - Un tipo di algoritmo che usa il consenso di rete per gestire la tolleranza ai guasti.

* **Proof of Work** `PoW` - Un tipo di algoritmo che utilizza la potenza di calcolo per gestire la tolleranza ai guasti.

* **Byzantine Fault** `BF` - Un fallimento nel quale un nodo rimane funzionante, ma opera in maniera disonesta.

* **Delegated Byzantine Fault Tolerance** `DBFT` - Un algoritmo di consenso implementato nella blockchain NEO per garantire la tolleranza ai guasti.

* **View** `v` - Il set di dati utilizzato durante l'attività di consenso `DBFT` in NEO.

## 2 - Ruoli
**Nell'algoritmo di consenso di NEO, i Consensus Node sono eletti dai possessori di NEO e votano sulla validità delle transazioni. Questi nodi vengono anche definiti come 'Bookkeepers'. Da ora in avanti, ci riferiremo ad essi come Consensus Nodes**.

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Consensus Node** - Questo nodo partecipa nell'attività di consenso. Durante l'attività di consenso, i nodi di consenso si alternano assumendo i due seguenti ruoli:
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Speaker** `(One)` - Lo **Speaker** è responsabile per la trasmissione di un blocco come proposta al sistema.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Delegate** `(Multiple)` - I **Delegates** sono responsabili della realizzazione del consenso sulla transazione.


## 3 - Introduzione

Una delle differenze fondamentali tra le blockchain è il modo in cui possono garantire la tolleranza d'errore data l'attività "difettosa" e non onesta sulla rete.

I metodi tradizionali implementati usando il PoW possono fornire questa garanzia a patto che la maggior parte della potenza computazionale della rete sia onesta. Comunque, a causa della dipendenza di questo schema dalla potenza computazionale, il meccanismo può essere davvero inefficiente (la potenza computazionale costa energia e richiede hardware). Queste dipendenze espongono la rete PoW a una serie di limitazioni, la principale é il costo di scalabilitá.

NEO implementa un algoritmo di consenso Delegated Byzantine Fault Tolerance (DBFT) il quale sfrutta alcune caratteristiche del PoS (i possessori NEO possono votare i **Consensus Nodes**) il quale protegge la rete da difetti Byzantine usando una quantitá di risorse minima, mentre respinge alcuni dei suoi problemi. Questa soluzione risolve i problemi di prestazione e scalabilità associati alle attuali implementazioni blockchain senza un impatto significativo sulla tolleranza ai guasti.  


## 4 - Teoria

Il Byzantine Generals Problem é un classico problema nel calcolo distribuito. Il problema definisce un numero di **Delegates** che devono realizzare il consenso sul risultato proveniente da un'ordine dello **Speaker**. In questo sistema, bisogna stare attenti perché lo **Speaker** o un numero qualsiasi di **Delegates** potrebbero essere dei traditori. Un nodo disonesto potrebbe non inviare un messaggio coerente a ogni destinatario. Questa é considerata come la situazione piú disastrosa. La soluzione al problema richiede che i **Delegates** identifichino se lo **Speaker** sia onesto e quale fosse il vero comando come gruppo.

Allo scopo di descrivere come funziona il DBFT, concentreremo principalmente questa sezione sulla giustificazione del tasso di consenso del 66.66% utilizzato nella sezione 5. Tieni a mente che un nodo disonesto non necessariamente deve essere attivamente malevolo, potrebbe semplicemente non funzionare come previsto.

Per il bene della discussione, descriveremo un paio di scenari. In questi semplici esempi, assumeremo che ogni nodo invii il messaggio ricevuto dallo **Speaker**. Questo meccanismo é usato anche nel DBFT ed é fondamentale per il sistema. Descriveremo solamente la differenza fra un sistema funzionante e un sistema non funzionante. Per una spiegazione maggiormente dettagliata, vedi i riferimenti.


### **Speaker Onesto**

  <p align="center"><img src="/assets/n3.png" width="300"><br> <b>Figura 1:</b> Esempio n = 3 con un <b>Delegate</b> disonesto.</p>

  Nella **Figura 1**, abbiamo un singolo **Delegate** leale (50%). Entrambi i **Delegates** ricevono lo stesso messaggio dallo **Speaker** onesto. Comunque, a causa della disonestá di un **Delegate**, il Delegate onesto puó solo determinare che c'é un nodo disonesto, ma non é in grado di identificare se si tratti del creatore del blocco (lo **Speaker**) o del **Delegate**. Per questo motivo, il **Delegate** deve astenersi dal voto, cambiando la View.

  <p align="center"><img src="/assets/n4.png" width="400"><br> <b>Figura 2:</b> Esempio n = 4 con un <b>Delegate</b> disonesto.</p>

  Nella **Figura 2**, abbiamo due **Delegates** leali (66%). Tutti i **Delegates** ricevono lo stesso messaggio dallo **Speaker** onesto e inviano il loro risultato di convalida, insieme al messaggio ricevuto dallo Speaker l'un l'altro **Delegate**. Sulla base del consenso dei due **Delegates** onesti, siamo capaci di determinare se lo **Speaker** o il **Delegate** a destra siano disonesti nel sistema. 

  


### **Speaker Disonesto** 

  <p align="center"><img src="/assets/g3.png" width="300"><br> <b>Figura 3:</b> Esempio n = 3 con uno <b>Speaker</b> disonesto. </p>

  Nel caso della **Figura 3**, dello **Speaker** disonesto, abbiamo una conclusione identica a quella raffigurata nella **Figurea 1**. Il **Delegate** non é capace di determinare quale nodo si disonesto.

  <p align="center"><img src="/assets/g4.png" width="400"><br> <b>Figura 4:</b> Esempio n = 4 con uno <b>Speaker</b> disonesto. </p>

  Nell'esempio posto dalla **Figura 4**, i blocchi ricevuti dal nodo centrale e dal nodo destro non sono validabili. Ció causa un differimento per una nuova View che elegge un nuovo **Speaker** perché essi hanno la maggioranza del 66%. In questo esempio, se lo **Speaker** disonesto aveva inviato dati onesti ai due dei tre **Delegates**, sarebbe stato convalidato senza la necessitá di un cambio di View.


## 5 - Implementazioni Pratiche

L'implementazione pratica del DBFT in NEO avviene tramite un metodo iterativo di consenso per garantire che lo stesso venga realizzato. Le performance dell'algoritmo dipendono dalla frazione dei nodi onesti nel sistema. La **Figura 5** raffigura le iterazioni previste in funzione della frazione dei nodi disonesti.

Nota che la **Figura 5** non si estende al di sotto del 66.66% di onestá dei **Consensus nodes**. Tra questo punto critico e il 33% di onestá dei **Consensus nodes**, c'é 'la terra di nessuno' dove il consenso é irragiungibile. Sotto il 33% di onestá dei **Consensus nodes**, i nodi disonesti (assumendo che siano allineati nel consenso) sono capaci di raggiungere il consenso da soli e diventare un nuovo punto di veritá nel sistema.

<img src="/assets/consensus.iterations.png" width="800">

**Figura 5:** Simulazione Monto-Carlo dell'algoritmo DBFT raffigurante le iterazioni necessarie per raggiungere il consenso. {100 Nodi; 100,000 Blocchi simulati con una selezione casuale dei nodi onesti}


### 5.1 - Definizioni

**All'interno dell'algoritmo, definiamo quanto segue:**

  - `t`: Quantitá di tempo allocata per la generazione di un blocco, misurata in secondi.
    - Correntemente: `t = 15 secondi`
    - Questo valore puó essere usato per approssimare il tempo di una singola iterazione View poiché l'attivitá di consenso e gli eventi di comunicazione sono veloci rispetto a questa costante di tempo. 
  - `n`: Il numero di **Consensus Nodes** attivi.

  - `f`: La soglia minima di **Consensus Nodes** difettosi all'interno del sistema. 
     - `f = (n - 1) / 3`

  - `h` : L'altezza del blocco corrente durante l'attivitá di consenso.

  - `i` : Indice **Consensus Node**.


  - `v` : La View di un **Consensus Node**. La View contiene le informazioni aggregate che i nodi hanno ricevuto durante il round di consenso. Questa include il voto (`prepareResponse` o `ChangeView`) emesso da tutti i Delegates.


  - `k` : L'indice della View `v`. Un'attivitá di consenso puó richiedere round multipli. In caso del fallimento del consenso, `k` é incrementato e un nuovo round di consenso comincia.


  - `p` : Indice del **Consensus Node** eletto come **Speaker**. Questo meccanismo di calcolo per questo indice ruota tra i **Consensus Nodes** per prevenire che un singolo nodo agisca da dittatore all'interno del sistema. 
     - `p = (h - k) mod (n)`


  - `s`: La soglia sicura di consenso. Al di sotto di questa soglia, la rete é esposta a guasti.  
     - `s = ((n - 1) - f)`


### 5.2 - Requisiti

**Within NEO, there are three primary requirements for consensus fault tolerance:**

1. `s` **Delegates** must reach a consensus about a transaction before a block can be committed.

2. Dishonest **Consensus Nodes** must not be able to persuade the honest consensus nodes of faulty transactions. 

3. At least `s` **Delegates** are in same state (`h`,`k`) to begin a consensus activity



### 5.3 - Algorithm
**The algorithm works as follows:**

1. A **Consensus Node** broadcasts a transaction to the entire network with the sender's signatures.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Figure 6:</b> A <b>Consensus Node</b> receives a transaction and broadcasts it to the system. </p>

2. **Consensus Nodes** log transaction data into local memory.

3. The first view `v` of the consensus activity is initialized.

4. The **Speaker** is identified. **Wait** `t` seconds.
<p align="center"><img src="/assets/consensus2.png" width="450"><br/> <b>Figure 7:</b> A <b>Speaker</b> has been identified and the view has been set.</p>

5. The **Speaker** broadcasts the proposal : `<prepareRequest, h, k, p, bloc, [block]sigp>`

     <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Figure 8:</b> The <b>Speaker</b> mints a block proposal for review by the <b>Delegates</b>. </p>

6. The **Delegates** receive the proposal and validate:

    - Is the data format consistent with the system rules?
    - Is the transaction already on the blockchain?
    - Are the contract scripts correctly executed?
    - Does the transaction only contain a single spend?(i.e. does the transaction avoid a double spend scenario?)
    - **If Validated Proposal Broadcast:**  `<prepareResponse, h, k, i, [block]sigi>`
    - **If Invalidated Proposal Broadcast:**  `<ChangeView, h,k,i,k+1>`

   <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Figure 9:</b> The <b>Delegates</b> review the block proposal and respond. </p>

7. After receiving `s` number of 'prepareResponse' broadcasts, a **Delegate** reaches a consensus and publishes a block.

8. The **Delegates** sign the block.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Figure 10:</b> A consensus is reached and the approving <b>Delegates</b> sign the block, binding it to the chain. </p>

9. When a **Consensus Node** receives a full block, current view data is purged, and a new round of consensus begins. 
  - `k = 0`

---

**Note:**

 If after   (![timeout](/assets/consensus.timeout.png) )  seconds on the same view without consensus:
  - **Consensus Node** broadcasts:

  <!-- -->
      <ChangeView, h,k,i,k+1>

  - Once a **Consensus Node** receives at least `s` number of broadcasts denoting the same change of view, it increments the view `v`, triggering a new round of consensus.


​	

## 6 - References
1. [A Byzantine Fault Tolerance Algorithm for Blockchain](whitepaper.md)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

