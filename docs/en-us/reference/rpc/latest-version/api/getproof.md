# getproof Method
Gets proof by querying root hash, contract hash, and storage key.

> [!Note]
>
> You must install the plugin [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- roothash: root hash of state root

- scripthash: Contract script hash

- key: key of the storage; Base64-encoded.

## Configuration

Before you can invoke the getproof method you must install the plugin [StateService](https://github.com/neo-project/neo-modules/releases) and [RpcServer](https://github.com/neo-project/neo-modules/releases), and then modify the following fields in the [StateService](https://github.com/neo-project/neo-modules/releases) config.json file：

- FullState: Set to true, or the error message is returned as follows：

  ```json
  {
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
      "code": -100,
      "message": "Old state not supported",
      "data": "   at Neo.Plugins.StateService.StatePlugin.GetProof(UInt256 root_hash, UInt160 script_hash, Byte[] key)\r\n   at Neo.Plugins.StateService.StatePlugin.GetProof(JArray _params)\r\n   at Neo.Plugins.RpcServer.ProcessRequest(HttpContext context, JObject request)"
    }
  }
  ```

- Network: Set to the same value as `Network` in the Neo-cli config.json.

- AutoVerify: Set whether to enable verification by default, and if yes, the default active wallet in Neo-cli is used as the verification node.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getproof",
  "params": ["0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca","0x79bcd398505eb779df6e67e4be6c14cded08e2f2","Fw=="],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": "Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA="
}
```