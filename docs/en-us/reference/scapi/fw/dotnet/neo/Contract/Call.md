# Contract.Call Method (byte[], string, object[])

Invokes the contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern object Call(byte[] scriptHash, string method, object[] arguments)
```

Parameters:

- scriptHash: The contract script hash
- method: The contract method
- arguments: The contract method arguments

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object Main(string method, object[] args)
    {
        string scriptHash = "0x43cf98eddbe047e198a3e5d57006311442a0ca15";
        if (Runtime.Trigger == TriggerType.Application)
        {
            if (method == "name") {
            string name = Contract.Call(scriptHash.HexToBytes(), "name", new object[]{});
            return name;
            }
        }  
    }
}
```



[Back](../Contract.md)