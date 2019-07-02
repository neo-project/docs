# The basics

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

## What consensus algorithms does NEO use？

NEO utilizes a delegated Byzantine Fault Tolerance (dBFT) algorithm which provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. 

There are two types of nodes in this mechanism, the ordinary node and the consensus node. Ordinary nodes vote for consensus nodes based on the proportion of NEO they own. When a consensus needs to be passed, a speaker is randomly selected to decide the proposal, and then other consensus nodes vote according to the dBFT algorithm. If more than 2/3 of nodes agree to the proposal, the consensus is reached; otherwise, the speaker is re-elected and the voting process is repeated.  

## How to become a NEO consensus node？Is there any incentives？

NEO consensus nodes are elected by NEO holders. For more information see https://neo-ngd.github.io/reference/How-To-Become-NEO-Consensus-Node.html

## What browsers are available for NEO blockchain?

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

## What is the difference between ordinary assets and NEP-5 assets?

NEO has two asset types. One is global assets which manages assets using the UTXO model. The other is NEP-5 assets which manages assets using the BALANCE model. Both NEO and GAS are UTXO assets that can be traded directly. NEP-5 is a contract asset that is traded by invoking the smart contract. You can use NEO-GUI to register and issue a new UTXO asset. To issue a new NEP-5 asset you need to write a smart contract.

## How to view NEP-5 assets in NEO-CLI？

In NEO-CLI you can just list UTXO assets using `list asset`. To view NEP-5 assets invoke the API `getbalance`.

## What is the difference between NEP-5 and NEP-6？

NEP-5 is a token standard that specifies the token issuance in NEO smart contract. NEP-6 is a wallet standard that specifies the wallet format, the definition of parameters in it, the creation rules of wallet address and so on. NEP-6 is applicable to several current NEO client versions including 2.7.6. The NEO client supports wallets in two formats,  sqlite wallet (in .db3) and NEP-6 wallet (in .json). Considering the processing speed, the sqlite wallet is strongly recommended for exchanges. 