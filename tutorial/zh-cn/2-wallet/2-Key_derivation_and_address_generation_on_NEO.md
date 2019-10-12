# 密钥和地址
现在我们已经对钱包的本质有所了解，那么我们又该如何生成一个钱包呢？ 首先，我们要生成一个私钥，它是一个64字符长的十六进制字符串， 代表的是范围在0到2 ^ 256（1.15792089e77）之间的数字。 利用私钥可以推出 “账户”的其余部分信息。 账户中将包含私钥，WIF（钱包导入格式），公钥和地址。

技术上来说，这个随机的数据源可以来自任何熵源，但它应该由某种形式的加密数字生成算法来生成。 大多数现代编程语言都会通过标准库中提供的安全随机函数来生成私钥。

对钱包软件而言，第一个真正的难题是从生成的私钥中推出账户的其他所有信息。 下面让我们详细介绍如何生成这些信息。

## WIF
WIF相对来说比较好理解。 在实际操作中，最终生成的私钥可能是这样的：
```
0C28FCA386C7A227600B2FE50B7CAEEC86D3BF1FBE471BE89827E19D72AA1D 
```

更好的做法是使用一种可读性更强的方式呈现，所以我们可以将私钥转换为WIF格式，也称为钱包导入格式

```
5HueCGU8rMjxEXxiPuD5BDku4MkFqeZyd4dZ1jvhTVqvbTLvyTJ
```

虽然这仍不能让人完全理解，但肯定会比使用原字符串好。 WIF还能提供一些基本的错误检查，因此当发送代币到WIF格式的地址时，你更有可能发现错误。 从原始的私钥到WIF格式的转换是通过Base58Check算法实现的。

## Base58Check编码
Base58与常见的Base64编码方案类似，只不过它除去了非字母数字的字符以及那些肉眼看起来相似的字符。 例如，0（零），O（大写o），I（大写i）和l（小写L）都在Base58编码方案中删除了。 NEO 的 Base58 编码中可用字符的完整列表是
```
123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz
```

下面是用 Go 语言编写的 NEO 检验编码的完整实现：

```go
func b58checkencode(ver uint8, b []byte) (s string) {
	/* 在原有的字节数据前添加前缀：版本号*/
	bcpy := append([]byte{ver}, b...)

	/* 创建一个新的SHA256*/
	sha256_h := sha256.New()

	/* SHA256哈希 #1 */
	sha256_h.Reset()
	sha256_h.Write(bcpy)
	hash1 := sha256_h.Sum(nil)

	/* SHA256哈希 #2 */
	sha256_h.Reset()
	sha256_h.Write(hash1)
	hash2 := sha256_h.Sum(nil)

	/* 在字节数据后面添加后缀：哈希的前4个字节*/
	bcpy = append(bcpy, hash2[0:4]...)

	/* 编码Base58字符串*/
	s = b58encode(bcpy)

	/* 遍历字节数组，每遇到值为0的字节，就向字符串前面添加字符1，直到遇到非0的字节*/
	for _, v := range bcpy {
		if v != 0 {
			break
		}
		s = "1" + s
	}

	return s
}
```

执行检验编码的步骤可以分解如下：

1. 在字节数组前面添加前缀：版本号
2. 使用SHA256算法对产生的十六进制进行两次哈希处理
3. 向添加了版本号的字节数据添加后缀：哈希的前4个字节
4. 将添加了版本号前缀和校验和后缀的的十六进制转换为Base58编码。
5. 如果字节数组有前导为0的字节，则向字符串前面添加字符1

因此，要将上面描述的原始私钥转换成WIF格式，我们可以使用以下这个简单的函数

```go
// ToWIF 会将NEO的私钥转换成WIF字符串
func (priv *PrivateKey) ToWIF() (wif string) {
	/* 查看 https://en.bitcoin.it/wiki/Wallet_import_format */

	/* 将私钥转换成字节数据 */
	priv_bytes := priv.ToBytes()

	/* 将字节转换成带有版本号0x80的Base58Check编码的字符串 */
	wif = b58checkencode(0x80, priv_bytes)

	return wif
}
```

我们可以看到 WIF 是私钥的一种编码算法，它可以提供基本的错误检查功能，并通过附加版本号前缀和校验和后缀，以及编码为 Base58 格式来提高私钥的可读性。


## 导出公钥
加密货币通常会使用椭圆曲线加密算法从私钥推导出公钥，而反过来操作在计算上是不可行的。

椭圆曲线方程的形式如下：  
*y^2 = x^3 + ax + b*

比特币使用称为secp256k1的椭圆曲线，而NEO使用的是secp256r1，其中k -- 表示Koblitz，r -- 表示随机。本质上来说，secp256k1的参数选择方式的计算效率更高（以非常小的安全性来换取），而secp256r1的参数则是随机选择的。

secp256k1等式是：
*y^2 = x^3 + 7*

secp256r1 等式是:  
*y^2 = x^3 - 3x + b*, 其中 *b* 为 *41058363725152142129326129780047268409114441015993725554835256314039467401291*

由于在secp256r1中*b*的值非常大，所以下面我们会对secp256k1加以解释，但二者的原理是相同的。

下面是一条secp256k1曲线：

![](https://cdn-images-1.medium.com/max/1600/1*4dcCrlQfGqZECDLy-25fnw.png)

首先，我们解释下如何在椭圆曲线上进行点的加法运算。
给定两点*P*和*Q*，我们绘制一条穿过它们的直线，并在曲线和直线的交点上找到第三个点。 然后我们作该点相对x轴的反射点*R*。 
*P + Q = R*  
![](https://cdn-images-1.medium.com/max/1600/1*dErGh_rL2ExM6AX-Rtyb7w.png)

但是在椭圆加密中，我们不是将两个任意点相加，而是将曲线上的指定基准点与该点相加。
我们在点*P*处绘制到曲线的切线，然后应用与上面相同的规则。
*P + P = 2 * P*  
![](https://cdn-images-1.medium.com/max/1600/1*ffYKgW-4_Paxve3G1HIJXw.png)

请记住，私钥是一个256位的数字？ 基本上，公钥就是*P*自加*x*次的结果，其中*x*是我们的私钥。

*X = x * P*, 其中，*X* 是公钥。

要想反过来操作（从*X*和*P*中算出*x*），我们必须不断地对*P*进行自加，直到得到*X*，这平均需要做*2 ^ 128*次点的加法直到得到*x*，这在计算上是不可行的。

## ECDSA 签名
椭圆曲线数字签名算法（ECDSA）是ECC算法对数字签名算法（DSA）的一种模拟，具有速度快，强度可靠，签名短等优点。

简要步骤如下：
假设私钥，公钥和基准点分别为*k*，*K*和*G*。根据ECC算法，我们知道*K = k * G*。

### 签名过程

1. 选择随机数*r*并计算点*r * G(x，y)*。
2. 根据随机数*r*，消息*M*的哈希*h*，私钥*k*来计算*s =(h + k * x)/ r*。
3. 向接收方发送消息*M*和签名{*r * G*，*s*}。

### 验证过程

1. 接收者接收消息*M*和签名{*r * G(x，y)*，*s*}。
2. 根据收到的消息计算哈希*h*。
3. 使用发送方的公钥*K*计算*h * G / s + x * K / s*并与*r * G*进行比较。如果两者相同，则验证成功。

推导过程如下

![](https://docs.neo.org/developerguide/en/images/blockchain_paradigm/formula_ecdsa.jpg)

## NEO地址
NEO地址由地址脚本生成，该脚本定义了谁可以花费交易输出。
通常使用的脚本形式如下：
*PUSHBYTES21*操作码（*0x21*）+压缩型公钥（33字节）+ *CHECKSIG*操作码（*0xAC*），意味着输出只能被给定公钥对应的私钥所有者花费。

要从交易脚本中计算出NEO地址：

1. 计算交易脚本的SHA-256哈希
2. 计算步骤1中结果的RIPEMD-160哈希（也就是脚本哈希）
3. 在输出的脚本哈希前添加版本号0x17，之后做Base58Check编码（意味着结果将以字符A开头）

以下是从公钥生成NEO地址的示例代码：

```go
// ToNeoAddress将NEO公钥转换为NEO地址字符串。
func (pub *PublicKey) ToNeoAddress() (address string) {
	/* 将公钥转换成字节数据 */
	pub_bytes := pub.ToBytes()

	pub_bytes = append([]byte{0x21}, pub_bytes...)
	pub_bytes = append(pub_bytes, 0xAC)

	/* SHA256哈希*/
	sha256_h := sha256.New()
	sha256_h.Reset()
	sha256_h.Write(pub_bytes)
	pub_hash_1 := sha256_h.Sum(nil)

	/* RIPEMD-160哈希*/
	ripemd160_h := ripemd160.New()
	ripemd160_h.Reset()
	ripemd160_h.Write(pub_hash_1)
	pub_hash_2 := ripemd160_h.Sum(nil)

	program_hash := pub_hash_2
	
	/* 将哈希字节转换成Base58Check编码的序列*/
	address = B58checkencodeNEO(0x17, program_hash)

	return address
}
```

智能合约中通常使用的公共标识符是脚本哈希，而不是地址。由于字节数组在计算机中是很常见的，因此更具有意义，而进行 Base58 编码则是为了具有更高的可读性。

## 阅读下节

[加密私钥与合约账户](3-Key_encryption_and_contract_accounts.md)

