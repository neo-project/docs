# NEO Token Models

### Native Token

There are 2 kinds of native token defined in Neo system: NEO and NeoGas (GAS).

NEO is the Governing Token. Neo holders can participate in Neo network management, including voting for consensus nodes, network parameter modification, etc. The total amount of NEO is 100 million. Its minimum unit is 1 and can not be divided. It's registered in Genesis block, and stored in standby validators' muti-signature addresses.

GAS is the fuel token for the realization of Neo network resource control, with a smallest unit of 0.00000001. Users can obtain GAS either through a claim or purchase. When using the Neo network, they need to pay a certain amount of GAS as network fees, such as transfer, registering assets, publishing assets, running DApps, etc.

To read more about GAS generation rate and distribution refer to the [Governance Overview](https://docs.neo.org/v3/docs/en-us/basic/governance.html)

A new block is generated about every 15 seconds according to system design. Thus approximately 2 million new blocks are created every year. 


### NEP17 Assets (Tokens)

NEP17 tokens need to be issued and managed through smart contract. Their information is stored in a smart contract's storage. Account model is used. For detailed inforamtion, please refer to `NEP17` part in chapter `Smart Contract`.
