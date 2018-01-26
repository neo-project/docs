# Réseau de test

TestNet est un environnement dans lequel les utilisateurs peuvent développer, commander et tester des programmes. Le test de programmes sur TestNet utilise comme frais de réseau des TestNet GAS (pas de GAS réel !!). TestNet NEO et TestNet GAS peuvent être demandés gratuitement sur le site officiel.

Toutes les blockchains du réseau de test sont indépendant du réseau principale. Si vous développez un simple contrat intelligent ou essayé d'enregistrer des actifs, l'utilisation de TestNet devrait suffir. Après que les tests accomplis, le développement peut être transférer sur le réseau principale de NEO, MainNet.

Si vous êtes développeur, vous pouvez demander du GAS pour TestNet, ici: https://www.neo.org/Testnet/Create

## Caractéristiques TestNet

1. Enregistrement d'actifs, distribution d'actifs, execution de contrats, etc. (N'utilise pas de monnaies réelles)
2. Déployement global dans un environnement Internet.
3. Tests des blocs du réseau; Les transactions et les autres informations peuvent être facilement visible dans le navigateur de la blockchain.
4. Le déployement de contrats intelligents dans l'environnement de test que tout le monde pourront utiliser.
5. Le réseau de test ne peut pas être utilisé pour des applications commerciales comme environnement définitif.

## Téléchargements des clients

Les clients des réseaux de test sont les mêmes que pour le réseau principale. Il suffit de changer le fichier de configuration du client.

Référence: [Introduction aux noeuds NEO](introduction.md)

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Site officiel](https://www.neo.org/download) or [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Codes sources | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Méthode pour utiliser le réseau de test

1. Copiez le contenu dans le répertoire du programme de `protocol.testnet.json` dans `protocol.json`.

![image](/assets/testnet_1.png)

2. Copiez le contenu dans le repertoire du programme  de `neo-gui.exe.testnet.config` dans `neo-gui.exe.config`.

![image](/assets/testnet_2.png)

Note: si le noeud tourne sur CLI, le contenu de `config.testnet.json` a besoin d'être copié dans `config.json`.