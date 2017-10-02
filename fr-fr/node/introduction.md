# Introduction aux noeuds (nodes) NEO

Les noeuds qui stockent la blockchain entière sont appelés "full-nodes" (noeuds complet). Ils sont connectés à la blockchain à traves un réseau P2P. Chacun des noeuds dans le réseau de la blockchain sont égaux et agissent aussi bien comme une interface client que comme un serveur.

Il existe deux types de programme "full-node". Le premier détient toutes les fonctionnalités de bases d'un client utilisateur en plus d'avoir une interface graphique, c'est le Neo-GUI. Celui-ci est destiné à être utilisé par les utilisateurs de NEO. Le second s'appelle Neo-CLI, il permet l'utilisation d'une API externe pour les fonctionnalités basiques d'un porte feuille et est, lui, plus destiné à être utilisé par les developpeurs. Ce dernier permettra, par ailleurs, aider les autres noeuds à accomplir le consensus dans le réseau et sera impliqué dans la création des nouveaux blocs.

Le [protocol réseau](network-protocol.md) de NEO fournira une API de bas niveau pour quelques transactions types qui ne sont pas encore supportées par le CLI tels que la réclamation du GAS ou l'envoi de NEO sans un porte-feuille (wallet) ouvert.

## Téléchargement des programmes noeuds NEO

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| Releases | [Official website](https://www.neo.org/download) or [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| Code source | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## Comparaison des fonctionnalités entre le programme GUI et le programme CLI

|           | GUI  | CLI  |
| --------- | ---- | ---- |
| Interface graphique | ✅    |      |
| Interface en ligne de commande |      | ✅    |
| Création de porte-feuille | ✅    | ✅    |
| Ouverture de porte-feuille | ✅    | ✅  |
| Reconstruction de l'index d'un porte feuille | ✅    | ✅    |
| Affichage des pairs de clefs | ✅    | ✅    |
| Import/Export d'une pair de clefs | ✅    | ✅    |
| Affichage des adresses | ✅    | ✅    |
| Affichages des actifs | ✅    | ✅    |
| Création d'adresses | ✅    | ✅    |
| Transferts | ✅    | ✅    |
| Transactions (échange d'actifs)  | ✅    |      |
| Création de contrat de signature multipartite | ✅    |      |
| Création d'un Smart Contract personnalisé | ✅    |      |
| Signature | ✅    |      |
| Election des noeuds de consensus | ✅    |      |
| Vote | ✅    |      |
| Enregistrement d'actifs | ✅    |      |
| Distribution d'actifs | ✅    |      |
| Extraction de NEO | ✅    |      |
| Génération d'adresses en lot  |      | ✅    |
| JSON-RPC |      | ✅    |
| Participation dans le consensus des blocs |      | ✅    |

## Description des ports

Si vous voulez qu'un programme extérieur puis accéder à l'API de noeud, un port doit être ouvert dans le pare-feu. Voici les différents ports qui peuvent être ouvert.

|                    | Main Net | Test Net |
| ------------------ | ------------ | ------------- |
| JSON-RPC via HTTPS | 10331        | 20331         |
| JSON-RPC via HTTP  | 10332        | 20332         |
| P2P via TCP        | 10333        | 20333         |
| P2P via WebSocket  | 10334        | 20334         |

Pour plus d'information, consultez [réseau de test](testnet.md).
