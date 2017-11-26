# Konsensmechanismus

## 1 - Begrifflichkeiten

* **Proof of Stake** `PoS` - Ein Algorithmus, der Fehlertoleranz über einen Netzwerkkonsens erreicht.

* **Proof of Work** `PoW` - Ein Algorithmus, der Fehlertoleranz über Rechenpower erreicht.

* **Byzantine Fault** `BF` - Ein Fehler, bei dem eine funktionierende Node unehrlich agiert.

* **Delegated Byzantine Fault Tolerance** `DBFT` - Ein Konsensalgorithmus, der in der NEO Blockchain eingesetzt wird, um Fehlertoleranz zu gewährleisten

* **View** `v` - Der Datensatz, der während der Konsensbildung in  NEO `DBFT` genutzt wird

## 2 - Rollen
**Im NEO Konsensalgorithmus werden Consensus Nodes von NEO Haltern gewählt und entscheiden über die Gültigkeit von Transaktionen. Die Consensus Nodes wurden früher "Bookkeepers" genannt**.

  - <img style="vertical-align: middle" src="/assets/nNode.png" width="25"> **Consensus Node** - Diese Node nimmt an der Konsensfindung teil. An der Konsensfindung nehmen Consensus Nodes in einer der folgenden zwei Rollen  teil:
  - <img style="vertical-align: middle" src="/assets/speakerNode.png" width="25"> **Speaker** `(Eine Node)` - Der **Speaker** sendet einen Blockvorschlag an das System.
  - <img style="vertical-align: middle" src="/assets/cNode.png" width="25"> **Delegate** `(die restlichen Nodes)` - **Delegates** sind dafür verantwortlich, Konsens für die Transaktion zu finden.


## 3 - Einführung

Einer der größten Unterschiede zwischen Blockchains ist der Mechanismus, mit dem Fehlertoleranz im Falle fehlerhafter oder nicht-ehrlicher Aktivität im Netzwerk gewährleistet wird.

Ältere Methoden wie z.B. PoW können dies garantieren, so lange die Mehrheit der Rechenpower des Netzwerks ehrlich ist.  Da dieses System aber höchst inneffizient ist (Rechenpower kostet Energie und Hardware), gibt es viele Grenzen, die diesen Mechanismus limitieren.

NEO implementiert einen 'Delegated Byzantine Fault Tolerance' Konsensalgorithmus, welcher die Vorteile von PoS (NEO Halter wählen **Consensus Nodes**) und das Netzwerk vor **Byzantine Faults** mit minimalen Ressourcen schützt, während er einige der Schwächen von PoS abschafft. Diese Lösung schafft Performance und Skalierbarkeit ohne signifikant in die Fehlertoleranz einzugreifen.



## 4 - Theorie

Das Problem des "Byzantinischen Generals" ist ein klassisches Problem im verteilten Rechnen. Das Problem definiert eine Anzahl von **Delegates**, die alle einen Konsens über eine Order des **Speakers** erreichen müssen. In diesem System kann sowohl der **Speaker** als auch eine beliebige Anzahl von **Delegates** verräterisch sein. Eine unehrliche Node sendet möglicherweise keine konsistente Nachricht an jeden Empfänger. Die Lösung des Problems erfordert, dass die **Delegates** angeben, ob der **Speaker** ehrlich ist und was die eigentliche Order als Gruppe war.

Um zu beschreiben wie dBFT funktioniert, konzentrieren wir uns in diesem Abschnitt hauptsächlich auf die Begründung der in Abschnitt 5 verwendeten Konsensrate von 66,66%.  Bitte beachten Sie, dass eine unehrliche Node nicht bösartig sein muss. Es kann auch ein einfacher Fehler vorliegen.

Es werden einige Szenarien diskutiert, in denen wir davon ausgehen, dass jede Node die Nachricht sendet, die er vom **Speaker** erhalten hat. Dieser Mechanismus wird auch in dBFT verwendet und ist für das System wichtig. Wir werden dabei nur den Unterschied zwischen einem funktionalen und einem disfunktionalen System beschreiben. Eine ausführlichere Erklärung finden Sie in den Verweisen.



### **Ehrlicher Speaker**

  <p align="center"><img src="/assets/n3.png" width="300"><br> <b>Abb. 1:</b> Ein n = 3 Beispiel mit einem unehrlichen <b>Delegate</b>.</p>

  In **Abb. 1** haben wir nur einen loyalen **Delegate** (50%). Beide **Delegates** haben die gleiche Nachricht vom **Speaker** erhalten. Weil ein **Delegate** unehrlich ist, kann der ehrliche **Delegate** nur feststellen, dass es eine unehrliche Node gibt, aber ist nicht in der Lage, festzustellen ob es der **Speaker** oder der **Delegate** ist. Deshalb muss der **Delegate** sich seiner Stimme enthalten und die View ändern.

  <p align="center"><img src="/assets/n4.png" width="400"><br> <b>Abb. 2:</b> Ein n = 4 Beispiel mit einem unehrlichen <b>Delegate</b>.</p>

  In **Abb. 2** gibt es zwei loyale **Delegates** (66%): Alle **Delegates** haben die gleiche Nachricht vom ehrlichen **Speaker** erhalten und senden ihr Validierungsergebnis zusammen mit der Nachricht des **Speaker** zu jedem **Delegate**. Aufgrund des Konsens zwischen den beiden **Delegates** sind wir in der Lage zu ermitteln, dass entweder der **Speaker** oder der rechte **Delegate** unehrlich ist.
  


### **Unehrlicher Speaker** 

  <p align="center"><img src="/assets/g3.png" width="300"><br> <b>Abb. 3:</b> Ein n = 3 Beispiel mit einem unehrlichen <b>Speaker</b>. </p>

  Im Fall von **Abb. 3** mit einem unehrlichen **Speaker** kommen wir zu dem gleichen Schluss wie in **Bild 1**. Kein **Delegate** ist in der Lage zu bestimmen, welche Node unehrlich ist.

  <p align="center"><img src="/assets/g4.png" width="400"><br> <b>Abb. 4:</b> Ein n = 4 Beispiel mit einem unehrlichen <b>Speaker</b>. </p>

 Im Beispiel in **Abb. 4** sind die Blocks, die die rechte und die mittlere Node erhalten, nicht validierbar. Dies sorgt dafür, dass sie die View ändern und somit einen neuen **Speaker** wählen, weil sie eine Mehrheit von 66% tragen. Wenn in diesem Beispiel der unehrliche **Speaker** ehrliche Daten an zwei der drei **Delegates** gesendet hätte, wäre der Block ohne Änderung der View validiert worden.


## 5 - Praktische Implementierung

Die praktische Umsetzung von dBFT in NEO verwendet eine iterative Konsensmethode, um den Konsens zu bilden. Die Leistung des Algorithmus hängt vom Antei der ehrlichen Nodes ab. **Abb. 5** zeigt die erwarteten Iterationen als eine Funktion des Anteils unehrlicher Nodes. 

Beachten Sie, dass **Abb. 5** nicht unter 66,66% Consensus Node Ehrlichkeit geht. Zwischen diesem kritischen Punkt und einer Ehrlichkeit von 33% der **Consensus Nodes** gibt es ein "Niemandsland", in dem ein Konsens unerreichbar ist. Unterhalb von 33,33% der Consensus Nodes ist ein Angriff auf das Netzwerk denkbar, wenn die anderen 66,66% der Nodes einen unehrlichen Konsens und somit eine neue Wahrheit bilden.

<img src="/assets/consensus.iterations.png" width="800">

**Abb. 5:** Monto-Carlo Simulation des dBFT Algorithmus, die die Iterationen darstellt, die erforderlich sind um einen Konsens zu erreichen. {100 Nodes, 100.000 simulierte Blöcke mit zufälliger ehrliche Nodeauswahl}


### 5.1 - Definitionen

**Innerhalb des Algorithmus definieren wir folgendermaßen:**

  - `t`: Die Zeit, die für die Blockgenerierung vorgesehen ist in Sekunden.
    - Aktuell: `t = 15 seconds`
    - Dieser Wert kann genutzt werden, um die Dauer einer einzelnen View-Iteration grob vorherzusehen, da die Konsensaktivität und die Kommunikationsereignisse relativ zu dieser Zeitkonstante vernachlässigbar sind.

  - `n`: Die Anzahl aktiver **Consensus Nodes**

  - `f`: Die Mindestschwelle für fehlerhafte **Consensus Nodes** im System
     - `f = (n - 1) / 3`

  - `h` : Die aktuelle Blockhöhe

  - `i` : **Consensus Node** Index

  - `v` : Die View einer **Consensus Node**.  Die View enthält die Gesamtheit an Informationen, die die Node während einer Konsensrunde erhalten hat. Dies beinhaltet die Abstimmung (`prepareResponse` or `ChangeView`) die von allen **Delegates** ausgegeben wird.

  - `k` : Der Index der View `v`. Eine Konsensbildung kann mehrere Konsensrunden benötigen. Beim Konsensversagen wird `k` erhöht und eine neue Konsensrunde beginnt. 

  - `p` : Index der **Consensus Node**, die zum **Speaker** gewählt wurde.  Der Mechanismus für diesen Index rotiert durch einzelne **Consensus Nodes**, um zu verhindern, dass ein einzelner Knoten als Diktator innerhalb des Systems fungiert.
     - `p = (h - k) mod (n)`

  - `s`: Die sichere Konsensschwelle. Unterhalb dieser Schwelle ist das Netzwerk Fehlern ausgesetzt.
     - `s = ((n - 1) - f)`


### 5.2 - Anforderungen

**Innerhalb NEO gibt es drei Hauptanforderungen an die Konsensfehlertoleranz:**

1. `s` **Delegates** müssen einen Konsens über eine Transaktion erreichen, bevor ein neuer Block generiert werden kann.

2. Unehrliche **Consensus Nodes** dürfen die ehrlichen Nodes nicht von fehlerhaften Transaktionen überzeugen dürfen. 

3. Mindestens `s` **Delegates** sind im gleichen Zustand (`h`,`k`) um eine Konsensbildung zu beginnen



### 5.3 - Algorithmus
**Der Algorithmus funktioniert folgendermaßen:**

1. Eine **Consensus Node** sendet eine Transaktion mit den Signaturen des Senders an das gesamte Netzwerk.

   <p align="center"><img src="/assets/consensus1.png" width="450"><br> <b>Abb. 6:</b> A <b>Consensus Node</b> empfängt eine Transaktion und sendet sie ans System </p>

2. **Consensus Nodes** protokollieren die Transaktionsdaten im lokalen Speicher:

3. Die erste View `v` der Konsensbildung wird gestartet.

4. Der **Speaker** wird gewählt. **Warte** `t` Sekunden.
<p align="center"><img src="/assets/consensus2.png" width="450"><br/> <b>Abb. 7:</b> Ein <b>Speaker</b> wurde gewählt und die View wurde festgelegt</p>

5. Der **Speaker** sendet Vorschlag : `<prepareRequest, h, k, p, bloc, [block]sigp>`

     <p align="center"><img src="/assets/consensus3.png" width="450"><br> <b>Abb 8:</b> Der <b>Speaker</b> erstellt seinen Blockvorschlag für die Überprüfung durch die <b>Delegates</b>. </p>

6. Die **Delegates** erhalten den Vorschlag und validieren:

    - Ist das Datenformat konsistent zu den Systemregeln?
    - Gibt es diese Transaktion bereits auf der Blockchain?
    - Sind die Contractskripe richtig ausgeführt worden?
    - Enthält die Transaktion nur einen 'single spend'? (Gibt es keine 'double spend' Transaktion?)
    - **Wenn der Vorschlag validiert wird:**  `<prepareResponse, h, k, i, [block]sigi>`
    - **Wenn der Vorschlag nicht validiert wird:**  `<ChangeView, h,k,i,k+1>`

   <p align="center"><img src="/assets/consensus4.png" width="500"><br> <b>Abb. 9:</b> Die <b>Delegates</b> überprüfen den Vorschlag und antworten </p>

7. Nachdem er die Anzahl `s` von 'prepareResponse' Nachrichten erhalten hat, erreicht der **Delegate** Konsens und veröffentlicht den Block.

8. Die **Delegates** signieren den Block.

   <p align="center"><img src="/assets/consensus5.png" width="500"><br> <b>Abb. 10:</b> Der Konsens ist erreicht und zustimmende <b>Delegates</b> signieren den Block und hängen ihn an die Blockchain </p>

9. Wenn eine **Consensus Node** einen vollen Block erhält, wird die aktuelle View gelöscht und eine neue Konsensbildung beginnt.
    - `k = 0`

---

**Anmerkung:**

Wenn die **Consensus Node** sich nach (![timeout](/assets/consensus.timeout.png) ) Sekunden in der selben View ohne Konsens befindet, sendet sie:

  <!-- -->
      <ChangeView, h,k,i,k+1>

  - Sobald eine **Consensus Node** mindestens die Anzahl `s` an Nachrichten erhält, die die gleiche Viewänderung ankündigen, ändert sie die View `v` und startet eine neue Konsensrunde.



## 6 - Verweise
1. [Der 'Byzantine Fault Tolerance' Algorithmus für Blockchains](whitepaper.md)
2. [Practical Byzantine Fault Tolerance](http://pmg.csail.mit.edu/papers/osdi99.pdf)
3. [The Byzantine Generals Problem](https://www.microsoft.com/en-us/research/wp-content/uploads/2016/12/The-Byzantine-Generals-Problem.pdf)
