# Référence des commandes CLI

Ouvrez l'interface en ligne de commande, déplacez vous dans le répertoire où le programme est situé et entrez le code suivant pour démarrer le porte-feuille en ligne de commande.

`dotnet neo-cli.dll`

Ce tutoriel va vous présenter toutes les commandes disponibles. Vous pouvez manipuler votre porte-feuille avec les commandes pour la création d'un porte-feuille, l'importation et l'exportation d'une clé privée, les transferts, l'initialisation du consensus, etc.

Nous allons tout d'abord découvrir divers commandes disponible dans le programme. Dans l'interface, entrez `help` suivis de la touche Entrer et vous allez voir la liste de commandes suivante.

![image](/assets/cli_2.png)

Voici une description de toutes les "parenthèses" des commandes:

`<>` indique un paramètre.
`[]` indique un paramètre optionnel.
`|` sépare les paramètres qui peuvent être choisis et qui peuvent être de n'importe lequel de ces types/
`=` indique la valeur par défaut du paramètre optionnel.

## 1. Instructions de la console

| Commandes      | Description     |
| ------- | --------- |
| version | Montre la version actuelle du programme |
| help    | Menu d'aide      |
| clear   | Vide l'écran      |
| exit    | Quitte le programme      |

## 2. Opérations de porte-feuille


| Commandes | Description | Remarques |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | Crée un fichier de porte-feuille |
| open wallet \<path> | Ouvre un fichier de porte-feuille |
| update wallet \<path> | Actualise un porte-feuille |
| rebuild wallet index | | Nécessite un porte-feuille ouvert |
| list address | Liste tous les comptes liés à un porte-feuille | |
| list asset | Liste tous les actifs liés à un porte-feuille | Nécessite un porte-feuille ouvert |
| list key | Liste toutes les clé publiques liés à un porte-feuille | Nécessite un porte-feuille ouvert |
| show utxo \[id\|alias] | Liste toutes les transactions en fonction de leur id ou de leur alias | Nécessite un porte-feuille ouvert |
| show gas | Montre le GAS | Nécessite un porte-feuille ouvert |
| claim gas | Demande le GAS disponible | Nécessite un porte-feuille ouvert |
| create address [n = 1] | Crée une adresse ou un lot d'adresses | Nécessite un porte-feuille ouvert |
| import key \<wif\|path> | Importe une clé privée ou un volume de clés privées | Nécessite un porte-feuille ouvert |
| export key \[address] \[path] | Exporte une clé privée | Nécessite un porte-feuille ouvert |
| send \<id\|alias> \<address> \<value> [fee=0]| Envoie à l'adresse spécifique | Nécessite un porte-feuille ouvert |

Quelques commandes sont expliquées plus en détail ci-dessous :

👉 `rebuild index`

Cette commande est utilisée pour reconstruire l'index du porte-feuille.
Pourquoi cela peut être nécessaire ?

Il y a un champs dans le porte-feuille qui enregistre la taille de blocs synchronisés avec le wallet actuel. Pour chaque nouveau bloc, le client synchronise les blocs et met à jour les actifs et les transactions dans le porte-feuille. Imaginons que la taille actuelle des blocs enregistrés soit de 100 et qu'ensuite nous éxécutons la commande d'importation de clé, le porte-feuille va continuer à calculer nos actifs à partir de la taille de blocs 100. Si l'adresse importée contient des transactions d'un moment ou la taille de blocs était en dessous de 100, la transaction et l'actif correspondant ne seront pas reflètés dans le porte-feuille. De ce fait, l'index du porte-feuille devrait être reconstruit, forçant le wallet à calculer vos actifs à partir de la taille de blocs 0.

Un porte-feuille nouvellement créé n'a pas besoin de reconstruire son index, seul les clés privées importées nécessitent de reconstruire l'index d'un porte-feuille.

👉 `create address [n = 1]`

Cette commande peut être utilisée pour créer une nouvelle adresse. Nous pouvons également entrer "create address 100" pour créer 100 nouvelles adresses. Le lot d'adresses créées sera automatiquement exporté dans un fichier "address.txt".

👉 `export key [address] [path]`

Vous pouvez spécifier quelle adresse pour exporter la clé privée correspondante. Vous pouvez aussi exporter un groupe de clés via un fichier contenant des adresses (voir les exemples ci-dessous). La commandes nécessite la vérification du mot de passe du porte-feuille.

Export key

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉 `import key <wif | path>`

Lors l'importation de clés privées, vous pouvez indiquer d'importer une clé privée ou un fichier avec plusieurs clés (voir exemple ci-dessous).

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

Si il y a un fichier indiqué, le fichieer est dans le format de la clé privée. Référez vous à la sortie de "export key key.txt".

👉 `send <id | alias> <address> <value> [fee = 0]`

Pour les transferts, il y a un total de quatre paramètres. Le premier paramètre est l'ID de l'actif, le second paramètre est l'adresse de paiement, le troisième paramètre est le montant du transfert et le dernier est la taxe de la transaction. (Ce paramètre peut être laissé vide, par défaut, il vaut 0). La commande nécessite la vérification du mot de passe du porte-feuille. Par exemple, pour transférer 100 NEO à l'adresse "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", on pourrait écrire une commande de ce type.

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

Si vous n'êtes pas sur de l'ID de l'actif, vous pouvez entrer "list asset" pour voir tous les actifs disponible dans le porte-feuille.

## 3. Voir les informations du noeud


| Commande | Description |
| ---------- | ----------------------- |
| show state | Affiche le statut actuel de la synchronisation à la blockchain |
| show node | Affiche l'adresse et le port des noeuds connectés |
| show pool | Affiche les transactions se trouvant dans la zone mémoire (Les transactions qui n'ont pas de confirmation) |

## 4. Instructions avancées

| Commande | Description |
| --------------- | ---- |
| Start consensus | Démarre le consensus |
| export blocks [path=chain.acc] | Exporte les blocs dans un fichier |
| refresh policy | Rafraichie la politique |

Pour lancer un consensus, le porte-feuille doit avoir un pouvoir de consensus, l'autorité du consensus sur le réseau principal (MainNet) est obtenu par le biais du vote. Si une chaîne privée est déployée, les clés publiques pour le consensus peuvent être configurées dans le fichier `protocol.json`. Référez vous à l'article de création de [chaîne privée](private-chain.md)