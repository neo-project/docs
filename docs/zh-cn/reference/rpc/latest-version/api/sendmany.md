# sendmany 方法

批量转账命令，并且可以指定找零地址。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

`[fromAddress]<outputs_array>`

- fromAddress： 资产出金的地址（可选）。

- outputs_array：数组，数组中的每个元素的数据结构如下：

  `{"asset": <asset>, "value": <value>, "address": <address>, "signers": <signers>}`

  - asset：资产 ID，即 NEP-17 合约的脚本哈希。

	  如 NeoToken 为：0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5

	  GasToken 为：0xd2a4cff31913016155e38e474a2c06d08be276cf
  - value：转账金额。

  - address：收款地址。

  - signers：交易签名账户。


## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

请求正文（包含 fromAddress）：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [
     "NY9nnDv7cAJ44C2xeRScrXfzkrCJfFWYku",
	[
	    {
			    "asset": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5", 
			    "value": 100, 
					"address": "NbtvbHpwv6nswDtVFpKEyooHhDHwZh2LHf"
			}, 
			{
			     "asset": "0xd2a4cff31913016155e38e474a2c06d08be276cf", 
					 "value": 100, 
					 "address": "NbtvbHpwv6nswDtVFpKEyooHhDHwZh2LHf"
			},
			    {
			    "asset": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5", 
			    "value": 100, 
					"address": "NPTvd2T1zi7ioj3LmvpeBd45pPvAJU3gvr"
			}, 
			{
			     "asset": "0xd2a4cff31913016155e38e474a2c06d08be276cf", 
					 "value": 100, 
					 "address": "NPTvd2T1zi7ioj3LmvpeBd45pPvAJU3gvr"
			}
	 ]
	 ],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "hash": "0xe8742fc5a69f3180ab59f3f21695ce5459891429682a7f1df38219bc05cce39e",
    "size": 514,
    "version": 0,
    "nonce": 537723951,
    "sender": "NY9nnDv7cAJ44C2xeRScrXfzkrCJfFWYku",
    "sysfee": "39726800",
    "netfee": "1497580",
    "validuntilblock": 6357,
    "signers": [
      {
        "account": "0x9dd95824d6a1789d5bb665abd727d0c387a53e86",
        "scopes": "CalledByEntry"
      }
    ],
    "attributes": [],
    "script": "CwBkDBSvT25X7NLzUvxKKqw14LOzO554tQwUhj6lh8PQJ9erZbZbnXih1iRY2Z0UwB8MCHRyYW5zZmVyDBT1Y+pAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQsAZAwUJvOMLBhLx7odYBaJkOQJlbxNJF4MFIY+pYfD0CfXq2W2W514odYkWNmdFMAfDAh0cmFuc2ZlcgwU9WPqQLwoPU0OBcSOowWz8qBzQO9BYn1bUjkLAGQMFK9Pblfs0vNS/EoqrDXgs7M7nni1DBSGPqWHw9An16tltludeKHWJFjZnRTAHwwIdHJhbnNmZXIMFM924ovQBixKR47jVWEBExnzz6TSQWJ9W1I5CwBkDBQm84wsGEvHuh1gFomQ5AmVvE0kXgwUhj6lh8PQJ9erZbZbnXih1iRY2Z0UwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtSOQ==",
    "witnesses": [
      {
        "invocation": "DEDxTxMc/IKpEzhfYV0bMv8qUEL1na7LvrnK3hisz1SBoYJr2SF7SpXY0RzA/1x5QfHEuxHUuvelul1aiDjFenYD",
        "verification": "EQwhA+CII7RDmfaiqiJIg02SChWrOuktx1Y89+Q/3dWxwBgvEUF7zmyl"
      }
    ]
  }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

JSON 格式不正确，会返回 Parse error。

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
