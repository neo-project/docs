# Contract.Call Method

Invokes the contract.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern object Call(UInt160 scriptHash, string method, object[] arguments)
```

Parameters:

- scriptHash: The contract script hash
- method: The contract method
- arguments: The contract method arguments

## Example

```c#
public class Contract1 : SmartContract
 {
     delegate object Dyncall(string method, object[] args);

     //0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 in little endian order
     //HexToBytes()、ToScriptHash() can only operate on constants and cannot be written in the Main method
     //scriptHash can be modified to be passed in from the parameter or read from storage
     static UInt160 ScriptHash = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();

     public static object Test(string operation, object[] args)
     {
         if (operation == "name")
         {
             return Contract.Call((UInt160)ScriptHash, "name", new object[0]);
         }
         if (operation == "totalSupply")
         {
             return Contract.Call(ScriptHash, "totalSupply", new object[0]);
         }
         return true;
     }
 }
```



[Back](../Contract.md)