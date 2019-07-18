# claimgas 方法

提取钱包中的 GAS。

> [!Note]
>
> - 执行此命令前需要在 NEO-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

address（可选）：要提取 GAS 的地址，该地址需为标准地址。不设置时，默认将 GAS 提取到钱包第一个标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "claimgas",
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
        "txid": "0xa6d16b98dbd4b2d140bd8316f595de3c6770456454d5aa48e1d3dbe11c1acd3e",
        "size": 543,
        "type": "ClaimTransaction",
        "version": 0,
        "attributes": [],
        "vin": [],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.499384",
                "address": "AH2TGXkKgiWm4xMQzVT5R9zV1yxwVXNAPT"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "4000b71a53738761ec03d9cd5d85fc8ea2acf42cda076e7a5f690adb897b2ee8ed018a0000494d6ee047cd66ec926806a0c934fe1a84aec171f66eedf8309d6a9a",
                "verification": "2102bac395577bf47e7dd6058b7dfc38d2b351966ac03ea84ba7bca410e8a8aded20ac"
            },
            {
                "invocation": "4086cdf2622d901110f2c04e646f8e78f4c995f3be399bbe5d2d4ac81918fd4a5d5c39a7df60f827c00de1f19e3584c3253541c52b88bed54ba1b9a448548b0e5d",
                "verification": "2103991949671a85ba5eb09a982c94e0d205b81c94f958109895b4ebafa747caaf09ac"
            }
        ],
        "claims": [
            {
                "txid": "0xe1e44f41a1f0854063ccdc9beb7537fc40565575e0ae2366b4a93a73c18b6166",
                "vout": 2
            },
            {
                "txid": "0x69fd452c92fb0e5861b27588549a8e55d3f9fee542884ae317600508bbacedbb",
                "vout": 2
            },
            {
                "txid": "0x152d823d5cf1ce58cf33879e23309dc83152cfb8c50ba05cc03c090dcd00198e",
                "vout": 0
            },
            {
                "txid": "0x152d823d5cf1ce58cf33879e23309dc83152cfb8c50ba05cc03c090dcd00198e",
                "vout": 1
            },
            {
                "txid": "0xe1e44f41a1f0854063ccdc9beb7537fc40565575e0ae2366b4a93a73c18b6166",
                "vout": 0
            },
            {
                "txid": "0xe1e44f41a1f0854063ccdc9beb7537fc40565575e0ae2366b4a93a73c18b6166",
                "vout": 1
            },
            {
                "txid": "0x668e9be5185e1cfa1efb08b673062038ce04ebc9db41f75dc74d6faacbaf71ea",
                "vout": 0
            },
            {
                "txid": "0x668e9be5185e1cfa1efb08b673062038ce04ebc9db41f75dc74d6faacbaf71ea",
                "vout": 1
            }
        ]
    }
}

```

响应说明：

返回该交易的内容。
