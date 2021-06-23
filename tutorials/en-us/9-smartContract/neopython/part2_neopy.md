
# NEO Smart Contract Workshop (Part 2)
*by [Steve](https://github.com/HandsomeJeff) for NEO*

This is part 2 of the workshop. [Part 1](part1_setup.md) is for installation. This portion involves interacting with neo-python command line and smart contract examples.


## Task 2 - Wallet Operations

help

Type `help` to get a list of available commands. Here's what you'll see:

```
quit
help
block {index/hash} (tx)
header {index/hash}
tx {hash}
account {address} # returns account state
asset {assetId} # returns asset state
asset search {query}
contract {contract hash} # returns contract state
contract search {query}
notifications {block_number or address}
mem # returns memory in use and number of buffers
nodes # returns connected peers
state
config output_levels (interactive)
config sc-events {on/off}
config maxpeers {num_peers}
config node-requests {reqsize} {queuesize}
config node-requests {slow/normal/fast}
config compiler-nep8 {on/off}
build {path/to/file.py} (test {params} {returntype} {needs_storage} {needs_dynamic_invoke} {is_payable} [{test_params} or --i]) --no-parse-addr (parse address strings to script hash bytearray)
load_run {path/to/file.avm} (test {params} {returntype} {needs_storage} {needs_dynamic_invoke} {is_payable} [{test_params} or --i]) --no-parse-addr (parse address strings to script hash bytearray)
import wif {wif}
import nep2 {nep2_encrypted_key}
import contract {path/to/file.avm} {params} {returntype} {needs_storage} {needs_dynamic_invoke} {is_payable}
import contract_addr {contract_hash} {pubkey}
import multisig_addr {pubkey in wallet} {minimum # of signatures required} {signing pubkey 1} {signing pubkey 2}...
import watch_addr {address}
import token {token_contract_hash}
export wif {address}
export nep2 {address}
open wallet {path}
create wallet {path}
wallet (verbose)
wallet claim (max_coins_to_claim)
wallet migrate
wallet rebuild (start block)
wallet create_addr {number of addresses}
wallet delete_addr {addr}
wallet delete_token {token_contract_hash}
wallet alias {addr} {title}
wallet tkn_send {token symbol} {address_from} {address to} {amount}
wallet tkn_send_from {token symbol} {address_from} {address to} {amount}
wallet tkn_approve {token symbol} {address_from} {address to} {amount}
wallet tkn_allowance {token symbol} {address_from} {address to}
wallet tkn_mint {token symbol} {mint_to_addr} (--attach-neo={amount}, --attach-gas={amount})
wallet tkn_register {addr} ({addr}...) (--from-addr={addr})
wallet tkn_history {token symbol}
wallet unspent (neo/gas)
wallet split {addr} {asset} {unspent index} {divide into number of vins}
wallet close
send {assetId or name} {address} {amount} (--from-addr={addr}) (--fee={priority_fee}) (--owners=[{addr}, ...]) (--tx-attr=[{"usage": <value>,"data":"<remark>"}, ...])
sendmany {number of outgoing tx} (--change-addr={addr}) (--from-addr={addr}) (--fee={priority_fee}) (--owners=[{addr}, ...]) (--tx-attr=[{"usage": <value>,"data":"<remark>"}, ...])
sign {transaction in JSON format}
testinvoke {contract hash} [{params} or --i] (--attach-neo={amount}, --attach-gas={amount}) (--from-addr={addr}) --no-parse-addr (parse address strings to script hash bytearray)
debugstorage {on/off/reset}
```

### Opening a Wallet

Now it is time to open a wallet to perform some functionos that would otherwise be unavailable. We'll be using a sample wallet that comes with the Docker container. Run the command `open wallet neo-privnet.sample.wallet`. The password is `coz`.

![open wallet](assets/open_wallet.png)


Let's check the contents of our wallet. We can show wallet details with the command `wallet`.

![wallet content](assets/wallet_content_box.png)

As you can see, we've got a ton of 100M NEO and 16k Gas in our wallet (**1**). 

We also see in (**2**) that we have a bunch (140k!) of *claims* available. We can claim this Gas with the command `wallet claim 143992` (the number 143992 is the amount fo claimable Gas I have). Enter the password `coz` to confirm. 
(If don't see any available gas to claim but only unavailable, you need to send NEO to yourself to make the gas available. Just copy the address and then:)
```
send neo {address} 100000000
```


Now, if you enter the command `wallet again`, you'll see that we have 160k Gas in our balances.

![wallet content](assets/wallet_claimed_gas_box.png)



*If there is anything wrong with your wallet, you can rebuild it with* `wallet rebuild`.

### Creating a new Wallet

Let's try creating a personal wallet. The command is `create wallet {path}`, where {path} is the location where you want to store the wallet. I entered `create wallet stevewallet`, because I'm Steve and this is my wallet. Enter a password twice (at least 10 characters long). It is stored in the same directory

![create wallet](assets/create_wallet.png)

As you can see, there is no NEO and Gas here. Let's fix that, shall we?

### Sending Tokens

To send tokens to a wallet, we first need to know the address of the wallet. From `wallet`, we can see that my wallet address is `AbsZKotUNrshTg6DTs6FjhuP4xsKJMosw9`.

![wallet address](assets/wallet_address_box.png)

**Keep in mind that your address might be something else! It is unlikely that we have the same wallet address.**

Copy the wallet address and keep it somewhere safe.

Then, open the sample wallet again with `open wallet neo-privnet.sample.wallet`. The password is still `coz`. This will close our current wallet (stevewallet) and open the sample wallet.

Now, let's send ourselves some NEO and Gas! We'll send ourselves 10k of each asset.

```
send neo {address} 10000
send gas {address} 10000
```

{address} is our own wallet address. So in my case it'll look like
```
send neo AbsZKotUNrshTg6DTs6FjhuP4xsKJMosw9 10000
send gas AbsZKotUNrshTg6DTs6FjhuP4xsKJMosw9 10000
```

Finally, we open our own wallet again `wallet open stevewallet` and enter the command `wallet`.

![own wallet with assets](assets/own_wallet_with_assets.png)

We now have 10k NEO and Gas in our wallet!

*If you do not see your assets right away, wait for 15-20 seconds and check again. That should be enough time for the transaction to be confirmed*

## Task 3 - Smart Contracts

Okay, so we messed with our wallets and made a couple of transactions. Now let's try deploying some smart contracts!

For the purpose of this workshop, I will use **programs** and **smart contracts** interchangeably.

First, download the `smart-contracts` folder and place it in the neo-python folder.

If you are working with command line and ssh, first install svn: sudo apt-get install subversion Then, in your neo-python folder, run the command svn checkout https://github.com/HandsomeJeff/neo-python-workshop/trunk/smart-contracts to download the smart-contracts folder.

![smart contracts in neopy](assets/smartcontracts_in_neopy.png)

We should have 5 files inside:

- 1-print.py
- 2-print-and-notify.py
- 3-storage.py
- 4-domain.py
- 5-calculator.py


### Hello World
The first program most programmers write is `hello world`. It's simple, efficient, and we can easily see the output.

On the NEO blockchain, the contract goes in the following order:
1. Build
2. Deploy
3. Invoke

Build Contract

First, enter the command `config sc-events on`. Then try the command <br>`build smart-contracts/1-print.py test ff ff False False False`.

*If you get a "No such file or directory" error, try using the full path of 1-print.py*

![build test contract1](assets/build_test_contract1.png)

We can see under `SmartContract.Runtime.Log`, there is a 'Hello World' printed. This is the outcome of our program.

The command for building a smart contract is <br> `build {path/to/file.py} (test {params} {returntype} {needs_storage} {needs_dynamic_invoke} {test_params})`

Let's break it down:
* `{path/to/file.py}` is the path to the python file we want to build.
* `test`: the word "test" has to be typed if we want to test the contract.
* `{params}` is the type of input parameters, if any, that this contract accept.
* `{returntype}` is the type of value, if any, that this contract returns.
* `{needs_storage}` is a boolean that tells the blockchain if our contract requries storage.
* `{needs_dynamic_invoke}` is a boolean that tells the blockchain if our contracts requires special conditions to execute.
* `{test_params}` are the actual input parameter values that we might want to test with, if any. Note that `test` has to be typed.

For `{params}` and `{returntype}`, the appropriate values for the commands are as follows:

<!-- | Parameter Type | Signature | Boolean | Integer | Hash160 | Hash256 | ByteArray | PublicKey | String | Array | InteropInterface | void |
| --- |
| **Value of param** | 00 | 01 | 02 | 03 | 04 | 05 | 06 | 07 | 10 | f0 | ff | -->

| Parameter Type | Value of param |
| --- | --- |
| Signature | `00` |
| Boolean | `01` |
| Integer | `02` |
| Hash160 | `03` |
| Hash256 | `04` |
| ByteArray | `05` |
| PublicKey | `06` |
| String | `07` |
| Array | `10` |
| InteropInterface | `f0` |
| void | `ff` |

Since our `hello world` program requires no input, output, storage, or special run conditions, we can build it with <br> `build smart-contract/1-print.py ff ff False False False`. <br> *We can omit the word `test`, if we want to build it wihout testing*

![build contract1](assets/build_contract1.png)

We see something called `1-print.avm`. What's this `.avm`? Well, NEO cannot read and execute python programs natively, only `.avm` programs. So a compiler has to compile our `.py` file into a `.avm` file before we can deploy it.

#### Deploy Contract
Now that we have a proper `.avm` smart contract, it's time to deploy it!

For that, we'll run the command <br> `import contract smart-contracts/1-print.avm ff ff False False False`

You'll be prompted to fill in the following:
1. Contract Name
2. Contract Version
3. Contract Author
4. Contract Email
5. Contract Description

You can technically fill in anything you like, but try to write something that makes sense and is easy to remember.

![deploy contract1](assets/deploy_contract1.png)

Enter the password and wait for about 15-20 seconds, or till you see a bunch of random-looking text pop up.

![deployed contract](assets/deployed_contract1.png)

We have now successfully deployed `hello world` to our blockchain!

#### Invoke Contract

To invoke our contract, we're gonna need our contract hash. To see our contract hash, try searching for your contract with the command `contract search {contract info}`. For me, `{contract info}` will be `steve`.

![contract search](assets/contract_search.png)

I can see that the contract hash for my 'steve contract' is `0x5f21886e9c5674ef65f3ba787c45c7a4957621cd`. Next, enter the command `testinvoke {contract hash}`, where `{contract hash}` is your own contract hash. Enter your password to confirm.

![testinvoke contract1](assets/testinvoke_contract1.png)

After a few seconds, you should see a bunch of text pop up:

![testinvoke success contract1](assets/testinvoke_success_contract1.png)

Once again under `SmartContract.Runtime.Log`, there is a 'Hello World' printed. We have successfully invoked a smart contract from our blockchain!

### Print and Notify

Now let's go through the second smart contract.
 <br>`build smart-contracts/2-print-and-notify.py test ff ff False False False`

![build test contract2](assets/build_test_contract2.png)

Here we see the difference between `print()`, `log()`, and `notify()`. The first two functions are essentially the same - they both appear under `SmartContract.Runtime.Log`. `notify()`, however, appears under `SmartContract.Runtime.Notify`. In addition, it can display multiple arguments.

### Calculator

Now let's try something a little different: a calculator program that takes in multiple inputs and returns a value. This contract takes in three parameters: string, integer, integer. It then returns an integer. Hence our input parameter is 070202 and return type is 02.
 <br>`build smart-contracts/3-calculator.py test 070202 02 False False False add 1 2`

![build test contract3](assets/build_test_contract3.png)

In our command, we've included test parameters 'add', '1', and '2'. If we look at the source code, what we are doing is telling the program to add 1 and 2 together. We can see the return value of '3', which is probably the correct answer.

Deploy the calculator <br> `import contract smart-contracts/3-calculator.avm 070202 02 False False False`

Now we need to get the contract hash once again to invoke it. We can either do a search `contract search calculator`, or scroll up to right when we deployed our contract, to find the hash.

![contract hash](assets/contract_hash.png)

At this point, let's invoke our contract and make it, say, multiply 3 with 7. <br> `testinvoke 0x86d58778c8d29e03182f38369f0d97782d303cc0 mul 3 7`

![invoke contract3](assets/invoke_contract3.png)

As we can see, 3 multiplied by 7 gives 21.

Storage

Next up, we have a program that always remembers. First, run `debugstorage on`.

Then run `build smart-contracts/4-storage.py test ff ff True False False`

Note that `{needs_storage}` is set to `True`, because we want to store values on this contract.

![build test storage 1](assets/built_test_contract4_1.png)

Take a look at the value here. It says 1.

Run `build smart-contracts/4-storage.py test ff ff True False False` again.

![build test storage 3](assets/built_test_contract4_2.png)

Now it says 2. Run `build smart-contracts/4-storage.py test ff ff True False False` one more time.

![build test storage 3](assets/built_test_contract4_3.png)

It says 3. This demonstrates the storage capability. But this is only in a test environment. We can reset the value with a `debugstorage reset`. Let's deploy this contract to the blockchain with <br>
`import contract smart-contracts/4-storage.avm ff ff True False False`

Enter the necessary details and wait a while for it to be confirmed. Then invoke the contract with `testinvoke {contract hash}`. After a while you'll see the value of 1.

![invoke storage 1](assets/invoke_contract4_1.png)

Repeating the same command will increment the value each time.

![invoke storage 2](assets/invoke_contract4_2.png)

The difference between this and the test environment is that we cannot reset the contract once it's on the blockchain, given the way the contract is coded. Meaning the value can never decrease or be reset.


#### Domain Name Service

Our last contract example involves working Domain Name Services (DNS) on our blockchain. That is to say, we can register our wallet addresses with unique names. This example will be a culmination of everything we have learnt so far.

The contract will take in a string followed by an array, and then returns a ByteArray (more on this later). So input parameter is 0710, and return type is 05. We will also be needing storage.

The build command is `build smart-contracts/5-domain.py 0710 05 True False False`

Deploy the contract with `import contract smart-contracts/5-domain.avm 0710 05 True False False`

For the next part, we'll test out the various functionalities of this contract:
1. Register a domain name
2. Query a domain name
3. Delete a domain name
4. Transfer ownership of a domain name

Register a Domain Name

To register a wallet address, we need to invoke `register` and enter a name and address. The command looks something like this: `testinvoke {contract_hash} register ['{name}', '{address}']`. We can only register the current wallet that is open.

Let's say I want to assign the name 'steve.com' to the my sample wallet address `AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y`. I'll enter <br>
`testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 register ['steve.com', 'AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y']`

![invoke contract 5 register](assets/invoke_contract5_register.png)

Here we see a 1, which indicates success.

Query a Domain Name

Now, let's check if our address is really registered with the domain name 'steve.com'. For that I enter the command <br> `testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 query ['steve.com']`

![invoke contract 5 query](assets/invoke_contract5_query.png)

Here we see the result `23ba2703c53263e8d6e522dc32203339dcd8eee9`, which is totally not the same as my wallet address `AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y`! Remember the earlier part about ByteArray? Well, our contract returns a ByteArray, whereas our address is a string. Our friend Peter from NEO has build a convenient [tool](https://peterlinx.github.io/DataTransformationTools/) to help us with the conversion.

![scripthash to address](assets/scripthash_to_address.png)

1. Paste the ByteArray where it says "Script Hash", under **Address (little endian)**
2. Click on **Transform**
3. Check out the Address value

![scripthash to address 2](assets/scripthash_to_address2.png)

As we can see, the ByteArray `23ba2703c53263e8d6e522dc32203339dcd8eee9` does correspond to the string `AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y`, which is our wallet address!

#### Delete a Domain Name

If we ever get sick of 'steve.com', we can delete it from this contract. The command is <br> `testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 delete ['steve.com']`

![invoke contract 5 delete](assets/invoke_contract5_delete.png)

Again, we see a 1, which indicates that the action has been successfully executed. To test it, run the query <br> `testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 query ['steve.com']`

![invoke contract 5 delete query](assets/invoke_contract5_delete_query.png)

This time, the contract does not return a ByteArray (**1**), and we get an additional message (**2**).

#### Transfer Ownership of a Domain Name

Lastly, we're gonna try "gifting" our domain name to another wallet address. For this, we need another wallet address, different from our own. For convenience, I'll create a new wallet and look for its address. `create wallet domainwallet`

![new domain wallet](assets/new_domain_wallet.png)

The address for my domainwallet is `AcBpsw14KnwT66oBnfxWFRgRL4QJcyWMMn`.

Now, I'll log back into my previous wallet, that has all the NEO and Gas. `open wallet neo-privnet.sample.wallet`

Since we deleted 'steve.com' in **3.5.3**, we're gonna have to repeat **3.5.1**. First, register our wallet <br>
`testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 register ['steve.com', 'AK2nJJpJr6o664CWJKi1QRXjqeic2zRp8y']`

Next, we'll transfer ownership of 'steve.com' to domainwallet with <br> `testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 transfer ['steve.com', 'AcBpsw14KnwT66oBnfxWFRgRL4QJcyWMMn']`

After confirmation, we can check the new owner of 'steve.com' by the query <br> `testinvoke 0x37c7ed02c81dbe6109e7b45b8fbbf43f585a71d2 query ['steve.com']`

![invoke contract 5 transfer query](assets/invoke_contract5_transfer_query.png)

We get the ByteArray `dfea3015502e02ff4f389f62bada617d7c12f906`.

![scripthash to address 3](assets/scripthash_to_address3.png)

Once we plug it into the conversion tool, we see the address `AcBpsw14KnwT66oBnfxWFRgRL4QJcyWMMn`, which is our domainwallet.

## End

At this point, we have gone through some basic operations on the neo-python command prompt. You should have a clearer idea of how to deploy and call smart contracts to the NEO blockchain. The next step would be to check out our [Discord](https://discord.gg/bXhmTGp) channel and engage with the rest of our community.

Here are additional workshops to go through also:
https://github.com/neo-project/docs/tree/master/en-us/workshop

The City of Zion offical Neo Python documentation is also a great resource:
https://github.com/CityOfZion/neo-python

Thanks for joining us, and feel free to [contact me](mailto:yefan0072001@gmail.com) if you have any further queries.

## Acknowledgements

Special Thanks to [Peter Lin](https://github.com/peterlinx), [Jon](https://github.com/jonathanlimwj) and [Chris Hager](https://github.com/metachris).
