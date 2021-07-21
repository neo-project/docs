# Advanced Functions

## Election and Voting

Using Neo-GUI you can elect candidates and vote for Neo consensus nodes. After all the Neo consensus nodes reach a consensus through the DBFT algorithm, new blocks are generated. Voting for consensus nodes is conducted constantly in real time in the Neo blockchain. The main process is:

1. Neo nodes register as candidates
2. NEO token holders vote for candidates
3. Neo blockchain determines the consensus nodes based on the number of candidates and their votes cast.

### Election

After the candidates are registered, the NEO token holders can vote for consensus nodes. Before you participate in the election make sure:

- You open the wallet
- There are enough GAS in your wallet (approximately 6 GAS) for payment of  candidate registration.

To register as a candidate:

1. In Neo-GUI home page click `Advanced` -> `Election`

2. Select the public key of the account in the list and click `OK`. 

   > [!Note]
   >
   > The multi-signature address is not displayed in the list as it cannot be registered to a candidate.

After the transaction is sent successfully, you can do the following to check if the candidate has been registered:

Click `Advanced` -> `Vote` to enter the **Vote** page. The candidate's public key should be displayed in the candidate list:

![](../assets/guiValidators.png)

### Voting

Each Neo node can vote for the candidates. The number of NEO in the current voting account will be automatically calculated as the number of the candidate's votes. For example, if you vote for a candidate from an account that has 100 NEO, the candidate receives 100 votes. If NEO in the account is spent after the vote, the candidate' votes will simultaneously be decreased to the current NEO balance.

To vote:  

1. In Neo-GUI open a wallet and then click `Advanced` -> `Vote`
2. Choose the account to vote
3. In the Candidates field, enter the public key of the candidate to vote. 
4. Click `OK`. 

After voting you can check the votes in the candidates list after the block data has been updated.

## Signature

When initiating any transaction from a multi-signature address, e.g. transferring assets, invoking a contract, or voting, the transaction needs to obtain the minimum number of signatures to carry out the transaction.

1. When GUI prompts there is insufficient signature after you send a transaction from a multi-signature address, copy the transaction information displayed in the pop-up window. 

2. In Neo-GUI, click `Advanced`-> `Signature`.

3. Paste the transaction information copied before into the Transaction Json box, and then click `Signature`.

   ![](../assets/sign_2.png)

4. Copy the output data, enter the next wallet participating in the signature, and repeat that same operation until the signature is completed.

   ![](../assets/sign_3.png)

5. Click `Broadcast`.

   ![](../assets/sign_4.png)

