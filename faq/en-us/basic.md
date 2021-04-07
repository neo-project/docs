# General

## What is Neo？

Neo is a distributed network which utilizes blockchain technology and digital identity to digitize assets and automate the management of digital assets using smart contracts. Neo network has two tokens, NEO representing the right to manage Neo blockchain and GAS representing the right to use the Neo Blockchain. 

## What developer communities does Neo have?

Neo has a large number of worldwide developer communities that have been contributing to Neo development for a long time. Following are some representative communities:

- **CoZ**, the earliest developer community in Neo ecosystem: https://github.com/CityOfZion
- **NEL**, the first Chinese developer community in Neo ecosystem: https://github.com/NewEconoLab
- **NeoResearch**, the South American developer community：https://github.com/NeoResearch
- **NSPCC**, the St. Petersburg developer community, russia：https://www.nspcc.ru/en/
- **NEO·ONE**, a Neo blockchain development toolkit: https://neo-one.io/
- **Red4Sec**, Neo contract security audit：https://red4sec.com/
- **NEONEWSTODAY**, Neo ecosystem latest news: https://neonewstoday.com/
- **NEXT**, Neo Dapp tools development：https://neonext.io/
- **neow3j**, multi-language SDK for Neo smart contract development：https://github.com/neow3j/

## What is GAS？How to acquire GAS？

GAS represents the right to use the Neo Blockchain. Neo network charges GAS for the new assets issuance and smart contract running as well as all translations that modify the blockchain status . The Neo N3 Genesis block will mint the exact amount of GAS token needed to account for all GAS token circulating on the NEO Legacy chain at the time of Genesis block. In Neo N3 once NEO is transferred from the account, the relevant GAS is claimed to the same address automatically.

## What consensus algorithms does Neo use？

Neo utilizes a delegated Byzantine Fault Tolerance (dBFT) algorithm which provides a  𝑓 = ⌊ (𝑛−1) / 3 ⌋  fault tolerance to a consensus system that comprises n nodes. 

There are several types of nodes in this mechanism, such as the ordinary nodes, the candidate nodes, the committee nodes, and the consensus nodes.  Anyone can start a transaction to become the candidate or vote for the candidate. Candidates with a certain amount votes are elected as committee members or consensus nodes. When a consensus needs to be passed, a speaker is randomly selected to decide the proposal, and then other consensus nodes vote according to the dBFT algorithm. If more than 2/3 of nodes agree to the proposal, the consensus is reached; otherwise, the speaker is re-elected and the voting process is repeated.  

## How to become a Neo consensus node？Is there any incentives？

Neo consensus nodes are elected by NEO holders. For more information see https://docs.neo.org/v3/docs/zh-cn/basic/consensus/vote_validator.html.

## What browsers are available for Neo blockchain?

You can access http://ndapp.org/ and find all the browsers listed in the Explorer tab.

## How can I check the status of my transaction?

You can check it on any Neo blockchain explorer, such as https://neotube.io/.

## Is there an equivalent of ERC-20 standard for Neo?

Yes. NEP-17, the replacement of the standard NEP-5, is the Neo N3 token standard which outlines the specifications to be followed by contracts deployed on the Neo blockchain. 

## How to view NEP-17 assets in Neo-CLI？

To view NEP-17 assets invoke the  RPC API [getnep17balances](../../docs/en-us/reference/rpc/latest-version/api/getnep17balances.md) or use the Neo-CLI command [balanceof](../../docs/en-us/node/cli/cli.html#balanceof) .

## What is NEP-6？

NEP-6 is a wallet standard that specifies the wallet format, the definition of parameters in it, the creation rules of wallet address and so on. NEP-6 is applicable to several current Neo client versions including 2.7.6. The Neo client supports wallets in two formats,  sqlite wallet (in .db3) and NEP-6 wallet (in .json). Considering the processing speed, the sqlite wallet is strongly recommended for exchanges. 

## Can you store NEO the same way as Bitcoin? I am nervous about the storage safety.

Yes. If you are holding NEO, then you are always keeping it online. Storing private keys offline means your coins are safe and can not be touched.

## Is there a transfer fee between Neo wallets?

Yes. On Neo N3 any transfer transaction requires a certain amount of GAS.

## If I keep my NEO on an exchange, can I still get my GAS?

This depends on the exchange; some (like [Binance](https://www.binance.com/)) have chosen to give users their GAS when you leave your NEO on the exchange, while others (like [Bittrex](https://www.bittrex.com/)) keep the GAS for themselves. If you want to make sure you receive your Gas, move your NEO to a private wallet and manually claim your GAS.

## I have transferred my NEO balance from the exchange and the exchange kept 0.9750 NEO. However, I cannot send this anywhere because you need at least 1 NEO to be able to send. Can this amount be topped up, held or sold?

You can keep it there to be sold later, or you can buy additional NEO on the exchange so that your amount is more than 1 NEO. You can also exchange NEO to other tokens like USDT, GAS, etc.

