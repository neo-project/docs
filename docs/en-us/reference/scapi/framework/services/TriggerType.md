# TriggerType Enumeration

This enumeration represents the type of smart contract triggers. Triggers enable the contract to execute different logic under different usage scenarios.

For more information about triggers, refer to [Smart Contract Basics](../../../../../develop/write/basics.md).

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum TriggerType : byte
    {
        System = 0x01,
        Verification = 0x20,
        Application = 0x40,
        All = System | Verification | Application
    }
```

## System trigger

This trigger is currently used only for the native contracts NEO and GAS. When a node receives a new block, it will invokes the onPersist methods for all native contracts before being persisted, and to make the execution continue, the system trigger is required.

This trigger does not affect the execution of an ordinary contract.

## Application trigger

An application trigger is used to invoke the contract as a verification function, which can accept multiple parameters, change the blockchain status, and return values of any type.

Here is a simple C# smart contract:

```c#
    public class Contract1 : SmartContract.Framework.SmartContract
    {
        public static object Test(string operation, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "FunctionA") return FunctionA(args);
            }  
        }
        public static bool FunctionA(params object[] args)
        {
            //Do Something  
        }
    }
```
In Neo N3 all transactions are invocations of contracts. When a transaction is broadcast and confirmed, consensus nodes execute the contract. The success of contract execution does not determine the success of transaction, and vice versa.

## Verification trigger

A Verification trigger is used to call the contract as a verification function, which can accept multiple parameters and should return a valid Boolean value, indicating the validity of the transaction or block.

When you transfer assets from account A to account B, a verification contract that invokes  the Verify method of the contract is triggered. All the nodes that received the transaction (including normal nodes and blue consensus nodes) verify account A's contract. If the return value is true, the transfer is completed successfully. If false is returned, the transfer is failed.

If return `false` , that means the transaction will not be recorded in the blockchain.

Here is a simple example of verification contract, which returns true when the transaction contains signature of the owner account, or returns false when the transfer fails.

```c#
    public class Contract1 : SmartContract.Framework.SmartContract
    {
        public static bool Verify()
        {
            return Runtime.CheckWitness(Owner);
        }
    }
```
