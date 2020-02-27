# Contract.CallEx Method (byte[], string, object[], CallFlags)

Invokes the contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly:  Neo.SmartContract.Framework

## Syntax

```c#
public static extern object CallEx(byte[] scriptHash, string method, object[] arguments, CallFlags flag)
```

Parameters:

- scriptHash: The contract script hash
- method: The contract method
- arguments: The contract method arguments
- flag: The contract call flag

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main(string method, object[] args)
    {
        string scriptHash = "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789";
        if (Runtime.Trigger == TriggerType.Application)
        {
            if (method == "name") {
            string name = Contract.CallEx(scriptHash.HexToBytes(), "name", new object[]{}, CallFlags.ReadOnly);
            return name;
            }
        }  
    }
}
```



[Back](../Contract.md)