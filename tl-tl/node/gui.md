# Gamit ang NEO-GUI Client

> [!Tandaan]
>
> Maliban kung ito'y nakalagay, ipinakilala ng artikulong ito ang NEO-GUI na tumatakbo sa test net . Para sa karagdagang impormasyon, sumangguni sa [Test Network](testnet.md).

## Kinakailangan

### Pag-download ng kliyente

I-download ang [NEO-GUI](https://neo.org/download) at kunin ang mga file sa isang lokasyon na iyong pinili, pagkatapos ay i-double-click ang neo-gui.exe upang patakbuhin ang kliyente. Kung may anumang mga problema sa proseso at ang kliyente ay hindi maaaring gamitin nang normal, mangyaring panatilihin ang error.log file na matatagpuan sa parehong direktoryo ng neo-gui, pagkatapos makipag-ugnay sa aming mga teknikal na kawani upang tulungan ka sa paglutas ng problema.
> [!Tandaan]
>
> Ang NEO-GUI client ay tugma sa mga sumusunod na bersyon ng Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.
>
> Kinakailangan ng mga pre-Windows 10 system ang [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework) upang mai-install.

### Pag-synchronize ng blockchain data

Ang kliyente ay dapat na ganap na naka-synchronize bago gamitin. Ang data sa tabi ng "Height" y tumutugma sa taas ng wallet / naka-synchronize na taas ng blockchain / taas na blockchain header. Kapag binuksan mo ang isang wallet, ang  taas na data ng wallet ay ipinapakita. Regular na ina-update ang mga numerong ito.

![imahe](/assets/gui_1.png)

Upang mapabilis ang pag-synchronize ng network maaari mong i-download ang isang offline na pakete ng data blockchain hanggang sa isang tiyak na taas ng block. Ang ibig sabihin nito ay kailangan lamang ng kliyente na i-sync ang mga karagdagang bloke mula sa NEO network kaysa sa buong blockchain.

1. Upang magsimula, i-download ang pakete na matatagpuan sa [Client Downloads](https://neo.org/download) na ayon sa iyong network: : chain.acc.zip para sa pangunahing net o  chain.acc.test.zip para sa test net..

2. Isara ang neo-gui client at kopyahin chain.acc.zip sa neo-gui folder tulad ng ipinapakita sa figure sa ibaba:

   ![](/assets/gui_58.png)

   > [!Tandaan]
   >
   > Para sa test net package chain.acc.test.zip, kailangan mong palitan ang pangalan ng file sa chain.acc.zip bago ang 
pagkakalagay.
3. Buksan muli ang neo-gui client, maaari mong makita ang kliyente na ngayon ay naka-synchronize hanggang sa tiyak na punto at ang client ay ipagpapatuloy ang pag-synchronize sa natitirang bahagi ng blockchain.



Maaari mo ring gamitin ang NEO-CLI command na `export blocks` upang i-export ang naka-synchronize na data ng block sa isang pakete. Para sa karagdagang impormasyon, tingnan ang  [CLI Command Reference](cli.md).

## Wallet
Ang isang wallet na file, kasama ang extension ng json o .db3, nag-iimbak ng sanggunian sa iyong NEO, GAS, at impormasyon ng account sa isang database. Ang file na ito ay napakahalaga at dapat na naka-back up nang ito'y ligtas.

> [!Mahalaga]
>
> Ang pagkawala ng alinman sa wallet na file o password ng wallet ay magreresulta sa pagkawala ng iyong mga asset. Mangyaring siguraduhin na ang wallet file ay ligtas na nakaimbak at tandaan ang password ng pitaka.

### Lumikha ng wallet ng database

1. I-klik ang `Wallet`, `New Wallet Database`.

   ![imahe](/assets/gui_2.png)

2.I-iklik ang `Browse` upang piliin ang lokasyon ng imbakan ng wallet file, at itakda ang pangalan ng file, at pagkatapos ay i-click ang I-save.
   ![imahe](/es-es/node/assets/gui/gui_3.png)

3. Ipasok ang `Password` and `Re-Password` at i-save ang iyong sariling password.

   ![imahe](/assets/gui_4.png)

4. I-klik ang `OK` at ang wallet ay matagumpay na nalikha, na kung saan ang default ay may isang karaniwang account.

   > [!Tandaan]
   >
   >Dahil sa papel ng mekanismo ng pagbabago, ang natitira sa mga asset ay inililipat sa unang address bilang default. Kaya, kailangan ang pag-back up ng kaukulang pribadong key at wallet.

### Tingnan ang impormasyon ng wallet

#### Account

I-klik ang kanan ng wallet at piliin ang Account -> Tingnan ang Key upang suriin ang impormasyon ng account:

- Address: Ang katumbas ng isang bank account o numero ng bank card, na ginagamit upang makatanggap ng mga asset sa panahon ng mga transaksyon.


- Private key: Isang random na numero ng 256-bit, itinatago ng gumagamit at hindi kilala sa publiko. Ito ay kumakatawan sa pagmamay-ari ng user account at ang pagmamay-ari ng mga asset sa loob ng account.

- Public key: Ang bawat pribadong susi ay may katugmang pampublikong susi (Tandaan: Ang pampublikong susi, at ang pribadong susi ng pangunahing impormasyon ay maaaring makita sa pamamagitan ng pag-click sa kanan ng address.)

> [!Mahalaga]
>
>Hindi dapat ituro ang pribadong susi sa iba. Sa sandaling ibunyag ang pribadong key, maaaring magresulta ito sa pagkawala ng iyong mga ari-arian.

Maaari mo ring gawin ang mga sumusunod na operasyon sa pamamagitan ng pag-right click sa isang address ng account:

| Function          |Paglalarawan                                        |
| ----------------- | ------------------------------------------------------------ |
| Lumikha ng Bagong Idadagdag.   | Lumilikha ng bagong address sa wallet                        |
| Angakat           | Import from WIF: Ini-angkat ang katumbas na address sa wallet <br> Mag-angkat mula sa Sertipiko: Ini-angkat ang sertipikasyon <br> Mag-angkat ng Address ng Watch-Only: Matapos mag-angkat ng address ng kabilang partido bilang address ng watch-only maaari mong subaybayan ang mga asset sa address na iyon. |
|Kopyahin sa clipboard | Kinokopya ang address                                 |
| Burahin         | Tinatanggal ang address                                         |

#### Mga asset

Ang pag-click sa tab ng `Assets` maaari mong tingnan ang mga asset ng account, kabilang ang Mga Asset (NEO, GAS, mga nilikha ng user na asset), uri, balanse, at ang issuer.

#### Rekord ng Transaksyon

Ang pag-click sa tab na `Transaction Record` maaari mong tingnan ang lahat ng mga rekord ng transaksyon na nauugnay sa wallet.

### Buksan ang database ng wallet

1. Sa bawat oras na muling buksan ang kliyente, kailangan mong i-click ang  `open wallet database` upang piliin kung aling file ng wallet ang bubuksan, tulad ng ipinakita ng larawan:

   ![imahe](/assets/gui_5.png)

2. I-click ang `Browse` upang piliin ang wallet (kadalasan ang default ay ang huling bukas na wallet)

3. Pumili ng isa sa format ng file upang buksan: NEP-6 (.json) or SQLite (.db3)

  Mga kliyente na mas mauna kaysa Neo GUI v2.5.2 suporta lamang .db3 file.
  
4. Ipasok ang password, at i-klik ang `OK` upang makapasok sa wallet.

5. Kung magbubukas ng lumang wallet na dd3, kailangan mong piliin kung na-upgrade ang wallet sa bagong format ng NEP-6 ayon sa naipong mensahe.

   Pagkatapos na ma-upgrade, maibabahagi ang wallet ng NEP-6 sa maraming kliyente, hal. mobile, PC, o Web site. Ngunit hindi ito mabubuksan sa mga kliyente nang mas nauna kaysa sa Neo GUI v2.5.2.


### Palitan ang password

Maaaring magamit upang baguhin ang password ng pitaka.

![imahe](/assets/gui_6.png)

Pagkatapos na baguhin ang password, mangyaring tandaan na i-back up muli ang wallet bilang anumang nakaraang mga pag-backup ng wallet ay hindi maglalaman ng bagong password.

### Muling itayo ang index ng wallet

Ginagamit ang opsyong ito upang maibalik ang mga error sa client kapag may eksepsiyon. Ang Index ng Wallet ay maaaring kailangang muling itayo sa mga sumusunod na kaso:

- Matapos ang pag-import ng isang pribadong key.
- Isang transaksyon na hindi pa nakumpirma pagkatapos ng mahabang panahon.
- Ang mga asset ng wallet ay nagpapakita ng mga error at hindi tumutugma ang data ng blockchain.
- Paglipat sa pagitan ng pangunahing net at net test.

Tulad ng kasalukuyang block height ay napakatass, muling pagtatayo ng index ng wallet ay maaaring tumagal nang ilang minuto. Mangyaring maging matiyaga.

## Transaksyon

### Ilipat

Ilipat ang mga asset sa isang tatanggap na address. Kung ang inilipat na uri ng asset ay equity, ang dalawang partido ay kinakailangang kumpirmahin sa kanilang pirma.

1. Mula sa NEO-GUI, I-klik ang  `Transaction`-> `Transfer`

2. Gawin ang isa sa mga sumusunod:

   1. Upang ilipat sa isang solong address, i-klik ang `+` at ipasok ang impormasyon ng paglilipat, hal. uri ng asset, address ng tatanggap, at halaga.
   2. Upang ilipat sa isang address ng mga batch, i-klik ang ! ![image](/assets/gui_icon.png) at ipasok ang mga pares ng address at halaga na pinaghihiwalay ng isang puwang, tulad ng ipinapakita sa ibaba:
   ![imahe](/assets/gui_15.png)

3. I-klik ang OK. Kung kailangan, i-klik ![image](/assets/gui_remark.png)  upang ipasok ang impormasyon sa kaugnay na transaksyon na maitatala sa block block ng NEO.
4. I-double-check ang impormasyon sa paglilipat at pagkatapos ay i-klik ang OK.

   Para sa paglipat ng token ng pag-aari, ang transaksyon ay nakumpleto na ipinapakita ang ID ng transaksyon.
   ![image](/assets/txid.png)

  Para sa transfer ng pag-aari ng equity, kinakailangan ang mga lagda para sa pagkumpleto ng transaksyon. Kopyahin ang impormasyon ng transaksyon na lumilitaw at ipadala ito sa kabilang panig. Ang ibang partido ng transaksyon ay kailangang mag-sign at mag-broadcast sa NEO-GUI upang makumpleto ang transaksyon. Para sa karagdagang impormasyon, sumangguni sa [Signature](#Signature).

### Lagda

Ang pag-sign ng impormasyon, ay upang ipahiwatig ang kumpirmasyon ng impormasyon sa pamamagitan ng tagaparka.
Para sa mga transaksyon na kinasasangkutan ng equity allocation at exchange asset, kinakailangan ang pirma bilang patunay ng pahintulot ng mga partido na kasangkot.

1. Mula sa NEO-GUI, i-klik ang `Transaction` -> `Sign`,

2. Ilagay ang impormasyon ng transaksyon na ipinadala ng ibang partido sa patlang ng input, at pagkatapos ay i-klik ang `sign`. Ang output data ay nabuo.

   Kasabay nito, ang pindutan ng  `broadcast` ay ipinapakita.

   ![image](/assets/signature.png)

3. I-klik  `broadcast`. Ang transaksyon ay matagumpay na ipinadala at makukumpleto sa sandaling nakumpirma ng NEO blockchain.

![image](/assets/gui_30.png)

### Mga Palitan ng Asset

Ang isang online asset exchange sa pagitan ng dalawang partido ay nangangailangan ng parehong partido na mag-sign para sa transaksyon bago ang matagumpay na palitan ng mga asset ay maaaring mangyari. Halimbawa, ang isang pangkalahatang proseso ng pagpapalit ng asset sa pagitan ng mga partido ng transaksyon A at B ay:

1. Ang parehong mga partido ay nagsimula ng isang kahilingan sa transaksyon at ipinapadala ang nabuong kahilingan sa bawat isa
2. I-verify ang kahilingan na natanggap
3. Pagsamahin ang mga kahilingan sa transaksyon mula sa parehong mga partido, bumuo ng mga lagda at ipadala ang mga ito sa bawat isa
4. Mag-sign at i-broadcast ang transaksyon.

#### Hakbang 1 - Pagpapasimula ng isang kahilingan

Gawin ang mga operasyon na ginawa sa A side  bilang isang halimbawa:

1. FMula sa NEO-GUI, i-klik ang  `Transaction` -> `Transaction`.

2.Ilagay ang impormasyon ng account ng iba pang partido at pagkatapos ay i-click ang `+` upang ipasok ang asset upang maipadala.

3. I-klik ang `Initiate` upang makabuo ng kahilingan sa transaksyon. Abutin ang kahilingan na lilitaw at ipadala ito sa B. Pagkatapos i-klik ang `Close`.

   ![image](/assets/tranrequest.png)

4. Ang pahina ng kahilingan ng merge ay ipinapakita. Maghintay ng kahilingan ng transaksyon na ipinadala mula sa B.

 Ang B ay gumaganap ng parehong mga operasyon at ipadala ang kahilingan sa A.

#### Hakbang 2 - Pagsasama ng kahilingan

Gawin ang mga operasyon na ginawa sa A side bilang isang halimbawa:

1. Sa pahina ng kahilingan ng merge, i-paste ang kahilingan na ipinadala mula sa B sa patlang ng kahilingan ng counterparty. I-klik ang `Validate`.

   ![image](/assets/gui_20.png)

2. Patunayan ang impormasyon ng transaksyon. I-klik ang `Accept` kung walang isyu.

3. I-click ang `Merge` upang pagsamahin ang mga kahilingan ng parehong partido at bumuo ng lagda.

4.Kopyahin ang signature information at ipadala ito sa B.

5. Ang B ay gumaganap ng parehong operasyon at ipapadala ang pirma sa A.

#### Hakbang 3 - Pag-sign at pagbro-broadcast ng transaksyon

Ang dalawang panig ay nag-sign at nag-broadcast ng impormasyon sa transaksyon upang makumpleto ang proseso. Para sa karagdagang impormasyon, sumangguni sa [signature](#sign).

## Mga Advanced na Tampok

### Multi-party na naka-sign address

Ang naka-sign na address ng multi-party ay isang address ng kontrata na nangangailangan ng isa o higit pang mga partido na mag-sign sa panahon ng proseso ng transaksyon.

Upang lumikha ng isang naka-sign na address ng multi-party:

1. Mula sa NEO-GUI, i-right klik sa lugar ng account at piliin ang `Create Contract Address` -> `Multi-Signature`.

2. Sa listahan ng pampublikong key, ilagay ang mga pampublikong key na ginamit para sa pag-sign.

3. Tukuyin ang kaunting bilang ng mga lagda.

   ![image](/assets/multisign.png)

4. I-klik ang  OK.

Ang address ng kontrata ay nilikha at ipinapakita sa account page.

![image](/assets/multisign2.png)

### Pag-claim ng GAS

Ang GAS ay binuo sa bawat bagong block at ilalaan sa address ng mga may hawak ng NEO. (Ang numero sa loob ng mga braket ng balanse ng mga ari-arian ay ang bilang ng GAS na maaaring ma-claim) Sa anumang oras, ang tagapagtaguyod ng NEO ay maaaring magpasimula ng isang paghahabol na tubusin ang mga GAS na ito sa kaukulang address ng NEO. Sa sandaling ito, ang PC version lamang ng client ay may functionality na kunin ang GAS.

Ang mga tiyak na hakbang ay:

1.Ilipat ang lahat ng NEO sa loob ng wallet gamit ang isang operasyon sa paglilipat. (Posibleng ipadala ang NEO diretso sa kasalukuyang address) Kapag ang pag-claim para sa GAS ay napagkasunduan, ang GAS ay maaaring maibalik. (Sumangguni sa puting papel para sa teknikal na paliwanag ng prosesong ito).
2.I-klik ang `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Humihiling ng sertipiko

Tandaan na ang tampok na ito ay maaari lamang bumuo ng isang application certificate file, ang gumagamit ay kailangan pa ring pumunta sa may-katuturang digital na sertipiko ng sertipiko upang mag-aplay para sa isang sertipiko.
I-klik ang `Advanced`, `Request certificate`, at punan ang kahilingan ayon sa mga tagubilin na ibinigay.

![image](/assets/gui_39.png)

Ang nakabuo ng file ay magiging tulad ng ipinapakita sa sumusunod na figure:
![image](/zh-cn/node/assets/y.png)

### Pagrehistro ng mga asset

Maaari kang lumikha ng isang bagong uri ng asset sa NEO blockchain, pagtukoy sa uri, pangalan, kabuuang halaga, at administrator account ng asset. Sa kasalukuyan ay lumilikha ng isang gastos sa asset 4990 GAS bilang karagdagang bayad sa serbisyo.
There are two types of assets, Token and Share. Taking Token assets as an example, do the following to create the asset:

1. Mula sa NEO-GUI, i-klik ang  `Advanced` -> `Asset Registration`. Tukuyin ang mga sumusunod na pagpipilian at i-klik ang ` `OK`：

   - Asset Type: Choose the asset type: Token or Share.  For share asset transfer, signature is required.

   - Name: The asset name. It will be displayed in the Asset page of neo-gui and the blockchain browser after the asset distributed. 

   - Capped: Check this option to set the maximum amount of the asset issued.

   - Precision: The minimum unit of the asset. The default is 8, indicating the minimum unit is 0.00000001. If it is 0, the minimum unit is 0.

   - Owner: The asset issuer.

   - Admin: An administrator can modify the asset name, the total amount and so on. The feature is not supported yet.

   - Issuer: The address of the asset to be distributed.

     ![image](/assets/gui_43.png)

2. Assets registration is implemented by invoking the smart contract. In the Invoke Contract page, click `Test` . 

   You can see the corresponding service fee is shown up in the lower-left corner of the page.

   You can also load your local smart contract files.

   > [!Note]
   >
   > The assets registration incurs a significant fee (Currently it is 4990 Gas) .


3. If you are sure to continue, click `Invoke`.

4. Copy the transaction ID returned and paste it into Notepad for later use in asset distribution.

   > [!Note]
   >
   > It takes about 15 minutes to register before you can distribute assets.

### Distributing assets

Within the upper limits of the total amount set by the asset creator, the asset can be issued to the address specified by the issuer. Distributing assets requires a certain amount of GAS to be used as an additional service fee, currently 1 Gas per time.

1. From NEO-GUI, click `Advanced` -> `Asset Distribution`.

2. Paste the transaction ID obtained in the last step of registering assets into `Asset ID`, the asset details is displayed automatically.

   If the transaction ID starts with "0x", you need to delete "0x" and enter it again.

3. Click `+` to enter the account address and the amount of assets to be distributed. Click `OK`.

   Once the distribution is complete, you can see the user-created assets is displayed in your wallet.

![image](/assets/gui_46.png)

### NEP-5 Assets

The NEO-GUI client supports NEP-5 assets transactions. To make a NEP-5 asset transaction, you first need to click `Advanced` -> `Options` in the client to add a script hashes for the NEP-5 asset. Then you can select the NEP-5 asset type for asset transfer and exchange transactions.

### Election

This function is used to register as a NEO blockchain validator candidate.

![image](/assets/gui_57.png)

It should be noted that the election incurs a significant fee. (The main network fee is 1000 GAS, test network fee is 10 GAS) Please exercise caution. The validator function is not available yet, please wait for further updates.
