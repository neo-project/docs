# Getbalance Methode

Geeft de balans van de overeenkomstige asset in de wallet weer, gebaseerd op een gespecificeerd asset-nummer.

> [!Note]
> Om deze command uit te voeren, moet de wallet in de Neo-CLI node worden geopend.

## Parameter Omschrijving

Asset_id: Asset ID (asset-identificator), gelijk aan het transactie-ID van de RegistTransaction bij het registreren van de asset.

Voor NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Voor GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

De overgebleven asset-ID's kunnen opgevraagd worden door middel van de `list asset`-command in [CLI command](../cli.md), of in de blockchain-verkenner.

## Voorbeeld 

Request tekst:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

Response tekst:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
  "Balance": "1.01",
  "Confirmed": "1.01"
  }
}
```

Response Omschrijving:

Balance: het daadwerkelijke saldo van een asset in de wallet.

Confirmed: de exacte hoeveelheid van de asset in de wallet, waarbij alleen bevestigde hoeveelheden kunnen worden overgemaakt.

De Balance en Confirmed kunnen verschillen. Dit komt voor wanneer er een output-transactie is vanuit de wallet, welke nog niet bevestigd is, waardoor het bevestigde saldo lager ligt dan de Balance. Als de transactie is goedgekeurd, zullen ze weer gelijk worden.
