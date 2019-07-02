# Gettxout Methode

Geeft de overeenkomstige transactie-outputinformatie weer (teruggestuurd 'wisselgeld'), gebaseerd op de gespecificeerde hash en index.

## Parameter Omschrijving

Txid: transaction ID

N: de index van de transactie-output welke in de transactie moet worden verkregen (begint bij 0).

## Voorbeeld

Request tekst:

```json
{
   "jsonrpc": "2.0",
   "method": "gettxout",
   "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 0],
   "id": 1
}
```

Response tekst:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": {
     "N": 0,
     "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
     "Value": "2950",
     "Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
   }
}
```
