# Método `getaccountstate`

Consulta informação de ativos do endereço de conta dado.


## Descrição de Parâmetros

Seu único parâmetro é a *hash* de endereço da conta a ser consultada:
  `Endereço de Conta`: Uma *string* de 34-bits, iniciando com o caracter *A*, como por exemplo *AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz*.

## Exemplo

### Requisição:

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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
        "script_hash": "1179716da2e9523d153a35fb3ad10c561b1e5b1a",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "94"
            }
        ]
    }
}
```

#### Descrição da Resposta:

  - `script_hash`: *hash* do script do contrato; No NEO, todas contas são "contas contrato"

  - `frozen`: indica se a conta está congelada

  - `Votes`: consulta a quantia de NEO que o endereço utilizou em votação

  - `balance`: balanço dos ativos do endereço

  - `asset`: *id* do ativo

  - `value`: quantia de ativos

