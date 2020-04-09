# Distributing GAS to Users

The exchange can determine whether to distribute GAS to users. GAS is used to pay to the NEO blockchain for recording and additional services. 

## What is GAS ?

GAS represents the right to use the Neo Blockchain. There will be 100 million GAS in total. GASs are generated along with every new block. The issuance will slow down according to a set slowly-decreasing pace, while GAS will go through a generating process to grow from zero to 100 million. Once NEO is acquired, GAS will be generated in the system following the algorithms.

In NEO3 every time a NEO transfer transaction occurs in the address, GASs generated since last time NEO transfer transaction are claimed automatically.

## Calculating the claimed GAS amount

Claimed *GAS = f(neo_amount, Δt_const)*

-  Δt_const = t_end - t_start
  -  t_end = the current time that Neo is transferred into or out of the address. 
  -  t_start = the last time that Neo was transferred into or out of the address. 

Δt_const is fixed, thus the claimed Gas is of a fixed amount too. And this amount depends on the amount of Neo held by the user and the duration between the moments that the user transferred this amount of Neo into and out of his or her address. 

## Distributing GAS to Users

Suppose all the exchange addresses are stored in one wallet, the following chart demonstrates the procedure and computational formula how the exchange distributes GAS to the user A.


![gasflow_en](../sc/assets/gasflow_en.png)

The shorter the snapshot interval, the more precise the calculation is. If the snapshot interval is not uniform, use the weighted average calculation method.

## RPC methods

The following RPC method can be used to help exchanges query users' GAS information. For details, click the desired method link in the table below. 

| Method                                                       | Description                                             |
| ------------------------------------------------------------ | ------------------------------------------------------- |
| [getunclaimedgas](../reference/rpc/latest-version/api/getunclaimedgas.md) | Returns the unclaimed GAS amount in the current wallet. |

## Claiming GAS

GAS is claimed automatically after the user transfers NEO in or out of the address. For example, suppose you have NEO in address A without claiming GAS, when you transfer NEO to yourself (i.e. address A) then GAS is claimed automatically.

The following table lists the GAS claiming steps and corresponding commands.

| #    | Steps                                                        | Command                                         |
| ---- | :----------------------------------------------------------- | ----------------------------------------------- |
| 1    | Run Neo-CLI                                                  | `dotnet neo-cli.dll`                            |
| 2    | Check the client version                                     | `version`                                       |
| 3    | Check the synchronized height of the client ( Height: height/header height, Nodes: amount of connected nodes). | `show state`                                    |
| 4    | Open a wallet                                                | `open wallet /home/NeoNode/test.json`           |
| 5    | Check the addresses and assets in the wallet                 | `list asset`                                    |
| 6    | Check the GAS balance in the wallet                          | `show gas`                                      |
| 7    | Transfer NEO to your address（e.g. AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM） to claim the GAS automatically. | `send neo AaAHt6Xi51iMCaDaYoDFTFLnGbBN1m75SM 1` |
| 8    | Check the asset balance again.                               | `list asset`                                    |

