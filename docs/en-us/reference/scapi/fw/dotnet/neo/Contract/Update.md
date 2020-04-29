# Update method (byte[], string)

Migrates or updates the smart contract. On the basis of Contract.Create this method adds a migration operation to the private storage of the contract, which migrates everything in the persistent storage of the current contract to the new contract when executed.

Actually, Contract.Update and Contract.create functions the same if no operation of the persistent storage is required in the smart Contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Update(byte[] script, string manifest)
```

Parameters:

- script: The contract bytecode as a byte array.
- manifest: Defines the contract features and permissions with Json strings

Return value: [Contract](../Contract.md).

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main(byte[] signature)
    {
        //Type the contract script here
        byte[] script = new byte[] {87, 0, 2, 12, 1, 26, 64};
        string manifest = "{\"groups\":[],\"features\":{\"storage\":false,\"payable\":false},\"abi\":{\"hash\":\"0x51d24ad1f61af44c019cffb41534821b644b602d\",\"entryPoint\":{\"name\":\"main\",\"parameters\":[{\"name\":\"method\",\"type\":\"String\"},{\"name\":\"args\",\"type\":\"Array\"}],\"returnType\":\"ByteArray\"},\"methods\":[],\"events\":[]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"safeMethods\":[],\"extra\":null}";
      
        Blockchain.Update(script, manifest);
    }
}
```



[back](../Contract.md)