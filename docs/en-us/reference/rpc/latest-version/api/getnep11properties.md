# getnep11properties Method

Gets the customized properties of the NEP-11 token, where the name, description, image, and tokenURI properties are automatically decoded by UTF8.

> [!Note]
>
> You must install the plugin [TokensTracker](https://github.com/neo-project/neo-modules/releases), [LevelDBStore](https://github.com/neo-project/neo-modules/releases), and [RpcSever](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- contract: The contract hash

- tokenId: The  hex string of token id


## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep11properties",
  "params": ["0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f","452023313032204e6f697a"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "name": "E #102 Noiz",
        "owner": "wJjkrPCyCQ3Rbss9WN5CaocVhRs=",
        "number": "Zg==",
        "image": "https://neo.org/Noiz.png",
        "video": null
    }
}
```



