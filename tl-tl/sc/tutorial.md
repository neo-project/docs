# Tutoryal para sa NEO smart contract 

Pagkatapos basahin ang mga nakaraang mga tutoryal, dapat mo na ngayong magamit ang C# sa loob ng Visual Stuio 2015 o 2017 para lumikha ng isang smart contract na proyekto. Dito, tatalakayin natin kong paano ini-eksekyut ang mga smart contract sa NeoVM (Neo Virtual Machine).

## Mga nagpapasimula ng smart contract

Mayroong dalawang paraan para umpisahan ang mga smart contract:

1. Contract User Authentication: Dito ang mga smart contract ay isang kontrata na account. Kung ang user ay hihiling na gumamit ng kontrata na account sa isang asset, ito ay magpapasimula sa smart contract.

2. Mano-manong pagtawag sa isang smart contract: Dito, ang user ay magpapadala ng isang transaksyon (Invocation Transaction) para simulan ang implementasyon ng isang smart contract.

## NeoVM

Ang NeoVM ay isang bertuwal na makina na umi-eksekyut ng NEO smart contract na code. Ang pinag-uusapan natin ay tungkol sa limitadong konsepto ng bertuwal na makina, hindi tungkol sa mga  operating system o mga program na nakakasimulate nito tulad ng VMware o Hyper-V.

Halimbawa, sa Java JVM o .NET CLR, ang mga source code ay i-cocompile sa nauugnay na bytecode at ipapagana sa nararapat na bertuwal na makina. Ang JVM o CLR ay magpapatakbo ng bytecode, na kaparehas lang sa pagpapatakbo ng mga instruksyon sa isang pisikal na makina. Kapansin-pansin, na ang nararapat na binary na instruksyon ay pinapatakbo pa rin sa pisikal na makina. Ang pisikal na makina ay kukuha ng mga instruksyon galing sa memorya, ililipat ito patungo sa CPU gamit ang bus, tapos idedecode, i-eeksekyut, at itatabi ang resulta.

### Ang arkitektura ng virtual na makina

   ![](../../assets/neo-vm.jpg)

Ang dayagram sa itaas ay ang system architecture diagram ng Neo Virtual Machine (NeoVM), kung saan ang pag-deploy sa loob ng dashed na kahon ay ang core ng bertuwal na makina.

#### Execution engine

Ang berde na nasa kaliwa ay ang Virtual Machine execution engine (ang katumbas ng CPU).  Ito ay maaaring mag-eksekyut ng mga karaniwang instruksyon tulad ng flow na kontrol, mga stack na operasyon, mga bit na operasyon, mga aritmetika na operasyon, mga lohikal na operasyon, mga cryptograpik na method, at iba pa. Ito ay maaari ring makipag-ugnayan sa Interoperable service na layer (na inilalarawan sa ibaba) sa pamamagitan ng mga pagtawag sa sistema.

#### Evaluation na stack

The middle gray part of the the bertuwal na makina is the Evaluation Stack (it is equivalent to memory). These days there are two ways to achieve a bertuwal na makina 1) stack based and 2) register based. Both ways have their own advantages and disadvantages, and both have their own great implementation examples. There are stack-based virtual machines like JVM, CPython, and the .NET CLR. On the other side there are register-based VMs, such as Dalvik and Lua5.0. Stack-based virtual machines have a computing stack concept that allows virtual machines to interact directly with the stack (Evaluation Stack) when performing real operations.

Since the default behavior of a stack based VM is to fetch data from the operand stack, there is no need to specify an operand. Contrast this to for example the following x86 assembly `"ADD EAX, EBX"`. This operation requires you to specify the source operands and destination of the result. Stack-based bertuwal na makina instructions do not need to specify these parameters. For example, the addition of a simple "ADD" operation will operate directly on the operand stack. The data can be popped of directly and the result is stored at the stop of the stack.

#### Interoperable service layer

The blue part on the right side is the interoperable service layer of the bertuwal na makina (equivalent to the peripherals). At present, the interoperable service layer provides some APIs for accessing the chain-chain data of the smart contract. It can access block information, transaction information, contract information, asset information, and so on.

In addition, the interoperable service layer also provides a persistent storage area for each contract. Each of the smart contracts is optionally created with private storage, which is in the form of a key-value object determined by the callee of the contract rather than the context of the persistent store. The caller needs to pass their own storage context to the callee (to complete the authorization) before the caller can perform read and write operations.

### Charge mode

A smart contract can be programmed to charge a certain fee, divided into deployment costs and execution costs.

Deployment costs refers to the need for a developer to pay a fee to deploy a smart contract on the block chain (currently 500 GAS). Execution costs refers to the fee the user pays for execution of the smart contract. All operations have a costs, with most operations defaulting to 0.001 GAS. The first 10 GAS is free. Priority processing can be achieved by manually increasing the execution fee. Read more about smart contract fees [here](systemfees.md#smart-contract-fees).

## A simple smart contract

Here are some simple smart contracts:

```c#
public static bool Main ()
{
    return true;
}
```

Here the return value of the contract is always true, indicating that anyone can spend the contract address of the assets (can be understood as money).

The NEO wallet client has a function for deleting an asset. When you delete an asset, the asset is sent to a specified address being the contract address generated by the above smart contract. Anyone can spend the assets in the address. The assets in the address are assets that others do not want.

```c#
public static bool Main ()
{
    return false
}
```

The return value of the contract is always `false`, indicating that the assets of this contract can not be used (this can be interpreted as burning or destroying an asset). Such a contract can for example be applied for shares of a company that have  been written off/canceled.

For more examples please see:

[Hello World](tutorial/HelloWorld.md)

[Lock (lock)](tutorial/lock.md)

[Domain (Domain Name System)](tutorial/Domain.md)
