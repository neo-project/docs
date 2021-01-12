# Binary Class

Encodes or converts numerical values.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Binary
```

## Methods

| Name                                           | Description                                    |
| ---------------------------------------------- | ---------------------------------------------- |
| [Base64Decode(string)](Binary/Base64Decode.md) | Decodes Base64-encoded string into  byte array |
| [Base64Encode(byte[])](Binary/Base64Encode.md) | Encodes byte array to Base64-encoded string    |
| [Base58Decode(string)](Binary/Base58Decode.md) | Decodes Base58-encoded string into  byte array |
| [Base58Encode(byte[])](Binary/Base58Encode.md) | Encodes byte array to Base58-encoded string    |
| [Itoa(BigInteger, int )](Binary/Itoa.md)       | Converts BigInteger value to string            |
| [Itoa(int, int @base = 10)](Binary/Itoa.md)    | Converts signed 32-bit integer to string       |
| [Itoa(uint, int @base = 10)](Binary/Itoa.md)   | Converts unsigned 32-bit integer to string     |
| [Itoa(long, int @base = 10)](Binary/Itoa.md)   | Converts signed 64-bit integer to string       |
| [Itoa(ulong, int @base = 10)](Binary/Itoa.md)  | Converts unsigned 64-bit integer to string     |
| [Itoa(short, int @base = 10)](Binary/Itoa.md)  | Converts signed 16-bit integer to string       |
| [Itoa(ushort, int @base = 10)](Binary/Itoa.md) | Converts unsigned 16-bit integer to string     |
| [Itoa(byte, int @base = 10)](Binary/Itoa.md)   | Converts unsigned 8-bit integer to string      |
| [Itoa(sbyte, int @base = 10)](Binary/Itoa.md)  | Converts signed 8-bit integer to string        |
| [Atoi(string, int @base = 10)](Binary/Atoi.md) | Converts string to BigInteger type             |
