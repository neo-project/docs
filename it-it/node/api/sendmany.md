# Metodo sendmany

Ordine di trasferimento di grandi quantitativi, é possibile specificare un indirizzo di modifica.

> [!Nota]
> È necessario aprire il portafoglio nel nodo NEO-CLI prima di eseguire questo comando.

## Descrizione del parametro

\<outputs_array> \[fee=0] \[change_address]

Outputs_array: Array, la struttura dati di ogni elemento nell'array è la seguente:

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset：Asset ID（identificatore dell'asset），l'ID `RegistTransaction` dell'asset al momento della registrazione.

​	Per NEO：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

​	Per NeoGas：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

   Gli ID degli asset rimanenti possono essere passati attraverso la [linea di comando CLI](../cli.MD), anche la query del comando `list Asset` può essere interrogata nel browser della block chain.


​	value：Importo del trasferimento

​	address：Indirizzo di destinazione.

Fee: Commissione di gestione, parametro opzionale, il valore predefinito è 0.

Change_address: Cambia indirizzo, parametro opzionale, di default è il primo indirizzo standard nel wallet.

## Esempio

Corpo della richiesta：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

Corpo della risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "27b9a82ed519eec17c5520927b3f472e4df28b835c24dba25645e1650ed8d2ac",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f",
                "vout": 0
            }
        ],   
        "vout": [
            {
                "n": 0,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "999998",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "40844144eb6819cb094afee2db5e5da078cfc7bbe29dbc60e47b4c3b4bdf77a5fd97865ae9b5a8d8bb3fa20f1441a58a05f848b2ea49c6c0dbbfc5ed241b226665",
                "verification": "210208c5203d32f960c54c225f140c1020408b114c15d29082fc959dac6874828fccac"
            }
        ]
    }
}
```

Descrizione della risposta:

Restituisce i dettagli della transazione come sopra per indicare che la transazione è stata inviata correttamente o che la transazione non è andata a buon fine.

Se il formato JSON non è corretto, viene restituito un errore Parse.
Se la firma è incompleta, viene restituita una transazione in sospeso.
Se il saldo è insufficiente, viene restituito un messaggio di errore.
