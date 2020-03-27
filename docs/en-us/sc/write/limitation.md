# Smart Contract Writing Limitations

## NEO-supported features in C#

When using C# to develop smart contracts, you cannot use the full set of C# features due to the difference between NeoVM and Dotnet IL. 

Because NeoVM is more compact, we can only compile limited C# / dotnet features into an AVM file.

### C#  integral types

`Int8 int16 int32 int64 uint8 uint16 uint32 uint64`

All these integer types are supported because NeoVM has only one integer type and the underlying implementation is BigInteger, which covers larger scope than C#. 

A numeric type, `VARINT`, is represented as `BigInteger` in the underlying implementation.

Additionally, these are supported for C#  `BigInteger` ：

```c#
ulong total_neo = 200;
BigInteger ico_neo = 300;
BigInteger balance_neo = total_neo - ico_neo;
ulong value = 150;
```

Note that when converting a numeric type to a smaller one, compiling to AVM does not truncate the value (byte) (ulong)

Mathematical operators are supported for all integer types：

```c#
var a1 = abc + 1;
var a2 = abc - 1;
var a3 = abc * 1;
var a4 = abc / 1;
var a5 = abc % 2;
```

Logical operations are supported for all integer types：

```c#
if (a1 > a2) ;
if (a2 < a3) ;
if (a3 == a2) ;
if (a3 != a2) ;
if (a1 >= a2) ;
if (a1 <= a2) ;
```

Incremental operators are supported for integers：

```c#
int k = 100;
for (int j = 0; j < 3; j++)
{
   k += j;
}
```

### C# floating point types

Not support.

### C# bool types

Basic support. The underlying behavior is similar to INT; false is int 0.

### C# char string types

Not fully support. Unlike the string in C#, the string in NeoVM is treated as bytearray, thus the string compiled into AVM is actually its UTF8 encoded bytearray. 

Only string variables are supported. Built-in methods of string types are not supported, such as `+`, `Contains`,` Replace`, `Trim`,` IndexOf`, etc. `ToString ()` methods of any type are not supported, neither. Thus do not use any string advanced handlers. Just treat string as a special type. Particularly do not use string to handle Chinese.

```c#
string ss3 = "ab";
ss3 += "c";
var ss = "abcdef";
var b2 = ss.Length;
var c = ss + "abc";
var d = ss.Substring(1, 2);
```

String concatenation, fetch length, and intercept operations for bytes are supported. English strings are supported as the same as strings in C#, however, Chinese strings are not supported.

Since there is no support for other types to be formatted as strings, the results of `“abc”+1.ToString()` and C# are different.

char type is supported as the integer type. 

### C# switch

Switch statements and [switch expressions](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-8#switch-expressions) are supported. But note that the number of cases in the switch statement must not exceed 7, otherwise an error will occur when invoking the contract, even if the contract can be compiled with no issue. If there are more than 7 cases, it is recommended to use if statements instead.

### C# class and structure

C# class and structure definition is supported.

```c#
public class info
{
    public byte[] a;
    public byte[] b;
}
```

Defining custom member functions is not supported, with the exception of extern member functions that use features like APPCALL. 

Custom constructors are not supported, with the exception of extern constructors that use the OPCALL attribute.

### C# array

C# array is supported, and the behavior is similar to C#.

Byte[] is an exception as it is a special type in the NeoVM underlying layer.

Usually you can set the value in an array using the following:

```c#
short[] some = new short[17];
some[1] = 12;
return some;
```

### C# enumeration

Defining enumerations is supported only when used as a numeric value.

Formatting to String and parsing from String are not supported.

### C# containers

C# common List Dictionary containers are not supported.  

The List function can be replaced by an array.  

The Dictionary function can be replaced with MAP in Neo Dotnet DevPack.

### C# variables

Temporary variables are unrestricted. Defining const variables and static member variables are supported. Assigning initial values to static member variables is supported.

```c#
private const ulong total_neo = total_ico_usd / neo_to_usd * neo_decimals;
public static BigInteger TotalIcoNeo() => total_neo;
```

### C# delegates and events

You can define two functions of C# delegates, which are special features of NeoVM.

 `public delegate void acall(string a);`

One can be used to define events:

 `public static event acall dododo;`

When invoking this event, the NEO C# compiler regards it as the Notify method. Refer to the NEP5 notification event.

 The other can be used to convert a bytearray to a delegate:

`acall call = (acall)new byte[] { 01, 02, 03 }.ToDelegate();`

This implements a call to a smart contract with a specified address. Refer to NEP4.

Action is supported as well:

```
event Action<byte[], byte[], BigInteger> Transferred;
```

## C# development convention

### C# export requirements

NEO C# compile requires that a smart contract has only one Main function as the entry point.

Other functions to be exported should be public static and have unique name. 

### C# delegation and definition

C# delegates and events have special features. Refer to the C# delegates and events section.  

C# delegates and events correspond to NEO smart contract notification and NEP4 respectively.

### Built-in attributes

You may find there are lots of extern external functions of NEO DEVPACK. In fact, they have no external implementation because they do not need to be implemented. They are marked by features.

You can use these functions in your smart contracts.

### APPCALL

Calling a function with the APPCALL attribute calls the specified smart contract.

```c#
[Appcall("97b9373228d508155d5bdf75cd4703dfb1137fe0")]
public static extern bool AnotherContract(string arg, object[] args);
```

### SYSCALL

Calling a function with the Syscall attribute actually calls the corresponding system function:

```c#
 [Syscall("Neo.Account.GetBalance")]
  public extern long GetBalance(byte[] asset_id);
```

### OPCALL

When a function with the OPCODE attribute is called, the call is translated into an instruction:

```c#
[OpCode(Neo.VM.OpCode.LEFT)]
public extern static byte[] Take(byte[] good, int index);
```

### NONEMIT

Executing a function with the NonEMit attribute is usually used to complete conversions that meet syntax rules. In fact, there is no need to make the conversion in the underlying NeoVM.

```c#
[Nonemit]
public extern static Delegate ToDelegate(this byte[] source);
```

### NonemitWithConvert

Executing a function with the `NonemitWithConvert` attribute actually executes a conversion. The input to this function must be a constant as the conversion is performed in the phase of compilation.

```c#
[NonemitWithConvert(ConvertMethod.ToScriptHash)]
public extern static byte[] ToScriptHash(this string address);
```

For example, `"NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9".ToScriptHash();` is valid because the compiler can do conversion of  `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` .

However,  `String address = "NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9"; address.ToScriptHash();` is invalid as the compiler cannot determine the value of  `address`.

## Other known issues

If using StorageMap, you must declare StorageMap inside the method as a local variable rather than write it outside the method as a global variable, otherwise an error will be reported when it is called even it is compilable.