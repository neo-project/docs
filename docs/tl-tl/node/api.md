# Reperensiya ng API

Bawat node sa Neo-CLI ay nagbibigay ng isang interface ng API para makamit ang datos ng blockchain na mula sa isang node, na nagpapadali sa pag-develop ng mga aplikasyon ng blockchain. Ang interface ay ibinigay sa pamamagitan ng [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html), at ang pinagtitibayan na protocol ay gumagamit ng HTTP/HTTPS para sa komunikasyon. Para makapagsimula ng isang node na nagbibigay ng isang RPC na serbisyo, i-run ang mga sumusunod na command:

`dotnet neo-cli.dll /rpc`

Para makapasok sa serber ng RPC gamit ang HTTPS, kailangan mong baguhin ang kompigurasyon na payl config.json bago simulan ang node at  lagyan ng pangalan ng domain, sertipiko, at password:

```json
{
  "ApplicationConfiguration": {
    "Paths": {
      "Chain": "Chain"
    },
    "P2P": {
      "Port": 10333,
      "WsPort": 10334
    },
    "RPC": {
      "Port": 10331,
      "SslCert": "YourSslCertFile.xxx",
      "SslCertPassword": "YourPassword"
    }
  }
}                                         
```

Pagkatapos ng pagsisimula ng JSON-RPC na serber, susubaybayan nito ang mga sumusunod na mga port, na naaayon sa Main at Test na mga net:

Para sa P2P at WebSocket na impormasyon tingnan ang [Node/Introduction](introduction.md).

|                | （Main Net） | （Test Net） |
| -------------- | ---------- | ---------- |
| JSON-RPC HTTPS | 10331      | 20331      |
| JSON-RPC HTTP  | 10332      | 20332      |

## Command List

| Command                                  | Reperensiya                                | Paliwanag                              | Mga Komento                     |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- | ---------------------------- |
| [dumpprivkey](api/dumpprivkey.md)        | \<address>                               | I-export ang pribadong key ng espisipikong address | Kailangan buksan ang wallet      |
| [getaccountstate](api/getaccountstate.md) | \<address>                               | I-check ang impormasyon ng account asset ayon sa address ng account |                              |
| [getapplicationlog](api/getapplicationlog.md) | \<txid>[verbose=0]                       | Ibinabalik ang log ng kontak batay sa tinukoy na txid. | Kailangan paganahin ang logging       |
| [getassetstate](api/getassetstate.md)    | \<asset_id>                              | Impormasyon sa asset ng query ayon sa espisipikong numero ng asset |                              |
| [getbalance](api/getbalance.md)          | \<asset_id>                              | Ibinabalik ang balance ng nararapat na asset sa wallet ayon sa espisipikong numero ng asset. | Kailangan buksan ang wallet      |
| [getbestblockhash](api/getbestblockhash.md) |                                          | Kinukuha ang hash ng pinakamataas na bloke sa pangunahing chain |                              |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                      | Ibinabalik ang nararapat na impormasyon ng bloke ayon sa espisipikong halaga ng hash |                              |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                     | Ibinabalik ang nararapat na impormasyon ng bloke ayon sa espisipikong indeks |                              |
| [getblockcount](api/getblockcount.md)    |                                          | Kinukuha ang bilang ng mga bloke sa pangunahing chain |                              |
| [getblockhash](api/getblockhash.md)      | \<index>                                 | Ibinabalik ang halaga ng hash sa nararapat na bloke batay sa tinukoy na indeks |                              |
| [getblocksysfee](api/getblocksysfee.md)  | \<index>                                 | Ibinabalik ang bayarin ng sistem bago ang bloke na naaayon sa tinutukoy na indeks |                              |
| [getconnectioncount](api/getconnectioncount.md) |                                          | Kinukuha ang kasalukuyang bilang ng koneksyon para sa node |                              |
| [getcontractstate](api/getcontractstate.md) | \<script_hash>                           | Ibinabalik ang impormasyon tungkol sa kontrata batay sa espisipikong hash ng script |                              |
| [getnewaddress](api/getnewaddress.md)    |                                          | Gumawa ng bagong address                     | Kailangan buksan ang wallet      |
| [getrawmempool](api/getrawmempool.md)    |                                          | Kumukuha ng isang listahan ng hindi nakompirmang mga transaksyon sa memorya |                              |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                      | Ibinabalik ang nararapat na impormasyon ng transaksyon batay sa tinutukoy na halaga ng hash |                              |
| [getstorage](api/getstorage.md)          | \<script_hash>  \<key>                   | Ibinabalik ang naitagong halaga batay sa kontrata ng script hash at key |                              |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                             | Ibinabalik ang nararapat na impormasyon ng awtput (pagbabago) ng transaksyon batay sa tinutukoy na hash at indeks |                              |
| [getpeers](api/getpeers.md)              |                                          | Kumukuha ng isang listahan ng mga node na kasalukuyang nakakonekta/hindi nakakonekta sa node na ito |                              |
| [getversion](api/getversion.md)          |                                          | Kumukuha ng impormasyon ng bersyon sa node na ito     |                              |
| [invoke](api/invoke.md)                  | \<script_hash>  \<params>                | Pinapaki-usapan ang isang kontrata ng smart sa tinutukoy na hash ng script kasama ang binigay na mga parameter |                              |
| [invokefunction](api/invokefunction.md)  | \<script_hash>  \<operation>  \<params>  | Pinapaki-usapan ang isang kontrata ng smart sa tinutukoy na hash ng script, pagpasa sa isang operasyon at mga params nito |                              |
| [invokescript](api/invokescript.md)      | \<script>                                | Pinapatakbo ang isang script sa pamamagitan ng virtual machine at ibinabalik ang mga resulta |                              |
| [listaddress](api/listaddress.md)        |                                          | Mga listahan ng lahat ng mga address sa kasalukuyang wallet. | Kailangan buksan ang wallet      |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                   | Ipahayag ang isang transaksyon sa network. Tingnan ang [network protocol](network-protocol.md) na dokumentasyon. |                              |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0]  | Ilipat sa tinutukoy na address            | Kailangan buksan ang wallet      |
| [sendmany](api/sendmany.md)              | \<outputs_array> \[fee=0] \[change_address] | Malakihang order ng pag-transfer                      | Kailangan buksan ang wallet      |
| submitblock                              | \<hex>                                   | Magsumite ng mga bagong bloke                        | Kinakailangan na ito ay konsensus na noda |
| [validateaddress](api/validateaddress.md) | \<address>                               | Patunayan na ang address ay isang tamang address ng NEO |                              |

## Halimbawa ng kahilingan ng GET

Ang tipikal na pormat ng paghingi ng kahilingan ng JSON-RPC GET ay ang mga sumusunod:

Ang sumusunod ay isang halimbawa kung paano makuha ang bilang ng mga bloke sa pangunahing chain.

Kahilingan ng URL:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

Pagkatapos magpadala ng kahilingan, makakakuha ka ng sumusunod na sagot:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## Halimbawa ng kahilingan ng POST

Ang pormat ng isang tipikal na paghingi ng kahilingan ng POST sa JSON-RPC ay ang mga sumusunod:

Ang sumusunod ay isang halimbawa kung paano makuha ang bilang ng mga bloke sa pangunahing chain.

Kahilingan ng URL:

```
http://somewebsite.com:10332
```

Laman ng kahilingan:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```

Pagkatapos magpadala ng kahilingan, makakakuha ka ng sumusunod na sagot:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## Mga kagamitan sa pagsusuri

Maaari mong gamitin ang ekstensyon ng Chrome sa Postman para mapangasiwaan ang pagsusuri (Ang pag-install ng ekstensyon ng Chrome ay nangangailangan ng koneksyon ng Internet), ang sumusunod ay isang screenshot ng pagsusuri:

![image](/zh-cn/node/assets/api_2.jpg)

![image](/assets/api_3.jpg)

## Iba

[C# JSON-RPC Command List](https://github.com/chenzhitong/CSharp-JSON-RPC/blob/master/json_rpc/Program.cs)
