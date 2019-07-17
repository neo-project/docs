# Smart Contract Parameter und Return Values

Wenn Sie einen Smart Contract bereitstellen oder abrufen, müssen Sie die Parameter des Smart Contract spezifizieren. Smart Contract Parameter sind byte types, welche wie folgend beschrieben definiert sind.

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

Zum Beispiel für den folgenden Smart Contract:

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```

Mit der 'enum' von oben wird int als 2, bool als 1 public key als 6 und signature als 0 dargestellt.

Wenn sie Parameter mittels dem PC Client einfügen, benutzen Sie 2 Hexadezimalzeichen für jeden Parameter. Daher werden die Argumente der obigen Funktion wie folgt geschrieben: 02010600, return: 01.

