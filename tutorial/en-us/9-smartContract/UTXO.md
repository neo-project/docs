---
layout: post
lang: en
lang-ref: UTXO
---

# UTXO

>
> **Objective**:  Understand the idea of UTXO
>
> **Main points**:
>
> 1. The concept of UTXO
> 2. The Stucture of UTXO in NEO
>
>

## The conept of UTXO

If you are familiar with blockchain or use some digital coins before, you may hear of the word `UTXO`. The UTXO stands for **Unspent Transaction Output**, which means an output of a blockchain transaction that has not been spent and can be used as an input in a new transaction.

When you use some digital coin wallets, you may see there is an account balance number. Actually, if it is a UTXO based blockchain, there is the concept of `account balance`. Actually the stored number is aggregated by the wallet application itself and the source it use is the UTXO. The concept of the UTXO is very similar to the wallet in the real life. Let's think you open your wallet, you see 100 dollars. You do not know where the 100 dollar come from. It might come from your customer as the payment for your website designing last week, and that is a UTXO which from you customer to you and the amount is 100 dollars. Then, you want  to spent 10 dollar from your wallet to buy a magazine. After spent 10 dollars you get 90 dollar as change. Then the UTXO you have is 90 dollars. The 10 dollars you spent to the magazine shop becomes a UTXO to him until he spent it to his next transaction.


## UTXO in NEO

The NEO blockchain supports native assets, the two most important ones being NEO and GAS. Native assets are Unspent Transaction Output (UTXO) based and are understood natively by the blockchain. Contrast this with tokens like the one we’ve built so far which live entirely in custom smart contracts. Unlike the account balance model, the UTXO model does not directly record account assets, but calculates user assets through unspent output. Each UTXO asset (such as a global asset) is an input-output association model, `input` specifies the source of funds, and `output` indicates the asset destination.

In the picture below, Alice gets 8 GAS's share from her hold NEO, which is recorded in the first output in transaction *#101*. When Alice transfers 3 GAS to Bob, input of new transaction records the asset is 8 GAS, which is represented by output position 0 of transaction *#101*. Furthermore, in another transaction *#201*, one output points to the 3 GAS transferred to Bob, while another one to 5 GAS back to Alice herself (small change).

<p align="center">
    <img src="https://docs.neo.org/developerguide/en/images/blockchain/utxo_en.jpg"/>
</p>

Let's view the transaction structure in NEO. AS show in the picture above, the `output` itself has an index attributes because it is located in a list of outputs. The `output` it self consists of `AssetId`,`Amount` and `ScriptHash` which is the receipt address. The `Input` structure is the source of a transaction and it contains a `PreHash` which points to the transaction it comes from and a `Preindex` which points to the corresponding output from previous transaction

## Next Step

[What is CGAS](cgas/1_what_is_cgas.md)