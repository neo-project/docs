# 交易类型

NEO中有几种不同类型的交易，每种交易都有不同的用途和属性。一些以前使用的交易类型现在已经被弃用或删除，因此在主网上创建交易时不应该再使用这些类型。

| 字节| 名称| 状态| 交易费用| 说明|
|--------|-------------------------|--------------|-----------------|---------------------------------------------------------|
| `0x00` | `MinerTransaction`      | *活跃*     | `0`             | 区块中的第一个交易，用于分发网络费用|
| `0x01` | `IssueTransaction`      | *弃用* | `500`           |从已注册的原生资产中发行资产            |
| `0x02` | `ClaimTransaction`      | *活跃*     | `0`             | 从未提取的交易输出中提取GAS           |
| `0x20` | `EnrollmentTransaction` | *弃用* | `1000`          | 申请成为共识节点候选人               |
| `0x24` | `VotingTransaction`     | *删除*    | `0`             | 为共识节点候选人投票                     |
| `0x40` | `RegisterTransaction`   | *弃用* | `10000`         | 在区块链上注册一个新的原生资产         |
| `0x80` | `ContractTransaction`   | *活跃*     | `0`             |常见交易类型，用于资产转账     |
| `0x90` | `StateTransaction`      | *活跃*     | `0`             |为共识节点候选人投票或者注册为共识节点候选人|
| `0xb0` | `AgencyTransaction`     | *删除*    | `0`             | 在区块链上下单              |
| `0xd0` | `PublishTransaction`    | *弃用* | `500`           |  发布智能合约             |
| `0xd1` | `InvocationTransaction` | *活跃*     | `0`             | 调用智能合约              |

### MinerTransaction

区块中的第一个交易。由议长节点在共识期间生成，并将收集和分发该区块中的所有网络费用。

#### MinerTransaction的额外属性:

| 字段| 类型| 说明|
|---------|--------|---------------------------------------------------|
| `nonce` | uint32 | 确保交易哈希唯一性的随机数 |

示例:

```javascript
{
   "txid":"0xdbf3ad80e483c56b996fcc1264384f87a86a889d3cc2c79888200d347923f6c6",
   "size":70,
   "type":"MinerTransaction",
   "version":0,
   "attributes":[

   ],
   "vout":[
      {
         "n":0,
         "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
         "value":"0.001",
         "address":"AWHX6wX5mEJ4Vwg7uBcqESeq3NggtNFhzD"
      }
   ],
   "vin":[

   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[

   ],
   "nonce":960164232
}
```

### ClaimTransaction

从未提取的交易输出中提取GAS

#### ClaimTransaction的额外属性:

| 字段| 类型| 说明|
|----------|-------|------------------------------------------------------|
| `claims` | array | 引用前一个交易的已花费输出|

#### claims
`claim` 指的是引用前一个交易的已花费的[`输出`](transactions.md#outputs) (只用于NEO)。 每个交易最多可以有65536个claim引用。claims数组中的每个claim引用都有一组必需的属性。

| 字段| 类型| 说明|
|--------|---------|------------------------------------------------|
| `txid` | uint256 | 被引用的输出所属交易的哈希|
| `vout` | uint16  | 作为输入的输出在数组中的索引|

一旦前一个交易的输出被用于claim引用，该输出就会被视为`已提取`，并且之后也不能再被提取了。可提取的GAS数量将通过所有区块中的总的GAS分布来计算，而被引用的NEO资产位于相应的合约地址中。

示例:

```javascript
{
   "txid":"0x30f90c7df4c02984bcdc11abd68ffef01557eed3ccadc1b653ab918842ecdfcc",
   "size":237,
   "type":"ClaimTransaction",
   "version":0,
   "attributes":[

   ],
   "vout":[
      {
         "n":0,
         "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
         "value":"0.03326015",
         "address":"ANAP9Afv5WxJzgw5j5Q3zrY71QWMAwhZHg"
      }
   ],
   "vin":[

   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[
      {
         "invocation":"40da65923fbfb60ee9f94882e1df1d11dfefa1eae89cb989ec6e27007108c4d7db4e134ce9be5636436fae1209bb44c308f8b9eef3dcbc73d1a0132b8dab9f07de",
         "verification":"210282606b2b58cbbeb25890d35e5b7480089fa726e5f625fdb3193a2677b3a6ebf6ac"
      }
   ],
   "claims":[
      {
         "txid":"0x84d91a7641f038a03a7e93ddfd0d7f546aba3b4494dd4d7981552abdf2890593",
         "vout":0
      },
      {
         "txid":"0x3c256425d2f650572fdcef7101cfb845bd668170e3fbc5b55ef10bd4d8b6ac1a",
         "vout":0
      }
   ]
}
```

### ContractTransaction

常见的交易，用于资产转账。 `ContractTransaction`用于向其他合约地址发送NEO或者GAS。

#### ContractTransaction的额外属性:

不需要其他额外的属性。

示例:

```javascript
{
   "txid":"0x3d5b91a488a12ec091fff743b1670c008cc1962f3aa98e760981016685e9c668",
   "size":211,
   "type":"ContractTransaction",
   "version":0,
   "attributes":[
      {
         "usage":255,
         "data":"6e656f2d6f6e65"
      }
   ],
   "vout":[
      {
         "n":0,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"12",
         "address":"ATNjqV62Azg3yLw4Tfc6yhKyUCSsqjQ6iA"
      }
   ],
   "vin":[
      {
         "txid":"0xdd5fb8bfac04742788e1d0a73307d1eeb87d098165eb248d481fb84448742003",
         "vout":0
      }
   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[
      {
         "invocation":"407eea3ba920b48973e7f3d5d4e532fe3011d02da3e75daaa20f310c3248ed49a97f5dad0a28178c9473b52ed04c8fa2ffe2f49eb8e6e4a8ed5968d4a507283c86",
         "verification":"21029d910eb93122578d0ddf0443f96f4cdece42a7e4e404ae047a75734c1aa4738eac"
      }
   ]
}
```

### StateTransaction

为共识节点候选人投票或者注册为共识节点候选人。

#### StateTransaction的额外属性:

| 字段| 类型| 说明|
|---------------|-------|-----------------------|
| `descriptors` | array | 状态描述符列表|

#### descriptors

`descriptor` 包含有投票信息。可用于申请成为共识节点或者为共识节点候选人进行投票。

| 字段| 类型| 说明|
|---------|--------|--------------------------------------|
| `type`  | uint8  | 状态描述符类型               |
| `key`   | byte   | 合约脚本哈希或者公钥   |
| `field` | string | 待更新的状态字段                |
| `value` | byte   | 已更新的状态字段值    |

#### type

状态描述符类型为 `0x40`时，代表`账户` ； 为`0x48` 时，代表`验证人`。如果将此类型设置为账户类型，则可以使用描述符来对投票进行更新。如果设置为验证人类型，则它用于将注册状态更新为共识节点候选人。

#### key

如果为账户类型，则key代表投票合约的20字节长的脚本哈希；如果为验证人类型，则key为验证人的33字节长的公钥。

#### Field

待更新的状态字段。可以是`Registered`，用于设置验证人请求，也可以是`Votes`，用于设置账户投票。

#### Value


已更新的状态字段值。如果验证人想要注册成为共识节点候选人，那么他可以将`Registered`字段设置为值`true`，或者通过将`Registered`设置为`false`来取消注册。如果一个账户想要投票给共识节点，他可以设置一组公钥进行投票。

示例:

```javascript
{
   "txid":"0x7031bbc63b5087ed1e84a7a6f02a4b5c7a998c800862f0b5d1e745128bdd152f",
   "size":271,
   "type":"StateTransaction",
   "version":0,
   "attributes":[

   ],
   "vout":[

   ],
   "vin":[

   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[
      {
         "invocation":"40f74883a23083f9a236b01aec3eb016e4611ac23cf3036addf8957460917bad4bb968cbbb93e321da368e11da77defca0342299dd8806e9953c0def13c6b348f4",
         "verification":"21034278b37db70b6c59b1e68a34569b77c5470ed50b9a1176b0d2da1b1b601ae86cac"
      }
   ],
   "descriptors":[
      {
         "type":"Account",
         "key":"ce47912d51b7ed8a24a77f97f2cb6ef9a0e0bf0d",
         "field":"Votes",
         "value":"04024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d02aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e02ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba55402df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e895093"
      }
   ]
}
```

### InvocationTransaction

在区块链上调用或者部署智能合约。

#### InvocationTransaction的额外属性:

| 字段| 类型| 说明|
|----------|-------|----------------------------------------------|
| `script` | byte  | 虚拟机执行的脚本|

#### Script

`script`是要执行的NVM字节码。它可以是一个独立的脚本，已经部署的使用 AppCall opcode 智能合约的调用，或者通过使用`neo.contract.create`指令部署新的智能合约。

示例:

```javascript
{
   "txid":"0x1ae96d64e4d88a31f21f8a05a5370600efb3a7aa55e6fec6057f895f5ba91c16",
   "size":231,
   "type":"InvocationTransaction",
   "version":1,
   "attributes":[

   ],
   "vout":[
      {
         "n":0,
         "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
         "value":"1011.92212",
         "address":"ALEN8KC46GLaadRxaWdvYBUhdokT3RhxPC"
      }
   ],
   "vin":[
      {
         "txid":"0x33b241c922c7178c1fc50c0bf104ab729a851b77c2073be842c69712ceac2118",
         "vout":0
      }
   ],
   "sys_fee":"0",
   "net_fee":"0.0001",
   "scripts":[
      {
         "invocation":"401ba0d3ba2751842cca57c562ad31617cec8187fe0fa894ca71e0a1dfb29f87e6753615528336be273a7ef90601c9ba1b7719beaa0cc5113ec4dc11e5b52b68a0",
         "verification":"2103ed613933d4745622e7c626275c5e74dac1a595d07a9ada02b31104ebb6330aa2ac"
      }
   ],
   "script":"00c104696e69746771496142de066bd6b7a2d6a166dc47a543d1c0ba"
}
```

## 注册资产（已弃用）

NEO支持使用`RegisterTransaction`和`IssueTransaction`交易在区块链上注册原生（UTXO）资产。 NEO和GAS都属于这类原生资产。 对于数字资产的注册，现在更常见的是使用（NEP-5兼容）智能合约。 使用智能合约比使用原生资产有着更高的可扩展性和灵活性。 可以使用[InvocationTransaction](#InvocationTransaction)交易将新的代币智能合约部署到区块链上。

## 阅读下节

[交易手续费](4-NEO_transaction_fees.md)