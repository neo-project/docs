# getstateheight 方法
查询 stateroot 高度。

> [!Note]
>
> 此方法由插件提供，需要安装 [StateService](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getstateheight",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "localrootindex": 602,
        "validatedrootindex": 602
    }
}
```