<p align="center">
  <img 
    src="../assets/logo.svg" 
    width="200px"
    alt="Neo">
</p>

<p align="center" style="font-size: 48px;">
  <strong>Workshop 003: Smart Contracts 1 - Writing, Deploying, and Invoking</strong>
</p>

# Introduction
* <b>Duration:</b> 
	* 1 Hour
* <b>Prerequisites:</b> 
	* [002 Neo Development Environments](../2_development_environment/README.md)
* <b>Infrastructure Requirements:</b>
	* (Required) Whiteboard or Projector
	* (Required) High-Speed Internet Connection
	* (Required) Deployment of an Eventnet for workshop use
* <b>Instructor Prework:</b>
	* (Required) Workshop content review
	* (Required) Fill out the [worksheet](./Worksheet.md) for students
* <b>Student Prework:</b>
	* (Recommended) General Understanding of blockchain fundamentals
	* (Recommended) Familiarization with Amazon Web Services(or other CSP)
* <b>Workshop Materials List:</b>
	* None

## Outline
This workshop covers how to use the Neo development environment to develop basic smart contracts for the Neo platform. It will also cover the deployment process as well as how to invoke the contracts. This workshop will be branching and will support C#, python, and typescript contract development and their environments.


## Tools
* <i><b>Note:</b> All code examples are flagged with a language and tool for clarity.  Depending on your implementation path, you may be using cross language libraries (for example, writing a smart contract in python, but interfacing in javascript). </i>

## Introduction and Setup
In this course we will be walking students through smart contract development including writing, deploying, and invoking.  We will primarily be using NEP5 contracts as examples, but will cover additional contracts to provide feature coverage.  When developing a smart contract for Neo, its important to understand that the contract deployment workflow has an intermediary step where the contract code is compiled from its native language into a .avm file containing bytecode which the neoVM interprets.  


<p align="center">
  <img 
	src="../2_development_environment/assets/workflow.png" 
	alt="Neo">
</p>
	
	
## Writing a contract
In the NEO ecosystem, there are two triggers to consider when writing a smart contract.  These triggers are used as flow control. 
* <b>Application Triggers:</b>
Application triggers behave similarly to method calls.  These events occur when a user attempted to invoke a specific method exposed in the smart contract.
* <b>Verification Triggers:</b>
Verification triggers running when a verification occurs from a transaction.  For example, if an address sends NEO or GAS to the contract, the verification trigger is emitted.

### Events
Events are another important component to smart contracts because they significantly enhance the usability of the platform.  Because invokes are published using bytecode, its very difficult of applications to parse this information to detect events which may be relevant to their performance.  An event raises a flag to indicate that something occured.  In the NEP5 standard, we see a [transfer event](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki#events) which broadcasts that a token transfer event has taken place.  It also provides some additional useful information about the event.

### The Virtual Machine
The Neo platform runs smart contracts in a virtual machine.  This allows contracts to be written in any language for which there is a compiler.  Its very important to note the distinction between compiling from a lanaguage to byte code run by the VM and native support for the language.  If you are having issues with debugging a section of your code, its possible that a feature of your language may not yet be supported by the compiler.
Examples of the same method in multiple languages:
* C#: `Storage.Put(Storage.CurrentContext, Owner, pre_ico_cap);`
* Python: `Put(ctx, t_to, to_total)`
* Go: `storage.Put(ctx, to, totalAmountTo)`

These all result in similar bytecode once compiled.  You can refer to the complete list [<b>here</b>](https://docs.neo.org/developerguide/en/articles/neo_vm.html)


### Our Atomic NEP-5
In this workshop will make use of an atomic NEP-5 token.  The contract used may be referenced for learning purposes but you should always reference the latest templates for contracts which implement the most updated design patterns to ensure security.

* [<b>Python</b>](./assets/nep5.py)
* [<b>Go</b>](https://github.com/CityOfZion/neo-storm/tree/13b9dfa70af55896334ea02de3b5a05ec6dc4eee/examples/token)

<b>The Python Example:</b>
```python

"""
NEP5 Token
===================================

A simplified version of the original authored by: 
.. moduleauthor:: Thomas Saunders <tom@cityofzion.io>

..modifiedby:: Tyler Adams <tyler@coz.io>

"""

from boa.interop.Neo.Runtime import GetTrigger, CheckWitness
from boa.interop.Neo.Action import RegisterAction
from boa.interop.Neo.TriggerType import Application, Verification
from boa.interop.Neo.Storage import GetContext, Get, Put, Delete
from boa.builtins import concat

# -------------------------------------------
# TOKEN SETTINGS
# -------------------------------------------

# Script hash of the contract owner
# Use: np-utils --address-to-scripthash {{address}} 
OWNER = b'\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00'

# Name of the Token
TOKEN_NAME = 'NEP5 Standard'

# Symbol of the Token
TOKEN_SYMBOL = 'NEP5'

# Number of decimal places
TOKEN_DECIMALS = 8

# Total Supply of tokens in the system
TOKEN_TOTAL_SUPPLY = 10000000 * 100000000  # 10m total supply * 10^8 ( decimals)

ctx = GetContext()

# -------------------------------------------
# Events
# -------------------------------------------

OnTransfer = RegisterAction('transfer', 'addr_from', 'addr_to', 'amount')
OnApprove = RegisterAction('approve', 'addr_from', 'addr_to', 'amount')


def Main(operation, args):
    """
    This is the main entry point for the Smart Contract

    :param operation: the operation to be performed ( eg `balanceOf`, `transfer`, etc)
    :type operation: str
    :param args: a list of arguments ( which may be empty, but not absent )
    :type args: list
    :return: indicating the successful execution of the smart contract
    :rtype: bool
    """

    # The trigger determines whether this smart contract is being
    # run in 'verification' mode or 'application'

    trigger = GetTrigger()

    # 'Verification' mode is used when trying to spend assets ( eg NEO, Gas)
    # on behalf of this contract's address
    if trigger == Verification():

        # if the script that sent this is the owner
        # we allow the spend
        is_owner = CheckWitness(OWNER)

        if is_owner:

            return True

        return False

    # 'Application' mode is the main body of the smart contract
    elif trigger == Application():

        if operation == 'name':
            return TOKEN_NAME

        elif operation == 'decimals':
            return TOKEN_DECIMALS

        elif operation == 'symbol':
            return TOKEN_SYMBOL

        elif operation == 'totalSupply':
            return TOKEN_TOTAL_SUPPLY

        elif operation == 'balanceOf':
            if len(args) == 1:
                account = args[0]
                return do_balance_of(ctx, account)

        elif operation == 'transfer':
            if len(args) == 3:
                t_from = args[0]
                t_to = args[1]
                t_amount = args[2]
                return do_transfer(ctx, t_from, t_to, t_amount)
            else:
                return False

        return 'unknown operation'

    return False


def do_balance_of(ctx, account):
    """
    Method to return the current balance of an address

    :param account: the account address to retrieve the balance for
    :type account: bytearray

    :return: the current balance of an address
    :rtype: int

    """

    if len(account) != 20:
        return 0

    return Get(ctx, account)


def do_transfer(ctx, t_from, t_to, amount):
    """
    Method to transfer NEP5 tokens of a specified amount from one account to another

    :param t_from: the address to transfer from
    :type t_from: bytearray
    :param t_to: the address to transfer to
    :type t_to: bytearray
    :param amount: the amount of NEP5 tokens to transfer
    :type amount: int

    :return: whether the transfer was successful
    :rtype: bool

    """

    if amount <= 0:
        return False

    if len(t_from) != 20:
        return False

    if len(t_to) != 20:
        return False

    if CheckWitness(t_from):

        if t_from == t_to:
            print("transfer to self!")
            return True

        from_val = Get(ctx, t_from)

        if from_val < amount:
            print("insufficient funds")
            return False

        if from_val == amount:
            Delete(ctx, t_from)

        else:
            difference = from_val - amount
            Put(ctx, t_from, difference)

        to_value = Get(ctx, t_to)

        to_total = to_value + amount

        Put(ctx, t_to, to_total)

        OnTransfer(t_from, t_to, amount)

        return True
    else:
        print("from address is not the tx sender")

    return False
	
```



<b>To Build into a .avm:</b>
* <b>Python:</b> In the neo-python prompt

   ```sc build {{path to smart contract}}```
   
* <b>Go:</b> From shell

    ```neo-storm compile -i path/to/file.go```


* <b>C#:</b> (Built from compiler)
    
### Other Examples:

#### <b>C#</b>:
* [Vanilla NEP-5 template](https://github.com/neo-project/examples-csharp/blob/master/ICO_Template)
* [Moonlight NEP-5 template](https://github.com/Moonlight-io/moonlight-ico-template)
* [Neo Docs Samples](https://docs.neo.org/en-us/sc/tutorial/HelloWorld.html)
	
#### <b>Python</b>:
* [NEX NEP-5 Template](https://github.com/nash-io/neo-ico-template)

#### <b>Go</b>:
* [neo-storm examples](https://github.com/CityOfZion/neo-storm/tree/13b9dfa70af55896334ea02de3b5a05ec6dc4eee/examples)


<b>For a list of supported methods:</b>
* [<b>Python:</b>](https://neo-boa.readthedocs.io/en/latest/index.html)
* [<b>Go:</b>](https://github.com/CityOfZion/neo-storm/tree/13b9dfa70af55896334ea02de3b5a05ec6dc4eee/examples)
* [<b>C#</b>](https://docs.neo.org/en-us/sc/reference/api.html)

## Addresses
For more contract development tools, you must have an open wallet with a standing balance to work.  With a privatenet deployed, we can use the faucet to receive assets, but first we need to have a valid address to receive them. During this step, it is <b>CRITICAL</b> for your to log this information in a private location.  If you lose it, it cannot be recovered.

To Create a new wallet:
* <b>Python:</b>

`wallet create {{path to new wallet}}`

`wallet import wif KxDgvEKzgSBPPfuVfw67oPQBSjidEiqTHURKSDL1R7yGaGYAeYnr`
	
* <b>Go:</b>



* <b>C#:</b>


### Wallet Attributes
 <b> Wallet output from Python `wallet create` command: </b>
```json
Wallet {
    "path": "demowallet",
    "addresses": [
        {
            "address": "AUjpV8S35wW1ZZzkBZcD3d8uiiDuNdjpCH",
            "script_hash": "8e362a05574a0b4dc77a63b51d69294bff1828d0",
            "tokens": null
        }
    ],
    "height": 0,
    "percent_synced": 0,
    "synced_balances": [],
    "public_keys": [
        {
            "Address": "AUjpV8S35wW1ZZzkBZcD3d8uiiDuNdjpCH",
            "Public Key": "036192a94cb37e11b828dfef96c6539f9b4397ee330837217db4e                                                                                                                                                             bee9cf3158ef2"
        }
    ],
    "tokens": [],
    "claims": {
        "available": "0.0",
        "unavailable": "0.0"
    }
}
Pubkey b'036192a94cb37e11b828dfef96c6539f9b4397ee330837217db4ebee9cf3158ef2'

```

* Claims
* Address
* Keys
	* Public
	* Private

### Assets for Development
For a development environment using a neo-local privatenet, you can now navigate to the faucet {{privatenet address}:4002 and request assets for your address.


	
## Local Invokes
Now that we have a compiled contract, lets run some invokes on it.  In NEO, we <b>HIGHLY</b> recommend leveraging testing in a local VM before deploying to the blockchain (even a privatenet) for efficiency.  Alternatively, you can deploy the contract to the privatenet and run system-level unit testing.

* <b>Python:</b> In the neo-python prompt
	```sc build_run {{path to smart contract}} True False False  0710 05 name []```
* <b>Go:</b>
	
* <b>C#:</b>

Local invokes private a strong foundation for unit testing of smart contracts.

<b>Python result of local invoke:</b>
```
-----------------------------------------------------------
Calling ./examples/nep5.py with arguments ['[]', 'name']
Test deploy invoke successful
Used total of 86 operations
Result [{'type': 'ByteArray', 'value': '4e455035205374616e64617264'}]
Invoke TX gas cost: 0.0001
-------------------------------------------------------------
```

### Input and Return Parameters

When deploying a contract, interface parameters are defined by bytes using the following [<b>definition</b>](https://docs.neo.org/en-us/sc/Parameter.html).

## Deploying a Contract
* Overview of deployment costs


* <b>Python:</b>

   ```sc deploy {{path to avm}} True False False 0710 05```

* <b>Go:</b>

* <b>C#:</b>


<b>Example result:</b>

```
                 Name: nep5 demo
              Version: 1.0
               Author: lllwvlvwlll
                Email: tyler@coz.io
          Description: a nep5 demo
        Needs Storage: True
 Needs Dynamic Invoke: False
           Is Payable: False
{
    "hash": "0xcc109ff556bb10f05213c76b0ba763be079a76a8",
    "script": "0126c56b6a00527ac46a51527ac41400000000000000000000000000000000000000006a52527ac40d4e455035205374616e646172646a53527ac4044e4550356a54527ac4586a55527ac4070080c6a47e8d036a56527ac468164e656f2e53746f726167652e476574436f6e74657874616a57527ac468164e656f2e52756e74696d652e47657454726967676572616a58527ac46a58c30100876435006a52c368184e656f2e52756e74696d652e436865636b5769746e657373616a59527ac46a59c3640700516c756661006c7566616a58c30110876409016a00c3046e616d65876409006a53c36c7566616a00c308646563696d616c73876409006a55c36c7566616a00c30673796d626f6c876409006a54c36c7566616a00c30b746f74616c537570706c79876409006a56c36c7566616a00c30962616c616e63654f66876426006a51c3c051876480006a51c300c36a5a527ac46a57c36a5ac37c656f026c7566626600616a00c3087472616e73666572876455006a51c3c053876447006a51c300c36a5b527ac46a51c351c36a5c527ac46a51c352c36a5d527ac46a57c36a5bc36a5cc36a5dc353795179557275517275527952795472755272756526006c756661006c75666111756e6b6e6f776e206f7065726174696f6e6c756661006c7566011fc56b6a00527ac46a51527ac46a52527ac46a53527ac46a53c300a1640700006c7566616a51c3c001149e640700006c7566616a52c3c001149e640700006c7566616a51c368184e656f2e52756e74696d652e436865636b5769746e65737361644f016a51c36a52c387642a00117472616e7366657220746f2073656c6621680f4e656f2e52756e74696d652e4c6f67516c7566616a00c36a51c37c680f4e656f2e53746f726167652e476574616a54527ac46a54c36a53c39f642b0012696e73756666696369656e742066756e6473680f4e656f2e52756e74696d652e4c6f67006c7566616a54c36a53c3876422006a00c36a51c37c68124e656f2e53746f726167652e44656c65746561622d00616a54c36a53c3946a55527ac46a00c36a51c36a55c35272680f4e656f2e53746f726167652e50757461616a00c36a52c37c680f4e656f2e53746f726167652e476574616a56527ac46a56c36a53c3936a57527ac46a00c36a52c36a57c35272680f4e656f2e53746f726167652e507574616a51c36a52c36a53c35272087472616e7366657254c168124e656f2e52756e74696d652e4e6f74696679516c7566612166726f6d2061646472657373206973206e6f74207468652074782073656e646572680f4e656f2e52756e74696d652e4c6f67006c756657c56b6a00527ac46a51527ac46a51c3c001149e640700006c7566616a00c36a51c37c680f4e656f2e53746f726167652e476574616c75665ec56b6a00527ac46a51527ac46a51c36a00c3946a52527ac46a52c3c56a53527ac4006a54527ac46a00c36a55527ac461616a00c36a51c39f6433006a54c36a55c3936a56527ac46a56c36a53c36a54c37bc46a54c351936a54527ac46a55c36a54c3936a00527ac462c8ff6161616a53c36c7566",
    "parameters": [
        "String",
        "Array"
    ],
    "returntype": "ByteArray"
}
Used 500.0 Gas

```

## Invoking a Contract

On the NEO platform, invocations (including deployments) cost GAS.  The first 10 GAS associated with an invoke are free.  Invocation costs are a function of byte code execution.

* <b>Python:</b>

```sc invoke {{hash}} name```

* <b>Javascript:</b>

* Example invokation using neo-gui
* Example invocation using neon.js

```
-------------------------------------------------------------------------------------------------------------------------------------
Test invoke successful
Total operations: 120
Results [{'type': 'ByteArray', 'value': '756e6b6e6f776e206f7065726174696f6e'}]
Invoke TX GAS cost: 0.0
Invoke TX fee: 0.0001
-------------------------------------------------------------------------------------------------------------------------------------
```

<b>Note:</b> Notice that the response is a binary array.  This was defined as our response type when deploying.  If you use a HEX converter, you will be able to see that the resulting string is the name of the contract.

### Local Invokes v. Published Invokes
* Differences in how each works
* How to leverage the difference in your architecture

### Events

In the contract examples, you'll notice that we have events these are signals that are published with the transactions as helpers to external tools.  In our example, we publish information indicating that a transfer has occurred.
