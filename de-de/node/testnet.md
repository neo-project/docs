# NEO TestNet

Das TestNet ist eine Umgebung in der Entwickler Programme entwickeln und testen können. Zum Testen von Programmen im TestNet wird TestNet-GAS und TestNet-NEO benötigt. TestNet-GAS und TestNet-NEO sind wertlose TestNet-Assets, die kostenlos auf der offiziellen NEO Website beantragt werden können.

Die gesamte TestNet-Blockchain ist unabhängig vom NEO-MainNet. Für die Entwicklung von "Smart Contracts" oder die testweise Registrierung von Assets reicht das TestNet vollkommen aus. Nach abgeschlossener Entwicklung und ausgiebigen Tests kann der "Smart Contract" / das Asset problemlos im NEO-MainNet registriert werden.

Entwickler können TestNet-GAS kostenlos hier beantragen: https://www.neo.org/Testnet/Create

## TestNet Eigenschaften:

1. Registrierung von Assets, Verteilung von Assets, Ausführung von "Smart Contracts" etc, ohne dabei "echtes" Geld zu verbrauchen.
2. Globale Verteilung des "Smart Contracts" / des Assets im Internet.
3. Test von Netzwerkblöcken; Transaktionen und andere Informationen können einfach in jedem Blockchainbrowser verfolgt werden.
4. "Smart Contract" Verteilung in einer Testumgebung, in der es weltweit von Jedem genutzt werden kann.
5. Das TestNet kann nicht als kommerzielle Plattform für Programme genutzt werden.

## Client Downloads

Der TestNet-Client ist der gleiche Client wie für das NEO-MainNet. Durch eine Änderung in der Konfigurationsdatei kann der Client zwischen TestNet und MainNet hin- und herwechseln.

Querverweis: [Einführung in NEO-Nodes](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Offizielle Website](https://www.neo.org/download) oder [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Quellcode | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Anleitung zum Wechseln des Netzwerks

1. Den Inhalt der `protocol.testnet.json` in `protocol.json` im Programmverzeichnis kopieren:

![image](/assets/testnet_1.png)

2. Den Inhalt der Datei `neo-gui.exe.testnet.config` in die Datei `neo-gui.exe.config` kopieren:

![image](/assets/testnet_2.png)

Anmerkung: Wenn die NEO-CLI-Node verwendet wird, muss der Inhalt der `config.testnet.json` in die Datei `config.json` kopiert werden.
