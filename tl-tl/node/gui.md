# Gamit ang NEO-GUI Client

> [!Tandaan]
>
>Maliban kung ito ay sinabi, ang artikulong ito ay ipinakikilala ang NEO-GUI na tumatakbo sa test net . Para sa karagdagang impormasyon, sumangguni sa [Test Network](testnet.md).

## Kinakailangan

### Pag-download ng kliyente

I-download ang [NEO-GUI](https://neo.org/download) at kunin ang mga file sa isang lokasyon na iyong pinili, pagkatapos ay i-double-click ang neo-gui.exe upang patakbuhin ang kliyente. Kung may anumang mga problema sa proseso at ang kliyente ay hindi maaaring gamitin kagaya ng normal, mangyaring panatilihin ang error.log file na matatagpuan sa parehong direktoryo ng neo-gui, pagkatapos ay makipag-ugnay sa aming mga teknikal na kawani upang tulungan ka sa paglutas ng problema.
> [!Tandaan]
>
> Ang NEO-GUI na kliyente ay tugma sa mga sumusunod na bersyon ng Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
>
> Kinakailangan ng mga pre-Windows 10 system ang [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework) upang mai-install.

### Pagsinkronisa ng datos ng blockchain

Ang kliyente ay dapat na ganap na nakasinkronisa bago gamitin. Ang data sa tabi ng "Height" y tumutugma sa taas ng wallet / naka-synchronize na taas ng blockchain/taas na blockchain header. Kapag binuksan mo ang isang wallet, ang  taas na data ng wallet ay ipinapakita. Regular na nag-uupdate ang mga numerong ito.

![imahe](/assets/gui_1.png)

Upang mapabilis ang pagsinkronisa ng network maaari mong i-download ang isang offline na pakete ng datos blockchain hanggang sa isang tiyak na taas ng block. Ang ibig sabihin nito ay kailangan lamang ng kliyente na isink ang mga karagdagang bloke mula sa NEO network kaysa sa buong blockchain.

1. Upang magsimula, i-download ang pakete na matatagpuan sa [Client Downloads](https://neo.org/download) na ayon sa iyong network: chain.acc.zip para sa pangunahing net o chain.acc.test.zip para sa test net..

2. Isara ang neo-gui na kliyente at kopyahin ang chain.acc.zip sa neo-gui na folder tulad ng ipinapakita sa pigura sa ibaba:

   ![](/assets/gui_58.png)

   > [!Tandaan]
   >
   > Para sa pakete ng test net na chain.acc.test.zip, kailangan mong palitan ang pangalan ng file sa chain.acc.zip bago ang 
pagkakalagay.
3. Buksan muli ang kliyente na neo-gui, maaari mong makita ang kliyente na ngayon ay nakasinkronisa hanggang sa tiyak na punto at ang kliyente ay ipagpapatuloy ang pagsisinkronisa sa natitirang bahagi ng blockchain.



Maaari mo ring gamitin ang NEO-CLI na utos na `export blocks` upang i-export angnakasinkronisang datos ng bloke sa isang pakete. Para sa karagdagang impormasyon,  tingnan ang  [CLI Command Reference](cli.md).

## Wallet
Ang isang wallet na file, kasama ang extension ng json o .db3, nag-iimbak ng reperensiya sa iyong NEO, GAS, at impormasyon ng account sa isang database. Ang file na ito ay napakahalaga at dapat na naka-back up nang ligtas.

> [!Mahalaga]
>
> Ang pagkawala ng alinman sa file ng wallet o password ng wallet ay magreresulta sa pagkawala ng iyong mga asset. Mangyaring siguraduhin na ang wallet file ay ligtas na nakatago at tandaan ang password ng wallet.

### Lumikha ng wallet ng database

1. I-klik ang `Wallet`, `New Wallet Database`.

   ![imahe](/assets/gui_2.png)

2.I-iklik ang `Browse` upang piliin ang lokasyon ng taguan ng file ng wallet, at itakda ang pangalan ng file, at pagkatapos ay i-click ang Save.
   ![imahe](/es-es/node/assets/gui/gui_3.png)

3. Ipasok ang `Password` and `Re-Password` at i-save ang iyong sariling password.

   ![imahe](/assets/gui_4.png)

4. I-klik ang `OK` at ang wallet ay matagumpay na nalikha, na kung saan ang defaultay may kasamang karaniwan na account.

   > [!Tandaan]
   >
   >Dahil sa papel ng pagbabago na mekanismo, ang natitira sa mga asset ay inililipat sa unang address bilang default. Kaya, Kinakailangan ang pag-back up ng kaukulang pribadong key at wallet.

### Tingnan ang impormasyon ng wallet

#### Account

I-right click ang wallet at piliin ang Account -> Tingnan ang Key upang suriin ang impormasyon ng account:

- Address: Ang katumbas ng isang account sa bangko o numero ng bank card, na ginagamit upang makatanggap ng mga asset sa panahon ng mga transaksyon.


- Pribadong key: Isang random na 256-bit na numero, tinatago ng gumagamit at hindi alam ng publiko. Ito ay kumakatawan sa pagmamay-ari ng account ng gumagamit at ang pagmamay-ari ng mga asset sa loob ng account.

-Pampublikong key: Ang bawat pribadong susi ay may katugmang pampublikong susi (Tandaan: Ang pampublikong susi, at ang pribadong susi ng pangunahing impormasyon ay maaaring makita sa pamamagitan ng pagright-click ng address.)

> [!Mahalaga]
>
>Hindi dapat ipaalam sa iba ang pribadong susi sa iba. Sa sandaling ibunyag ang pribadong key, maaaring magresulta ito sa pagkawala ng iyong mga ari-arian.

Maaari mo ring gawin ang mga sumusunod na operasyon sa pamamagitan ng pag-right click sa isang address ng account:

| Punksyon         |Paglalarawan                                        |
| ----------------- | ------------------------------------------------------------ |
| Lumikha ng Bagong Idadagdag.   | Lumilikha ng bagong address sa wallet                        |
| Angkat           | Angkat mula sa WIF: Ini-aangkat ang katumbas na address sa wallet <br> Mag-angkat mula sa Sertipiko: Ini-angkat ang sertipikasyon <br> Mag-angkat ng Address ng maaari mo nang: Matapos mag-angkat ng address ng kabilang partido bilang address ng watch-only maaari mong subaybayan ang mga ari-arian sa address na iyon. |
|Kopyahin sa clipboard | Kinokopya ang address                                 |
| Burahin         | Tinatanggal ang address                                         |

#### Mga ari-arian

Sa pagclick tab ng `Assets` maari mong tingnan ang mga ari-arian na account, kabilang ang Mga Asset (NEO, GAS,mga nilikhang ari-arian ng user), uri, balanse, at taga-isyu.

#### Rekord ng Transaksyon

Sa pagclick sa tab na `Transaction Record` maari mong tingnan ang lahat ng mga rekord ng transaksyon na nauugnay sa wallet.

### Buksan ang database ng wallet

1. Sa bawat oras na muling mabuksan ang kliyente, kailangan mong i-click ang  `open wallet database` upang piliin kung aling file ng wallet ang bubuksan, tulad ng ipinakita ng larawan:

   ![imahe](/assets/gui_5.png)

2. I-click ang `Browse` upang piliin ang wallet (kadalasan ang default ay ang huling bukas na wallet)

3. Pumili ng isa sa format ng file upang buksan: NEP-6 (.json) or SQLite (.db3)

  Mga kliyente na mas mauna kaysa Neo GUI v2.5.2 ay sumusuporta lamang ng .db3 na file.
  
4. Ipasok ang password, at i-klik ang `OK` upang makapasok sa wallet.

5. Kung magbubukas ng lumang wallet na db3,kailangan mong pumili kung i-upgrade ang wallet sa bagong format ng NEP-6 na ayon sa nasabing mensahe

   Pagkatapos na ma-upgrade, maibabahagi na wallet ng NEP-6 sa maraming kliyente, hal. mobile, PC, o Web site. Ngunit hindi ito mabubuksan sa mga kliyente nang mas nauna kaysa sa Neo GUI v2.5.2.


### Change password

Maaaring magamit upang baguhin ang password ng wallet.

![imahe](/assets/gui_6.png)

Pagkatapos na baguhin ang password, mangyaring tandaan na i-backup muli ang wallet bilang anumang nakaraang mga pag-backup ng wallet ay hindi maglalaman ng bagong password.

### Muling itayo ang index ng wallet

Ginagamit ang opsyong ito upang maibalik ang mga error sa kliyente kapag may eksepsiyon. Ang Index ng Wallet ay maaaring kailangang muling maitayo sa mga sumusunod na kaso:

- Matapos ang pag-import ng isang pribadong key.
- Isang transaksyon na hindi pa nakumpirma pagkatapos ng mahabang panahon.
- Ang mga asset ng wallet ay nagpakita ng mga error at hindi tumutugma ang data ng blockchain.
- Paglipat sa pagitan ng pangunahing net at net test.

Dahil napakataas ang bloke, ang muling pagtatayo ng index ng wallet ay maaaring tumagal nang ilang minuto. Mangyaring maging matiyaga.

## Mga transakyon

### Paglipat

Nililipat ang mga asset sa isang address ng tatanggap. Kung ang inilipat na uri ng asset ay equity, ang dalawang partido ay kinakailangang kumpirmahin sa kanilang sariling lagda.

1. Mula sa NEO-GUI, I-klik ang  `Transaction`-> `Transfer`

2. Gawin ang isa sa mga sumusunod:

   1. Upang mailipat sa isang solong address, i-klik ang `+` at ipasok ang impormasyon ng paglilipat, hal. uri ng asset, address ng tatanggap, at halaga.
   2. Upang mailipat sa isang grupo ng address, i-klik ang ![image](/assets/gui_icon.png) at ipasok ang mga pares ng address at halaga na pinaghihiwalay ng isang puwang, tulad ng ipinapakita sa ibaba:
   ![imahe](/assets/gui_15.png)

3. I-klik ang OK. Kung kailangan, i-klik ![image](/assets/gui_remark.png)  upang ipasok ang impormasyon na kaugnay sa transaksyon na maitatala sa block ng NEO.
4. I-double-check ang impormasyon sa paglilipat at pagkatapos ay i-klik ang OK.

   Para sa paglipat ng token ng pag-aari, ang transaksyon ay nakumpleto na ipinapakita ang ID ng transaksyon.
   ![image](/assets/txid.png)

  Para sa transfer ng pag-aari ng equity, kinakailangan ang mga lagda para sa pagkumpleto ng transaksyon. Kopyahin ang impormasyon ng transaksyon na lumilitaw at ipadala ito sa kabilang panig. Ang ibang partido ng transaksyon ay kailangang mag-sign at mag-broadcast sa NEO-GUI upang makumpleto ang transaksyon. Para sa karagdagang impormasyon, sumangguni sa [Signature](#Signature).

### Lagda

Ang Paglalagda ng impormasyon ay nagpapahiwatig ng kumpi..n ng impormasyon, ay upang ipahiwatig ang kumpirmasyon nng impormasyon sa lumagda
Para sa mga transaksyon na kinasasangkutan ng equity allocation at exchange asset, kinakailangan ang lagda bilang patunay ng pahintulot ng mga partido na sangkot.

1. Mula sa NEO-GUI, i-klik ang `Transaction` -> `Sign`,

2. I-paste ang impormasyon ng transaksyon na ipinadala ng ibang partido sa patlang ng input, at pagkatapos ay i-klik ang `sign`. Ang output data ay nabuo.

   Kasabay nito, ang pindutan ng  `broadcast` ay ipinapakita.

   ![image](/assets/signature.png)
 
3. I-klik ang `broadcast`. Ang transaksyon ay matagumpay na ipinadala at makukumpleto sa sandaling nakumpirma na ng NEO blockchain.

![image](/assets/gui_30.png)

### Palitan ng mga ari-arian

Ang isang online asset exchange sa pagitan ng dalawang partido ay nnangangailangan na ang parehong partido ang lumagda para sa transaksyon bago amangyari ang palitan ng mga asset ay maaaring mangyari. Halimbawa, ang isang pangkalahatang proseso ng pagpapalit ng asset sa pagitan ng mga partido ng transaksyon A at B ay:

1. Ang parehong partido ay nagsimula ng isang kahilingan na transaction at ipadala ang nabuong kahilingan sa bawat isa
2. Patunayan ang kahilingan na natanggap
3. Pagsamahin ang mga kahilingan na transaksyon mula sa parehong mga partido, bumuo ng mga lagda at ipadala ang mga ito sa bawat isa
4. Lumagda at ipahayag ang transaksyon.

#### Unang hakbang - Pagpapasimula ng isang kahilingan

Gawin ang mga operasyon na ginawa sa A side  bilang isang halimbawa:

1. Mula sa NEO-GUI, i-klik ang  `Transaction` -> `Transaction`.

2. Ilagay ang impormasyon ng ibang account ng partido at pagkatapos ay i-klik ang `+` upang ipasok ang asset upang maipadala.

3. I-klik ang `Initiate` upang makabuo ng kahilingan na transaksyon. kopyahin ang kahilinganna lilitaw at ipadala ito sa B. Pagkatapos i-klik ang `Close`.

   ![image](/assets/tranrequest.png)

4. Ang pahina ng kahilingan ng pagmemergee ay ipinapakita. Maghintay ng kahilingan na transaksyon na ipinadala mula sa B.

 Ang B ay gumaganap ng parehong mga operasyon at ipadala ang kahilingan sa A.

#### Pangalawang hakbang 2 - Pagsasama ng kahilingan

Gawin ang mga operasyon na ginawa sa A side bilang isang halimbawa:

1. Sa pahina ng kahilingan ngpagmemerge, i-paste ang kahilingan na ipinadala mula sa B sa patlang ng kahilingan ng kabilang partido. I-klik ang `Validate`.

   ![image](/assets/gui_20.png)

2. Patunayan ang impormasyon ng transaksyon. I-klik ang `Accept` kung walang isyu.

3. I-klik ang `Merge` upang pagsamahin ang mga kahilingan ng parehong partido at bumuo ng lagda.

4.Kopyahin ang impormasyon na lagda at ipadala ito sa B.

5. Ang B ay gumaganap ng parehong operasyon at ipapadala ang pirma sa A.

#### Pangatlong hakbang - Pag-sign at pagpapahayag ng transaksyon

Ang dalawangpanig ay lalagda at magpapahayag ng impormasyon sa transaksyon upang makumpleto ang proseso. Para sa karagdagang impormasyon, sumangguni sa [signature](#sign).

## Mga Advanced na Tampok

### Multi-party na naka-sign address

Ang nilagdaang address na may maraming partido ay isang kontratang address na nangangailangan ng isa o higit pang mga partido na lumagda sa panahon ng proseso ng transaksyon.
Para makalikha ng nilagdaang address na may maraming partido:

1. Mula sa NEO-GUI, i-right klik sa lugar ng account at piliin ang `Create Contract Address` -> `Multi-Signature`.

2. Sa listahan ng pampublikong key, ilagay ang mga pampublikong key na ginamit para sa pag-sign.

3. Tukuyin ang kaunting bilang ng mga lagda.

   ![image](/assets/multisign.png)

4. I-klik ang  OK.

Ang address ng kontrata ay nilikha at ipinapakita sa account page.

![image](/assets/multisign2.png)

### Pagkuha ng GAS

Ang GAS ay binuo sa bawat bagong bloke at ilalaan sa address ng mga may hawak ng NEO. (Ang numero sa loob ng mga braket ng balanse ng mga ari-arian ay ang bilang ng GAS na maaaring  matanggap) Sa anumang oras, ang tagapagtaguyod ng NEO ay maaaring magpasimula ng isang paghahabol na tubusin ang mga GAS na ito sa kaukulang address ng NEO. Sa sandaling ito, ang PC version lamang ng client ay may  punksyonalidad na kunin ang GAS.

Ang mga tiyak na hakbang ay:

1.Ilipat ang lahat ng NEO sa loob ng wallet gamit ang isang operasyon sa paglilipat. (Posibleng ipadala ang NEO diretso sa kasalukuyang address) Kapag ang pagtatanggap para sa GAS ay napagkasunduan, ang GAS ay maaaring maibalik. (Sumangguni sa puting papel para sa teknikal na paliwanag ng prosesong ito).
2.I-klik ang `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Humihiling ng sertipiko

Tandaan na ang tampok na ito ay maaari lamang bumuo ng isang application certificate file, ang gumagamit ay kailangan pa ring pumunta sa kaugnay digital na sertipiko upang ang sertipikato ng aplikasyon na file.
I-klik ang `Advanced`, `Request certificate`, at punan ang kahilingan ayon sa mga tagubilin na ibinigay.

![image](/assets/gui_39.png)

Ang nakabuo ng file ay magiging tulad ng ipinapakita sa sumusunod na figure:
![image](/zh-cn/node/assets/y.png)

### Pagrehistro ng mga asset

Maaari kang lumikha ng isang bagong uri ng asset sa NEO blockchain, pagtukoy sa uri, pangalan, kabuuang halaga, at administrator account ng asset. Sa kasalukuyan ay lumilikha ng isang gastos sa asset 4990 GAS bilang karagdagang bayad sa serbisyo.

Mayroong dalawang uri ng mga ari-arian, Token at Share. Sa pagkuha ng mga asset ng Token bilang isang halimbawa, gawin ang mga sumusunod upang lumikha ng  ari-arian:

1. Mula sa NEO-GUI, i-klik ang  `Advanced` -> `Asset Registration`. Tukuyin ang mga sumusunod na pagpipilian at i-klik ang `OK`：

   - Uri ng ari-arian :Piliin ang uri ng ari-arian: Token o Ibahagi. Para sa pagbabahagi ng transfer ng pag-aari, kinakailangan ang lagda.

   - Name: The asset name. Ipapakita ito sa pahina ng Asset ng neo-gui at browser ng blockchain pagkatapos maibahagi ang ari-arian.

   - Capped: Suriin ang pagpipiliang ito upang itakda ang pinakamataas na halaga ng ibinibigay na asset.
   - Precision: Ang minimum na yunit ng asset. Ang default ay 8, na nagpapahiwatig na ang pinakamaliit na yunit ay 0.00000001. Kung ito ay 0, ang minimum na yunit ay 0.

   - Owner:Ang issuer ng asset.

   - Admin: Ang isang administrator ay maaaring baguhin ang pangalan ng asset, ang kabuuang halaga at iba pa. Ang tampok ay hindi pa sinusuportahan.

   - Issuer: Ang address ng asset na ipamahagi.

     ![image](/assets/gui_43.png)

2. 
Ang pagpaparehistro ng mga asset ay ipinatutupad sa pamamagitan ng invoking ang smart contract. Sa pahina ng Kontrata ng Inimbitahan, i-klik ang `Test` . 

 
Makikita mo ang nararapat na bayad sa serbisyo ay ipinapakita sa kaliwang sulok sa ibaba ng pahina.

  Maaari mo ring i-load ang iyong mga lokal na matalinong mga file ng kontrata.

   > [!Tandaan]
   >
   > Ang pagpaparehistro ng mga ari-arian ay nakukuha ng isang makabuluhang bayad (Sa kasalukuyan ito ay 4990 Gas).


3.Kung sigurado kang magpatuloy, i-klik ang `Invoke`.

4. Kopyahin ang ID ng transaksyon na ibalik at i-paste ito sa Notepad para magamit sa ibang pagkakataon sa pamamahagi ng asset.

   > [!Tandaan]
   >
   > Kinakailangan ng humigit-kumulang 15 minuto upang magparehistro bago ka makakapag-distribute ng mga asset

### Pagbabahagi ng mga asset

Sa loob ng itaas na mga limitasyon ng kabuuang halaga na itinakda ng taga-gawa ng asset, ang asset ay maaaring maibigay sa address na tinukoy ng issuer. Ang paghahatid ng mga asset ay nangangailangan ng isang tiyak na halaga ng GAS na gagamitin bilang karagdagang bayad sa serbisyo, na kasalukuyang 1 Gas bawat oras.

1.Mula sa NEO-GUI, i-klik ang `Advanced` -> `Asset Distribution`.

2. Ilagay ang ID ng transaksyon na nakuha sa huling hakbang ng pagrehistro ng mga asset sa `Asset ID`, ang mga detalye ng asset ay awtomatikong ipinapakita.

   Kung ang ID ng transaksyon ay nagsisimula sa "0x", kailangan mong tanggalin ang "0x" at ipasok ito muli.
   
3. I-klik ang  `+` upang ipasok ang address ng account at ang halaga ng mga asset na ipamahagi. I-klik ang  `OK`.

  
Kapag nakumpleto na ang pamamahagi, makikita mo ang mga asset na nilikha ng user ay ipinapakita sa iyong wallet.

![image](/assets/gui_46.png)

### Mga NEP-5 Asset

Tinusuportahan ng client ng NEO-GUI ang mga transaksyon ng NEP-5 asset. Upang gumawa ng transaksyon ng asset na NEP-5, kailangan mo munang i-klik ang `Advanced` -> `Options` a client upang magdagdag ng isang hash ng script para sa asset ng NEP-5. Pagkatapos ay maaari mong piliin ang uri ng NEP-5 na asset para sa transfer ng pag-aari at mga transaksyon.
### Election

Ang function na ito ay ginagamit upang magrehistro bilang NEO blockchain validator kandidato.

![image](/assets/gui_57.png)

Dapat pansinin na ang eleksyon ay may malaking halaga. (Ang pangunahing bayad sa network ay 1000 GAS, ang bayad sa network na pagsubok ay 10 GAS) Mangyaring mag-ingat. Hindi pa available ang function ng validator, mangyaring maghintay para sa higit pang mga update.
