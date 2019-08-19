# 资产和账户

### Asset

NEO中资产包含两种：一种是用户发行的UTXO类型的全局资产，NEO与GAS在创世块中被定义发行。另外一种，用户通过智能合约发布的如NEP-5资产。前者信息记录在资产账户信息中，见下表，后者存储在合约的存储空间。

| 尺寸 | 字段 | 名称 | 类型 | 描述 |
|--|-------|-----|------|------|
| 32  | AssetId | 资产Id | UInt256 | `assetid = tx.hash` |
| 1 | AssetType | 类型 | AssetType | |
| ? | Name | 资产名字 | string | 存放的是公钥列表 |
| 8 | Amount | 总量 |Fixed8 |  `amount = -Fixed8.Satoshi = -1 = 无穷大`  |
| 8 | Available | 剩余量 | Fixed8 |   |
| 1 | Precision | 精度 | byte |   |
|1 | FeeMode | 费用模式 | const byte |   |
| 8 | Fee | 费用 | Fixed8 |   |
| 20 | FeeAddress |  | UInt160 | 默认null   |
| ? | Owner | 所有者 | ECPoint |   |
| 20 | Admin | 管理员 | UInt160  |   |
| 20 | Issuer | 发行者 | UInt160 |   |
| 4 | Expiration | 过期时间 | uint  |   |
| 1 | IsFrozen | 是否冻结 | bool |   |

> [!NOTE]
>
> 总量的模式有两种: 一种不限量，总量设置为` -Fixed8.Satoshi`，表示无穷大. 另外一种是限定不可修改的总量。

### AssetType

| 字段 | 值 | 描述 |
|-------|-----|----|
| CreditFlag | 0 |  |
| DutyFlag | 0x80 |  |
| GoverningToken | 0x00 | Neo |
| UtilityToken | 0x01 | Gas |
| Currency | 0x08 |  |
| Share | DutyFlag &#124; 0x10 | 股权类 |
| Invoice | DutyFlag &#124; 0x18 |  |
| Token | CreditFlag &#124; 0x20 | 普通token |

> [!NOTE]
>
> 资产类型包含`DutyFlag`值时，都需要进行收款方签名。

| 资产名称 | 类型 | 值 |  总量 | 描述 |
|-------|----|-----|-------|--------|
| NEO |  AssetType.GoverningToken | 0x00 | 1亿 | 一次性发放，创世块中全部转移到备用共识节点多方签名合约地址上 |
| GAS | AssetType.UtilityToken | 0x01 | 1亿 | 按区块新增，持有NEO的用户通过`ClaimTransaction`提取GAS |

### Account

NEO网络中，账户(account)模型和UTXO模型并存。账户记录了UTXO类型的全局资产的用户资金和用户投票。

| 尺寸 | 字段 | 名称 | 类型 | 描述 |
|--|-------|-----|------|------|
| 20  | ScriptHash | 地址脚本hash | UInt160 |   |
| 1 | IsFrozen | 是否冻结 | bool |  冻结用户的资产不能转账  |
| ? * ? | Votes | 投票地址 | ECPoint[] | 投票地址列表 |
| ? | Balances | UTXO资产 |Dict<UInt256, Fixed8> | 资产Id -> 数量  |
