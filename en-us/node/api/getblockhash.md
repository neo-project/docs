# Getblockhash method

Returns the hash value of the corresponding block based on the specified index.

## Parameter Description

Index: block index.

## Call the example

Request text:

```json
{
   "Jsonrpc": "2.0",
   "Method": "getblockhash",
   "Params": [10000],
   "Id": 1
}
```

Response text:

```json
{
   "Jsonrpc": "2.0",
   "Id": 1,
   "Result": "4c1e879872344349067c3b1a30781eeb4f9040d3795db7922f513f6f9660b9b2"
}
```