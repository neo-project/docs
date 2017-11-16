# Livre Blanc NEO

Un réseau distribué pour une Économie Intelligente.

## Concepts de NEO, Économie Intelligente

NEO représente l'usage d'une chaîne de blocs (en anglais « blockchain ») pour digitaliser des actifs, ainsi que l'utilisation de contrats intelligents (en anglais « smart contracts ») pour automatiser la gestion de ces actifs digitaux, dans le but de construire une "économie intelligente" reposant sur un réseau entièrement distribué.

### Les actifs digitaux

Les actifs digitaux sont des actifs programmables qui existent sous la forme de données numériques. Grâce à la chaîne de blocs, la digitalisation des actifs devient décentralisée, sure, traçable, hautement transparente, et sans intermédiaire. Sur la chaîne de blocs NEO, les utilisateurs peuvent enregistrer, échanger et faire circuler différents types d'actifs. Prouver la connection entre des actifs digitaux et des actifs physiques est rendue possible grâce à l'identité digitale. Les actifs enregistrés via une identité digitale certifiée sont protégés par la loi.

NEO a deux formes d'actifs digitaux: les actifs globaux et les actifs contractuels. Les actifs globaux peuvent être enregistrés dans l'espace système et peuvent être identifiés par tous les contrats intelligents, ainsi que par tous les clients. Les actifs contractuels sont enregistrés dans l'espace de stockage privé du contract intelligent et exigent un client compatible pour les reconnaître. Les actifs contractuels peuvent adhérer à un certain nombre de normes afin d'assurer leur compatibilité avec la plupart des clients.

### Les identités digitales

L'identité digitale fait référence aux informations sur l'identité des personnes physiques, morales, et aux autres entités qui existent sous forme numérique. Le système d'identification digital le plus mûr repose sur la norme ICP (Infrastructure à Clés Publiques) X.509. Au sein de NEO, nous allons implémenter une suite de normes d'identification digitale compatibles avec la norme X.509. Cette suite de normes d'identification digitale, s'ajoutant au modèle de délivrance en compatibilité avec le niveau requis par X.509, supportera de même le modèle de délivrance de certificat point-to-point (en français « point à point ») Web Of Trust. Notre vérification d'identité, lorsqu'elle est délivrée ou lorsqu'elle utilise des identités digitales, inclut l'utilisation des fonctionnalités liées à la reconnaissance faciale, d'empreintes digitales et vocales, par SMS et à d'autres méthodes d'authentification multi-facteurs. De même, nous ferons usage de la chaîne de blocs pour remplacer l'Online Certificate Status Protocol (OCSP, en français « protocole de vérification de certificat en ligne ») dans le cadre de la gestion et l'enregistrement de listes de révocation de certificats X.509 (CRL).

### Les contrats intelligents

Le contrat intelligent a d'abord été proposé par le cryptographe Nick Szabo, en 1994, soit seulement cinq ans après la création du World Wide Web. Selon la définition de Nick Szabo: lorsqu'une condition préprogrammée est déclenchée, le contrat intelligent exécute les termes relatifs aux contrat. La technologie des chaînes de blocs nous fournit un système décentralisé, inaltérable, et particulièrement fiable au sein duquel les contrats intelligents sont très utiles. NEO comprend un système indépendant de contrats intelligents: NeoContract.

Le système de contrat NeoContract est la fonctionnalité la plus importante car elle permet une intégration homogène avec l'écosystème de développeurs existant. Les développeurs n'ont pas besoin d'apprendre un nouveau language de programmation. Ils peuvent utiliser le C#, le Java ou un autre des languages de programmation dominants, au sein des IDE qui leurs sont familiers (Visual Studio, Eclipse, etc.), pour développer, débugger et compiler des contrats intelligents. NEO's Universal Lightweight Virtual Machine, NeoVM, a pour elle les avantages d'être particulièrement fiable, concurrente et extensible. Le système de contrats intelligents NeoContract va permettre à des millions de développeurs du monde entier de mener rapidement à bien le développement de contrats intelligents. NeoContract aura un livre blanc séparé décrivant l'implémentation en détail.

### Les applications et l'écosystème

L'écosystème est représenté par le dynamisme de la communauté open source. Afin d'accomplir l'objectif de bâtir un réseau économique intelligent, NEO sera engagé dans le développement de son écosystème, en fournissant des outils de développement, en publiant de la documentation, en organisant des activités de formation en d'apprentissage, et en apportant un support financier. Nous avons l'intention de soutenir, ainsi que de récompenser les améliorations apportées à leur conception et à leur expérience, les applications et l'écosystème NEO suivants:

🔹 **Les programmes de référence**

- Un programme PC de référence entièrement fonctionnel
- Un programme PC léger avec une meilleure expérience utilisateur
- Clients Web / Android / iOS qui n'ont pas besoin de synchronisation avec la chaîne de blocs
- Portefeuille en dur (en anglais « Hardware wallet »)

🔹 **L'explorateur de chaîne**

🔹 **Le SDK, kit de développement**

- Supporte Java / Kotlin, .NET C # / VB, JavaScript / Typescript, Python, Go

🔹 **Les compilateurs de Contrats Intelligents et les extensions d'IDE**

- C# / VB.Net / F#, Visual Studio
- Java / Kotlin, Eclipse
- C / C++ / GO
- JavaScript / TypeScript
- Python / Ruby

🔹 **Les applications décentralisées**

- Fonds d'actifs intelligent
- Contrats légaux "intelligents" assistés par de l'IA
- Réseaux sociaux
- Fournisseurs automatisé de liquidités adossées aux jetons
- Plateformes d'échange décentralisé
- Protocoles de communication sécurisé
- Marchés de l'échange de données
- Marchés de la propriété intellectuelle
- Marchés de la prédiction analytique
- Marchés de la publicité
- Marchés de la puissance de hachage (en anglais, « Hashpower »)
- Marchés de NeoGas

## Le modèle de gestion de NEO

### Le modèle économique

NEO a deux jetons natifs, NEO (symbole abrégé: NEO) et NeoGas (symbole abrégé: GAS).

NEO, avec un total de 100 millions de jetons, représente le droit de gérer le réseau. Les droits de gestion du réseau incluent le droit de vote pour élire les comptables, pour modifier les paramètres du réseau NEO, et cætera. Le minimum unitaire de NEO est égal à 1 et les jetons ne peuvent pas être subdivisés.

GAS représente le jeton "carburant" permettant de contrôler les ressources du réseau NEO, avec une limite totale fixée à 100 millions de jetons. Le réseau NEO fait payer des frais pour l'exploitation et le stockage des jetons et des contrats intelligents, créant ainsi une incentive économique pour les comptables tout en prévenant l'abus d'utilisation des ressources. Le minimum unitaire de GAS est égal à 0.00000001.

Lors de l'émission du bloc d'origine (en anglais, « genesis block ») du réseau NEO, 100 millions de NEOs ont été générés. Aucun de jeton de GAS n'avait encore été généré. 100 millions de jetons de GAS, correspondant aux 100 millions de NEO, seront générés via un algorithme déclinant sur une période d'à peu près 22 ans pour récompenser les porteurs de jetons NEO. Si les jetons de NEO sont transférés vers une nouvelle adresse, les jetons de GAS générés correspondants seront crédités sur la nouvelle adresse.

Le réseau NEO va définir un seuil, en votant, pour dispenser de frais en GAS un certain nombre de transactions de transfert, et d'opérations portant sur les contrats intelligents. Lorsqu'un nombre important de transactions indésirables se produit, NeoID peut être utilisé pour prioriser les transactions et contrats intelligents portant sur des identités certifiées. Les transactions et contrats intelligents qui ne portent pas sur des identités digitales certifiées peuvent obtenir cette priorité en payant via des jetons de GAS.

### Le mécanisme de distribution

**La distribution des jetons de NEO:**

Les 100 millions de jetons NEO sont divisés en deux portions.

La première portion de 50 millions de jetons a été distribuée de manière proportionnelle aux participants de l'opération de financement participatif. Cette opération a eu lieu entre août et septembre 2016 (Neo était appelé Antshares à cette époque).

La seconde partie de 50 millions de jetons est gérée par le Conseil d'administration de NEO pour soutenir le développement, le fonctionnement, la maintenance et l'écosystème de NEO sur le long-terme. Les jetons NEO faisant partie de cette seconde portion ont été bloqués pour une période d'un an avant d'être débloqué le 16 octobre 2017. Cette seconde partie ne sera pas injectée sur les marchés d'échange et est exclusivement consacrée au soutien des projets NEO sur le long-terme, selon le programme suivant:

🔹 10 million de jetons (10% du total) seront dépensés pour motiver les développeurs et membres du Conseil d'administration de NEO.

🔹 10 million de jetons (10% du total) seront dépensés pour motiver les développeurs au sein de l'écosystème NEO.

🔹 15 million de jetons (15% du total) seront dépensés pour inter-investir avec d'autres projets de chaînes de blocs, lesquels seront détenus par le Conseil d'administration de NEO et exclusivement utilisés pour des projets NEO.

🔹 15 million de jetons (15% du total) seront retenus en tant que fond de prévention.

🔹 Par principe, la dépense annuelle de jetons NEO se doit de ne pas dépasser les 15 millions de jetons.

**La distribution des jetons de GAS:**

Le GAS est généré par chaque nouveau bloc créé. Le montant total initial de GAS était de zéro. Avec l'augmentation progressive du taux de génération de nouveaux blocs, la limite du nombre totale de jetons de GAS, fixée à 100 millions, sera atteinte d'ici à peu près 22 ans. L'intervalle de génération de chacun des blocs est d'environ 15 à 20 secondes, et à peu près 2 millions de blocs sont générés en une année.

Chaque année, à peu près 2 millions de blocs seront générés et la génération de jetons de GAS initiale était de 8 par bloc. Il y aura une réduction annuelle d'1 jeton de GAS généré par bloc, concordant avec chaque passage de 2 millions de blocs supplémentaires générés. La réduction continuera jusqu'à atteindre 1 GAS par bloc et sera maintenue à ce taux pour à peu près 22 ans. Lorsque le 44 millionième bloc sera généré, le nombre total de jetons de GAS généré aura donc atteint la limite de 100 millions et, à partir de cet instant, il n'y aura plus aucune émission de jetons de GAS durant la génération des blocks suivants.

Selon cette courbe d'émission, 16% des jetons de GAS seront créés durant la première année, 52% durant les quatre premières années, et 80% durant les premières 12 années. Ces jetons de GAS seront distribués à chaque adresse enregistrée en proportion du taux de jetons NEO détenus par chacune des ces adresse. Les porteurs de jetons de NEO peuvent initier une transaction de réclamation (en anglais, « claim transaction ») à n'importe quelle moment pour récupérer ces jetons de GAS sur chacune de leurs adresses.

### Le mécanisme de gouvernance

La gouvernance de chaîne: les porteurs de jetons NEO sont les propriétaires et gestionnaires du réseau, gérant le réseau grâce à leurs votes, dépensant le GAS généré à partir de leurs jetons NEO pour se servir des fonctionnalités du réseau. Les jetons NEO peuvent être transférés.

La gouvernance hors chaîne: le Conseil d'administration de NEO (en anglais, « NEO Council ») est composé des membres fondateurs du projet NEO, sous lequel le comité de gestion, le comité technique et le secrétariat, sont responsables, respectivement, des prises de décisions stratégiques, techniques et de leur implémentation. Le Conseil d'administration de NEO est quant à lui responsable, en priorité, de la promotion et du développement de l'écosystème NEO.

## Les implémentations de la technologie NEO

### Le mécanisme de consensus: dBFT

Le dBFT désigne le Delegated Byzantine Fault Tolerant (en français, « tolérance aux pannes byzantines déléguées »), un mécanisme de consensus qui permet une prise de participation à grande échelle, au travers d'un scrutin proxy (en anglais, « proxy voting »). Le porteur de jetons NEO peut, en votant, choisir le comptable qu'il soutient. Le groupe de comptables élus, au travers de l'algorithme BFT, atteint un consensus et génère de nouveaux blocs. Voter sur le réseau NEO est un processus continu, en temps réel, et non pas basé sur des mandats fixés.

Le dBFT fournit une tolérance aux pannes correspondante à `f = ⌊ (n-1) / 3 ⌋` pour un système de consensus donné comportant `n` nœuds. Cette tolérance de panne incorpore une sécurité et une disponibilité importantes, résistant aux pannes générales et byzantines, et elle convient à tout environnement réseau. dBFT assume un caractère définitif, signifiant qu'une fois les confirmations finales, le bloc ne peut être dévié, et la transaction ne peut être révoquée ou annulée.

Au sein du mécanisme de consensus dBFT, chaque bloc étant généré en 15 à 20 secondes, le débit de transactions s'élève à peu près à 1 000 TPS, ce qui représente une excellente performance parmi les chaînes publiques. Au moyen d'optimisations appropriées, il est potentiellement possible d'atteindre les 10 000 TPS, rendant possible le support d'applications professionnelles à très grande échelle.

Le dBFT est combiné avec la technologie d'identification digitale, impliquant que les comptables peuvent être le nom réel de personnes physiques ou morales. Par conséquent, il est possible de geler, révoquer, récupérer, et approprier les transferts à la suite de décisions judiciaires les concernant. Cela facilite l'enregistrement d'actifs financiers légalement conformes sur le réseau NEO. Le réseau NEO planifie de soutenir ces opérations lorsque cela deviendra nécessaire.

### Le système de contrat intelligent: NeoContract

Le système de contrat intelligent de NEO est composé de trois parties:

**NeoVM - Machine virtuelle de chaîne de bloc universelle:**

NeoVM est une machine virtuelle universelle et légère dont l'architecture est très proche des environnements d'exécution JVM et .NET. Elle est analogue au processeur virtuel qui lit et exécute les instructions d'un contrat de manière séquentielle, réalise des contrôles de processus en fonction des opérations (logiques ou autres) de l'instruction. Elle jouit d'une bonne vitesse de démarrage et d'une bonne polyvalence. Elle est très adaptée aux petits programmes, comme les contrats intelligents, et peut être portée sur des systèmes non-chaînés, ou même intégrée à l'IDE pour procurer une expérience de développement optimale. Les fonctionnalités de NeoVM peuvent être étendues, en introduisant, par exemple, un mécanisme de compilation à la volée (JIT), améliorant de fait l'efficacité de l'implémentation.

**InteropService - Services interopérables:**

Ces services sont utilisés pour charger le grand livre (en anglais, « ledger »), les actifs digitaux, l'identité digitale, le stockage persistant, ainsi que d'autre services sous-jacents. Ils sont assimilables aux machines virtuelles qui sont fournis pour les machines virtuelles elles-mêmes, permettant aux contrats intelligents d'accéder à ces services durant la période d'exécution pour proposer des fonctionnalités avancées. Au travers de concept de couplage faible, **NeoVM peut être porté vers n'importe quelle chaîne de bloc, ou même système non chaîné, augmentant de fait l'utilité des contrats intelligents**.

**DevPack - Compilateur et extension d'IDE:**

DevPack comporte un compilateur de language haut niveau et une extension d'IDE. Du fait que l'architecture NeoVM est très semblable aux environnements d'exécution JVM et .NET, les compilateurs DevPack peuvent compiler du bytecode Java et du CIL .NET en suite d'instructions NeoVM. Les développeurs Java / Kotlin et C# n'ont pas besoin d'apprendre de nouveaux languages et seront capable de démarrer immédiatement à développer des contrats intelligents sous VS, Eclipse ou tout autre IDE familier. **Cela réduit considérablement la courbe d'apprentissage liée au développement de contrats intelligents, nous permettant de développer aisément une ardente communauté autour des NeoContracts.**

NeoContract peut créer un arbre d'appels au contrat intelligent via l'analyse statique avant d'exécuter un contrat intelligent. **Grâce à l'arbre d'appels déterministes, un nœud NEO peut fragmenter dynamiquement un contrat intelligent pour théoriquement atteindre une expansion illimitée**, ce qui surmonte "l'effet d'encombrement" causé par la fragmentation statique sur d'autres systèmes de chaîne de blocs.

### L'accord d'interopérabilité inter-chaîne: NeoX

NeoX est un protocole implémentant l'interopérabilité inter-chaîne. NeoX est divisé en deux parties: le "protocole inter-chaîne d'échange d'actifs" (en anglais, « cross-chain assets exchange protocol »), et le "protocole inter-chaîne de transaction distribué" (en anglais, « cross-chain distributed transaction protocol »).

**L'accord inter-chaîne d'échange d'actifs:**

NeoX a été étendu à partir du protocole existant d'échange atomique d'actifs en double-échecs (en anglais, « double-stranded atomic assets exchange protocols ») pour permettre à plusieurs participants d'échanger des actifs entre différentes chaînes tout en s'assurant que la totalité des étapes de la transaction réussissent ou échouent de manière homogène. Afin d'accomplir cette fonction, nous devons utiliser la fonction NeoContract pour créer un compte de contrat pour chacun des participants. Si d'autres chaînes de bloc ne sont pas compatibles avec NeoContract, elles peuvent être compatibles avec NeoX à partir du moment où elles fournissent simplement une fonctionnalité de contrat intelligent.

**Le protocole inter-chaîne de transaction distribuée:**

Une transaction distribuée inter-chaîne représente une transaction dont les différentes étapes sont dispersées parmi différentes chaînes de bloc mais dont la consistence est assurée. C'est une extension de l'échange d'actifs inter-chaîne, assurant ainsi un comportement arbitraire aux échanges d'actifs. En termes plus simples, NeoX rend les contrats intelligents inter-chaîne possibles, ces contrats intelligents pouvant réaliser différentes opérations sur plusieurs chaînes tout assurant soit une réussite, soit un échec global. Cela ouvre d'excellentes possibilités pour des collaborations inter-chaîne. Nous sommes d'ailleurs en train d'explorer différents scénarios d'application des contrats intelligents inter-chaîne.

### Le protocole de stockage distribué: NeoFS

NeoFS est un protocole de stockage distribué qui est fondé sur la technologie des tables de hachage distribuée (DHT). NeoFS génère un index des données via un hachage du contenu des fichiers plutôt que via leur chemin (URI). Les fichiers de taille importante seront d'abord segmentés en blocs de données de taille fixe, puis répartis et stockés sur différents nœuds.

Le problème principal avec ce type de système est le besoin de trouver un équilibre entre redondance et fiabilité. NeoFS compte résoudre ce paradigme grâce aux incitations sous forme de jetons et à l'établissement de nœuds principaux (en anglais, « backbone nodes »). Les utilisateurs peuvent choisir le niveau de fiabilité désiré pour chaque fichier. Les fichiers dont la fiabilité requise est faible peuvent être stockés et lu gratuitement ou presque gratuitement. A l'opposé les services particulièrement stables gérant des fichiers nécessitant un haut degré de fiabilité seront fournis par les nœuds principaux.

NeoFS servira en tant qu'un des services d'interopérabilité InteropService sous le système NeoContract, permettant aux contrats intelligents de stocker des fichiers de taille très importante sur la chaîne de bloc et de définir l'accès à ces fichiers. En outre, NeoFS peut être combiné aux identités digitales pour permettre aux certificats digitaux utilisés par les identités digitales d'être assignés, envoyés, et révoqués, sans nécessiter un serveur central pour les administrer. Dans l'avenir, les anciens bloc de données pourront être stocké in NeoFS, de manière à ce que la plupart des nœuds complets puissent libérer les données précédentes pour assurer une meilleure scalabilité tout en maintenant l'intégrité de l'historique des données.

### Mécanisme cryptographique anti-quantique: NeoQS

L'émergence des ordinateurs quantiques pose un défi majeur aux mécanismes cryptographiques basés sur le RSA et l'ECC. Les ordinateur quantiques peuvent résoudre un très grand nombre de problèmes de décomposition (sur lesquels RSA repose) et de logarithme discret sur une courbe elliptique (sur lesquels ECC repose) en un temps très bref. À l'heure actuelle, les ordinateurs quantiques n'ont pas la capacité de résoudre rapidement le problème du plus court vecteur (SVP) ni celui du plus proche vecteur (CVP), qui est considéré comme l'algorithme le plus fiable pour résister aux ordinateurs quantiques.

## En bref

NEO est un réseau distribué qui combine actifs digitaux, identités digitales et contrats intelligents. L'écosystème NEO utilisera DBFT, NeoX, NeoFS, NeoQS et beaucoup d'autres technologies originales comme infrastructure pour architecturer l'économie intelligente du futur.
