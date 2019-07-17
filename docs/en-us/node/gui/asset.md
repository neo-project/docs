# Registering and Distributing Assets

## Registering assets

You can create a new asset type in the NEO blockchain, defining the type, name, total amount, and the administrator account of the asset. Currently creating an asset costs 4990 GAS as an additional service fee. 

There are two types of assets, Token and Share. Taking Token assets as an example, do the following to create the asset:

1. From NEO-GUI, click `Advanced` -> `Asset Registration`. Specify the following options and click `OK`：

   - Asset Type: Choose the asset type: Token or Share.  For share asset transfer, signature is required.

   - Name: The asset name. It will be displayed in the Asset page of neo-gui and the blockchain browser after the asset distributed. 

   - Capped: Check this option to set the maximum amount of the asset issued.

   - Precision: The minimum unit of the asset. The default is 8, indicating the minimum unit is 0.00000001. If it is 0, the minimum unit is 0.

   - Owner: The asset issuer.

   - Admin: An administrator can modify the asset name, the total amount and so on. The feature is not supported yet.

   - Issuer: The address of the asset to be distributed.

     ![image](../../assets/gui_43.png)

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

## Distributing assets

Within the upper limits of the total amount set by the asset creator, the asset can be issued to the address specified by the issuer. Distributing assets requires a certain amount of GAS to be used as an additional service fee, currently 1 Gas per time.

1. From NEO-GUI, click `Advanced` -> `Asset Distribution`.

2. Paste the transaction ID obtained in the last step of registering assets into `Asset ID`, the asset details is displayed automatically.

   If the transaction ID starts with "0x", you need to delete "0x" and enter it again.

3. Click `+` to enter the account address and the amount of assets to be distributed. Click `OK`.

   Once the distribution is complete, you can see the user-created assets is displayed in your wallet.

![image](../../assets/gui_46.png)