# Installation et déploiement d'un nœud NEO

Il existe deux clients pour créer un nœud dans le réseau NEO. Le premier est [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (un client en ligne de commandes, destiné aux développeurs), le second [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (un client doté d'une interface graphique, pour les utilisateurs avancés).

Le déploiement d'un nœud de consensus utilise `Neo-CLI`, un logiciel multi-plateforme qui tourne sur Windows, Linux et Docker.

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

> [!Note]
> Actuellement, les nœuds NEO ne fonctionnent pas correctement sous Mac OS. C'est prévu, nous l'annoncerons le moment venu.

## Lancer l'environnement

Pour lancer un nœud NEO il faut préalablement installer [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), version 2.0 ou plus.

### Méthode d'installation pour Windows

Sur Windows, il suffit de télécharger le programme d'installation de .NET Core et de le lancer.

### Méthode d'installation pour Linux

Les instructions suivantes montrent comment .NET Core peut être installé sur un serveur Red Hat Enterprise Linux 7 :

> [!Note]
> Pour les autres distributions Linux, veuillez vous référer à ce [tutoriel d'installation de .NET Core](https://www.snetnet/core#linuxredhat).

```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Après l'installation, vous pouvez lancer la commande suivante pour vérifier si l'environnement .NET Core a été installé correctement :

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Si "Hello World!" s'affiche, l'installation s'est bien passée.

## Installation d'un nœud NEO

1. Téléchargez le zip [Neo-CLI](https://github.com/neo-project/neo-cli/releases) sur Github et décompressez-le.

> [!Note]
> Si vous essayez de télécharger et de compiler la source de Neo-CLI directement sur Github, vous verrez que `dotnet neo-cli.dll` ne marche pas correctement après la compilation. Vous allez donc avoir besoin de copier les fichiers `libleveldb.dll` et `sqlite3.dll` dans le même repertoire que `neo-cli.dll`. Ces deux fichiers peuvent être téléchargés dans le zip mentionné ci-dessus.

2. Sur Linux, installez les paquets de développement LevelDB and SQLite3. Par exemple, sur Ubuntu:

```
sudo apt-get install libleveldb-dev sqlite3 libsqlite3-dev
```

Sur Windows, utilisez la [version spéciale de LevelDB pour NEO](https://github.com/neo-project/leveldb).

3. Ouvrez l'invite de commande, déplacez-vous dans le répertoire du programme, puis entrez la commande suivante pour démarrer un nœud NEO :

```
dotnet neo-cli.dll
```

Neo-CLI fournit une suite d'APIs (interfaces de programmation) pour les accès externes. Si vous voulez lancer un nœud supportant ces APIs, entrez plutôt :

```
dotnet neo-cli.dll /rpc
```

4. Si vous souhaitez utiliser les APIs, pensez à aussi ouvrir les ports suivants dans votre pare-feu: 10331-10334, 20331-20334.
