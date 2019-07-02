# Installazione e Implementazione del nodo NEO

L’articolo precedente descrive due client per i nodi della rete NEO. Uno é [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (il client a linea di comando - per gli sviluppatori), l’ altro é [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (Il client a interfaccia grafica - per gli utenti avanzati).

L'implementazione di un nodo di consenso utilizza `Neo-CLI`, un programma multi-piattaforma che può essere eseguito su Windows, Linux e Docker. 

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
> Al momento, i nodi NEO non funzionano correttamente con Mac OS. In futuro Mac OS sará supportato, per favore attendere ulteriori aggiornamenti. 

## Esecuzione dell'ambiente

L’esecuzione di un nodo NEO richiede l’istallazione di [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), versione 2.0 o successive.

### Metodo di istallazione su Windows

Nel sistema operativo Windows, conviene istallare .NET Core, é possibile scaricarlo e eseguirlo direttamente.

### Metodo di installazione su Linux

Tutto ció che segue mostra come .NET Core é installato su un Server Red Hat Enterprise Linux 7:

> [!Nota]
> Per le altre distribuzioni del kernel Linux, fare riferimento a [Tutorial di installazione di .NET Core](https://www.snetnet/core#linuxredhat)

```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```


```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Dopo il completamento dell’installazione, é possibile eseguire i seguenti comandi per controllare se l’ambiente .NET Core é stato installato con successo.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Se l’output finale é "Hello World!", .NET Core é stato installato con successo.


## Installazione del nodo Neo

1. Scarica il pacchetto [Neo-CLI](https://github.com/neo-project/neo-cli/releases) su Github e decomprimilo.

> [!Nota]
> Provando a scaricare e compilare il file sorgente Neo-CLI su Github, `dotnet neo-cli.dll` verrá eseguito incorrettamente dopo la compilazione, quindi occorrerá copiare libleveldb.dll e sqlite3.dll nella stessa directory di neo-cli.dll. Questi due file possono essere scaricati durante il primo step del pacchetto. 

2. Su Linux, istallare i pacchetti di sviluppo LevelDB e SQLite3. Es. Su Ubuntu:

```
sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
```
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Su Windows, usare [la versione Neo di LevelDB](https://github.com/neo-project/leveldb).

3. Aprire la linea di comando, navigare fino alla directory del programma e immettere il seguente codice per avviare il nodo NEO. 

```
dotnet neo-cli.dll
```

Neo-CLI fornisce una serie di API per gli accessi esterni. Se si vuole avviare il nodo all’apertura dell'API, eseguire il seguente codice.
```
dotnet neo-cli.dll /rpc
```
4. Se si vuole permettere a un programma esterno di accedere all'API del nodo aprire la porta del firewall: 10331-10334 20331-20334
