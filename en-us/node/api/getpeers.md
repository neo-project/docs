# getpeers method

Gets the list of nodes that the node is currently connected/disconnected from.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getpeers",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "unconnected": [
            {
                "address": "::ffff:70.73.16.236",
                "port": 10333
            },
            {
                "address": "::ffff:82.95.77.148",
                "port": 10333
            },
            {
                "address": "::ffff:49.50.215.166",
                "port": 10333
            },
            {
                "address": "::ffff:24.5.178.244",
                "port": 10333
            }
        ],
        "bad": [
            {
                "address": "::ffff:139.219.226.107",
                "port": 10333
            }
        ],
        "connected": [
            {
                "address": "::ffff:139.219.106.33",
                "port": 10333
            },
            {
                "address": "::ffff:47.88.53.224",
                "port": 10333
            },
            {
                "address": "::ffff:47.91.92.192",
                "port": 10333
            },
            {
                "address": "::ffff:47.89.178.72",
                "port": 10333
            },
            {
                "address": "::ffff:61.69.169.117",
                "port": 10333
            },
            {
                "address": "::ffff:73.129.221.112",
                "port": 10333
            },
            {
                "address": "::ffff:174.2.185.133",
                "port": 10333
            },
            {
                "address": "::ffff:88.161.1.223",
                "port": 10333
            },
            {
                "address": "::ffff:114.234.77.207",
                "port": 10333
            },
            {
                "address": "::ffff:78.18.22.226",
                "port": 10333
            }
        ]
    }
}
```

Response Description:

Unconnected: A node that is not currently connected.

Bad: Nodes that are no longer connected.

Connected: the node to which you are currently connected.

