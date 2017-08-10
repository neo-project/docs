# NeoContract White Paper


## 1.	Einführung

Smart Contracts sind Computerprogramme, die automatisch die Vereinbarungen eines vorprogrammierten Vertrags ausführen können. Das Konzept des Smart Contracts ist ungefähr so alt wie das Internet selbst und wurde erstmals 1994 von dem Kryptografen Nick Szabo vorgestellt. Aufgrund eines Mangels an zuverlässigen Abwicklungsumfeldern wurden Smart Contracts bis jetzt noch kaum benutzt. 

Im Jahre 2008 veröffentlichte eine Person unter dem Namen Satoshi Nakamoto “Bitcoin“ und skizzierte das grundlegende Konzept der Blockchain. Innerhalb der Bitcoinblockchain benützt Nakamoto ein Set von Skriptsprachen um den Nutzern erhöhte Flexibilität bei der Kontrolle über ihr persönliches Konto und beim Transferprozess zu bieten. Im Prinzip stellte dies die erste Embryoform eines chain-based Smart Contract Systems dar. 

Im Jahre 2014 veröffentlichte ein Teenager namens Vitalik Buterin „Ethereum“, ein chain-based, Turing-vollständiges Smart Contract System, das für die Entwicklung einer Vielfalt an dezentralisierten Blockchain Anwendungen benützt werden kann.

Die NEO Blockchain ist eine digitale Asset- und Anwendungsplattform, die unter anderem ein neues Smart Contract System mit dem Namen NeoContract enthält. Der Kern der NEO Plattform bietet eine Vielzahl an Funktionen wie in etwa Ressourcen für digitale Assets (NeoAsset) oder für digitale Identität (NeoID), die es Nutzern auf einfache Art und Weise ermöglichen am digitalen Business teilzunehmen, und die nicht mehr ausschließlich auf die bloße Emission von blockchaineigene Token limitiert ist. 

Dieser Artikel stellt die Funktionen von NeoCotnract vor und erforscht die nicht-technischen Details. Für technische Dokumentationen und Details verweisen wir auf docs.neo.org

## 2.	Funktionen 

### 2.1 Gewissheit

Eine Anwendung wird dann als deterministisch bezeichnet, wenn sie auf verschiedenen Computern, oder zu verschiedenen Zeitpunkten auf demselben Computer ausgeführt werden kann und dabei derselbe Input immer exakt den selben Output erzeugt.  

Blockchain ist ein Mehrparteienspeicherungsystem und eine Berechnungsmethode. Die Daten innerhalb dieses dezentralisierten Systems sind das Resultat von vertrauenswürdigen Kalkulationen, die nicht verfälscht werden können. Smart Contracts operieren innerhalb eines dezentralisierten, multi-node Blockchain Netzwerk. Im Falle von nicht-deterministischen Smart Contracts sind die Ergebnisse von verschiedenen Nodes womöglich ebenfalls inkonsistent. Das führt dazu, dass zwischen den Nodes kein Konsens erreicht werden kann und das Netzwerk dadurch stagniert. Aus diesem Grund verlangt das Design eines Smart Contract Systems die bestmöglichste Prävention von Faktoren, die zu nicht-deterministischem Verhalten führen könnten. 


#### 2.1.1 Zeit

System-Zeit zu erlangen ist eine sehr übliche Systemfunktion, die besonders intensiv bei entsprechenden zeitsensitiven Smart Contract Prozeduren angewandt werden könnte. System-Zeit zu erlangen ist jedoch eine nicht-deterministische Systemfunktion. Es gestaltet sich schwierig eine einheitliche, präzise Zeit in einem dezentralisierten System zu erlangen, da die Resultate der verschiedenen Nodes inkonsistent sein werden. NeoContract bietet einen Block-basierten System-Call, der die gesamte Blockchain als Zeitstempel-Server behandelt und der dabei den Zeitstempel immer dann erhält, wenn ein neuer Block generiert wurde. Im Durchschnitt wird im NEO Netzwerk alle 15 Sekunden ein neuer Block erschaffen, somit läuft der Contract plus-minus 15 Sekunden zur selben Zeit wie die letzte Block-Zeit. 

#### 2.1.2. Zufälligkeit

Viele Smart Contract Anwendungen wie in etwa Glücksspiel Contracts und kleine Spiele nützen Zufallszahlenfunktionen. Diese Zufallszahlenfunktionen zählen allerdings zu typischen nicht-deterministischen Funktionen, denn jeder System-Call kommt zu einem anderen Ergebnis. In einem dezentralisierten System gibt es mehrere Möglichkeiten dieses Problem zu adressieren: Es könnte derselbe Zufallsseed für alle Nodes verwendet werden, sodass die erhaltene Sequenz der gesamten Zufallsfunktion deterministisch ist. Diese Methode gibt jedoch das gesamte zufallsgenerierte Resultat bereits im Vorhinein preis und reduziert somit drastisch den praktischen Nutzen des Zufallsprodukts. Eine andere mögliche Lösung wäre der Versuch durch kollaborative Kommunikation aller Nodes Zufallsprodukte zu generieren. Dies kann mit Hilfe kryptografischer Techniken die auf die Generierung fairer Zufallsprodukte abzielen erreicht werden. Der Nachteil dabei liegt in der äußerst schlechten Performance und der Notwendigkeit für zusätzliche Kommunikation. Ein zentralisierter Provider für Zufallszahlen könnte verwendet werden, um Konsistenz und Performance zu garantieren. Die Kehrseite dieser Methode ist augenscheinlich: Die Nutzer müssen bedingungslos dem zentralen Provider vertrauen. 

In NEO gibt es zwei Möglichkeiten für die Generierung einer Zufallszahl: 1) Jedes Mal wenn ein Block generiert wird, erreicht die Konsensnode Konsens bezüglich einer Zufallszahl und füllt diese in das Nonce Feld des neuen Blocks. Mittels Bezugnahme auf dieses Nonce Feld kann der Contract auf einfache Art und Weise die Zufallszahl jedes Blocks einholen. 2) Der Contract kann den Hashwert eines Blocks als Zufallszahlgenerator verwenden, denn dieser besitzt von Natur aus gewisse Zufälligkeit. Diese Methode kann für die Erlangung schwacher Zufallszahlen verwendet werden. 

#### 2.1.3 Datenquellen

Ein Programm das während der Laufzeit Daten einholt ist dann nicht-deterministisch, wenn die Datenquelle das Programm mit nicht-deterministischen Daten versorgt. Ein Beispiel hierfür wäre der Einsatz verschiedener Suchmaschinen für die Einholung der Top 10 Suchergebnisse für ein bestimmtes Keyword. Beim Einsatz verschiedener IP Adressen könnten verschiedene Suchergebnisse in unterschiedlicher Rangordnung erlangt werden. 

Für Smart Contracts verwendet NEO zwei Arten von deterministischen Datenquellen:

**(1) Blockchain Ledger**

Der Contract kann mittels der interoperablen Services auf die gesamten Daten der Chain, inklusive Blocks und Transaktionen und jedes ihrer Felder, zugreifen. Die Daten auf den Blocks sind deterministisch und konsistent und können somit unbesorgt von Smart Contracts abgerufen werden. 

**(2) Speicherumgebung der Contracts**

Jeder Contract der im NEO Netzwerk eingesetzt wird besitzt eine private Speicherumgebung auf die ausschließlich vom Contract selbst zugegriffen werden kann. Der NEO Konsensmechanismus gewährt die Konsistenz des Speicherstatus von jeder Node im Netzwerk. 

Für den Zugriff auf non-Blockchain Daten bietet NEO keine direkte Möglichkeit. Non-Blockchain Daten müssen zuerst auf die NEO Blockchain transferiert werden und in eine der obengenannten Datenquellen übersetzt werden, damit sie von Smart Contracts abgerufen werden können. 

#### 2.1.4 Contract Call

In NeoContract haben Smart Contracts die Möglichkeit sich (in nicht rekursiver Weise) aufeinander zu berufen. Rekursion kann innerhalb eines Contracts stattfinden, allerdings nicht darüber hinaus. Darüber hinaus muss die Beziehung zwischen den Contracts von statischer Natur sein: Das Ziel kann während der Laufzeit nicht spezifiziert werden. Dies ermöglicht der Anwendung vor ihrer Ausführung vollkommen determiniert zu sein, und ihrer Call-Beziehung vollkommen definiert zu sein. Darauf basierend können multiple Verträge dynamisch partitioniert werden um parallele Ausführung zu erzielen.

### 2.2 Hohe Performance

Das Ausführungsumfeld von Smart Contracts spielt eine zentrale Rolle in deren Performance. Bei der Analyse der Performance eines Ausführungsumfeldes gibt es zwei kritische Indikatoren: 1) Ausführungsgeschwindigkeit der Anweisung 2) Startup Geschwindigkeit des Ausführungsumfeldes selbst. Bei Smart Contracts spielt meist das Ausführungsumfeld eine größere Rolle als die Ausführungsgeschwindigkeit selbst. Smart Contracts sind mehr in IO Logikoperationen involviert, um die Anweisungen zu determinieren und wobei auch die Implementation dieser Anweisungen einfach optimiert werden können. Bei jedem Aufrufen eines Smart Contracts muss eine neue virtuelle Maschine / Container aufgerufen werden. Aus diesem Grund hat die Ausführungsgeschwindigkeit des Umfeldes (Starten der virtuellen Maschine / Container) einen höheren Einfluss auf die Performance des Smart Contract Systems.

NEO verwendet die schlanke NeoVM (NEO Virtual Machine) als ihr Smart Contract Ausführungsumfeld. Die NeoVM besitzt hohe Startgeschwindigkeit und benötigt kaum Ressourcen, was ideale Bedingungen für kleine Anwendungen wie Smart Contracts bietet. Die Nutzung von Compilation und Caching von Hotspot Smart Contracts mit JIT (Echtzeit Compilers) kann die Effizienz von virtuellen Maschinen signifikant erhöhen.  

### 2.3 Skalierbarkeit

#### 2.3.1 Hohe Nebenläufigkeit und dynamische Partitionierung

Die Diskussion bezüglich der Skalierbarkeit behandelt grundlegend zwei verschiedene Arten: die vertikale Skalierung und die horizontale Skalierung. Die vertikale Skalierung ist die Optimierung des Prozessworkflows, die es dem System erlaubt die Kapazität des vorhandenen Equipments maximal auszunützen. Bei diesem Ansatz werden die Grenzen des Systems rasch ausgeschöpft, da serienbasierte Prozesskapazität von dem Hardwarelimit des einzelnen Geräts abhängt. Gibt es bezüglich der Skalierung eines Systems eine Möglichkeit ein Seriensystem in ein Parallelsystem umzuwandeln? Theoretisch müsste man lediglich die Anzahl der Geräte erhöhen und man erreicht nahezu unbegrenzte Skalierbarkeit. Kann völlig unbeschränkte Skalierbarkeit in einem dezentralisierten Blockchain Netzwerk erreicht werden? In anderen Worten: Kann die Blockchain Anwendungen parallel ausführen?

Die Blockchain ist eine dezentralisierte Datenbank. Sie enthält eine Vielzahl von Zustandsdaten und dazugehörige Regeln, die über etwaige Veränderungen dieser Daten bestimmen. Smart Contracts werden als Medium verwendet, das mit bestimmten Regeln ausgestattet ist und diese ausführt. Blockchains können Anwendungen nur dann parallel abwickeln, wenn mehrere Smart Contracts gleichzeitig und in nicht sequentieller Manier ausgeführt werden können. Grundlegend ist die Ausführung nicht sequentiell, wenn die Contracts nicht miteinander interagieren und sie nicht dieselben Daten zur selben Zeit modifizieren. In diesem Fall können sie gleichzeitig ausgeführt werden. Sind die genannten Bedingungen nicht erfüllt, können sie lediglich sequentiell bzw. seriell ausgeführt werden und das Netzwerk ist somit nicht horizontal skalierbar. 

Basierend auf dieser Analyse können wir ohne Umstände unlimitierte Skalierbarkeit in Smart Contract Systeme implementieren. Dafür müssen lediglich folgende simple Regeln festgelegt werden:

(1) Ein Smart Contract kann ausschließlich die Zustandsdaten des Contracts zu dem er zugehörig ist verändern.

(2) Ein Contract kann in ein und derselben Transaktion-Batch (Block) nur einmal ausgeführt werden.

Folglich können Smart Contracts parallel abgewickelt werden, da sequentielle Ordnung irrelevant für das Resultat ist. Durch die Bedingung „Ein Smart Contract kann ausschließlich die Zustandsdaten des Contracts zu dem er zugehörig ist verändern“ wird allerdings impliziert, dass Contracts sich nicht aufeinander beziehen können. Jeder Contract ist bildlich gesprochen eine isolierte Insel. Die Bedingung „Ein Contract kann in ein und derselben Transaktion-Batch (Block) nur einmal ausgeführt werden“ impliziert, dass ein digitales Asset das durch einen Smart Contract emittiert wird lediglich eine Transaktion pro Block handhaben kann. Dies steht allerdings in krassem Kontrast zu der ursprünglichen Ideologie von Smart Contracts. Immerhin inkludieren die designierten Ziele von NEO sowohl die mögliche Interaktion zwischen Smart Contracts als auch die mehrfache Ausführung desselben Aufrufs, im selben Block. 

Erfreulicherweise stehen Smart Contracts in NEO in einer statischen Call-Beziehung und das Call-Ziel kann nicht während der Laufzeit spezifiziert werden. Dies ermöglicht dem Programm völlig deterministisches Verhalten und eine vollständig definierte Call-Beziehung bereits vor der Ausführung. Ein Erfordernis hierfür ist, dass jeder Contract explizit kenntlich macht, welche Contracts aufgerufen werden sollen, damit die Anwendungsumgebung den vollständigen Aufrufbaum vor der Ausführung kalkulieren kann und basierend darauf die Durchführung der Contracts partitionieren kann. Contracts die womöglich denselben Zustandsdatensatz modifizieren, werden sequentiell in derselben Partition durchgeführt. Unterschiedliche Partitionen können damit parallel durchgeführt werden. 

#### 2.3.2 Niedrige Kopplung

Die Kopplung ist ein Maß für die Abhängigkeit zwischen zwei oder mehr Einheiten. Das NeoContract System verwendet ein Design mit niedriger Kopplung, welches in der NeoVM ausgeführt wird und das mittels der interoperablen Services mit non-Blockchain Daten kommuniziert. Das bedeutet, dass Upgrades der Smart Contract Funktionalität zu einem großen Teil mittels Verbesserung der API der interoperablen Services erreicht werden können. 

## 3.	Contract Einsatz

### 3.1 Verifikations-Contract

Im Gegensatz zu dem Public-Key-Accountsystem das Bitcoin benützt verwendet NEO ein Contract-Accountsystem.  Jeder Account in NEO korrespondiert mit einem Verifikations-Contract. Der Hashwert in diesem Verifikations-Contract ist die Accountadresse. Die Programmlogik des Verifikations-Contracts regelt das Besitztum eines Accounts. Vor jedem Transfer der von einem Account ausgeführt wird, muss zuerst der Verifikations-Contract für diesen Account ausgeführt werden. Ein Verifikations-Contract akzeptiert ein Set von verschiedenen Parameter (im Normalfall eine digitale Signatur o.ä.) und retourniert nach erfolgter Verifikation einen booleschen Wert, der dem System die erfolgreiche Verifikation kommuniziert. 

Der Benutzer kann den Verifikations-Contract im Vorhinein der Blockchain bereitstellen, oder den Vertragsinhalt direkt in der Transaktion während dem Transferprozess veröffentlichen. 

### 3.2 Anwendungs-Contract

Der Anwendungs-Contract wird von einer speziellen Transaktion ausgelöst, die während der Laufzeit auf die globale und die private (Speicherumgebung) Beschaffenheit des Systems zugreifen und sie verändern kann. Zum Beispiel kann während der Vertragslaufzeit ein globales digitales Asset in einem Vertrag erstellt werden, gewählt werden, Daten gespeichert werden und sogar auf dynamische Art und Weise ein neuer Vertrag erstellt werden.

Die Ausführung eines Anwendungs-Contract erfordert die Bezahlung von Gebühren. Bei Ausbleiben der Gebühren schlägt der Contract fehl und die Ausführung wird gestoppt. Alle vorgenommenen Veränderungen werden rückgängig gemacht. Das Gelingen des Contracts hat keinen Einfluss auf die Gültigkeit der Transaktion. 

### 3.3 Funktions-Contract

Der Funktions-Contract wird für die Bereitstellung von allgemeinen bzw. vielgenutzten Funktionen, die von anderen Contracts aufgerufen werden können, genutzt. Der Smart Contract Code kann wiederverwendet werden und Entwickler können somit immer komplexer werdende Businesslogik schreiben. Jeder Funktionskontrakt kann sich bei seiner Bereitstellung für den Besitz einer privaten Speicherumgebung entscheiden, die in die Daten eines zukünftigen Contracts eingeschrieben wird, womit erhöhte Beständigkeit der Beschaffenheit geschaffen wird. 

Der Funktions-Contract muss der Chain vorab zur Verfügung gestellt werden damit er aufgerufen werden kann. Von der Chain entfernt wird ein Contract mittels eines Selbstzerstörungsmechanismus der auch die private Speicherumgebung löscht. Per Migrationstools können Contract Daten vor ihrer Zerstörung automatisch auf einen anderen Subcontract migriert werden. 

## 4.	Virtuelle Maschine

### 4.1 Virtuelle Hardware

NeoVM besitzt eine Ebene für virtuelle Hardware, um die Ausführung von Smart Contracts zu unterstützen:

**(1) CPU**

Der CPU ist zuständig für das Lesen und die sequentielle Ordnung der Ausführung von Anweisungen im Vertrag in Abhängigkeit vom Steuerfluss der Anweisungen, arithmetischen Operationen und Logikoperationen. Die Funktionalität des CPU kann zudem erweitert werden, beispielweise durch die Implementierung von JIT (Echtzeit Compiler) und die damit verbundene Erhöhung der Ausführungseffizienz von Anweisungen.

**(2) Call Stack**

Das sogenannte Call Stack wird verwendet, um die Kontextinformationen des ausführenden Programms bei jedem Funktionsaufruf beizubehalten, sodass es weiterhin im aktuellen Kontext operieren kann, nachdem die Funktion fertig mit der Ausführung ist. 

**(3) Kalkulation Stack**

Die gesamten Laufzeitdaten der NeoVM sind im Kalkulation Stack gespeichert. Nach der Implementierung verschiedener Anweisungen wird das Stack anhand der korrespondierenden Datenelementen der Operation kalkuliert. Wenn beispielweise zusätzliche Anweisungen ausgeführt werden, werden die Operationen die an dem Zusatz beteiligt sind vom Kalkulation Stack ausgeschlossen. Das Resultat des Zusatzes wird an die Spitze des Stacks geschoben. Call-Funktion Parameter müssen zudem von rechts nach links kalkuliert werden, in Abstimmung mit dem Stack. Nach erfolgreicher Ausführung der Funktion retourniert die Spitze der Stack Fetch-Funktion den Wert.

**(4) Reserve Stack**

Für die Planung oder die Umorganisation des Stacks können temporär Komponenten im Spare Stack gespeichert und später von dort bezogen werden. 

### 4.2 Instruktionen Set

NeoVM bietet ein Set von simplen und praktischen Anweisungen für die Erstellung von Smart Contracts. Die Hauptkategorien gegliedert nach Funktionen lauten wie folgt:

(1)	Daueranweisung

(2)	Prozesssteuerungsanweisung

(3)	Anweisungen für Stack Operationen

(4)	Stringanweisungen

(5)	Logikansweisungen

(6)	Anweisungen für arithmetische Operationen

(7)	Kryptografieanweisungen

(8)	Anweisungen für Datenoperationen 

Es ist zu beachten, dass das NeoVM Instruktion Set eine Reihe von kryptografischen Anweisungen wie in etwa ECDSA, SHA und andere Algorithmen enthält, die die Implementierungseffizienz von kryptografischen Algorithmen bei Smart Contracts optimieren. Zusätzlich unterstützen Anweisungen für Datenveränderungen Arrays und komplexe Datenstrukturen auf direktem Weg.

### 4.3. Interoperable Serviceebene

Die virtuelle Maschine in der Smart Contracts ausgeführt werden ist ein sogenanntes Sandbox Environment, in dem die interoperable Serviceebene benötigt wird, wenn Daten außerhalb der Sandbox verlangt werden und um persistente Laufzeitdaten zu gewährleisten. Innerhalb dieser interoperablen Serviceebene kann NeoContract auf eine Reihe von Systemfunktionen- und Services zugreifen. Diese Contracts können wie gewöhnliche Funktionen aufgerufen und benützt werden. All diese Systemfunktionen werden gleichzeitig ausgeführt und somit kommt es zu keinem Skalierbarkeitsproblem. 

### 4.4 Debugging Funktion

Oftmals gestaltet sich die Entwicklung von Smart Contracts aufgrund eines Mangels an guter Test- und Debuggingmethoden besonders schwierig. NeoV bietet Unterstützung beim Debugging von Anwendungen auf dem Level von virtuellen Maschinen, bei dem Programmstops am Contractcode, oder single-step, single-process Exekutionen gesetzt werden können.
Dank des Designs mit niedriger Kopplung zwischen der virtuellen Maschine und der Blockchain kann die NeoVM problemlos direkt mit einer Vielzahl anderer Entwicklungsumgebungen integriert werden. Dies schafft Konsistenz zwischen dem Testumfeld und dem finalen Entwicklungsumfeld. 

## 5.	High-level Sprachen

### 5.1 C#, VB.Net, F#

NeoContract kann von Entwicklern für nahezu jede high-level Sprache die sie beherrschen verwendet werden. Unter den ersten unterstützten Sprachen befinden sich C#, VB.Net, F# und viele mehr. Wir stellen Compiler und Plug-ins für diese Sprachen zur Verfügung die die Kompilierung dieser high-level Sprachen in das Instruktion Set ermöglichen. Net Sprache kann in MSIL Sprache übersetzt werden und somit direkt unterstützt werden. 

Eine großer Teil der Entwickler sind mit diesen Sprachen vertraut. Diese Sprachen haben außerdem ein sehr solides integriertes Entwicklungsumfeld. Entwickler können in Visual Studio entwickeln, erschaffen, testen und debuggen und die Vorteile der von uns zur Verfügung gestellten Templates für die Smart Contract Entwicklung zur Gänze ausnützen. 

### 5.2 Java, Kotlin

Java und Kotlin bilden die zweite Menge der unterstützten Sprachen, für die wir Compiler und IDE Plugins zur Verfügung stellen, um den Entwicklern die Nutzung von JVM-basierten Sprachen für die Entwicklung von Smart Contracts und Anwendungen zu erleichtern. 
Java ist weitverbreitet und Kotlin wurde erst kürzlich von Google offiziell als die empfohlene Sprache für die Entwicklung auf Android genannt. Wir sind der Überzeugung, dass die Unterstützung dieser Sprachen immens die Anzahl der NEO Smart Contract Entwickler steigern wird. 

### 5.3 Andere Sprachen

Zu einem späteren Zeitpunkt wird NEO andere high-level Sprachen abhängig von ihrem Schwierigkeitsgrad unterstützen. Mögliche Sprachen wären zum Beispiel:

(1)	C, C++, GO

(2)	Python, JavaScript

Mit der Zeit werden wir immer mehr Unterstützung für Sprachen hinzufügen. Unser Ziel ist es, dass mehr als 90% der NEO Entwickler mit NeoContract entwickeln, ohne eine neue Sprache lernen zu müssen und dass sie darüber hinaus die Möglichkeit haben, existierenden Businesssystem Code direkt auf die Blockchain transferieren zu können.

## 6.	Service

### 6.1 Blockchain Ledger

Neo Smart Contracts können mittels der Systemfunktionen, die von den interoperablen Services bereitgestellt werden, während der Laufzeit vollständige Block Daten (inklusive vollständiger Blocks und Transaktionen und ihrer jeweiligen Datenfelder) der NEO Blockchain erlangen. Konkret können folgende Daten abgerufen werden:

(1)	Höhe der Blockchain ;

(2)	Block Head, aktueller Block ;

(3)	Transaktionen ;

(4)	Art der Transaktion, Attribute, Input, Output, etc ;

Anhand dieser Daten können interessante Anwendungen kreiert werden wie zum Beispiel automatische Dividenden oder Smart Contracts auf Basis von „proof of work“.

### 6.2 Digitale Assets

Smart Contracts können nicht bloß Blockchainabfragen über Eigenschaften und Statistiken von digitalen Assets durchführen, sondern mittels der interoperablen Services auch neue digitale Assets während der Laufzeit erschaffen. Digitale Assets, die von Smart Contracts geschaffen wurden, können emittiert, transferiert und  außerhalb des Contracts gehandelt werden. Sie werden gleich behandelt wie originale Assets in NEO und können mit jeder NEO-kompatiblen Wallet-Software gemanagt werden. Das Interface inkludiert:

(1)	Abfrage zu Asset-Eigenschaften ;

(2)	Abfrage zu Asset-Statisiken ;

(3)	Management des Asset Lebenszyklus: Erschaffen, Modifizieren, Löschen, etc ;

(4)	Asset Management: Mehrsprachige Namen, totale Änderungen, Detailänderungen, Änderungen der Administratorenrechte

### 6.3 Beständigkeit

Jeder Smart Contract der an die Blockchain bereitgestellt wird, besitzt eine private Speicherumgebung, die ausschließlich vom Contract selbst gelesen und beschrieben werden kann. Smart Contracts besitzen vollständige Administratorenrechte über die Daten in ihrer eigenen Speicherumgebung: Sie können lesen, schreiben, modifizieren und löschen. Die Daten sind in der Form von key-value Paarungen gespeichert und bieten die folgenden Interfaces:

(1)	Überschreibe alle gespeicherten Datensätze ;

(2)	Gehe zu einem bestimmten Datensatz in Abstimmung mit dem jeweiligen Key ;

(3)	Modifiziere oder erstelle einen neuen Datensatz in Abstimmung mit dem jeweiligen Key 

(4)	Lösche einen bestimmten Datensatz in Abstimmung mit dem jeweiligen Key ;

Generell kann ein Contract nur Daten von der eigenen Speicherumgebung lesen und beschreiben. Eine Ausnahme gilt bei der Aufrufung eines Contracts. Mittels einer cross-domain Anfrage kann der aufgerufene Contract nach erfolgter Genehmigung durch den Aufrufer Zugang zu der Speicherumgebung des Aufrufers erhalten. Zusätzlich gewähren Sub-Contracts, die auf dynamische Weise während der Vertragsausführung erstellt wurden, den Contracts von denen sie abstammen automatisch Zugang zu ihrer Speicherumgebung. 

Cross-domain Anfragen ermöglichen NeoContract die Implementierung von gehaltvollen Bibliothek Ressourcen, die den Aufrufern hoch skalierbare Datenmanagement Ressourcen bieten. 

## 7.	Gebühren

### 7.1 Bereitstellungsgebühr

Die dezentralisierte Architektur von NEO bedeutet hohe Redundanz von Speicherkapazität. Die Nutzung dieser Kapazität ist entgeltlich. Für die Bereitstellung eines Smart Contracts im NEO Netzwerk wird eine Gebühr verrechnet, die momentan auf 500 GAS festgelegt ist und als Systemertrag verbucht wird. Zukünftige Gebühren werden von den tatsächlichen Betriebskosten des Systems abhängig gemacht. Ein einmal bereitgestellter Smart Contract kann solange wiederverwendet werden, bis er vom Bereitsteller gelöscht wird. 

### 7.2 Nutzungsgebühr

NEO bietet ein zuverlässiges Ausführungsumfeld für Smart Contracts und diese Ausführung von Contracts verbraucht Computerressourcen für jede Node. Deshalb müssen User für die Ausführung von Smart Contracts eine Gebühr verrichten. Diese Gebühr (in GAS) ist abhängig von den benötigten Computerressourcen pro Ausführung. Schlägt die Ausführung eines Contracts aufgrund nicht ausreichender GAS-Ressourcen fehl, wird die verbrauchte Menge GAS nicht retourniert, um so etwaige schadhafte Angriffe auf die Energieversorgung des Systems zu verhindern. 

Die meisten einfachen Contracts können unentgeltlich ausgeführt werden, solange ihre Ausführungskosten weniger als 10 GAS betragen. Dies senkt die Kosten für den Nutzer erheblich.

## 8.	Anwendungsszenarien

### 8.1 Supraleitende Transaktionen

Digitale Assets auf der Blockchain benötigen grundlegend ein gewisses Maß an Liquidität. Point-to-point Transaktionen bieten normalerweise nicht ausreichend Liquidität und somit werden Börsen benötigt, die Handel anbieten. Börsen für digitale Assets können grob in zwei Kategorien eingeteilt werden: 1) Zentrale Börsen, bei denen ein User sein digitales Asset hinterlegt und subsequent Gebote abgegeben werden. 2) Dezentralisierte Börsen, wo das Handelssystem in die Blockchain integriert ist und das System die Matchingdienste durchführt. 

Zentralisierte Börsen bieten oftmals äußert hohe Performance und hoch diversifizierte Services, benötigen allerdings hohe Kreditgarantien um „Moral Hazards“ (Veruntreuung, Betrug,etc.) vorzubeugen. Bei dezentralisierten Börsen gibt es zwar keine „Moral Hazards“, dafür ist allerdings das Nutzungserlebnis oft mangelhaft und Leistungsengpässe kommen häufiger vor. Gibt es also eine Möglichkeit des Beste aus beiden Welten zu verbinden?

Supraleitende Transaktionen bieten einen Mechanismus um genau das zu erzielen. Trotz dem Handel auf der Blockchain müssen die User ihre Assets nicht hinterlegen. Transaktionen werden auf der Blockchain durchgeführt, der Prozess des Matchings wird allerdings off-Chain, in etwa von einer zentralen Börse die diese Dienste anbietet, durchgeführt. Trotz Aufrechterhaltung der Kontrolle über die Assets ist die Performance des Matchings ähnlich zu der von zentralisierten Börsen. Börsen verwenden somit den Handelswillen des Users um Matchingdienste durchzuführen, ohne dass „Moral Hazards“ involviert sind. 

Innerhalb der NEO Community hat die Entwicklung von Smart Contracts um supraleitende Transaktionen zu erreichen bereits begonnen, wie man am Beispiel von OTCGO sieht. 

### 8.2 Smart Fund

Smart Funds die auf der Blockchain basieren bieten im Vergleich zu traditionellen Funds Vorteile wie Dezentralisierung, Offenheit und Transparenz und einen höheren Sicherheits- und Freiheitsgrad. Smart Funds sind darüber hinaus grenzübergreifend und offen für Investoren auf der ganzen Welt. Herausragende Projekte können mit Kapital rund um den Globus ausgestattet werden. 

Nest ist ein NeoContract-basiertes Smart Fund Projekt das große Ähnlichkeit zum Ethereum-basierten Projekt TheDAO aufweist. Verbesserte Sicherheitsmaßnahmen sind erforderlich, um den Ereignissen von TheDAO (Hackerangriffe) vorzubeugen. 

### 8.3 Cross-chain Interoperabilität

In naher Zukunft wird es weltweit eine große Anzahl an public-Chains und eine noch größere Anzahl an alliance- und private Chains geben. Diese isolierten Blockchainsysteme sind bildlich gesprochen Inseln voller Wertigkeiten und Informationen die untereinander nicht operabel sind. Durch die cross-chain Interoperabilitätsmechanismen können isolierte Blockchains miteinander verknüpft werden, sodass die Wertigkeiten der verschiedenen Blockchains miteinander ausgetauscht werden können und um somit der Grundidee des Internets gerecht zu werden. 
NeoContract bietet Unterstützung für die Implementation von cross-chain Interoperabilität, die die Konsistenz beim cross-chain Assethandel, bei dezentralisierten cross-chain Transaktionen und bei der Ausführung von Smart Contracts auf verschiedenen Blockchains sicherstellt.  

### 8.4 Orakel Maschinen

Im Volksmund ist ein Orakel eine übernatürliche Einrichtung, die die Fähigkeit besitzt bestimmte Fragen zu beantworten. In der Blockchainwelt öffnet die Orakel Maschine die Tür zur Außenwelt für Smart Contracts und ermöglicht es ihnen damit Informationen aus der „echten“ Welt für die Ausführung von Contracts zu verwenden. 

NeoContract kann nicht auf direktem Weg auf externe Daten (zum Beispiel per Internetsuche) zugreifen. Dies würde nämlich zu nicht-deterministischem Verhalten und zu Inkonsistenzen zwischen den Nodes bei der Ausführung von Contracts führen. Durch die Orakel Maschine werden externe Daten von einer vertrauenswürdigen Drittpartei an die Blockchain geleitet. Durch die Integration dieser Datenfeeds als Teil des Blockchain Ledgers wird nicht-deterministisches Verhalten eliminiert. 

Die vertrauenswürdige Drittpartei kann eine Person oder eine Institution sein, der von beiden Parteien im Vertrag vertraut wird, oder ein dezentralisierter Datenprovider, dessen Integrität durch ökonomische Anreize garantiert wird. In dieser Art und Weise kann NeoContract für die Implementation von Orakel Maschinen verwendet werden. 

### 8.5 Ethereum DAPP

Bitcoin erschuf die Ära der Blockchain und von elektronischem Geld. Ethereum erschuf die Ära der Smart Contracts. Ethereum, der als Pionier von Smart Contracts auf der Blockchain gilt, hat bedeutsame Beiträge zum Grundprinzip, dem ökonomischen Modell und der technologischen Umsetzung eines Smart Contract Systems geleistet. Zusätzlich verzeichnet die Ethereum Plattform bis jetzt eine große Anzahl an DAPPs (distributed applications = dezentralisierte Anwendungen). Ein paar ihrer Anwendungsmöglichkeiten inkludieren Glücksspielvereinbarungen, digitale Assets, elektronisches Gold, Gaming Plattformen, Gesundheitsversicherungen, Heiratsplattformen, und weiteren weitgestreuten Anwendungsmöglichkeiten entlang einer Vielzahl von Industrien. Theoretisch können all diese DAPPs auf einfachste Art und Weise als NEO Anwendungen auf die NeoContract Plattform umgesetzt werden.
