# Smart Contract Parameters en Return Values

Bij het deployen of oproepen van een smart contract moet je de parameters van het smart contract aangeven. Smart contract-parameters zijn byte types, welke als volgt zijn gedefiniëerd:

```c#
     /// <samenvatting>
     /// Indicates the parameter type of the smart contract
     /// </samenvatting>
     public enum ContractParameterType: byte
     {
         /// <samenvatting>
         /// Signature (ondertekening)
         /// </samenvatting>
         Signature = 0x00,
         Boolean = 0x01,
         /// <samenvatting>
         /// Integer
         /// </samenvatting>
         Integer = 0x02,
         /// <samenvatting>
         /// 160-bit hashwaarde
         /// </samenvatting>
         Hash160 = 0x03,
         /// <samenvatting>
         /// 256-bit hashwaarde
         /// </samenvatting>
         Hash256 = 0x04,
         /// <samenvatting>
         /// byte-array
         /// </samenvatting>
         ByteArray = 0x05,
         PublicKey = 0x06,
         String = 0x07,
         
         /// <samenvatting>
         /// object-array
         /// </samenvatting>
         Array = 0x10,
         
         Void = 0xff
     }
```
Een voorbeeld is het smart contract hieronder:

```c#
public class Lock : FunctionCode
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //meer code...
    }
}
```
Bij het invullen van de data uit het blok code bovenaan deze pagina, zou gelden `int` = 2, `bool` = 1, `pubkey` = 6 en `signature` = 0.

Bij het invullen van de parameters d.m.v. de PC-client is het van belang 2 hexadecimale karakters te gebruiken voor elke parameter. Op deze wijze zouden de inputs voor bovenstaande functie als volgt geschreven zijn: `02010600` met als `return` = `01`.
