# getproof 方法
通过 root hash，合约 hash 和 storage key 查询得到 proof。

> [!Note]
>
> 此方法由插件提供，需要安装 [StateService](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- roothash：state root 的 root hash。

- scripthash：合约 hash。

- key: 存储区 key 值，使用 Base64 编码格式。

## 配置说明

要使用 getproof 方法，需要先安装 [StateService](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件，并修改[StateService](https://github.com/neo-project/neo-modules/releases) 插件配置文件中的以下字段：

- FullState：设置为true，否则调用时将出现如下信息：

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

- Network：与 Neo-cli 中 config.json 的 magic 设置一致。

- AutoVerify：设置是否默认启动，如果默认启动验证，将利用 Neo-cli 中默认活跃钱包作为验证节点进行验证。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getproof",
  "params": ["0x7bf925dbd33af0e00d392b92313da59369ed86c82494d0e02040b24faac0a3ca","0x79bcd398505eb779df6e67e4be6c14cded08e2f2","Fw=="],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": "Bfv///8XBiQBAQ8DRzb6Vkdw0r5nxMBp6Z5nvbyXiupMvffwm0v5GdB6jHvyAAQEBAQEBAQEA7l84HFtRI5V11s58vA+8CZ5GArFLkGUYLO98RLaMaYmA5MEnx0upnVI45XTpoUDRvwrlPD59uWy9aIrdS4T0D2cA6Rwv/l3GmrctRzL1me+iTUFdDgooaz+esFHFXJdDANfA2bdshZMp5ox2goVAOMjvoxNIWWOqjJoRPu6ZOw2kdj6A8xovEK1Mp6cAG9z/jfFDrSEM60kuo97MNaVOP/cDZ1wA1nf4WdI+jksYz0EJgzBukK8rEzz8jE2cb2Zx2fytVyQBANC7v2RaLMCRF1XgLpSri12L2IwL9Zcjz5LZiaB5nHKNgQpAQYPDw8PDw8DggFffnsVMyqAfZjg+4gu97N/gKpOsAK8Q27s56tijRlSAAMm26DYxOdf/IjEgkE/u/CoRL6dDnzvs1dxCg/00esMvgPGioeOqQCkDOTfliOnCxYjbY/0XvVUOXkceuDm1W0FzQQEBAQEBAQEBAQEBAQEBJIABAPH1PnX/P8NOgV4KHnogwD7xIsD8KvNhkTcDxgCo7Ec6gPQs1zD4igSJB4M9jTREq+7lQ5PbTH/6d138yUVvtM8bQP9Df1kh7asXrYjZolKhLcQ1NoClQgEzbcJfYkCHXv6DQQEBAOUw9zNl/7FJrWD7rCv0mbOoy6nLlHWiWuyGsA12ohRuAQEBAQEBAQEBAYCBAIAAgA="
}
```
