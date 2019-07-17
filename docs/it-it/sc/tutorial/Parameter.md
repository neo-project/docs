# Parametri dello Smart Contract e Valori Restituiti

Nell'implementazione o invocazione di uno smart contract, occorre specificare i parametri dello smart contract. I parametri dello smart contract sono tipi di byte definiti come segue.

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
Per esempio, per lo smart contract seguente:

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```
Usando l'enum sopra, int é rappresentato come 2, bool come 1, la chiave pubblica come 6 e la firma come 0.

Quando si compilano i parametri tramite il client del PC, usare due caratteri esadecimali per la compilazione di ogni parametro. Pertanto gli argomenti per la funzione precedente sono scritti come : 02010600, restituiscono: 01.

