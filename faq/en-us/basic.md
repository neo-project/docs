# General

## What is NEO？

NEO is a distributed network which utilizes blockchain technology and digital identity to digitize assets and automate the management of digital assets using smart contracts. NEO network has two tokens, NEO representing the right to manage NEO blockchain and GAS representing the right to use the NEO Blockchain. 

## What developer communities does NEO have?

NEO has a large number of worldwide developer communities that have been contributing to NEO development for a long time. Following are some representative communities:

- **CoZ**，the earliest developer community in NEO ecosystem: https://github.com/CityOfZion
- **NEL**，the first Chinese developer community in NEO ecosystem: https://github.com/NewEconoLab
- **NeoResearch**，the South American developer community：https://github.com/NeoResearch
- **NSPCC**，the St. Petersburg developer community, russia：https://www.nspcc.ru/en/
- **KeyMakers**，the Japanese developer community：https://github.com/keymakers

## What is GAS？How to acquire GAS？

GAS represents the right to use the Neo Blockchain. NEO network charges GAS for the new assets issuance as well as for smart contract running and storage. In the genesis block GAS is 0 and it is generated as new blocks generate. Once NEO is acquired, GAS is generated in the system following the algorithms. GAS has two status, available and unavailable. Once NEO is spent (i.e. transferred out) from the account, the relevant GAS turns to available. NEO holders can initiate a claim transaction at any time to claim available GAS to the NEO address.

## Can I transfer GAS to my own account to make it claimable? 

Yes. You can do that even if there is just one address in your wallet.

## How can a Mac user claim GAS?

Mac users can use [this link](https://github.com/CityOfZion/neon-wallet/releases) to download the NEON wallet, which they can use to claim Gas (and send NEO/GAS).

## How many NEO do I need to start earning GAS?

The smallest unit of NEO is 1, in other words: it is indivisible. The smallest unit of GAS is 0.00000001 (one hundred millionth). As long as you possess NEO (at least 1 NEO), GAS will be generated automatically. You can calculate how much GAS you would generate with x amount of NEO on <https://neotogas.com/> or any other GAS-calculator.

## What consensus algorithms does NEO use？

NEO utilizes a delegated Byzantine Fault Tolerance (dBFT) algorithm which provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. 

There are two types of nodes in this mechanism, the ordinary node and the consensus node. Ordinary nodes vote for consensus nodes based on the proportion of NEO they own. When a consensus needs to be passed, a speaker is randomly selected to decide the proposal, and then other consensus nodes vote according to the dBFT algorithm. If more than 2/3 of nodes agree to the proposal, the consensus is reached; otherwise, the speaker is re-elected and the voting process is repeated.  

## How to become a NEO consensus node？Is there any incentives？

NEO consensus nodes are elected by NEO holders. For more information see https://neo-ngd.github.io/reference/How-To-Become-NEO-Consensus-Node.html

## What browsers are available for NEO blockchain?

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

## How can I check the status of my transaction?

You can check it on any NEO blockchain explorer, such as <https://neoscan.io/>.

## Is there an equivalent of ERC-20 standard for NEO?

Yes, it's called [NEP-5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) (NEP is short for *NEO Enhancement Proposals*).

## What is the difference between ordinary assets and NEP-5 assets?

NEO has two asset types. One is global assets which manages assets using the UTXO model. The other is NEP-5 assets which manages assets using the BALANCE model. Both NEO and GAS are UTXO assets that can be traded directly. NEP-5 is a contract asset that is traded by invoking the smart contract. You can use NEO-GUI to register and issue a new UTXO asset. To issue a new NEP-5 asset you need to write a smart contract.

## How to view NEP-5 assets in NEO-CLI？

In NEO-CLI you can just list UTXO assets using `list asset`. To view NEP-5 assets invoke the API `getbalance`.

## What is the difference between NEP-5 and NEP-6？

NEP-5 is a token standard that specifies the token issuance in NEO smart contract. NEP-6 is a wallet standard that specifies the wallet format, the definition of parameters in it, the creation rules of wallet address and so on. NEP-6 is applicable to several current NEO client versions including 2.7.6. The NEO client supports wallets in two formats,  sqlite wallet (in .db3) and NEP-6 wallet (in .json). Considering the processing speed, the sqlite wallet is strongly recommended for exchanges. 

## Can you store NEO the same way as Bitcoin? I am nervous about the storage safety.

Yes. If you are holding NEO, then you are always keeping it online. Storing private keys offline means your coins are safe and can not be touched.

## Is there a transfer fee between NEO wallets?

There is no transfer fee for now. You can transfer NEO or GAS without extra costs. This might change in the future.

## Is there a transfer fee between NEO wallets and exchanges?

It depends on the exchange rules; right now, there is no transfer fee in the NEO system. However, exchanges can take a fee when transferring from an exchange.

## If I keep my NEO on an exchange, can I still get my GAS?

This depends on the exchange; some (like [Binance](https://www.binance.com/)) have chosen to give users their GAS when you leave your NEO on the exchange, while others (like [Bittrex](https://www.bittrex.com/)) keep the GAS for themselves. If you want to make sure you receive your Gas, move your NEO to a private wallet and manually claim your GAS.

## I have transferred my NEO balance from Bittrex and the exchange kept 0.9750 NEO on the exchange. However, I cannot send this anywhere because you need at least 1 NEO plus fees to be able to send. Can this amount be topped up, held or sold?

The tokens you hold on exchanges are not actually NEO. When you withdraw them, at this moment they send you NEO. This is why you are allowed to have 0.97 NEO on exchanges, but not in a wallet. In itself, NEO is indivisible, which means you can't have 1.01 NEO; it will be cut down to 1 NEO. If you try and send your NEO from the exchange, it will send 0 NEO (which is prevented by Bittrex). You can keep it there to be sold later for example though, or you can buy additional NEO on the exchange so that your amount is more than 1 NEO + the necessary fees.
