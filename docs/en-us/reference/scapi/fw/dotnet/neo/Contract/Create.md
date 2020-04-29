# Contract.Create Method (byte[], string)

Calling this method in a smart contract will publish a new contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Contract Create(byte[] script, string manifest)
```

Parameters:

- script: The contract bytecode as a byte array.

- manifest: Defines the contract features and permissions with Json strings


Return value: [Contract](../Contract.md).

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        //这里填写合约脚本
        byte[] script = new byte[] {0x41, 0xeb, 0x43, 0xf4, 0xf4};
        string manifest = "{\"groups\":[],\"features\":{\"storage\":true,\"payable\":false},\"abi\":{\"hash\":\"0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b\",\"entryPoint\":{\"name\":\"Main\",\"parameters\":[{\"name\":\"operation\",\"type\":\"String\"},{\"name\":\"args\",\"type\":\"Array\"}],\"returnType\":\"Any\"},\"methods\":[{\"name\":\"getSysFeeAmount\",\"parameters\":[{\"name\":\"index\",\"type\":\"Integer\"}],\"returnType\":\"Integer\"},{\"name\":\"name\",\"parameters\":[],\"returnType\":\"String\"},{\"name\":\"symbol\",\"parameters\":[],\"returnType\":\"String\"},{\"name\":\"decimals\",\"parameters\":[],\"returnType\":\"Integer\"},{\"name\":\"totalSupply\",\"parameters\":[],\"returnType\":\"Integer\"},{\"name\":\"balanceOf\",\"parameters\":[{\"name\":\"account\",\"type\":\"Hash160\"}],\"returnType\":\"Integer\"},{\"name\":\"transfer\",\"parameters\":[{\"name\":\"from\",\"type\":\"Hash160\"},{\"name\":\"to\",\"type\":\"Hash160\"},{\"name\":\"amount\",\"type\":\"Integer\"}],\"returnType\":\"Boolean\"},{\"name\":\"onPersist\",\"parameters\":[],\"returnType\":\"Boolean\"},{\"name\":\"supportedStandards\",\"parameters\":[],\"returnType\":\"Array\"}],\"events\":[{\"name\":\"Transfer\",\"parameters\":[{\"name\":\"from\",\"type\":\"Hash160\"},{\"name\":\"to\",\"type\":\"Hash160\"},{\"name\":\"amount\",\"type\":\"Integer\"}],\"returnType\":\"Signature\"}]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"safeMethods\":[\"getSysFeeAmount\",\"name\",\"symbol\",\"decimals\",\"totalSupply\",\"balanceOf\",\"supportedStandards\"],\"extra\":null}";
      
        Contract contract = Blockchain.Create(script, manifest);
    }
}
```



[Back](../Contract.md)