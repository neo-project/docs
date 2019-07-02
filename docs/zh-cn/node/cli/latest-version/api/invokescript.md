# invokescript 方法

通过虚拟机传递脚本之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

script：一个由虚拟机运行的脚本，与 InvocationTransaction 中携带的脚本相同。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["00046e616d656724058e5e1b6008847cd662728549088a9ee82191"],
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "00046e616d656724058e5e1b6008847cd662728549088a9ee82191",
        "state": "HALT, BREAK",
        "gas_consumed": "0.161",
        "stack": [
            {
                "type": "ByteArray",
                "value": "4e45503520474153"
            }
        ],
        "tx": "d1011b00046e616d656724058e5e1b6008847cd662728549088a9ee82191000000000000000000000000"
    }
}
```
