# Contract.Migrate Methode (byte[], byte[], byte, bool, string, string, string, string, string)

Migrieren/Erneuern von Smart Contracts. Diese Methode ähnelt der `Contract.Create`, der einzige Unterschied ist das diese Methode Logik für die Migration des Private Persistent Storage beinhaltet. Wenn Sie diese Methode ausführen, werden alle **existierenden Daten** in den Persisten Sore des neuen Contracts migriert.
Wenn der Contract keinen Persistent Store benutzt ist die Methode `Contract.Migrate` funktionell dieselbe wie `Contract.Create`.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract Migrate(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Parameter: 

script: Der Contract Bytecode als ein Byte Array.

parameter_list: Parameter List als ein Byte Array. [Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md).

return_type: Return Type als ein Byte. [Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md).

need_storage: Wenn der Contract einen Persistent Store benötigt, boolean

name: Der Name des Contract als ein String.

version: Die Version als ein String.

author: Der Autor Name als ein String.

email: Die Autor Email als ein String.

description: Die Description des Contract als ein String.

Rückgabewert: [Contract](../Contract.md).

## Beispiel

```c#
public class Contract1 : FunctionCode
{
    public static void Main(byte[] signature)
    {
        if(VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature))
          {
                    //This is the scripthash of the new contract
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = true;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@neo.org";
        string description = "DescriptionHere";
      
        Contract.Migrate(script, parameter_list, return_type, need_storage, name, version, author, email, description);
          }

    }
}
```



[Back](../Contract.md)
