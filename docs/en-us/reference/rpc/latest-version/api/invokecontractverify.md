# invokecontractverify Method

Invokes the contract method `Verify`. Unlike the method `invokefunction` which executes the contract by the Application trigger, `invokecontractverify` executes the contract by the Verification trigger and can pass parameters as `params` and `signers`. Specific parameter type and number depend on the smart contract to invoke.

> [!Note]
>
> - This method is used to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- scripthash: Smart contract scripthash.

- params：Optional. The parameters to be passed into the smart contract operation.

- signers:  Optional. List of contract signature accounts.
  * account: signature account
  * scopes: signature's valid scopes, allowed values: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups
  
  > [!Note]
  >
  > You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian script hash; if the data type is ByteArray, use the little endian scripthash.
  
  For example:
  
    ```json
    {
      "type": "String",
      "value": "Hello"
    }
  
    {
      "type": "Hash160",
      "value": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
    }
  
    {
      "type": "ByteArray",
      "value": "7472616e73666572"
    }
    ```

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "invokecontractverify",
    "params": [
        "0x63c7e30a5eee6c8208f9ba073b3424e8b592c26c"
    ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "IQwU9mRDSY04eNMrmU5OEoPGk0Qh2v4hQfgn7IxAEUBXAQAhDAVIZWxsbyFBm/ZnzkGSXegxcCMFAAAAaEBXAQEheHBoJwoAAAAjIAAAAAwFSGVsbG8MBVdvcmxkIVBBm/ZnzkHmPxiEIUBXAQIhITWQ////ELNwaCcaAAAADBFObyBhdXRob3JpemF0aW9uLiE6eHkhUEExxjMdIUBXAQAhITVd////ELNwaCcaAAAADBFObyBhdXRob3JpemF0aW9uLiE6IUHGnx3wIUAhVgEMFPZkQ0mNOHjTK5lOThKDxpNEIdr+YCFA",
        "state": "HALT",
        "gasconsumed": "0.0101685",
        "exception": null,
        "stack": [
            {
                "type": "Integer",
                "value": "1"
            },
            {
                "type": "Integer",
                "value": "1"
            }
        ]
    }
}
```

Response description:

- script：the invocation script of the contract. You can convert it to OpCode at [Neo 3.0 data converter](https://neo.org/converter).
- state：`HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 
- gasconsumed：the system fee consumed for invocation.
- stack：the contract execution result. If the value is String or ByteArray, it is encoded by Base64.