# NEO - Livre Blanc

Un réseau distribué pour une Smart Economy

## Objectif de NEO : la Smart Economy

Tout d’abord, le système NEO a pour objectif de numériser des actifs grâce à la technologie Blockchain et l'identité numérique. Il veut également rendre possible une Smart Economy dans un réseau distribué avec l'aide des contrats intelligents (Smart Contracts) pour que ces actifs numériques s'autogèrent d'elle-mêmes.

### Actifs numériques

Les actifs numériques sont des biens programmables qui existent sous forme de données électroniques. Avec la technologie de la Blockchain, la numérisation des actifs peut être décentralisée, digne de confiance, traçable, hautement transparente et sans intermédiaire. Sur la blockchain NEO, les utilisateurs sont capable d'enregistrer, d'échanger et de diffuser de multiples types d'actifs. Le lien entre les actifss numériques et physiques sont possible à travers l'identité numérique. En effet, les actifs enregistrés avec une identité numérique valide sont protégé par les lois.

NEO à deux formes d'actifs numériques : les actifs globaux et les actifs contractuels. Les actifs globaux peuvent être enregistrés dans l'espace-système et être identifiés par l'ensemble des contrats intelligents et des clients. Les actifs contractuels sont enregistrés dans un espace de stockage privé par un contrats intelligents et demande un client compatible pour les reconnaître. Ces derniers doivent rencontrer donc certains standards afin d'assurer la compatibilité avec la majorité des clients.

### Identité numérique

Une identité numérique fait référence aux informations relatives aux individus, aux organisations et aux autres entités qui peuvent exister sous une forme électronique. Le système d'identité numérique le plus abouti est basé sur le standard PKI (Public Key Infrastructure) X.509. Dans NEO, nous allons implémenter un ensemble d'identité numérique compatible avec le standard X.509. En addition au modèle d'émission de certificat compatible avec X.509, cet ensemble va aussi supporter le modèle d'émission de certificat Web Of Trust point-à-point. Notre vérification d'identité lors de l'émission ou de l'utilisation d'identités numériques inclura l'utilisation de la reconnaissance faciale, des empreintes digitales, de la voix, des SMS et autres authentification multi-facteur. Entre temps, nous aurons également remplacé le protocole de vérification de certificat en ligne (OCSP) par la blockchain pour gérer et enregistrer la liste de révocation de certificat X.509 (CRL).

### Contrat intelligent (Smart Contract)

Originellement, le contrats intelligent a été proposé au monde pour la première fois par le cryptographe Nick Szabo en 1994, seulement cinq ans après la création du World Wide Web. Selon la définition de Szabo : quand une condition préprogrammée est enclenchée, le contrat intelligent va exécuter les termes du contrat correspondants. La technologie blockchain nous fournit un système décentralisé, résistant aux crises et hautement fiable dans lesquelles les contrats intelligents seront extrêmement utiles. NEO a un système de contrats intelligents indépendant : NeoContract.

Le système « NeoContract » est la plus grosse fonctionnalité de l'écosystème de développement existant. Tout d’abord, les développeurs n'ont pas besoin d'apprendre un nouveau langage mais ont, de plus, la possibilité d'utiliser C#, Java et d'autres langages de programmation plus courants dans leur environnement favori (Visual Studio, Eclipse, etc.) pour développer, déboguer et compiler des contrats intelligents. La très légère machine virtuelle universelle de NEO, NeoVM, a l'avantage d’être d’une très grande fiabilité, une concurrence élevée et une haute évolutivité. Le système NeoContract donnera la possibilité aux millions de développeurs du monde entier de démarrer rapidement le développement de contrats intelligents. En fin, NeoContract aura un livre blanc séparé avec tous les détails de son implémentation.

### Application et écosystème

L'écosystème est le vivier de la communauté open-source. Afin d'atteindre l'objectif d'un réseau économique intelligent, NEO investira dans le développement de son écosystème en proposant des outils de développement complets, en améliorant la documentation, en organisant l'apprentissage via des activités d’entraînement et en pourvoyant un support financier aux membres de la communauté NEO. Nous avons pour objectif d'accompagner les futures applications basées sur NEO et son écosystème, et de récompenser les améliorations apportées à celui-ci.

🔹 **Applications de nœud (node)**

- Un programme client desktop complet

- Un programme client plus léger avec une meilleur expérience utilisateur

- Des clients Web, iOS et Android qui ne nécessite pas une synchronisation avec la blockchain

- Un portefeuille hardware

🔹 **Explorateur de blockchain**

🔹 **Software DDevelopment Kit**

- Support de Java / Kotlin, .NET C# / VB, JavaScript / TypeScript, Python, Go

🔹 **Compilateur de contrats intelligents et plugin pour IDE**

- C# / VB.Net / F#, Visual Studio

- Java / Kotlin, Eclipse

- C /C++ / Go

- JavaScript / TypeScript

- Python / Ruby

🔹 **Applications décentralisées (dApps)**

- Smart fund

- Contrat intelligent légal assisté par AI

- Réseau social

- Pourvoyeur de liquidité de token automatique

- Échanges décentralisés

- Protocole de communication sécurisée

- Marché d'échange de données

- Marché d'échange de propriété intellectuelle

- Marché de prédiction

- Marché publicitaire

- Marché de puissance de hash

- Marché de NeoGas

## Modèle de gestion de NEO

### Modèle économique

NEO possède deux tokens natifs, NEO (symbole : NEO) et NeoGas (symbole : GAS).

NEO, avec un total de 100 millions de tokens, représente les droits de gestion du réseau. Ceux-ci incluent le vote des bookkeepers, des changements de paramètre dans le réseau et bien plus encore. L'unité minimal de NEO est 1, il est indivisible.

GAS est le token carburant destiné à l’utilisation des ressources du réseau NEO, avec un maximum total de 100 millions aussi. Le réseau facture les opérations, le stockage de tokens et les contrats intelligents avec le GAS. De ce fait, des incitants économiques sont créés pour les bookkeepers et cela permet d'éviter les abus de ressources sur le réseau. L'unité minimale du GAS est 0.00000001.

Dans le bloque originel de NEO, 100 millions de NEO sont été généré, mais il n'y a pas encore de GAS générés. Les 100 millions de GAS, correspondant aux 100 millions de NEO, seront généré à travers un algorithme pendant 22 ans et par après transféré aux adresses possédant du NEO. Si les NEO sont transférés vers une nouvelle adresse, le GAS sera alors donné à cette nouvelle adresse.

Par vote, le réseau placera un seuil éviter le paiement en GAS pour un certain nombre de transferts et d'opérations de contrats intelligents pour améliorer l'expérience utilisateur. Quand une énorme quantité de spam de transaction se produit, NeoID pourra être utilisé pour donner la priorité aux transactions et aux contrats intelligents possédant des identités qualifiées. Les transactions et les contrats intelligents sans identités qualifiées peuvent avoir une priorité en payant du GAS.

### Mécanisme de distribution

Distribution du NEO :

Les 100 millions de token NEO sont divisés en deux parties. La première partie est divisé en 50 million de tokens et est distribué proportionnellement aux investisseurs du projet pendant le crowdfunding. Cette partie a déjà été distribuée.

La seconde partie est géré par le NEO Council afin de supporter le développement à long terme du réseau, les opérations, la maintenance et l'écosystème. Elle est bloquée pour une période de un an et sera débloquée après le 16 octobre 2017. Cette partie de NEO ne sera pas libérée dans les marchés d’échanges. Elle sera destiné qu'au support à long terme des projets de NEO. La démarche est la suivante :

🔹 10 million de tokens (10% du total) vont être utilisés pour motiver les développeurs NEO et les membres du NEO Council.

🔹 10 millions de tokens (10% du total) vont être utilisés pour inciter les développeurs à rentrer dans l'écosystème NEO.

🔹 15 millions de tokens (15% du total) vont être utilisés pour investir dans d'autres projets de blockchain qui sont détenu par le NEO Council et qui seront uniquement utilisés pour les projets NEO.

🔹 15 millions de tokens (15% du total) seront conservés pour gérer les imprévus.

🔹 L'utilisation annuelle de NEO ne devrait pas en principe excéder les 15 millions de tokens.

Distribution du GAS :

Le GAS est généré a chaque nouveau bloque crées dans la blockchain. Le montant initial du GAS est nul. Avec le taux de croissance de génération par nouveaux bloques, la limite total de 100 millions de GAS va être atteinte dans les environs de 22 ans. L’intervalle entre chaque bloque est de 15 à 20 secondes de ce fait deux millions de bloques seront créés chaque année.

Initialement, la génération de GAS initiale sera de 8 par bloque. Il y aura une réduction annuelle de 1 GAS par bloque conjointement avec l'écoulement des deux millions de bloques. La réduction va continuer chaque année pour atteindre 1 GAS par bloque et va rester à ce taux jusqu'au 22 ans annoncés. Après les 44 millions de bloques, le total de GAS générés aura atteint 100 millions d'unité et dès lors il n'y aura plus de génération de GAS lors de la création de nouveaux bloques.

Selon la courbe de génération de GAS, les 16 premiers % seront crées la première année, 52% les quatre premières années et 80% pendant les 12 premières années. Le GAS sera distribué proportionnellement au nombre de NEO détenu dans les adresses correspondantes. Les détenteurs de NEO peuvent réclamer leur GAS à n'importe quel moment sur leur adresse.

### Mécanisme de gouvernance

Gouvernance de la chaîne: les possesseurs de tokens NEO sont les propriétaires et les gestionnaires du réseau. Ils peuvent décider pour le réseau par votes et utiliser le GAS généré par leur NEO pour utiliser les fonctions du réseau. Les tokens NEO peuvent être transférés.

Gouvernance hors-chaîne: Le NEO Council se compose des membres fondateurs du projet NEO dans lequel le comité de gestion, le comité technique et le secrétariat sont responsable respectivement des décisions stratégiques, des décisions techniques et des implémentations spécifiques. Le NEO Council est responsable devant la communauté NEO pour la promotion et le développement de l’écosystème et ses objectifs premiers.

## Implémentation technologique de NEO

### Mécanisme de consensus distribué: dBFT

Le dBFT, le Delegated Byzantine Fault Tolerance, est un mécanisme de consensus qui tolère le problème des généraux byzantins et, de plus, qui permet une participation à grande échelle aux consensus à travers un système de vote. Le possesseur de NEO peut, grâce au vote, choisir le bookkeeper qu'il supporte. Par après, le groupe de bookkeepers sélectionné vont, à travers l'algorithme dBFT, atteindre des consensus pour générer les nouveaux bloques. Voter dans le réseau se fait en temps réel plutôt que par période fixe.

Le dBFT permet une tolérance à l'erreur maximum de f = (n-1) / 3 pour un système de consensus consistant à n nœuds. Cette tolérance à l'erreur inclut également la sécurité et la disponibilité, la résistance aux échecs généraux et aux échecs byzantins et est adapté à n'importe quel environnement réseau. Le dBFT conduit à une bonne finalité, les confirmations sont finales, c'est-à-dire qu'une fois confirmé, les bloques ne peuvent pas être modifiés, les transactions ne peuvent pas être annulées.

Dans le mécanisme de consensus de NEO dBFT, cela prend de 15 à 20 secondes pour générer un bloque, le débit de transaction est de 1.000 transactions par seconde ce qui est, bien entendu, une excellente performance pour une chaîne publique. Après quelques optimisations, il y aura un potentiel de 10.000 transacations/s. Ce qui permettra un support à grande échelle des applications commerciales.

Le dBFT se combine aux identités numériques, ce qui implique que les bookkeepers peuvent être des personnes réelles ou des institutions. En d'autres termes, il est possible des geler, de révoquer, d'hériter, de récupérer ou de transférer les possessions d'un bookkeeper en cas de décisions de justice contre eux. Cela facilitera l'enregistrement d'actifs financiers conformes dans le réseau NEO. De telles opérations sont prévu par le réseau si nécessaire.

### Le système de contrats intelligents: NeoContract

Ce système se compose de trois parties:

**NeoVM - Universal Block Chain Virtual Machine :**

NeoVM est une machine virtuelle légère à usage général avec une architecture vraiment proche de la JVM et de .NET Runtime. Elle est semblable à un CPU virtuel qui lit et exécute les instructions du contrat en séquences. Elle effectue un contrôle de procédure basé sur la fonction des opérations d'instructions, des opérations logiques, etc. De plus, elle possède une bonne vitesse de lancement et une certaine souplesse, ce qui est vraiment adapté aux petits programmes tels que les contrats intelligents. Elle peut également être utilisé dans un contexte hors de la blockchain ou être intégré à un IDE pour fournir la meilleur expérience de développement. Les fonctionnalités NeoVM peuvent être étendues par exemple par l'ajout d'une mécanisme JIT dans le but d'améliorer l’efficacité de l'implémentation.

**InteropService - Services interopérables :**

Utilisés pour charger le grand livre de la blockchain, les actifs numériques, les identités numériques, l'espace de stockage persistant et autres services sous-jacents sont comme des machines virtuelles qui assure le bon fonctionnement de la machine virtuelle. Ils permettent aux contrats intelligents d'accéder à des services à l’exécution pour accomplir différentes fonctionnalités avancées. A travers ce design de faible couplage, **NeoVM peut être porté dans n'importe quelle blockchain ou même des système hors-blockchain. Cela mène à une augmentation de l'utilité des contrats intelligents dans n’importe quel secteur.**

**DevPack - Compilateur et plugins IDE :**

Le DevPack fournit les compilateur pour les langages de haut-niveau et les plugins IDE. Parce que l'architecture de NeoVM est très similaire à JVM ou .NET Runtime, les compilateurs du DevPack peuvent compiler Java byte code et .NET MSIL dans un ensemble d'instructions de NeoVM. Java / Kotlin et C# développeurs n'ont donc pas besoin d'apprendre  de nouveaux langages et seront dès lors capable de commencer à développer instantanément des contrats intelligents dans Visual Studio, Eclipse ou d'autres IDE. **Cela réduit considérablement la courbe d'apprentissage du développement de contrats intelligents et va nous permettre de créer facilement une large communauté active autour de NeoContract.**

NeoContract peut créer un arbre d'appels de contrats intelligents à travers une analyse statique avant d’exécuter un contrat intelligent. **Avec cet arbre d'appels déterminé, un nœud NEO peut dynamiquement fragmenter un contrat intelligent pour en accomplir une expansion théoriquement illimitée**, ce qui permettra de surmonter l'effet de blocage causé par la fragmentation statique d'autres systèmes de blockchain.

### Entente multi-blockchain : NeoX

NeoX est un protocole qui implémente l'interopérabilité multi-blockchain. NeoX est divisé en deux parties:

- un protocole d'échange d'actifs multi-blockchain
- un protocole de transaction distribué multi-blockchain

**Protocole d'échange d'actifs multi-blockchain:**

NeoX a été étendu sur des protocoles d'échange d'actifs atomiques flexibles déjà existant pour permettre de multiples participants à échanger des actifs à travers différentes blockchains. NeoX leurs assure également que toutes les étapes du processus de transaction seront réussies entièrement ou au contraire échoueront de façon atomique. Dans le but d'accomplir cette fonction, nous avons besoin d'utiliser NeoContract pour créer un compte de contrat pour chaque participant. Si les autres blockchains ne sont pas compatible avec NeoContract, elles seront compatible avec NeoX aussi longtemps qu'elles pourvoient le fonctionnement de simples contrats intelligents.

**Protocole de transaction distribué multi-blockchain :**

Une transaction distribuée multi-blockchain signifie que les plusieurs étapes de la transaction sont dispersées dans les autres blockchains et que la consistance de la transaction entière est assurée. Ceci est une extension du premier protocole étendant le comportement des échanges d'actifs à un comportement arbitraire. Pour aller plus loin, NeoX rend possible les contrats intelligents multi-blockchain. Les différentes parties d'un contrat intelligent pourront être effectué sur plusieurs blockchains et être réussies ou annulées comme un tout. Cela donne donc d'excellentes possibilités pour des collaborations multi-blockchains. Par ailleurs, nous sommes actuellement en train d'explorer des scénarios d'application de contrats intelligents multi-blockchains.

### Protocole de stockage distribué : NeoFS

NeoFS est un protocole de stockage distribué qui utilise la technologie de table de hash distribué (Distribued Hash Table). NeoFS indexe les données dans un hash plutôt que dans une URI. Les gros fichiers seront divisés dans des bloques de données d'une taille fixe qui seront distribué et stocké dans une multitudes de nœuds différents.

Le principale problème de ce type de système est le besoin de trouver un équilibre entre la redondance et la fiabilité. NeoFS prévoit de résoudre cette contradiction aux moyens d’incitants économiques via les tokens et par l'établissement de nœuds pivots. Les utilisateurs pourront choisir le niveau de fiabilité du fichier. Les fichiers avec un faible niveau de fiabilité pourront être stocké gratuitement ou presque gratuitement. Les services stable et fiable pour les fichiers avec un haut niveau de fiabilité seront fournies par les nœuds pivots.

NeoFS servira comme service d'interopérabilité InteropService dans le système NeoContract, habilitant les contrats intelligents à enregistrer le grands fichiers dans la blockchain et permettre les accès à ces grands fichiers. Par ailleurs, NeoFS peut être associé aux identités numériques de tel sorte que les certificats numériques utilisés par les identités numériques peuvent être assignés, envoyés et révoqués sans un serveur central pour les gérer. Dans le futur, les données des vieux bloques pourront être stockées dans NeoFS afin que la plupart des nœuds puisse se libérer des vieilles données pour une meilleur évolutivité et en même temps assurer l'intégrité des données historiques.

### Mécanisme cryptographique anti-quantique: NeoQS

Avec l'émergence des ordinateurs quantiques, nous nous retrouvons face à des défis majeurs par rapport au chiffrement RSA et les mécanisme cryptographique basés sur ECC. Les ordinateurs quantiques peuvent résoudre un nombre très large de problèmes à décompositions (RSA) et de logarithme discrète à courbe elliptique (ECC) et ce avec un temps très cours. NeoQS (NÉO Quantum Safe) est un mécanisme cryptographique basé sur les treillis. Jusqu'à présent, les ordinateurs quantiques n'ont pas la capacité de résoudre rapidement les problèmes du vecteur le plus court (Shortest Vector Problems - SVP) et les problèmes du vecteur le plus proche (Closest Vector Problems - CVP). Ce mécanisme cryptographique est considéré actuellement comme l'algorithme le plus fiable pour résister aux ordinateurs quantiques.

## Résumé

NEO est un réseau distribué qui combine les actifs numériques, les identités numériques et les contrats intelligents. Le système NEO va utiliser le dBFT, NeoX, NeoFS, NeoQS et beaucoup d'autres technologies originales dans l'objectif de créer une infrastructure pour l'économie intelligente du future.
