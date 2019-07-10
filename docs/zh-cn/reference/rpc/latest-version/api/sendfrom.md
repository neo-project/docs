# sendfrom 方法

从指定地址，向指定地址转账。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

asset_id：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

如NEO为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

NeoGas为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

RPX sale为：ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9

其余资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

from：转账地址。

to: 收款地址。

value：转账金额。

fee：可选参数，设置手续费可以提升网络处理该笔转账的优先级，默认为 0，最小值可设为0.00000001。

change_address：找零地址，可选参数，默认为钱包中第一个标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendfrom",
  "params": ["602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7","AWg3L6W68bFfSS13Tf4rt8CRdG2ktaAjGb","AWg3L6W68bFfSS13Tf4rt8CRdG2ktaAjGb",1],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "txid": "0x60170ad03627ce45c7dd56ececbf33b26eab0845aa8b2cbbeecaefc5771b9eb1",
    "size": 262,
    "type": "ContractTransaction",
    "version": 0,
    "attributes": [],
    "vin": [
      {
        "txid": "0xd2188c1bd454ac883d79826e5c677deedb91cc61ec6d819df48ff4a963873adb",
        "vout": 1
      }
    ],
    "vout": [
      {
        "n": 0,
        "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
        "value": "1",
        "address": "AWg3L6W68bFfSS13Tf4rt8CRdG2ktaAjGb"
      },
      {
        "n": 1,
        "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
        "value": "17.4798197",
        "address": "AWg3L6W68bFfSS13Tf4rt8CRdG2ktaAjGb"
      }
    ],
    "sys_fee": "0",
    "net_fee": "0",
    "scripts": [
      {
        "invocation": "40a8d40e1652d7ad0c7bb59ef8217237037824af54ee5e46f2fd096c44dd46ef27fa7255010e2a8a2166af8a904e13b96bd3ac82e791633685824c35e7f2731e79",
        "verification": "2102883118351f8f47107c83ab634dc7e4ffe29d274e7d3dcf70159c8935ff769bebac"
      }
    ]
  }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
