# 合约编写须知

## Neo 编译器支持的 C# 特性

使用 C# 开发智能合约时，你无法使用 C# 的全部特性。会存在一些限制以及不支持的功能，这些限制的根源，来自于 NeoVM 和 Dotnet IL 的差异性。

因为 NeoVM 更加精简，所以我们只能将有限的 C# / dotnet 特性编译为 AVM 文件。

### C# 整数类型的支持

`Int8 int16 int32 int64 uint8 uint16 uint32 uint64`

因为 NeoVM 只有一种 Integer，底层实现是 `BigInteger`，比 C# 的范围要大，所以这些整数类型均可使用。

一种数值类型 `VARINT`，在底层实现时表现为 `BigInteger` 类型。

另外对 C# 的 `BigInteger` 也可以支持：

```c#
ulong total_neo = 200;
BigInteger ico_neo = 300;
BigInteger balance_neo = total_neo - ico_neo;
ulong value = 150;
```

需要注意在将数值类型转型为更小的类型时，编译为 AVM 之后并不会截断数值（byte）（ulong）

对所有整数类型支持数学运算符 + - * / % 加减乘除余：

```c#
var a1 = abc + 1;
var a2 = abc - 1;
var a3 = abc * 1;
var a4 = abc / 1;
var a5 = abc % 2;
```

对所有整数类型支持逻辑运算 大于、大于等于、小于、小于等于、等于、不等于：

```c#
if (a1 > a2) ;
if (a2 < a3) ;
if (a3 == a2) ;
if (a3 != a2) ;
if (a1 >= a2) ;
if (a1 <= a2) ;
```

支持整数的自增操作符：

```c#
int k = 100;
for (int j = 0; j < 3; j++)
{
   k += j;
}
```

### C# 浮点类型的支持

不支持

### C# bool 类型的支持

基本支持，底层行为和 INT 类似，false 为 int 0。

### C# char string 类型的支持

不完全支持，由于在 NeoVM 层次，string 也是作为 bytearray 处理，和 C# 中的 string 是不同的，编译到 AVM 的 string 实际是它的 UTF8 编码的 bytearray。仅支持声明字符串变量，不支持字符串类型的内置方法，如  `+`、`Contains`、`Replace`、`Trim`、`IndexOf` 等，也不支持任意类型的 `ToString()` 方法。所以请勿使用任何 string 高级处理函数，仅将 string 作为一种特殊类型处理。

尤其不要使用 string 处理中文。

```c#
string ss3 = "ab";
ss3 += "c";
var ss = "abcdef";
var b2 = ss.Length;
var c = ss + "abc";
var d = ss.Substring(1, 2);
```

支持针对 bytes 操作的 string 的连接，取长度，截取操作，在英文处理时与 C# string 相同，不支持处理中文。

另外，由于没有其它类型格式化为 string 的支持，所以 `“abc”+1.ToString()` 与 C# 结果不同。

char 类型作为整数支持。

### C# switch 的支持

支持 switch 语句和 [switch 表达式](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-8#switch-expressions) 但需要注意 switch 语句中 case 的数量**不能超过 7 个**，否则调用时会报错（可编译通过）。如果 case 数量超过 7 个，建议改为 if 语句。

### C# class 和 结构体的支持

支持 C# class 和结构体定义。

```c#
public class info
{
    public byte[] a;
    public byte[] b;
}
```

不支持在其中自定义成员函数，使用 APPCALL 之类特性的 extern 成员函数例外。

不支持自定义构造函数，使用 OPCALL 特性的 extern 构造函数例外。

### C# 数组的支持

数组支持，行为基本和 C# 一致。

Byte[] 例外，因为 byte[] 是 NeoVM 底层的特别类型。

对一般数组可以用的设置其中的值的操作

```c#
short[] some = new short[17];
some[1] = 12;
return some;
```

对 Byte[] 不允许。

### C# 枚举的支持

支持仅作为数值使用时定义枚举。

不支持格式化为 String，以及从 String 解析等。

### C# 容器的支持

不支持 C# 常用的 List Dictionary 容器。

List 功能可以用数组替代。

Dictionary 功能可以用 Neo Dotnet DevPack 中的 MAP 替代。

### C# 变量的支持

临时变量不限，支持定义 const 变量和静态成员变量。支持静态成员变量直接赋初值。

```c#
private const ulong total_neo = total_ico_usd / neo_to_usd * neo_decimals;
public static BigInteger TotalIcoNeo() => total_neo;
```

### C# 委托和事件的支持

C# 委托可以定义，定义的委托有两个功能，都是 NeoVM 的特别功能。

 `public delegate void acall(string a);`

一是可以用来定义事件：

 `public static event acall dododo;`

调用这个事件则会被 NEO C# 编译器理解为调用 Notify 方法，可参考 NEP5 的通知事件。

 另一个是可以将一个 bytearray 转型为一个委托：

`acall call = (acall)new byte[] { 01, 02, 03 }.ToDelegate();`

这就实现了对一个指定地址的智能合约的调用，参考 NEP4。

也支持 Action 等：

`event Action<byte[], byte[], BigInteger> Transferred;`

## C# 开发约定

### C# 的导出要求

NEO C# 编译器要求一个智能合约有且只有一个名为 Main 的 public static 函数作为入口点。

其它要导出的函数都应该为 public static，且不可重名。

### C# 的委托和定义

C# 的委托和事件具有特殊的功能，参考 C# 委托和事件的支持。

分别对应 NEO 智能合约的通知与 NEP4。

### 内置特性

如果你观察 NEO DEVPACK 会看到很多 extern 的外部函数，实际上他们并没有外部实现，只是不需要实现。他们由特性标记功能。

也可以在你的智能合约代码中使用这些功能。

### APPCALL特性

调用一个具有 APPCALL 特性的函数，会调用指定的智能合约。

```c#
[Appcall("97b9373228d508155d5bdf75cd4703dfb1137fe0")]
public static extern bool AnotherContract(string arg, object[] args);
```

### SYSCALL特性

调用一个具有 Syscall 特性的函数，实际上会调用对应的系统函数：

```c#
[Syscall("Neo.Account.GetBalance")]
public extern long GetBalance(byte[] asset_id);
```

### OPCALL 特性

调用一个具有 OPCODE 特性的函数时，该调用会被翻译成一条指令：

```c#
[OpCode(Neo.VM.OpCode.LEFT)]
public extern static byte[] Take(byte[] good, int index);
```

### NONEMIT 特性

执行一个具有 NonEMit 特性的函数，通常都是用来完成一些满足语法的转换，实际上在 NeoVM 底层并不需要转换。

```c#
[Nonemit]
public extern static Delegate ToDelegate(this byte[] source);
```

### NonemitWithConvert 特性

当执行一个具有 `NonemitWithConvert` 特性的函数时，实际只是执行一个转换。这个函数的入参必须是一个常数，因为这个转换是在编译阶段执行的。

```c#
[NonemitWithConvert(ConvertMethod.ToScriptHash)]
public extern static byte[] ToScriptHash(this string address);
```

例如， `"NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9".ToScriptHash();` 是合法的，因为编译器可以执行对 `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` 的转换。

而 `String address = "NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9"; address.ToScriptHash();` 是非法的，因为编译器无法确定 `address` 的值。

### 其它已知 Bug

如果使用 StorageMap，则 StorageMap 的声明必须在方法内（局部变量），不能写在方法外（全局变量），否则调用时会报错（可编译通过）。