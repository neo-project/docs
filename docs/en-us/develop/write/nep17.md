# NEP-17

The NEP-17 proposal is a replacement of the original NEP5 proposal, which outlines a token standard for the Neo blockchain that will provide systems with a generalized interaction mechanism for tokenized Smart Contracts. 

NEP17 assets are recorded in the contract storage area, through updating account balance in the storage area, to complete the transaction.

In the method definitions below, we provide both the definitions of the functions as they are defined in the contract as well as the invoke parameters.

**totalSupply**

    {
      "name": "totalSupply",
      "parameters": [],
      "returntype": "Integer"
    }

Returns the total token supply deployed in the system.

**symbol**

    {
      "name": "symbol",
      "parameters": [],
      "returntype": "String"
    }

Returns a short string symbol of the token managed in this contract. e.g. "MYT". 

This string MUST be valid ASCII, MUST NOT contain whitespace or control characters, SHOULD be limited to uppercase Latin alphabet (i.e. the 26 letters used in English) and SHOULD be short (3-8 characters is recommended). 

This method MUST always return the same value every time it is invoked.

**decimals**

    {
      "name": "decimals",
      "parameters": [],
      "returntype": "Integer"
    }

Returns the number of decimals used by the token - e.g. `8`, means to divide the token amount by `100,000,000` to get its user representation.

This method MUST always return the same value every time it is invoked.

**balanceOf**

    {
      "name": "balanceOf",
      "parameters": [
        {
          "name": "account",
          "type": "Hash160"
        }
      ],
      "returntype": "Integer"
    }

Returns the token balance of the `account`.

The parameter `account` MUST be a 20-byte address. If not, this method SHOULD `throw` an exception.

If the `account` is an unused address, this method MUST return `0`.

**transfer**

    {
      "name": "transfer",
      "parameters": [
        {
          "name": "from",
          "type": "Hash160"
        },
        {
          "name": "to",
          "type": "Hash160"
        },
        {
          "name": "amount",
          "type": "Integer"
        },
        {
          "name": "data",
          "type": "Any"
        }
      ],
      "returntype": "Boolean"
    }

Transfers an `amount` of tokens from the `from` account to the `to` account. 

The parameters `from` and `to` MUST be 20-byte addresses. If not, this method SHOULD `throw` an exception.<br/>

The parameter `amount` MUST be greater than or equal to `0`. If not, this method SHOULD `throw` an exception.<br/>

The function MUST return `false` if the `from` account balance does not have enough tokens to spend.<br/>

If the method succeeds, it MUST fire the `Transfer` event, and MUST return `true`, even if the `amount` is `0`, or `from` and `to` are the same address.<br/>

The function SHOULD check whether the `from` address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL `Neo.Runtime.CheckWitness` to verify the transfer.<br/>

If the transfer is not processed, the function MUST return `false`.

If the receiver is a deployed contract, the function MUST call `onNEP17Payment` method on receiver contract with the `data` parameter from `transfer` AFTER firing the `Transfer` event. If the receiver doesn't want to receive this transfer it MUST call `ABORT`. 

**Transfer Event**

    {
      "name": "Transfer",
      "parameters": [
        {
          "name": "from",
          "type": "Hash160"
        },
        {
          "name": "to",
          "type": "Hash160"
        },
        {
          "name": "amount",
          "type": "Integer"
        }
      ]
    }

MUST trigger when tokens are transferred, including zero value transfers and self-transfers. <br/>

A token contract which creates new tokens MUST trigger a `Transfer` event with the `from` address set to `null` when tokens are created.<br/>

A token contract which burns tokens MUST trigger a `Transfer` event with the `to` address set to `null` when tokens are burned.

NEP17 methods are as follows. For the complete code refer to [NEP-17 contract code](https://github.com/neo-project/examples/tree/master/csharp/NEP17).

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;
using System;
using System.Numerics;

namespace Template.NEP17.CSharp
{
    public partial class NEP17 : SmartContract
    {
        public static BigInteger TotalSupply() => TotalSupplyStorage.Get();

        public static BigInteger BalanceOf(UInt160 account)
        {
            if (!ValidateAddress(account)) throw new Exception("The parameters account SHOULD be a 20-byte non-zero address.");
            return AssetStorage.Get(account);
        }

        public static bool Transfer(UInt160 from, UInt160 to, BigInteger amount, object data)
        {
            if (!ValidateAddress(from) || !ValidateAddress(to)) throw new Exception("The parameters from and to SHOULD be 20-byte non-zero addresses.");
            if (amount <= 0) throw new Exception("The parameter amount MUST be greater than 0.");
            if (!Runtime.CheckWitness(from) && !from.Equals(ExecutionEngine.CallingScriptHash)) throw new Exception("No authorization.");
            if (AssetStorage.Get(from) < amount) throw new Exception("Insufficient balance.");
            if (from == to) return true;

            AssetStorage.Reduce(from, amount);
            AssetStorage.Increase(to, amount);

            OnTransfer(from, to, amount);

            // Validate payable
            if (IsDeployed(to)) Contract.Call(to, "onNEP17Payment", new object[] { from, amount, data });
            return true;
        }
    }
}
```

## NEP-17 changes

This section summaries NEP-17 changes compared to the previous NEP-5 protocol.  

### onNEP17Payment

- The Transfer method should determine if the recipient is the deployed contract, and if so, call its `onNEP17Payment` method.

- The FungibleToken (NeoToken, GasToken) of the native contract calls the `onNEP17Tokens` method when transferring assets. The NonfungibleToken calls the `onNEP11Tokens` method when transferring assets.

- The TokenSale contract should implement the `onNEP17Payment` method to receive assets and modify the Manifest file to trust the received asset contract.


### name method

The name method is moved to the manifest file, and you need to add `[DisplayName("Token Name")]` when writing the contract.

```c#
[DisplayName("Token Name")]
[ManifestExtra("Author", "Neo")]
[ManifestExtra("Email", "dev@neo.org")]
[ManifestExtra("Description", "This is a NEP17 example")]
[SupportedStandards("NEP-17")]
public partial class NEP17 : SmartContract
{
    [DisplayName("Transfer")]
    public static event Action<UInt160, UInt160, BigInteger> OnTransfer;

    public static string Symbol() => "TokenSymbol";

    public static ulong Decimals() => 8;
    
    //……
}
```

### Transfer event

The transfer event is changed to Transfer event (first letter capitalized).

### IsPayable

In Neo Legacy, you should check the IsPayable checkbox when deploying contracts to receive NEP-5 assets.

In Neo N3.x, the payable check has been removed and the corresponding logic has been placed in the `onNEP17Payment` method.

The ability of the contract to receive assets has been changed from a fixed constant to the code logic within the contract.