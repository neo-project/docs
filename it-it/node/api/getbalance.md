# Metodo getbalance

Restituisce il saldo dell'asset corrispondente nel portafoglio, in base al numero di asset specificato.

> [!Nota]
> Prima di eseguire questo comando è necessario aprire il wallet nel nodo Neo-CLI.

## Descrizione del Parametro

Asset_id: Asset ID (identificatore dell'asset), che è l'ID della transazione di RegistTransaction quando l'asset è registrato.

Per NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Per GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Gli ID degli asset rimanenti possono essere interrogati tramite il comando `list asset` in [Comando CLI](../cli.md) o nel Browser della Blockchain.

## Esempio 

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

Corpo della risposta:

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

Descrizione della Risposta:

Balance: Il saldo effettivo dell'asset nel wallet.

Confirmed: L'importo esatto dell'asset nel wallet, dove solo gli importi confermati possono essere utilizzati per il trasferimento.

I valori Balance e Confirmed potrebbero non essere uguali. Questo succede quando c'è una transazione in uscita dal wallet, e il cambiamento non è ancora stato confermato, dunque il valore confermato sarà inferiore al saldo. Una volta confermato l'accordo, i due diventeranno uguali.
