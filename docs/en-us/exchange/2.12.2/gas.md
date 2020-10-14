# Distributing GAS to Users

The exchange can determine whether to distribute GAS to users. GAS is used to pay to the NEO blockchain for recording and additional services. 

## What is GAS ?

NeoGas (abbreviated as GAS) represents the right to use the Neo Blockchain. There will be 100 million GAS in total. GASs are generated along with every new block. The issuance will slow down according to a set slowly-decreasing pace, while GAS will go through a generating process to grow from zero to 100 million. Once NEO is acquired, GAS will be generated in the system following the algorithms.

## Calculating the Available GAS Amount

- Available *GAS = f(neo_amount, Δt_const)*

  -  Δt_const = t_end - t_start
    -  t_end = the moment that Neo goes into the state of spent
    -  t_start = the moment that Neo goes into the state of unspent

  Δt_const is fixed, thus the available Gas is of a fixed amount too. And this amount is a function of the amount of Neo held by the user and the duration between the moments that he or she transferred this amount of Neo into and out of his or her address. 


- Unavailable *GAS = f(neo_amount, Δt_var)*

  - Δt_var = t - t_start
    - t is the current time
    - t_start = the moment that Neo goes into the state of unspent

  The current time is a variable, so the amount of the unavailable GAS also grows through time, which means it is a variable.

## Distributing GAS to Users

Suppose all the exchange addresses are stored in one wallet, the following chart demonstrates the procedure and computational formula how the exchange distributes GAS to the user A.


![gasflow_en](../../sc/assets/gasflow_en.png)

The shorter the snapshot interval, the more precise the calculation is. If the snapshot interval is not uniform, use the weighted average calculation method.

## RPC methods

NEO provides a set of RPC methods to help exchanges query users' GAS information. For details, click the desired method link in the table below. 

| Method                                                       | Description                                                  | Parameter          |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------ |
| [getunclaimedgas](../../reference/rpc/latest-version/api/getunclaimedgas.md) | Returns the unclaimed GAS amount in the current wallet.      |                    |
| [getunclaimed](../../reference/rpc/latest-version/api/getunclaimed.md) | Returns the unclaimed GAS amount of the specified address.   | \<address>         |
| [claimgas](../../reference/rpc/latest-version/api/claimgas.md) | Claims GAS and send them to the first standard address in the wallet by default. You can also specify an address to receive these GAS. | [address] Optional |
| [getclaimable](../../reference/rpc/latest-version/api/getclaimable.md) | Returns claimable GAS information of the specified address.  | \<address>         |
| [getunspents](../../reference/rpc/latest-version/api/getunspents.md) | Returns information of the unspent NEO and GAS amount at the specified address. | \<address>         |

## Claiming GAS

GAS becomes claimable after the user transfer his or her NEO. For example, **someone has NEO in address A and GAS are not claimable, he transfer his NEO to himself (address A) then the NEO GAS are claimable.**

The following table lists the GAS claiming steps and corresponding commands.

| #    | Steps                                                        | Command                                         |
| ---- | :----------------------------------------------------------- | ----------------------------------------------- |
| 1    | Run NEO-CLI                                                  | `dotnet neo-cli.dll --rpc`                      |
| 2    | Check the client version                                     | `version`                                       |
| 3    | Check the synchronized height of the client ( Height: height/header height, Nodes: amount of connected nodes). | `show state`                                    |
| 4    | Create a wallet                                              | `create wallet /home/NeoNode/test.db3`          |
| 5    | Open the wallet created in the last step                     | `open wallet /home/NeoNode/test.db3`            |
| 6    | Check the address list in the wallet                         | `list address`                                  |
| 7    | Check the assets in the wallet                               | `list asset`                                    |
| 8    | Check the GAS balances details in the wallet                 | `show gas`                                      |
| 9    | Transfer NEO to your address（e.g. AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1） to change the status of Gas to be claimable. | `send NEO AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 10   | Get the details of the balances of GAS in the wallet again. Now the status of all the GAS should be available to claim. | `show gas`                                      |
| 11   | Claim GAS.                                                   | `claim gas [all]`                               |
| 12   | Check balance again.                                         | `list asset`                                    |

