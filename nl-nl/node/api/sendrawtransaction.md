# Sendrawtransaction Methode

Broadcast een transactie over het NEO-netwerk. Er zijn vele soorten transacties; zie de [netwerkprotocoldocumentatie](../network-protocol.md).

## Parameter Omschrijving

Hex: een hexadecimale string die geserialiseerd is, na de getekende transactie in het programma.

## Voorbeeld

Request tekst:

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": [ "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"],
  "id": 1
}
```

Response tekst:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": false
}
```

Response Omschrijving:

Als het resultaat `true` is, dan is de huidige transactie succesvol uitgezonden naar het netwerk.

Als het resultaat `false` is, dan is de huidige transactie niet uitgezonden. Hiervoor zijn vele mogelijke redenen, zoals dubbel spenderen, een onvolledige handtekening et cetera.

In bovenstaand voorbeeld was een bevestigde transactie al reeds uitgezonden, waardoor de tweede broadcast werd geweigerd (door dubbel spenderen).
