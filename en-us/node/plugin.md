# Plug-ins for NEO Client

Since NEO 2.9.0 some additional functionalities are individually encapsulated in plug-ins for the purpose of improving node security, stability, and flexibility. The user can select the desired extension functionality instead of invoking it with additional parameters every time starting neo-cli, thus avoiding many human errors and some tedious instructions such as opening a wallet and calling applicationlogs. Click [here](https://github.com/neo-project/neo-plugins/releases) to download Plugins.

| Plug-in                                                      | Description                                                  |                                                              |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ApplicationLogs.zip) | Synchronizes the smart contract log (ApplicationLogs) automatically in RPC mode. Currently the log has been changed to be stored in the format of LevelDB. | Mandatory for exchanges                                      |
| [CoreMetrics](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/CoreMetrics.zip) | 查询历史区块的时间戳。                                       | Recommended for exchanges                                    |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/ImportBlocks.zip) | Synchronizes the client using offline packages.              | Mandatory                                                    |
| [RpcWallet](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcWallet.zip) | Provides wallet-specific RPC functionalities.                | Mandatory                                                    |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/SimplePolicy.zip) | Enables policies for filtrate illegal transactions                              | Mandatory                                            |
| [RpcSecurity](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcDisabled.zip) | Improves RPC security.                                       | Optional                                                     |
| [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.2/RpcSystemAssetTracker.zip) | 查询 UTXO 资产相关信息。                                     | Recommended for exchanges                                    |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/StatesDumper.zip) | Exports NEO-CLI status data.                                 | Optional                                                     |
| [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases/download/v2.10.0/RpcNep5Tracker.zip) | Enquiries NEP-5 balance and transactions history of accounts through RPC | Optional                                                     |

## Installing plug-ins

To install the plug-in, create a new **Plugins** folder (The first letter is capitalized) under the client root directory neo-cli root directory and copy the unzipped plugins into it.

![plugins.png](../../assets/plugins.png)

## API methods

### getapplicationlog method

Returns the contract log based on the specified txid. The complete contract logs are stored under the ApplicationLogs directory.

This method is provided by the [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ApplicationLogs.zip) plugin. You need to install the plugin before invoking the method.

#### Parameter Description

txid：Transaction ID

#### Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["b6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3"],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xb6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x23c3aaaa31a0c373c23505157e9fb2665c7065ec",
                "vmstate": "HALT",
                "gas_consumed": "2.931",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x1578103c13e39df15d0d29826d957e85d770d8c9",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "235a717ed7ed18a43de47499c3d05b8d4a4bcf3a"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0b2f7cac1d57b9f535d35da1a5421015e4e32b19"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00f44a4f9df66d01"
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
