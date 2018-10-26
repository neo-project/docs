# NEO-Python 数据类型

在使用 NEO-python 或 NEO 区块链时，你需要熟悉一些数据类型，这可以帮助你识别在系统的各部分以不同格式出现的这些数据类型，以及正确使用它们。本章将简要描述每种数据类型及其一般用法。

请注意，这些数据类型是在 `neocore` 项目中实现的，但在 neo-python 中用的很多。

## KeyPair / 地址

NEO 中的地址实际上是一对公钥/私钥。当创建一个钱包时，会根据钱包密码创建一个32位的私钥，这个私钥只能你自己知道和保存。此私钥与公钥配对，用于标识网络上的地址。只有签名交易时才需要用到私钥。

如果在 `prompt` 中打开一个钱包，运行 `wallet` 命令，在输出的信息中可以查看到钱包的公钥，例如：

```python
"public_keys": [
  {
      "Address": "AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy",
      "Public Key": "036d4de3e05057df18b82718d635795cb67d9c19001e998d76c77b86081be5f160"
  }
],
```

上例中 `Public Key` 以压缩格式表示 [ECDSA](https://en.wikipedia.org/wiki/Elliptic_Curve_Digital_Signature_Algorithm) 曲线上的 x 和 y 坐标，特别是 *SECP256R1 曲线。我们通过一系列步骤推导出 `Address` ：

- 创建一个以 `21` 开头 `ac` 结尾的公钥 `UInt160` 或 `ScriptHash`：

  ```python
  >>> from neocore.Cryptography.Crypto import Crypto
  >>> pubkey_hex = '036d4de3e05057df18b82718d635795cb67d9c19001e998d76c77b86081be5f160'
  >>> pubkey_hex_for_addr = '21' + pubkey_hex + 'ac'
  >>> pubkey_hex_for_addr
  '21036d4de3e05057df18b82718d635795cb67d9c19001e998d76c77b86081be5f160ac'
  >>> script_hash = Crypto.ToScriptHash(pubkey_hex_for_addr, unhex=True)
  >>> script_hash
  <neocore.UInt160.UInt160 object at 0x10d33e908>
  >>> script_hash.Data
  bytearray(b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96')
  ```

- 接着，从以下脚本散列创建一个地址：

  ```
  >>> addr = Crypto.ToAddress(script_hash)
  >>> addr
  'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy'
  >>>
  ```

如果对 `KeyPair`、 `UInt160`、或 `Crypto` 包的实现细节感兴趣，可以查看 [neocore repository](https://github.com/CityOfZion/neo-python-core)。

## UInt256

`UInt256` 表示 32位 的散列。它通常是一个 `Transaction` 对象或 `Block`的散列。 它一般显示为 64 字符的字符串或带有 0x 十六进制说明符的 66 个字符的字符串。以下是一个与 `UInt256` 交互的例子。

```python
>>>
>>> from neocore.UInt256 import UInt256
>>>
>>> hash = "0x99e2be05956027b884cbf11cddbf9d2e5a8fb97ab18d5cde44d5ae2d4c980d18"
>>>
>>> uint = UInt256.ParseString(hash)
>>> uint
<neocore.UInt256.UInt256 object at 0x10cb9b240>
>>> uint.ToString()
'99e2be05956027b884cbf11cddbf9d2e5a8fb97ab18d5cde44d5ae2d4c980d18'
>>> uint.To0xString()
'0x99e2be05956027b884cbf11cddbf9d2e5a8fb97ab18d5cde44d5ae2d4c980d18'
>>> uint.Data
bytearray(b"\x18\r\x98L-\xae\xd5D\xde\\\x8d\xb1z\xb9\x8fZ.\x9d\xbf\xdd\x1c\xf1\xcb\x84\xb8\'`\x95\x05\xbe\xe2\x99")
>>>
>>> uint.ToBytes()
b'99e2be05956027b884cbf11cddbf9d2e5a8fb97ab18d5cde44d5ae2d4c980d18'
>>>
>>> data = uint.Data
>>> data
bytearray(b"\x18\r\x98L-\xae\xd5D\xde\\\x8d\xb1z\xb9\x8fZ.\x9d\xbf\xdd\x1c\xf1\xcb\x84\xb8\'`\x95\x05\xbe\xe2\x99")
>>>
>>> copy = UInt256(data=data)
>>>
>>> copy.To0xString()
'0x99e2be05956027b884cbf11cddbf9d2e5a8fb97ab18d5cde44d5ae2d4c980d18'
>>>
```

需要注意的是，我们通常看到的是字符串，或者 UInt256 的 0x 字符串版本。

## UInt160

`UInt160` 表示 20 位的散列，也可称为一个 `ScriptHash`。它用于显示 NEO 中的 `Address` 对象是普通地址还是合约地址。以下是一个与 `UInt160`交互的例子。

```python
>>>
>>> data = bytearray(b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96')
>>>
>>> from neocore.UInt160 import UInt160
>>>
>>> new_sh = UInt160(data=data)
>>> new_sh
<neocore.UInt160.UInt160 object at 0x10d3460b8>
>>> new_sh.Data
bytearray(b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96')
>>>
>>> new_sh.To0xString()
'0x9698b1cac6ce9cbe8517e490778525b929e01903'
>>>
>>> sh_again = UInt160.ParseString( new_sh.To0xString() )
>>> sh_again.Data
bytearray(b'\x03\x19\xe0)\xb9%\x85w\x90\xe4\x17\x85\xbe\x9c\xce\xc6\xca\xb1\x98\x96')
>>>
>>> Crypto.ToAddress( sh_again)
'AG4GfwjnvydAZodm4xEDivguCtjCFzLcJy'
>>>
```

## Fixed8

 `Fixed8` 用于表示整数格式的 8 位小数。以下是一个使用 `Fixed8`的基本示例。

```python
>>> from neocore.Fixed8 import Fixed8
>>>
>>> three = Fixed8.FromDecimal(3)
>>> three.value
300000000
>>> three.ToInt()
3
>>> three.ToString()
'3.0'
>>>
>>>
>>> point5 = Fixed8(50000000)
>>> point5.ToString()
'0.5'
>>>
>>> point5 + three
<neocore.Fixed8.Fixed8 object at 0x10cd48ba8>
>>> threepoint5 = point5 + three
>>> threepoint5.value
350000000
>>>
>>> threepoint5.ToString()
'3.5'
>>>
>>>
>>> threepoint5 * 2
Traceback (most recent call last):
File "<input>", line 1, in <module>
  threepoint5 * 2
File "/Users/thomassaunders/Workshop/neo-python/venv/lib/python3.6/site-packages/neocore/Fixed8.py", line 85, in __mul__
  return Fixed8(self.value * other.value)
AttributeError: 'int' object has no attribute 'value'
>>>
>>>
```

以下是一些总结：

- 如果你想创建一个 Fixed8 并且你有一个小数，最简单的做法是使用 `Fixed8.FromDecimal` 方法。
- 假设每个操作数是一个 `Fixed8`，你可以对 Fixed8 对象进行数学运算。
- 在一个 `Fixed8` 和另一种类型的数字之间进行数学运算会引发错误。
- 你可以通过访问  `value`  属性来访问 `Fixed8` 对象的完整值。

## BigInteger

`BigInteger` 用于存储和对任意大小的整数进行运算，包括负数和正数。这对将数字序列化为字节和返回非常有用。以下是 `BigInteger` 的一些示例用法。

```python
>>> from neocore.BigInteger import BigInteger
>>>
>>> bi = BigInteger(10000)
>>>
>>> bi.ToByteArray()
b"\x10'"
>>>
>>> bi2 = BigInteger.FromBytes( bi.ToByteArray() )
>>> bi2
10000
>>>
>>> bi3 = BigInteger(-3)
>>>
>>> bi4 = bi2 * bi3
>>> bi4
-30000
>>>
>>> bi4 += 100000
>>> bi4
70000
>>> bi4.ToByteArray()
b'p\x11\x01'
>>>
```

`BigInteger` 实现中需要注意的一点是它与 `Fixed8` 不同，因此你可以在 `BigInteger` 和普通整数之间进行数学运算。

## ContractParameterTypes

以下是创建和调用智能合约中用到的 ContractParameterTypes。

**描述**：

neo.Wallets 中的合约参数

**用法：**

从 neo.SmartContract.ContractParameterType 导入 ContractParameterType

`class neo.SmartContract.ContractParameterType.ContractParameterType`

Contract Parameter Types are used to denote different types of objects used in the VM

`Signature`

00

`Boolean`

01

`Integer`

02

`Hash160`

03

`Hash256`

04

`ByteArray`

05

`PublicKey`

06

`String`

07

`Array`

10

`InteropInterface`

F0

`Void`

FF

`neo.SmartContract.ContractParameterType.``ToName (param_type)`

根据其值 param_type 获取 ContractParameterType 的名称。