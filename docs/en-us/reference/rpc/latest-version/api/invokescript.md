# invokescript Method

Returns the result after passing a script through the VM.

> [!Note]
>
> - This method is to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

### Parameter Description

- script: A script runnable in the VM. This is the same script that is returned in invokefunction
- signers: list of contract signature accounts
  * account: signature account
  * scopes: signature's valid scopes, allowed values: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokescript",
  "params": [    
    "DAlqdXN0IHRlc3QRDBRWyI0UCtLMDykDfdEKfwBgorUoXAwU19eXMOJ4xtkG5uj2lb+th34/+pAUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
    [
         {
          "account": "NfbEjVjhhpDsni716KVbuQWqSjVNHAUdTh",
          "scopes": "CustomContracts",
          "allowedcontracts":["0xd2a4cff31913016155e38e474a2c06d08be276cf","0xd2a4cff31913016155e38e474a2c06d08be276cf"],
          "allowedgroups":[]
        }
    ]
  ]
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "script": "DAlqdXN0IHRlc3QRDBRWyI0UCtLMDykDfdEKfwBgorUoXAwU19eXMOJ4xtkG5uj2lb+th34/+pAUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
    "state": "HALT",
    "gasconsumed": "9931880",
    "exception": null,
    "stack": [
      {
        "type": "Boolean",
        "value": true
      }
    ],
    "tx": "AOAp8X1ojJcAAAAAADiCEwAAAAAAwhgAAAHX15cw4njG2Qbm6PaVv62Hfj/6kBACz3bii9AGLEpHjuNVYQETGfPPpNLPduKL0AYsSkeO41VhARMZ88+k0gBgDAlqdXN0IHRlc3QRDBRWyI0UCtLMDykDfdEKfwBgorUoXAwU19eXMOJ4xtkG5uj2lb+th34/+pAUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtSAUIMQND33YydF1nRttTQHmrzusLTAS3JY+Wmwdpbsh1T0p7uzOomsJca6GqH9KeDavvQ6MdnZsOD4/1zUQu/OlfId20oDCED4IgjtEOZ9qKqIkiDTZIKFas66S3HVjz35D/d1bHAGC9BdHR2qg=="
  }
}
```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 

- gasconsumed: the system fee consumed for invocation.

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly.
