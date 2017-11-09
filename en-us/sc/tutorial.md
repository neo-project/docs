# NEO smart contract tutorial

After reading the previous tutorials, you should now be able to use C# in Visual Studio 2015 or 2017 to create a smart contract project. Here we will discuss how smart contracts are executed on the NeoVM (Neo Virtual Machine).

## Smart contract triggers

There are two ways to trigger smart contracts:

1. Contract User Authentication: Here the smart contract is a contract account. When the user requests to use the contract account in an asset, it will trigger the smart contract.

2. Manually call a smart contract: Here the user sends a transaction (Invocation Transaction) to trigger the implementation of a smart contract.

## The type of smart contract

The smart contract has two base classes, FunctionCode and VerificationCode.

### A smart contract inherited from FunctionCode

The smart contract inherited from `FunctionCode` can be compiled and distributed to the block chain for use by other users. It is equivalent to a "function" in programming, which can be called by the "Main function" (the two types of smart contract calls mentioned above). It can also be called by "other functions" (being other smart contracts inherited from `FunctionCode`).

The entry point for the smart contract inherited from `FunctionCode` is the `Main()` method. The return value can be void, int, or byte. This article is a detailed description of the above code.

Here is a default inherited contract for FunctionCode:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method is capitalized
    {
        // The Smart Contract inherited from FunctionCode can be compiled and posted to the block chain for use by other users
    }
}
```

### A smart contract inherited from VerificationCode

The smart contract inherited from `VerificationCode` can generate a contract address in the wallet client. This address triggers the smart contract if the user wants to use an asset in the contract address (i.e. the user has sent a transaction using the contract address asset).

When the contract returns a value of `true`, the validation is passed and the user can spend the asset. When the contract returns a value of `false`, the authentication fails and the user can not spend the asset. The transaction that failed the verification can not be broadcast by another node and will not be confirmed by the consensus node.

Here is an example smart contract inherited from `VerificationCode`. The return value of the Verify method must be of type `bool`.

```c#
public class Contract1: VerificationCode
{
    public static bool Verify ()
    {
        return true;
    }
}
```

## NeoVM

NeoVM is the virtual machine that executes the NEO smart contract code. We are talking about the concept of virtual machine in the narrow sense, not in reference to operating systems or programs that can simulate them such as VMware or Hyper-V.

For example, in the Java JVM or. Net CLR, source code will be compiled into the relevant bytecode and then run on the corresponding virtual machine. The JVM or CLR will run the bytecode, which is similar to running instructions on a real physical machine. Notably, the corresponding binary instructions are still run on a physical machine. The physical machine fetches instructions from memory, transfers it to the CPU via the bus, then decodes, executes, and stores the result.

### Virtual machine architecture

   ![](/assets/neo-vm.jpg)

The above diagram is the system architecture diagram of the Neo Virtual Machine (NeoVM), where the deployment in the dashed box is the core of the virtual machine.

#### Execution engine

The green on the left is the Virtual Machine execution engine (the equivalent of the CPU). It can execute common instructions such as flow control, stack operations, bit operations, arithmetic operations, logical operations, cryptographic methods, and so on. It can interact with the Interoperable service layer (described below) through system calls.

#### Evaluation stack

The middle gray part of the the virtual machine is the Evaluation Stack (it is equivalent to memory). These days there are two ways to achieve a virtual machine 1) stack based and 2) register based. Both ways have their own advantages and disadvantages, and both have their own great implementation examples. There are stack-based virtual machines like JVM, CPython, and the .Net CLR. On the other side there are register-based VMs such as Dalvik and Lua5.0. Stack-based virtual machines have a computing stack concept that allows virtual machines to interact directly with the stack (Evaluation Stack) when performing real operations.

Since the default behavior of a stack based VM is to fetch data from the operand stack, there is no need to specify an operand. Contrast this to for example the following x86 assembly `"ADD EAX, EBX"`. This operation requires you to specify the source operands and destination of the result. Stack-based virtual machine instructions do not need to specify these parameters. For example, the addition of a simple "ADD" operation will operate directly on the operand stack. The data can be popped of directly and the result is stored at the stop of the stack.

#### Interoperable service layer

The blue part on the right side is the interoperable service layer of the virtual machine (equivalent to the peripherals). At present, the interoperable service layer provides some APIs for accessing the chain-chain data of the smart contract. It can access block information, transaction information, contract information, asset information, and so on.

In addition, the interoperable service layer also provides a persistent storage area for each contract. Each of the smart contracts is optionally created with private storage, which is in the form of a key-value object determined by the callee of the contract rather than the context of the persistent store. The caller needs to pass their own storage context to the callee (to complete the authorization) before the caller can perform read and write operations.

### Charge mode

A smart contract can programmed to charge a certain fee, divided into deployment costs and execution costs.

Deployment costs refers to the need for a developer to pay a fee to deploy a smart contract on the block chain (currently 490 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. Read more about smart contract fees [here](systemfees.md#smart-contract-fees).

## A simple smart contract

Here is a simple inheritance from VerificationCode's smart contract

```c#
public static bool Verify ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the contract address of the assets (can be understood as money).

The NEO wallet client has a function for deleting an asset. When you delete an asset, the asset is sent to a specified address being the contract address generated by the above smart contract. Anyone can spend the assets in the address. The assets in the address are assets that others do not want.

```c#
public static bool Verify ()
{
    return false
}
```

The return value of the contract is always `false`, indicating that the assets of this contract can not be used (this can be interpreted as burning or destroying an asset). Such a contract can for example be applied for shares of a company that have  been written off/canceled.

For more examples please see:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
