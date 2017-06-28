# Client usage instructions

## Overview

### Introduction

The versions of Windows which are compatible with the client are: win7 sp1/win8/win10.

The client itself does not require any installation. Download and directly double-click AntSharesUI.exe to open the client. If there are any problems with the process, and the client cannot be used normally, please keep the client directory error.log file, and contact our technical staff to assist you in solving the problem.

> [!Note]
> Windows10 pre-version of the system requries installation [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### Synchronize

The client must be synchronized fully before use. That is, the client interface on both sides of the lower left corner, maintains the same value and the steady increase in speed.

![image](http://docs.antshares.org/images/gui/a.png)

### Glossary

#### wallet

A wallet file stores a reference to your AntShares, AntCoins, and account information in a database with .Db3 as the suffix name. This file is very important and requires a secure backup **.

> [!Important]
>
> Loss of either the wallet file or wallet password, will result in the loss of your assets. Please ensure that the wallet file is securely stored and remember the wallet password.

#### Account

This is used to track assets in an ANS block.

Account information includes: address, private key, public key, type.

(1) Address: The equivalent of a bank account or bank card number, used to receive assets during transactions.

(2) Type: AntShares.Wallets.SignatureContract Indicates that the address consists of a public key and is a 1-of-1 multi-signed address. AntShares.Wallets.MultiSigContract indicates that the address consists of multiple public keys and is a m-of-n multi-signature address, which is used for smart contracts.

(3) Private key: A 256-bit random number, kept by the user and not known publicly, represents the user account ownership and the ownership of the assets within the account.

(4) Public key: Each private key has a match with the public key (Note: public key, and private key information can be viewed by right clicking on the address.)

> [!Important]
>
> At no point should the private key be disclosed to others. Once the private key is leaked, it may result in the loss of your assets.

#### Assets

The assets of the account, asset information, including: assets (AntShares, AntCoins, the user created by the assets), type, balance, and the issuer.

#### Transaction Record

A record of all transaction information associated with the account.

#### Transfer

Transfer of assets to a recipent address. If the asset type is an Antshare, both partities are required to confirm with their signature. Other types of asset transfer can be condcuted without confirmation for both parties.

#### Trade

Carries out online asset exchange between two parties, where both parties have to confirm before succesful exchange of assets can occur.

#### Signature

Signing of information, is to signify confirmation of the information by the signer.
For transactions involving equity allocation and transfer of assets, the signature is required proof of consent by the parties involved.

#### Registered assets

Creating a new user-issued asset in the AntShares block. The user can define the type, name, total, etc of the asset and specify the administrator account of the asset. The creation of assets need to consume a certain amount of AntShares as an additional service fee, the current price is 10,000 AntCoins. (Test network fee is one percent of the main network)

#### Distribute assets

Within the upper limits of the total amount set by the asset creator, the asset is issued to the address specified by the issuer. Distribution of assets consumes a certain amount of small coins as an additional service fee, the current price is 500 AntCoins. (Test network fee is one percent of the main network)

#### Election

Those who want to be a AntShares accountant are required to register by election. Through the deposit of a certain amount of AntShares, the candidate accountant qualifications can be obtained. This function is not currently supported. Please wait for further updates.

#### Vote

The holders of  AntShares can vote on the candidate accountants and determine the creditors based on the voting results. This function is not currently supported. Please wait for further updates.

#### Broadcast

After signing, the transaction information is broadcasted to the entire network, where confirmaton by a node, completes the transaction. At the moment, this feature only appears in the signature.

#### Monitor address

After importing the address of the other party as the monitoring address, you will be able to view the assets at that address.

## Wallet
### Create the wallet database

(1) Click on the `wallet`, `create the wallet database`, pop-up `new wallet` page.

![image](http://docs.antshares.org/images/gui/b.png)

(2) Click `Browse` to select the wallet file storage location, and set the file name, and then click Save.

![image](http://docs.antshares.org/images/gui/c.png)

(3) Enter `password` and `repeat password 'and save your own password.

![image](http://docs.antshares.org/images/gui/d.png)

(4) Click `OK ', and the wallet will be successfully created, which will come with a standard account, by default. It should be noted that, due to the role of change mechanism, the remainder of the aseets will be transferred to the first address, by default. Thus, there is a need to back up the corresponding private key and wallet.

### Open the wallet database
(1) Everytime the client is re-opened, you will need to click `open wallet database` to select which wallet file to open, as the picture shows: 

![image](http://docs.antshares.org/images/gui/e.png)

(2) Click `Browse 'to select the wallet (usually the default is the last open wallet), enter the password, click OK to enter the wallet.
It should be noted that when the wallet displays an error, you can try to choose in the "repair mode" to open the wallet.

### Change Password

Can be used to modify the wallet password.

![image](http://docs.antshares.org/images/gui/f.png)

After changing the password, please remember to re-backup wallet, because the previous backup wallet password has not changed.

### Rebuild the wallet index

This option is used to restore errors in the client when an exception occurs. The Wallet Index may need to be rebuilt in the following cases:

1, After the import of private key.

2, A transaction that has not been confirmed after a long time.

3, The wallet assets show errors, and blockchain data does not match.

As the current block height is very high, rebuilding the wallet index takes about a minute or a few minutes. Please be patient.

### Restore the account

This option is used to restore the address of the wallet file that was accidentally deleted and its assets. It should be noted that it is generally not recommended to delete the operation within the client, to avoid loss of assets.

## Trade

### Transfer

#### Token Asset Transfer

(1) Click on the `transaction`, `transfer`, ```, and enter the transfer information.

![image](http://docs.antshares.org/images/gui/g.png)

(2) Click OK.

![image](http://docs.antshares.org/images/gui/h.png)

(3) Click OK, as shown:

![image](http://docs.antshares.org/images/gui/i.png)

#### Equity asset transfer

(1) Click on the `transaction`, `transfer`, ```, and enter the transfer information.

![image](http://docs.antshares.org/images/gui/j.png)

(2) Click OK.

![image](http://docs.antshares.org/images/gui/k.png)

(3) Click OK, as shown in the display, where more signatures are shown to be required:

![image](http://docs.antshares.org/images/gui/l.png)

(4) Signature function see [signature](# sign).

#### Batch transfer

This function is used to simplify the transfer of the same asset to a different addresses.

![image](http://docs.antshares.org/images/gui/m.png)

The data format is `address transfer amount '(separated by spaces).

![image](http://docs.antshares.org/images/gui/n.png)

It should be noted that the data format should be strictly in accordance with the above criteria, where extra spaces is likely to lead to transfer failure.

#### Remarks

This function is used to record the information of the transaction on the AntShares block-chain. Currently, [small block blockchain browser](https://www.antchain.xyz/) can be used to discover corresponding information for that transcation.

![image](http://docs.antshares.org/images/gui/o.png)

At the moment, there is no requirement for the message format.

![image](http://docs.antshares.org/images/gui/p.png)

The remarks for the transcation can be found on the broswer.

![image](http://docs.antshares.org/images/gui/Oo.png)

### Trade

#### Initiating a deal

(1) This transaction requires both parties to initiate a transaction request, in order to determine the asset details being sent to the corresponding recepient.

![image](http://docs.antshares.org/images/gui/Q.png)

(2) Click OK to generate the transaction request. We can use the transaction request, to obtain details on the terms sent by the corresponding party.

![image](http://docs.antshares.org/images/gui/R.png)

#### Merging of the deal

(1) After closing the initiated transaction request window, it will jump to the merge transaction request interface.

![image](http://docs.antshares.org/images/gui/S.png)

(2) This causes the other party's transcation request to be displayed on the interface. Click on verification, to verify the legitimacy of the other party's request. Depending the legitimacy of the request, one can either choose to accept or refuse.

![image](http://docs.antshares.org/images/gui/T.png)

(3) If you choose to accept, then the two sides need to sign and broadcast. For details, see [Signature](# sign). <a id="sign"> </a>

### Signature
(1) This causes the transcation sent by the other party to be pasted within the input box. Click on 'sign', and the output data will be generated. At the same time, the `broadcast ' button will be displayed.

![image](http://docs.antshares.org/images/gui/U.png)

(2) Click on `broadcast ', and the transaction will be sent. This deal is complete, when there is confirmation of the successful transaction. 

![image](http://docs.antshares.org/images/gui/V.png)

## Advanced

### Extractation of AntShares

AntCoins are generated with each new block, and will be recorded to the address of holders AntShares. (The number within the brackets of the balance of assets, is the number of AntCoins to be claimed) At any time, the AntShares stock holder can initiate a claim, to redeem these AntCoins to the corresponding address of the AntShares. At the moment, only the PC version of the client, has the ability to execute the function of extracting AntCoins.

The specific steps are:

(1) Transfer all the AntShares stocks within the wallet using a transfer operation. ( It is possible to send the AntShares straight to the current address) Once the claim for the AntCoins is settled, the AntCoins can be withdrawn. (Refer to the white paper for technical explanatin of this process).

(2) Click `````````````````````

![image](http://docs.antshares.org/images/gui/W.png)

### Request a certificate

Note that this feature can only generate a certificate application file, the user will still need to go to the relevant digital certificate authority to apply for a certificate.
Click `advance ', 'request certifcate', and fill in the request form according to the instructions given.

![image](http://docs.antshares.org/images/gui/X.png)

The generateed file will be as shown, in the following figure:

![image](http://docs.antshares.org/images/gui/y.png)

### Registered assets

There are two types of assets, Token and Share. Using Token as an example, fill in the following:

![image](http://docs.antshares.org/images/gui/Z.png)

It should be noted that the registeration of assets require a huge amount of fees. (The main network fee is 10000 AntCoins, test network fee is 100 AntShares coins) Please exercise caution.

### Distribute assets

![image](http://docs.antshares.org/images/gui/A1.png)

It should be noted that the distribution of assets require a huge amount of fees. (The main network fee is 500 AntShares coins, test network fee is 5 AntShares coins) Please exercise caution, and choose one-time distribution if possible. 

### Deploy Contract

To be added

### Invoke Contract

To be added

### Election

This function is used to register as a candidate for the AntShares block-chain book-kepper.

![image](http://docs.antshares.org/images/gui/B1.png)

It should be noted that the election requires a huge fee. (The main network fee is 1000 AntCoins, test network fee is 10 AntCoins) Please exercise caution. The book-keeper function is not availabe yet, please wait for further updates. 

### 4.8 Option

No content yet.

## Help

### View help

No content yet.

### Official website

Click will jump to the AntShares official website.

### Developers tools

To be added

### About AntShares

The version number of the AntShares client.
