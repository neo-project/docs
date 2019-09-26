

## What is a non-fungible token?

A non-fungible token (NFT) can be thought of like a property deed - each one is unique and carries some non-mutable information (e.g. the physical address of the property) although other information, such as the owner of the property can be changed. An NFT smart contract is useful to track ownership of real-world items, as well as in online gaming, allowing users to posess unique characters or items of a limited supply, that can be transferred between users without requiring the permission of the game owner.

The NFT proposal standard for the Neo Smart Economy is currently in development. This is example in C# showing how such a smart contract might be written. There is some overlap between NEP-5 (fungible) token functionality to make adoption easier by API writers.


### Methods

#### name

```csharp
public static string name()
```

Returns the name of the token. e.g. <code>"MyNFT"</code>. 

This method MUST always return the same value every time it is invoked. 

#### symbol

```csharp
public static string symbol()
```

Returns a short string symbol of the token managed in this contract. e.g. <code>"MNFT"</code>. This symbol SHOULD be short (3-8 characters is recommended), with no whitespace characters or new-lines and SHOULD be limited to the uppercase latin alphabet (i.e. the 26 letters used in English). 

This method MUST always return the same value every time it is invoked. 

#### totalSupply

```csharp
public static BigInteger totalSupply()
```

Returns the total token supply deployed in the system.

#### decimals

```csharp
public static byte decimals()
```

Returns the number of decimals used by the token - e.g. <code>8</code>, means to divide the token amount by <code>100,000,000</code> to get its user representation.

If the token managed in this contract is indivisible, the function SHOULD return <code>0</code>.

If the function returns a non-zero value, all of the ''OPTIONAL'' methods in this standard MUST be implemented.

This method MUST always return the same value every time it is invoked. 

#### tokens

```csharp
public static enumerator tokens()
```

Returns an <code>enumerator</code> that contains all the tokens that have been issued in this contract.

#### transfer

```csharp
public static bool transfer(byte[] to, byte[] tokenid)
```

Transfers token with id <code>tokenid</code> to address <code>to</code>.

The parameter <code>tokenid</code> SHOULD be a valid NFT. If not, this method SHOULD <code>throw</code> an exception.

The parameter <code>to</code> SHOULD be a 20-byte address. If not, this method SHOULD <code>throw</code> an exception.

The function SHOULD return <code>false</code> if the token that will be transferred has more than one owner.

If the method succeeds, it MUST fire the <code>transfer</code> event, and MUST return <code>true</code>, even if the token is sent to the owner himself.

The function SHOULD check whether the owner address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL <code>Neo.Runtime.CheckWitness</code> to verify the transfer.

If the <code>to</code> address is a deployed contract, the function SHOULD check the <code>payable</code> flag of this contract to decide whether it should transfer the tokens to this contract.

If the transfer is not processed, the function SHOULD return <code>false</code>.

```csharp
public static bool transfer(byte[] from, byte[] to, BigInteger amount, byte[] tokenid)
```

''OPTIONAL'': This method MUST be implemented if <code>decimals() > 0</code>.

Transfers an <code>amount</code> of tokens with id <code>tokenid</code> from address <code>from</code> to address <code>to</code>.

The parameter <code>tokenid</code> SHOULD be a valid NFT. If not, this method SHOULD <code>throw</code> an exception.

The parameters <code>from</code> and <code>to</code> SHOULD be 20-byte addresses. If not, this method SHOULD <code>throw</code> an exception.

The parameter <code>amount</code> SHOULD be greater than or equal to <code>0</code> and SHOULD be less than or equal to <code>pow(10, decimals())</code>. If not, this method SHOULD <code>throw</code> an exception.

The function SHOULD return <code>false</code> if the <code>from</code> account balance does not have enough tokens to spend.

If the method succeeds, it MUST fire the <code>transfer</code> event, and MUST return <code>true</code>, even if the <code>amount</code> is <code>0</code>, or the token is sent to the owner himself.

The function SHOULD check whether the <code>from</code> address equals the caller contract hash. If so, the transfer SHOULD be processed; If not, the function SHOULD use the SYSCALL <code>Neo.Runtime.CheckWitness</code> to verify the transfer.

If the <code>to</code> address is a deployed contract, the function SHOULD check the <code>payable</code> flag of this contract to decide whether it should transfer the tokens to this contract.

If the transfer is not processed, the function SHOULD return <code>false</code>.

#### ownerOf

```csharp
public static enumerator ownerOf(byte[] tokenid)
```

Returns an <code>enumerator</code> that contains all the co-owners that own the specified token.

The parameter <code>tokenid</code> SHOULD be a valid NFT. If not, this method SHOULD <code>throw</code> an exception.

#### tokenURI

```csharp
public static string tokenURI(byte[] tokenid)
```

Returns a distinct Uniform Resource Identifier (URI) for a given asset. The URI data of a token supplies a reference to get more information about a specific token or its data.

The parameter <code>tokenid</code> SHOULD be a valid NFT. If not, this method SHOULD <code>throw</code> an exception.

#### balanceOf

```csharp
public static BigInteger balanceOf(byte[] owner, byte[] tokenid)
```

Returns the balance of the specified token for the specified owner's account.

The parameter <code>tokenid</code> SHOULD be a valid NFT. If not, this method SHOULD <code>throw</code> an exception.

The parameter <code>owner</code> SHOULD be a 20-byte address. If not, this method SHOULD <code>throw</code> an exception.

If the <code>owner</code> is an unused address, or it's not the owner of the specified token, this method SHOULD return <code>0</code>.

#### tokensOfOwner

```csharp
public static enumerator tokensOfOwner(byte[] owner)
```

Returns an <code>enumerator</code> that contains all the tokens owned by the specified address.

The parameter <code>owner</code> SHOULD be a 20-byte address. If not, this method SHOULD <code>throw</code> an exception.

### Events


#### transfer

```csharp
public static event transfer(byte[] from, byte[] to, BigInteger amount, byte[] tokenid)
```

MUST trigger when tokens are transferred, including zero value transfers.

A token contract which creates new tokens SHOULD trigger a <code>transfer</code> event with the <code>from</code> address set to <code>null</code> when tokens are created.
