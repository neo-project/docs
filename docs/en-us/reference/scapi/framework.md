# Neo.SmartContract.Framework

## Class

| Name            | Description                                                  |
| --------------- | ------------------------------------------------------------ |
| ByteString      | Encapsulation for Byte Array                                 |
| ECPoint         | Represents a (X,Y) coordinate pair for elliptic curve cryptography (ECC) structures |
| ExecutionEngine | Represents the VM used to execute the script                 |
| List            | Similar to List in .net                                      |
| Map             | Similar to Dictionary in .net                                |
| Nep11Token      | Abstraction class for digital asset                          |
| Nep17Token      | Abstraction class for NFT asset                              |
| UInt160         | UInt160                                                      |
| UInt256         | UInt256                                                      |


## Extension method

| Name         | Description                                                  |
| ------------ | ------------------------------------------------------------ |
| ToByteString | 1. Converts byte to byte[] considering the byte as a BigInteger (0x00 at the end).<br/>2. Converts sbyte to byte[].<br/>3. Converts string to byte[]. Examples: "hello" -> [0x68656c6c6f]; "" -> []; "Neo" -> [0x4e656f]<br/>4. Converts byte[] to string. Examples: [0x68656c6c6f] -> "hello"; [] -> ""; [0x4e656f] -> "Neo"<br/> |
| Within       | Returns true iff a <= x && x < b. Examples: x=5 a=5 b=15 is true; x=15 a=5 b=15 is false |
| Concat       | Concatenating two byte arrays                                |
| Range        | Copy the subarray, starting from the specified position and having the specified length |
| Take         | Returns a specified number of contiguous elements from the start of a sequence |
| Last         | Returns a specified number of contiguous elements from the last of a sequence |
| Reverse      | Reverses the order of the elements                           |
| Sqrt         | Calculating the square root                                  |

## Enum

| Name                  | Description                                   |
| --------------------- | --------------------------------------------- |
| ContractParameterType | Underlying types, which developers can ignore |
| OpCode                | Underlying types, which developers can ignore |
| StackItemType         | Underlying types, which developers can ignore |