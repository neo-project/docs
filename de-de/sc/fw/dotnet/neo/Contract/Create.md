# Contract.Create Methode (byte[], byte[], byte, bool, string, string, string, string, string)

Das Ausführen dieser Methode in einem Smart Contract veröffentlicht einen neuen Contract.

Diese Methode ersetzt die PublicTransaction in Version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

Parameter:

script: Der Contract Bytecode als ein Byte Array.

parameter_list: Parameter List als ein Byte Array. [Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md).

return_type: Return Type als ein Byte. [Smart Contract Parameters and Return Values](../../../../tutorial/Parameter.md).

need_storage: Wenn der Contract einen Persistent Store benötigt, boolean.

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
    public static void Main()
    {
        //This is the new contract as bytecode
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = false;
        string name = "AdditionContractExample";
        string version = "1";
        string author = "chris";
        string email = "chris@abc.com";
        string description = "This is an Addition Contract. It takes in 2 inputs, adds them and returns the result.";
      
        Blockchain.CreateContract(script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[Back](../Contract.md)
