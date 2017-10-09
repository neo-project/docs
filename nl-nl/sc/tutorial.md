# NEO smart contract Handleiding

Na het volgen van de voorafgaande tutorials zou je nu in staat moeten zijn een smart contract project aan te maken m.b.v. C# in Visual Studio. Hieronder volgt een uitleg hoe smart contracts worden uitgevoerd door de NeoVM (Neo Virtual Machine).

## Smart contract triggers

Er zijn twee manieren om smart contracts te triggeren:

1. Contract User Authentication: hierbij is het smart contract een contract-account. Wanneer de gebruiker aanvraagt om de contract-account te gebruiken bij een asset, dan wordt het smart-contract getriggerd.

2. Stuur handmatig een transaction call Smart contract: hierbji stuurt de gebruiker een transactie (*Invocation Transaction*) om de implementatie van een smart contract te triggeren.

## Types smart contract

Er zijn twee basis-classes waar smart contracts op gebaseerd kunnen zijn (*inherit*): FunctionCode en VerificationCode.

### Een smart contract gebaseerd op FunctionCode

Een smart contract dat gebaseerd is op FunctionCode kan worden gecompileerd en gedistribueerd naar de blockchain voor gebruik door anderen. Het staat gelijk aan een 'function' in programmeren, welke opgeroepen kan worden door de 'main function' (één van de twee trigger-methodes die hierboven staan beschreven) en door 'other functions' (andere smart contracts die gebaseerd zijn op FunctionCode).

De `entry point` voor de smart contract die gebaseerd is op FunctionCode is de `Main` methode. De waarde van `return` kan `void`, `int` of `byte` zijn. Deze pagina licht bovenstaande code toe.

Hier is een voorbeeldcontract dat gebaseerd is op FunctionCode:

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Let op: de methode met Hoofdletter
    {
        // Het Smart Contract dat gebaseerd is op FunctionCode kan gecompileerd worden en op de blockchain geplaatst worden om door anderen gebruikt te worden
    }
}
```

### Een smart contract gebaseerd op VerificationCode

Een smart contract dat gebaseerd is op VerificationCode kan een contract-adres genereren in de wallet-client. Het smart contract kan worden getriggerd als de gebruiker een asset in het contract-adres wil gebruiken (een transactie).

Als het contract als antwoord `true` geeft, is de bevestiging gelukt en kan de gebruiker de asset uitgeven. Als het contract als antwoord `false` geeft, is de bevestiging mislukt en kan de gebruiker de asset niet spenderen. De mislukte transactie kan niet worden uitgezonden en zal niet worden bevestigd.

Hier is een voorbeeld van een smart contract dat gebaseerd is op VerificationCode. De Verify methode moet als type reactie `bool` hebben.

```c#
public class Contract1: VerificationCode
{
    public static bool Verify () //Hier wordt de return type genoemd (bool)
    {
        return true;
    }
}
```

## NeoVM

NeoVM is de virtual machine die de NEO smart contract-code uitvoert. Dit is niet een volledige VM zoals Vmware of Hypter-V, maar eentje die puur op smart contracts is gericht.

Bijvoorbeeld: in de Java JVM of .NET CLR wordt de broncode gecompileerd tot de bijbehorende bytecode, en vervolgens uitgevoerd op de 

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
