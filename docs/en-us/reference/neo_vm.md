# NeoVM Instructions

## Built-in data types

NeoVM has following built-in data types:

| Type | Description |
|------|------|
| Array | Implemented as a `List<StackItem>`, the `StackItem` is an abstract class, and all the built-in data types are inherited from it. |
| Boolean |  Implemented as two byte arrays, `TRUE` and `FALSE`.  |
| Buffer        | Readonly byte array, implemented as a buffer array `byte[]`  |
| ByteString        | Readonly byte array, implemented as a `ReadOnlyMemory<byte>` |
| Integer | Implemented as a `BigInteger` value.  |
| InteropInterface | Interoperable interface |
| Map | Implemented as a key-value pair `Dictionary<StackItem, StackItem>`.  |
| Null | Null type |
| Pointer    | Implemented as a context `Script` and an instruction `Position` |
| Struct |  Inherited from Array, a `Clone` method is added and `Equals` method is overridden. |

- `CompoundType` : Compound type, which includes  `Array`, `Map` and `Struct`。
- `PrimitiveType`: Basic type which includes `Boolean`, `ByteString` and `Integer`。

```c#
// boolean type
private static readonly byte[] TRUE = { 1 };
private static readonly byte[] FALSE = { 0 };

private bool value;
```

## Instructions

NeoVM has implemented 189 instructions. The categories are as follows:

| Constant | Flow Control | Stack Operation | Slot Operation |String Operation | Logical Operation | Arithmetic Operation | Advanced Data Structure | Type Operation |
| ---- | -------- | ------ | ------ | -------- | -------- | -------- | ---- | ---- |
| 29 | 32 | 15 | 50 | 6 | 6 | 25 | 18 | 3|

Details of each instruction in each category are introduced as follows.

### Constants

The constant instructions mainly complete the function of pushing constants or arrays into the `EvaluationStack`.

#### PUSHINT

| Instruction   | PUSHINT8, PUSHINT16, PUSHINT32, PUSHINT64, PUSHINT128, PUSHINT256                                   |
|----------|---------------------------------------|
| Bytecode | 0x00, 0x01, 0x02, 0x03, 0x04, 0x05                                                  |
| Fee | 0.00000001 GAS, 0.00000001 GAS, 0.00000001 GAS, 0.00000001 GAS, 0.00000004 GAS, 0.00000004 GAS |
| Function   | Push an integer onto the stack, the bit length of which is specified with the number 8\16\32\64\128\256. |

#### PUSHA

| Instruction   | PUSHA                                 |
|----------|----------|
| Bytecode | 0x0A                                  |
| Fee | 0.00000004 GAS             |
| Function | Convert the next four bytes to an address, and push the address onto the stack. |

#### PUSHNULL

| Instruction   | PUSHNULL                                   |
|----------|------------------------------------------|
| Bytecode | 0x0B                                     |
| Fee | 0.00000001 GAS                 |
| Function   | The item `null` is pushed onto the stack. |

#### PUSHDATA

| Instruction   | PUSHDATA1, PUSHDATA2, PUSHDATA4                                   |
|----------|---------------------------------------|
| Bytecode | 0x0C, 0x0D, 0x0E                                                  |
| Fee | 0.00000008 GAS, 0.00000512 GAS, 0.00004096 GAS |
| Function   | The next `n` bytes contain the number of bytes to be pushed onto the stack, where n is specified by 1\|2\|4. |

#### PUSHM1

| Instruction   | PUSHM1                                   |
|----------|------------------------------------------|
| Bytecode | 0x0F                                     |
| Fee | 0.00000001 GAS               |
| Function   | The number -1 is pushed onto the stack. |

#### PUSHN

| Instruction   | PUSH0\~PUSH16                               |
|----------|---------------------------------------------|
| Bytecode | 0x10\~0x20                                  |
| Fee | 0.00000001 GAS                        |
| Function   | The number `n` is pushed onto the stack，where n is specified by 0\~16. |

### Flow Control

It's used to control the running process of NeoVM, including jump, call and other instructions.

#### NOP

| Instruction   | NOP                                         |
|----------|---------------------------------------------|
| Bytecode | 0x21                                        |
| Fee | 0.00000001 GAS                  |
| Function   | The `NOP` operation does nothing. It is intended to fill in space if opcodes are patched. |

#### JMP

| Instruction   | JMP                                                     |
|----------|---------------------------------------------------------|
| Bytecode | 0x22                                                    |
| Fee | 0.00000002 GAS                              |
| Function   | Unconditionally transfers control to a target instruction. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMP_L

| Instruction   | JMP_L                                                     |
|----------|---------------------------------------------------------|
| Bytecode | 0x23                                                    |
| Fee | 0.00000002 GAS                              |
| Function   | Unconditionally transfers control to a target instruction. The target instruction is represented as a 4-bytes signed offset from the beginning of the current instruction.|

#### JMPIF

| Instruction   | JMPIF                                                                                                                |
|----------|----------------------------------------------------------------------------------------------------------------------|
| Bytecode | 0x24                                                                                                                 |
| Fee | 0.00000002 GAS                                                                                           |
| Function   | Transfers control to a target instruction if the value is `true`, not `null`, or non-zero. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction.|

#### JMPIF_L

| Instruction   | JMPIF                                                                                                                |
|----------|----------------------------------------------------------------------------------------------------------------------|
| Bytecode | 0x25                                                                                                                 |
| Fee | 0.00000002 GAS                                                                                           |
| Function   | Transfers control to a target instruction if the value is `true`, not `null`, or non-zero. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPIFNOT

| Instruction   | JMPIFNOT                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x26                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the value is `false`, a `null` reference, or zero. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPIFNOT_L

| Instruction   | JMPIFNOT_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x27                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the value is `false`, a `null` reference, or zero. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPEQ

| Instruction   | JMPEQ                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x28                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if two values are equal. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPEQ_L

| Instruction   | JMPEQ_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x29                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if two values are equal. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPNE

| Instruction   | JMPNE                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2A                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction when two values are not equal. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPNE_L

| Instruction   | JMPNE_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2B                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction when two values are not equal. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPGT

| Instruction   | JMPGT                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2C                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is greater than the second value. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPGT_L

| Instruction   | JMPGT_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2D                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is greater than the second value. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPGE

| Instruction   | JMPGE                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2E                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is greater than or equal to the second value. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPGE_L

| Instruction   | JMPGE_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x2F                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is greater than or equal to the second value. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPLT

| Instruction   | JMPLT                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x30                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is less than the second value. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPLT_L

| Instruction   | JMPLT_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x31                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is less than the second value. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### JMPLE

| Instruction   | JMPLE                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x32                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is less than or equal to the second value. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### JMPLE_L

| Instruction   | JMPLE_L                                                           |
|----------|--------------------------------------------------------------------|
| Bytecode | 0x33                                                               |
| Fee | 0.00000002 GAS                                          |
| Function   | Transfers control to a target instruction if the first value is less than or equal to the second value. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### CALL

| Instruction   | CALL                                                  |
|----------|-------------------------------------------------------|
| Bytecode | 0x34                                                  |
| Fee | 0.00000512 GAS             |
| Function   | Calls the function at the target address which is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### CALL_L

| Instruction   | CALL_L                                                  |
|----------|-------------------------------------------------------|
| Bytecode | 0x35                                                  |
| Fee | 0.00000512 GAS             |
| Function   | Calls the function at the target address which is represented as a 4-bytes signed offset from the beginning of the current instruction. |

#### CALLA

| Instruction   | CALLA                                                  |
|----------|-------------------------------------------------------|
| Bytecode | 0x36                                                  |
| Fee | 0.00000512 GAS             |
| Function   | Pops the address of a function from the stack, and call the function. |

#### CALLT

| Instruction | CALLT                                                        |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x37                                                         |
| Fee         | 0.00032768 GAS                                               |
| Function    | Pops the function Token from the stack, and call the function. |

#### ABORT

| Instruction   | ABORT                                                  |
|----------|-------------------------------------------------------|
| Bytecode | 0x38                                                  |
| Fee | 0 GAS                           |
| Function   | It turns the vm state to FAULT immediately, and the exception cannot be caught. |

#### ASSERT

| Instruction   | ASSERT                                                       |
|----------|------------------------------------------------------------------|
| Bytecode | 0x39                                                             |
| Fee | 0.00000001 GAS                                          |
| Function   | Pop the top value of the stack, if it is false, then exit vm execution and set vm state to FAULT. |

#### THROW

| Instruction   | THROW                 |
|----------|-----------------------|
| Bytecode | 0x3A                  |
| Fee | 0.00000512 GAS                            |
| Function   | Throws the exception of stack top |

#### TRY

| Instruction | TRY                                                          |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x3B                                                         |
| Fee         | 0.00000004 GAS                                               |
| Function    | Enters the block of Try statement. The Catch and Finally address offset are represented as a 1-byte signed offset from the beginning of the current instruction. |

#### TRY_L

| Instruction | TRY_L                                                        |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x3C                                                         |
| Fee         | 0.00000004 GAS                                               |
| Function    | Enters the block of Try statement. The Catch and Finally address offset are represented as a 4-byte signed offset from the beginning of the current instruction. |

#### ENDTRY

| Instruction | ENDTRY                                                       |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x3D                                                         |
| Fee         | 0.00000004 GAS                                               |
| Function    | Terminates the block Try and unconditionally transfers control to a target instruction. The target instruction is represented as a 1-byte signed offset from the beginning of the current instruction. |

#### ENDTRY_L

| Instruction | ENDTRY_L                                                     |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x3E                                                         |
| Fee         | 0.00000004 GAS                                               |
| Function    | Terminates the block Try and unconditionally transfers control to a target instruction. The target instruction is represented as a 4-byte signed offset from the beginning of the current instruction. |

#### ENDFINALLY

| Instruction | ENDFINALLY                                                   |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0x3F                                                         |
| Fee         | 0.00000004 GAS                                               |
| Function    | Terminates the block Finally and goes to the target instruction ENDTRY/ENDTRY_L if there is no exception, or throw the exception to the  upper level again. |

#### RET

| Instruction   | RET                                                                                              |
|----------|--------------------------------------------------------------------------------------------------|
| Bytecode | 0x40                                                                                             |
| Fee | 0 GAS                                                        |
| Function   | Returns from the current method. |

#### SYSCALL

| Instruction   | SYSCALL                                                |
|----------|--------------------------------------------------------|
| Bytecode | 0x41                                                   |
| Fee | 0 GAS                                                        |
| Function   | Calls to an interop service. |
### Stack Operation

Copy, remove and swap the elements of the stack.

#### DEPTH
| Instruction   | DEPTH                          |
|----------|------------------------------------------|
| Bytecode | 0x43                                     |
| Fee | 0.00000002 GAS                                          |
| Function | Puts the number of stack items onto the stack. |

#### DROP

| Instruction   | DROP                   |
|----------|------------------------|
| Bytecode | 0x45                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Removes the top stack item. |

#### NIP

| Instruction   | NIP                               |
|----------|------------------------------------------|
| Bytecode | 0x46                                     |
| Fee | 0.00000002 GAS                                          |
| Function   | Removes the second-to-top stack item. |

#### XDROP

| Instruction   | XDROP                                              |
|----------|----------------------------------------------------|
| Bytecode | 0x48                                               |
| Fee | 0.00000016 GAS                                          |
| Function   | The item n back in the main stack is removed. |
| Function | Gets the integer N from the top stack and removes elements indexed to N from the remaining elements of the stack. |

#### CLEAR

| Instruction   | CLEAR                             |
|----------|------------------------------------------|
| Bytecode | 0x49                                     |
| Fee | 0.00000016 GAS                 |
| Function   | Clear the stack |

#### DUP

| Instruction   | DUP                    |
|----------|------------------------|
| Bytecode | 0x4A                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Copies the top stack item to the top. |

#### OVER

| Instruction   | OVER                    |
|----------|------------------------|
| Bytecode | 0x4B                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Copies the second-to-top stack item to the top. |

#### PICK

| Instruction   | PICK                    |
|----------|------------------------|
| Bytecode | 0x4D                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Gets the integer N from the top stack and copies elements indexed to N from the remaining elements of the stack to the top. |

#### TUCK

| Instruction   | TUCK                    |
|----------|------------------------|
| Bytecode | 0x4E                   |
| Fee | 0.00000002 GAS                                          |
| Function   | The item at the top of the stack is copied and inserted before the second-to-top item. |

#### SWAP

| Instruction   | SWAP                    |
|----------|------------------------|
| Bytecode | 0x50                   |
| Fee | 0.00000002 GAS                                          |
| Function   | The top two items on the stack are swapped. |

#### ROT

| Instruction   | ROT                    |
|----------|------------------------|
| Bytecode | 0x51                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Moves the elements indexed to 2 to the top |

#### ROLL

| Instruction   | ROLL                    |
|----------|------------------------|
| Bytecode | 0x52                   |
| Fee | 0.00000016 GAS                                          |
| Function   | Gets the integer N from the top stack and moves elements indexed to N from the remaining elements of the stack to the top. |

#### REVERSE3

| Instruction   | REVERSE3                    |
|----------|------------------------|
| Bytecode | 0x53                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Reverse the order of the top 3 items on the stack. |

#### REVERSE4

| Instruction   | REVERSE4                    |
|----------|------------------------|
| Bytecode | 0x54                   |
| Fee | 0.00000002 GAS                                          |
| Function   | Reverse the order of the top 4 items on the stack. |

#### REVERSEN

| Instruction   | REVERSEN                    |
|----------|------------------------|
| Bytecode | 0x55                   |
| Fee | 0.00000016 GAS                                          |
| Function   | Gets the integer N from the top stack, and reverse the order of the top N items on the stack. |

### Slot

#### INITSSLOT

| Instruction   | INITSSLOT                                  |
|----------|---------------------------------------|
| Bytecode | 0x56                                  |
| Fee | 0.00000016 GAS                                          |
| Function   | Initialize the static field list for the current execution context. |

#### INITSLOT

| Instruction   | INITSLOT                                  |
|----------|---------------------------------------|
| Bytecode | 0x57                                  |
| Fee | 0.00000064 GAS                                          |
| Function   | Initialize the argument slot and the local variable list for the current execution context. |

#### LDSFLDN

| Instruction   | LDSFLD0\~LDSFLD6                                  |
|----------|---------------------------------------|
| Bytecode | 0x58\~0x5E                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the static field at index `n` onto the evaluation stack, where the n is 0\~6。 |

#### LDSFLD

| Instruction   | LDSFLD                                  |
|----------|---------------------------------------|
| Bytecode | 0x5F                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the static field at a specified index onto the evaluation stack. The index is represented as a 1-byte unsigned integer. |

#### STSFLDN

| Instruction   | STSFLD0\~STSFLD6                                  |
|----------|---------------------------------------|
| Bytecode | 0x60\~0x0x66                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the static field list at index `n`, where the n is 0\~6。 |

#### STSFLD

| Instruction   | STSFLD                                  |
|----------|---------------------------------------|
| Bytecode | 0x67                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the static field list at a specified index. The index is represented as a 1-byte unsigned integer. |

#### LDLOCN

| Instruction   | LDLOC0\~LDLOC6                                  |
|----------|---------------------------------------|
| Bytecode | 0x68\~0x6E                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the local variable at index `n` onto the evaluation stack, where the n is 0\~6。 |

#### LDLOC

| Instruction   | LDLOC                                  |
|----------|---------------------------------------|
| Bytecode | 0x6F                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the local variable at a specified index onto the evaluation stack. The index is represented as a 1-byte unsigned integer. |

#### STLOCN

| Instruction   | STLOC0\~STLOC6                                  |
|----------|---------------------------------------|
| Bytecode | 0x70\~0x76                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the local variable list at index `n`, where the n is 0\~6。 |

#### STLOC

| Instruction   | STLOC                                  |
|----------|---------------------------------------|
| Bytecode | 0x77                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the local variable list at a specified index. The index is represented as a 1-byte unsigned integer. |

#### LDARGN

| Instruction   | LDARG0\~LDARG6                                  |
|----------|---------------------------------------|
| Bytecode | 0x78\~0x7E                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the argument at index `n` onto the evaluation stack, where the n is 0\~6. |

#### LDARG

| Instruction   | LDARG                                  |
|----------|---------------------------------------|
| Bytecode | 0x7F                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Loads the argument at a specified index onto the evaluation stack. The index is represented as a 1-byte unsigned integer. |

#### STARGN

| Instruction   | STARG0\~STARG6                                  |
|----------|---------------------------------------|
| Bytecode | 0x80\~0x86                                |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the argument slot at index `n`, where the n is 0\~6. |

#### STARG

| Instruction   | STARG                                 |
|----------|--------------------------------------|
| Bytecode | 0x87                                  |
| Fee | 0.00000002 GAS                                          |
| Function   | Stores the value on top of the evaluation stack in the argument slot at a specified index. The index is represented as a 1-byte unsigned integer. |

### String Operation

#### NEWBUFFER

| Instruction   | NEWBUFFER                                              |
|----------|--------------------------------------------------|
| Bytecode | 0x88                                             |
| Fee | 0.00000256  GAS                                         |
| Function   | Create a new buffer |

#### MEMCPY

| Instruction   | MEMCPY                                              |
|----------|--------------------------------------------------|
| Bytecode | 0x89                                             |
| Fee | 0.00002048  GAS                                         |
| Function   | memory copy |

#### CAT

| Instruction   | CAT                                              |
|----------|--------------------------------------------------|
| Bytecode | 0x8B                                             |
| Fee | 0.00002048  GAS                                         |
| Function   | Concatenates two strings. |

#### SUBSTR

| Instruction   | SUBSTR                                       |
|----------|----------------------------------------------|
| Bytecode | 0x8C                                         |
| Fee | 0.00002048 GAS                                          |
| Function   | Returns a section of a string. |

#### LEFT

| Instruction   | LEFT                                         |
|----------|----------------------------------------------|
| Bytecode | 0x8D                                         |
| Fee | 0.00002048 GAS                                          |
| Function   | Gets characters in the left of the specified point in a string. |

#### RIGHT

| Instruction   | RIGHT                                        |
|----------|----------------------------------------------|
| Bytecode | 0x8E                                         |
| Fee | 0.00002048 GAS                                          |
| Function   | Gets characters in the right of the specified point in a string. |

### Logical Operation

#### INVERT

| Instruction   | INVERT                       |
|----------|------------------------------|
| Bytecode | 0x90                         |
| Fee | 0.00000004 GAS                                          |
| Function   | Flips all of the bits in the input. |

#### AND

| Instruction   | AND                                    |
|----------|----------------------------------------|
| Bytecode | 0x91                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Boolean and between each bit in the inputs |

#### OR

| Instruction   | OR                                     |
|----------|----------------------------------------|
| Bytecode | 0x92                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Boolean or between each bit in the inputs. |

#### XOR

| Instruction   | XOR                                      |
|----------|------------------------------------------|
| Bytecode | 0x93                                     |
| Fee | 0.00000008 GAS                                          |
| Function   | Boolean exclusive or between each bit in the inputs. |

#### EQUAL

| Instruction   | EQUAL                                        |
|----------|----------------------------------------------|
| Bytecode | 0x97                                         |
| Fee | 0.00000032 GAS                                          |
| Function   | Returns 1 if the inputs are exactly equal, 0 otherwise. |

#### NOTEQUAL

| Instruction   | NOTEQUAL                                        |
|----------|----------------------------------------------|
| Bytecode | 0x98                                         |
| Fee | 0.00000032 GAS                                          |
| Function   | Returns 1 if the inputs are not equal, 0 otherwise. |

### Arithmetic Operation

#### SIGN

| Instruction   | SIGN                                         |
|----------|----------------------------------------------|
| Bytecode | 0x99                                         |
| Fee | 0.00000004 GAS                                          |
| Function   | Puts the sign of top stack item on top of the main stack. If value is negative, put -1; if positive, put 1; if value is zero, put 0. |

#### ABS

| Instruction   | ABS                            |
|----------|--------------------------------|
| Bytecode | 0x9A                           |
| Fee | 0.00000004 GAS                                          |
| Function   | The input is made positive. |

#### NEGATE

| Instruction   | NEGATE                         |
|----------|--------------------------------|
| Bytecode | 0x9B                           |
| Fee | 0.00000004 GAS                                          |
| Function   | The sign of the input is flipped. |

#### INC

| Instruction   | INC                                |
|----------|------------------------------------|
| Bytecode | 0x9C                               |
| Fee | 0.00000004 GAS                                          |
| Function   | 1 is added to the input. |

#### DEC

| Instruction   | DEC                                |
|----------|------------------------------------|
| Bytecode | 0x9D                               |
| Fee | 0.00000004 GAS                                          |
| Function   | 1 is subtracted from the input. |

#### ADD

| Instruction   | ADD                                    |
|----------|----------------------------------------|
| Bytecode | 0x9E                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | a is added to b. |

#### SUB

| Instruction   | SUB                                    |
|----------|----------------------------------------|
| Bytecode | 0x9F                                  |
| Fee | 0.00000008 GAS                                          |
| Function   | b is subtracted from a. |

#### MUL

| Instruction   | MUL                                    |
|----------|----------------------------------------|
| Bytecode | 0xA0                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | a is multiplied by b. |

#### DIV

| Instruction   | DIV                                    |
|----------|----------------------------------------|
| Bytecode | 0xA1                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | a is divided by b. |

#### MOD

| Instruction   | MOD                                    |
|----------|----------------------------------------|
| Bytecode | 0xA2                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns the remainder after dividing a by b. |

#### SHL

| Instruction   | SHL                              |
|----------|----------------------------------|
| Bytecode | 0xA8                             |
| Fee | 0.00000008 GAS                                          |
| Function   | Gets the integer n from the top stack and performs a n-bit left shift operation on the remaining BigInteger on the stack. |

#### SHR

| Instruction   | SHR                              |
|----------|----------------------------------|
| Bytecode | 0xA9                             |
| Fee | 0.00000008 GAS                                          |
| Function   | Gets the integer n from the top stack and performs a n-bit right shift operation on the remaining BigInteger on the stack. |

#### NOT

| Instruction   | NOT                                |
|----------|------------------------------------|
| Bytecode | 0xAA                               |
| Fee | 0.00000004 GAS                                          |
| Function   | If the input is 0 or 1, it is flipped. Otherwise the output will be 0. |

#### BOOLAND

| Instruction   | BOOLAND                                |
|----------|----------------------------------------|
| Bytecode | 0xAB                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | If both a and b are not 0, the output is 1. Otherwise 0. |

#### BOOLOR

| Instruction   | BOOLOR                                 |
|----------|----------------------------------------|
| Bytecode | 0xAC                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | If a or b is not 0, the output is 1. Otherwise 0. |

#### NZ

| Instruction   | NZ                                  |
|----------|-------------------------------------|
| Bytecode | 0xB1                                |
| Fee | 0.00000004 GAS                                          |
| Function   | Returns 0 if the input is 0. 1 otherwise. |


#### NUMEQUAL

| Instruction   | NUMEQUAL                               |
|----------|----------------------------------------|
| Bytecode | 0xB3                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if the numbers are equal, 0 otherwise. |

#### NUMNOTEQUAL

| Instruction   | NUMNOTEQUAL                              |
|----------|------------------------------------------|
| Bytecode | 0xB4                                     |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if the numbers are not equal, 0 otherwise.|

#### LT 

| Instruction   | LT                                     |
|----------|----------------------------------------|
| Bytecode | 0xB5                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if a is less than b, 0 otherwise. |

#### LE

| Instruction   | LE                                        |
|----------|--------------------------------------------|
| Bytecode | 0xB6                                       |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if a is less than or equal to b, 0 otherwise. |

#### GT

| Instruction   | GT                                     |
|----------|----------------------------------------|
| Bytecode | 0xB7                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if a is greater than b, 0 otherwise. |

#### GE

| Instruction   | GE                                        |
|----------|--------------------------------------------|
| Bytecode | 0xB8                                       |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if a is greater than or equal to b, 0 otherwise. |

#### MIN

| Instruction   | MIN                                    |
|----------|----------------------------------------|
| Bytecode | 0xB9                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns the smaller of a and b. |


#### MAX

| Instruction   | MAX                                    |
|----------|----------------------------------------|
| Bytecode | 0xBA                                   |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns the larger of a and b. |

#### WITHIN

| Instruction   | WITHIN                                       |
|----------|----------------------------------------------|
| Bytecode | 0xBB                                         |
| Fee | 0.00000008 GAS                                          |
| Function   | Returns 1 if x is within the specified range (left-inclusive), 0 otherwise. |

### Advanced Data Structure

It has implemented common operations for array, map, struct, etc.

#### PACK

| Instruction   | PACK                              |
|----------|-----------------------------------|
| Bytecode | 0xC0                              |
| Fee | 0.00000512 GAS                                          |
| Function   | A value n is taken from top of main stack. The next n items on main stack are removed, put inside n-sized array and this array is put on top of the main stack. |

#### UNPACK

| Instruction   | UNPACK                             |
|----------|------------------------------------|
| Bytecode | 0xC1                               |
| Fee | 0.00000512 GAS                                          |
| Function   | An array is removed from top of the main stack. Its elements are put on top of the main stack (in reverse order) and the array size is also put on main stack. |

#### NEWARRAY0

| Instruction   | NEWARRAY0                             |
|----------|------------------------------------|
| Bytecode | 0xC2                               |
| Fee | 0.00000016 GAS                                          |
| Function   | An array with size n is put on top of the main stack. |

#### NEWARRAY

| Instruction   | NEWARRAY                             |
|----------|------------------------------------|
| Bytecode | 0xC3                               |
| Fee | 0.00000512 GAS                                          |
| Function   | A value n is taken from top of main stack. A null-filled array with size n is put on top of the main stack. |

#### NEWARRAY_T

| Instruction   | NEWARRAY_T                           |
|----------|------------------------------------|
| Bytecode | 0xC4                               |
| Fee | 0.00000512 GAS                                          |
| Function   | An array of type T with size n is put on top of the main stack. |

#### NEWSTRUCT0

| Instruction   | NEWSTRUCT0                           |
|----------|------------------------------------|
| Bytecode | 0xC5                               |
| Fee | 0.00000016 GAS                                          |
| Function   | A structure with size n and all 0 elements is put on top of the main stack. |

#### NEWSTRUCT

| Instruction   | NEWSTRUCT                           |
|----------|------------------------------------|
| Bytecode | 0xC6                               |
| Fee | 0.00000512 GAS                                          |
| Function   | A value n is taken from top of main stack. A zero-filled struct with size n is put on top of the main stack. |

#### NEWMAP

| Instruction   | NEWMAP                  |
|----------|-------------------------|
| Bytecode | 0xC8                    |
| Fee | 0.00000008 GAS                                          |
| Function   | An empty Map is put on top of the main stack. |

#### SIZE

| Instruction   | SIZE                  |
|----------|-------------------------|
| Bytecode | 0xCA                    |
| Fee | 0.00000004 GAS                                          |
| Function   | Gets the size of elements on the top stack. |

#### HASKEY

| Instruction   | HASKEY                  |
|----------|-------------------------|
| Bytecode | 0xCB                    |
| Fee | 0.00000064 GAS                                          |
| Function   | An input index n (or key) and an array (Map，Buffer, ByteString) are returned from the top of the main stack. Puts True on top of main stack if n is in the length range of the array (Map，Buffer, ByteString), and False otherwise. |

#### KEYS

| Instruction   | KEYS                                |
|----------|-------------------------------------|
| Bytecode | 0xCC                                |
| Fee | 0.00000016 GAS                                          |
| Function   | Gets all Keys of the map from top of the main stack and constructs a new array with all Key and puts it on top of the main stack. |

#### VALUES

| Instruction   | VALUES                                  |
|----------|-----------------------------------------|
| Bytecode | 0xCD                                    |
| Fee | 0.00008192 GAS                                          |
| Function   | Gets all Values of the elements (Array or Map) from top of the main stack and constructs a new array with all Value and puts it on top of the main stack.|

#### PICKITEM

| Instruction   | PICKITEM                           |
|----------|------------------------------------|
| Bytecode | 0xCE                               |
| Fee | 0.00000064 GAS                                          |
| Function   | Gets the Nth element in the array of the top stack|

#### APPEND

| Instruction   | APPEND                |
|----------|-----------------------|
| Bytecode | 0xCF                  |
| Fee | 0.00008192 GAS                                          |
| Function   | Adds a new item to the arry of the top stack |

#### SETITEM

| Instruction   | SETITEM                                  |
|----------|------------------------------------------|
| Bytecode | 0xD0                                     |
| Fee | 0.00008192 GAS                                          |
| Function   | Assigns a value to the specified index of element （Array，Map or Buffer）in the top stack |

#### REVERSEITEMS

| Instruction   | REVERSEITEMS                                  |
|----------|------------------------------------------|
| Bytecode | 0xD1                                     |
| Fee | 0.00008192 GAS                                          |
| Function   | Reverses the elements in Array or Buffer from the top stack.|

#### REMOVE

| Instruction   | REMOVE                            |
|----------|-----------------------------------|
| Bytecode | 0xD2                              |
| Fee | 0.00000016 GAS                                          |
| Function   | Removes the specified index or Key elements from Array or Map        |

#### CLEARITEMS

| Instruction   | CLEARITEMS                                  |
|----------|-----------------------------------------|
| Bytecode | 0xD3                                    |
| Fee | 0.00000016 GAS                                          |
| Function   | Remove all the items from the compound-type. |

#### POPITEM

| Instruction | POPITEM                                                      |
| ----------- | ------------------------------------------------------------ |
| Bytecode    | 0xD4                                                         |
| Fee         | 0.00000016 GAS                                               |
| Function    | Pops the last element in Array from the stack top and push into the stack. |

### Type 

#### ISNULL

| Instruction   | ISNULL                                  |
|----------|-----------------------------------------|
| Bytecode | 0xD8                                    |
| Fee | 0.00000002 GAS                            |
| Function   | Returns true if the input is null. Returns false otherwise. |

#### ISTYPE

| Instruction   | ISTYPE                                  |
|----------|-----------------------------------------|
| Bytecode | 0xD9                                    |
| Fee | 0.00000002 GAS                                          |
| Function   | Returns true if the top item is of the specified type.|

#### CONVERT

| Instruction   | CONVERT                                  |
|----------|-----------------------------------------|
| Bytecode | 0xDB                                    |
| Fee | 0.00002048 GAS                            |
| Function   | Converts the top item to the specified type. |

> [!Note]
>
> The operation code with \* indicates that the result of the operation is not pushed back to the `EvaluationStack` using `PUSH()`.
