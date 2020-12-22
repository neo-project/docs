# Smart Contract Parameters and Return Values

In the smart contract deployment or invocation, you need to specify the parameters of the smart contract. Smart contract parameters are byte types, defined as follows.

```c#
/// <summary>
/// Indicates the parameter type of the smart contract
/// </summary>
public enum ContractParameterType : byte
{
    Any = 0x00,

    Boolean = 0x10,
    /// <summary>
    /// Integer
    /// </summary>
    Integer = 0x11,
    /// <summary>
    /// byte array
    /// </summary>
    ByteArray = 0x12,
    String = 0x13,
    /// <summary>
    /// 160-bit hash value
    /// </summary>
    Hash160 = 0x14,
    /// <summary>
    /// 256-bit hash value
    /// </summary>
    Hash256 = 0x15,
    PublicKey = 0x16,
    /// <summary>
    /// Signature
    /// </summary>
    Signature = 0x17,

    /// <summary>
    /// object array
    /// </summary> 
    Array = 0x20,
    Map = 0x22,

    InteropInterface = 0x30,

    Void = 0xff

}
```

For example, for the smart contract below:

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        // more...
    }
}
```

Using the enum above, int is represented as 0x11, bool as 0x10，public key as 0x16 and signature as 0x17.

When filling in parameters through the Neo-GUI client, use 2 hexadecimal characters for each parameter. Thus, the arguments for the above function is written as : 11101617, return: 10.