# Client usage instructions

## Overview

### Introduction

The neo-gui client is compatible with the following versions of Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.

The client itself does not require any installation. Download and extract the files to a location of your choice, then double-click neo-gui.exe to open the client. If there are any problems with the process and the client cannot be used normally, please keep the error.log file located in the same directory as neo-gui, then contact our technical staff to assist you in solving the problem.

> [!Note]
> Windows10 pre-version of the system requires installation [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### Synchronize

The client must be fully synchronized before use. The bottom left hand corner indicates the number of blocks synchronized and the total number of blocks in the network (see example below).  These numbers will update regularly.

![image](/assets/gui_1.png)

### Glossary

#### Wallet

A wallet file stores a reference to your NEO, GAS, and account information in a database with .db3 extension. This file is very important and must be backed up securely.

> [!Important]
>
> Loss of either the wallet file or wallet password will result in the loss of your assets. Please ensure that the wallet file is securely stored and remember the wallet password.

#### Account

This is used to track assets in a NEO block.

Account information includes: Address, private key, public key, type.

(1) Address: The equivalent of a bank account or bank card number, used to receive assets during transactions.

(2) Type: Neo.Wallets.SignatureContract Indicates that the address consists of a public key and is a 1-of-1 multi-signed address. Neo.Wallets.MultiSigContract indicates that the address consists of multiple public keys and is a m-of-n multi-signature address, which is used for smart contracts.

(3) Private key: A 256-bit random number, kept by the user and not known publicly. This represents the user account ownership and the ownership of the assets within the account.

(4) Public key: Each private key has a matching public key (Note: Public key, and private key information can be viewed by right clicking on the address.)

> [!Important]
>
> At no point should the private key be disclosed to others. Once the private key is disclosed, it may result in the loss of your assets.

#### Assets

The assets of the account, asset information, including: Assets (NEO, GAS, the user created by the assets), type, balance, and the issuer.

#### Transaction Record

A record of all transaction information associated with the account.

#### Transfer

Transfer of assets to a recipient address. If the asset type is NEO, both parties are required to confirm with their signature. Other types of asset transfer can be conducted without confirmation for both parties.

#### Trade

Carries out online asset exchange between two parties, where both parties have to confirm before the successful exchange of assets can occur.

#### Signature

Signing of information, is to signify confirmation of the information by the signer.
For transactions involving equity allocation and transfer of assets, the signature is required as proof of consent by the parties involved.

#### Registered assets

Creating a new user-issued asset in the NEO block. The user can define the type, name, total, etc. of the asset and specify the administrator account of the asset. The creation of assets need to consume a certain amount of NEO as an additional service fee, the current price is 10,000 GAS. (Test network fee is one percent of the main network)

#### Distribute assets

Within the upper limits of the total amount set by the asset creator, the asset is issued to the address specified by the issuer. Distribution of assets consumes a certain amount of small coins as an additional service fee, the current price is 500 GAS. (Test network fee is one percent of the main network)

#### Election

Those who want to be a NEO validator are required to register by election. Through the deposit of a certain amount of NEO, validator qualifications may be obtained. This function is not currently supported. Please wait for further updates.

#### Vote

Holders of NEO can vote on the validator candidates and this voting mechanism will determine if a validator is selected. This function is not currently supported. Please wait for further updates.

#### Broadcast

After signing, the transaction information is broadcasted to the entire network, where confirmation by a node, completes the transaction. At the moment, this feature only appears in the signature.

#### Monitor address

After importing the address of the other party as the monitoring address, you will be able to view the assets at that address.

## Wallet
### Create the wallet database

(1) Click on the `wallet`, `create the wallet database`, pop-up `new wallet` page.

![image](/assets/gui_2.png)

(2) Click `Browse` to select the wallet file storage location, and set the file name, and then click Save.

![image](/es-es/node/assets/gui/gui_3.png)

(3) Enter `password` and `repeat password` and save your own password.

![image](/assets/gui_4.png)

(4) Click `OK` and the wallet will be successfully created, which by default will come with a standard account. It should be noted that due to the role of change mechanism, the remainder of the assets will be transferred to the first address by default. Thus, there is a need to back up the corresponding private key and wallet.

### Open the wallet database
(1) Every time the client is re-opened, you will need to click `open wallet database` to select which wallet file to open, as the picture shows:

![image](/assets/gui_5.png)

(2) Click `Browse 'to select the wallet (usually the default is the last open wallet), enter the password, click `OK` to enter the wallet.
It should be noted that when the wallet displays an error, you can try to choose "repair mode" to open the wallet.

### Change Password

Can be used to modify the wallet password.

![image](/assets/gui_6.png)

After changing the password, please remember to backup wallet again as any previous wallet backups will not contain the new password.

### Rebuild the wallet index

This option is used to restore errors in the client when an exception occurs. The Wallet Index may need to be rebuilt in the following cases:

1. After the import of a private key.

2. A transaction that has not been confirmed after a long time.

3. The wallet assets show errors and blockchain data does not match.

As the current block height is very high, rebuilding the wallet index can take several minutes. Please be patient.

### Restore the account

This option is used to restore the address of the wallet file that was accidentally deleted and its assets. It should be noted that it is generally not recommended to delete the operation within the client, to avoid loss of assets.

## Trade

### Transfer

#### Token Asset Transfer

(1) Click on the `transaction`, `transfer`, `+`, and enter the transfer information.

![image](/assets/gui_10.png)

(2) Click OK.

![image](/assets/gui_11.png)

(3) Click OK.

![image](/zh-cn/node/assets/i.png)

#### Equity asset transfer

(1) Click on the `transaction`, `transfer`, `+`, and enter the transfer information.

![image](/zh-cn/node/assets/j.png)

(2) Click OK.

![image](/zh-cn/node/assets/k.png)

(3) Click OK, as shown in the display, where more signatures are shown to be required:

![image](/zh-cn/node/assets/l.png)

(4) Signature function see [signature](#sign).

#### Batch transfer

This function is used to simplify the transfer of the same asset to a different addresses.

![image](/assets/gui_14.png)

The data format is `address transfer amount` (separated by spaces).

![image](/assets/gui_15.png)

It should be noted that the data format should be entered in accordance with the above criteria as extra spaces are likely to lead to transfer failure.

#### Remarks

This function is used to record the information of the transaction on the NEO block-chain. The [NEO blockchain browser](https://www.antchain.xyz/) can be used to locate transaction information.

![image](/zh-cn/node/assets/o.png)

At the moment there is no requirement for the message format.

![image](/zh-cn/node/assets/p.png)

The remarks for the transaction can be found on the [NEO blockchain browser](https://www.antchain.xyz/)

![image](/zh-cn/node/assets/oo.png)

### Trade

#### Initiating a deal

(1) This transaction requires both parties to initiate a transaction request in order to determine the asset details being sent to the corresponding recipient.

![image](/assets/gui_18.png)

(2) Click OK to generate the transaction request. We can use the transaction request to obtain details on the terms sent by the corresponding party.

![image](/assets/gui_19.png)

#### Merging of the deal

(1) After closing the initiated transaction request window you will be shown the merge transaction request interface.

![image](/assets/gui_20.png)

(2) This causes the other party's transaction request to be displayed. To verify the legitimacy of the other party's request, click verify. Depending the legitimacy of the request, one can either choose to accept or refuse.

![image](/assets/gui_24.png)

(3) If you choose to accept then the two sides need to sign and broadcast. For details, see [Signature](#sign). <a id="sign"> </a>

### Signature
(1) This causes the transaction sent by the other party to be pasted within the input box. Click on `sign`, and the output data will be generated. At the same time, the `broadcast` button will be displayed.

![image](/zh-cn/node/assets/u.png)

(2) Click on `broadcast`, and the transaction will be sent. This transaction is now complete and a transaction ID (TXID) will be shown once the transaction is successful.

![image](/assets/gui_30.png)

<a  id="offline"></a>

## Advanced

### Download Synchronize data offline

In order to speed up network synchronzation you can download a copy of the blockchain up to a certain blockheight.  This means the client will only need to sync the additional blocks from the NEO network rather than the entire blockchain.

**Download**

To begin, download the file located at [https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

**Add**

Close the neo-gui client and open chain.acc.zip.  Extract the chain.acc file in the neo-gui folder as shown in the figure below:

![](/assets/gui_58.png)

**Sync**

After re-opening the neo-gui client you will see that the client is now synchronized up to a certain point and the client will now continue synchronizing the rest of the blockchain. As shown in the figure below:  

![](/assets/gui_59.png)

**Complete**

When synchronized to a certain point, the file (chain.acc) will be deleted and synchronization from the NEO network will continue. As shown in the figure below:

![](/assets/gui_60.png)





### Extraction of GAS

GAS is generated with each new block and will be allocated to the address of NEO holders. (The number within the brackets of the balance of assets is the number of GAS that can be claimed) At any time, the NEO holder can initiate a claim to redeem these GAS to the corresponding address of the NEO. At the moment, only the PC version of the client has the functionality to extract GAS.

The specific steps are:

(1) Transfer all the NEO within the wallet using a transfer operation. (It is possible to send the NEO straight to the current address) Once the claim for the GAS is settled, the GAS can be withdrawn. (Refer to the white paper for technical explanation of this process).

(2) Click `Advanced`, `Claim GAS`, `Claim All`.

![image](/assets/gui_37.png)

### Request a certificate

Note that this feature can only generate a certificate application file, the user will still need to go to the relevant digital certificate authority to apply for a certificate.
Click `Advanced`, `Request certificate`, and fill in the request form according to the instructions given.

![image](/assets/gui_39.png)

The generated file will be as shown in the following figure:

![image](/zh-cn/node/assets/y.png)

### Registered assets

There are two types of assets, Token and Share. Using Token as an example, fill in the following:

![image](/assets/gui_43.png)

It should be noted that the registration of assets incurs a significant fee. (The main network fee is 10000 GAS, test network fee is 100 NEO coins) Please exercise caution.

### Distribute assets

![image](/assets/gui_46.png)

It should be noted that the distribution of assets incurs a significant fee. (The main network fee is 500 NEO coins, test network fee is 5 NEO coins) Please exercise caution, and choose one-time distribution if possible.

### Deploy Contract

To be added

### Invoke Contract

To be added

### Election

This function is used to register as a NEO blockchain validator candidate.

![image](/assets/gui_57.png)

It should be noted that the election incurs a significant fee. (The main network fee is 1000 GAS, test network fee is 10 GAS) Please exercise caution. The validator function is not available yet, please wait for further updates.

### 4.8 Option

No content yet.

## Help

### View help

No content yet.

### Official website

The official NEO website is located at: https://neo.org/

### Developers tools

To be added

### About NEO

The version number of the NEO client.
