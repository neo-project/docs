# getrawmempool Method

Obtains a list of confirmed / unconfirmed transactions in memory.

#### Examples

##### Example 1 - Get verified transactions

Request body:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
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

##### Example 2 - Get verified and unverified transactions

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [true],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "height": 5896416,
    "verified": [
      "0xb8115f90ce5ac2462807480cdbfdd027777dfe1e9759440c4dd474cc6b711ad1",
      "0xd92cd0cdf20249141db91bf1ffdef538fa36e46140fe6caa319581682025c687"
      ],
    "unverified": [
      "0xfffc3a0f014833110fc23cfa05873b04a07922e812402eeabd0a412185f3b2b4",
      "0xfffc9c3c6f7e82df32042cdd24a2eaedf66e3fbb927eb7245fb9a441729b4f07"
      ]
    }
}    
```

These are the unconfirmed and confirmed transactions received by nodes.