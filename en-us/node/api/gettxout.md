# Gettxout method

Returns the corresponding transaction output (change) information based on the specified hash and index.

## Parameter Description

Txid: transaction ID.

N: the index of the transaction to be obtained in the transaction (starting from 0).

## Call the example

Request text:

```json
{
   "Jsonrpc": "2.0",
   "Method": "gettxout",
   "Params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 0],
   "Id": 1
}
```

Response text:

```json
{
   "Jsonrpc": "2.0",
   "Id": 1,
   "Result": {
     "N": 0,
     "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
     "Value": "2950",
     "Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
   }
}
```