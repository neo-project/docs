# NEO Smart Contract Tutorial

Nachdem Sie das vorherige Tutorial gelesen haben, sollte es Ihnen möglich sein mit C# ein Smart Contract Projekt in Visual Studio 2015 oder 2017 zu kreieren. Hier werden wir nun diskutieren wie Smart Contracts in der NeoVM (Neo Virtual Machine) ausgeführt werden.

## Smart Contract Auslöser

Es gibt 2 Möglichkeiten Smart Contracts auszulösen:

1. Contract User Authentication: Hier ist der Smart Contract ein Contract Account. Wenn ein User anfordert, den Contract Account in einem Asset zu nutzen, wird das den Smart Contract auslösen.

2. Einen Smart Contract manuell auslösen: Hier sendet der User eine Transaktion (Invocation Transaction) um die Durchführung eines Smart Contracts auszulösen.

## NeoVM

NeoVM ist die Virtual Machine, die die Neo Smart Contract Codes ausführt.  Wir sprechen hier über das Konzept von Virtual Machine im engeren Sinne, nicht in Anlehnung an Betriebssysteme oder Programme, welche das simulieren können, wie zum Beispiel VMware oder Hyper-V.
In der Java JVM oder .NET CLR zum Beispiel, wird der Source Code in den relevanten Bytecode compiled und dann auf der entsprechenden Virtual Machine ausgeführt. Die JVM oder CLR wird den Bytecode ausführen, was ähnlich ist wie die Anweisungen auf einer echten, physischen Maschine auszuführen. Die entsprechenden binary Instructions werden trotzdem auf einer physischen Maschine ausgeführt. Die Physische Maschine holt Anweisungen aus dem Speicher ab, überträgt sie via BUS an die CPU, entschlüsselt und führt sie aus und speichert das Resultat.

### Virtual Machine Architektur

![](../../assets/neo-vm.jpg) 

Dieses Diagramm zeigt die Architektur der Neo Virtual Machine (NeoVM), wobei der Teil in der gestrichelten Box der Kern der Virtual Machine darstellt.

#### Execution Engine

Die grüne Box auf der linken Seite ist die Execution Engine der Virtual Machine (das Äquivalent der CPU). Sie kann gängige Befehle ausführen, wie zum Beispiel: flow control, stack operations, bit operations, arithmetic operations, logical operations, cryptographic methods und so weiter. Sie kann mit der Interoperablen Service Layer (weiter unten beschrieben) mittels System Calls interagieren.

#### Evaluation Stack
Der mittlere, graue Teil der Virtual Machine ist der Evaluation Stack (das Äquivalent zum Speicher). Zur Zeit gibt es 2 Möglichkeiten eine eine Virtual Machine zu kreieren 1) Stackbasiert und 2) Registerbasiert. Beide Möglichkeiten haben ihre Vor- und Nachteile und beide haben ihre eigenen, grossartigen Implementierungsbeispiele. Einerseits gibt es stackbasierte Virtual Machines wie JVM, CPython und die .NET CLR. Andererseits gibt es registerbasierte VMs wie Dalvik und Lua5.0. Stackbasierte Virtual Machines haben ein Computing Stack Konzept, das es Ihnen erlaubt direkt mit dem Stack (Evaluation Stack) zu interagieren wenn sie reale Operationen ausführen. 

Da das Standardverhalten von stackbasierten Virtual Machines darin besteht, Daten vom Operandenstack abzuholen, ist es nicht nötig Operanden zu bestimmen, im Gegensatz zu zum Beispiel der folgenden x86 Konstruktion '"ADD EAX, EBX"'. Für diese Anwendung ist es nötig, dass Sie die Source Operanden und den Bestimmungsort definieren. Für Stackbasierte Virtual Machine Anweisungen ist es nicht nötig diese Parameter zu definieren. Das Hinzufügen einer einfachen "ADD" Operation zum Beispiel wird direkt im Operandenstack ausgeführt. Die Daten können direkt verschwinden und das Resultat wird am Ende des Stack gespeichert.

#### Interoperable Service Layer

Der blaue Teil auf der rechten Seite ist die Interoperable Service Layer der Virtual Machine (das Äquivalent zu den Peripheriegeräten). Zur Zeit bietet die Interoperable Service Layer einige APIs um auf die chain-chain Daten eines Smart Contracts zuzugreifen. Sie hat Zugriff auf Blockinformationen, Transaktionsinformationen, Contractinformationen, Assetinformationen und so weiter.

Zusätzlich stellt die Interoperable Service Layer persistenten Speicherplatz für jeden Contract zur Verfügung. Jeder Smart Contract kann optional mit privatem Speicherplatz kreiert werden, in Form von einem Key-Value Objekt, bestimmt durch den Angerufenen des Contracts und nicht vom Kontext des persistenten Speicher. Der Anrufer muss dem Angerufenen seinen eigenen Speicherkontext übermitteln (um die Autorisierung abzuschliessen) bevor der Anrufer Lese- und Schreiboperationen ausführen kann.

### Charge Modus
Ein Smart Contract kann so programmiert werden, dass er eine bestimmte Gebühr erhebt, aufgeteilt in Bereitstellungs- und Ausführungskosten.

Bereitstellungskosten beziehen sich auf die Notwendigkeit für den Entwickler eine Gebühr zu bezahlen, um einen Smart Contract auf der Blockchain bereitzustellen (im Moment 500 GAS). Ausführungskosten beziehen sich auf die Gebühr, welche ein User für die Ausführung eines Smart Contracts bezahlt. Alle Operationen haben Kosten, wobei die meisten Operationen standardmässig auf 0.001 GAS festgelegt sind. Die ersten 10 GAS sind gratis. Priorität bei der Ausführung kann erreicht werden, indem die Ausführungsgebühr manuell erhöht wird. Lesen sie mehr über Smart Contract Gebühren [hier] (systemfees.md#smart-contract-fees).

## Ein einfacher Smart Contract

Hier sind einige einfache Smart Contracts:

```c#
public static bool Main ()
{
    return true;
}
```
Hier ist der return Wert des Contracts immer 'true', was anzeigt, dass jeder die Contractadresse der Assets ausgeben kann (kann als Geld verstanden werden).

Der NEO wallet client hat eine Funktion um Assets zu löschen. Wenn sie ein Asset löschen, wird der Asset an eine spezifische Adresse gesendet, die Contractadresse welche von obigem Smart Contract generiert wird. Jeder kann die Assets auf der Adresse ausgeben. Die Assets in der Adresse sind Assets welche andere nicht wollen.

```c#
public static bool Main ()
{
    return false
}
```

Der return Wert des Contracts ist immer 'false', was anzeigt, dass die Assets dieses Contracts nicht benutzt werden können (das kann interpretiert werden als Verbrennen oder Zerstören eines Assets). Ein Solcher Contract kann zum Beispiel angewendet werden für Aktien einer Firma, welche abgeschrieben/storniert wurden.

Mehr Bespiele finden Sie hier:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)


