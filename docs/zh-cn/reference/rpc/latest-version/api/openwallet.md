# openwallet 方法

打开指定钱包文件。为了安全该方法默认禁用，如确实需要使用，请要在 RpcServer 的配置文件中手动开启该方法。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- path：钱包文件路径。
- password：明文密码。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "openwallet",
  "params": ["11.db3", "1"],
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

true：打开成功。

其他：打开失败。

如果返回消息为`Access denied`，则表示默认禁用了 `openwallet` 方法，如果确实需要使用，请修改 RpcServer/config.json 中的 DisabledMethods 字段，将 `openwallet` 移除。

