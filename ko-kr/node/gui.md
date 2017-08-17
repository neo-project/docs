# 클라이언트 사용법 설명서 (Client usage instructions)

## 개요

### 소개

이 클라이언트와 호환되는 윈도우 버전은 다음과 같습니다 : Win7 sp1 / Win8 / Win10.

이 클라이언트는 설치과정이 필요 없습니다. 다운로드 받아 neo-gui.exe를 더블 클릭해서 실행시키면 됩니다. 이 과정 중에 문제가 생기면 클라이언트를 정상적으로 실행시킬 수 없습니다. 이 경우 클라이언트 디렉토리의 error.log 파일을 보관하시고 저희 기술진에 연락하셔서 문제를 푸시기 바랍니다. 

> [!주의]
> 이전 버전의 윈도우10의 경우 다음 파일을 설치하셔야 합니다. [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### 싱크하기

클라이언트 사용 전에 반드시 전체 싱크가 되어야 합니다. 클라이언트 왼쪽 하단 부분에 있는 숫자가 블록의 싱크 상태를 나타냅니다. 앞/뒤가 같아져야 합니다.

![image](http://docs.neo.org/images/gui/a.png)

### 용어집(Glossary)

#### 지갑(Wallet)

지갑 파일엔 여러분의 NEO, GAS에 대한 참고 값과 계정 정보가 *.db3 파일 형태로 저장됩니다. 이 파일은 매우 중요하기 때문에 백업을 반드시 하시기 바랍니다.  

> [!중요]
>
> 지갑 파일과 지갑 패스워드를 잃어버릴 경우, 여러분의 자산을 찾을 수 없습니다. 때문에 지갑 파일과 패스워드는 반드시 안전하게 보관하시길 바랍니다.

#### 계정 (Account)

이는 네오 블록에서 자산의 추적에 쓰입니다. 

계정 정보에는 다음과 같은 것들이 포함됩니다 : 주소, 프라이빗 키, 퍼블릭 키, 타입(type)

(1) 주소: 은행 계정이나 은행 카드의 번호와 같은 개념이며, 자산을 받을 때 사용됩니다.

(2) 타입: Neo.Wallets.SignatureContract(네오.지갑.서명.계약) 은 주소가 하나의 퍼블릭 키와 1of1 다중 서명 주소로 구성 되어있음을 나타냅니다. Neo.Wallets.MultiSigContract (네오.지갑,다중서명 계약)은 주소가 여러 개의 퍼블릭 키와 m of n 의 다중 서명 주소로 구성 되었음을 나타내며 이는 스마트 계약에 사용됩니다.

(3) 프라이빗 키(Private key): 256비트의 난수로 구성되어 있으며, 사용자가 보관하고 외부로 알려지면 안됩니다. 이 키는 사용자 계정과 그 계정내의 자산의 소유권을 대표합니다.

(4) 퍼블릭 키 : 각각의 프라이빗 키는 짝을 이루는 퍼블릭 키가 있습니다. (주 : 퍼블릭 키와 프라이빗 키는 계정(account)을 오른쪽 클릭하면 화면에 표시됩니다.)


> [!중요]
> 그 어떤 경우에도 프라이빗 키가 다른 사람에게 공개되면 안됩니다. 만약 그렇게 되면 자산을 잃어버릴 수 있습니다.

#### 자산(Assets)

계정 내의 자산과 자산 정보가 있으며 다음을 포함합니다 : 자산 (NEO, GAS, 사용자가 만든 자산), 타입, 잔액 과 발행인.

#### 전송 기록 (Transaction Record)

계정과 관련된 모든 전송 기록입니다.

#### 이전(Transfer)

자산을 수신인 주소로 이전합니다. 이전되는 자산이 NEO인 경우 양쪽 다 서명이 필요합니다. 다란 형태의 자산은 양쪽의 서명 없이 이전됩니다.

#### 거래(Trade)

자산 교환이 일어나기 전에 양자간 확인 있으면 온라인 자산 거래가 수행됩니다.

#### 서명(Signature)

서명자에 의한 정보의 서명. 
전송은 재산의 배분과 자산의 이전을 포함하기 때문에, 양자간 동의의 증거로써 서명이 사용됩니다.

#### 등록된 자산 (Registered assets)

네오 블록체인 내에 사용자가 발행한 자산을 생성할 수 있습니다. 사용자는 자산의 형태, 이름, 총량을 정의할 수 있고 해당 자산의 관리자 계정을 설정할 수 있습니다. 이런 자산을 만든 때는 수수료로 일정양의 NEO를 소모되며, 현재 가격은 10,000GAS입니다. (테스트 네트워크 요금은 메인 네트워크 요금의 1%입니다)

#### Distribute assets

Within the upper limits of the total amount set by the asset creator, the asset is issued to the address specified by the issuer. Distribution of assets consumes a certain amount of small coins as an additional service fee, the current price is 500 GAS. (Test network fee is one percent of the main network)

#### Election

Those who want to be a NEO validator are required to register by election. Through the deposit of a certain amount of NEO, the validator qualifications can be obtained. This function is not currently supported. Please wait for further updates.

#### Vote

The holders of NEO can vote on the validator candidates and determine the validator based on the voting results. This function is not currently supported. Please wait for further updates.

#### Broadcast

After signing, the transaction information is broadcasted to the entire network, where confirmation by a node, completes the transaction. At the moment, this feature only appears in the signature.

#### Monitor address

After importing the address of the other party as the monitoring address, you will be able to view the assets at that address.

## Wallet
### Create the wallet database

(1) Click on the `wallet`, `create the wallet database`, pop-up `new wallet` page.

![image](http://docs.neo.org/images/gui/b.png)

(2) Click `Browse` to select the wallet file storage location, and set the file name, and then click Save.

![image](http://docs.neo.org/images/gui/c.png)

(3) Enter `password` and `repeat password` and save your own password.

![image](http://docs.neo.org/images/gui/d.png)

(4) Click `OK`, and the wallet will be successfully created, which will come with a standard account, by default. It should be noted that, due to the role of change mechanism, the remainder of the assets will be transferred to the first address, by default. Thus, there is a need to back up the corresponding private key and wallet.

### Open the wallet database
(1) Every time the client is re-opened, you will need to click `open wallet database` to select which wallet file to open, as the picture shows:

![image](http://docs.neo.org/images/gui/e.png)

(2) Click `Browse 'to select the wallet (usually the default is the last open wallet), enter the password, click `OK` to enter the wallet.
It should be noted that when the wallet displays an error, you can try to choose in the "repair mode" to open the wallet.

### Change Password

Can be used to modify the wallet password.

![image](http://docs.neo.org/images/gui/f.png)

After changing the password, please remember to re-backup wallet, because the previous backup wallet password has not changed.

### Rebuild the wallet index

This option is used to restore errors in the client when an exception occurs. The Wallet Index may need to be rebuilt in the following cases:

1. After the import of private key.

2. A transaction that has not been confirmed after a long time.

3. The wallet assets show errors, and blockchain data does not match.

As the current block height is very high, rebuilding the wallet index takes about a minute or a few minutes. Please be patient.

### Restore the account

This option is used to restore the address of the wallet file that was accidentally deleted and its assets. It should be noted that it is generally not recommended to delete the operation within the client, to avoid loss of assets.

## Trade

### Transfer

#### Token Asset Transfer

(1) Click on the `transaction`, `transfer`, `+`, and enter the transfer information.

![image](http://docs.neo.org/images/gui/g.png)

(2) Click OK.

![image](http://docs.neo.org/images/gui/h.png)

(3) Click OK, as shown:

![image](http://docs.neo.org/images/gui/i.png)

#### Equity asset transfer

(1) Click on the `transaction`, `transfer`, `+`, and enter the transfer information.

![image](http://docs.neo.org/images/gui/j.png)

(2) Click OK.

![image](http://docs.neo.org/images/gui/k.png)

(3) Click OK, as shown in the display, where more signatures are shown to be required:

![image](http://docs.neo.org/images/gui/l.png)

(4) Signature function see [signature](#sign).

#### Batch transfer

This function is used to simplify the transfer of the same asset to a different addresses.

![image](http://docs.neo.org/images/gui/m.png)

The data format is `address transfer amount` (separated by spaces).

![image](http://docs.neo.org/images/gui/n.png)

It should be noted that the data format should be strictly in accordance with the above criteria, where extra spaces is likely to lead to transfer failure.

#### Remarks

This function is used to record the information of the transaction on the NEO block-chain. Currently, [NEO blockchain browser](https://www.antchain.xyz/) can be used to discover corresponding information for that transaction.

![image](http://docs.neo.org/images/gui/o.png)

At the moment, there is no requirement for the message format.

![image](http://docs.neo.org/images/gui/p.png)

The remarks for the transaction can be found on the browser.

![image](http://docs.neo.org/images/gui/Oo.png)

### Trade

#### Initiating a deal

(1) This transaction requires both parties to initiate a transaction request, in order to determine the asset details being sent to the corresponding recipient.

![image](http://docs.neo.org/images/gui/Q.png)

(2) Click OK to generate the transaction request. We can use the transaction request, to obtain details on the terms sent by the corresponding party.

![image](http://docs.neo.org/images/gui/R.png)

#### Merging of the deal

(1) After closing the initiated transaction request window, it will jump to the merge transaction request interface.

![image](http://docs.neo.org/images/gui/S.png)

(2) This causes the other party's transaction request to be displayed on the interface. Click on verification, to verify the legitimacy of the other party's request. Depending the legitimacy of the request, one can either choose to accept or refuse.

![image](http://docs.neo.org/images/gui/T.png)

(3) If you choose to accept, then the two sides need to sign and broadcast. For details, see [Signature](#sign). <a id="sign"> </a>

### Signature
(1) This causes the transaction sent by the other party to be pasted within the input box. Click on `sign`, and the output data will be generated. At the same time, the `broadcast` button will be displayed.

![image](http://docs.neo.org/images/gui/U.png)

(2) Click on `broadcast`, and the transaction will be sent. This deal is complete, when there is confirmation of the successful transaction.

![image](http://docs.neo.org/images/gui/V.png)

<a  id="offline"></a>

## Advanced

### Offline synchronous packet

**Download**

You can download it here [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

When you enter the URL, you will download a packet like this. ![](~/images/gui/2017-07-04_11-59-35.png)

**Add**

Unzip the packet and put it in the folder, as shown in the figure below:

![](~/images/gui/2017-07-04_12-06-35.png)

**Sync**

Open the client, and you will see that the client is in sync with the super fast speed. As shown in the figure below:  

![](~/images/gui/2017-07-04_12-07-35.png)

**Complete**

When synchronized to a certain degree, the file (chain.acc) will disappear and the synchronization speed will slow down. As shown in the figure below:

![](~/images/gui/2017-07-04_12-08-35.png)





### Extractation of GAS

GAS are generated with each new block, and will be recorded to the address of NEO holders. (The number within the brackets of the balance of assets, is the number of GAS to be claimed) At any time, the NEO holder can initiate a claim, to redeem these GAS to the corresponding address of the NEO. At the moment, only the PC version of the client, has the ability to execute the function of extracting GAS.

The specific steps are:

(1) Transfer all the NEO within the wallet using a transfer operation. ( It is possible to send the NEO straight to the current address) Once the claim for the GAS is settled, the GAS can be withdrawn. (Refer to the white paper for technical explanation of this process).

(2) Click `Advanced`, `Claim GAS`, `Claim All`.

![image](http://docs.neo.org/images/gui/W.png)

### Request a certificate

Note that this feature can only generate a certificate application file, the user will still need to go to the relevant digital certificate authority to apply for a certificate.
Click `Advanced`, `Request certificate`, and fill in the request form according to the instructions given.

![image](http://docs.neo.org/images/gui/X.png)

The generated file will be as shown, in the following figure:

![image](http://docs.neo.org/images/gui/y.png)

### Registered assets

There are two types of assets, Token and Share. Using Token as an example, fill in the following:

![image](http://docs.neo.org/images/gui/Z.png)

It should be noted that the registration of assets require a huge amount of fees. (The main network fee is 10000 GAS, test network fee is 100 NEO coins) Please exercise caution.

### Distribute assets

![image](http://docs.neo.org/images/gui/A1.png)

It should be noted that the distribution of assets require a huge amount of fees. (The main network fee is 500 NEO coins, test network fee is 5 NEO coins) Please exercise caution, and choose one-time distribution if possible.

### Deploy Contract

To be added

### Invoke Contract

To be added

### Election

This function is used to register as a candidate for the NEO blockchain validator.

![image](http://docs.neo.org/images/gui/B1.png)

It should be noted that the election requires a huge fee. (The main network fee is 1000 GAS, test network fee is 10 GAS) Please exercise caution. The validator function is not available yet, please wait for further updates.

### 4.8 Option

No content yet.

## Help

### View help

No content yet.

### Official website

Click will jump to the NEO official website.

### Developers tools

To be added

### About NEO

The version number of the NEO client.
