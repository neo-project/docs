# getblock Method

Returns the corresponding block information according to the specified index.

## Parameter Description

Index: Block index (block height) = Number of blocks - 1.

Verbose: Optional, the default value of verbose is 0. When verbose is 0, the serialized information of the block is returned, represented by a hexadecimal string. If you need to get detailed information, you will need to use the SDK for deserialization. When verbose is 1, detailed information of the corresponding block in Json format string, is returned.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [10000],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "00000000e990d39e3ff75327e42c3459a4300b7f7d88ce8e00e98b05aa4f183aa515ce53294d136abf69e02f49fc43e002a31ba2c702e062d8683a559032a03b1e9e909c50b6065810270000455444dcd50f2caa59e75d652b5d3827bf04c165bbe9ef95cca4bf5501fd4501405e31eb19b1feaeb27c3a5b95f568b9b256fefe0ea61f6296eb8af836c29597617fe81d23a8bf66309000e4c7568b7f43560f61e4ee6cd1f78a2a42f50a5008c240ccf73ce9f7f810273730bdfc786d346086a697cc06239e88e040ed2ec0583c7dbb6eccb8b8a74afbd75cfbaff06c051b7e82abe65f96f50a1673e1536f91a3d540618e43cce18c7c91b54b2a5e44ba1e4a71a8dd0af0ec95c8c4f05343e66129b150057a5f79399a92eda1226fddd254702ffc682309787ab241509b2244e410334070a5ac50d897bf39f98780f79fb1a2416c41dc2e202b4ad797bd0c70e2b57f1157c4ff5551ec6df58bec6244dc72a3f25cd1836e8cdd4c0d8c2e5ba7e2d8859b40ae80743c9a2a8e154671eb156266971439a9017e96ea072c848287a71b2d6a99a67ba50fc7935a6de4d8884794291fc6cebd77158954ef03b10d5d0a30b52bc9f1552102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d67666 2d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae010000455444dc00000000 "
}
```

Request body:

Verbose = 1, returns the result in JSON format.

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [10000, 1],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "Hash": "4c1e879872344349067c3b1a30781eeb4f9040d3795db7922f513f6f9660b9b2",
    "Size": 686,
    "Version": 0,
    "Previousblockhash": "53ce15a53a184faa058be9008ece887d7f0b30a459342ce42753f73f9ed390e9",
    "Merkleroot": "9c909e1e3ba03290553a68d862e002c7a21ba302e043fc492fe069bf6a134d29",
    "Time": 1476834896,
    "Index": 10000,
    "Nonce": "aa2c0fd5dc445445",
    "Nextconsensus": "APyEx5f4Zm4oCHwFWiSTaph1fPBxZacYVR",
    "Script": {
      "Invocation": "405e31eb19b1feaeb27c3a5b95f568b9b256fefe0ea61f6296eb8af836c29597617fe81d23a8bf66309000e4c7568b7f43560f61e4ee6cd1f78a2a42f50a5008c240ccf73ce9f7f810273730bdfc786d346086a697cc06239e88e040ed2ec0583c7dbb6eccb8b8a74afbd75cfbaff06c051b7e82abe65f96f50a1673e1536f91a3d540618e43cce18c7c91b54b2a5e44ba1e4a71a8dd0af0ec95c8c4f05343e66129b150057a5f79399a92eda1226fddd254702ffc682309787ab241509b2244e410334070a5ac50d897bf39f98780f79fb1a2416c41dc2e202b4ad797bd0c70e2b57f1157c4ff5551ec6df58bec6244dc72a3f25cd1836e8cdd4c0d8c2e5ba7e2d8859b40ae80743c9a2a8e154671eb156266971439a9017e96ea072c848287a71b2d6a99a67ba50fc7935a6de4d8884794291fc6cebd77158954ef03b10d5d0a30b52bc9",
      "Verification": "552102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
    },
    "Tx": [
      {
        "Txid": "9c909e1e3ba03290553a68d862e002c7a21ba302e043fc492fe069bf6a134d29",
        "Size": 10,
        "Type": "MinerTransaction",
        "Version": 0,
        "Attributes":[],
        "Vin":[],
        "Vout":[],
        "Sys_fee": "0",
        "Net_fee": "0",
        "Scripts":[],
        "Nonce": 3695465541
      }
   ],
    "Confirmations": 981987,
    "Nextblockhash": "c9a32cd215837c02dd72613bfad6ed064579e77bafd859907f87b3e67fa498cc"
  }
}
```