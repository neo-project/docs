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
  "params": ["0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AA7aoUS2kokAAAAAACYcEwAAAAAARzMAAAHNWK7P0zW+HrPTEeHcgAlj39ctnwEAXQMA5AtUAgAAAAwUzViuz9M1vh6z0xHh3IAJY9/XLZ8MFM1Yrs/TNb4es9MR4dyACWPf1y2fE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOAFCDEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+KQwhAv3yei642bBp1hrlpk26E7iWN8VC2MdMXWurST/mONaPC0GVRA14"
}
```

Request body:

When verbose = 1, the result in Json format is returned:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a", 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a",
        "size": 252,
        "version": 0,
        "nonce": 1151457806,
        "sender": "NedjwsfAJYFas9rn8UHWQftTW4oKAQyW9h",
        "sysfee": "9015990",
        "netfee": "1252390",
        "validuntilblock": 13127,
        "signers": [
            {
                "account": "0x9f2dd7df630980dce111d3b31ebe35d3cfae58cd",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AwDkC1QCAAAADBTNWK7P0zW+HrPTEeHcgAlj39ctnwwUzViuz9M1vh6z0xHh3IAJY9/XLZ8TwAwIdHJhbnNmZXIMFLyvQdaEx9StbuDZnalwe50fDI5mQWJ9W1I4",
        "witnesses": [
            {
                "invocation": "DEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+",
                "verification": "DCEC/fJ6LrjZsGnWGuWmTboTuJY3xULYx0xda6tJP+Y41o8LQZVEDXg="
            }
        ],
        "blockhash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "confirmations": 44,
        "blocktime": 1605687708300,
        "vmstate": "HALT"
    }
}
```
