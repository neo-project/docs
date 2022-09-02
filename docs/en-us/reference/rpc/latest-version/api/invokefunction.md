﻿﻿# invokefunction Method

Invokes a smart contract with its scripthash based on the specified operation and parameters and returns the result.

> [!Note]
>
> - This method is used to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* scripthash: Smart contract scripthash. You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian scripthash; if the data type is ByteArray, use the little endian scripthash.

* operation: The operation name (string)

* params: Optional. The parameters to be passed into the smart contract operation

* signers: Optional. List of contract signature accounts.

  * account: signature account
  * scopes: signature's valid scopes, allowed values are:
    * None: Only transactions are signed and no contracts are allowed to use this signature.
    * CalledByEntry: It only applies to the chain call entry. That is,  if the user invokes contract A, and then contract A calls contract B, only contract A can use the signature. It is recommended as the default value for the wallet.
    * CustomContracts: Custom contract. The signature can be used in the specified contract.
      It can be used in conjunction with CalledByEntry.
    * CustomGroups: Custom contract groups that can be used in a specified contract group.
      It can be used in conjunction with CalledByEntry.
    * Global: Global. Global. The risk is extremely high because the contract may transfer all assets in the address. Only choose it when the contract is extremely trusted.
  * allowedcontracts: contracts of the signature can take effect, if scopes is CustomContracts
  * allowedgroups: pubkeys of the signature can take effect, if scopes is CustomGroups
* use diagnostic: Whether to return the simulated invocation information and storage change information. The default value is `false`.
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
  "method": "invokefunction",
  "params": [
    "0xa1a375677dded85db80a852c28c2431cab29e2c4",
    "transfer",
    [
            {
                "type": "Hash160",
                "value": "0xfa03cb7b40072c69ca41f0ad3606a548f1d59966"
            },
            {
                "type": "Hash160",
                "value": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa"
            },
            {
                "type": "Integer",
                "value": "10000"
            },
            {
                "type": "String",
                "value": ""
            }
        ],
        [
            {
                "account": "0xfa03cb7b40072c69ca41f0ad3606a548f1d59966",
                "scopes": "CalledByEntry",
                "allowedcontracts": [],
                "allowedgroups": []
            }
        ],
    true
  ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "DAABECcMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBRmmdXxSKUGNq3wQcppLAdAe8sD+hTAHwwIdHJhbnNmZXIMFMTiKascQ8IoLIUKuF3Y3n1ndaOhQWJ9W1I=",
        "state": "HALT",
        "gasconsumed": "1490312",
        "exception": null,
        "notifications": [
            {
                "eventname": "Transfer",
                "contract": "0xa1a375677dded85db80a852c28c2431cab29e2c4",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteString",
                            "value": "ZpnV8UilBjat8EHKaSwHQHvLA/o="
                        },
                        {
                            "type": "ByteString",
                            "value": "+on7LBTfD1nd3wT25WUX8rNKrus="
                        },
                        {
                            "type": "Integer",
                            "value": "10000"
                        }
                    ]
                }
            }
        ],
        "diagnostics": {
            "invokedcontracts": {
                "hash": "0x9cac876fcc1646f1f017aa49b1fbcf87bd37b043",
                "call": [
                    {
                        "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4",
                        "call": [
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4",
                                "call": [
                                    {
                                        "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                                    },
                                    {
                                        "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                                    }
                                ]
                            },
                            {
                                "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4",
                                "call": [
                                    {
                                        "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                                    },
                                    {
                                        "hash": "0xa1a375677dded85db80a852c28c2431cab29e2c4"
                                    }
                                ]
                            },
                            {
                                "hash": "0xfffdc93764dbaddd97c48f252a53ea4643faa3fd"
                            }
                        ]
                    }
                ]
            },
            "storagechanges": [
                {
                    "state": "Changed",
                    "key": "BgAAAAEBZpnV8UilBjat8EHKaSwHQHvLA/o=",
                    "value": "8CTJ5wda"
                },
                {
                    "state": "Added",
                    "key": "BgAAAAEB+on7LBTfD1nd3wT25WUX8rNKrus=",
                    "value": "ECc="
                }
            ]
        },
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": "AOaXOgSIvRYAAAAAAKzgAQAAAAAAesUGAAFmmdXxSKUGNq3wQcppLAdAe8sD+gEAWQwAARAnDBT6ifssFN8PWd3fBPblZRfys0qu6wwUZpnV8UilBjat8EHKaSwHQHvLA/oUwB8MCHRyYW5zZmVyDBTE4imrHEPCKCyFCrhd2N59Z3WjoUFifVtSAUIMQMTS2HRIO9gDxq/U/lqIB77dLBzVHT4cwKdvqoGOZqm4IoGqHbYzBSYHOPHWGNutWvkjCgIQGQFKK1JGyOR16LwoDCEDrQCtTQQyXXSsHZm3oRiqiAzP00uFPaW9tICYC3D7Bm9BVuezJw=="
    }
}
```

Response description:

- script: the invocation script of the contract. You can analysis from https://neo.org/converter

  ```
   PUSHDATA1
   PUSHINT16 10000
   PUSHDATA1 0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa
   PUSHDATA1 0xfa03cb7b40072c69ca41f0ad3606a548f1d59966
   PUSH4
   PACK
   PUSH15
   PUSHDATA1 transfer
   PUSHDATA1 0xa1a375677dded85db80a852c28c2431cab29e2c4
   SYSCALL System.Contract.Call
  ```

- state:  `HALT` means the vm executed successfully, and`FAULT` means the vm exited due to an exception. 

- gasconsumed: the system fee consumed for invocation.

- exception: The exception messages occurred during contract execution. It is `null` when there is no exception.

- notifications: The event messages occurred during contract execution.  They can be checked by [getapplicationlog](./getapplicationlog.md) for on-chain transactions. 

- diagnostics: The process information and storage changes of the contract invocation. This request does not change the real storage on the blockchain, but only simulates the storage changes after the transaction is sent on the blockchain.  

- stack: the contract execution result. If the value is String or ByteArray, it is encoded by Base64.

- tx: the transaction's hex string of this invocation, need open wallet and added signers correctly, otherwise the string will not be returned.

- pendingsignature: It is returned if the transaction requires multiple signatures and the currently open wallet does not include all accounts of signers.

## About iterator

If the execution result of contract includes iterators, whether to return `session` is decided by the value of  `SessionEnabled` in `config.json` of the plugin `RpcServer`. If  `SessionEnabled` is `true`, `session` is returned to get further details of the Iterator. Otherwise, if  `SessionEnabled` is `false`, `session` is not returned.

In the following example,  `SessionEnabled` is `true`：

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "wh8MBnRva2VucwwU/+Ha24YygjLl9RpzOqiVrDhOCyVBYn1bUg==",
        "state": "HALT",
        "gasconsumed": "247083",
        "exception": null,
        "notifications": [],
        "stack": [
            {
                "type": "InteropInterface",
                "interface": "IIterator",
                "id": "bfc3ccf4-d814-4497-9d68-eb50806c3b7a"
            }
        ],
        "session": "77c20bc6-6c6a-40dc-87b9-0be461c04831"
    }
}
```

To get iterators, refer to the method [traverseiterator](traverseiterator.md) 
