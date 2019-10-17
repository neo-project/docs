# Private key encryption and Wallet files
Storing raw private keys on disk is a security liability. Anyone that that has access to a raw private key can drain these funds. It would be more secure if these keys were encrypted via a password. For this reason we have the NEP-2 standard format (https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)

This encrypted key provides an additional layer of security to the raw private key, requiring an attacker to acquire both the encrypted key and the password in order to access the funds. This is good, but it is often the case that one might need to have multiple accounts, which means that they have multiple keys. Storing each NEP-2 encrypted key would be very cumbersome, so instead we can create a file structure that would allow for all of these encrypted keys to be stored in the same place.

The NEP-6 wallet standard allows for a standardized way of importing addresses into various blockchain clients and contains the additional security guarantees of the NEP-2 format.

A full specification of the file format can be found here. (https://github.com/neo-project/proposals/blob/master/nep-6.mediawiki). It follows a JSON structure that contains information about the private/public key pairs, as well as metadata about each account. The metadata details contains information such as which wallet should be used as the default, the encryption parameters, and any other relevant metadata. 

The NEP-6 file also supports watch-only addresses. Watch-only addresses do not contain any information related to the private key, which maybe useful if the account is stored separately in a more secure location.

## Contract Accounts & Multi-signatures
NEO also supports more sophisticated account types. In these cases, the funds are not associated with a single user but stored in a smart contract. The contract would include special rules which define what is required in order for funds to to be withdrawn from the account. 

The most common case for this type of account is a multi-signature account. A multi-signature account requires that *N* of *X* people provides signatures for the transaction in order to transfer funds. For example, 2 out of 3 of the account owners must sign in order for the funds to be withdrawn.

We can generate a simple contract for this account using NEO op codes. Suppose we want to create a multi-signature contract account for THREE different persons (public keys):

> [!Warning]
>
> You need to sort public keys by its ECPoint(X,Y) in ascending order before the operation otherwise you will get a different scripthash which leads to different NEO address.

```
//pubkey1
036245f426b4522e8a2901be6ccc1f71e37dc376726cc6665d80c5997e240568fb

//pubkey2
0303897394935bb5418b1c1c4cf35513e276c6bd313ddd1330f113ec3dc34fbd0d

//pubkey3
02e2baf21e36df2007189d05b9e682f4192a101dcdf07eed7d6313625a930874b4
```

We want to require at least TWO of them to sign the transactions. So we must create a custom script for this purpose. The script is as follows:

```
// minimum number of signatures (2)
PUSH OPCODE 52

// attach all of the pubkeys
PUSH PUBKEY 1
PUSH PUBKEY 2
PUSH PUBKEY 3

//total number of public keys (3)
PUSH OPCODE 53

//CHECK MULTISIHG
PUSH OPCODE AE
```

This results in the script:

```
5221036245f426b4522e8a2901be6ccc1f71e37dc376726cc6665d80c5997e240568fb210303897394935bb5418b1c1c4cf35513e276c6bd313ddd1330f113ec3dc34fbd0d2102e2baf21e36df2007189d05b9e682f4192a101dcdf07eed7d6313625a930874b453ae
```

We then calculate the script hash and address of this account with the methods that we have already described previously.

Calculate the scripthash (and address): 4d0c0932fa032debdceaaf5cd8086cf3f882961f / AJetuB7TxUkSmRNjot1G7FL5dDpNHE6QLZ

*Multi-sig example courtesy of NeoResearch*

This contract information can also be stored in the NEP-6 file, which allows a user to keep track of accounts that are not necessarily associated with a single private key. More complex account types can be created using NEO's scripting capabilities. 

Multi-signatures are currently supported in the [NEO-GUI](https://github.com/neo-project/neo-gui) and [neo-python](https://github.com/CityOfZion/neo-python) clients.

### NEO DB3
NEO db3 is a legacy file format that was previously supported in NEO-GUI prior to the introduction of the NEP-6 file format. It is highly reccommended to upgrade to NEP-6 file format, which can be done in [NEO-GUI](../../../docs/en-us/node/gui/wallet.md).

## What's next?

[UTXO and Account Model](4-UTXO_and_account_models.md)

