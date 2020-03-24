# 常用数据类型转换

### 16 进制字符串与 byte 数组互转

```c#
//16进制字符串转Byte数组
string pubkey = "03335e39ec91a16797ddc2af00feee1cb57c2e6382dc5ba59efa7d65302e4b5a33";
var bytes = pubkey.HexToBytes();
//Byte数组转16进制字符串
string pubkey2 = bytes.ToHexString();
Console.WriteLine(pubkey2);
```

### DateTime 与 Unix 时间戳互转

```c#
//DateTime转Unix时间戳
DateTime date = new DateTime(2018,1,1,0,0,0);
uint timestamp = date.ToTimestamp();
//Unix时间戳转DateTime
DateTime date2 = timestamp.ToDateTime();
Console.WriteLine(date2.ToString());
```

### Address 与 Script Hash 互转

```c#
UInt160 scriptHash = "AK4LdT5ZXR9DQZjfk5X6Xy79mE8ad8jKAW".ToScriptHash();
string address = scriptHash.ToAddress();
```

如果 Script Hash 是大端序的字符串格式，可以用下面的方法转成 Address：

```c#
string address = new UInt160("0x9121e89e8a0849857262d67c8408601b5e8e0524".Remove(0, 2).HexToBytes().Reverse().ToArray()).ToAddress();
```

### 大端序与小端序互转

```c#
//big-endian 2 little-endian
Console.WriteLine("0x4701ee0b674ff2d8893effc2607be85327733c1f".Remove(0, 2).HexToBytes().Reverse().ToHexString());
//little-endian 2 big-endian
Console.WriteLine("0x" + "1f3c732753e87b60c2ff3e89d8f24f670bee0147".HexToBytes().Reverse().ToHexString());
```

### 16 进制字符与 BigInteger 互转

```c#
BigInteter bigInt = new BigInteger("00e1f505".HexToBytes());
string hexStr = new BigInteger(100000000).ToByteArray().ToHexString();
```

## 期待更多
更多 NEO SDK 用法正在补充中。
