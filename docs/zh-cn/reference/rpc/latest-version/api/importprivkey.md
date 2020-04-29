# importprivkey 方法

导入私钥到钱包。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

key ：WIF 格式的私钥。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "importprivkey",
  "params": ["KwYRSjqmEhK4nPuUZZz1LEUSxvSzSRCv3SVePoe67hjcdPGLRJY5"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "haskey": true,
        "label": null,
        "watchonly": false
    }
}

```

响应说明：

返回地址信息。
