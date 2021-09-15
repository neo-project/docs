# 一般问题

## Neo 是什么？

Neo 是利用区块链技术和数字身份进行资产数字化，利用智能合约对数字资产进行自动化管理，实现“智能经济”的一种分布式网络。Neo 网络中内置了两种通证，管理通证 NEO 和燃料通证 GAS。

## Neo 有哪些开发社区？

Neo 非常重视社区的发展，拥有庞大的全球开发者社区，长期以来为 Neo 的开发提供支持，目前代表性的社区有：

- **CoZ**，Neo 生态最早的开发者社区：https://github.com/CityOfZion
- **NEL**，Neo 生态首个中文开发者社区：https://github.com/NewEconoLab
- **NeoResearch**，南美开发者社区：https://github.com/NeoResearch
- **NSPCC**，俄罗斯圣彼得堡开发者社区：https://www.nspcc.ru/en/
- **NEO·ONE**，Neo 区块链开发工具：https://neo-one.io/
- **Red4Sec**，Neo 合约安全审计：https://red4sec.com/
- **NEONEWSTODAY**，Neo 生态新闻动态发布：https://neonewstoday.com/
- **NEXT**，Neo Dapp 工具开发社区：https://neonext.io/
- **neow3j**，Neo 多语言智能合约 SDK 开发 ：https://github.com/neow3j/

## 什么是 GAS？如何提取 GAS？

GAS 代表了 Neo 区块链的使用权，Neo 网络中的资产发行、智能合约的运行以及所有需要修改区块链状态的交易都需要花费一定量的 GAS。Neo N3 的创世区块将铸造准确数量的GAS代币，以对标 NEO legacy 链上流通的所有GAS代币。在 Neo N3 中，每当发生 NEO 转账，GAS 就会自动提取。

与 Neo Legacy 不同，Neo N3 的 GAS 没有发行上限，且交易的系统费会被燃烧掉。

## Neo 采用什么共识机制？

Neo 使用 一种改进的拜占庭容错机制 （dBFT），可以对由 𝑛 个共识节点组成的共识系统，提供 𝑓 = ⌊ (𝑛−1) / 3 ⌋ 的容错能力。在这个机制当中，存在多种节点，分别是普通节点，候选人节点，委员会节点和共识节点。任何人都可以发起交易成为候选人，或者对候选人进行投票，根据投票情况，排在最前面的一定数量的候选人将被选为委员会成员和共识节点。当需要通过一项共识时，在这些共识节点中随机推选出一名议长拟定方案，然后由其他共识节点根据拜占庭容错算法进行投票，如果大于等于 2/3 的节点同意议长提案，则共识达成；否则，重新推选议长，重复投票过程。

## 如何成为 Neo 的共识节点？ 成为共识节点有什么激励吗？

Neo 的共识节点由 Neo 持有者投票选出。详细信息可参考 [这里](https://docs.neo.org/docs/zh-cn/basic/consensus/vote_validator.html)；所有交易的网络费会作为奖励发给当前打包交易出块的共识节点。

## 有哪些 Neo 的区块链浏览器可以使用？

比较常用的有 <https://neo3.neotube.io/>，您也可以访问 http://ndapp.org/ ，在 Explorer 页签下选择所需要的区块链浏览器使用。

## 如何查看我的交易状态?

可以使用任意 Neo 区块链浏览器查看，例如 <https://neotube.io/>

## Neo 是否有类似 ERC-20 的标准？

NEP-17 标准是 Neo N3 的通证标准，它取代了以前的 NEP-5，表示在 Neo 区块链上发行的通证合约所需要遵循的规范。

## 如何在 Neo-CLI 中查看 NEP-17 资产？

想要看到 NEP-17 资产，需要使用 RPC 的 [getnep17balances](../../docs/zh-cn/reference/rpc/latest-version/api/getnep17balances.md) 方法或 Neo-CLI 的 [balanceof](../../docs/zh-cn/node/cli/cli.html#balanceof) 方法。

## NEP-6 是什么？

NEP-6 是一种钱包标准，包括钱包的格式，里面参数的定义，钱包地址的创建规则等。NEP-6 标准适用于现在的几个版本，包括 2.7.6。Neo 客户端支持两种格式的钱包，一种是 sqlite 钱包（格式为.db3），另一种是 NEP-6 钱包（格式为.json）。考虑到处理速度，强烈建议交易所使用 sqlite 钱包。

## NEO 可以像比特币一样保存吗，我担心存储安全

是的。如果你持有 NEO，你将始终在链上拥有。离线存储私钥将保证你的资产安全且无法触及。

## Neo 钱包之间是否有转账费用？

在 Neo N3 上进行任何转账或其他交易都会收取一定的 GAS 费用。

## 将 NEO 存放在交易所，我是否还能获取 GAS？

这取决于交易所自身规定。有的交易所如 [Binance](https://www.binance.com/) 会发放 GAS 给用户，而有的交易所如 [Bittrex](https://www.bittrex.com/) 则自己保留 GAS 。如果你要保证自己收到 GAS，请将你的 NEO 转到私人钱包并手动提取 GAS。

## 我从交易所提取了 NEO，但交易所保留了 0.9750 个 NEO 我无法将其取出。那这点余额可以充值，持有或卖出吗？ 

NEO 的最小操作单位为 1，因此，你只能先保留在交易所，以后再卖，或者购买额外的 NEO，使你的 NEO 余额大于 1，或者将其换成其他 Token 如 USDT，GAS 等。