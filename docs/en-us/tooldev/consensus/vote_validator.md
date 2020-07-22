# Consensus Nodes Election

Neo is an open and transparent blockchain network where anyone can either initiate a transaction to apply for being a validator candidate or vote to decide which validator candidate can become a consensus node. The committee members and validators are elected based on the voting result.

> [!Note]
>
> Committee members have the privilege to modify the configuration of Neo network by voting, currently including setting the maximum block size, maximum transactions in a block, fee per byte for network transmission, block / unblock account, etc.

There is no duty assigned to candidates. However, committee members and validators are elected from certain number of candidates with most votes. Their relationship can be described in the following picture. There is no explicit relationship between committee members and validators but, as default committee member amount (21) is more than that of validators, generally speaking validators are a subset of committee members. 

![](../images/consensus/vote_candidate.png)

每个地址均有投票给另一个地址的权利，候选人票数为所有投票给它的地址的NEO余额之和。这里注意，投给非候选人地址的票数会被统计但不会被计入票数，只有当该地址注册为候选人时投票才会生效。

Every address has the right to vote to only one address (whether or not it's a candidate). Candidate's received votes are defined as the sum of NEO held by its voter. Please note that voting towards non-candidate is recorded but not taken into account in committee & validator election. However, such votes will be effective as soon as the voted address becomes a candidate. 

Voting is a dynamic and continuous process. If the NEO asset of a voter is changed, the number of votes at the previous voting address will also change, and the list of consensus nodes and committee members will change accordingly.

> [!Note]
>
> Genesis Block is the first block，its `NextConsensus` is set to the script hash of standby consensus nodes' multi-signature contract.

## From Delegate to Speaker

A speaker is a consensus node who creates the next proposal block. The list of consesus nodes is obtained by the method above, and the speaker is determined by the formula `p = (h - v) mod N` in the dBFT algorithm. `h` is the height of the proposal block. `v` is view number, start from 0. `N` is the number of consensus nodes.

During the consensus phase, a speaker will send `PrepareRequest` message with `NextConsensus`, which determines the next block consensus nodes. The Speaker calculates the next round of consensus nodes by combining the transactions in the proposal block with the previous votes in blockchain, and assign the script hash of 2/3 multi-signature contract to `NextConsensus`. 
