# getstateroot 方法

通过高度查询 state root

> [!Note]
>
> 此方法由插件提供，需要安装 [StateService](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- index: 区块索引

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getstateroot",
  "params": [160],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "index": 160,
        "roothash": "0x3d3f099e05cf92c018703ab309d8643c30a0ab6b2b008cc6fe80869b1a350c31",
        "witnesses": []
    }
}
```