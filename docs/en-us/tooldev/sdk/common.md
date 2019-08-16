# NEO SDK Common Usages

## Conversion between commonly used data types

### Conversion between hexadecimal strings and byte arrays

```c#
//Convert the hexadecimal string to the byte array
string pubkey = "03335e39ec91a16797ddc2af00feee1cb57c2e6382dc5ba59efa7d65302e4b5a33";
var bytes = pubkey.HexToBytes();
//Convert the byte array to the hexadecimal string
string pubkey2 = bytes.ToHexString();
Console.WriteLine(pubkey2);
```

### Conversion between DateTime and Unix timestamp

```c#
//Convert DateTime to the Unix timestamp
DateTime date = new DateTime(2018,1,1,0,0,0);
uint timestamp = date.ToTimestamp();
//Convert the Unix timestamp to DateTime
DateTime date2 = timestamp.ToDateTime();
Console.WriteLine(date2.ToString());
```

### Conversion between Address and Script Hash

```c#
UInt160 scriptHash = "AK4LdT5ZXR9DQZjfk5X6Xy79mE8ad8jKAW".ToScriptHash();
string address = scriptHash.ToAddress();
```

If Script Hash is a big-endian string，the following method can be used to convert it to Address:

```c#
string address = new UInt160("0x9121e89e8a0849857262d67c8408601b5e8e0524".Remove(0, 2).HexToBytes().Reverse().ToArray()).ToAddress();
```

### Conversion between big-endian and little-endian

```c#
//big-endian 2 little-endian
Console.WriteLine("0x4701ee0b674ff2d8893effc2607be85327733c1f".Remove(0, 2).HexToBytes().Reverse().ToHexString());
//little-endian 2 big-endian
Console.WriteLine("0x" + "1f3c732753e87b60c2ff3e89d8f24f670bee0147".HexToBytes().Reverse().ToHexString());
```

### Conversion between hexadecimal strings and BigInteger

```c#
BigInteter bigInt = new BigInteger("00e1f505".HexToBytes());
string hexStr = new BigInteger(100000000).ToByteArray().ToHexString();
```

## More is on the way
This document is in editing for adding more common usages of NEO SDK.
