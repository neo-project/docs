# Charging Model

Participants in Neo ecosystem need to pay network fees and system fees with GAS when using the Neo network. Fees distribution rule is shown below:

![economic model](../images/blockchain/economic_model.jpg)

### Network Fee

Network fee is the fee to pack transactions into a block. Users can define the amount of network fee. Network fee is paid to consensus node as new block incentive. Theoretically the higher network fee per byte is, the easier corresponding transaction is to be put into a block. In the current main network, a block supports up to 512 transactions, including up to 20 free transactions.

### System Fee
System fees are the cost of resources consumed by the transaction execution in NeoVM. The total fee depends on the number and type of instructions executed in the smart contract script. 

Additionally, when running a smart contract, system calls or instructions executed by NeoVM also incur system fees. For details, refer to [Fees](../../sc/fees.md).
