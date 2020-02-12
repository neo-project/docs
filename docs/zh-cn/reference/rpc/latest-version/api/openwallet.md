# openwallet 方法

打开指定钱包文件。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

path：钱包文件路径。
password：明文密码。

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

