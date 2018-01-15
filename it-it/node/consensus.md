# Consenso

## 1 - Elenco dei Termini

* **Proof of Stake** `PoS` - Un tipo di algoritmo che usa il consenso di rete per gestire la tolleranza ai guasti.

* **Proof of Work** `PoW` - Un tipo di algoritmo che utilizza la potenza di calcolo per gestire la tolleranza ai guasti.

* **Byzantine Fault** `BF` - Un fallimento nel quale un nodo rimane funzionante, ma opera in maniera disonesta.

* **Delegated Byzantine Fault Tolerance** `DBFT` - Un algoritmo di consenso implementato nella blockchain NEO per garantire la tolleranza ai guasti.

* **View** `v` - Il set di dati utilizzato durante l'attività di consenso `DBFT` in NEO.

## 2 - Ruoli
**Nell'algoritmo di consenso di NEO, i Nodi di Consenso sono eletti dai possessori di NEO e votano sulla validità delle transazioni. Questi nodi vengono anche definiti come 'Contabili'. Da ora in avanti, ci riferiremo ad essi come Nodi di Consenso**.

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Nodo di Consenso** - Questo nodo partecipa nell'attività di consenso. Durante l'attività di consenso, i nodi di consenso si alternano assumendo i due seguenti ruoli:
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Speaker** `(Uno)` - Lo **Speaker** è responsabile della trasmissione di una proposta di blocco al sistema.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Delegati** `(Multipli)` - I **Delegati** sono responsabili della realizzazione del consenso sulla transazione.


## 3 - Introduzione

Una delle differenze fondamentali tra le blockchain è il modo con la quale possono garantire la tolleranza ai guasti data un'attività "difettosa" e non onesta sulla rete.

I metodi tradizionali implementati che fanno uso del PoW possono fornire questa garanzia a patto che la maggior parte della potenza di calcolo della rete sia onesta. Tuttavia, a causa di questa dipendenza dello schema dalla potenza computazionale, il meccanismo può essere davvero inefficiente (la potenza di calcolo costa energia e richiede hardware). Queste dipendenze espongono la rete PoW a una serie di limitazioni, la principale é il costo di scalabilitá.

NEO implementa un algoritmo di consenso chiamato Delegated Byzantine Fault Tolerance (DBFT) il quale sfrutta alcune caratteristiche del PoS (i possessori NEO possono votare i **Nodi di Consenso**) il quale protegge la rete da difetti Byzantine (Bizantini) usando una quantitá di risorse minima, mentre respinge alcuni dei suoi problemi. Questa soluzione risolve i problemi di prestazione e di scalabilità associati alle attuali implementazioni blockchain senza un impatto significativo sulla tolleranza ai guasti.  


## 4 - Teoria

Il Problema dei Generali Bizantini é un classico problema nel calcolo distribuito. Il problema definisce un numero di **Delegati** che devono realizzare un consenso sul risultato proveniente da un'ordine dello **Speaker**. In questo sistema, bisogna prestare attenzione poiché lo **Speaker** o un numero qualsiasi di **Delegati** potrebbero essere dei traditori. Un nodo disonesto potrebbe non inviare un messaggio coerente a ogni destinatario. Questa é da considerarsi come la situazione piú disastrosa. La soluzione al problema richiede che i **Delegati** identifichino se lo **Speaker** sia onesto e quale sia il vero comando come gruppo.

Allo scopo di descrivere come funziona il DBFT, concentreremo principalmente questa sezione sulla motivazione dell'utilizzo di un tasso di consenso del 66.66% nella sezione 5. Tenere presente che un nodo disonesto non necessariamente deve essere attivamente malevolo, potrebbe semplicemente non funzionare come previsto.

Per il bene della discussione, descriveremo un paio di scenari. In questi semplici esempi, assumeremo che ogni nodo invii il messaggio ricevuto dallo **Speaker**. Questo meccanismo é usato anche nel DBFT ed é fondamentale per il sistema. Descriveremo solamente la differenza fra un sistema funzionante e un sistema non funzionante. Per una spiegazione maggiormente dettagliata, vedere i riferimenti.


### **Speaker Onesto**

  <p align="center"><img src="/assets/n3.png" width="300"><br> <b>Figura 1:</b> Esempio n = 3 con un <b>Delegate</b> disonesto.</p>

  Nella **Figura 1**, abbiamo un singolo **Delegato** leale (50%). Entrambi i **Delegati** ricevono lo stesso messaggio dallo **Speaker** onesto. Tuttavia, a causa della disonestá di un **Delegato**, il Delegato onesto puó solo determinare che esiste un nodo disonesto, ma non é in grado di identificare se si tratti del creatore del blocco (lo **Speaker**) o del **Delegato**. Per questo motivo, il **Delegato** deve astenersi dal voto, cambiando la View.

  <p align="center"><img src="/assets/n4.png" width="400"><br> <b>Figura 2:</b> Esempio n = 4 con un <b>Delegate</b> disonesto.</p>

  Nella **Figura 2**, abbiamo due **Delegati** leali (66%). Tutti i **Delegati** ricevono lo stesso messaggio dallo **Speaker** onesto e inviano il loro risultato di convalida insieme al messaggio ricevuto dallo Speaker ad ogni **Delegato**. Sulla base del consenso dei due **Delegati** onesti, siamo capaci di determinare che nel sistema lo **Speaker** o il **Delegato** a destra sono disonesti. 

  

### **Speaker Disonesto** 

  <p align="center"><img src="/assets/g3.png" width="300"><br> <b>Figura 3:</b> Esempio n = 3 con uno <b>Speaker</b> disonesto. </p>

  Nel caso della **Figura 3**, dello **Speaker** disonesto, abbiamo una conclusione identica a quella raffigurata nella **Figurea 1**. Nessun **Delegato** é capace di determinare quale nodo sia disonesto.

  <p align="center"><img src="/assets/g4.png" width="400"><br> <b>Figura 4:</b> Esempio n = 4 con uno <b>Speaker</b> disonesto. </p>

  Nell'esempio posto dalla **Figura 4**, i blocchi ricevuti dal nodo centrale e dal nodo destro non sono validabili. Ció li induce a differire per una nuova View che elegge un nuovo **Speaker** poiché essi hanno la maggioranza del 66%. In questo esempio, se lo **Speaker** disonesto aveva inviato dati onesti ai due dei tre **Delegati**, sarebbe stato convalidato senza la necessitá di un cambio di View.


## 5 - Implementazioni Pratiche

L'implementazione pratica del DBFT in NEO avviene tramite un metodo di consenso iterativo per poter garantire che il consenso venga realizzato. Le performance dell'algoritmo dipendono dalla frazione dei nodi onesti nel sistema. La **Figura 5** raffigura le iterazioni previste in funzione della frazione dei nodi disonesti.

Nota che la **Figura 5** non si estende al di sotto del 66.66% di onestá dei **Nodi di Consenso**. Tra questo punto critico e il 33% di onestá dei **Nodi di Consenso**, c'é 'la terra di nessuno' dove il consenso é irragiungibile. Sotto il 33% di onestá dei **Nodi di Consenso**, i nodi disonesti (assumendo che siano allineati nel consenso) sono capaci di raggiungere il consenso da soli e di diventare un nuovo punto di veritá nel sistema.

<img src="/assets/consensus.iterations.png" width="800">

**Figura 5:** Simulazione Monto-Carlo dell'algoritmo DBFT raffigurante le iterazioni necessarie per raggiungere il consenso. {100 Nodi; 100,000 Blocchi simulati con una selezione casuale dei nodi onesti}


### 5.1 - Definizioni

**All'interno dell'algoritmo, definiamo quanto segue:**

  - `t`: Quantitá di tempo allocata per la generazione di un blocco, misurata in secondi.
    - Correntemente: `t = 15 secondi`
    - Questo valore puó essere usato per approssimare il tempo di una singola iterazione View poiché l'attivitá di consenso e gli eventi di comunicazione sono veloci rispetto a questa costante di tempo. 
  - `n`: Il numero di **Nodi di Consenso** attivi.

  - `f`: La soglia minima di **Nodi di Consenso** difettosi all'interno del sistema. 
     - `f = (n - 1) / 3`

  - `h` : L'altezza del blocco corrente durante l'attivitá di consenso.

  - `i` : Indice dei **Nodi di Consenso**.


  - `v` : La View di un **Nodo di Consenso**. La View contiene le informazioni aggregate che i nodi hanno ricevuto durante il round di consenso. Questa include il voto (`prepareResponse` o `ChangeView`) emesso da tutti i Delegati.


  - `k` : L'indice della View `v`. Un'attivitá di consenso puó richiedere round multipli. In caso del fallimento del consenso, `k` é incrementato e un nuovo round di consenso comincia.


  - `p` : Indice del **Nodo di Consenso** eletto come **Speaker**. Questo meccanismo di calcolo per questo indice ruota tra i **Nodi di Consenso** in modo da prevenire che un singolo nodo agisca da dittatore all'interno del sistema. 
     - `p = (h - k) mod (n)`


  - `s`: La soglia sicura di consenso. Al di sotto di questa soglia, la rete é esposta a guasti.  
     - `s = ((n - 1) - f)`


### 5.2 - Requisiti

**All'interno di NEO, ci sono tre principali requisiti per la tolleranza ai guasti del consenso:**

1. `s` **Delegati** devono raggiungere il consenso su una transazione prima che un blocco possa essere impegnato. 

2. I **Nodi di Consenso** disonesti non devono essere capaci di persuadere i Nodi di Consenso onesti con transazioni falsate. 

3. Almeno `s` **Delegati** sono nello stesso stato (`h`,`k`) per iniziare un'attivitá di consenso.



### 5.3 - Algoritmo
**L'algoritmo funziona come segue:**

1. Un **Nodo di Consenso** trasmette all'intera rete una transazione con la firma del mittente.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Figura 6:</b> Un <b>Consensus Node</b> riceve una transazione e la trasmette al sistema. </p>

2. I **Nodi di Consenso** registrano i dati della transazione nella memoria locale.

3. La prima View `v` dell'attivitá di consenso é inizializzata.

4. Viene identificato **Speaker**. **Attende** `t` secondi.
<p align="center"><img src="/assets/consensus2.png" width="450"><br/> <b>Figura 7:</b> Uno <b>Speaker</b> é stato identificato e la View inviata.</p>

5. Lo **Speaker** trasmette la proposta : `<prepareRequest, h, k, p, bloc, [block]sigp>`

     <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Figura 8:</b> Lo <b>Speaker</b> conia una proposta di blocco per la revisione da parte dei <b>Delegati</b>. </p>

6. I **Delegati** ricevono la proposta da confermare:

    - Il formato dei dati è coerente con le regole del sistema?
    - La transazione è già sulla blockchain?
    - Gli script del contratto sono eseguiti correttamente?
    - La transazione contiene solo una singola spesa?(es. la transazione evita uno scenario di doppia spesa?)
    - **Se la trasmissione proposta convalidata:**  `<prepareResponse, h, k, i, [block]sigi>`
    - **Se la proposta invalidata trasmessa:**  `<ChangeView, h,k,i,k+1>`

   <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Figura 9:</b> I <b>Delegati</b> rivedono la proposta del blocco e rispondono </p>

7. Dopo aver ricevuto `s` numeri di 'prepareResponse' trasmessi, un **Delegato** realizza il consenso e pubblica un blocco.

8. I **Delegati** firmano il blocco.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Figura 10:</b> Il consenso é realizzato e approvato, i <b>Delegati</b> firmano il blocco legandolo alla chain. </p>

9. Quando un **Nodo di Consenso** riceve un blocco completo, la View corrente viene "ripulita", e un nuovo round di consenso comincia. 
  - `k = 0`

---

**Nota:**

 Se dopo (![timeout](/assets/consensus.timeout.png) )  secondi sulla stessa View senza consenso:
  - Il **Nodo di Consenso** Trasmette:

  <!-- -->
      <ChangeView, h,k,i,k+1>

  - Una volta che un **Nodo di Consenso** riceve almeno `s` numeri di trasmissioni che denotano lo stesso cambio di View, incrementa la View `v`, attivando un nuovo round di consenso.


​	

## 6 - Riferimenti
1. [Un Byzantine Fault Tolerance Algorithm per Blockchain](whitepaper.md)
2. [Byzantine Fault Tolerance pratico](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [Il Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)

