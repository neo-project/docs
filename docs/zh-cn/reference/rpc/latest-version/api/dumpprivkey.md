# dumpprivkey 方法

导出指定地址的私钥。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

address：要导出私钥的地址，该地址需为标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["NepVckSSgHJf1szQ6LEibd5NU7Ap67yJrJ"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L5LEfSAAbVAk5vxmkBpWQqJ2e1hyh3nEqgWaosB35XpBAkZdizj4"
}
```

响应说明：

返回该标准地址的私钥。
