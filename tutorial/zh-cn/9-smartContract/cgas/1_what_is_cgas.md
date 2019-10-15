# 什么是 CGAS

CGAS 是由 NGD（NEO Global Development）发布的符合 NEP-5 规范的合约资产，CGAS 可由 GAS 一比一地对换，并且支持退回操作。该合约的目的是将 GAS 进行全局资产的合约映射，使全局资产 GAS 可以方便地在合约内部流转，支持由合约调用转账。

为什么要发布 CGAS？ 

因为在 NEO 上面的众多 DApps项目方都有一个需求，要在合约中使用一种流通性强，价格相对稳定的数字资产。但受限于 NEO 智能合约的限制和安全性考虑，无法在智能合约中对全局资产（如 NEO 或 GAS）进行转账。而项目方自己发行一种 NEP-5 代币又无法拥有广泛的流通性，无论是让社区认可其代币还是让其代币在交易所上流通，对项目方来说都是个成本很高的事情，而且所有项目发均发行自己的NEP-5资产也是一种浪费。所以社区强烈建议由 NGD 来发行一种与 NEO 或 GAS 锚定的 NEP-5 资产，以供社区统一使用，所以 CNEO 和 CGAS 就诞生了。

CGAS 是如何映射全局资产的呢？

在 CGAS 中通过 mintTokens 和 refund 方法进行全局资产的兑换和退回，无需中心化机构的承兑，完全的去中心化。mintTokens 的方式跟众多项目的 Token Sale 的代码类似，在方法内部对全局资产和合约资产进行了 1:1 的兑换。在 refund 方法中，是预先将一个 UTXO 标记为指定的用户可以取回，然后该用户发起转账将该资产转到自己的地址中。更多细节可以参考 GitHub。这个设计理念由 NEL 团队提出并进行了开源的代码实现，对此表示感谢。

CGAS 中的 C 是什么意思？

Contract，合约的意思。

有社区项目已经开发的映射全局资产的合约，为什么 NGD 要开发 CGAS 呢？

据了解，社区的映射全局资产的合约是不开源的，无法解决信任问题。NGD 开发的 CGAS 是开源的，去中心化的，而且没有使用限制，任何项目方都可以使用。

## 技术介绍

NEP-5 规范中的方法：

| 方法        | 参数                               | 返回值 | 描述                                                         |
| ----------- | ---------------------------------- | ------ | ------------------------------------------------------------ |
| balanceOf   | byte[] account                     | int    | 获得某个账户 CGAS 的余额，返回结果为真实值 × 10⁸             |
| decimals    | ---                                | int    | 获得 CGAS 精度，返回值为常量 `8`                             |
| name        | ---                                | string | 获得合约名称，返回值为常量 `NEP5 GAS`                        |
| symbol      | ---                                | string | 获得合约符号，返回值为常量 `CGAS`                            |
| totalSupply | ---                                | int    | 获得 CGAS 总发行量，返回结果为真实值 × 10⁸。因为 CGAS 与 GAS 为一比一兑换，所以合约地址中 GAS 的数量等于 CGAS 的总发行量 |
| transfer    | byte[] from, byte[] to, int amount | bool   | 转账方法，将 CGAS 从发送者（from）账户，转到接收者（to）账户，转账金额为 amount；from 与 to 为 Script Hash，amount 为实际转账金额 × 10⁸。该方法同时支持用户调用和合约调用。 |

该合约为了支持 GAS 与 CGAS 互换，除了满足 NEP-5 规范中的方法其它方法：

| 方法               | 参数        | 返回值                                      | 描述                                                         |
| ------------------ | ----------- | ------------------------------------------- | ------------------------------------------------------------ |
| getRefundTarget    | byte[] txId | byte[]                                      | 获得某个 UTXO 是谁待退回的，参数为 UTXO 中的交易 ID（确定一个 UTXO 由 txId 和 output 索引共同完成，这里 output 索引默认为 0），返回值为这个 UTXO 的退回者，他可以将这个 UTXO 作为交易输入，将 GAS 从 CGAS 地址中取走。 |
| getTxInfo          | byte[] txId | [TransferInfo](NeoContract/TransferInfo.cs) | 获得某个交易 ID 的详细转账信息，在以下 4 种情况中可记录 TxInfo：mintTokens, Refund, transfer, transferAPP。 |
| mintTokens         | ---         | bool                                        | CGAS 的铸币方法。用户通过发起 InvocationTransaction，将 GAS 转给 CGAS 合约地址，并且调用 mintTokens 完成 GAS 到 CGAS 的转换工作。合约调用成功后，用户资产中将会增加与兑换的 GAS 数额相等的 CGAS。 |
| refund             | byte[] from | bool                                        | 用户将 CGAS 提取，变成 GAS 总共分两步。第一步，发起一笔 InvocationTransaction 其中包含一笔从 CGAS 地址到 CGAS 地址的 GAS 转账（转账金额为用户想退回的 GAS 的数量），并调用 refund 方法（参数为退回者的 Script Hash）。合约调用成功后，将自动销毁与退回数量相等的 CGAS，并把该交易的第 0 号 output 标记为所属于该用户。第二步，用户构造一个交易将第一步标记过的 UTXO 作为交易输入，交易输出为用户自己的地址，从而将 GAS 从 CGAS 地址中取走。 |
| supportedStandards | ---         | string                                      | NEP-10 规范，返回合约所支持的 NEP 标准，返回值为常量，数组格式：`{ "NEP-5", "NEP-7", "NEP-10" }` |

NEP-5 规范中的通知：

| 通知     | 参数                              | 描述                                                         |
| -------- | --------------------------------- | ------------------------------------------------------------ |
| transfer | byte[] from, byte[] to, int value | 通知中包含转账的 3 个要素，发送者 （from），接收者 （to） ，转账金额 （value）, 转账资产默认为 CGAS |

该合约实现的其它通知：

| 通知   | 参数                    | 描述                                                         |
| ------ | ----------------------- | ------------------------------------------------------------ |
| refund | byte[] txid, byte[] who | 通知中包含转账的 2 个要素，待退回的 UTXO（txid），退回者的 Script Hash（who） |

<a name="note-zh"></a>

> [!Note]
>
> 在 mintTokens 的时候请注意，InvocationTransaction 的 Inputs 和 Output 加起来不应该超过60个，否则在执行时所需的手续费会超过 10 GAS 的免费额度。如果有大量 GAS 的 UTXO 需要换成 CGAS，建议先进行一个普通转账，将 UTXO 合并，然后再进行 mintTokens 操作。

## 版本说明

**1.0.3**

Script Hash: [0x74f2dc36a68fdc4682034178eb2220729231db76](https://neotracker.io/contract/74f2dc36a68fdc4682034178eb2220729231db76)

CGAS Contract Address: AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM

Known Issues: not found

**1.0.2**

Script Hash: [0x505663a29d83663a838eee091249abd167e928f5](https://neotracker.io/contract/505663a29d83663a838eee091249abd167e928f5)

CGAS Contract Address: Ae8AD6Rc3cvQapqttJcUTj9ULfLi2tLHmc

Known Issues: `transfer` method cannot be called by other contract

**1.0.1**

Script Hash: [0x9121e89e8a0849857262d67c8408601b5e8e0524](https://neotracker.io/contract/9121e89e8a0849857262d67c8408601b5e8e0524)

CGAS Contract Address: AK4LdT5ZXR9DQZjfk5X6Xy79mE8ad8jKAW

Known Issues: `transferAPP` method naming not canonical

## 阅读下节

下节我们将介绍 [全局资产和NEP5](2_global_asset_and_nep5.md)。

如果要返回上节查看 NEP5 知识，点击[这里](../What_is_nep5.md)。