# 加密算法

## ECC椭圆曲线加密

ECC椭圆曲线素数加密算法是一种非对称加密算法。利用其K=k\*G过程不可逆的特性（其中K为公钥，G为基点（常数点）），可以预防通过公钥暴力求解私钥。相较于RSA等其他加密算法，在相同密钥长度情况下，其具备更高的安全性，同时更节约算力。ECC结合其他算法广泛应用于签名等领域，例如 ECDSA 数字签名。

Neo与比特币一样都采用ECC作为其公钥生成算法，NEO采用了secp256r1标准所定义的一条特殊的椭圆曲线，使用的参数：

素数素数Q：00FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFF

椭圆曲线的系数A：00FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFC

椭圆曲线的系数B：005AC635D8AA3A93E7B3EBBD55769886BC651D06B0CC53B0F63BCE3C3E27D2604B

阶数N：00FFFFFFFF00000000FFFFFFFFFFFFFFFFBCE6FAADA7179E84F3B9CAC2FC632551

基点G：(0x6B17D1F2E12C4247F8BCE6E563A440F277037D812DEB33A0F4A13945D898C296,
　　　　0x4FE342E2FE1A7F9B8EE7EB4A7C0F9E162BCE33576B315ECECBB6406837BF51F5)

Example:

| 名称 | 数值 |
| --- | --- |
| 私钥   |  c7134d6fd8e73d819e82755c64c93788d8db0961929e025a53363c4cc02a6962 |
| 公钥(压缩型) |  035a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a |
| 公钥(非压缩型) | 045a928f201639204e06b4368b1a93365462a8ebbff0b8818151b74faab3a2b61a 35dfabcb79ac492a2a88588d2f2e73f045cd8af58059282e09d693dc340e113f |

> [!NOTE]
>
> 上面的非压缩型公钥因为太长而成为两行，实际数据是连接的。

应用场景：

- 私钥生成公钥

- 签名和验证签名

更多信息，请参考[一个关于椭圆曲线密码学的初级读本 ](https://arstechnica.com/information-technology/2013/10/a-relatively-easy-to-understand-primer-on-elliptic-curve-cryptography/)。


## ECDSA 签名

椭圆曲线数字签名算法（ECDSA）是使用椭圆曲线密码（ECC）对数字签名算法（DSA）的模拟。其优点是速度快，强度高，签名短。

其基本使用方法如下：

假设私钥、公钥、基点分别为k、K、G，根据ECC算法可知有K = k·G。

签名过程：

   1. 选择随机数r，计算点r·G(x, y)。

   2. 根据随机数r、消息M的哈希h、私钥k，计算s = (h + k·x)/r。
    
   3. 将消息M、和签名{r·G, s}发给接收方。

验证过程：

   1. 接收方收到消息M、以及签名{r·G=(x,y), s}。

   2. 根据消息M求哈希h。
   
   3. 使用发送方公钥K计算：h·G/s + x·K/s，并与r·G比较，如相等即验签成功。

推导原理如下：

[![formula_ecdsa](../../images/blockchain_paradigm/formula_ecdsa.jpg)](../../images/blockchain_paradigm/formula_ecdsa.jpg)

Example:

| 名称 | 数值                                                         |
| ---- | ------------------------------------------------------------ |
| 消息 | Hello World                                                  |
| 私钥 | f9be359876aac462df9ec642e5d063140daedb83aefc0f8657b08132d3da62d2 |
| 公钥 | 04ed08d3bc46390a54350d841c8110ca02f9e357f8ba08702078de2d7041727<br>5956e94045d041a2bf89be25d5a56ddcf15c4f629d5a1db32657d0da13ebde64b29 |
| 签名 | 54a6faec9159e98d45f5868e5799762de290c3e7e67e013c1bd6a2a6f8a2e500<br>a4d29567359bd171ddebc547dcddd670fb6b367e3e19298d7672f0422b5a2c52 |

> [!NOTE]
>
> 上面的公钥和签名因为太长而成为两行，实际数据是连接的。

应用场景：

- 交易的签名。

- 共识

## AES 加密

AES 是对称加密算法中的一种分组算法，分组长度为 128、192、256 位三种。AES 的优势在于处理速度快，整个过程可以数学化描述，目前尚未有有效的破解手段。

Neo 中使用的是 256 位 AES 加密算法。加密模式为 ECB 模式，填充方式是 NoPadding。

Example：

  1. msg,key----->passphrase-protected msg

　　（消息："Hello World"的256位哈希") +（密码："l love coding"的256位哈希)

　　="a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e"

　　　+"da04fe4405fc021e4ca5ca956b263828e99d4ce2a342b2cbdc919baddbe178ae"

　　---->"a8158a64c1e9d776e12582d8c63553ee0c7687bd8e374f79c766e7459577f547"

  2. passphrase-protected msg,key----->msg

　　加密密文 +（密码："l love coding"的256位哈希)

　　="a8158a64c1e9d776e12582d8c63553ee0c7687bd8e374f79c766e7459577f547"

　　　+"da04fe4405fc021e4ca5ca956b263828e99d4ce2a342b2cbdc919baddbe178ae"

　　---->"a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e"

应用场景：

DB3钱包账户密码的存储、验证
