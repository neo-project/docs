# NEP-17

The NEP-17 proposal is a replacement of the original NEP5 proposal, which outlines a token standard for the Neo blockchain that will provide systems with a generalized interaction mechanism for tokenized Smart Contracts. 

NEP17 assets are recorded in the contract storage area, through updating account balance in the storage area, to complete the transaction.

In the method definitions below, we provide both the definitions of the functions as they are defined in the contract as well as the invoke parameters.

**totalSupply**    

```c#
public static BigInteger totalSupply()
```

Returns the total token supply deployed in the system.

**symbol**

```c#
public static string symbol()
```

Returns a short string symbol of the token managed in this contract. e.g. "MYT". 

This symbol must be a valid ASCII string, with no whitespace characters or new-lines, and should be short (3-8 characters is recommended) uppercase latin alphabet (i.e. the 26 letters used in English).

This method MUST always return the same value every time it is invoked.

**decimals**

```c#
public static byte decimals()
```

Returns the number of decimals used by the token - e.g. 8, means to divide the token amount by 100,000,000 to get its user representation.

This method MUST always return the same value every time it is invoked.

**balanceOf**

```c#
public static BigInteger balanceOf(byte[] account)
```

Returns the token balance of the `account`.

The parameter `account` must be a 20-byte address. If not, this method should throw an exception.

If the `account` is an unused address, this method must return 0.

**transfer**

```c#
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```

The parameters `from` and `to` should be 20-byte addresses. If not, this method should throw an exception.<br/>

The parameter amount must be greater than or equal to 0. If not, this method should throw an exception.<br/>

The function must return false if the `from` account balance does not have enough tokens to spend.<br/>

If the method succeeds, it must fire the `Transfer` event, and must return `true`, even if the `amount` is 0, or `from` and `to` are the same address.<br/>

The function SHOULD check whether the `from` address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL `Neo.Runtime.CheckWitness` to verify the transfer.<br/>

If the transfer is not processed successfully, the function must return `false`.

If `to` is the address hash of a deployed contract, the function must invoke the `onPayment` method of the contract after triggering the `Transfer` event. If the contract `to` does not want to receive the transfer, it must invoke the opcode `ABORT`.

**Transfer Event**

```c#
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

This event MUST be triggered when tokens are transferred, including the case where `amount` is 0 and `from` and `to` are the same address.<br/>

A token contract which creates new tokens MUST trigger a `Transfer` event with the `from` address set to null when tokens are created.<br/>

A token contract which burns tokens MUST trigger a `Transfer` event with the `to` address set to null when tokens are burned.

NEP17 methods are as follows. For the complete code refer to [NEP-17 contract code](https://github.com/neo-project/examples/tree/37487a324b4be695af422f37d668e15a05d75e1e/csharp/NEP17).

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
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
            if (IsDeployed(to)) Contract.Call(to, "onPayment", new object[] { from, amount, data });
            return true;
        }
    }
}
```

