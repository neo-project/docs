# getnewaddress Method

Creates a new address.

> [!Note]
> You must open the wallet in the Neo-CLI node before executing this command.

## Example

Request text：

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

Response text：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

Response Description：

Returns the new created address.
