# Istallazione e Implementazione del nodo NEO

L’articolo precedente descrive due client per i nodi della rete NEO. Uno é [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (il client a linea di comando - per gli sviluppatori), l’ altro é [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (Il client a interfaccia grafica - per gli utenti avanzati).

Per l'implementazione di un nodo di consenso viene utilizzato `Neo-CLI`, un programma multi-piattaforma che gira su Windows, Linux e Docker. 

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

> [!Nota]
> Al momento, i nodi NEO non funzionano correttamente con Mac OS. In futuro Mac OS sará supportato, per favore aspettare futuri aggiornamenti. 

## Esecuzione dell'ambiente

L’esecuzione di un nodo NEO richiede l’istallazione di [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), versionw 1.0.1 o superiore.

### Metodo di istallazione su Windows

Nel sistema windows, conviene istallare .NET Core, puoi scaricarlo direttamente e istallarlo.

### Metodo di installazione su Linux

Tutto ció che segue mostra come .NET Core é istallato su Red Hat Enterprise Linux 7 Server:

> [!Nota]
> Per le altre distribuzioni del kernel Linux, fare riferimento a [.NET Core installation tutorial](https://www.snetnet/core#linuxredhat)

```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```


```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Dopo il completamento dell’stallazione, eseguire i seguenti comandi per controllare se l’ambiente .NET Core é stato istallato con successo.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Se l’output finale é "Hello World!", .NET Core é stato istallato con successo.


## Istallazione di nodo Neo

1. Scarica il pacchetto [Neo-CLI](https://github.com/neo-project/neo-cli/releases) su Github ed estrailo.

> [!Nota]
> Se si prova a scaricare direttamente il sorgente di Neo-CLI da Github, `dotnet neo-cli.dll` verrá eseguito incorrettamente dopo la compilazione, quindi occorrerá copiare libleveldb.dll e sqlite3.dll nella stessa directory di neo-cli.dll. Questi due file devono essere scaricati durante il primo step del pacchetto. 

2. Su Linux, istallare LevelDB e SQLite3 dev packages. Es. Su Ubuntu:

```
sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Su Windows, usare [Neo version of LevelDB](https://github.com/neo-project/leveldb).

3. Aprire la line di comando, navigare fino alla directory del programma, immettere il seguente codice per avviare il nodo NEO. 

```
dotnet neo-cli.dll
```

Neo-CLI fornisce una serie di APIs per gli accessi esterni. Se vuoi avviare il nodo all’apertura delle API, eseguire il seguente codice.
```
dotnet neo-cli.dll /rpc
```
4. Se vuoi permettere a un programma esterno di accedere al nodo API apri la porta firewall: 10331-10334 20331-20334
