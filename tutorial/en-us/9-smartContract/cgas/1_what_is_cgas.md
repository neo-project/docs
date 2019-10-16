# What is CGAS

CGAS is a NEP-5 compatible contract asset and is issued by NGD (NEO Global Development). CGAS can be exchanged in proportion 1:1 for GAS and can be exchanged back. The purpose of the contract is to map the GAS to the global assets, so that the global asset GAS can be easily circulated inside the contract and support the transfer invoked through smart contract utilization.

Why issue CGAS?

Because many DApps project parties on NEO have a demand to use a digital asset with strong liquidity and relatively stable price is used in the contract. However, it is not possible to transfer global assets (such as NEO or GAS) in smart contracts by the fact that NEO and GAS tokens can’t be actually exchanged through smart contract operations out of security reasons. Furthermore, if the project side itself issues a NEP-5 token, it may have poor liquidity. It is a high cost for the project side to get the needed recognition of the community, or a listing on an exchange market, and it is also a waste for all projects to issue their own NEP-5 assets. Therefore, NGD is strongly recommended by the community to issue a universal NEO-5 asset anchored with NEO or GAS for the use within the community, hence the birth of CNEO and CGAS.


How does CGAS map global assets?

In CGAS, the global assets are exchanged and refunded through methods mintTokens and refund, without the acceptance of a centralized institution, and it’s completely decentralized. mintTokens is similar to the Token Sale for many projects, with the exchange of global assets and contract assets in proportion 1:1 within the method. In refund method, a UTXO is marked to a specified user in advance, and then the user can initiate a transfer transaction to get the asset back to his address. More details can be found in GitHub. This design concept is proposed and implemented in open source by the NEL team, for which we are grateful.

What does C in CGAS mean?

C actually stands for “Contract”.

Why should NGD develop CGAS since there are already community contract assets that can map global assets within the network?

The need for CGAS and CNEO becomes obvious consequently with revealing the fact that not all contract assets made by the community can be trusted, or may not even have an open source nature. On the other hand, CGAS developed by NGD is open source and completely decentralized that can be fortunately used for any type of projects without any restrictions.

## Technology Introduction

Methods in the NEP-5 specification:

| Method        | Parameters                               | Return | Description                                                         |
| ----------- | ---------------------------------- | ------ | ------------------------------------------------------------ |
| balanceOf   | byte[] account                     | int    | Get the CGAS balance of an account and return the real value * 10⁸             |
| decimals    | ---                                | int    | Get the CGAS precision, and return the constant value `8`                             |
| name        | ---                                | string | Get the contract name, and return the constant value `NEP5 GAS`                        |
| symbol      | ---                                | string | Get the contract symbol, and return the constant value `CGAS`                            |
| totalSupply | ---                                | int    | Get the total circulation of CGAS, and return the real value * 10⁸. Since CGAS and GAS are exchanged in proportion 1:1, the amount of GAS in the contract address is equal to the total circulation of CGAS |
| transfer    | byte[] from, byte[] to, int amount | bool   | This method is to transfer CGAS from sender's (from) account to receiver's (to) account  with a transfer amount (amount). from and to is in format of Script Hash and amount is the real transfer amount *10⁸. This method supports both user invocation and contract invocation. |

To allow the interchange of GAS and CFAS, the contract offers several methods in addition to the methods in the NEP-5 specification:

| Method               | Parameters         | Return                                      | Description                                                         |
| ------------------ | ----------- | ------------------------------------------- | ------------------------------------------------------------ |
| getRefundTarget    | byte[] txId | byte[]                                      | Get the refunder of a UTXO, parameter is the transaction ID in UTXO (a UTXO is completely determined by the txId and output index, where the output index is 0 by default). Return the refunder of the UTXO, who can take the UTXO as the transaction input and take GAS from the CGAS address. |
| getTxInfo          | byte[] txId | [TransferInfo](NeoContract/TransferInfo.cs) | Get the detailed transfer information for a transaction ID and TxInfo can be recorded in the following four cases below: mintTokens, Refund, transfer, transferAPP |
| mintTokens         | ---         | bool                                        | The mint method of CGAS. By initiating InvocationTransaction, users can transfer GAS to the CGAS contract address, and invoke mintTokens to exchange GAS to CGAS. When the contract is successfully invoked, the CGAS in the user's assets will increase to the same amount as the exchanged GAS.  [Note](#note-zh) |
| refund             | byte[] from | bool                                        | Users exchange CGAS to GAS in two steps. The first step is to initiate an InvocationTransaction, which contains a GAS transferred from the CGAS address to the CGAS address (the transfer amount is the amount of GAS the user want to refund), and invoke the refund method (parameter is the refunder's Script Hash). When the contract invocation is successful, the CGAS equal to the refunded amount will be automatically ruined, and the output with index 0 of the transaction will be marked as belonging to the user. In the second step, the user creates a transaction that takes the UTXO marked in the first step as the transaction input and own address as output, thus taking the GAS from the CGAS address. |
| supportedStandards | ---         | string                                      | NEP-10 specification, return the NEP standards supported by the contract, return the constant value in array format: `{ "NEP-5", "NEP-7", "NEP-10" }` |

Notice in the NEP-5 specification:

| Notice     | Parameters                              | Description                                                         |
| -------- | --------------------------------- | ------------------------------------------------------------ |
| transfer | byte[] from, byte[] to, int value | The three elements of the transfer contained in the notice: sender (from), receiver (to), transfer amount (value), and the transfer asset is CGAS by default |

Other notices implemented by the contract:

| Notice   | Parameters                    | Description                                                         |
| ------ | ----------------------- | ------------------------------------------------------------ |
| refund | byte[] txid, byte[] who | The two elements of the transfer contained in the notice: UTXO (txid) to be refunded, and Script Hash (who) of the refunder. |

<a name="note-zh"></a>

> [!Note]
>
> In mintTokens, the Inputs and Outputs of InvocationTransaction should not exceed 60. Otherwise, the fee required for execution will exceed the free 10 GAS. If a large number of GAS’s UTXO needs to be exchanged as CGAS, it is recommended to make a normal transfer to merge UTXO first, and then perform mintTokens.

## Release Notes

**1.0.3**

Script Hash: [0x74f2dc36a68fdc4682034178eb2220729231db76](https://neotracker.io/contract/74f2dc36a68fdc4682034178eb2220729231db76)

CGAS Contract Address: AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM

Known Issues: not found

**1.0.2**

Script Hash: [0x505663a29d83663a838eee091249abd167e928f5](https://neotracker.io/contract/505663a29d83663a838eee091249abd167e928f5)

CGAS Contract Address: Ae8AD6Rc3cvQapqttJcUTj9ULfLi2tLHmc

Known Issues: `transfer` method cannot be called by other contract

**1.0.1**

Script Hash: [0x9121e89e8a0849857262d67c8408601b5e8e0524](https://neotracker.io/contract/9121e89e8a0849857262d67c8408601b5e8e0524)

CGAS Contract Address: AK4LdT5ZXR9DQZjfk5X6Xy79mE8ad8jKAW

Known Issues: `transferAPP` method naming not canonical

## Next Step
Now we are going to learn [global asset and nep5](2_global_asset_and_nep5.md).

If you want to learn NEP5, click [here](../What_is_nep5.md).
