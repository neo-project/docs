# UTXO and Account Model

One of the main functions of a wallet is to facilitate the transfer of assets. Assets on NEO are divided into two categories; UTXO-based (Unspent transaction outputs) and account-based. In NEO, NEO and GAS follow the UTXO model, while NEP-5 tokens follow the account model. Lets explore both in more detail.

## UTXO Model

First, let us consider a simple example where a user has 10 NEO. This 10 NEO actually consists of multiple UTXOs. The sum of all the UTXOs must equal 10. For example this 10 NEO may be consist of 3 UTXOs. UTXO_1 is worth 2 NEO, UTXO_2 is worth 3 NEO, and UTXO_3 is worth 5 NEO, which sums up to the total balance of 10 NEO. So if we need to send someone 3 NEO then we can simply use UTXO_2 3 as the input of the transaction, and the recipient receives as an output one UTXO that is also worth 3 NEO.

If we try to send 5 NEO, then we can combine the UTXO_1 and UTXO_2 together as the inputs, and the recipient recieves 5 NEO as one single output of the transaction. It becomes slightly more complicated when we need to send an amount where we cannot create a perfect sum of UTXOs. 

Let's say that we want to send 4 NEO to someone. No combination of our UTXOs will allows us to get get 4 exactly. The best we can do is use UTXO_1 and UTXO_2 together which will combine to equal 5 NEO. So we use UTXO_1 and UTXO_2 as the inputs to our transaction, but instead of having a single output as with the previous examples, we need to have two output UTXOs. One UTXO worth 4 NEO is generated for the recipient, and then a second UTXO worth 1 NEO is created and returned as change back to the sender's address.

For core NEO transactions, they must satisfy this formula in order to be considered valid on the network:

Sum(NEO_i) + Sum(GAS_i) = Sum(NEO_o) + (Sum(GAS_I) - Sum(GAS_sys_fee) - Sum(GAS_net_fee))

In this sense, UTXOs are not really created or destroyed, but are instead recycled into new ones. Inclusion of UTXOs allows for parallel transaction execution, as each UTXO is unique and therefore is impossible to double spend.

## Account Model
The account model, which is adopted by other blockchain platforms such as Ethereum, creates a global state for each account which has funds. Instead of having a set of UTXOs which can be used for a transaction, you would simply have a balance of 10 associated with your account. Because of this, the global state of all acounts must be store locally on the nodes in the network. Transactions are interpreted by the virtual machine in the network, and make the corresponding state changes to all accounts in the global state. 

NEP-5 token contracts deployed on the NEO network typically follow the account model of balance storage. They do not have any associated UTXO data, and changes in balance state are handled via smart contract executions. These executions are interpreted by the NEO virtual machine, and recorded in the smart contract storage area.

## What's next?

[Introduction to transactions](../3-transactions/1-Introduction_to_transactions.md)

