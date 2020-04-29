# closewallet 方法

关闭当前打开着的钱包。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

无

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "closewallet",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": true
}
```

响应说明：

true：关闭钱包成功。
其他：失败。
