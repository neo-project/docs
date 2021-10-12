# findstates Method

Queries the desired state by the root hash, contract hash and storage key prefix.

> [!Note]
>
> You must install the plugin  [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameters

- roothash: The root hash of state root.

- scripthash: The contract hash。

- prefix: The prefix of storage key, Base64-encoded.

- key: Optional. Returns the Base64-encoded key at the start of the result, with no information about the key in the result, but the result after the key.

- count: Optional. The count of returned items. 

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "findstates",
  "params": ["0xec31cdb14da4143e2ab471a8b5812d895b88fc1c12d54e112791491feca9b5f4","0xb1fbb6b0096919071769906bb23b2ca2ec51eea7","AQE="],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "firstProof": "GgEAAAABAUzxBIiQG4dVg53aSJGZBdc4jzffBlIAA1GZMg/ZG96bUUsFRwyZwD2mw/kkKd2sO8mj7AKs5yqSBAQEBAQEBAQEBAQEBAQD7/elUnvysLKgzT96xy6wwZj/emziL98I1kf1UZgNIsYELQEKAQAAAAAAAAABAAO32triSNLXJubm+sBN+lbYosN3ykl8iVUmREj0hO1Nz1IABAPvApR7HUrwQUO/FoEXpWnHnHz2vpsMk8DT2doV1Nwh4APoOjR3pJ5Jj/b9thBymJT96iVJNfZdb96z4YvP/3ZEuQQEBAQEBAQEBAQEBAQEcgAEBAQEAwAYKOMRzay9vdMnNqVdYCCprUSQAEgueNtFRhLxHcJeBAPKdsd3M5d1JSsULlc92k9tg9XpPUcGYzHY+jSRwlM+RwQEBAQEBAQDb3OGKsDYwWrvEw3gfTb9UipoBFZ9I8pYS8ntV4wAM6oEBEoBJwwPAQAECAgJAAELCAcFBQgDCQ0NCgQICQEJCQAFDQcDCAgPAwcNDwPqBPR7WXK0bOm5grD7JqZG1o8ymVny67eCX22yIybAzAYCBJzCeAE=",
        "lastProof": "GgEAAAABAe7wFiVtSpzngy2v5Lv6LQCPkn8uBlIAA1GZMg/ZG96bUUsFRwyZwD2mw/kkKd2sO8mj7AKs5yqSBAQEBAQEBAQEBAQEBAQD7/elUnvysLKgzT96xy6wwZj/emziL98I1kf1UZgNIsYELQEKAQAAAAAAAAABAAO32triSNLXJubm+sBN+lbYosN3ykl8iVUmREj0hO1Nz1IABAPvApR7HUrwQUO/FoEXpWnHnHz2vpsMk8DT2doV1Nwh4APoOjR3pJ5Jj/b9thBymJT96iVJNfZdb96z4YvP/3ZEuQQEBAQEBAQEBAQEBAQEcgAEBAQEAwAYKOMRzay9vdMnNqVdYCCprUSQAEgueNtFRhLxHcJeBAPKdsd3M5d1JSsULlc92k9tg9XpPUcGYzHY+jSRwlM+RwQEBAQEBAQDb3OGKsDYwWrvEw3gfTb9UipoBFZ9I8pYS8ntV4wAM6oEBEoBJw4PAAEGAgUGDQQKCQwOBwgDAg0KDw4ECwsPCgINAAAIDwkCBw8CDgOpMv0n0GGU2BoUUydwQJcc1bzfrOCWmTdbjX56GFcBagcCBZzq4+8A",
        "truncated": false,
        "results": [
            {
                "key": "AQFM8QSIkBuHVYOd2kiRmQXXOI833w==",
                "value": "nMJ4AQ=="
            },
            {
                "key": "AQFmmdXxSKUGNq3wQcppLAdAe8sD+g==",
                "value": "yGJI4+cA"
            },
            {
                "key": "AQHu8BYlbUqc54Mtr+S7+i0Aj5J/Lg==",
                "value": "nOrj7wA="
            }
        ]
    }
}
```

Request body:
```json
{
  "jsonrpc": "2.0",
  "method": "findstates",
  "params": ["0xec31cdb14da4143e2ab471a8b5812d895b88fc1c12d54e112791491feca9b5f4","0xb1fbb6b0096919071769906bb23b2ca2ec51eea7","AQE=","AQFM8QSIkBuHVYOd2kiRmQXXOI833w==",2],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "firstProof": "GgEAAAABAWaZ1fFIpQY2rfBBymksB0B7ywP6BlIAA1GZMg/ZG96bUUsFRwyZwD2mw/kkKd2sO8mj7AKs5yqSBAQEBAQEBAQEBAQEBAQD7/elUnvysLKgzT96xy6wwZj/emziL98I1kf1UZgNIsYELQEKAQAAAAAAAAABAAO32triSNLXJubm+sBN+lbYosN3ykl8iVUmREj0hO1Nz1IABAPvApR7HUrwQUO/FoEXpWnHnHz2vpsMk8DT2doV1Nwh4APoOjR3pJ5Jj/b9thBymJT96iVJNfZdb96z4YvP/3ZEuQQEBAQEBAQEBAQEBAQEcgAEBAQEAwAYKOMRzay9vdMnNqVdYCCprUSQAEgueNtFRhLxHcJeBAPKdsd3M5d1JSsULlc92k9tg9XpPUcGYzHY+jSRwlM+RwQEBAQEBAQDb3OGKsDYwWrvEw3gfTb9UipoBFZ9I8pYS8ntV4wAM6oEBEoBJwYJCQ0FDwEECAoFAAYDBgoNDwAEAQwKBgkCDAAHBAAHCwwLAAMPCgOdJYDatk7lvSUyTBhr0mRtcpdMQNr3JtRyjRD2dEjxpwgCBshiSOPnAA==",
        "lastProof": "GgEAAAABAe7wFiVtSpzngy2v5Lv6LQCPkn8uBlIAA1GZMg/ZG96bUUsFRwyZwD2mw/kkKd2sO8mj7AKs5yqSBAQEBAQEBAQEBAQEBAQD7/elUnvysLKgzT96xy6wwZj/emziL98I1kf1UZgNIsYELQEKAQAAAAAAAAABAAO32triSNLXJubm+sBN+lbYosN3ykl8iVUmREj0hO1Nz1IABAPvApR7HUrwQUO/FoEXpWnHnHz2vpsMk8DT2doV1Nwh4APoOjR3pJ5Jj/b9thBymJT96iVJNfZdb96z4YvP/3ZEuQQEBAQEBAQEBAQEBAQEcgAEBAQEAwAYKOMRzay9vdMnNqVdYCCprUSQAEgueNtFRhLxHcJeBAPKdsd3M5d1JSsULlc92k9tg9XpPUcGYzHY+jSRwlM+RwQEBAQEBAQDb3OGKsDYwWrvEw3gfTb9UipoBFZ9I8pYS8ntV4wAM6oEBEoBJw4PAAEGAgUGDQQKCQwOBwgDAg0KDw4ECwsPCgINAAAIDwkCBw8CDgOpMv0n0GGU2BoUUydwQJcc1bzfrOCWmTdbjX56GFcBagcCBZzq4+8A",
        "truncated": false,
        "results": [
            {
                "key": "AQFmmdXxSKUGNq3wQcppLAdAe8sD+g==",
                "value": "yGJI4+cA"
            },
            {
                "key": "AQHu8BYlbUqc54Mtr+S7+i0Aj5J/Lg==",
                "value": "nOrj7wA="
            }
        ]
    }
}
```