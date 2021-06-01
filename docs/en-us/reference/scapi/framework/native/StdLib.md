# StdLib Class

Provides a series methods of the native contract `StdLib`, which contract hash is `0xacce6fd80d44e1796aa0c2c625e9e4e0ce39efc0`.

Namespace: [Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class StdLib
```

## Attributes

| Name | Description            |
| ---- | ---------------------- |
| Hash | Gets the contract hash |

## Methods

| Name                                   | Description   |
| ---------------------------------------- | --------------- |
| Serialize(object source) | Serializes the object to byte array |
| Deserialize(ByteString source) | Deserializes the byte array to object |
| JsonSerialize(object obj) | Serializes the object to Json |
| JsonDeserialize(string json) | Deserializes the Json to object |
| Base64Decode(string input) | Decodes the Base64-encoded string into byte array |
| Base64Encode(ByteString input) | Encodes the byte array into Base64 string |
| Base58Decode(string input) | Decodes the Base58 encoded string into byte array |
| Base58Encode(ByteString input) | Encodes the byte array into Base58 string |
| Base58CheckDecode(string input) | Decodes the Base58Check encoded string into byte array |
| Base58CheckEncode(ByteString input) | Encodes the byte array into Base58Check string |
| Itoa | Converts the integer to string |
| Atoi(string value, int @base = 10) | Converts the string to integer |
| MemoryCompare(ByteString, ByteString) | If two arrays are the same, return 0; if array 1 is less than array 2, return a value less than 0; if array 1 is greater than array 2, return a value greater than 0 |
| MemorySearch | Returns the index of the first match of array 2 in array 1, or -1 if no match |
| StringSplit | Creates an array of substrings by splitting the input string based on one or more delimiters |