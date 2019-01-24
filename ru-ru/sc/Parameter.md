# Параметры и возвращаемые значения смарт-контракта 

При развертывании или вызове смарт-контракта необходимо указать параметры смарт-контракта, то есть типы байтов, определяемые следующим образом.

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
         InteropInterface = 0xf0,   
         Void = 0xff
     }
```
Например, для смарт-контракта, представленного ниже:

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```
При использовании enum, int представлен как 2, bool - как 1, открытый ключ - как 6 и подпись - как 0.

При вводе параметров через ПК-клиент используйте 2 шестнадцатеричных символа для каждого параметра. Таким образом, аргументы для данной функции записываются как 02010600, а возвращаемое значение: 01.

