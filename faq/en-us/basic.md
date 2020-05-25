# General

## What is Neo？

Neo is a distributed network which utilizes blockchain technology and digital identity to digitize assets and automate the management of digital assets using smart contracts. Neo network has two tokens, NEO representing the right to manage Neo blockchain and GAS representing the right to use the Neo Blockchain. 

## What developer communities does Neo have?

Neo has a large number of worldwide developer communities that have been contributing to Neo development for a long time. Following are some representative communities:

- **CoZ**，the earliest developer community in Neo ecosystem: https://github.com/CityOfZion
- **NEL**，the first Chinese developer community in Neo ecosystem: https://github.com/NewEconoLab
- **NeoResearch**，the South American developer community：https://github.com/NeoResearch
- **NSPCC**，the St. Petersburg developer community, russia：https://www.nspcc.ru/en/
- **KeyMakers**，the Japanese developer community：https://github.com/keymakers

## What is GAS？How to acquire GAS？

GAS represents the right to use the Neo Blockchain. Neo network charges GAS for the new assets issuance as well as for smart contract running and storage. In the Neo3 genesis block GAS is 30,000,000 and it is increasing as new blocks generate. Once NEO is acquired, GAS is generated in the system following the algorithms. In Neo3 once NEO is transferred from the account, the relevant GAS is claimed to the same address automatically.

## What consensus algorithms does Neo use？

Neo utilizes a delegated Byzantine Fault Tolerance (dBFT) algorithm which provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. 

There are two types of nodes in this mechanism, the ordinary node and the consensus node. Ordinary nodes vote for consensus nodes based on the proportion of NEO they own. When a consensus needs to be passed, a speaker is randomly selected to decide the proposal, and then other consensus nodes vote according to the dBFT algorithm. If more than 2/3 of nodes agree to the proposal, the consensus is reached; otherwise, the speaker is re-elected and the voting process is repeated.  

## How to become a Neo consensus node？Is there any incentives？

Neo consensus nodes are elected by NEO holders. For more information see https://neo-ngd.github.io/reference/How-To-Become-NEO-Consensus-Node.html

## What browsers are available for Neo blockchain?

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

## How can I check the status of my transaction?

You can check it on any Neo blockchain explorer, such as <https://neoscan.io/>.

## Is there an equivalent of ERC-20 standard for Neo?

Yes, it's called [NEP-5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) (NEP is short for *Neo Enhancement Proposals*).

## How to view NEP-5 assets in Neo-CLI？

To view NEP-5 assets invoke the API `getbalance`.

## What is the difference between NEP-5 and NEP-6？

NEP-5 is a token standard that specifies the token issuance in Neo smart contract. NEP-6 is a wallet standard that specifies the wallet format, the definition of parameters in it, the creation rules of wallet address and so on. NEP-6 is applicable to several current Neo client versions including 2.7.6. The Neo client supports wallets in two formats,  sqlite wallet (in .db3) and NEP-6 wallet (in .json). Considering the processing speed, the sqlite wallet is strongly recommended for exchanges. 

## Can you store NEO the same way as Bitcoin? I am nervous about the storage safety.

Yes. If you are holding NEO, then you are always keeping it online. Storing private keys offline means your coins are safe and can not be touched.

## Is there a transfer fee between Neo wallets?

There is no transfer fee for now. You can transfer NEO or GAS without extra costs. This might change in the future.

## Is there a transfer fee between Neo wallets and exchanges?

It depends on the exchange rules; right now, there is no transfer fee in the Neo system. However, exchanges can take a fee when transferring from an exchange.

## If I keep my NEO on an exchange, can I still get my GAS?

This depends on the exchange; some (like [Binance](https://www.binance.com/)) have chosen to give users their GAS when you leave your NEO on the exchange, while others (like [Bittrex](https://www.bittrex.com/)) keep the GAS for themselves. If you want to make sure you receive your Gas, move your NEO to a private wallet and manually claim your GAS.

## I have transferred my NEO balance from the exchange and the exchange kept 0.9750 NEO. However, I cannot send this anywhere because you need at least 1 NEO to be able to send. Can this amount be topped up, held or sold?

The tokens you hold on exchanges are not actually NEO. When you withdraw them, at this moment they send you NEO. This is why you are allowed to have 0.97 NEO on exchanges, but not in a wallet. In itself, NEO is indivisible, which means you can't have 1.01 NEO; it will be cut down to 1 NEO. If you try and send your NEO from the exchange, it will send 0 NEO. You can keep it there to be sold later for example though, or you can buy additional NEO on the exchange so that your amount is more than 1 NEO.
