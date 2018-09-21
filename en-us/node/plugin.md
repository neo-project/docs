# Plug-ins for NEO Client

Since NEO 2.9.0 some additional functionalities are individually encapsulated in plug-ins for the purpose of improving node security, stability, and flexibility. The user can select the desired extension functionality instead of invoking it with additional parameters every time starting neo-cli, thus avoiding many human errors and some tedious instructions such as opening a wallet and calling applicationlogs. Click [here](https://github.com/neo-project/neo-plugins/releases) to download Plugins.

| Plug-in                                                      | Description                                                  |                                      |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------ |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ApplicationLogs.zip) | Synchronizes the smart contract log (ApplicationLogs) automatically in RPC mode. Currently the log has been changed to be stored in the format of LevelDB. | Mandatory for exchanges              |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ImportBlocks.zip) | Synchronizes the client using offline packages. This plug-in is included in the release package. | Mandatory                            |
| [RpcDisabled](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/RpcDisabled.zip) | Disables all RPC services.                                   | Optional                             |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/SimplePolicy.zip) | Enables policies for consensus.                              | Mandatory for building private chain |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/StatesDumper.zip) | Exports NEO-CLI status data.                                 | Optional                             |

## Installing plug-ins

To install the plug-in, create a new **Plugins** folder (The first letter is capitalized) under the client root directory neo-cli root directory and copy the unzipped plugins into it. 

![plugins.png](../../assets/plugins.png)

## API methods

### getapplicationlog method

Returns the contract log based on the specified txid. The complete contract logs are stored under the ApplicationLogs directory.

This method is provided by the [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.0/ApplicationLogs.zip) plugin. You need to install the plugin before invoking the method.

#### Parameter Description

txid：Transaction ID

#### Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07"],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x0110a8f666bcc650dc0b544e71c31491b061c79e",
                "vmstate": "HALT, BREAK",
                "gas_consumed": "2.855",
                "stack": [
                    {
                        "type": "Integer",
                        "value": "1"
                    }
                ],
                "notifications": [
                    {
                        "contract": "0xb9d7ea3062e6aeeb3e8ad9548220c4ba1361d263",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "e3069da508f128069a0cd2544b0728ccbacdfb43"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d142f89e93b2717426a8130c37dad93aad70cff5"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00e1f50500000000"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```
