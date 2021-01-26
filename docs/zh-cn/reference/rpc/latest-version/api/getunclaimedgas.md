# getunclaimedgas 方法

返回指定地址未提取的 GasToken。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

address：要查询的地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": ["NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unclaimed": "0.00000003",
        "address": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ"
    }
}
```