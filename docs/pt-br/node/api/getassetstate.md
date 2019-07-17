# Método *getassetstate*

Consulta na rede o estado (informações) de ativos baseado na *hash* de identificação do ativo.


## Descrição do Parâmetro

`asset_id`: *id* do ativo.

*Id* dos ativos nativos da rede:
  - NEO: *c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b*
  - GAS: *602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7*

> [!Note]
> Em ativos não-nativos é a *id* da transação de registro do ativo, `RegistTransaction`

As *id*'s dos ativos podem ser consultadas com o comando `list asset` no [Neo-CLI](../cli.md).


## Exemplo		

### Requisição:

```json
{
  "jsonrpc": "2.0",
  "method": "getassetstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

### Resposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "id": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "type": "SystemShare",
        "name": [
            {
                "lang": "zh-CN",
                "name": "NEO"
            },
            {
                "lang": "en",
                "name": "NEO"
            }
        ],
        "amount": "100000000",
        "available": "100000000",
        "precision": 0,
        "owner": "00",
        "admin": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "issuer": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "expiration": 2000000,
        "frozen": false
    }
}
```

