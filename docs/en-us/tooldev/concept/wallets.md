# 钱包

钱包是Neo的基础组件，是用户接入Neo网络的载体，负责完成与之相关一系列的工作和任务。Neo的钱包可以自行设计和修改，但需要满足一定的规则和范式。


## **钱包中的数据格式**
Neo钱包主要处理地址(Address)、私钥(Private Key)、公钥(Public Key)、脚本哈希(ScriptHash)和WIF这五种数据。它们之间可以相互转化。

NEP <=> WIF <=> Private Key => Public Key => ScriptHash <=> Address

这里给出一个更清楚的图示，还要给出每个数据的长度和使用情况。

同比特币一样，私钥是最关键的保密数据，公钥可以由私钥算得，反之不可。同私钥等价的NEP和WIF也应该妥善保管。而可由公钥推出的ScriptHash和Address都是公开的。他们用在不同的场合。比如，Address类似一个银行卡号，在用户做转账时使用。ScriptHash则用在具体交易信息中的Input和Output。

### 私钥

私钥是一个随机生成的位于1和n之间的任何数字（n是⼀个常数，略小于2的256次方），一般用一个256bit(32字节)数表示。在NEO中私钥主要采用两种编码格式：

- **hexstring格式**

hexstring格式是将byte[]数据使用16进制字符表示的字符串。

- **wif格式**

wif格式是在原有32字节数据前后添加前缀0x80和后缀0x01,并做Base58Check编码的字符串

[![Base58Check编解码](../images/blockchain/wallets/privateKey-wif.png)](../../images/blockchain/wallets/privateKey-wif.png)

Example: 

| 格式 | 数值 |
|---|---|
| byte[] | [0xc7,0x13,0x4d,0x6f,0xd8,0xe7,0x3d,0x81,0x9e,0x82,0x75,<br>0x5c,0x64,0xc9,0x37,0x88,0xd8,0xdb,0x09,0x61,0x92,0x9e,<br>0x02,0x5a,0x53,0x36,0x3c,0x4c,0xc0,0x2a,0x69,0x62] |
| hexstring | c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962 |
| wif | L3tgppXLgdaeqSGSFw1Go3skBiy8vQAM7YMXvTHsKQtE16Dw58cV |

### 公钥

公钥是通过ECC算法将私钥运算得到的一个点（x,y）。该点的x、y坐标都可以用32字节数据表示。neo与比特币稍有不同，neo选取了secp256r1曲线作为其ECC算法的参数。在neo中公钥有两种编码格式：

- **非压缩型公钥**

0x04+x坐标（32字节）+y坐标（32字节）

- **压缩型公钥**

0x02/0x03+x坐标（32字节）

Example:

| 格式 | 数值 |
|----------|:-------------:|
| 私钥 | c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962|
| 公钥（压缩型） | 035a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a |
| 公钥（非压缩型） | 045a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74<br>faab3a2b61a35dfabcb79ac492a2a88588d2f2e73f045cd8af58059282e09d693dc340e113f  |

<a name="3_address"/>

> [!NOTE]
>
> 上面的公钥（非压缩型）因为太长而成为多行，实际数据是连接的。

### 地址

地址是由公钥经过一系列转换得到的一串由数字和字母构成的字符串。在neo中，公钥到地址的转换步骤如下：

1. 构建地址脚本合约(脚本合约格式：

`0x21`(1字节,代表Opcode中PushBytes指令)+压缩型公钥(33字节) + `0xac`（1字节,代表Opcode中 CheckSig指令))

2. 计算地址脚本合约哈希(20字节，地址脚本合约做一次sha256和riplemd160得到)

3. 在地址脚本合约哈希前添加版本号（ 目前neo所使用的协议版本是23所以对应字节为0x17）

4. 对字节数据做Base58Check编码

Example：

| 格式 | 数值 |
|----------|:-------------:|
| 私钥 | c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962|
| 压缩型公钥 | 035a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a |
| 地址 | AXaXZjZGA3qhQRTCsyG5uFKr9HeShgVhTF  |

### 数字证书
数字证书是一个经证书授权中心数字签名的包含公开密钥拥有者信息以及公开密钥的文件。
Neo使用的是X509格式的证书。

## **钱包文件**

###  db3钱包文件

db3钱包文件是neo采用sqlite技术存储数据所使用存储文件，文件尾缀名：`.db3`。 文件中主要存储以下四个属性：

- `PasswordHash`：密码的哈希，由密码做sha256得到

- `IV`：AES的初始向量，随机生成

- `MasterKey`：加密密文，由PasswordHash、 IV对私钥做AES256加密得到

- `Version`：版本

db3钱包采用对称加密AES相关技术作为钱包的加密和解密方法。

### NEP6钱包文件

NEP6钱包文件是neo满足NEP6标准的钱包存储数据所使用存储文件，文件尾缀名：`.json`。 json文件格式如下：

```json
{
	"name": null,
	"version": "1.0",
	"scrypt": {
		"n": 16384,
		"r": 8,
		"p": 8
	},
	"accounts": [{
		"address": "AZ6AsQ42HLkzN1SdwDfWMfNdECN41QGvWP",
		"label": null,
		"isDefault": false,
		"lock": false,
		"key": "6PYKXU9ZkVTkdRzFdHUBH8SL6ESGS5SYx94UeYpeEUnG2z8H2Fvdh47EN9",
		"contract": {
			"script": "210209c86ad123403f7ddaa80f6b4c72e6f46607cabed5b2c297e27812cdd755f2c2ac",
			"parameters": [{
				"name": "signature",
				"type": "Signature"
			}],
			"deployed": false
		},
		"extra": null
	}, {
		"address": "AeiXnh6T47CQ5HwpJ9rE3CrMr6UT6VsGXt",
		"label": null,
		"isDefault": false,
		"lock": false,
		"key": "6PYUdZvc35rD9MetztTCScgwsGV81r167M1rMx5FeG5YLHSkmcTCGEShUh",
		"contract": {
			"script": "2102cb8f7571d8ed87f3a6c8c5af8bc0fbfababf4d9927dc8899af57bc362271c0a0ac",
			"parameters": [{
				"name": "signature",
				"type": "Signature"
			}],
			"deployed": false
		},
		"extra": null
	}],
	"extra": null
}
```

属性说明：

* name:名称

* version：版本

* scrypt（n/r/p）：scrypt算法设置CPU性能的三个参数

* accounts：钱包所包含的账户的集合

* address:账户地址

* label：标题

* isDefault：是否默认账户

* lock：是否打开

* key：按照NEP2标准加密的密钥nep2Key

* contract：地址脚本合约的详细内容

* script：地址脚本合约的字节

* parameters：地址脚本合约的参数表

* contract/name：地址脚本合约参数的名称

* type：地址脚本合约参数的类型

* deployed：是否部署

* accounts/extra：账户其他扩展属性

* extra：钱包其他扩展

NEP6钱包采用了以scrypt为核心算法的相关技术作为钱包的加密和解密方法。

**加密过程**：

1. 由公钥计算地址，并获取SHA256(SHA256(Address))的前四个字节作为地址哈希。

2. 使用Scrypt算法算出一个derivedkey，并将其64个字节数据分成2半，作为derivedhalf1和derivedhalf2。Scrypt所使用参数如下：

	- 密文：输入的密码（UTF-8格式）
	- 盐：地址哈希
	- n：16384
	- r：8
	- p：8
	- length：64

3. 把私钥和derivedhalf1做异或，然后用derivedhalf2对其做AES256加密得到encryptedkey

4. 按照以下格式拼接数据，并对其做Base58Check编码得到NEP2Key

    `0x01` + `0x42` + `0xe0` + `地址哈希` + `encryptedkey`


**解密过程**：

1. 对NEP2key做Base58Check解码。

2. 验证解码后数据长度为39，以及前3个字节（data[0-2]是否为0x01、0x42、0xe0）

3. 取data[3-6]作为addresshash

4. 把密码、addresshash代入Scrypt算法指定结果长度为64求出导出密钥Derivedkey

5. 把Derivedkey前32字节作为导出半数1 Derivedhalf1，后32字节作为导出半数2 Derivedhalf2

6. 取data[7-38]作为加密密钥Encryptedkey（32字节），并用
导出半数2 Derivedhalf2作为初始向量对其进行AES256解密

7. 把解密结果与导出半数1 Derivedhalf1做异或处理求得私钥

8. 把该私钥做ECC求出公钥，并生成地址，对该地址做2次Sha256然后取结果的前四字节判断其是否与addresshash相同，相同则是正确的私钥。（参考NEP2）

相关详细技术请参照neo文档中的NEP2和NEP6提案。

​        NEP2提案：<https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki>

​        NEP6提案：<https://github.com/neo-project/proposals/blob/master/nep-6.mediawiki>

## **钱包功能**

| 功能名称         | 功能描述                                                     |
| ---------------- | ------------------------------------------------------------ |
| 导入钱包文件     | 使钱包软件加载指定钱包文件内的数据，建议兼容NEO所使用的两种格式文件：.db3和.json |
| 导出钱包文件     | 将用户的账户列表信息（包含私钥、密码、地址等信息）存入指定钱包文件内。建议使用NEO所使用的两种格式文件：.db3和.json |
| 解锁钱包         | 验证用户密码，预防泄密                                       |
| 创建私钥         | 生成私钥，建议使用安全的随机源生成                           |
| 导入私钥         | 向钱包内添加新的私钥，可以使用wif格式、数字证书导入          |
| 导出私钥         | 导出钱包内账户的私钥                                         |
| 生成公钥         | 根据私钥生成公钥，使用ECC算法生成                            |
| 生成地址         | 根据私钥生成地址                                             |
| 导入地址         | 向钱包内添加新的地址（账户）                                 |
| 导出地址         | 导出钱包内账户的地址                                         |
| 导入离线同步数据 | 加载chain.acc内的区块数据，减少同步时间                      |
| 导出离线同步数据 | 导出本地的区块数据，需满足chain.acc格式                      |
| 同步区块数据     | 同步最新的区块数据                                           |
| 转账             | 向其他地址转账                                               |
| 签名             | 给多方签名合约签名                                           |
| 提取gas          | 提取账户所持有的neo新分配到的gas                             |
| 显示余额         | 显示账户余额                                                 |
| 显示交易         | 显示交易记录                                                 |
| 构建多方签名合约 | 创建多方签名合约                                             |
| 扩展功能         |                                                              |
| 部署智能合约     | 发布智能合约                                                 |
| 测试智能合约     | 测试智能合约                                                 |


## **两种节点类型对应的钱包**

### 全节点钱包

全节点钱包是对区块链数据的完整备份，保存了链上的所有数据，同时也参与了P2P网络的构建，因此需要占用较大的存储空间。neo-cli、neo-gui都是全节点钱包。

### 轻钱包

SPV钱包又可称为“轻钱包”，不同于全节点钱包，它不存储全部区块的数据，只存储区块头数据，并通过使用布隆过滤器和梅克尔树等算法来实现相关数据的验证。能有效节约存储空间，多用在手机App端或轻客户端。若需要开发SPV钱包，可参考NEO网络协议相关接口实现。

使用方式：

   1. SPV钱包向全节点发送布隆过滤器，并由全节点加载布隆过滤器

   2. SPV钱包向全节点发送布隆过滤器参数，并由全节点加载相应布隆过滤器参数（可选）。

   3. SPV钱包向全节点用区块hash查询交易数据，全节点使用布隆过滤器过滤后返回交易数据以及构建的梅克尔树路径（待确认）
   
   4. SPV钱包用梅克尔树路径验证交易数据有效性（待确认）

   5. SPV钱包向全节点发送指令清除布隆过滤器，全节点清除过滤器。
