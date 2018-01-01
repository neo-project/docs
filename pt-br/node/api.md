# Referência da API

Cada nó Neo-CLI oferece interface API para a obtenção de dados de um nó, facilitando o desenvolvimento de aplicações para a *blockchain*. Esta interface é provida via JSON-RPC e utiliza o protocolo HTTP/HTTPS para comunicação. Para iniciar um nó com serviço RPC, execute o seguinte comando:
```
dotnet neo-cli.dll /rpc
```

Para acessar o servidor RPC via HTTPS, é necessário alterar o arquivo de configuração `config.json` antes de inicializar o nó e configurar o nome de domínio, certificado e a senha:

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "Seu_arquivo_certificado_ssl.xxx",
    "SslCertPassword": "Sua_Senha"
  }
}                                          
```

Depois que o servidor JSON-RPC iniciar, ele irá monitorar as seguintes portas, correspondentes a rede principal (MainNet) e/ou a rede de teste (TestNet):

|                | Rede Principal (MainNet) | Rede de Teste （TestNet） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

Para informação P2P e WebSocket, acesse a [introdução](introduction.md).

## Funções API

| Comando                                       | Referência                                     | Descrição                         | Observação       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [dumpprivkey](api/dumpprivkey.md)          | \<address>                             |Retorna a chave privada da conta especificada   | Necessita abrir a carteira   |
| [getaccountstate](api/getaccountstate.md)          | \<hash>                             |Retorna o estado da conta   |
| [getassetstate](api/getassetstate.md)          | \<hash>                             |Retorna o estado do ativo   |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |Retorna o balanço na carteira do ativo especificado   | Necessita abrir a carteira    |
| [getbestblockhash](api/getbestblockhash.md) |                                         | Recebe a *hash* do bloco mais alto (recente) da *blockchain* principal     |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | Retorna a informação de bloco em função da *hash* |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | Retorna a informação de bloco em função do índice          |          |
| [getblockcount](api/getblockcount.md)    |                                         | Recebe o número de blocos da cadeia principal                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | Retorna a *hash* do bloco em função do índice         |          |
| [getblocksysfee](api/getblocksysfee.md)          | \<hash>            |Retorna a tarifa do bloco   ||
| [getconnectioncount](api/getconnectioncount.md) |                                         | Recebe o número de conexões do nó                 |          |
| [getcontractstate](api/getcontractstate.md)          | \<hash>        |Retorna o estado do contrato  |
| [getnewaddress](api/getnewaddress.md)          |                              | Cria uma conta padrão   | Necessita abrir a carteira    |
| [getpeers](api/getpeers.md)          |         | Retorna a lista de nós que estão conectados, desconectados ou com problemas  |
| [getrawmempool](api/getrawmempool.md)    |                                         | Recebe a lista de transações não confirmadas na memória            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | Retorna a informação da transação em função da sua *hash*         |          |
| [getstorage](api/getstorage.md)          | \<hash> \<key>                            |Retorna o valor de armazenamento em função da *hash* e da chave    |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | Retorna a informação da transação em função da *hash* e do índice  |          |
| [sendmany](api/sendmany.md)   |   \<asset> \<value> \<address>       | Permite realizar transferências por lote a diferentes contas   | Necessita abrir a carteira    |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | Transmite a mensagem de uma transação à rede. Veja a documentação do [protocolo de rede](network-protocol.md).                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | Transferir à carteira especificada                     | Necessita abrir a carteira    |
| [submitblock](api/submitblock.md)  | \<hex> | Envia novos blocos. Precisa ser um *nó de consenso* |
| [validateaddress](api/validateaddress.md)          | \<hash>                             |Valida a conta  |


## Exemplo de requisição GET

O formato típico de uma requisição GET JSON-RPC é ilustrado no exemplo.
A função `getblock` será usada para obter os números de blocos da cadeia principal.

URL de requisição:

```
http://algumwebsite:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Após enviar a requisição, você receberá a seguinte resposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```


## Requisição POST

O formato típico de uma requisição POST JSON-RPC é ilustrado abaixo.
A função `getblockcount` será usada para obter o bloco mais alto da cadeia principal.

URL:

```
http://nodo:10332
```

Corpo da requisição：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

Após enviar a requisição, você receberá a seguinte resposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```


## Ferramentas de testes

Você pode utilizar a aplicação para o Chrome, **Postman**, para facilitar os testes. 

<p align="center"><img src="/pt-br/assets/api_2.png"></p>

<p align="center"><img src="/pt-br/assets/api_3.jpg"></p>


## Extras

[Lista de comandos C# JSON-RPC](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)

