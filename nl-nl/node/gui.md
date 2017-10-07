# Instructies voor Gebruik van de Client

## Overzicht

### Introductie

De Neo-GUI client is compatible met de volgende versies van Windows: Windows 7 (Service Pack 1) / Windows 8 / Windows 10.

De client zelf heeft geen installatie nodig. Download de zip, pak deze uit en dubbelklik op neo-gui.exe om de client te openen. Wanneer hierbij problemen zijn en de client niet normaal kan worden gebruikt, bewaar dan het error.log bestand, welke zich in dezelfde map bevindt als neo-gui, en stuur deze naar ons technisch personeel voor hulp.

> [!Opmerking]
> Bij de voorloperversie van Windows 10 dient [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework) te worden geïnstalleerd.

### Synchroniseren

De client moet volledig gesynchroniseerd zijn voordat deze gebruikt kan worden. Linksonderin is te zien hoeveel blocks zijn gesynchroniseerd en hoeveel blocks er in totaal in het netwerk zijn (zie het voorbeeld hieronder). Deze nummers zullen regelmatig oplopen.

![image](/assets/gui_1.png)

### Verklarende Woordenlijst

#### Wallet

Een wallet-bestand bewaart een verwijzing naar de NEO, het GAS en de account-informatie in een database met een .db3-extensie. Dit bestand is zeer belangrijk; een goede backup wordt aanbevolen.

> [!Belangrijk]
>
> Het verliezen van het wallet-bestand of -wachtwoord zal resulteren in verlies van de bijbehorende assets. Sla het wallet-bestand veilig op en onthoud het wachtwoord!

#### Account

Dit wordt gebruikt om de assets in een NEO-block bij te houden.

De account-informatie bevat: adress, private key, public key, type.

(1) Address: vergelijkbaar met het nummer van een bankrekening of credit card. Dit wordt gebruikt om assets te ontvangen tijdens transacties.

(2) Type: *Neo.Wallets.SignatureContract* geeft aan dat het adres bestaat uit een enkele public key en werkt als een '1-van-de-1' multi-signed adres. *Neo.Wallets.MultiSigContract* geeft aan dat het adres bestaat uit meerdere public keys en werkt als een 'm-van-de-n' multi-signature adres, welke gebruikt wordt bij smart contracts.

(3) Private key (*persoonlijke sleutel*): een 256-bit willekeurig getal, welke bewaard wordt door de gebruiker en niet openbaar bekend moet worden gemaakt. Dit vertegenwoordigt bezit van de account en de bijbehorende assets binnen de account.

(4) Public key (*openbare sleutel*): elke private key heeft een bijbehorende public key. De private en public keys kunnen worden gezien door met de rechter muisknop op het adres te klikken in de Neo-GUI.

> [!Belangrijk]
>
> De private key dient nooit bekend te worden gemaakt aan anderen. Wanneer dit wel wordt gedaan, kan dit resulteren in verlies van assets.

#### Assets

De assets van de account en de asset-informatie, waaronder: de naam (NEO, GAS of een asset gecreëerd door de gebruiker), het type, het saldo en de verstrekker.

#### Transaction Record

Registratie van alle transactie-informatie die met de account wordt geassocieerd.

#### Transfer

Het sturen van assets naar een ontvangend adres. Als het asset-type NEO is, dienen beide partijen de transactie te verifiëren met hun handtekening (*signature*). Assets van andere types kunnen worden uitgevoerd zonder dat verificatie van beide partijen nodig is.

#### Trade

Het uitwisselen van online assets tussen twee partijen, waarbij beide partijen de uitwisseling moeten verifiëren voordat deze kan plaatsvinden.

#### Signature

Het ondertekenen van informatie. Dit geeft aan dat de informatie wordt geverifiëerd door de gebruiker.
Voor transacties waarbij billijkheid (*equity allocation*) en het overdragen van assets een rol spelen, is de signature vereist als bewijs dat de partijen bewust akkoord zijn met de transactie.

#### Registered assets

Het creëren van een nieuwe, door een gebruiker aangevraagde asset binnen het NEO-block. De gebruiker kan het type, de naam en andere eigenschappen van de asset definiëren, en aangeven welke account de administrator van de asset is. De aanmaak van assets vereist betaling van een bepaalde hoeveelheid GAS als aanvullende servicekosten; de huidige prijs is 10.000 GAS (op het testnetwerk is dit honderd maal zo weinig als op het hoofdnetwerk).

#### Distribute assets

De aangemaakte asset wordt gedistribueerd naar een adres, aangegeven door de verstrekker. Dit aantal moet binnen de bovenste grens van de totale hoeveelheid van de asset zijn, welke is aangegeven door de maker van de asset. Het distribueren van assets vereist een betaling van aanvullende servicekosten; de huidige prijs is 500 GAS (ook hierbij is dit op het testnetwerk honderd maal minder). 

#### Election

Wanneer iemand een NEO-validator wil zijn, moet deze worden aangesteld door middel van een verkiezing. Door een bepaalde hoeveelheid NEO te storten, kunnen aan de validator-eisen worden voldaan. Deze functie is nog niet geïmplementeerd; wacht hiervoor op verdere updates.

#### Vote

Bezitters van NEO kunnen stemmen op een validator-kandidaat naar keuze. Op deze manier wordt bepaald of een validator geaccepteerd wordt. Deze functie is nog niet geïmplementeerd; wacht hiervoor op verdere updates.

#### Broadcast

Na het tekenen van een transactie, wordt deze verzonden naar het gehele netwerk (*'to broadcast' = uitzenden), waarbij bevestiging nodig is van een node voordat de transactie wordt voltooid. Op dit moment is deze functie alleen aanwezig in de signature.

#### Monitor address

Het is mogelijk een adres van een andere partij te importeren, waarna het mogelijk is de assets van dat adres te zien.

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
