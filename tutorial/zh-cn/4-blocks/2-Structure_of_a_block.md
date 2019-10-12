# 区块结构

下面是NEO主网上高度为#3649960区块的JSON转储信息。可以使用以下命令来获取（请注意，节点的选择是随机的，且该节点可能会随时下线。可以使用NEO主网上可接收RPC请求的任意节点来替换该节点）：

```
curl https://seed4.switcheo.network:10331 -H 'Content-Type: application/json' -d '{ "jsonrpc": "2.0", "id": 1, "method": "getblock", "params": ["ad83d993ca2d9783ca86a000b39920c20508c8ccae7b7db11806646a4832bc50",1] }'
```

下面是上述请求返回的部分结果信息，去掉了请求的元数据且只选择了区块中的一个交易进行说明。然而，这些信息对于我们理解区块结构已经足够了。cURL请求的完整响应可以点击[此处](neo-block.json)查看。

## 区块示例

```{
"hash": "0xad83d993ca2d9783ca86a000b39920c20508c8ccae7b7db11806646a4832bc50",
"size": 2139,
"version": 0,
"previousblockhash": "0x82616a5cc9b6beb808dd4e81d5ddd8aac1a0bf369df6599a953bd3441c4d3e2f",
"merkleroot": "0xbce8a69479efea7878ad9e45d58a6e67c5cc5d45774052a6ceac4b45820baa3e",
"time": 1555864355,
"index": 3649960,
"nonce": "3f7f9582d84e0052",
"nextconsensus": "ANuupE2wgsHYi8VTqSUSoMsyxbJ8P3szu7",
"script": {
	"invocation": "4013a82dff8a58ff750703cc32852899124917ded6bd7a7d66bf31d693890488717ab4ee258c0806286d3c2d49da4f9f52d1c6a20843ab5a9a0b4e867ed3d4c5644087875bbc17e8300bb2ee82b3623833be4693fe378cde10e380ce64fe4f1cdba6acb70b6d9d3c52efaa776a6c8a5f91cf3a48b6df79edeae1cd26259b00add96640a1053731b59c6687965e942600301b68f79252e9aa08047115e649930df679d853438bc95c88c9cfa7aa9737d51f82d25dde5b5435cd8266a132a726d7d01f294043df832e612d220c3ce639cbca4ab18f9ce21dfd8718340dae4ca49fd239a4ee06d294e9d583bc4e0da5cccb5eb0f35e7b836d7c633b1e9ca20c0c0af429644740c352f2425c56001a292cc28cba9e736913f9c116580796efacda4270ac104659173ee1bc4bed706c0f3ea90c9b8201653abe74a30e627c443855af6c08c90acb",
	"verification": "5521024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d21025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b6421035e819642a8915a2572f972ddbdbe3042ae6437349295edce9bdc3b8884bbf9a32103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
},
"tx": [{
	"txid": "0xd3e7337fe0666dac52277f1f576f47064935fe2af2b9dc2d88f34e84e7837170",
	"size": 70,
	"type": "MinerTransaction",
	"version": 0,
	"attributes": [],
	"vin": [],
	"vout": [{
		"n": 0,
		"asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
		"value": "0.001",
		"address": "AKNLArGjLisJB9mXvtSxASxHd9jaCBFs1B"
	}],
	"sys_fee": "0",
	"net_fee": "0",
	"scripts": [],
	"nonce": 3628990546
},
	{ "txid": "0x1d9839c589d505391cff9bd0b8ed057d8233b85cb162d046cbc3f97ad78e212c",
		"size": 541,
		"type": "InvocationTransaction",
		"version": 1,
		"attributes": [{
			"usage": "Script",
			"data": "57d40b321c35277ea977f76e5e431e04cb14cda4"
		}],
		"vin": [{
			"txid": "0x0c1d6f7c23ea52d7b1d66b0903efaf34be3b98e057813f91c4e7dc4ad4b36d81",
			"vout": 0
		}, {
			"txid": "0xacca07162a2a544ff1e73fd67c62941f10d71081af52f11f21db1361f2916193",
			"vout": 0
		}],
		"vout": [{
			"n": 0,
			"asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
			"value": "0.00000001",
			"address": "ASH41gtWftHvhuYhZz1jj7ee7z9vp9D9wk"
		}],
		"sys_fee": "0",
		"net_fee": "0.001",
		"scripts": [{
			"invocation": "404a4f5d2e426977a6a788559878091bad62c932dfe5820f6db5ab0cf6cdf148760b1a62577bf65162c352efcf0faa86f5309b628b291b63db92b0fc8003f81178",
			"verification": "21039ab3dfa0876901f78ec20d8969f7684e635b7540a3e6584a0973943f566c0810ac"
		}, {
			"invocation": "40f2f4b5f99ccec7027e9a89a142f2bed38207ab7ee7259225ac1c38a219c840f86a35a72e53ee1b957f43191d4cb4b23d6f06929d4786331567858cf3e7413c05",
			"verification": "2102c29b96cf2db558bd8265dfb29f425c9fc333a8b30c0e91b5b7338469e7939c87ac"
		}, {
			"invocation": "404d226b4bc30955a1dc74387df80cd25a56d1f136594339f7e269f49032b3c6ffcde9d8fd0ca68238d97993753a390ee1b9b33728eab75efdb768cf08e5a08e42",
			"verification": "2102a1e6ed9a5cff73ad33b7896465af8e9206eab9c8c75502868b783deb64f232eaac"
		}],
		"script": "05cba800841b1437e558ef781b899d61fe204c75761e699bd42ede1457d40b321c35277ea977f76e5e431e04cb14cda453c1076465706f73697467d4c357a466cf12e8167b00a440f782705dcf2ba3",
		"gas": "0"
	},
	{"...more transactions..."}],
"confirmations": 117,
"nextblockhash": "0x77875e7a3d255c3fc82070c51c7999487fb927dfec6a158b5d1dcd4031ee1c5c"
```

## 界面呈现

可以使用区块浏览器来以一种对用户更为友好的方式查看区块信息。Neoscan.io就是其中一个选择，上面所说的区块可以点击[这个URL](https://neoscan.io/block/ad83d993ca2d9783ca86a000b39920c2508ccae7b7db11806646a4832bc50)来查看。区块包含的信息和交易如下所示。调用脚本和验证脚本信息没有在图中显示，在[区块验证 & 处理](4-Block_validation_processing.md)一节有详细的讨论。

![Visual representation of a block](block-info.png)

# 区块内容
## 区块头

- ***hash***: 区块头的哈希。 目前在计算哈希时使用了以下字段，区块哈希用于唯一标识一个区块：
	* version
	* previousblockhash
	* merkleroot
	* time
	* index
	* nonce
	* nextconsensus

- ***size***: 区块大小
- ***version***: 区块版本号，声明要遵循的区块验证规则的集合。 每当引入新规则时，都会增加版本号以引用之前遵循的规则集合。
- ***previousblockhash***: 前一个区块的哈希，称为当前区块的父块。 子块总是引用到一个父块。 引用前一个区块的哈希是网络安全的重要部分。

由于区块始终通过区块头的哈希引用到前一个区块，因此前一个区块的任意交易发生的任意更改都会导致前一个区块的[默克尔根节点](resource.md)的哈希发生变化。由于在计算区块头哈希时使用了默克尔根节点的哈希，因此交易上的任意更改都会完全改变区块头哈希。这个哈希会完全不同于之前的值，因此会改变下一个区块所指向的父块。这样就可以很容易地检测到变化，因为它会有效地打破链结构。这可以使得所有其他节点检测并忽略这些作恶的区块，从而确保了网络的安全性。在比特币这样的基于工作量证明的区块链，要接受恶意区块，就意味着需要重新计算恶意块*以及*之后所有区块的全部Nonces，以产生比当前区块链更长的链，从而让其他所有节点接受该链有效这一事实。这就是为什么区块高度越低安全性越低的原因，一般规则是在确定一笔交易的最终性之前先等待6个区块的时间。在比特币中通常需要等待约1小时（6 x 10分钟/区块）。

然而NEO使用了[dBFT](../../../docs/zh-cn/basic/technology/dbft.md)机制，一旦区块上链就具有终局性。黑客要想提交一个作恶的区块，他需要获得66％的共识节点的同意才能在作恶的区块链上构建出下一个区块，并将作恶的区块头设置为新区块的 “前一个区块的哈希”。

- ***merkleroot***: 区块中交易列表的默克尔树根节点的哈希值。
- ***time***: 区块时间是区块创建时的Unix纪元时间。 Unix纪元时间是自大纪元 -  1970年1月1日格林尼治标准时间00:00:00以来的秒数。
- ***index***: 当前区块的高度。 创世块的索引是0。区块结构中不包含这个字段，它是由节点发起RPC请求同步区块时计算得出的。
- ***Nonce***: 智能合约使用的随机数。 需要理解的是，这与其他区块链协议（例如比特币）中的随机数是有很大区别的，在比特币中矿工会通过竞争来找到满足某个难度级别的随机数。 由于NEO使用的是dBFT共识机制，所以不存在工作量证明（PoW），并且节点会共同争取达成共识。 由于不需要PoW，因此Nonce字段就是供区块中所有交易使用的一个随机数。 每生成一个新的区块，共识节点就会对随机数达成共识，并将其填充到新区块的Nonce字段中。 智能合约可以通过引用Nonce字段轻松地获取任意区块的随机数。
- ***nextconsensus***: 在对当前区块的共识期间，算法会重新选择下一轮参与共识的节点，节点信息会存储在该字段中。
- ***script***: 用于验证区块的脚本。 在[区块验证和处理](4-Block_validation_processing.md)一节有详细讨论。

## 区块体

区块体中包含该区块的全部交易。

### 交易类型

以下是区块中可能出现的交易类型：

* **MinerTransaction**：每个区块中的第一个交易必须是MinerTransaction。 它用于将当前区块的所有交易费用奖励给验证人。
* **IssueTransaction**：用于发行资产。 资产管理者可以通过IssueTransaction交易来创建已经在NEO区块链上注册过的资产，并将其发送到任意地址。
* **ClaimTransaction**：NEO的持有者可以通过调用该交易来提取那些尚未提取过的NeoGas。
* **EnrollmentTransaction**：该交易代表一个注册表，表明交易的发起者想要注册成为验证人
* **ContractTransaction**：一种非常常见的交易，允许将NEO从一个钱包发送至另一个钱包。 该交易的输入和输出字段是很重要的（例如，管理要发送的NEO个数以及接收人的地址）。
* **InvocationTransaction**：用于调用智能合约。

### 交易结构

* **Type**：交易类型，必须是上述类型之一。 此外，区块的第一个交易必须始终是 ***MinerTransaction***。
* **Version**：交易版本。 目前为0。类似于区块版本，但是在交易级别的。
* **Attributes**：交易具有的其他特性。
* **Inputs**：交易输入。当从一个地址向另一个地址发送NEO时，这代表了对发送方发送的NEO的UTXO引用。
* **Outputs**：交易输出。 当从一个地址向另一个地址发送NEO时，这会为接收方创建一个新的UTXO，以便可以在该区块被挖出后进行花费。
* **Scripts**：用于验证交易的脚本列表。 当从一个地址向另一个地址发送NEO时，用于对输入所引用的任意UTXO的花费进行验证。

## 附加字段

 -  ***confirmations***：在该区块之上构建的区块个数。每当在包含该区块的区块链的顶部确认一个新块时，之后的区块会获得额外的确认。区块结构中不包含这个字段，它是由节点发起RPC请求同步区块时计算得出的。

 -  ***nextblockhash***：下一个区块的哈希，从而形成由区块构成的链表。区块结构中不包含这个字段，它是由节点发起RPC请求同步区块时计算得出的。

## 阅读下节

 [区块创建与广播](3-Block_creation_broadcasting.md)