# Installation et déployement d'un noeud NEO

Il existe deux clients pour créer un noeud dans le réseau NEO. Le premier est [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (un client en ligne de commande pour destiné aux développeurs), l'autre esst [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (un client doté d'une interface graphique pour les utilisateurs avancées).

Le deployement d'un noeud de consensus utilise `Neo-CLI`, un logiciel multi-plateforme qui tourne sur Windows, Linux et Docker.

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
> Actuellement, les noeuds NEO ne peuvent pas fonctionner sous Mac OS. Un support de MAc OS devrait être sorti prochainement, soyez attentif aux mises à jour futures.

## Lancer l'environnement

Faire tourner un noeud NEO requière l'installation de [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime), version 1.0.1 ou plus.

### Méthode d'installation pour Windows

Dans le système Windows, l'installation de .NET Core est très aisée, vous pouvez directement télécharger le programme d'installation et le lancer.

### Méthode d'installation pour Linux

Les instructions suivantes montrent comment .NET Core peut être installé sur un serveur Red Hat Enterprise Linux 7 :

> [!Note]
> Pour les autres distributions Linux, veuillez vous référer à ce [tutorial d'installation de .NET Core](https://www.snetnet/core#linuxredhat).

```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Après l'installation, vous pouvez lancer la commande suivante pour vérifier si l'environnement .NET Core a été installé correctement.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Si vous voyez comme dernière sortie "Hello World!", cela veut dire que l'installation est un succès.


## Installation d'un neoud NEO

1. Téléchargez le package [Neo-CLI](https://github.com/neo-project/neo-cli/releases) sur Github et extrayez le où vous le souhaitez.

> [!Note]
> Si vous essayez de télécharger et de compiler la source de Neo-CLI directement sur Github, `dotnet neo-cli.dll` risque de ne pas fonctionner correctement après la compilation. Vous allez donc avoir besoin de copier les fichiers libleveldb.dll et sqlite3.dll dans le même repertoire que neo-cli.dll. Ces deux fichiers peuvent être téléchargés dans la première partie du package.

2. Ouvrez l'invite de commande et déplacez vous dans le repertoire du programme. Ensuite, entrez les lignes suivantes pour démarrer un noeud NEO :

```
dotnet neo-cli.dll
```

Neo-CLI fournit une série d'APIs pour avoir un accès de l'exterieur. Si vous voulez lancer un noeud pendant l'ouverture de l'API, vous pouvez écrire la ligne suivante :

```
dotnet neo-cli.dll /rpc
```

3. Si vous voulez que le programme externe puisse accèder à l'API du noeud, vous devez ouvrir les ports suivants dans votre pare-feu: 10331-10334, 20331-20334.