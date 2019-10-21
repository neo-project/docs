# 交易结构

NEO交易是一个带有网络操作指令的签名数据包，例如，将资产转移到另一个地址。区块链账本中的每个NEO区块都包含有一个或多个交易，使得每个区块可以对交易进行批处理。

目前 NEO单笔交易最大为100 KB，每个区块最多包含500笔交易。 如有必要，这些限制值将来是可以提高的。 NEO可同时支持UTXO（*未花费的交易输出*）模型和基于账户/余额的记录保存模型。 所有原生资产（如NEO和GAS）使用的都是UTXO模型，而所有合约代币都使用账户/余额模型。

## 结构

每个交易都有一个最小的属性集合。

| 字段| 类型| 说明|
|--------------|---------|------------------------------------------|
| `type`       | uint8   | 交易类型             |
| `version`    | uint8   | 兼容版本                 |
| `attributes` | array   | 交易其他属性  |
| `outputs`    | array   | 资产的接收地址       |
| `inputs`     | array   | 交易的资产输入   |
| `scripts`    | array   | 用于验证交易的脚本|

所有交易都会计算出唯一的交易哈希`txid`（uint256）和`size`（uint8）参数。

交易属性的更多信息：

- [type](#type)
- [version](#version)
- [attributes](#attributes)
  - [属性使用类型](#attributes-usage-types)
- [outputs](#outputs)
- [inputs](#inputs)
- [scripts](#scripts)
  - [调用脚本](#invocation-script)
  - [验证脚本](#verification-script)

交易示例:

```javascript
{
   "txid":"0xee85d489e4428a538f39c1903771e1f222a383f8327c96ed19cc02079149a1fd",
   "size":665,
   "type":"ContractTransaction",
   "version":0,
   "attributes":[

   ],
   "vout":[
      {
         "n":0,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"1000",
         "address":"Ae2d6qj91YL3LVUMkza7WQsaTYjzjHm4z1"
      },
      {
         "n":1,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"99999000",
         "address":"AWHX6wX5mEJ4Vwg7uBcqESeq3NggtNFhzD"
      }
   ],
   "vin":[
      {
         "txid":"0x3631f66024ca6f5b033d7e0809eb993443374830025af904fb51b0334f127cda",
         "vout":0
      }
   ],
   "sys_fee":"0",
   "net_fee":"0",
   "scripts":[
      {
         "invocation":"406a159b7552c7eaedc79abc86faeca7aa50af52aaa0f14aa9a4abaf498f270a140709992253df55de1b2fd93a6ea13b5344dacbd4e54e4f661fe073edeb72e2f740e28c0866c2ea963e40f8f6edbc1e40b76181fef43a4016d234602a52b31b83f02d745d57188cd72fcb1a8394a39d77270334374848266bb87a29fa4114d1b13240c1e7eae0e8e8d33b1a16c8ece8e96bc832d8f0a069499b8b9590609d8cd2a799a555f5433bdc153466bf6eefea0a568bd08b28afabfacb673785fe8d59ab82ea404874390b85c4d37d3645e03cae571000f3ca344452c2a4018aab57f73750dfb695c5488e3c9887699a2ff69e539b7e37278f470b03bc357ebaad25c397ef3104",
         "verification":"542102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
      }
   ]
}
```

### type

NEO中有几种不同类型的交易。 每种类型都具有不同的用途和特性。

可用的交易:

  - `ContractTransaction`

  - `InvocationTransaction`

  - `ClaimTransaction`

  - `MinerTransaction`

  - `StateTransaction`

不应再使用的已弃用的交易：

  - `RegisterTransaction`

  - `EnrollmentTransaction`

  - `IssueTransaction`

已删除的交易：

  - `PublishTransaction`

  - `VotingTransaction`

  - `AgencyTransaction`

### version

版本属性允许对交易结构进行更新，使其具有向后兼容性。 目前版本`0`和`1`均支持`InvocationTransaction`交易，而其他类型的交易只能在版本`0`中使用。

### attributes

根据具体的交易类型允许向交易添加额外的属性。 对于每个属性，必须指定使用类型，以及外部数据和外部数据的大小。

| 字段| 类型| 说明|
|----------|-------|---------------------------------------|
| `usage`  | uint8 | 使用类型                  |
| `length` | uint8 | 数据长度 (如有需要)      |
| `data`   | uint8 | 使用类型相关的外部数据|

示例:

```javascript
{
   "attributes":[
      {
         "usage":48,
         "data":"cf62fd54fc761f291d07d68088dd81b8b35a7c444f3af8acd78a3ad4ff75d163"
      },
      {
         "usage":48,
         "data":"aac6d49da8f63cf6442c5f707317bc3e7490029af1a75b83adc0ec3b1b3e1f0f"
      },
      {
         "usage":240,
         "data":"e5a487e6b3a8e58a9fe883bde7acace4b880e6aca1e6b58be8af95efbc8ce880b6efbc81202048656c6c6f2072656d61726b73efbc81"
      },
      {
         "usage":144,
         "data":"5473685f323031372f322f382031363a31383a353931373033323132343035"
      }
   ]
}
```

#### 属性使用类型

以下使用类型可以包括在交易的属性中。

| 使用类型    | 名称| 说明| 长度|
|---------------|-------------------|---------------------------------------|-----------------------------------------|
| `0`           | `ContractHash`    | 合约脚本哈希          | `32`                                    |
| `2`           | `ECDH02`          | 用于ECDH密钥交换的公钥    | `32`                                    |
| `3`           | `ECDH03`          | 用于ECDH密钥交换的公钥   | `32`                                    |
| `32`          | `Script`          | 交易额外的验证| `20`                                    |
| `48`          | `Vote`            | 投票payload                        |应指定(最多255个字节)   |
| `129`         | `DescriptionUrl`  | 描述说明的URL                | 应指定 (最多255个字节)   |
| `144`         | `Description`     | 说明            |应指定 (最多255个字节   |
| `161` - `175` | `Hash1-Hash15`    | 自定义的存储哈希        | `32`                                    |
| `240` - `255` | `Remark-Remark15` | 自定义的一般备注             |应指定 (最多65535个字节) |

每个交易最多可添加16个属性。

### outputs
一个输出`vout`代表了交易的一个结果，表示转账到地址的资产金额。 每笔交易最多可以有`65536`个输出。 对输出的验证取决于所使用的交易类型。

| 类型| 说明|
|-----------------------------|-------------------------------------------------------------------------------------------------|
| `IssueTransaction`          |要求交易由资产管理合约签名                   |
| `ClaimTransaction`          |需要在交易的`claims`属性中引用一个或多个未提取的输出   |
| `MinerTransaction`          |要求`inputs`为空，并且`outputs`中的金额与区块中的所有系统费相匹配|

所有其他交易都需要在交易的`inputs`属性中引用一个或多个未花费的输出。

网络将验证要求是否得到满足以及`outputs`中的资产总额是否超过该交易的可用金额。 输出数组中的每个输出都有一组必需的属性。

| 字段| 类型| 说明|
|-----------|---------|------------------------------------------------------------------|
| `asset`   | uint256 |资产注册的交易哈希（唯一的资产ID） |
| `value`   | int64   |要转账的资产金额                         |
| `address` | uint160 |资产要转入的地址                      |

对于输出数组中的每个输出，都会计算一个唯一索引`n`。 每个输出只能在新交易中作为输入被引用一次。

示例:

```javascript
{
   "vout":[
      {
         "n":0,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"10000",
         "address":"AXwJzQTtLKvzy2nxHUgQFxokh1GpuxCEdf"
      },
      {
         "n":1,
         "asset":"0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
         "value":"1864",
         "address":"ALaDzzomLTccNfNPPeWh7NLRW1UasyWvi5"
      }
   ]
}
```

### inputs

输入`vin`是对先前交易中未花费的输出的引用。 这个引用表示要转入到某个地址的资产金额。 每个交易最多可以有`65536`个输入。 输入数组中的每个输入都有一组必需的属性。

| 字段| 类型| 说明|
|--------|---------|------------------------------------------------|
| `txid` | uint256 |被引用的输出所属交易的哈希  |
| `vout` | uint16  |作为输入的输出在数组中的索引|

一旦前一个交易的输出被作为输入，它将被视为“已花费”并且不能再使用。

示例:

```javascript
{
   "vin":[
      {
         "txid":"0xa3a6f522beb92fedeb508b4ece820ecbb34f3892af36c0082045d17aac62e6fc",
         "vout":241
      }
   ]
}
```

### scripts

脚本属性用于验证交易的有效性和完整性。 脚本数组中的对象通常被称为`见证人`。 脚本数组中的每个见证人都有两个属性。

| 字段 | 说明|
|----------------------|---------------------------------------------------------------------------------------------|
| `InvocationScript`   |调用脚本，给验证脚本提供有效签名信息                    |
| `VerificationScript` |验证脚本，推送与（多签名）合约相对应的公钥 |

如果交易是`ContractTransaction`类型，其中资产在`inputs`属性中，那么节点会对属于该输入的签名和公钥进行验证。 每笔交易可以有多个见证人，也可以使用具有多签名的见证人。

示例:

```javascript
{
   "scripts":[
      {
         "invocation":"406a159b7552c7eaedc79abc86faeca7aa50af52aaa0f14aa9a4abaf498f270a140709992253df55de1b2fd93a6ea13b5344dacbd4e54e4f661fe073edeb72e2f740e28c0866c2ea963e40f8f6edbc1e40b76181fef43a4016d234602a52b31b83f02d745d57188cd72fcb1a8394a39d77270334374848266bb87a29fa4114d1b13240c1e7eae0e8e8d33b1a16c8ece8e96bc832d8f0a069499b8b9590609d8cd2a799a555f5433bdc153466bf6eefea0a568bd08b28afabfacb673785fe8d59ab82ea404874390b85c4d37d3645e03cae571000f3ca344452c2a4018aab57f73750dfb695c5488e3c9887699a2ff69e539b7e37278f470b03bc357ebaad25c397ef3104",
         "verification":"542102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
      },
      {
         "invocation":"407ee3f7f7ee3e0be4c3a3bf367f710e666e8ccf0e7f08681e3df90cb69f82476c2d04e09133045f00d5cf1753c6c11bded45e96f6742dda54dbfbd7c05024eb35",
         "verification":"21027ec2a9f042a8a702b061faace75966c7199b6a6524c08002da22f54cbf4c4da0ac"
      },
      {
         "invocation":"4031c35a44fb2a24718c43bfcff92dd20e8d129f331c7944830665ea1072382233e5d368a8c8942fb60c55867bacf9aac38a7cb01470a01b41e07c509ca4b68974",
         "verification":"2102a1e6ed9a5cff73ad33b7896465af8e9206eab9c8c75502868b783deb64f232eaac"
      }
   ]
}
```

#### 调用脚本

调用脚本可以通过以下步骤进行构造：

- `0x40`（PUSHBYTES64）后跟（第一个）64字节长的签名

通过重复这些步骤，调用脚本可以为多签名合约推送多个签名。

#### 验证脚本

具有单个签名的验证脚本可以通过以下步骤进行构建：

1. `0x21`（PUSHBYTES33）后跟33字节长的与签名相对应的公钥
2. `0xAC`（CHECKSIG）使用所提供的公钥对签名进行验证

具有多签名合约的验证脚本可以通过以下步骤进行构建：

1. `0x52`（PUSH2）到`0x60`（PUSH16）表示所需的签名数量
2. `0x21`（PUSHBYTES33）后跟多签名合约的第一个33字节长的公钥，对多签名合约中的每个公钥重复这个步骤
3. `0x52`（PUSH2）到`0x60`（PUSH16）表示签名的公钥总数
4. `0xAE`（CHECKMULTISIG）用所提供的公钥对签名进行验证

为了保证性能，在验证多签名合约时，公钥和签名的顺序必须保持一致。

## 阅读下节

[交易类型](3-NEO_transaction_types.md)

