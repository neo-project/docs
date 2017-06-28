# CreateContract method (byte[], byte[], byte, bool, string, string, string, string, string)

Calling this method in a smart contract can issue a new smart contract.

The method is a proxy for PublishTransaction in version 2.0.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Contract CreateContract (byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string author, string email, string description)
```

parameter:

Script: contract code, byte array.

Parameter_list: Parameter list, byte array, refer to [Smart contract parameters and return value](../../../../tutorial/Parameter.md).

Return_type: return value, byte, refer to [Smart contract parameters and return value](../../../../tutorial/Parameter.md).

Need_storage: whether the need for persistent storage, Boolean value.

Name: the name of the smart contract, the string type.

Version: version number, string type.

Author: author name, string type.

Email: author mailbox, string type. The

Description: description of smart contract, string type.

Return Value: The published Smart Contract, [Contract](../Contract.md) type.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // fill in the contract script here
        byte[] script = new byte[] {116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 98, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 118, 108, 118, 108, 117, 108, 118, 140, 107, 148, 108, 117, 108, 118, 140, 107, 148, 109, 108, 117, 102}
      
        byte[] parameter_list = {2, 2};
        Byte return_type = 2;
        Bool need_storage = false;
        String name = "Addition contract example";
        String version = "1";
        String author = "chris";
        String email = "chris@abc.com";
        String description = "This is an addition contract, the incoming two integers, the contract adds to the two integers, returns an integer";
      
        Blockchain.CreateContract (script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[Return to superior](../Blockchain.md)
