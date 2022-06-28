# sendtoaddress 方法

向指定地址转账。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- asset_id：资产 ID，即 NEP-17 合约的脚本哈希

  如 NeoToken 为：0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5

  GasToken 为：0xd2a4cff31913016155e38e474a2c06d08be276cf

  以上资产可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

- address：收款地址。

- value：转账金额，不带精度的大整数。例，GAS 精度为 8，如果想转 0.000001 GAS, 这里应该输入 100，如果想转 100 GAS，这里应该输入 10000000000。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0xd2a4cff31913016155e38e474a2c06d08be276cf", "NUuPz4k387bHuySx2e2RWhZj5SpF8V4Csy", 100],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x4c072646cf9515dd2a5df9fc4df0563a4f2e468910d24a9b2196743bcea8b8f0",
        "size": 246,
        "version": 0,
        "nonce": 573855568,
        "sender": "NSXYk7V6bgrwCJJbh5m8ZGCy1fbREY4gk5",
        "sysfee": "9977780",
        "netfee": "1229520",
        "validuntilblock": 17307,
        "signers": [
            {
                "account": "0x580d152d36db6f34c9aaf676facbbe2779538b48",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CwBkDBRinWqydAv8Nt9xgEEbqA/YeB0pvQwUSItTeSe+y/p29qrJNG/bNi0VDVgUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEDROjmUBKzywJa+WCD9MttL6V+3i+HvjnfW8hMjT5y8zMcXzqt4HI2/72YM/aS2nfWPXOfJVXZmK/89mSJqPVX6",
                "verification": "DCECUDQqDEv7ud85rbYDDT8/i+vdyxW46/e8TMrafzqJui5BVuezJw=="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
