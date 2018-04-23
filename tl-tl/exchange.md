# Dokumento para sa Mga Deveoper ng Exchange


Ang dokumentong ito ay inilaan upang gabayan ang mga developer ng exhange upang mag set-up ng mga NEO node sa exchange server at kumpletuhing kaugnay na pagbuo ng programa para sa mga transaksyong asset ng NEO. Bago magbasa, siguraduhin na nabasa mo ang [NEO White Paper] (index.html) at nauunawaan ang NEO background na kaalaman at teknolohiya.


Sa pangkalahatan, kailangan ng isang palitan ang mga sumusunod:

- [Pag-deploy ng NEO Node sa Server](#deploying-a-neo-node-on-server)
- [Paglikha ng mga Wallet at mga address sa Deposito](#creating-a-wallet-and-deposit-addresses)
- [Pakikitungo sa mga Transaksyong Global Asset](#dealing-with-global-assets-transactions)
- [Pagkikitungo sa mga Transaksyon ng NEP-5 na mga Asset](#dealing-with-nep-5-assets-transactions)
- [(Opsyonal) Ipamahagi ang GAS sa mga User](#optional-distributing-gas-to-users)



## Pag-deploy ng NEO Node sa Server

Upang i-deploy ang NEO node sa exchange server, gawin ang mga sumusunod:

1.  I-install [.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime) sa server, 1.0.1 at sa susunod na bersyon
2.  Mula kay Github, i-download ang [Neo-CLI](https://github.com/neo-project/neo-cli/releases) programa at paganahin ang NEO node.

Para sa karagdagang impormasyon, sumangguni sa [Pag-install at pag-deploy ng NEO node](node/setup.html).

## Paglikha ng Mga Wallet at mga address sa deposito

### Tungkol sa NEO-CLI

Ang NEO-CLI ay isang command-line client (wallet) para sa mga developer. May dalawang paraan ang mga developer na makipag-ugnay dito:

- Paggamit ng CLI (command-line interface) na mga utos. Halimbawa, maaari kang lumikha ng isang wallet, bumuo ng isang address, atbp.
- Gamit ang Remote Procedure Call (RPC). Halimbawa, maaari kang maglipat sa itinalagang address, kunin ang impormasyon ng block ng itinalagang taas, kunin ang impormasyon ng itinalagang kalakalan, atbp.

Ang NEO-CLI ay nagbibigay ng mga sumusunod na tampok:

- Bilang isang wallet, namamahala ng mga asset sa pamamagitan ng command-line.

  Upang paganahin ang wallet, ipasok ang sumusunod na command sa ilalim ng direktoryo ng NEO-CLI:
  
  ```
  dotnet neo-cli.dll
  ```

 Upang suriin ang lahat ng mga magagamit na command, ipasok ang sumusunod na command:

  ```
  help
  ```

Para sa karagdagang impormasyon, sumangguni sa [CLI Command Reference](node/cli.html).

-Nagbigay ng mga API upang mabawi ang blockchain na datos mula sa mga node. Ang mga interface ay ipinagkakaloob [JSON-RPC](http://www.jsonrpc.org/specification)，at ang kalakip na mga komunikasyon ay gumagamit ng HTTP / HTTPS protocol.

 Upang magsimula ng node na nagbibigay ng serbisyo ng RPC, ipasok ang sumusunod na command sa ilalim ng direktoryo ng NEO-CLI:

  ```
  dotnet neo-cli.dll /rpc
  ```

  Para sa karagdagan pang impormasyon sa API, sumangguni sa [API Reference](node/api.html).


### Lumikha ng Wallet

Ang palitan ay kailangang lumikha ng isang online wallet upang pamahalaan ang mga address ng deposito ng mga gumagamit. Ang isang pitaka ay ginagamit upang iimbak ang impormasyon ng mga account (parehong mga pampublikong key at mga pribadong key) at ang mga kontrata. Ito ang pinakamahalagang patunay na hinahawakan ng gumagamit. Ang mga gumagamit ay dapat na panatilihin ang mga wallet file at secure ang mga password ng wallet. Hindi nila dapat mawala o ibunyag ang mga datos na ito.

> [!Tandaan]
>
> Ang mga palitan ay hindi kailangang lumikha ng wallet para sa bawat address. Ang isang online wallet ay karaniwang nagpapanatili sa lahat ng mga address ng deposito ng mga gumagamit. Ang isang malamig na wallet(offline wallet) ay isa pang pagpipilian sa imbakan na nagbibigay ng mas mahusay na seguridad.

Upang lumikha ng wallet, gawin ang mga sumusunod:

1. ipasok  `create wallet <path>`.

   <path> ay ang landas ng pitaka at pangalan ng wallet na file. Ang extension ng file ay maaaring maging anumang uri, halimbawa, gumawa ng wallet mywallet.db3.

2. Magtakda ng isang password para sa wallet.

> [!Tandaan]
>
>Ang wallet ay dapat panatilihing bukas sa lahat ng oras upang tumugon sa mga kahilingan sa pag-withdraw ng mga gumagamit. Para sa mga kadahilanang pang-seguridad, ang mga wallet ay dapat na patakbuhin sa isang malayang server kung saan ang firewall ay maayos na naisaayos, tulad ng ipinapakita sa ibaba. 

|                    | Mainnet | Testnet |
| ------------------ | ------- | ------- |
| JSON-RPC via HTTPS | 10331   | 20331   |
| JSON-RPC via HTTP  | 10332   | 20332   |
| P2P                | 10333   | 20333   |
| websocket          | 10334   | 20334   |

### Pagbubuo ng mga Address sa Deposito

Ang isang wallet ay maaaring mag-imbak ng maramihang mga address. Ang palitan ay kailangang bumuo ng isang addressu sa deposito para sa bawat user.
Mayroong dalawang mga paraan upang makabuo ng mga address ng deposito:

- Kapag ang gumagamit sa deposito (NEO / NEO GAS) sa unang pagkakataon, ang programa ay dynamic na bumubuo ng isang NEO address. Ang kalamangan ay hindi na kailangan upang makabuo ng mga address sa mga nakapirming mga agwat ng oras, habang ang kawalan ay hindi mo maaaring i-backup ang wallet.


-Upang bumuo ng programa ng dynamically binuong mga address, gamitin ang NEO-CLI API  [getnewaddress Method](node/api/getnewaddress.html). Ang nagawa na address ay ibinalik.
  

- Ang palitan ay lumilikha ng batch ng NEO address nang maaga. Kapag ang mga singil ng gumagamit sa unang pagkakataon (NEO / NEO GAS), ang palitan ay nagtatalaga ng isang NEO address sa kanya. Ang kalamangan ay ang kaginhawaan na i-backup ang wallet, habang ang kawalan ay ang pangangailangan upang bumuo ng mga address NEO nang manu-mano.
  Upang bumuo ng mga address sa batch, patakbuhin ang ng NEO-CLI command `create address [n]`. Ang mga address ay awtomatikong na-export sa address.txt file.
  [n] ay opsyonal. Ang default na halaga nito ay 1. Halimbawa, upang bumuo ng 100 mga address sa isang pagkakataon, ipasok `create address 100`.


> [!Tandaan]
>
>Sa alinmang paraan, dapat na i-angkat ng palitan ang mga address sa database at ipamahagi ang mga ito sa mga gumagamit.

## Pakikitungo sa mga Transaksyong Global Asset

### Pagbubuo ng Programa para sa mga Deposito ng Gumagamit at mga Pag-withdraw

Para sa mga pandaigdigang ari-arian, kailangan ng palitan ng mga programa upang matupad ang mga sumusunod na function:

1. Subaybayan ang mga bagong bloke sa pamamagitan ng NEO-CLI API([getblock Method](node/api/getblock2.html)).
2. Harapin ang mga deposito ng user ayon sa impormasyon ng transaksyon.
3. Iimbak ang mga talaan ng transaksyon na may kaugnayan sa palitan.

#### Mga Deposito ng Gumagamit

Tungkol sa mga deposito ng user, kailangang palitan ng palitan ang mga sumusunod:

- Ang NEO blockchain ay mayroon lamang isang pangunahing chain na walang mga chain sa gilid, ay hindi ma-fork, at hindi magkakaroon ng ilang mga bloke.
- Ang isang transaksyon na na-record sa NEO blockchain ay hindi maaaring ma-tampered sa, na nangangahulugang ang pagkumpirma ay kumakatawan sa isang tagumpay na deposito.
- Sa pangkalahatan, ang balanse ng isang deposito na address sa palitan ay hindi katumbas ng balanse ng gumagamit sa palitan. Maaaring dahil:
  - Kapag naglilipat o nag-withdraw, ang NEO wallet ay tumitingin sa pamamagitan ng isa o higit pang mga address sa wallet, hinahanap ang minimal na maluwag na pagbabago na nakakatugon sa pangangailangan at nagdadagdag ng hanggang kabuuan ng transaksyon at pagkatapos ay nagsisilbing bilang input, sa halip na umalis mula sa tinukoy na address (maliban kung ang palitan ay muling isinusulat ang ilang mga function ng NEO wallet upang matugunan ang kanilang sariling mga pangangailangan).
  - Ang iba pang mga operasyon na maaaring humantong sa hindi pagkakapantay-pantay na balanse, halimbawa, ang paglilipat ng mga bahagi ng mga asset sa mga malamig na wallet nito.
- Mayroong higit sa dalawang mga asset (NEO at NEO GAS) sa isang NEO address. Ang higit pang mga asset na ibinigay ng mga gumagamit (tulad ng stock o token) ay maaaring maimbak. Ang palitan ay dapat matukoy ang uri ng mga ari-arian kapag ang mga deposito ng gumagamit. Huwag isaalang-alang ang iba pang mga ari-arian bilang NEO pagbabahagi o NEO o malito ang withdrawal ng NEO sa NEO GAS.
- NEO wallet ay isang buong node, na kailangang manatili sa online upang i-synchronize ang mga bloke. Maaari mong tingnan ang katayuan ng pag-block ng pag-synchronize sa pamamagitan ng estado ng pagpapakita sa CLI, kung saan ang kaliwang bahagi ay ang lokal na taas ng bloke, at ang kanang bahagi ay ang taas ng node block.
- Sa palitan, ang paglipat sa pagitan ng mga gumagamit ay hindi dapat maitala sa pamamagitan ng blockchain. Sa pangkalahatan, ang balanse ng user ay binago nang direkta sa database. Tanging ang mga deposito at withdrawals ay dapat na maitatala sa blockchain.

#### Mga Rekord ng Deposito

Ang palitan ay kailangang magsulat ng code upang masubaybayan ang bawat transaksyon sa isang bloke at itala ang lahat ng mga transaksyon na may kaugnayan sa mga address ng palitan sa database. Kung ang isang deposito ay nangyayari, dapat na ma-update ang balanse ng gumagamit.

Maaaring gamitin ng mga developer ang  `getblock <index> [verbose]` paraan ng NEO-CLI API upang mabawi ang impormasyon ng bloke. `<index>` ay ang index ng bloke. `[verbose]` ay 0 bilang default. Kailan `[verbose]` ay 0, ang paraan ay nagbabalik ng serialized block na impormasyon sa Hexadecimal. Dapat mong deserialize ang hex string upang makuha ang detalyadong impormasyon ng block. Kailan `[verbose]` ay 1, ang paraan ay nagbabalik ng detalyadong impormasyon ng nararapat na block sa JSON na format. Para sa karagdagang impormasyon, sumangguni sa [Getblock Method](node/api/getblock2.html).

Ang bloke ng impormasyon kabilang ang input at output ng mga transaksyon. Kailangan ng palitan ng rekord ang lahat ng mga kaugnay na transaksyon nito. Ang mga transaksyon na output ay sa katunayan ang mga rekord ng transaksyon ng mga withdrawals ng isang gumagamit. Kapag nakikita ng palitan ang alinman sa mga address nito sa output ng mga transaksyon, ina-update nito ang NEO / NEO GAS na balanse ng kaukulang gumagamit na nagmamay-ari ng deposito na ito. Ang ilang mga palitan ay maaari ring gawin tulad ng sumusunod: kung ito ay nakakahanap ng isang address sa loob ng palitan bilang ang output ng transaksyon, pagkatapos ay itatala ang deposito sa database nito at binabago ang balanse ng gumagamit pagkatapos ng ilang mga pagkumpirma (Maliban kung ito ay kailangang sumunod sa pagpapatakbo ng iba pang blockchains, hindi inirerekomenda ang ganitong paraan).

> [!Tandaan]
>
> - Paraan ng pagkuha getblockcount ang bilang ng mga bloke sa pangunahing chain. Ang unang parameter ng Method getblock ay `<index>` 
kung saan ay ang index ng block. I-block ang index = I-block ang taas = Ang bilang ng mga bloke - 1. Kung ang getblockcount ay nagbalik 1234, dapat mong gamitin ang getblock 1233 upang makuha ang impormasyon ng pinakabagong block.
> - Ang mga deposito at mga withdrawal na transaksyon (NEO / NEO GAS) ay lahat sa isang uri na pinangalanang ContractTransaction. Ang mga palitan ay kailangan lamang mag-alaga tungkol sa mga uri ng Kontrata ng Transaksyon kapag tiningnan nila ang mga transaksyon sa isang bloke.
> - Bilang unang transaksyon ng bawat bloke ay dapat na MinerTransaction, maaari mong pabayaan o tumalon sa paglipas nito kapag traversing ang blockchain.
> - Kinukuha ng sistema ng NEO ang transaksyon bilang isang yunit ng record.
>

### Pakikitungo sa mga Gumagamit ng mga Paglipat

Upang makitungo sa withdrawals ng gumagamit para sa mga pandaigdigang asset, kailangan ng palitan ang mga sumusunod:

1. Sa NEO-CLI, patakbuhin ang `open wallet <path>` upang buksan ang wallet.

2. I-rekord ang transaksyon ng pag-withdraw ng gumagamit at baguhin ang balansng user.

3. (Opsyonal) Mga deal ng serbisyo sa customer na may withdrawal application.

4. Magpadala ng transaksyon sa gumagamit ng address sa withdrawal gamit ang pamamaraan ng NEO-CLI API, `sendtoaddress <asset_id> <address> <value>`. Para sa karagdagang impormasyon, sumangguni sa  [sendtoaddress Method](node/api/sendtoaddress.html).

   - `<asset_id>` ：Asset ID
   - `<address>` ：Pag-withdraw ng address
   - `<value>` Halaga ng kinuha

   Maaari mo ring ipadala ang transaksyon sa isang batch ng mga address gamit ang API [sendmany Method](node/api/sendmany.html).

5. I-extract ang ID ng transaksyon mula sa mga ibinalik na detalye ng transaksyon sa format ng JSON, at pagkatapos ay i-record sa database.

6. Kapag nakumpirma na sa blockchain, markahan ang transaksyon sa pag-withdraw bilang tagumpay.

   Katulad ng pagsubaybay sa deposito, ang mga withdrawals ay kailangan din na subaybayan. Kung ang ID ng withdrawal ay matatagpuan sa blockchain, nangangahulugang ang transaksyong ito ay nakumpirma na at isang matagumpay na pag-withdraw
   
> [!Tandaan]
>
> -  Ang <value> dito ay tumutukoy sa aktwal na halaga, sa halip na ang halaga na times sa 10 ^ 8.
> -  Ang halaga ng transfer ng NEO ay dapat na isang integer; kung hindi man, hindi maitatatag ito ng blockchain dahil ang hindi maayos na pagbabago sa wallet ay hindi tumpak. Kakailanganing muling itayo ang index ng wallet, na muling pagkalkula ng mga transaksyon at pagbabago ng wallet.

## Pagkikitungo sa mga Transaksyon ng NEP-5 na mga Asset

### Pagtanggap ng Mga Abiso ng Mga Gumagamit sa Deposito

Para sa mga asset ng NEP-5, kailangan ng palitan ang pagpapabatid ng mga deposito ng mga gumagamit. Ang notification para sa bawat bloke ay naitala sa isang JSON file, na kinabibilangan ng lahat ng impormasyon ng bawat transaksyong NEP-5.

Upang makakuha ng mga file ng notification, patakbuhin ang sumusunod na command:

```
dotnet neo-cli.dll --rpc --record-notifications
```

Ang isang folder na "Notification" ay binuo sa ilalim ng landas ng ugat, tulad ng ipinapakita sa ibaba:

![1](../assets/notification_1.jpg)

#### ![2](../assets/notification_2.jpg)

#### Mga abiso sa JSON File

Ang sumusunod ay nagpapakita ng isang halimbawa ng nilalaman ng abiso ng file.

```json
[
{
    "txid": "0x65d62a736a73c4d15dc4e4d0bfc1e4bbc4ef220e163625d770eb05577b1afdee",
    "contract": "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "state":
    {
        "type": "Array",
        "value": [
        {
            "type": "ByteArray",
            "value": "7472616e73666572"
        },
        {
            "type": "ByteArray",
            "value": "d336d7eb9975a29b2404fdb28185e277a4b299bc"
        },
        {
            "type": "ByteArray",
            "value": "eab336cac807707295afa7e7da2f4683237f612a"
        },
        {
            "type": "ByteArray",
            "value": "006ad42d100100"
        }]
    }
}]
```

Sa file na ito, mayroong isang hanay ng mga abiso na may isang bagay lamang, na nangangahulugang isa lamang NEP-5 na kaganapan ang na-trigger sa block. Ang mga parameter na may kaugnayan sa isang transaksyon sa file ay ang mga sumusunod:

-  **contract**: ang iskrip na hash ng matalinong kontrata, kung saan maaaring makilala ng palitan ang uri ng asset. Halimbawa,"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9" ay ang iskrip hash at ang natatanging pagkakakilanlan ng RPX asset.

-  Ang apat na bagay na kasama sa "state" na array:

[kaganapan, mula sa account, sa account, halaga]

   -  Ang unang bagay na may uri ay "bytearray" at ang halaga ay "7472616e73666572", ulad ng ipinapakita sa halimbawa, maaaring ma-convert sa string na "transfer". "transfer" ay isang paraan sa NEP5 na kumakatawan sa isang transfer ng pag-aari.
   -  Ang pangalawang bagay sa array ay ang address ng account kung saan ang asset ay inilipat mula sa. Ang uri nito "bytearray" at ang halaga "d336d7eb9975a29b2404fdb28185e277a4b299bc“ maaaring i-convert sa "Ab2fvZdmnM4HwDgVbdBrbTLz1wK5TcEyhU". Tandaan na para sa hexadecimal string na may prefix na "0x", pinoproseso ito bilang malaking endian; kung hindi, ito ay naproseso bilang maliit na endian.
   -  Ang ikatlong bagay sa array ay ang address ng account kung saan ang asset ay inilipat sa. Kung ang address ay isang address ng palitan ng account, ito ay isang transaksyon sa deposito.
   -  Ang ikaapat na bagay sa array ay ang halaga ng paglilipat. Mayroong dalawang uri ng halaga, integer at bytearray. Kapag nakikitungo sa halagang ito, ang exchange ay dapat magbayad ng espesyal na pansin para sa mga transaksyon ng uri ng integer.

### Pag-query ng Balanse ng Gumagamit

Upang tanungin ang balanse ng user, kailangan ng palitan ang mga sumusunod:

1. Buuin ang mga file ng JSON upang magamit ang tatlong pamamaraan (`balanceOf`,` decimals`, at `simbolo`) sa pamamagitan ng PRC API invokefunction.
2. Ipadala ang mga file ng JSON sa NEO RPC server.
3. Kalkulahin ang balanse ng gumagamit ayon sa ibinalik na mga halaga.

#### invokefunction

Sa JSON, isang pangkalahatang kahilingan na humiling ng katawan ay nasa sumusunod na form:

```
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "script hash",
    "method name",
    [
      {
        "optional arguments"
      }
    ]
  ],
  "id": 1
}
```

Kailangan mong palitan ang mga string na ito kapag nag-query sa balanse ng gumagamit:

- script hash

  Ang script hash ng NEP-5 token na iyong hiniling. Halimbawa, maaari mong mahanap ang script na hash ng RPX ay:*0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9*.


- pangalan ng pamamaraan

  Ang pangalan ng pamamaraan na ginagamit mo. Upang tanungin ang balanse ng user, kailangan mong tawagan ang tatlong paraan na ito:
  
  **balanceOf**

  - Syntax: `public static BigInteger balanceOf(byte[] account)`
  - Remarks: "balanceOf" nagbabalik ang token na balanse ng '''account'''.

  **decimals**

  - Syntax: `public static byte decimals()`
  - Remarks: "decimals" nagbabalik ang bilang ng mga desimal na ginamit ng token.

  **symbol**

  - Syntax: `public static string symbol()`
  - Remarks: "symbol" nagbabalik ang simbolo ng token.

- opsyonal na argumento

 Opsyonal. Kung ang paraan na iyong ginagamit ay nangangailangan ng mga argumento, maaari mong ipasa ang mga ito sa pamamagitan ng pagtatayo ng mga parameter na ito sa isang array. Halimbawa, ang "balanceOf" sa NEP-5 ay nagbabalik ng token na balanse ng "account":
  `public static BigInteger balanceOf(byte[] account)`

Kaya kailangan mong ipasa ang account bilang argumento sa paraan ng "balanceOf".

#### Halimbawa

##### **Invoking balanceOf**

Ipagpalagay na ang address account ay AJShjraX4iMJjwVt8WYYzZyGvDMxw6Xfbe, kailangan mong i-convert ito sa uri ng Hash160 at buuin ang parameter na ito bila

```json
{
    "type": "Hash160",
    "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
}
```

Pagkatapos ay maaari mong buuin ang mensahe ng JSON bilang mga sumusunod:
Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
      }
    ]
  ],
  "id": 3
}
```

Pagkatapos maipadala ang kahilingan, makakakuha ka ng sumusunod na tugon:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00e1f505"
            }
        ]
    }
}
```

Nagbabalik ang "00e1f505" na maaaring ma-convert sa interger 100000000.

##### **Invoking decimals**

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "decimals", 
    []
    ],
  "id": 2
}
```

Pagkatapos maipadala ang kahilingan, makakakuha ka ng sumusunod na tugon:

```json
{
    "jsonrpc": "2.0",
    "id": 2,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.156",
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ]
    }
}
```

Nagbabalik ito ng integer 8.

##### **Invoking symbol**

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "symbol", 
    []
    ],
  "id": 1
}
```

Pagkatapos maipadala ang kahilingan, makakakuha ka ng sumusunod na tugon:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.141",
        "stack": [
            {
                "type": "ByteArray",
                "value": "525058"
            }
        ]
    }
}
```

Nagbabalik ang "525058" na maaaring ma-convert sa string na "RPX".

##### **Calculating the User Balance**

Ayon sa lahat ng ibinalik na mga halaga, maaari nating kalkulahin ang balanse ng gumagamit tulad ng sumusunod:
Ang balanse = 100000000/10 <sup> 8 </ sup> RPX = 1 RPX

### Pakikitungo sa mga Gumagamit ng mga widthrawal

Ang palitan ay maaaring pumili ng isa sa mga sumusunod na paraan upang magpadala ng mga NEP-5 asset sa mga gumagamit:

- Utos ng NEO-CLI: `send`

- RPC na paraan: `sendtoaddress`
- RPC na paraan: `sendmany`

#### NEO-CLI Command: magpadala

##### Syntax

`send <txid|script hash> <address> <value> [fee = 0]`

##### Mga Parameter

- txid|script hash: ang Id ng asset

- address: ang address ng pagbabayad.

- Halaga: ang halaga ng paglipat.

- fee: Maaaring iwanang walang laman ang parameter na ito. Ang default na halaga ay 0.


Pinapatunayan ng utos na ito ang password ng wallet.

##### Halimbawa

Upang ilipat ang 100 RPX sa address *AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b*, ipasok ang sumusunod:

```
send 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100
```

Kung kailangan mong magpadala ng global na asset, baguhin lamang ang unang parameter sa txid. Halimbawa,
Ang txid ng NEO: 0Xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b
Ang txid ng GAS: 0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

#### RPC Method: sendtoaddress

Ang susi "params" ay nagsasama ng isang array ng hindi bababa sa tatlong mga parameter.'

`"params":[script hash, address, amount, fee(optional), change address(optional)]`

Halimbawa, upang magpadala ng 1 RPX sa *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* ,bumuo ng isang JSON file bilang mga sumusunod at ipadala ito sa RPC server.

Request Body：

```json
{
    "jsonrpc":"2.0",
    "method":"sendtoaddress",
    "params":[
        "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
        "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg",
        "1",
        "0",
        "ARkJ8QcVdYL68WRvN3wj3TSvXX8CgmC73Z"
    ],
    "id":1
}
```

Pagkatapos maipadala ang kahilingan, makakakuha ka ng sumusunod na tugon:

```json
{
    "jsonrpc":"2.0",
    "id":1,
    "result":{
        "txid":"0xc6d4bf7c62fb47e0b2a6e838c3a1ca297622a1b1df7ceb2d30fa4ef8b7870700",
        "size":219,
        "type":"InvocationTransaction",
        "version":1,
        "attributes":[
            {
                "usage":"Script",
                "data":"5305fbbd4bd5a5e3e859b452b7897157eb20144f"
            }
        ],
        "vin":[

        ],
        "vout":[

        ],
        "sys_fee":"0",
        "net_fee":"0",
        "scripts":[
            {
                "invocation":"4054fbfca678737ae164ebf0e476da0c8215782bc42b67ae08cf4d8a716eeef81fcc17641e7f63893c3e685fb7eb1fb8516161c5257af41630f4508dde3afa3a8c",
                "verification":"210331d1feacd79b53aeeeeb9de56018eadcd07948675a50258f9e64a1204b5d58d1ac"
            }
        ],
        "script":"0400e1f50514d710f6f3f0bad2996a09a56d454cfc116a881bfd145305fbbd4bd5a5e3e859b452b7897157eb20144f53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166187b7883718089c8",
        "gas":"0"
    }
}
```

#### RPC Method: sendmany

Ang susi "params" ay nagsasama ng isang array ng hindi bababa sa isang parameter:

`"params":[[], fee(optional), change address(optional)]`

Halimbawa, upang magpadala ng 15.5 RPX at 0.0001 GAS sa *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg* at ang `change address` ay din *AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg*, maaari kang bumuo ng isang JSON file bilang mga sumusunod at ipadala ito sa RPC server.
Request Body：

```json
{
    "jsonrpc":"2.0",
    "method":"sendmany",
    "params":[
        [
            {
                "asset":"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
                "value":"15.5",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value":"0.0001",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],"0.00001","AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
    ],
    "id":1
}
```

Pagkatapos maipadala ang kahilingan, makakakuha ka ng sumusunod na tugon:
```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xe1351c9c9f2205a801d1b04f0df2d65fb4b1692d7d3b06cf41e0712fd1b12c9c",
        "size": 373,
        "type": "InvocationTransaction",
        "version": 1,
        "attributes": [
            {
                "usage": "Script",
                "data": "6d64dc9e50af8e911247436b264c8f7d791ad58c"
            }
        ],
        "vin": [
            {
                "txid": "0x9f0a28a912527604ab4b7d5e8b8d1a9b57631fcbab460132811ae7b6ed1ccaff",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.0001",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.01359",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0.00001",
        "scripts": [
            {
                "invocation": "40644ab915419dbf855a52d5c75596e80b78c8e928cc0ce91ae6afc3b75a0c31ee54efe1836f9ec232f6c42dcb3ace0bfdc688e626944fa20970a76064975eade9",
                "verification": "2103d4b6fc2d116855f86a483d151182f68e88e6ddd13f3f1f3631e36300aac122bfac"
            }
        ],
        "script": "04801f635c14d710f6f3f0bad2996a09a56d454cfc116a881bfd146d64dc9e50af8e911247436b264c8f7d791ad58c53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166f871fb30fc859b77",
        "gas": "0"
    }
}
```

### See Also

[NEP-5 Token Standard](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki "NEP5")

[Data Transformation Examples](https://github.com/PeterLinX/NeoDataTransformation)

## (Opsyonal) Ipamahagi ang GAS sa mga Gumagamit

Ang palitan ay maaaring matukoy kung ipamahagi ang GAS sa mga gumagamit. Ginagamit ang GAS para magbayad sa block block ng NEO para sa pagtatala at karagdagang mga serbisyo.

### Ano ang GAS ?

Ang NeoGas (dinaglat bilang GAS) ay kumakatawan sa karapatang gamitin ang Neo Blockchain. Magkakaroon ng 100 milyong GAS sa kabuuan. Ang mga gas ay binuo kasama ang bawat bagong block. Ang pagpapalabas ay magpapabagal ayon sa isang itinakdang hakbang na mabagal, habang ang GAS ay dumadaan sa isang proseso ng pagbuo upang lumago mula sa zero hanggang 100 milyon. Sa sandaling nakuha ang NEO, ang GAS ay mabubuo sa sistema ng pagsunod sa mga algorithm.

### Kinakalkula ang Magagamit na Halaga ng GAS

- Magagamit na *GAS = f(neo_amount, Δt_const)*
onst = t_end - t_start
    -  t_end = sa sandaling si Neo ay pumasok sa estado ng ginugol
    -  t_start = ang sandali na napupunta si Neo sa kalagayan ng walang kasiglahan

Ang Δt_const ay naayos na, kaya ang magagamit na Gas ay masyadong naayos. At ang halagang ito ay isang function ng halaga ng Neo na hawak ng gumagamit at ang tagal sa pagitan ng mga sandali na inilipat niya ang halaga na ito ng Neo papunta at sa kanyang address.


- Hindi magagamit *GAS = f(neo_amount, Δt_var)*

  - Δt_var = t - t_start
    - t is the current time
    - t_start = the moment that Neo goes into the state of unspent

Ang kasalukuyang oras ay isang variable, kaya ang halaga ng hindi magagamit na GAS ay lumalaki din sa pamamagitan ng oras, na nangangahulugang ito ay isang variable.

### Ipamahagi ang GAS sa mga Gumagamit

Ipagpalagay na ang lahat ng mga address ng exchange ay naka-imbak sa isang pitaka, ang sumusunod na tsart ay nagpapakita ng pamamaraan at computational formula kung paano ipinagkakaloob ng palitan ang GAS sa user A.

![gasflow_en](sc/assets/gasflow_en.png)

Ang mas maikli ang pagitan ng snapshot, mas tumpak ang pagkalkula. Kung ang pagitan ng snapshot ay hindi pare-pareho, gamitin ang timbang na average na paraan ng pagkalkula.

### Pag-claim ng GAS

Ang GAS ay maaaring maipahayag pagkatapos mailipat ng user ang kanyang NEO. Halimbawa, **someone has NEO in address A and GAS are not claimable, he transfer his NEO to himself (address A) then the NEO GAS are claimable.**

The following table lists the GAS claiming steps and corresponding commands.

| #    | Steps                                    | Command                                  |
| ---- | :--------------------------------------- | ---------------------------------------- |
| 1    | Run NEO-CLI                              | `./neo-cli.dll /rpc`                     |
| 2    | Check the client version                 | `version`                                |
| 3    | Check the synchronized height of the client ( Height: height/header height, Nodes: amount of connected nodes). | `show state`                             |
| 4    | Create a wallet                          | `create wallet /home/NeoNode/test.db3`   |
| 5    | Open the wallet created in the last step | `open wallet /home/NeoNode/test.db3`     |
| 6    | Check the address list in the wallet     | `list address`                           |
| 7    | Check the assets in the wallet           | `list asset`                             |
| 8    | Check the GAS balances details in the wallet | `show gas`                               |
| 9    | Transfer NEO to your address（e.g. AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1） to change the status of Gas to be claimable. | `send NEO AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 10   | Get the details of the balances of GAS in the wallet again. Now the status of all the GAS should be available to claim. | `show gas`                               |
| 11   | Claim GAS.                               | `claim gas`                              |
| 12   | Check balance again.                     | `list asset`                             |

