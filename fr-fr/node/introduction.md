# Introduction aux nœuds NEO

Les noeuds qui stockent la blockchain entière sont appelés "full-nodes" (en anglais « nœuds complets »). Ils sont connectés à la chaîne via un réseau P2P. Tous les nœuds du réseau de la chaîne de blocs sont égaux et agissent aussi bien en tant qu'interface client que comme serveur.

Il existe deux types de programme "full-node". Le premier détient toutes les fonctionnalités de bases d'un client utilisateur en plus d'avoir une interface graphique, c'est le Neo-GUI. Celui-ci est destiné à être utilisé par les utilisateurs de NEO. Le second s'appelle Neo-CLI, il permet l'utilisation d'une API externe pour les fonctionnalités basiques d'un portefeuille et est, quant à lui, plus destiné à être utilisé par les développeurs. Ce dernier permet par ailleurs d'aider les autres nœuds à assurer le consensus dans le réseau. Il est d'ailleurs impliqué dans la création des nouveaux blocs.

Le [protocole réseau](/en-us/network-protocol.md) de NEO fournira une API de bas niveau pour quelques transactions-types qui ne sont pas encore supportées par le CLI tels que la réclamation de jetons de GAS ou l'envoi de jetons NEO sans nécessiter d'avoir un portefeuille ouvert.

## Téléchargement des programmes nœuds NEO

|               | Neo-GUI                                           | Neo-CLI                                           |
| ------------- | ------------------------------------------------- | ------------------------------------------------- |
| Publications  | [Site officiel](https://www.neo.org/download) ou [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases)        |
| Code source   | [Github](https://github.com/neo-project/neo-gui)  | [Github](https://github.com/neo-project/neo-cli)  |

## Comparaison des fonctionnalités entre le programme GUI et le programme CLI

|                                                   | GUI  | CLI  |
| ------------------------------------------------- | ----- | ----- |
| Interface graphique                               | ✅    |      |
| Interface en ligne de commande                    |      | ✅    |
| Création de portefeuille                          | ✅    | ✅    |
| Ouverture de portefeuille                         | ✅    | ✅    |
| Reconstruction de l'index d'un portefeuille       | ✅    | ✅    |
| Affichage des paires de clefs                     | ✅    | ✅    |
| Import/Export d'une paire de clefs                | ✅    | ✅    |
| Affichage des adresses                            | ✅    | ✅    |
| Affichage des actifs                              | ✅    | ✅    |
| Création d'adresses                               | ✅    | ✅    |
| Transferts                                        | ✅    | ✅    |
| Transactions (échanges d'actifs)                  | ✅    |      |
| Création de contrat de signature multipartite     | ✅    |      |
| Création d'un constrat intelligent personnalisé   | ✅    |      |
| Signature                                         | ✅    |      |
| Election des nœuds de consensus                   | ✅    |      |
| Vote                                              | ✅    |      |
| Enregistrement d'actifs                           | ✅    |      |
| Distribution d'actifs                             | ✅    |      |
| Extraction de jetons NEO                          | ✅    |      |
| Génération d'adresses en lot                      |      | ✅    |
| JSON-RPC                                          |      | ✅    |
| Participation dans le consensus des blocs         |      | ✅    |

## Description des ports

Si vous souhaitez qu'un programme extérieur puisse accéder à l'API de nœud, un port doit être ouvert dans le pare-feu. Voici les différents ports qui peuvent être ouverts :

|                    | Main Net     | Test Net      |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Pour plus d'information, consultez [réseau de test](/en-us/testnet.md).
