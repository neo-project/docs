# listplugins 方法

显示节点已加载的插件列表。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "listplugins",
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
            "name": "DBFTPlugin",
            "version": "3.1.0.0",
            "interfaces": [
                "IP2PPlugin"
            ]
        },
        {
            "name": "LevelDBStore",
            "version": "3.1.0.0",
            "interfaces": []
        },
        {
            "name": "TokensTracker",
            "version": "3.1.0.0",
            "interfaces": [
                "IPersistencePlugin"
            ]
        },
        {
            "name": "RpcServer",
            "version": "3.1.0.0",
            "interfaces": []
        },
        {
            "name": "SystemLog",
            "version": "3.1.0.0",
            "interfaces": [
                "ILogPlugin"
            ]
        }
    ]
}
```