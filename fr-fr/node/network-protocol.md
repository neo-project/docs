# Protocol réseau


NEO adopte une structure réseau P2P dans lequel les noeuds peuvent communiquer entre eux au travers du protocol TCP/IP. Dans cette structure, il y a deux différents types de noeuds: les noeuds pairs et les noeuds de validation (dit les Bookkeepers dans le livre blanc de NEO). Les noeuds pairs peuvent diffuser, recevoir et transférer des transactions ou des bloques pendant que les noeuds de validation peuvent quant à eux créer des noeuds.


Le protocol réseau de NEO est, en étant large, assez similaire à celui du Bitcoin. Cependant, les structures de données tels que les bloques ou les transactions sont, quelque peu, différents.

Convention
----

1. L'ordre des octets

	Tous les types entier (integer) de NEO sont little-endian excepté pour les adresses IP et les numéros de port, ces derniers sont, eux, big-endian.
	
1. Hash

	Deux différents types de fonction de hashage sont utilisés dans NEO: SHA256 et RIPEMD160. SHA256 est utilisé dans la génération de longue valeur de hashage et RIPEMD160 est utilisé pour de courte valeur de hashage.
	
	En général, nous obtenons une valeur hashage d'un objet en utilisant deux fois une fonction de hashage. Par exemple, nous utilisons SHA256 deux fois quant il s'agit de générer la valeur de hashage d'un bloque ou d'une transaction. Lors de la génération d'une adresse de contrat, nous allons utiliser une fonction SHA256 en premier lieu et ensuite utiliser RIPEMD160.
	
	Par ailleurs, le bloque utilisera également une structure de hash appelé : arbre de Merkel. Le principe est le suivant : on va calculer le hash de chaque transaction et les combiner un à un pour les hasher à nouveau. Le processus sera répeté jusqu'à ce que l'ont trouve le hash de la racine (racine de Merkel - Merkel Root).
	
1. Type de longueur variable

	+ Variant : entier (integer) de longueur variable, peut être encodé pour sauver de l'espace en fonction de la valeur écrite.
		
		|Valeur|Longueur|Format|
		|---|---|---|
		|< 0xfd|1|uint8|
		|<= 0xffff|3|0xfd + uint16|
		|<= 0xffffffff|5|0xfe + uint32|
		|> 0xffffffff|9|0xff + uint64|
		
	+ Varstr : chaîne de caractères (string) de longueur variable, consistant en entier de longueur variable suivi par des chaînes de caractères. Elles sont encodées en UTF-8.
	
		|Taille|Champs|Type de données|Description|
		|---|---|---|---|
		|?|length|variant|La longueur de la chaîne en octets|
		|length|string|uint8[length]|La chaine en elle-même|
		
	+ Array : Le tableau (array) consiste en un entier de longueur variable suivis par une séquence d'éléments.
	
1. Nombre à point fixe

	Les données dans NEO tels que les montant ou les prix sont des nombre à point fixe de 64 bits et la précision de la partie décimale est de 10<sup>-8</sup>, entre [ -2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup> ]
	
Type de données
-------

1. La blockchain

	La blockchain est un type de structure logique qui est connecté en série avec une liste liée a sens unique (one-way linked list). Elle est utilisée pour stocker des données tels que des transactions ou des actifs dans le réseau entier.
	
1. Les bloques
	
	|Taille|Champs|Type de donnée|Description|
    	|---|---|---|---|
	|4|Version|uint32|Version du bloque qui est 0 actuellement|
	|32|PrevBlock|uint256|Valeur de hashage du précédent bloque|
	|32|MerkleRoot|uint256|Hash du root d'une liste de transactions|
	|4|Timestamp|uint32|Horodatage|
	|4|Height|uint32|Taille du bloque|
	|8|Nonce|uint64|Nombre aléatoire|
	|20|NextMiner|uint160|Adresse de contact du prochain mineur|
	|1|-|uint8|Fixé à 1|
	|?|Script|script|Script utilisé pour valider le bloque|
	|?*?|Transactions|tx[]|Liste de transactions|
   
	Lors du calcul de la valeur de hashage d'un bloque, au lieu de calculer le bloque en entier, seuls les sept premiers champs dans l'en-tête du bloque sera calculé c'est-à-dire Version, PrevBlock, MerkleRoot, Timestamp, Height, Nonce, NextMiner. En effet, puisque MarkelRoot contient déjà la valeur de hashage de toutes les transactions, la modification d'une transaction aura quand même une influence sur la valeur de hashage du bloque.
   
	Structure de donnée du bloque de tête :

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|4|Version|uint32|Version du bloque qui est 0 actuellement|
	|32|PrevBlock|uint256|Valeur de hashage du précédent bloque|
	|32|MerkleRoot|uint256|Hash du root d'une liste de transactions|
	|4|Timestamp|uint32|Horodatage|
	|4|Height|uint32|Taille du bloque|
	|8|Nonce|uint64|Nombre aléatoire|
	|20|NextMiner|uint160|Adresse de contact du prochain mineur|
	|1|-|uint8|Fixé à 1|
	|?|Script|script|Script utilisé pour valider le bloque|
	|1|-|uint8|Fixé à 0|
	
	L'horodatage de chaque bloque doit être supérieur à celui du bloque précédent. Généralement, la différence de temps entre deux bloques est d'environ 15 secondes, quelques imprécisions sont acceptées. La taille du bloque doit être exactement égale à la taille du bloque précédent plus un.
	
1. Transactions

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|1|Type|uint8|Type de transaction|
	|1|Version|uint8|Version de la transaction, actuellement 0|
	|?|-|-|Données spécifiques au type de la transaction|
	|?*?|Attributes|tx_attr[]|Fonctions additionnelles que la transaction possède|
	|34*?|Inputs|tx_in[]|Entrées|
	|60*?|Outputs|tx_out[]|Sorties|
	|?*?|Scripts|script[]|Liste des scripts utilisés pour valider la transaction|
	
	Toutes les opérations dans le système NEO sont enregistrés comme des transactions. Il y a plusieurs types de transactions :
	
	|Value|Name|System Fee|Description|
	|---|---|---|---|
	|0x00|MinerTransaction|0|Attribue les taxes de bytes|
	|0x01|IssueTransaction|500\|0|Insertion d'actif|
	|0x02|ClaimTransaction|0|Attribue le GAS|
	|0x20|EnrollmentTransaction|1000|Inscription de validateur|
	|0x40|RegisterTransaction|10000|Enregistrement d'actifs|
	|0x80|ContractTransaction|0|Tansaction de contrat|
	|0xd0|PublishTransaction|500 * n|(Non utilisable) Transactions spéciales pour les contrats intelligents|
	|0xd1|InvocationTransaction|0|Transactions spéciales pour l'appel de contrats intelligents|
	
	Chaque type de transaction, en plus du domaine publique, a aussi son propre domaine exclusif. Une description de ces domaines exclusifs en détails est expliqué ci-après :
	
	+ MinerTransaction
	
		|Taille|Champs|Type de données|Description|
		|---|---|---|---|
		|4|Nonce|uint32|Nombre aléatoire|
		
		La première transaction de chaque bloque doit être une MinerTransaction. Elle est utilisée pour donner au validateur toutes les taxes de transactions du bloque courant.
		
		Le nombre aléatoire dans la transaction est utilisé pour éviter une collision de hashage.
		
	+ IssueTransaction
	
		Il n'y a pas de champs spécifique à une transaction d'insertion.
		
		Les gestionnaires d'actifs peuvent insérer des actifs qui ont été enregistrés dans la blockchain NEO grâce à IssueTransaction et les envoyer à n'importe quelle adresse.
		
		En particulier si les actifs qui seront insérés sont des NEO alors la transaction sera gratuite.
   
	+ ClaimTransaction
	
		|Taille|Champs|Type de données|Description|
		|---|---|---|---|
		|34*?|Claims|tx_in[]|NEOs pour la distribution|
		
	+ EnrollmentTransaction

		|Size|Field|DataType|Description|
		|---|---|---|---|
		|33|PublicKey|ec_point|Clé publique du validateur|
		
		Cette transaction représente un formulaire d'inscription qui indique que le promoteur de la transaction voudrait s'inscrire en tant que validateur.
		
		La façon de s'inscrire est la suivante : construire une EnrollmentTransaction et envoyer un dépot à l'adresse de la clé publique.
		
		La façon d'annuler son inscription est de dépenser l'argent du dépot de l'adresse de la clé publique.
		
	+ RegisterTransaction
	
		> [!Attention]
		A été desactivé et remplacé par Neo.Asset.Create pour les contrats intelligents.
		
		Voir [Framework .NET Smart Contract alternatif](../sc/fw/dotnet/neo/Asset/Create.md).
		
		Voir [API Smart Contract alternative](../sc/api/neo.md).
		
	+ ContractTransaction
	
		Il n'y a pas d'attributs spéciaux pour une transaction de contrat. C'est un type de transaction très commun qui donne la possibilité à un porte-feuille d'envoyer des NEOs à un autre. Les champs de transactions `entrées` et `sorties` seront habutuellement important pour cette transaction (par exemple, pour contrôler combien de NEOs vont être envoyé et à quelle adresse).
		
	+ PublishTRansaction
	
		> [!Attention]
		A été désactivé et remplacé par Neo.Contract.Create pour les contrats intelligents.
		
		Voir [Framework .NET Smart Contract alternatif](../sc/fw/dotnet/neo/Asset/Create.md).
		
		Voir [API Smart Contract alternative](../sc/api/neo.md).
		
	+ Invoquer une transaction
	
		| Taille   | Champs     | Type de donnée    | Description              |
		| ---- | ------ | ------- | --------------- |
		| -    | -      | -       | Champs publiques pour les transactions        |
		| ?    | Script | uint8[] | Invoqué par un contrat intelligent     |
		| 8    | Gas    | int64   | Coût requis pour lancer le contrat intelligent |
		| -    | -      | -       | Champs publiques pour les transactions         |
		
1. Attributs d'une transaction

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|1|Usage|uint8|Utilisation|
	|0\|1|length|uint8|Taille de la donnée (les circonstances particulières seront omises)|
	|length|Data|uint8[length]|Données externes|
	
	Parfois la transaction va contenir quelques données pour un usage extérieur, ces données vont être placées dans le champs d'attributs de la transaction.
	
	Chaque attribut de transaction a un usage spécifique.
	
	|Valeur|Nom|Description|
	|---|---|---|
	|0x00|ContractHash|Valeur de hashage du contrat|
	|0x02-0x03|ECDH02-ECDH03|Clé publique pour un échange de clé ECDH|
	|0x20|Script|Validation additionnelle des transactions|
	|0x30|Vote|Pour le vote|
	|0x80|CertUrl|l'adresse url d'un certificat|
	|0x81|DescriptionUrl|l'adresse url d'une description|
	|0x90|Description|Courte description|
	|0xa1-0xaf|Hash1-Hash15|Utilisé pour enregistrer des valeurs de hash personnelles|
	|0xf0-0xff|Remark-Remark15|Remarques|
	
	Pour ContractHash, les séries ECDH, les séries Hash, la longueur des données est fixé à 32 octets et la longueur des champs est omise.
	
	Pour CertUrl, DescriptionUrl, Description, les séries de Remark, la longueur des données doit être clairement définie et la longueur ne doit pas dépasser 255;
	
1. Entrée d'une transaction

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|32|PrevHash|uint256|Hash de la transaction précédente|
	|2|PrevIndex|uint16|Index de la transaction précédente|
	
1. Sortie d'une transaction

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|32|AssetId|uint256|ID de l'asset|
	|8|Value|int64|Valeur|
	|20|ScriptHash|uint160|Adresse du destinataire|

	Chaque transaction peuvent avoir au maximum 65536 sorties.

1. Script de validation

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|?|StackScript|uint8[]|Code du script de la pile|
	|?|RedeemScript|uint8[]|Code du script du contrat|
   
	Le script de la pile peut seulement être utilisé pour une opération PUSH qui est utilisée pour pousser des données telles que les signatures dans la pile. L'interpréteur de script éxécutera le premier code de script de la pile et ensuite executera le code du script du contrat.
	
	Dans une transaction, la valeur de hashage du code de script de contre doit être consistant avec les sorties de transaction qui sont une partie de la validation. Dans une section prochaine, nous décrirons le processus d'éxécution du script en détail.
	
Messages du réseau
-------

Tous les messages du réseau sont envoyés selon cette structure :
	
|Taille|Champs|Type de donnée|Description|
|---|---|---|---|
|4|Magic|uint32|ID du protocol|
|12|Command|char[12]|Commande|
|4|length|uint32|Longueur de la charge utile|
|4|Checksum|uint32|Checksum|
|length|Payload|uint8[length]|Contenu du message|

Valeurs Magic définies

|Valeur|Description|
|---|---|
|0x00746e41|Mode production|
|0x74746e41|Mode test|

Command est un code UTF-8 qui a une longueur de 12 bytes, la partie restante disponnible est rempli avec des 0.

Checksum sont les 4 premiers bytes de la valeur de hashage de la charge utile qui a été passée deux fois dans la fonction SHA256.

Selon les ordres, Payload a différents formats détaillés :

1. version

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|4|Version|uint32|Version du protocol, 0 pour l'instant|
	|8|Services|uint64|Le service fourni par le noeud qui est actuellement 1|
	|4|Timestamp|uint32|Temps courant|
	|2|Port|uint16|Port que le serveur est en train d'écouter, 0 si non utilisé|
	|4|Nonce|uint32|Utilisé pour différencier le noeud d'une adresse IP publique|
	|?|UserAgent|varstr|ID du client|
	|4|StartHeight|uint32|Taille de la blockchain|
	|1|Relay|bool|Ou bien recevoir ou bien transférer|
	
	Quand un noeud reçoit une requète de connexion, il déclare sa version immédiatement. Il n'y aura pas d'autre communication temps que les deux cotés n'ont pas la même version.
	
1. verack

	Quand un noeud reçoit la version du message, il répond avec un verack immédiatement.
	
	Ce message n'a pas de charge utile.
	
1. getaddr

	Fait des requètes à un noeud pour un lot de nouveaux noeuds actifs dans le but d'augmenter le nombre de connexions.
	
	Ce message n'a pas de charge utile.
	
1. addr

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|30*?|AddressList|net_addr[]|Adresses des autres noeuds du réseau|
	
	Après avoir reçu le message getaddr, le noeud renvoit un message addr comme réponse et fournit les informations sur les noeuds connus du réseau.
	
1. getheaders

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|32*?|HashStart|uint256[]|Hash du bloque le plus ancien que le noeud a demandé|
	|32|HashStop|uint256|Hash du dernier bloque que le noeud a demandé|
	
	Fait des requètes à un noeud qui à plus de 2000 paquets d'en-tête de bloques qui contiennent HashStart et HashStop. Pour avoir le hash du bloque d'après, il faut renvoyer un message getheaders. Ce message est utilisé pour rapidement télécharger la blockchain qui ne contient pas de transactions.
	
1. headers

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|?*?|Headers|header[]|En-tête du bloque|
	
	Après avoir reçu le message getheaders, le noeud renvoit un message header comme réponse et fournit les informations concernant les noeuds connu du réseau.
	
1. getblocks

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|32*?|HashStart|uint256[]|Hash du bloque le plus ancien que le noeud a demandé|
	|32|HashStop|uint256|Hash du dernier bloque que le noeud a demandé|
	
	Fait des requètes à un noeuds dans l'optique de recevoir des messages inv qui commenceront de HashStart à HashStop. Le nombre de bloques qui commence de HashStart à HashStop peut aller jusque 500. Si il faut avoir plus de bloques que cela, il faut renvoyer un message getblocks.
	
1. inv

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|36*?|Inventories|inv_vect[]|Données des inventaires|

	Le noeud peut diffuser les informations de l'objet qu'il détient grâce à ce message. Le message peut être envoyé automatiquement ou peut être utilisé pour répondre à un message getblocks.

	Les informations de l'objet sont inclus dans cette liste :

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|4|Type|uint32|Type de l'objet|
	|32|Hash|uint256|Hash de l'objet|

	Type d'objets:

	|Valeur|Nom|Description|
	|---|---|---|
	|0x01|TX|Transaction|
	|0x02|Block|Bloque|
	|0xe0|Consensus|Données de consensus|
	
1. getdata

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|36*?|Inventories|inv_vect[]|Données des inventaires|
	
	Pour demander un objet spécifique à un noeud : c'est habituellement envoyé après qu'un packet inv ait été reçu et que l'élément connu a été éliminé.
	
1. block

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|?|Block|block|Bloque|
	
	Envoie un bloque à un noeud pour répondre à un message getdata.
	
1. tx

	|Taille|Champs|Type de donnée|Description|
	|---|---|---|---|
	|?|Transaction|tx|Transaction|

	Envoie une transaction à un noeud pour répondre à un message getdata.

	|Taille|Champs|Type de donnée|Description|
	|----|---------|--------- |----------------- |
	|32*?|HashStart|uint256[]|Noeud qui est connu comme le hash du bloque le plus ancien|
	|32|hashStop|uint256|Dmande le dernier bloque|
