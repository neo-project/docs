# getblockheader Method

Returns the corresponding block header information according to the specified script hash.

## Parameter Description

hash：The block script hash.

verbose：Optional, the default value of verbose is 0. When verbose is 0, the serialized information of the block is returned, represented by a hexadecimal string. If you need to get detailed information, you will need to use the SDK for deserialization. When verbose is 1, detailed information of the corresponding block in Json format string, is returned.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957"],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "00000000e5abdddd1bb06ac4530a0cb699a99453fc64086708659cac9a8258061ab533698e6a6e91a592649a7fb0af5afa4d899d871819994fd260dc6b50c1be2badff0974486c5b40ac27006d80cbea5b752a7683f5011bdaaccee8c4d2555c829fa51e31551ef201fd45014047c4915575949baa8594877105598df8f06875539aa98e2b028ebf5b4f17122831d32308142062db8b50e1bbe07d2313510c0ae289e7f9a97b20cbe858e62ba2407187c52864ececa40ad3c76f221c7ef9918b9e2dd058156021a88737ca0a54722482297c9775af35d52cd4e01648a34662748d00f5b3c63ac2ae346b6bebf236401f23118e86ce3a74ae1bd92c41675f7f8dc94a6ceb2796a2a3741d248f0d5f07aaeda7ec47287317926382d921a47a38bb5793ebef91cbff7a04313d91a4d3ea403aecb64ecde98fc705dd4e9e26580fbeaf27bd24b69507b1b7d348ec29f7bc09948d237d7ca6fb3b253b59297bdc7fe10d1132fef3ac0d728e5063baebbc99cd4053871e5b4138d5b3dfcf79264d240b389417213517ad1fff9636d067a32d288b660503695c4341ce0799d0d9b1e78a62322f10eef1f44f3dd9ec4d311381a3daf15521024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d21025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b642102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae00"
}
```

Request body:

Verbose = 1, returns the result in JSON format.

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["a5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957", 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xa5508c9b6ed0fc09a531a62bc0b3efcb6b8a9250abaf72ab8e9591294c1f6957",
        "size": 676,
        "version": 0,
        "previousblockhash": "0x6933b51a0658829aac9c6508670864fc5394a999b60c0a53c46ab01bddddabe5",
        "merkleroot": "0x09ffad2bbec1506bdc60d24f991918879d894dfa5aafb07f9a6492a5916e6a8e",
        "time": 1533823092,
        "index": 2600000,
        "nonce": "762a755beacb806d",
        "nextconsensus": "ATobfpwv6JBXciEC4bL8GL8PjQkssDsmCR",
        "script": {
            "invocation": "4047c4915575949baa8594877105598df8f06875539aa98e2b028ebf5b4f17122831d32308142062db8b50e1bbe07d2313510c0ae289e7f9a97b20cbe858e62ba2407187c52864ececa40ad3c76f221c7ef9918b9e2dd058156021a88737ca0a54722482297c9775af35d52cd4e01648a34662748d00f5b3c63ac2ae346b6bebf236401f23118e86ce3a74ae1bd92c41675f7f8dc94a6ceb2796a2a3741d248f0d5f07aaeda7ec47287317926382d921a47a38bb5793ebef91cbff7a04313d91a4d3ea403aecb64ecde98fc705dd4e9e26580fbeaf27bd24b69507b1b7d348ec29f7bc09948d237d7ca6fb3b253b59297bdc7fe10d1132fef3ac0d728e5063baebbc99cd4053871e5b4138d5b3dfcf79264d240b389417213517ad1fff9636d067a32d288b660503695c4341ce0799d0d9b1e78a62322f10eef1f44f3dd9ec4d311381a3da",
            "verification": "5521024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d21025bdf3f181f53e9696227843950deb72dcd374ded17c057159513c3d0abe20b642102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
        },
        "confirmations": 149214,
        "nextblockhash": "0x9559ab79d1b9c69fa0cd7b5356018fd6ef11f3cf5b22a1d7eb0481cb359b3fab"
    }
}
```