# `getblock`

Retorna a informação do bloco especificado pela sua *hash*.

## Parâmetros

`hash`: *hash* do bloco de interesse.

`verbose`: (Opcional) Seu valor é 0 por padrão. 
  - Quando `verbose` tem valor 0, a informação de bloco retornada é serializada, representada por uma *string* hexadecimal. Neste caso, para conseguir a informação detalhada é preciso utilizar o SDK para deserializar a *string*.
  - Quando `verbose` tem valor 1, a informação de bloco retornada é uma *string* no formato Json.

## Exemplo

### Requisão:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"],
  "id": 1
}
```

### Resposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "000000002deadfa82cbc4682f5800ec72a8d8bd6afa469af5b2de83a51d28795a893222816f8081bf1054136cca420f807f844a958b2dea482dfc99d2538ef9c77d13320f9263659d4220f00878f40bd841c552a59e75d652b5d3827bf04c165bbe9ef95cca4bf5501fd450140b514d8562ad3badac0e097a502a43c58e23c75029dad8ccdb3b1ce221067d73d5612950e38c7565d6b166ef62894399a6f152c38a1bdb8c7d3715f75f20c1c7340e443f55108c5eefd99f954e06b21e97a4f0cf64dbd4e52426c27f7046cd880d6a7b1a507131c39afa48b9cac16411d6f84ec2f0b5d9977e5f1e3ce760a127b31409b8a52714b37a3b0970a19b4fb2669d2aa41ea85e05e68dfb03a197d505282dd53846ca58b1457504c65759a9ceb8f84f5148dec71727e9c743e986092728174401862c08611338be8e352b9110b2bb6d11ce0485286d857162deb417f1cb920d6727f8e6edbe1b7fce8d9b122523d5b45cfd02ab1ca002a58e28c8903ad764a84409dfcbda69cef1164936212e8e5d91965c8a976dc8dbcb5ea7d2f2d2f0105dadb902924559fede016a1f76a2c7ab0ff89a6446b0c19c88375906c8b9eccb61bc1f1552102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d67666 2d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae010000878f40bd00000000 "
}
```

### Requisição:

> `verbose` = 1

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e", 1],
  "id": 1
}
```

### Resposta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "Hash": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e",
    "Size": 686,
    "Version": 0,
    "Previousblockhash": "282293a89587d2513ae82d5baf69a4afd68b8d2ac70e80f58246bc2ca8dfea2d",
    "Merkleroot": "2033d1779cef38259dc9df82a4deb258a944f807f820a4cc364105f11b08f816",
    "Time": 1496721145,
    "Index": 991956,
    "Nonce": "2a551c84bd408f87",
    "Nextconsensus": "APyEx5f4Zm4oCHwFWiSTaph1fPBxZacYVR",
    "Script": {
      "Invocation": "40b514d8562ad3badac0e097a502a43c58e23c75029dad8ccdb3b1ce221067d73d5612950e38c7565d6b166ef62894399a6f152c38a1bdb8c7d3715f75f20c1c7340e443f55108c5eefd99f954e06b21e97a4f0cf64dbd4e52426c27f7046cd880d6a7b1a507131c39afa48b9cac16411d6f84ec2f0b5d9977e5f1e3ce760a127b31409b8a52714b37a3b0970a19b4fb2669d2aa41ea85e05e68dfb03a197d505282dd53846ca58b1457504c65759a9ceb8f84f5148dec71727e9c743e986092728174401862c08611338be8e352b9110b2bb6d11ce0485286d857162deb417f1cb920d6727f8e6edbe1b7fce8d9b122523d5b45cfd02ab1ca002a58e28c8903ad764a84409dfcbda69cef1164936212e8e5d91965c8a976dc8dbcb5ea7d2f2d2f0105dadb902924559fede016a1f76a2c7ab0ff89a6446b0c19c88375906c8b9eccb61bc1",
      "Verification": "552102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
    },
    "Tx": [
      {
        "Txid": "2033d1779cef38259dc9df82a4deb258a944f807f820a4cc364105f11b08f816",
        "Size": 10,
        "Type": "MinerTransaction",
        "Version": 0,
        "Attributes":[],
        "Vin":[],
        "Vout":[],
        "Sys_fee": "0",
        "Net_fee": "0",
        "Scripts":[],
        "Nonce": 3175124871
       }
    ],
    "Confirmations": 20,
    "Nextblockhash": "0b08e2eeed05c70f27293521c47f7f60dfc29f9f299ae9909a8552a4a87db7a2"
  }
}
```
