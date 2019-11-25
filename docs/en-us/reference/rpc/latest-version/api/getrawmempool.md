# getrawmempool Method

Obtains a list of confirmed / unconfirmed transactions in memory.

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [],
  "id": 1
}
```

### Parameter Description

* shouldGetUnverified: Optional. The default value is 0. 
  * When shouldGetUnverified is 0, a list of verified transaction hash strings in memory pool is returned. 
  * When shouldGetUnverified is 1, current block height as well as lists of verified / unverified transaction hash strings in memory pool are returned.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        "0x9786cce0dddb524c40ddbdd5e31a41ed1f6b5c8a683c122f627ca4a007a7cf4e",
        "0xb488ad25eb474f89d5ca3f985cc047ca96bc7373a6d3da8c0f192722896c1cd7",
        "0xf86f6f2c08fbf766ebe59dc84bc3b8829f1053f0a01deb26bf7960d99fa86cd6"
    ]
}
```

These are the confirmed transactions received by nodes.

Request body:

When Verbose = 1，current block height as well as lists of verified / unverified transaction hashes in memory pool are returned.

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        "height": 6180,
        "verified": [
            "0x9786cce0dddb524c40ddbdd5e31a41ed1f6b5c8a683c122f627ca4a007a7cf4e",
            "0xb488ad25eb474f89d5ca3f985cc047ca96bc7373a6d3da8c0f192722896c1cd7",
            "0xf86f6f2c08fbf766ebe59dc84bc3b8829f1053f0a01deb26bf7960d99fa86cd6"
        ],
        "unverified": [
            "0xdd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6"
        ]
    ]
}
```

