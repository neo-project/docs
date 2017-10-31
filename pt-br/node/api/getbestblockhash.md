# `getbestblockhash`

Retorna a *hash* do bloco mais alto (recente) na *blockchain*.

Não possui parâmetros.


## Exemplo

### Requisição:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

### Resposta:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

#### Descrição da Resposta:

  - `result`: *hash* do bloco mais alto da *blockchain*
