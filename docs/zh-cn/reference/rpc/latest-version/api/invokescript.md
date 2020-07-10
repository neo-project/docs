# invokescript 方法

通过虚拟机传递脚本之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，调用时只是在 RPC 对应的节点试运行脚本并返回结果，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- script：一个可由虚拟机运行的脚本，可参考 [invokefunction](invokefunction.md) 接口响应正文中的 script。
- cosigners：需要添加的签名列表，如不需要签名，无需传递此参数。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokescript",
  "params": [    "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
    [
        {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CalledByEntry"      
        },
        {
          "account": "0xb120f50f804d3a203c43475212894ab1c911ce18",
          "scopes": "CalledByEntry"      
        }
    ]
  ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
        "state": "HALT",
        "gasconsumed": "9007960",
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": "0044381e331c0357464b777ecf6b5f3ac3893ace1f8b1621f658738900000000009c8a2400000000000020200002011c0357464b777ecf6b5f3ac3893ace1f8b1621f6010118ce11c9b14a89125247433c203a4d800ff520b10154180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b5202420c40d26e1bd8588a54b1537b058a1bd0dfc7580662ab277edba02bbcca2aaa70d1a6fce23d6c5140a23d2fdb5d4a35b0cb26c1ea4f01c87b6dc896f15e2b241b2ec7290c21028bd1902c4d1419f002b821e6de653ddfd5358063208e426756398be6ffa3aac80b4195440d78420c40aa0cba50fc14584ed81ef6bb24b2e78f1fa1aff4bdc2825b4392d3d0f5bf9ec4d0a34361e3463eed25d0ab888de00a538d938769df53ca5993fcbed4aa2df793290c210222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df1218263430b4195440d78"
    }
}
```

