# `getbalance`

Retorna o balanço de um dado ativo na carteira aberta.


> [!Note]
> Você precisa abrir a carteira no Neo-CLI antes de executar este comando


## Parâmetro

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
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

### Resposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
  "Balance": "1.01",
  "Confirmed": "1.01"
  }
}
```

#### Descrição da Resposta

  - `balance`: O balanço atual do ativo na carteira.
  - `confirmed`: A quantia exata do ativo na carteira, onde apenas quantias confirmadas podem ser utilizadas em transferências.

> [!Note]
> Os valores `balance` e `confirmed` podem não ser iguais. 
Isto acontece quando há uma transação de saída desse ativo da carteira, e o troco (retorno da quantia de ativo não transferida) ainda não foi confirmada; nesse caso o valor de `confirmed` será menor do que o de `balance`. Uma vez que o acordo é confirmado, ambos os valores terão o mesmo valor
