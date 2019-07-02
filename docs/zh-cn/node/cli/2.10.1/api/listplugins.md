# listplugins 方法

显示节点已加载的插件列表。

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
            "name": "SimplePolicyPlugin",
            "version": "2.10.1.0",
            "interfaces": [
                "ILogPlugin",
                "IPolicyPlugin"
            ]
        }
    ]
}
```