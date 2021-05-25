# Wallet

The wallet is a database file of Neo-GUI used to store Neo account and asset information in the account. This file is very important and must be properly kept and safely backed up.

> [!CAUTION]
>
> Do not open or create a wallet on an insecure computer. Once the wallet file or wallet password is lost, it will cause the loss of your assets. So back up your wallet file securely, keep it safe, and remember your wallet password.

## Creating a wallet

1. In Neo-GUI main page click `Wallet` -> `New Wallet Database`.

2. Select the wallet file storage path, set the file name, and then click `Save`.

3. Enter `Password` and `Re-Password` and save your own password.

4. Click `OK` and the wallet is successfully created, which by default comes with a standard account.

> [!Warning]
>
> After the wallet is created, please back up the wallet file safely;
>
> It is not recommended to save your wallet files directly under the neo-gui root directory, or you may lose your wallet files when upgrading the software.

## Opening a wallet

1. In Neo-GUI main page click `Wallet` -> `Open Wallet Database`.
2. Select the wallet and enter the password. Click `OK` to open the wallet.

> [!Note]
>
> The wallets created in Neo Legacy cannot be opened in Neo3-GUI. To work around this issue you can import the wallet to Neo3-GUI through the private key.

## Importing a wallet

Neo-GUI supports importing wallets through the private key and encrypted private key. Importing  mnemonics will be supported in the future.

## Account operations

### Viewing account list

![](../assets/guiWallet.png)

After creating or opening the wallet, you will go to the account list page, which displays the following information:

- Account list: all account addresses in the wallet, and the number of NEO and GAS in each account.

- Asset list: all asset types and balance in the wallet, including NEO, GAS and other NEP-17 assets, etc.

  The GAS balance shows the amount of GAS claimed, and the Claim GAS button at the bottom of the page shows the amount of unclaimed GAS. To withdraw the GAS into the account, click the button.

Clicking on the account address you can enter a new page to view the private key or delete the address.


> [!CAUTION]
>
> At no point should the private key be disclosed to others. Once the private key is disclosed, it may result in the loss of your assets.

### Creating addresses

You can create both standard addresses and multi-signature addresses in a wallet account. A multi-signature address is a contract address composed of multiple public keys, requiring one or more parties to sign to transfer assets. For example, after building a private chain, you need to create a multi-signature address to claim NEO and GAS from the genesis block.

To create a standard address：

Click the `+` button beside Accounts and select `Create new address`.

To create a multi-signature address：

1. Click the `+` button beside Accounts and select `Create multi-signature address`.
2. In `Multi-signature pubkeys` field, select public keys or enter multiple public keys directly, and set `Minimum number of signatures`.
3. Click `Confirm`.

> [!Note]
>
> If you set multiple signature public keys, you must create the same multi-party signature address in all corresponding wallet accounts so that to successfully complete the signature of the transaction. For more information refer to [Signature](advanced.md).

The newly created address is displayed in the account list.

### Importing private key

You can import the account address corresponding to the private key into the current wallet. To do so, click the `+` button beside Accounts and select `Import private`.

## Viewing transaction list

You can view all transaction records related to the wallet by clicking the transaction list. This includes the confirmed transactions and the transactions that have just been initiated but have not yet been confirmed.

+ **Latest transaction**: Transactions already packaged on the blockchain by consensus nodes
+ **Unconfirmed transaction**: Transactions waiting to be packaged on the blockchain

## Transfer

In Neo-GUI, you can do multiple transfers at one time, or bulk transfers from a single address to multiple addresses.

1. In Neo-GUI click `Wallet` -> `Transfer`.
2. Do one of the following:
   - Single transfer: enter necessary transfer parameters.
   - Multiple transfers: click `Add transfer` to add transfer parameters for multiple addresses.
   - Bulk transfers: Click the `Bulk transfer` tab and then enter necessary parameters.
3. Click `Send`.

If the transfer transaction is initiated from a multi-signature address, you will receive a message prompting the signatures are not enough. Copy the information and proceed with the signature procedure to complete the transaction. For more information refer to  [Signature](advanced.md).

![](../assets/sign_1.png)

## Address book

The address book shows all the addresses in the current wallet.