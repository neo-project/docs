# getunclaimedgas method

Returns the unclaimed GAS with the specified address.

## Parameter Description

- address: Specified address.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getunclaimedgas",
  "params": ["NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unclaimed": "9693738",
        "address": "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y"
    }
}
```