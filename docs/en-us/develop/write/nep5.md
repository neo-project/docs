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

Here is the complete [NEP-5 contract code](https://github.com/neo-ngd/Neo3-Smart-Contract-Examples/blob/master/NEP5/Contract1.cs):

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace NEP5
{
    [Features(ContractFeatures.HasStorage)]
    public class NEP5 : SmartContract
    {
        [DisplayName("Transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        private static readonly BigInteger TotalSupplyValue = 10000000000000000;

        private static readonly byte[] Owner = "NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9".ToScriptHash(); //Owner Address

        private static readonly StorageMap contract = Storage.CurrentContext.CreateMap(nameof(contract));

        private static readonly StorageMap asset = Storage.CurrentContext.CreateMap(nameof(asset));

        public static object Main(string method, object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return Runtime.CheckWitness(Owner);
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                var callscript = ExecutionEngine.CallingScriptHash;

                if (method == "deploy") return Deploy();

                if (method == "balanceOf") return BalanceOf((byte[])args[0]);

                if (method == "decimals") return Decimals();

                if (method == "name") return Name();

                if (method == "symbol") return Symbol();

                if (method == "supportedStandards") return SupportedStandards();

                if (method == "totalSupply") return TotalSupply();

                if (method == "transfer") return Transfer((byte[])args[0], (byte[])args[1], (BigInteger)args[2], callscript);
            }
            return false;
        }

        [DisplayName("deploy")]
        public static bool Deploy()
        {
            if (TotalSupply() != 0) return false;
            
            contract.Put("totalSupply", TotalSupplyValue);
            
            asset.Put(Owner, TotalSupplyValue);
            Transferred(null, Owner, TotalSupplyValue);
            return true;
        }

        [DisplayName("balanceOf")]
        public static BigInteger BalanceOf(byte[] account)
        {
            if (account.Length != 20)
                throw new InvalidOperationException("The parameter account SHOULD be 20-byte non-zero addresses.");
            return asset.Get(account).TryToBigInteger();
        }

        [DisplayName("decimals")]
        public static byte Decimals() => 8;

        private static void onPayment(BigInteger amount)
        {
            SmartContract.Abort();
        }

        [DisplayName("name")]
        public static string Name() => "MyToken"; //name of the token

        [DisplayName("symbol")]
        public static string Symbol() => "MYT"; //symbol of the token

        [DisplayName("supportedStandards")]
        public static string[] SupportedStandards() => new string[] { "NEP-5", "NEP-7", "NEP-10" };

        [DisplayName("totalSupply")]
        public static BigInteger TotalSupply()
        {
            return contract.Get("totalSupply").TryToBigInteger();
        }

#if DEBUG
        [DisplayName("transfer")] //Only for ABI file
        public static bool Transfer(byte[] from, byte[] to, BigInteger amount) => true;
#endif
        //Methods of actual execution
        private static bool Transfer(byte[] from, byte[] to, BigInteger amount, byte[] callscript)
        {
            //Check parameters
            if (from.Length != 20 || to.Length != 20)
                throw new InvalidOperationException("The parameters from and to SHOULD be 20-byte addresses.");
            if (amount <= 0)
                throw new InvalidOperationException("The parameter amount MUST be greater than 0.");
            if (!Runtime.CheckWitness(from) && from.TryToBigInteger() != callscript.TryToBigInteger())
                return false;
            var fromAmount = asset.Get(from).TryToBigInteger();
            if (fromAmount < amount)
                return false;
            if (from == to)
                return true;

            //Reduce payer balances
            if (fromAmount == amount)
                asset.Delete(from);
            else
                asset.Put(from, fromAmount - amount);

            //Increase the payee balance
            var toAmount = asset.Get(to).TryToBigInteger();
            asset.Put(to, toAmount + amount);

            Transferred(from, to, amount);

            // Validate payable
            if (Blockchain.GetContract(to) != null) Contract.Call(to, "onPayment", new object[] { amount });
            return true;
        }
    }

    public static class Helper
    {
        public static BigInteger TryToBigInteger(this byte[] value)
        {
            return value?.ToBigInteger() ?? 0;
        }
    }
}
```

