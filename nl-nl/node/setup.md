# Installatie en Deployment van de NEO Node 

Het artikel hierboven beschrijft twee clients voor nodes binenn het NEO-netwerk. De een is [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (de command line client, bedoeld voor ontwikkelaars), de ander is [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (de grafische interface-client, voor de geavanceerde NEO-gebruikers).

De deployment consensus node maakt gebruik van de `Neo-CLI`. Dit programma kan worden uitgevoerd in Windows, Linux en Docker.

|                                   | Neo-CLI           |
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

> [!Opmerking]
> Momenteel werken NEO-nodes nog niet naar behoren op Mac OS. In toekomstige versies zal ondersteuning voor Mac OS worden geïmplementeerd.

## De Ontwikkelomgeving Uitvoeren

Het draaien van een NEO-node vereist dat [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime) geïnstalleerd is (minstens versie 1.0.1).

### Installatie op Windows

In een Windows-systeem is de installatie van .NET Core erg eenvoudig; download het programma en het is gelijk klaar voor gebruik.

### Installatie op Linux

.NET Core kan als volgt worden geïnstalleerd in een Red Hat Enterprise Linux 7 Server:

> [!Opmerking]
> Kijk voor andere versies van Linux in de [.NET Core Installation Tutorial](https://www.snetnet/core#linuxredhat).


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Nadat de installatie is voltooid, kunnen de volgende commands uitvoeren om na te gaan of de .NET Core-omgeving succesvol is geïnstalleerd.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Wanneer de laatste output "Hello World!" is, is de installatie van .Net Core geslaagd.

## Installatie van de NEO Node

1. Download het [Neo-CLI-pakket](https://github.com/neo-project/neo-cli/releases) van Github en pak deze uit.

> [!Opmerking]
> Wanneer geprobeerd wordt de Neo-CLI direct te downloaden en compilen op GitHub, zal `dotnet neo-cli.dll` niet correct kunnen worden uitgevoerd. Dit vereist dat libleveldb.dll en sqlite3.dll naar dezelfde map worden gekopieerd als neo-cli.dll. Deze twee bestanden kunnen in de eerste fase van het pakket worden gedownload.

2. Open de command line, navigeer naar de map van het programma en voer de volgende code in om de NEO-node te starten:

```
dotnet neo-cli.dll
```

De Neo-CLI verschaft een reek aan API's voor externe toegang. Als de node moet worden opgestart tijdens het openen van de API, dan kan de volgende code worden uitgevoerd:

```
dotnet neo-cli.dll /rpc
```

3. Wanneer een extern programma toegang nodig heeft tot de API van de node, moet de firewall-port worden geopend: `10331-10334`, `20331-20334`.

