# Smart Contract Parameters and Return Values

In the smart contract deployment or invocation, you need to specify the parameters of the smart contract. Smart contract parameters are byte types, defined as follows.

```c#
     /// <summary>
     /// Indicates the parameter type of the smart contract
     /// </summary>
     public enum ContractParameterType: byte
     {
         /// <summary>
         /// Signature
         /// </summary>
         Signature = 0x00,
         Boolean = 0x01,
         /// <summary>
         /// Integer
         /// </summary>
         Integer = 0x02,
         /// <summary>
         /// 160-bit hash value
         /// </summary>
         Hash160 = 0x03,
         /// <summary>
         /// 256-bit hash value
         /// </summary>
         Hash256 = 0x04,
         /// <summary>
         /// byte array
         /// </summary>
         ByteArray = 0x05,
         PublicKey = 0x06,
         String = 0x07,
         
         /// <summary>
         /// object array
         /// </summary>
         Array = 0x10,
         
         Void = 0xff
     }
```
For example, for the smart contract below:

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```
Using the enum above, int is represented as 2, bool as 1, public key as 6 and signature as 0.

When filling in parameters through the PC client, use 2 hexadecimal characters for each parameter. Thus, the arguments for the above function is written as : 02010600, return: 01.
