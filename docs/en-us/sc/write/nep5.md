# NEP-5

The NEP-5 proposal outlines a token standard for the NEO blockchain that will provide systems with a generalized interaction mechanism for tokenized Smart Contracts. 

Different from UTXO, the NEP5 assets are recorded in the contract storage area, through updating account balance in the storage area, to complete the transaction.

In the method definitions below, we provide both the definitions of the functions as they are defined in the contract as well as the invoke parameters.

**totalSupply**    

```c#
public static BigInteger totalSupply()
```

Returns the total token supply deployed in the system.

**name**    
```c#
public static string name()
```

Returns the name of the token. e.g. "MyToken".

This method MUST always return the same value every time it is invoked.

**symbol**

```c#
public static string symbol()
```

Returns a short string symbol of the token managed in this contract. e.g. "MYT". This symbol SHOULD be short (3-8 characters is recommended), with no whitespace characters or new-lines and SHOULD be limited to the uppercase latin alphabet (i.e. the 26 letters used in English).

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

The parameter `account` SHOULD be a 20-byte address. If not, this method SHOULD throw an exception.

If the `account` is an unused address, this method MUST return 0.

**transfer**

```c#
public static bool transfer(byte[] from, byte[] to, BigInteger amount)
```

Transfers an amount of tokens from the from account to the to account.<br/>

The parameters from and to SHOULD be 20-byte addresses. If not, this method SHOULD throw an exception.<br/>

The parameter amount MUST be greater than or equal to 0. If not, this method SHOULD throw an exception.<br/>

The function MUST return false if the from account balance does not have enough tokens to spend.<br/>

If the method succeeds, it MUST fire the transfer event, and MUST return true, even if the amount is 0, or from and to are the same address.<br/>

The function SHOULD check whether the from address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL `Neo.Runtime.CheckWitness` to verify the transfer.<br/>

If the to address is a deployed contract, the function SHOULD check the payable flag of this contract to decide whether it should transfer the tokens to this contract.<br/>

If the transfer is not processed, the function SHOULD return false.


**Transfer Event**

```c#
public static event transfer(byte[] from, byte[] to, BigInteger amount)
```

MUST trigger when tokens are transferred, including zero value transfers.<br/>

A token contract which creates new tokens MUST trigger a `transfer` event with the from address set to null when tokens are created.<br/>

A token contract which burns tokens MUST trigger a `transfer` event with the to address set to null when tokens are burned.