# getunclaimedgas 方法

显示钱包中未提取的 GAS 数量。

> [!Note]
>
> 执行此命令前需要：
>
> -  在 NEO-CLI 节点中打开钱包。
> - 安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件。

#### 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "available": "0.140771",
        "unavailable": "0.096224"
    }
}

```

响应说明：

返回未提取的 GAS 数量。
