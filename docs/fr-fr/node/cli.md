# Référence de NEO-CLI

Dans un terminal, déplacez-vous dans le dossier où le programme est installé, puis entrez la commande suivante pour démarrer le portefeuille NEO en ligne de commande (qui fait aussi office de nœud NEO).

`dotnet neo-cli.dll`

Ce tutoriel va introduire toutes les commandes de NEO-CLI. Vous pouvez manipuler votre portefeuille avec des commandes de création, d'import et export de clé privée, de transfert, de démarrage d'un consensus, etc.

Voyons d'abord les différentes commandes disponibles. Dans le terminal, tapez `help` (aide) puis entrée, et vous verrez une liste comme ci-dessous :

![image](/assets/cli_2.png)

Les commandes sont décrites ci-dessous ainsi que leurs paramètres. Ces symboles sont utilisés:
Les signes `<>` délimitent les paramètres qui doivent être fournis.
`[]` délimitent les paramètres optionnels.
Quand `|` sépare deux paramètres, vous pouvez choisir de renseigner l'un ou l'autre.
Le signe `=` indique la valeur par défaut d'un paramètre optionnel quand il n'est pas renseigné.

## 1. Commandes de base

| Commande | Description      |
| -------- | ---------------- |
| version | Montre la version utilisée |
| help    | Menu d'aide |
| clear   | Effacer l'écran |
| exit    | Sortir du programme |

## 2. Commandes relatives au portefeuille

Commande | Description |
| ------ | ----------- |
| create wallet \<chemin> | Crée un portefeuille au chemin indiqué
| open wallet \<chemin> | Ouvre un portefeulle

Pour les commandes suivantes, un portefeuille doit être ouvert :

Commande | Description |
| ------ | ----------- |
| rebuild wallet index | Reconstruit l'index du portefeuille |
| list address | Liste les comptes du portefeuille |
| list asset | Liste les actifs associés au portefeuille |
| list key | Liste les clés publiques du portefeuille |
| create address [n = 1] | Crée une ou plusieurs adresses |
| import key \<wif\|path> | Importe une ou plusieurs clés privées |
| export key \[address] [path] | Exporte la ou les clés privées |
| send \<id\|alias> \<address> \<value> [fee=0]| Envoyer une quantité `value` d'actifs dont l'identifiant ou l'alias est donnée, à une adresse `address`

Certaines commandes sont expliquées plus en détail ici:

👉 `rebuild index`

Cette commande reconstruit l'index du portefeuille.
Pourquoi est-ce nécessaire ?

Il y a un champs dans le portefeuille qui enregistre la hauteur du dernier bloc synchronisé. A chaque nouveau bloc, le client synchronise les blocs et met à jour les actifs et les transactions du portefeuille.
Si l'on suppose que la hauteur du dernier bloc enregistré est 100, puis que vous importez une clé privée, le portefeuille ne suivra que les transactions à partir du bloc 100. Si la nouvelle adresse importée avait des opérations avant ce bloc, elles n'apparaîtront pas, et vous verrez une balance incorrecte. Il faut donc reconstruire l'index pour forcer le portefeuille logiciel à calculer tous les actifs à partir du bloc 0.

Ceci n'est pas nécessaire pour de nouveaux portefeuilles, mais seulement après un l'import d'un portefeuille existant (via sa clé privée).

👉 `create address [n = 1]`

Cette commande crée une nouvelle adresse. Le paramètre optionnel permet d'en créer plusieurs d'un coup, comme `create address 100` qui en créera 100. La création d'un lot d'adresses sera automatiquement exporté dans le fichier `address.txt`.

👉 `export key [address] [path]`

Vous pouvez préciser quelles adresses exporter, ou encore vers quel fichier (voir exemples ci-dessous). Il faudra entrer votre mot de passe pour effectuer cette commande.

Exemples:
`export key`
`export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b`
`export key key.txt`
`export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt`

👉 `import key <wif | path>`

L'import de clé(s) privée(s) se fait en précisant la clé elle-même, ou un fichier qui en contient plusieurs.

Exemples:
`import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH`
`import key key.txt`

Si un fichier est donné, il doit être au bon format, le même qui est utilisé lors de l'export de clés.

👉 `send <id | alias> <address> <value> [fee = 0]`

Pour effectuer une transaction (en termes bancaires, un virement), il y a quatre paramètres :
1. l'identifiant de l'actif
2. l'adresse du destinataire
3. le montant (la quantité d'actifs)
4. les frais (optionnel, aucun par défaut)

Le mot de passe sera demandé pour procéder au transfert.
Par exemple, pour transférer 100 NEO à l'adresse "AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b", il faut entrer cette commande:

`send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100`

Si vous n'êtes pas sûr de l'identifiant de l'actif, utilisez la commande `list asset` pour voir tous les actifs du portefeuille.

## 3. Commandes relatives au nœuds NEO

Commande | Description |
|------- | ----------- |
show state | Affiche l'état courant de la synchronisation avec la blockchain
show node | Affiche les adresses et ports des nœuds connectés |
show pool | Affiche les transactions dans la zone mémoire (ce sont les transactions non confirmées)

## 4. Commandes avancées

Command | Description |
| ----- | ----------- |
Start consensus | Démarrer un consensus

Prérequis: le portefeuille doit avoir une autorité de consensus, et autoriser leur obtention sur le MainNet (réseau principal) par vote. Si une chaîne privée est déployée, la clé publique du consensus peut être déterminée dans le fichier `protocol.json`. Se référer à la page [Chaîne privée](private-chain.md) pour plus de détails.
