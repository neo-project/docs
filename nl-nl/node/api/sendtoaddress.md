# Sendtoaddress Methode

Overmaken naar een gespecificeerd adres.

> [!Note]
> De wallet moet worden geopend in de Neo-CLI-node voordat deze command uitgevoerd kan worden.

## Parameter Omschrijving

Asset_id: de asset-identificator, welke de transactie-ID is van de RegistTransaction bij het registreren van de asset.

Voor NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Voor GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

De overgebleven asset-ID's kunnen worden opgevraagd door middel van de `list asset`-command in [CLI Command](../cli.md), of in de blockchain-verkenner.

Address: het ontvangende adres.

Value: de over te maken hoeveelheid.

Fee: servicekosten; standaard 0 (kan leeg worden gelaten bij `"Fee": 0`).

## Voorbeeld

Request tekst:

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4", "AK4if54jXjSiJBs6jkfZjxAastauJtjjse", 1],
  "id": 1
}
```

Response tekst:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "Txid": "fbd69da6996cc0896691a35cba2d3b2e429205a12307cd2bdea5fbdf78dc9925",
    "Size": 262,
    "Type": "ContractTransaction",
    "Version": 0,
    "Attributes":[],
    "Vin": [
      { 
        "Txid": "19fbe968be17f4bd7b7f4ce1d27e39c5d8a857bd3507f76c653d204e1e9f8e63",
        "Vout": 0
      }
    ],
    "Vout": [
      {
        "N": 0,
        "Asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "Value": "1",
        "Address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
      },
      {
        "N": 1,
        "Asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
        "Value": "4978980",
        "Address": "AK4if54jXjSiJBs6jkfZjxAastauJtjjse"
       }
    ],
    "Sys_fee": "0",
    "Net_fee": "0",
    "Scripts": [
       {
        "Invocation": "40f02345c7e90245F085d0c588433ca9e89c6df58f3636b5240288aab5f081b1c67c3cad5946890de9001fcfe8d8b748b647b116891e6f1fb2393cc2f1aba45a81",
        "Verification": "21027b30333e0d0e6552ae6d1da9f9409f551e35ee9719305e945dc4dcba998456caac"
        }
     ]
  }
}
```

Response Omschrijving:

Wanneer de transactiedetails zoals hierboven worden teruggestuurd, is de transactie succesvol gestuurd; anders niet.

Als de signature incompleet is, zal de transactie worden teruggestuurd om ondertekend te worden.

Als het saldo ontoereikend is, zal het een errorbericht weergeven.
