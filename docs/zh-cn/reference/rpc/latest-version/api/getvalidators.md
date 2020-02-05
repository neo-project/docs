# getvalidators 方法

获取当前 NEO 共识节点的信息及投票情况。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getvalidators",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "publickey": "02486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a70",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b64",
            "votes": "0",
            "active": false
        },
        {
            "publickey": "02aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba554",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "02df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "032f7b887a43774c51927e44d4c471655cdf6257ad92e38c1cf50c67e1a10281b4",
            "votes": "0",
            "active": false
        },
        {
            "publickey": "03b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c",
            "votes": "46632420",
            "active": true
        },
        {
            "publickey": "03b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a",
            "votes": "46632420",
            "active": true
        }
    ]
}
```

- publickey: 候选人公钥
- votes: 候选人所得票数
- active: true 表示该候选人已经成为共识节点，反之，false 表示该候选人未成为共识节点。