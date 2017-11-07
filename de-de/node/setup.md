# Installation einer NEO-Node 

Der vorherige Artikel beschreibt zwei Clients, die als Nodes verwendet werden können. Der eine (NEO-CLI) ist ein Kommandozeilen-Client für Entwickler, der andere (NEO-GUI) ein Client mit grafischer Oberfläche für fortgeschrittene Anwender.

Die bereitgestellten Consensus-Nodes nutzen den NEO-CLI-Client, ein Multiplattform Programm, das auf Windows, Linux und Docker läuft.

|                                   | Neo-CLI |
| --------------------------------- | ----------------- |
| Windows 7 SP1 x64                 | ✅                 |
| Windows Server 2008 R2 SP1        | ✅                 |
| Red Hat Enterprise Linux 7 Server | ✅                 |
| Ubuntu 14.04, 16.04, 16.10        | ✅                 |
| Debian 8                          | ✅                 |
| Fedora 23, 24                     | ✅                 |
| CentOS 7.1 & Oracle Linux 7.1     | ✅                 |
| openSUSE 13.2, 42.1               | ✅                 |
| Docker                            | ✅                 |

> [!Anmerkung]
> Zur Zeit funktionieren NEO-Nodes nicht fehlerfrei unter MacOS. Es ist aber geplant, in der Zukunft einen MacOS-Client zu veröffentlichen.

## Die NEO-Node starten

Der Betrieb einer NEO-Node benötigt eine Installation der [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), Version 1.0.1 oder höher.

### Installation auf einem Windows System

Auf einem Windows System ist die Installation von .NET Core sehr nützlich, da der Client dann heruntergeladen und direkt gestartet werden kann.

### Installation auf einem Linux System

Im Folgenden wird gezeigt, wie .NET Core auf einem Red Hat Enterprise Linux 7 Server installiert wird.

> [!Anmerkung]
> Tutorials für eine Linux-Kernel-Installation auf anderen Distributionen finden Sie in der [.NET Core Installationsanleitung]https://www.snetnet/core#linuxredhat)


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Nachdem die Installation abgeschlossen wurde, können Sie mit dem folgenden Befehl überprüfen, ob die .NET Core Umgebung erfolgreich installiert wurde.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Wenn Sie den "Hello World!" ausgegeben bekommen, war die Installation erfolgreich.


## Installation der NEO-Node

1. Herunterladen und entpacken des [Neo-CLI](https://github.com/neo-project/neo-cli/releases)-Pakets von Github.

> [!Anmerkung]
> Beim Versuch den Quellcode von NEO-CLI von Github herunterzuladen und zu kompilieren wird `dotnet neo.cli.dll` danach nicht fehlerfrei funktionieren. Um diesen Fehler zu beheben müssen die Dateien libleveldb.dll und sqlite3.dll in das gleiche Verzeichnis wie neo-cli.dll kopiert werden. Beide Dateien können auch bei Github (s. Schritt 1.) heruntergeladen werden.

2. Öffnen Sie die Kommandozeile und navigieren Sie in das Installationsverzeichnis. Geben Sie den folgenden Code ein, um die NEO-Node zu starten.

```
dotnet neo-cli.dll
```

NEO-CLI bietet eine Reihe an verschiedenen APIs für externen Zugriff. Wenn Sie die Node mit APIs öffnen wollen, nutzen Sie folgenden Code:
```
dotnet neo-cli.dll /rpc
```
3. Um von außen auf die Node zuzugreifen, müssen Sie folgende Ports in Ihrer Firewall freigeben: 10331-10334, 20331-20334
