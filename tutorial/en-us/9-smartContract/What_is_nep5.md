---
layout: post
lang: en
lang-ref: What_is_nep5
---

#  NEP-5 contract

>
> **Objective**:  Learn the general idea of NEP5
>
> **Main points**:
>
> 1. What is NEP (NEO Enhancement Proposals)
>
> 2. The detail of NEP5
>

## What is NEP?
NEP stands for NEO Enhancement Proposal. An NEP is a design document providing information to the NEO community, or describing a new feature for NEO or its processes or environment. The NEP should provide a concise technical specification of the feature and a rationale for the feature. The NEP author is responsible for building consensus within the community and documenting dissenting opinions. There is already more then 10 NEPS in this [github repository](https://github.com/neo-project/proposals)

For NEO implementers, NEPs are a convenient way to track the progress of their implementation. Ideally each implementation maintainer would list the NEPs that they have implemented. This will give end users a convenient way to know the current status of a given implementation or library.

If someone are interested in proposing a new NEP, first review [NEP-1](https://github.com/neo-project/proposals/blob/master/nep-1.mediawiki), then clone the repository and add your NEP to it. There is a template NEP here. Then submit a Pull Request to this repository.

## Introduction to NEP-5

The NEP-5 standard is a token standard which represents a tokenized smart contract. This standard can regulated the token which is issued on the NEO blockchain. A standard method for interacting with these tokens relieves the entire ecosystem from maintaining a definition for basic operations that are required by every Smart Contract that employs a token.

In NEP-5 standard, you have some methods and trigger one event


### Methods

#### totalSupply

```csharp
public static BigInteger totalSupply()
```

Returns the total token supply deployed in the system.

#### name

```csharp
public static string name()
```

Returns the name of the token. e.g. <code>"MyToken"</code>.

This method MUST always return the same value every time it is invoked.

#### symbol

```csharp
public static string symbol()
```

Returns a short string symbol of the token managed in this contract. e.g. <code>"MYT"</code>. This symbol SHOULD be short (3-8 characters is recommended), with no whitespace characters or new-lines and SHOULD be limited to the uppercase latin alphabet (i.e. the 26 letters used in English).

This method MUST always return the same value every time it is invoked.

#### decimals

```csharp
public static byte decimals()
```


Returns the number of decimals used by the token - e.g. <code>8</code>, means to divide the token amount by <code>100,000,000</code> to get its user representation.

This method MUST always return the same value every time it is invoked.

#### balanceOf

```csharp
public static BigInteger balanceOf(byte[] account)
```

Returns the token balance of the <code>account</code>.

The parameter <code>account</code> SHOULD be a 20-byte address. If not, this method SHOULD <code>throw</code> an exception.

If the <code>account</code> is an unused address, this method MUST return <code>0</code>.

#### transfer
```csharp
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```

Transfers an <code>amount</code> of tokens from the <code>from</code> account to the <code>to</code> account.

The parameters <code>from</code> and <code>to</code> SHOULD be 20-byte addresses. If not, this method SHOULD <code>throw</code> an exception.

The parameter <code>amount</code> MUST be greater than or equal to <code>0</code>. If not, this method SHOULD <code>throw</code> an exception.

The function MUST return <code>false</code> if the <code>from</code> account balance does not have enough tokens to spend.

If the method succeeds, it MUST fire the <code>transfer</code> event, and MUST return <code>true</code>, even if the <code>amount</code> is <code>0</code>, or <code>from</code> and <code>to</code> are the same address.

The function SHOULD check whether the <code>from</code> address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL <code>Neo.Runtime.CheckWitness</code> to verify the transfer.

If the <code>to</code> address is a deployed contract, the function SHOULD check the <code>payable</code> flag of this contract to decide whether it should transfer the tokens to this contract.

If the transfer is not processed, the function SHOULD return <code>false</code>.

### Events
#### transfer
```csharp
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

MUST trigger when tokens are transferred, including zero value transfers.

A token contract which creates new tokens MUST trigger a <code>transfer</code> event with the <code>from</code> address set to <code>null</code> when tokens are created.

A token contract which burns tokens MUST trigger a <code>transfer</code> event with the <code>to</code> address set to <code>null</code> when tokens are burned.

## Next Step
Now let us [implement a NEP5-Token!](Implementation_of_NEP5.md)

If you want to learn the knowledge points of smart contract, click [here](Smart_Contract_basics.md).

