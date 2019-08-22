# Wallet

A wallet file, with the .json or .db3 extension, stores a reference to your NEO, GAS, and account information in a database. This file is very important and must be backed up securely.

> [!CAUTION]
>
> #### Caution
>
> Loss of either the wallet file or wallet password will result in the loss of your assets. Please ensure that the wallet file is securely stored and remember the wallet password.

## Creating the wallet database

1. Click `Wallet`, `New Wallet Database`.

   ![image](../../assets/gui_2.png)

2. Click `Browse` to select the wallet file storage location, and set the file name, and then click Save.

3. Enter `Password` and `Re-Password` and save your own password.

4. Click `OK` and the wallet is successfully created, which by default comes with a standard account. 


## Viewing the wallet information

### Account

Right-click on the account and select `View Private Key` to check the account information:

- Address: The equivalent of a bank account or bank card number, used to receive assets during transactions.

- Private key: A 256-bit random number, kept by the user and not known publicly. This represents the user account ownership and the ownership of the assets within the account.

- Public key: Each private key has a matching public key (Note: Public key, and private key information can be viewed by right clicking on the address.)

> [!CAUTION]
>
> #### Caution
>
> At no point should the private key be disclosed to others. Once the private key is disclosed, it may result in the loss of your assets.

You can also do the following operations by right-clicking an address of the account:

| Function          | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| Create New Add.   | Creates a new address in the wallet                          |
| Import            | `Import from WIF`: Imports the corresponding address into the wallet<br>`Import from Certificate:` Imports the certification <br>`Import Watch-Only Address`：After importing the address of the other party as the watch-only address, you can monitor the assets at that address. |
| Copy to Clipboard | Copies the address                                           |
| Delete            | Removes the address                                          |

### Assets

Clicking on the `Asset` tab you can view the assets of the account, including Assets (NEO, GAS, the user-created assets), type, balance, and the issuer.

### Transaction History

Clicking on the `Transaction History` tab you can view all the transaction records associated with the wallet.

## Opening the wallet database

1. Every time the client is re-opened, you need to click `open wallet database` to select which wallet file to open, as the picture shows:

   ![image](../../assets/gui_5.png)

2. Click `Browse` to select the wallet (usually the default is the last open wallet)

3. Select one of the file format to open: NEP-6 (.json) or SQLite (.db3)

   Clients earlier than Neo GUI v2.5.2 support only .db3 files.

4. Enter the password, and click `OK` to enter the wallet.

5. If opening an old .db3 wallet, you need to choose whether to upgrade the wallet to the new NEP-6 format according to the prompted message.

   After upgraded, the NEP-6 wallet can be shared among multiple clients, e.g. mobile, PC, or Web site. But it cannot be opened in the  clients earlier than Neo GUI v2.5.2.

## Changing password

You can modify the wallet password.

![image](../../assets/gui_6.png)

After changing the password, please remember to backup wallet again as any previous wallet backups will not contain the new password.

## Rebuild the wallet index

This option is used to restore errors in the client when an exception occurs. The Wallet Index may need to be rebuilt in the following cases:

- After the import of a private key.
- A transaction that has not been confirmed after a long time.
- The wallet assets show errors and blockchain data does not match.
- Switching between the main net and test net.

As the current block height is very high, rebuilding the wallet index can take several minutes. Please be patient.