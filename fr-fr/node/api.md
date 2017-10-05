# Référence API

Chaque noeud dans Neo-CLI donne accès à une interface API pour obtenir les données de la blockchain d'une node, cela rend le développement des applications blockchains beaucoup plus aisé. L'interface est fournie par [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html) et le protocol sous-jacent utilise HTTP/HTTPS pour communiquer. Pour démarrer un noeud qui donne accès au service RPC, entrez les inscriptions suivantes :

`dotnet neo-cli.dll /rpc`

Pour accéder au serveur RPC via HTTPS, vous avez besoin de modifier le fichier de configuration `config.json` avant de lancer le noeud et y indiquer le nom de domaine, le certificat et le mot de passe :

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```

Après le démarrage du serveur JSON-RPC, il va monitorer les ports suivants correspondant au réseau principale ou au réseau de test :

Pour avoir des informations sur le P2P ou les WebSocket, voir [Introduction aux noeuds NEO](introduction.md).


|                | MainNet | TestNet |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## Liste de commandes

| Commande                                    | Référence                               | Explication                         | Remarque       |
| ------------------------------------------- | --------------------------------------- | ----------------------------------- | -------------- |
| [getaccountstate](api/getaccountstate.md)   | \<address>                              | Retourne les informations sur les actifs d'un compte selon l'adresse du compte indiquée |         |
| [getassetstate](api/getassetstate.md)       | \<asset_id>                             | Demande les informations d'un actif selon l'ID de cet adresse spécifiée |         |
| [getbalance](api/getbalance.md)             | \<asset_id>                             | Retourne le solde des actifs correspondants dans le porte-feuille en fonction à l'ID de l'actif spécifié | Nécessite un porte-feuille ouvert   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Obtientle hash du plus grand bloc dans la chaîne principale          |          |
| [getblock](api/getblock.md)                 | \<hash> [verbose=0]                     | Retourne l'information du bloc correspondant à la valeur de hashage indiquée         |          |
| [getblock](api/getblock2.md)                | \<index> [verbose=0]                    | Retourne l'information du bloc correspondant à l'index indiqué         |          |
| [getblockcount](api/getblockcount.md)       |                                         | Obtient le nombre de blocs de la chaîne principale                 |          |
| [getblockhash](api/getblockhash.md)         | \<index>                                | Retourne la valeur de hashage correspondant au bloc de l'index indiqué         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                     | Obtient le nombre de connexion au noeud                 |          |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                          | Retourne les informations d'un contrat en fonction du hash de script du contrat |          |
| [getrawmempool](api/getrawmempool.md)       |                                         | Obtient le nombre de transaction non-confirmée en mémoire            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                   | Retourne les informations de la transaction correspondante basé sur la valeur de hashage spécifiée         |          |
| [getstorage](api/getstorage.md)             | \<script_hash>                          | Retourne la valeur stockée en fonction du hash de script du contrat et de la clé stockée |          |
| [gettxout](api/gettxout.md)                 | \<txid> \<n>                            | Retourne l'information de sortie de la transaction correspondante basé sur la valeur de hashage spécifiée et sur son index |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                              | Diffuse une transaction dans le réseau. Voir la documentation [Protocol du réseau](network-protocol.md).                     |          |
| [sendtoaddress](api/sendtoaddress.md)       | \<asset_id> \<address> \<value> [fee=0] | Transfert à l'adresse indiquée                    | Nécessite un porte-feuille ouvert   |
| submitblock                                 | \<hex>                                  | Soumet un nouveau bloc                      | Nécessite d'être un noeud de consensus |

## Exemple de requète GET

Le format typique de requète GET JSON-RPC se présente comme suit :

Par exemple, voici comment avoir le nombre de blocs dans la chaîne principale.

URL de la requète :

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Après avoir envoyé la requète, vous allez recevoir une réponse du type :

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## Exemplede requète POST

 Le format typique de requète POST JSON-RPC se présente comme suit :

Par exemple, voici comment avoir le nombre de blocs dans la chaîne principale.

URL de la requète :

```
http://somewebsite.com:10332
```

Corps de la requète :

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

Après avoir envoyé la requète, vous allez recevoir une réponse du type :

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## Outils de test

Vous pouvez utiliser l'extention de Chrome, Postman pour faire des tests. (L'installation d'une extention Chrome requière une connexion Internet). Voici une capture d'écran d'un test :

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Autres

[Liste des commandes JSON-RPC en C#](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)