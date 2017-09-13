# NEO smart contract tutorial

After reading the previous tutorials, you should now be able to use C# in Visual Studio 2015 to create a smart contract project. Here we will discuss how smart contracts are executed on the NeoVM (Neo Virtual Machine).

## Smart contract triggers

There are two ways to trigger smart contracts:

1. Contract User Authentication: Here the smart contract is a contract account, and when the user requests to use the contract account in an asset, it will trigger the smart contract.

2. Manually send a transaction call Smart contract: Here the user sends a transaction (Invocation Transaction) to trigger the implementation of a smart contract.

## The type of smart contract

The smart contract has two base classes, FunctionCode and VerificationCode.

### A smart contract inherited from FunctionCode

The smart contract inherited from FunctionCode can be compiled and distributed to the block chain for use by other users. It is equivalent to the "function" in programming, which can be called by the "main function" (the two intelligent contract calls described above) and can also be called by "other functions" (other intelligent contracts inherited from FunctionCode).

The entry point for the smart contract inherited from FunctionCode is the Main method. The return value can be void, int, or byte. This article is a detailed description of the above code.

Here is a default inherited contract for FunctionCode:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        // The Smart Contract inherited from FunctionCode can be compiled and posted to the block chain for use by other users
    }
}
```

### A smart contract inherited from VerificationCode

The smart contract inherited from VerificationCode can generate a contract address in the wallet client, which triggers the smart contract if the user wants to use an asset in the contract address (the user has sent a transaction using the contract address asset).

When the contract returns a value of true, the validation is passed and the user can spend the asset. When the contract returns a false value, the authentication fails and the user can not spend the asset. The transaction that failed the verification can not be broadcast by another node and will not be confirmed by the consensus node.

Here is an example smart contract inherited from VerificationCode. The return value of the Verify method must be of type` bool`.

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

NeoVM is the virtual machine that executes the NEO smart contract code. We are talking about the concept of virtual machine in the narrow sense, not in reference to operating systems or programs that can simulate them such as Vmware or Hypter-V.

For example, in the java JVM or. Net CLR, source code will be compiled into the relevant bytecode, and then run on the corresponding virtual machine. JVM or CLR will run the bytecode which is similar to running instructions on a real physical machine. Notably, the corresponding binary instructions are still run on a physical machine. The physical machine fetches instructions from memory, transfers it to the CPU via the bus, then decodes, executes, and stores the result.

### Virtual machine architecture

   ![](/assets/neo-vm.jpg)

The above diagram is the system architecture diagram of the Neo Virtual Machine (NeoVM), where the deployment in the dashed box is the core of the virtual machine.

#### Execute engine

The green on the left is the virtual machine execution engine (equivalent to the CPU), which can execute common instructions such as flow control, stack operations, bit operations, arithmetic operations, logical operations, cryptographic methods, and so on. Interoperable service layer (described below) to interact.

#### Calculate stack

The middle part of the gray is the virtual machine computing stack (equivalent to memory), and now the virtual machine to achieve two ways, based on the stack and based on the register, the two ways to achieve their own advantages and disadvantages, but also have the iconic product. Stack-based virtual machines with JVM, CPython, and .Net CLR. Register-based VMs also exist such as Dalvik and Lua5.0. Stack-based virtual machines have a stack stack concept that allows virtual machines to interact directly with the stack when performing real operations.

Since the default is to fetch data from the operand stack, there is no need to specify an operand. For example, x86 assembly "ADD EAX, EBX", you need to specify where the operation from the need to take the operation, where the results stored in the implementation. But stack-based virtual machine instructions do not need to specify these parameters. For example, to add a simple operation the default operands are stored in the operand stack, and we can pop out two data directly from the stack to do addition.

#### Interoperable service layer

The blue part of the right side is the interoperable service layer of the virtual machine (equivalent to the peripherals). At present, the interoperable service layer provides some APIs for accessing the chain-chain data of the smart contract, which can access block information, transaction information, contract information, asset information, and so on.

In addition, the interoperable service layer also provides a persistent storage area for each contract. Each of the smart contracts is optionally created with private storage, which is in the form of a key-value object determined by the callee of the contract, rather than the context of the persistent store. Of course, the caller needs to pass their own storage context to the callee (that is, to complete the authorization), the caller can perform read and write operations.

### Charge mode

A smart contract can programmed to charge a certain fee, divided into deployment costs and implementation costs.

Deployment costs refer to the need for a developer to deploy a smart contract to the chain to pay a fee for the block chain system (currently 500 GAS). With execution costs, the user will pay a fee for the execution of the smart contract (for free).

## A simple smart contract

Here are some simple inheritance from VerificationCode's smart contract

```c#
public static bool Verify ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the contract address of the assets (can be understood as money).

There is a function of deleting an asset in the client's e-wallet client. When you delete an asset, the asset is sent to a specified address, which is the contract address generated by the above smart contract, and anyone can spend the address In the assets, of course, the address of the assets are other people do not want the assets.

```c#
public static bool Verify ()
{
    return false
}
```

The return value of the contract is always false, indicating that the assets of this contract can not be used (can be understood as burn or destroy an asset), such as which can store some of the shares of the company has been canceled.

For more examples please see:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
