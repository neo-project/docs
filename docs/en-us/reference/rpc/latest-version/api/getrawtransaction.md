# getrawtransaction Method

Returns the corresponding transaction information based on the specified hash value.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* txid: Transaction ID

* verbose: Optional. The default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format string.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac", 0],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0082b3103425275006800e73cc64286753a3a732422521c8e400e1f50500000000466a13000000000063e72000000125275006800e73cc64286753a3a732422521c8e4015d0300e40b54020000000c142bf173f849d1d59123d097c009aa31624d39e7390c1425275006800e73cc64286753a3a732422521c8e413c00c087472616e736665720c143b7d3711c6f0ccf9b1dca903d1bfa1d896f1238c41627d5b523901420c4048f7972d1785bc159a998aa9b87935e869597c224b23b4c3a0860c9df2a252d084295b4529c52dbd262ce36ffe7089fd61b746de92c5a7e9684cf26ada409aa1290c2102c9885a0be8be46eef981a95da7d57a38a1568f6e8455deda4dc5e2009327ff4a0b410a906ad4"
}
```

Request body:

When verbose = 1, the result in Json format is returned:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac", 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac",
        "size": 272,
        "version": 0,
        "nonce": 873509762,
        "sender": "NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch",
        "sys_fee": "100000000",
        "net_fee": "1272390",
        "valid_until_block": 2156387,
        "attributes": [],
        "cosigners": [
            {
                "account": "0xe4c821254232a7a353672864cc730e8006502725",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AwDkC1QCAAAADBQr8XP4SdHVkSPQl8AJqjFiTTnnOQwUJSdQBoAOc8xkKGdTo6cyQiUhyOQTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEBI95ctF4W8FZqZiqm4eTXoaVl8IksjtMOghgyd8qJS0IQpW0UpxS29Jizjb/5wif1ht0beksWn6WhM8mraQJqh",
                "verification": "DCECyYhaC+i+Ru75galdp9V6OKFWj26EVd7aTcXiAJMn/0oLQQqQatQ="
            }
        ],
        "blockhash": "0xbd96fddf3c19381671f96de6b9e7779b7aef9972b87f5cff8412f4fbd64a9d47",
        "confirmations": 30,
        "blocktime": 1579168140997,
        "vmState": "HALT"
    }
}
```
