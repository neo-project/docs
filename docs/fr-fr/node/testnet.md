# Réseau de test

Le TestNet (réseau de test, en anglais) est un environnement dans lequel les utilisateurs peuvent développer, assigner et tester des programmes. Le test de programmes sur le TestNet nécessite le paiement des frais de réseau en GAS du TestNet (à ne pas confondre avec le GAS du réseau principal !!). On peut obtenir des NEO et GAS propres au TestNet sans frais, depuis le site web officiel de NEO. Les instructions détaillées suivent ci-dessous.

Toutes les _blockchains_ (chaînes de blocs) du réseau de test sont indépendantes du réseau principal. Si vous programmez un simple _Smart Contract_ (contrat intelligent) ou essayez d'enregistrer des actifs, l'utilisation du TestNet devrait suffire. Une fois vos tests effectués, le développement peut être transféré sur le MainNet, le réseau principal de NEO.

## Possibilités offertes par le TestNet

1. Enregistrement d'actifs, distribution d'actifs, exécution de contrats, etc. (N'utilise pas d'actifs réels)
2. Déploiement global sur Internet.
3. Test des blocs du réseau: les transactions et autres informations peuvent être visualisées facilement sur le navigateur de la blockchain.
4. Déploiement de Smart Contracts dans l'environnement de test, accessibles au monde entier.
5. Le TestNet **ne peut pas** être utilisé pour des applications commerciales en phase de production.

## Téléchargement de clients TestNet

Les clients des réseaux de test sont les mêmes que pour le réseau principal. Il suffit de changer des fichiers de configuration sur ces clients.

Référence: [Introduction aux nœuds NEO](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Publications | [Site officiel](https://www.neo.org/download) ou [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Code source | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Méthode pour passer sur le réseau de test

1. Copiez le contenu du fichier `protocol.testnet.json` dans le fichier `protocol.json`.

![image](/assets/testnet_1.png)

2. Copiez le contenu du fichier `config.testnet.json` dans le fichier `config.json`.

![image](/assets/testnet_2_v2.png)

Note: pour revenir au MainNet, vous feriez la même chose à partir des fichiers `*.mainnet.json`.

## Méthode pour obtenir des GAS et NEO pour le TestNet

Si vous êtes un(e) programmeur(se), vous pouvez demander des NEO et GAS pour le TestNet. Le coût de déploiement d'un contrat est de 500 GAS du TestNet.

- Remplissez le formulaire de demande (https://www.neo.org/Testnet/Create) en précisant votre clé **publique** et votre email.
- A peu près un jour plus tard vous recevrez un email avec l'addresse d'un contract et une deuxième clé publique.
- Créez/Ajoutez une adresse à signatures multiples (_multi-sig_) à votre portefeuille.
- Sélectionnez la nouvelle adresse et transférez vos actifs depuis l'adresse à signatures multiples vers votre propre adresse.

### ETAPE 1 - Trouvez votre clé publique

Avec NEO, l'adresse et la clé publique sont deux choses différentes.
La clé publique est affichée quand vous visualisez la clé privée. (Attention, ne partagez **jamais** votre clé privée.)

  ![image](/assets/neo_gas_0.jpg)

### ETAPE 2 - Remplissez la demande

Complétez le formulaire ici: https://www.neo.org/Testnet/Create en précisant votre email et clé plublique.
A peu près un jour plus tard vous recevrez un email avec une addresse à signatures multiples, et la clé publique de l'expéditeur. Se référer à Fonctionalités Avancées, Addresses à Signatures Multiples.

### ETAPE 3 - Créer une adresse à signatures multiples

Pour accéder aux actifs, dans Neo-GUI vous allez créer une addresse Multi-Sig (à signatures multiples) dans votre portefeuille en utilisant:
- L'adresse à signatures multiples qui vient de l'email que vous avez reçu
- L'adresse publique de l'expéditeur de l'email
- Votre adresse publique (voir ETAPE 1 ci-dessus)

1. Avec NEO-GUI, faites un clic droit sur le compte puis sélectionnez `Create Contract Add.` (en français, créer l'adresse d'un contrat) -> `Multi-Signature...`.

  ![image](/assets/neo_gas_1.jpg)

2. Dans la liste de clés publiques, entrez les clés publiques qui ont été utilisées pour la signature (celles de l'expéditeur et la votre).
3. Réglez le nombre minimal de signatures à `1`.
4. Confirmez en cliquant sur `confirm`.

L'adresse de contrat spécifiée dans l'email est créée et affichée dans la page du compte.

![image](/assets/neo_gas_2.jpg)

Vous pourrez voir la quantité de NEO et/ou de GAS aux côtés de l'addresse du contrat.

### ETAPE 4 - Transférer les actifs vers un autre compte

1. Sélectionnez l'adresse du contrat en cliquant dessus.

2. Depuis le menu de NEO-GUI, sélectionnez `Transaction` -> `Transfer...` (transfert).

![image](/assets/neo_gas_3.png)

3. Sélectionnez l'actif et la quantité à envoyer et le compte vers lequel vous souhaitez faire un transfert.

## Alternatives au réseau de test

Tester votre Smart Contract sur le TestNet est une bonne idée avant de le publier sur le réseau principal, mais plus tôt dans votre cycle de développement vous devriez considérer d'autres méthodes de test comme :
- Utiliser Neo.VM, si vous programmez en C# avec Visual Studio
- Faire tourner votre propre TestNet privé
