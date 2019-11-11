# NeoVM Instructions

## Built-in data types

NeoVM has seven built-in data types:

| Type | Description |
|------|------|
| Boolean |  Implemented as two byte arrays, `TRUE` and `FALSE`.  |
| Integer | Implemented as a `BigInteger` value.  |
| ByteArray |Implemented as a `byte[]`.  |
| Array |  Implemented as a `List<StackItem>`, the `StackItem` is an abstract class, and all the built-in data types are inherited from it. |
| Struct |  Inherited from Array, a `Clone` method is added and `Equals` method is overridden. |
| Map | Implemented as a key-value pair `Dictionary<StackItem, StackItem>`.  |
| InteropInterface |  Interoperable interface |

```c#
// boolean type
private static readonly byte[] TRUE = { 1 };
private static readonly byte[] FALSE = { 0 };

private bool value;
```

## Instructions

NeoVM has implemented 113 instructions (and four unimplemented instructions). The categories are as follows:

| Constant | Flow Control | Stack Operation | String Operation | Logical Operation | Arithmetic Operation | Cryptography | Advanced Data Structure |Stack Isolation| Exception Processing |
| ---- | -------- | ------ | ------ | -------- | -------- | ------ | -------- | ------ | ---- |
| 25 | 9| 16| 5 | 5 | 25 | 7  | 14 | 5 | 2 |

Details of each instruction in each category are introduced as follows.

### Constant

The constant instructions mainly complete the function of pushing constants or arrays into the `EvaluationStack`.

#### PUSH0

| Instruction   | PUSH0                                 |
|--------|----------|
| Bytecode: | 0x00                                  |
| Alias: |   `PUSHF`                |
| Function: | Push an empty array into the `EvaluationStack`  |

#### PUSHBYTES

| Instruction   | PUSHBYTES1\~PUSHBYTES75                                    |
|----------|-----------------------------|
| Bytecode: | 0x01\~0x4B                                                 |
| Function:   | Push a byte array into the `EvaluationStack`, the length of which is equal to the value of this instruction's bytecode. |

#### PUSHDATA

| Instruction   | PUSHDATA1, PUSHDATA2, PUSHDATA4                                   |
|----------|---------------------------------------|
| Bytecode: | 0x4C, 0x4D, 0x4E                                                  |
| Function:   | Push a byte array into the `EvaluationStack`, the length of which is specified by 1\|2\|4 bytes after this instruction.  |

#### PUSHM1
| Instruction   | PUSHM1                                   |
|----------|------------------------------------------|
| Bytecode: | 0x4F                                     |
| Function:   | Push a BigInteger of `-1` into the `EvaluationStack`. |

#### PUSHN
| Instruction   | PUSH1\~PUSH16                               |
|----------|---------------------------------------------|
| Bytecode: | 0x51\~0x60                                  |
| Alias:   |  `PUSHT`    |
| Function:   | Push a BigInteger into the `EvaluationStack`, the value of which is equal to 1\~16. |

### Flow Control

It's used to control the execution process of NeoVM, including jump, call and other instructions.

#### NOP

| Instruction   | NOP                                         |
|----------|---------------------------------------------|
| Bytecode: | 0x61                                        |
| Function:   | Empty operation, but it will add 1 to the instruction counter. |

#### JMP

| Instruction   | JMP                                                     |
|----------|---------------------------------------------------------|
| Bytecode: | 0x62                                                    |
| Function:   | Jump to the specified offset unconditionally, which is specified by 2 bytes after this instruction. |

#### JMPIF

| Instruction   | JMPIF                                                                                                                |
|----------|-------------------------------------------------------------|
| Bytecode: | 0x63      |
| Function:   | When the top element of the `EvaluationStack` isn't 0, then jump to the specified offset, which is specified by 2 bytes after this instruction.<br> Whether the condition is true or false, the top element of the stack will be removed.  |

#### JMPIFNOT

| Instruction   | JMPIFNOT                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode: | 0x64                                                               |
| Function:   | When the top element of the `EvaluationStack` is 0, then jump to the specified offset, which is specified by 2 bytes after this instruction. |

#### CALL

| Instruction   | CALL                                                  |
|----------|-------------------------------------------------------|
| Bytecode: | 0x65                                                  |
| Function:   | Call the function at the specified offset, which is specified by 2 bytes after this instruction.  |

#### RET

| Instruction   | RET                                                                                              |
|----------|--------------------------------------------------------------------------------------------------|
| Bytecode: | 0x66                                                                                             |
| Function:   | Remove the top element of the `InvocationStack` and set the instruction counter point to the next frame of the stack.<br> If the `InvocationStack` is empty, the virtual machine enters `HALT` state.  |

#### APPCALL

| Instruction   | APPCALL                                              |
|----------|------------------------------------------------------|
| Bytecode: | 0x67                                                 |
| Function:   | Call the function with the specified address, which is specified by 20 bytes after this instruction |

#### SYSCALL

| Instruction   | SYSCALL                                                |
|----------|--------------------------------------------------------|
| Bytecode: | 0x68                                                   |
| Function:   | Call the specified interoperable function whose name is specified by the string after this instruction. |

#### TAILCALL

| Instruction   | TAILCALL                                                                                             |
|----------|------------------------------------------------------------------------------------------------------|
| Bytecode: | 0x69                                                                                                 |
| Function:   | Tail call (no longer returning back to the current execution environment after the call).<br> Call the specified interoperable function whose name is specified by the string after this instruction. |

### Stack Operation

It's used to copy, remove and swap the elements of the stack.

#### DUPFROMALTSTACK

| Instruction   | DUPFROMALTSTACK                          |
|--------|------------------------------------------|
| Bytecode: | 0x6A                                     |
| Function:   | Copy the top element of the `AltStack`, and push it into the `EvaluationStack `. |

#### TOALTSTACK

| Instruction   | TOALTSTACK                               |
|----------|------------------------------------------|
| Bytecode: | 0x6B                                     |
| Function:   | Remove the top element of the `EvaluationStack`, and push it into the `AltStack`. |

#### FROMALTSTACK

| Instruction   | FROMALTSTACK                             |
|----------|------------------------------------------|
| Bytecode: | 0x6C                                     |
| Function:   | Remove the top element of the `AltStack`, and push it into the `EvaluationStack`. |

#### XDROP

| Instruction   | XDROP                                              |
|----------|----------------------------------------------------|
| Bytecode: | 0x6D                                               |
| Function:   | Remove the element n at the top of the `EvaluationStack`, and remove the remaining element with index n. |
| Input:   | Xn Xn-1 ... X2 X1 X0 n                             |
| Output:   | Xn-1 ... X2 X1 X0                                  |

#### XSWAP

| Instruction   | XSWAP                                                                   |
|----------|-------------------------------------------------------------------------|
| Bytecode: | 0x72                                                                    |
| Function:   | Remove the element n at the top of the `EvaluationStack`, and swap the remaining element with index 0 and the element with index n. |
| Input:   | Xn Xn-1 ... X2 X1 X0 n                                                  |
| Output:   | X0 Xn-1 ... X2 X1 Xn                                                    |

#### XTUCK

| Instruction   | XTUCK                                                                     |
|----------|---------------------------------------------------------------------------|
| Bytecode: | 0x73                                                                      |
| Function:   |  Remove the element n at the top of the `EvaluationStack`, copy the element with index 0, and insert to the index n.  |
| Input:   | Xn Xn-1 ... X2 X1 X0 n                                                    |
| Output:   | Xn X0 Xn-1 ... X2 X1 X0                                                   |

#### DEPTH

| Instruction   | DEPTH                                  |
|----------|----------------------------------------|
| Bytecode: | 0x74                                   |
| Function:   | Push the number of elements in the `EvaluationStack` into the top of the `EvaluationStack`. |

#### DROP

| Instruction   | DROP                   |
|----------|------------------------|
| Bytecode: | 0x75                   |
| Function:   | Remove the top element of the `EvaluationStack` |

#### DUP

| Instruction   | DUP                    |
|----------|------------------------|
| Bytecode: | 0x76                   |
| Function:   | Copy the top element of the `EvaluationStack`, and push it into the `EvaluationStack`. |
| Input:   | X                      |
| Output:   | X X                    |

#### NIP

| Instruction   | NIP                         |
|----------|-----------------------------|
| Bytecode: | 0x77                        |
| Function:   | Remove the second top element of the `EvaluationStack` |
| Input:   | X1 X0                       |
| Output:   | X0                          |

#### OVER 

| Instruction   | OVER                                     |
|----------|------------------------------------------|
| Bytecode: | 0x78                                     |
| Function:   |  Copy the second top element of the `EvaluationStack`, and push it into the `EvaluationStack`. |
| Input:   | X1 X0                                    |
| Output:   | X1 X0 X1                                 |

#### PICK 

| Instruction   | PICK                                                       |
|----------|------------------------------------------------------------|
| Bytecode: | 0x79                                                       |
| Function:   | Remove the element n at the top of the `EvaluationStack`, and copy the element with index n to the top. |
| Input:   | Xn Xn-1 ... X2 X1 X0 n                                     |
| Output:   | Xn Xn-1 ... X2 X1 X0 Xn                                    |

#### ROLL 

| Instruction   | ROLL                                                       |
|----------|------------------------------------------------------------|
| Bytecode: | 0x7A                                                       |
| Function:   | Remove the element n at the top of the `EvaluationStack`, and move the element with index n to the top.  |
| Input:   | Xn Xn-1 ... X2 X1 X0 n                                     |
| Output:   | Xn-1 ... X2 X1 X0 Xn                                       |

#### ROT 

| Instruction   | ROT                                         |
|----------|---------------------------------------------|
| Bytecode: | 0x7B                                        |
| Function:   | Move the third top element of the `EvaluationStack` to the top.  |
| Input:   | X2 X1 X0                                    |
| Output:   | X1 X0 X2                                    |

#### SWAP 

| Instruction   | SWAP                           |
|----------|--------------------------------|
| Bytecode: | 0x7C                           |
| Function:   | Swap the two elements at the top of the `EvaluationStack` |
| Input:   | X1 X0                          |
| Output:   | X0 X1                          |

#### TUCK 

| Instruction   | TUCK                                  |
|----------|---------------------------------------|
| Bytecode: | 0x7D                                  |
| Function:   | Copy the top element of the `EvaluationStack`, and insert to the index 2. |
| Input:   | X1 X0                                 |
| Output:   | X0 X1 X0                              |

### String Operation

#### CAT

| Instruction   | CAT                                              |
|----------|--------------------------------------------------|
| Bytecode: | 0x7E                                             |
| Function:   | Remove the two top elements of the `EvaluationStack`, concat them together and push it back to the `EvaluationStack` |
| Input:   | X1 X0                                            |
| Output:   | Concat(X1,X0)                                    |

#### SUBSTR

| Instruction   | SUBSTR                                       |
|----------|----------------------------------------------|
| Bytecode: | 0x7F                                         |
| Function:   | Remove the three top elements of the `EvaluationStack`, calculate the substring and push it back. |
| Input:   | X index len                                  |
| Output:   | SubString(X,index,len)                       |

#### LEFT

| Instruction   | LEFT                                         |
|----------|----------------------------------------------|
| Bytecode: | 0x80                                         |
| Function:   | Remove the two top elements of the `EvaluationStack`, calculate the left-side substring and push it back. |
| Input:   | X len                                        |
| Output:   | Left(X,len)                                  |

#### RIGHT

| Instruction   | RIGHT                                        |
|----------|----------------------------------------------|
| Bytecode: | 0x81                                         |
| Function:   | Remove the two top elements of the `EvaluationStack`, calculate the right-side substring and push it back. |
| Input:   | X len                                        |
| Output:   | Right(X,len)                                 |

#### SIZE

| Instruction   | SIZE                             |
|----------|----------------------------------|
| Bytecode: | 0x82                             |
| Function:   | Push the length of the top string element to the `EvaluationStack` top.  |
| Input:   | X                                |
| Output:   | X len(X)                         |

### Logical Operation

#### INVERT

| Instruction   | INVERT                       |
|----------|------------------------------|
| Bytecode: | 0x83                         |
| Function:   | Remove the top element, inverse by bit, and push it back to the `EvaluationStack` top.  |
| Input:   | X                            |
| Output:   | \~X                          |

#### AND

| Instruction   | AND                                    |
|----------|----------------------------------------|
| Bytecode: | 0x84                                   |
| Function:   | Remove the two top elements, push the logic AND result of the two elements back to the `EvaluationStack` top. |
| Input:   | AB                                     |
| Output:   | A&B                                    |

#### OR

| Instruction   | OR                                     |
|----------|----------------------------------------|
| Bytecode: | 0x85                                   |
| Function:   | Remove the two top elements, push the logic OR result of the two elements back to the `EvaluationStack` top.  |
| Input:   | AB                                     |
| Output:   | A\|B                                   |

#### XOR

| Instruction   | XOR                                      |
|----------|------------------------------------------|
| Bytecode: | 0x86                                     |
| Function:   | Remove the two top elements, push the logic XOR result of the two elements back to the `EvaluationStack` top.  |
| Input:   | AB                                       |
| Output:   | A\^B                                     |

#### EQUAL

| Instruction   | EQUAL                                        |
|----------|----------------------------------------------|
| Bytecode: | 0x87                                         |
| Function:   | Check whether the top two elements are equivalence bit-by-bit. |
| Input:   | AB                                           |
| Output:   | Equals(A,B)                                  |

### Arithmetic Operation

#### INC

| Instruction   | INC                                |
|----------|------------------------------------|
| Bytecode: | 0x8B                               |
| Function:   | Add 1 to the top element of the `EvaluationStack`.   |
| Input:   | X                                  |
| Output:   | X+1                                |

#### DEC

| Instruction   | DEC                                |
|----------|------------------------------------|
| Bytecode: | 0x8C                               |
| Function:   | Add -1 to the top element of the `EvaluationStack`. |
| Input:   | X                                  |
| Output:   | X-1                                |

#### SIGN

| Instruction   | SIGN                                         |
|----------|----------------------------------------------|
| Bytecode: | 0x8D                                         |
| Function:   | Remove the top element and push the sign of it back to the `EvaluationStack`. |
| Input:   | X                                            |
| Output:   | X.Sign()                                     |

#### NEGATE

| Instruction   | NEGATE                         |
|----------|--------------------------------|
| Bytecode: | 0x8F                           |
| Function:   | Remove the top element and push the opposite number back to the `EvaluationStack`.  |
| Input:   | X                              |
| Output:   | \-X                            |

#### ABS

| Instruction   | ABS                            |
|----------|--------------------------------|
| Bytecode: | 0x90                           |
| Function:   | Remove the top element and push the absolute number back to the `EvaluationStack`.  |
| Input:   | X                              |
| Output:   | Abs(X)                         |

#### NOT

| Instruction   | NOT                                |
|----------|------------------------------------|
| Bytecode: | 0x91                               |
| Function:   | Remove the top element and push the logic "negation" value back to the `EvaluationStack`.  |
| Input:   | X                                  |
| Output:   | !X                                 |

#### NZ

| Instruction   | NZ                                  |
|----------|-------------------------------------|
| Bytecode: | 0x92                                |
| Function:   | Check whether the top element of the `EvaluationStack` is a non-zero value. |
| Input:   | X                                   |
| Output:   | X!=0                                |

#### ADD

| Instruction   | ADD                                    |
|----------|----------------------------------------|
| Bytecode: | 0x93                                   |
| Function:   | The addition operation is performed on the top two elments of the `EvaluationStack`.  |
| Input:   | AB                                     |
| Output:   | A+B                                    |

#### SUB

| Instruction   | SUB                                    |
|----------|----------------------------------------|
| Bytecode: | 0x94                                   |
| Function:   | The subtraction operation is performed on the top two elments of the `EvaluationStack`.    |
| Input:   | AB                                     |
| Output:   | A-B                                    |

#### MUL

| Instruction   | MUL                                    |
|----------|----------------------------------------|
| Bytecode: | 0x95                                   |
| Function:   | The multiplication operation is performed on the top two elments of the `EvaluationStack`.  |
| Input:   | AB                                     |
| Output:   | A\*B                                   |

#### DIV

| Instruction   | DIV                                    |
|----------|----------------------------------------|
| Bytecode: | 0x96                                   |
| Function:  | The division operation is performed on the top two elments of the `EvaluationStack`.   |
| Input:   | AB                                     |
| Output:   | A/B                                    |

#### MOD

| Instruction   | MOD                                    |
|----------|----------------------------------------|
| Bytecode: | 0x97                                   |
| Function:   | The redundancy operation is performed on the top two elments of the `EvaluationStack`.   |
| Input:   | AB                                     |
| Output:   | A%B                                    |

#### SHL

| Instruction   | SHL                              |
|----------|----------------------------------|
| Bytecode: | 0x98                             |
| Function:   | The left-shift operation is performed on the top elment of the `EvaluationStack`.  |
| Instruction   | Xn                               |
| Bytecode: | X\<\<n                           |

#### SHR

| Instruction   | SHR                              |
|----------|----------------------------------|
| Bytecode: | 0x99                             |
| Function:   | The right-shift operation is performed on the top elment of the `EvaluationStack`.  |
| Input:   | Xn                               |
| Output:   | X\>\>n                           |

#### BOOLAND

| Instruction   | BOOLAND                                |
|----------|----------------------------------------|
| Bytecode: | 0x9A                                   |
| Function:   | The logic "and" operation is performed on the top two elments of the `EvaluationStack`. |
| Input:   | AB                                     |
| Output:   | A&&B                                   |

#### BOOLOR

| Instruction   | BOOLOR                                 |
|----------|----------------------------------------|
| Bytecode: | 0x9D                                   |
| Function:   | The logic "or" operation is performed on the top two elments of the `EvaluationStack`.  |
| Input:   | AB                                     |
| Output:   | A\|\|B                                 |

#### NUMEQUAL

| Instruction   | NUMEQUAL                               |
|----------|----------------------------------------|
| Bytecode: | 0x9C                                   |
| Function:   | Check whether the top two Bitintegers of the `EvaluationStack` are equal.   |
| Input:   | AB                                     |
| Output:   | A==B                                   |

#### NUMNOTEQUAL

| Instruction   | NUMNOTEQUAL                              |
|----------|------------------------------------------|
| Bytecode: | 0x9E                                     |
| Function:   | Check whether the top two Bitintegers of the `EvaluationStack` aren't equal.  |
| Input:   | AB                                       |
| Output:   | A!=B                                     |

#### LT 

| Instruction   | LT                                     |
|----------|----------------------------------------|
| Bytecode: | 0x9F                                   |
| Function:   | Check whether the first top element is less than the second top element in the `EvaluationStack`.  |
| Input:   | AB                                     |
| Output:   | A\<B                                   |

#### GT

| Instruction   | GT                                     |
|----------|----------------------------------------|
| Bytecode: | 0xA0                                   |
| Function:   | Check whether the first top element is more than the second top element in the `EvaluationStack`.   |
| Input:   | AB                                     |
| Output:   | A\>B                                   |

#### LTE

| Instruction   | LTE                                        |
|----------|--------------------------------------------|
| Bytecode: | 0xA1                                       |
| Function:   | Check whether the first top element ls less than or equal to the second top element in the `EvaluationStack`.  |
| Input:   | AB                                         |
| Output:   | A\<=B                                      |

#### GTE

| Instruction   | GTE                                        |
|----------|--------------------------------------------|
| Bytecode: | 0xA2                                       |
| Function:   | Check whether the first top element is more than or equal to the second top element in the `EvaluationStack`. |
| Input:   | AB                                         |
| Output:   | A\>=B                                      |

#### MIN

| Instruction   | MIN                                    |
|----------|----------------------------------------|
| Bytecode: | 0xA3                                   |
| Function:   | Calculate the minimum of the two top elements in the `EvaluationStack`.  |
| Input:   | AB                                     |
| Output:   | Min(A,B)                               |

#### MAX

| Instruction   | MAX                                    |
|----------|----------------------------------------|
| Bytecode: | 0xA4                                   |
| Function:   | Calculate the maximum of the two top elements in the `EvaluationStack`. |
| Input:   | AB                                     |
| Output:   | Max(A,B)                               |

#### WITHIN

| Instruction   | WITHIN                                       |
|----------|----------------------------------------------|
| Bytecode: | 0xA5                                         |
| Function:   | Check whether the Biginteger value is within the specified range.  |
| Input:   | XAB                                          |
| Output:   | A\<=X&&X\<B                                  |

### Cryptography

It has implemented hash operation and signature verification and so on.

#### SHA1 

| Instruction   | SHA1                             |
|----------|----------------------------------|
| Bytecode: | 0xA7                             |
| Function:   |  Performs a built-in SHA1 hash operation on the top element in the `EvaluationStack`.  |
| Input:   | X                                |
| Output:   | SHA1(X)                          |

#### SHA256

| Instruction   | SHA256                             |
|----------|------------------------------------|
| Bytecode: | 0xA8                               |
| Function:   | Performs a built-in SHA256 hash operation on the top element in the `EvaluationStack`.。 |
| Input:   | X                                  |
| Output:   | SHA256(X)                          |

#### HASH160

| Instruction   | HASH160                                     |
|----------|---------------------------------------------|
| Bytecode: | 0xA9                                        |
| Function:   | Performs a built-in 160-bit hash operation on the top element in the `EvaluationStack`.  |
| Input:   | X                                           |
| Output:   | HASH160(X)                                  |

#### HASH256

| Instruction   | HASH256                                     |
|----------|---------------------------------------------|
| Bytecode: | 0xAA                                        |
| Function:   |  Performs a built-in 256-bit hash operation on the top element in the `EvaluationStack`. |
| Input:   | X                                           |
| Output:   | HASH256(X)                                  |

#### CHECKSIG

| Instruction   | CHECKSIG                                                                       |
|----------|--------------------------------------------------------------------------------|
| Bytecode: | 0xAC                                                                           |
| Function:   | Using the given signature and public key in the `EvaluationStack`, the built-in asymmetric signaure verfication operation is performed on the current verification object.  |
| Input:   | SK                                                                             |
| Output:   | Verify(S,K)                                                                    |

#### VERIFY

| Instruction   | VERIFY                                                                     |
|----------|----------------------------------------------------------------------------|
| Bytecode: | 0xAD                                                                       |
| Function:   | Using the given signature and public key in the `EvaluationStack`, the built-in asymmetric signaure verfication operation is performed on the given verification object.  |
| Input:   | MSK                                                                        |
| Output:   | Verify(M,S,K)                                                              |

#### CHECKMULTISIG

| Instruction   | CHECKMULTISIG                                                                                  |
|----------|------------------------------------------------------------------------------------------------|
| Bytecode: | 0xAE                                                                             |
| Function:   | Using the given signatures and public keys in the `EvaluationStack`, the built-in asymmetric multi-signaure verfication operation is performed on the current verification object.   |
| Input:   | Sm-1 ... S2 S1 S0 m Kn-1 ... K2 K1 K0 n                              |
| Output:   | Verify(Sm-1 ... S2 S1 S0 m Kn-1 ... K2 K1 K0 n)                             |
| Note:   | For any 𝑆𝑖∈{𝑆0,…, 𝑆𝑚−1}, there exists a 𝐾𝑗∈{𝐾0, … , 𝐾𝑛−1}</br> makes Verify(𝑆𝑖, 𝐾𝑗) ==1, then V=1; otherwise, V=0. |

### Advanced Data Structure

It has implemented common operations for array, map, struct, etc.

#### ARRAYSIZE

| Instruction   | ARRAYSIZE                        |
|----------|----------------------------------|
| Bytecode: | 0xC0                             |
| Function:   | Get the number of elements of the array at the top of the `EvaluationStack`. |
| Input:   | [X0 X1 X2 ... Xn-1]              |
| Output:   | n                                |

#### PACK

| Instruction   | PACK                              |
|----------|-----------------------------------|
| Bytecode: | 0xC1                              |
| Function:   | Pack the n elments at the top of the `EvaluationStack` into array. |
| Input:   | Xn-1 ... X2 X1 X0 n               |
| Output:   | [X0 X1 X2 ... Xn-1]               |

#### UNPACK

| Instruction   | UNPACK                             |
|----------|------------------------------------|
| Bytecode: | 0xC2                               |
| Function:   | Get the number of elements of the array at the top of the `EvaluationStack`.  |
| Input:   | [X0 X1 X2 ... Xn-1]                |
| Output:   | Xn-1 ... X2 X1 X0 n                |

#### PICKITEM

| Instruction   | PICKITEM                           |
|----------|------------------------------------|
| Bytecode: | 0xC3                               |
| Function:   | Get the specified element in the array at the top of the `EvaluationStack`. |
| Input:   | [X0 X1 X2 ... Xn-1] i              |
| Output:   | Xi                                 |

#### SETITEM\*

| Instruction   | SETITEM                                  |
|----------|------------------------------------------|
| Bytecode: | 0xC4                                     |
| Function:   | Assign a value to the specified index element in the array at the top of the `EvaluationStack`. |
| Input:   | [X0 X1 X2 ... Xn-1] I V                  |
| Output:   | [X0 X1 X2 Xi-1 V X i+1 ... Xn-1]         |

#### NEWARRAY

| Instruction   | NEWARRAY                           |
|----------|------------------------------------|
| Bytecode: | 0xC5                               |
| Function:   | Create a new N-size array on the top of the `EvaluationStack`. |
| Input:   | n                                  |
| Output:   | Array(n) with all `false` elements.         |

#### NEWSTRUCT

| Instruction   | NEWSTRUCT                           |
|----------|-------------------------------------|
| Bytecode: | 0xC6                                |
| Function:   | Create a new N-size struct on the top of the `EvaluationStack`. |
| Input:   | n                                   |
| Output:   | Struct(n) with all `false` elements.        |

#### NEWMAP

| Instruction   | NEWMAP                  |
|----------|-------------------------|
| Bytecode: | 0xC7                    |
| Function:   | Create a new map on the top of the `EvaluationStack`.  |
| Input:   |                       |
| Output:   | Map()                   |

#### APPEND\*

| Instruction   | APPEND                |
|----------|-----------------------|
| Bytecode: | 0xC8                  |
| Function:   | Add a new item to the array |
| Input:   | Array item            |
| Output:   | Array.add(item)       |

#### REVERSE\*

| Instruction   | REVERSE             |
|----------|---------------------|
| Bytecode: | 0xC9                |
| Function:   | Reverse the array. |
| Input:   | [X0 X1 X2 ... Xn-1] |
| Output:   | [Xn-1 ... X2 X1 X0] |

#### REMOVE\*

| Instruction   | REMOVE                            |
|----------|-----------------------------------|
| Bytecode: | 0xCA                              |
| Function:   | Remove the specified element from the array or map.     |
| Input:   | [X0 X1 X2 ... Xn-1] m             |
| Output:   | [X0 X1 X2 ... Xm-1 Xm+1 ... Xn-1] |

#### HASKEY

| Instruction   | HASKEY                              |
|----------|-------------------------------------|
| Bytecode: | 0xCB                                |
| Function:   |  Check whether the array or the map contains a specified key element. |
| Input:   | [X0 X1 X2 ... Xn-1] key             |
| Output:   | true or false                       |

#### KEYS

| Instruction   | KEYS                                |
|----------|-------------------------------------|
| Bytecode: | 0xCC                                |
| Function:   | Get all the keys of the map, and put them into a new array. |
| Input:   | Map                                 |
| Output:   | [key1 key2 ... key n]               |

#### VALUES

| Instruction   | VALUES                                  |
|----------|-----------------------------------------|
| Bytecode: | 0xCD                                    |
| Function:   | Get all the values of the array or the map, and put them into a new array. |
| Input:   | Map or Array                              |
| Output:   | [Value1 Value2... Value n]              |

### Stack Isolation

#### CALL_I

| Instruction   | CALL_I                 |
|----------|-----------------------|
| Bytecode: | 0xE0                  |
| Function:   | Call a new execution context, the script is the script of the current execution context,<br> pcount specifies the number of parameters, and rvcount specifies the number of results.<br> Jump to the new execution context. |

#### CALL_E

| Instruction   | CALL_E                 |
|----------|-----------------------|
| Bytecode: | 0xE1                  |
| Function:   | Call a new execution context, the script is specified by the 20-byte hash after the instruction,<br> pcount specifies the number of parameters, and rvcount specifies the number of results.<br> Jump to the new execution context. |

#### CALL_ED

| Instruction   | CALL_ED                 |
|----------|-----------------------|
| Bytecode: | 0xE2                  |
| Function:   | Call a new execution context, the script is specified by the Hash at the top of the evaluation stack,<br> pcount specifies the number of parameters, and rvcount specifies the number of results.<br> Jump to the new execution context. |

#### CALL_ET

| Instruction   | CALL_ET                 |
|----------|-----------------------|
| Bytecode: | 0xE3                  |
| Function:   | The tail call form of CALL_E. |

#### CALL_EDT

| Instruction   | CALL_EDT                 |
|----------|-----------------------|
| Bytecode: | 0xE4                 |
| Function:   | The tail call form of CALL_ED. |

### Exception Processing

#### THROW

| Instruction   | THROW                 |
|----------|-----------------------|
| Bytecode: | 0xF0                  |
| Function:   | Set the virtual machine state to `FAULT` |

#### THROWIFNOT

| Instruction   | THROWIFNOT                                                       |
|----------|------------------------------------------------------------------|
| Bytecode: | 0xF1                                                             |
| Function:   | Read a boolean value from the top of the stack, and if it's False, then set the virtual machine state to `FAULT`. |

> [!Note]
>
> The operation code with \* indicates that the result of the operation is not pushed back to the `EvaluationStack` using `PUSH()`.
