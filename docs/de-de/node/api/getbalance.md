# Getbalance Methode

Gibt den Kontostand eines Assets in der Wallet aus, basierend auf der spezifischen Asset-ID.

> [!Anmerkung]
> Sie müssen die Wallet im NEO-CLI zuerst öffnen, bevor Sie diesen Befehl ausführen.

## Parameter Beschreibung

Asset_id: Die Asset-ID (asset identifier), ist die Transaktions-ID der RegistTransaction mit der das Asset registriert wurde.

Für NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Für GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Die übrigen Asset-IDs können über den `list asset` Befehl in [CLI Command](../cli.md) oder über einen Blockchainbrowser abgefragt werden.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

Antwort:

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

Antworterläuterung:

Balance: Der aktuelle Kontostand der Wallet.

Confirmed: Die exakte Menge an Assets in der Wallet. Nur bestätigte Assets können transferiert werden.

Die Werte von Balance und Confirmed können nicht gleich sein. Dies passiert, wenn es eine Outputtransaktion der Wallet gibt und diese noch nicht bestätigt wurde. Der Wert von Confirmed ist in diesem Fall niedriger. Sobald die Transaktion bestätigt wurde, sind beide Werte wieder gleich.
