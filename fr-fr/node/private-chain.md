# Construire une chaîne privée avec un noeud NEO

Dans un tutoriel précédent, vous avez appris à mettre en place et déployer un noeud Windows et Linux. Ce tutoriel, lui, va vous apprendre à construire une chaîne privée ou une chaîne d'alliance et connaître les étapes pour extraire du NEO et du GAS de ces chaînes privées.

Le déployement d'une chaîne NEO privée demande aux moins quatres serveurs pour atteindre un consensus dans lequel chaque serveur correspond à un noeud de consensus et à un porte-feuille NEO dédier.

## 1. Configuration de la machine virtuelle

Comme dit précédement, il nous faut tout d'abord quatres serveurs correspondant à quatres noeuds de consensus. Pour les besoins de la démonstration, j'ai créé quatres machines virtuelles Windows sur Azure, la taille est le standard DS1 v2 (1 coeur, 3,5 Go RAM). Vous allez être capable de déployer des chaînes privées sur un réseau LAN ou sur machines virtuelles.

![image](/assets/privatechain_1.png)

Il faut maintenant ouvrir les ports 10331 à 10334 dans le pare-feu. Pour établir une nouvelle règle, dirigez-vous dans `Pare-feu Windows` puis `Paramètres avancés`, ensuite `Règles de trafic entrant` et ajoutez les ports 10331-10334.

> [!Note]
> Si vous créez une machine virtuelle sur un serveur cloud, enregistrez-vous dans le panneau d'administration de la machine virtuelle et mettez en place un groupe de sécurtié réseau.
>
> La méthode d'installation sur Azure est : `Interface réseau` `Groupe de sécurité réseau` `Règles de trafic entrant` `ajouter` et ajoutez les ports 10331-10334.

Une fois que les machines virtuelles ont été créées, sauvegardez les adresses IP des quatres machines virtuelles pour plus tard.

## 2. Installation d'un noeud NEO

Le processus d'installation à déjà été expliqué dans un article précédent. Veuillez vous référer aux instructions d'installation [ICI](setup.md).

## 3. Création d'un porte-feuille

Tout d'abord, nous avons créer quatres fichiers de porte-feuille nommés de wallet1.db3 à wallet4.db3. Cette étape peut être réalisé sur le version GUI du porte-feuille comme sur la version CLI. Voici une image montrant une capture d'écran du client CLI.

![image](/assets/privatechain_3.png)

Une fois qu'un porte-feuille est créé et que sa clef publique correspondante a été sauvée (par exemple, sur un bout de papier ou dans un fichier texte), copiez cette clef directement ou utilisez la commande `list key` des [Commandes CLI](cli.md) pour voir toutes les clefs publiques et copiez-la.

Par après, copiez les quatres porte-feuilles vers les quatres machines virtuelles dans le répertoire des noeuds.

## 4. Modifier le fichier de configuration du noeud

Ouvrez le fichier de configuration du noeud `protocol.json`.

Commencez par modifier la valeur `Magic` utilisée pour identifier le réseau source des messages. En précisant un Magic différent assure que les informations d'un réseau dans la blockchain NEO ne sont pas envoyées dans les autres réseau pendant la transmission.

> [!Note]
> Le type de variable de Magic est unit, la valeur utilisée se trouve dans l'intervalle [0 - 4294967295].

Remplissez le champs `StandbyValidators` par les quatres clefs publiques enregistrées dans l'étape 3.

En fin, remplissez la `SeedList` avec les quatres adresses IP enregistrées dans la première étape, les numéros de port doivent rester inchangés. Par exemple, j'ai modifié le fichier de configuration comme suit :

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```

SystemFee est le système de frais, les frais actuels sont les suivants (en GAS) :

Enregistrement d'un bookkeepers - 1 000, échange d'actifs - 500, contrats intelligents - 500, enregistrement d'actifs - 10 000.

Vous pouvez arranger le système de frais de votre chaîne privée dans ce champs.

Finalement, remplacez le fichier `protocol.json` par le nouveau modifié dans les quatres repertoires des client des noeuds/

Ensuite, dans les quatres machines virtuelles, entrez les commandes suivantes pour démarrer le noeud, ouvrir le wallet et commencer le processus de consensus.

Consultez les [références des commandes CLI](cli.md) en cas de doute.

Démarrer un noeud :

`Dotnet neo-cli.dll`

Ouvrir le porte-feuille :

`Open wallet wallet1.db3`

> [!Note]
> Tous les noeuds ne doivent pas ouvrir wallet1. Chaque noeud devrait ouvrir son fichier porte-feuille correspondant.

Commencer le consensus :

`Start consensus`

Si l'opération ci-dessus est un succès alors les quatres noeuds vont commencer le processus de consensus comme montré dans l'image suivante : 

![image](/assets/privatechain_8.png)

Quatres noeuds peuvent toujours accomplir un processus même si une machine est éteinte.

![image](/assets/privatechain_9.png)

## 5. Extraire le NEO et le GAS

Installer la version PC du client (Neo-GUI), modifiez aussi le fichier de configuration `protocol.json` pour vous connectez à la chaîne privée.

Lancer le client. Si le nombre de connexions en bas à gauche de l'application n'est pas zéro et que les blocs sont synchronisés, cela signifie que le client est connecté à la chaîne privée.

Ouvrez le porte-feuille wallet1.db3, faites un clique droite sur l'adresse, puis allez sur `Create Contract Add` et ensuite cliquez sur `Multi-Signature...`.

![image](/assets/privatechain_11.png)

Entrez les quatres clefs publiques de vos adresses et indiquez également le nombre minimum de signatures à 3 (nombre de noeuds de consensus / 2 + 1).

![image](/assets/privatechain_12.png)

Cliquez sur OK. Dans le but de reconstruire l'index des porte-feuilles, cliquez sur "wallet" dans la barre de menu puis `Rebuild Index`

![image](/assets/privatechain_13.png)

Vous verrez ensuite que l'adresse de contrat possède 100 million de NEO shares.

![image](/assets/privatechain_14.png)

> [!Note]
> Les quatres porte-feuilles doivent faire l'opération d'ajout des adresses de signature multipartite et reconstruire l'index de leur wallet.

Ici nous voulons envoyer des NEOs de l'adresse de contrat vers une adresse normale. Pour se faire, ouvrez n'importe lequels des quatres porte-feuilles, cliquez sur `Transaction`, puis `Transfer`et entrez l'adresse du bénéficiaire dans le but de transférer les 100 MILLIONS de NEO.

Ensuite, le système va indiquer que la structure est complète mais qu'il n'y a pas encore assez de signatures. Copiez le code, ouvrez le second porte-feuille, cliquez sur `Transaction`, puis `Transfer` et collez le code que vous avez juste copié. Cliquez sur `Sign` et copiez à nouveau le code et faites de même avec le code que vous venez de copier. Cliquez sur `Sign`. A ce moment, un pop-up va apparaître montrant un bouton `Broadcast` ce qui signifie que le processus de signature est fini (le nombre minimum de signatures requises pour le contrat a été atteint). La transaction peut maintenant être diffusé. Cliquez sur `Broadcast`. Cela va prendre environ 15 secondes pour que la transaction soit totalement faite.

![image](/assets/privatechain_20.png)

L'opération pour extraire le GAS est similaire, cliquez sur `Advanced`, `Claim GAS`, `Claim` comme indiqué en dessous. (Retenez l'adresse du porte-feuille, vous en aurez besoin plus tard)

![image](/assets/privatechain_20.png)

La prochaine opération est similaire au transfert des NEOs. Copiez le code qui a un nombre insuffisant de signatures, ouvrez le second porte-feuille, cliquez sur `Transaction`, puis `Transfer` et collez le code. Faites de même avec le troisième porte-feuille. Cliquez sur `Broadcast` pour diffuser la transaction pour réclamer le GAS. Cette action prendra également 15 secondes pour être un succès.
Après l'extraction, le GAS va entrer dans la première adresse standard du porte feuille d'où l'extraction de GAS a été initiée.

![image](/assets/privatechain_26.png)