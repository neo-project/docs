# submitblock Method

Broadcasts a new block in the NEO network.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": [hex],
  "id": 1
}
```

### Parameter Description

hex: A Base64-encoded string of a serialized block.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": ["AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768CAGUTt7+NSxXGAA7aoUS2kokAAAAAACYcEwAAAAAARzMAAAHNWK7P0zW+HrPTEeHcgAlj39ctnwEAXQMA5AtUAgAAAAwUzViuz9M1vh6z0xHh3IAJY9/XLZ8MFM1Yrs/TNb4es9MR4dyACWPf1y2fE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOAFCDEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+KQwhAv3yei642bBp1hrlpk26E7iWN8VC2MdMXWurST/mONaPC0GVRA14"],
  "id": 1
}
```

Response body in successful cases:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xbe153a2ef9e9160906f7054ed8f676aa223a826c4ae662ce0fb3f09d38b093c1"
    }
}
```

Response body in unsuccessful cases:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
        "code": -500,
        "message": "AlreadyExists"
    }
}
```

Response Description:

When result is false, the block has failed to broadcast and an exception occurs. The following error codes can be expected

| Error codes | Message           | Description                                                  |
| ----------- | ----------------- | ------------------------------------------------------------ |
| 500         | AlreadyExists     | Block or transaction already exists and cannot be sent repeatedly. |
|             | OutOfMemory       | The memory pool is full and no more transactions can be sent. |
|             | UnableToVerify    | The block cannot be validated.                               |
|             | Invalid           | The format or parameter is incorrect                         |
|             | Expired           | The block information is expired                             |
|             | InsufficientFunds | Insufficient funds                                           |
|             | PolicyFail        | The behavior is not allowed (such as blacklist address trading) |