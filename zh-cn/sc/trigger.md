# 智能合约的触发器

触发器是触发智能合约执行的机制，在 NEO 智能合约中，有 4 种触发器，`Verification`, `Application`， `VerificationR`, `ApplicationR`

一个实现智能合约的区块链应该为其上运行的智能合约提供多种触发器，便其在不同的上下文中起作用。

### Verification

验证触发器的目的在于将该合约作为验证函数（verification function）进行调用，验证函数可以接受多个参数（parameters），并且应返回有效的布尔值，标志着交易或区块的有效性。

当你想从 A 账户向 B 账户进行转账时，会触发验证合约，所有收到这笔交易的节点（包括普通节点和蓝共识节点）都会验证 A 账户的合约，如果返回值为 true，即转账成功。如果返回 false，即转账失败。

如果鉴权合约执行失败，这笔交易将不会被写入区块链中。

比如下面的代码就是一个验证合约的简单示例，当条件 A 满足时，返回 true，即转账成功。否则返回 false，转账失败。

```c#
public static bool Main(byte[] signature)
{
    if (/*条件A*/)
        return true;
    else
        return false;
}
```
下面的这段代码的作用与上面的基本相同，但对运行时的触发器进行了判断，仅当触发器为验证触发器时执行验证部分的代码，这在复杂的智能合约中很有用，如果一个智能合约实现了多种触发器，应该在 Main 方法中对触发器进行判断。


```c#
public static bool Main(byte[] signature)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*条件A*/)
                return true;
            else
                return false;
    }  
}
```

### Application 

应用触发器的目的在于将该合约作为应用函数（verification function）进行调用，应用函数可以接受多个参数（parameters），对区块链的状态进行更改，并返回任意类型的返回值。

理论上智能合约可以有任意的入口点，但我们推荐智能合约使用 main 函数作为入口点以方便调用。

```c#
public static Object Main(string operation, params object[] args) 
```

下面是一个简单的使用应用触发器的智能合约

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
        if (operation == "FunctionB") return FunctionB(args);
        if (operation == "FunctionC") return FunctionC(args);
    }  
}
public static bool FunctionA(params object[] args)
{
    //some code  
}
public static BigInteger FunctionB(params object[] args)
{
    //some code  
}
public static byte[] FunctionC(params object[] args)
{
    //some code  
}
```

与验证触发器不同，应用触发器不是通过转账进行触发，而是通过一笔特殊的交易 `InvocationTransaction` 进行触发，如果应用（Web/App）想要调用该智能合约的话，需要在程序中构造一笔 `InvocationTransaction`，然后在程序中签名，广播。`InvocationTransaction` 交易确认后，智能合约由共识节点执行，普通节点在转发交易时不执行智能合约。

由于应用合约是在 `InvocationTransaction` 确认后才执行的合约脚本，此时无论应用合约执行成功或失败，该笔交易都会写在区块链中。`InvocationTransaction` 的成功与失败，与智能合约的成功与失败不存在必然联系。

智能合约的执行成功与否不决定 `InvocationTransaction` 交易的成功。 `InvocationTransaction` 交易的成功也不决定智能合约的成功。

### VerificationR

已弃用，关于 VerificationR 触发器可以参考 [此文](https://github.com/neo-project/proposals/blob/master/nep-7.mediawiki) 。

### ApplicationR

已弃用，关于 ApplicationR 触发器可以参考 [此文](https://github.com/neo-project/proposals/blob/master/nep-7.mediawiki) 。

### 其它说明

一个智能合约可以同时包含多种触发器以适应不同的上下文，下面的代码是同时包含了 Verification 触发器和 Application 触发器。

```c#
public static Object Main(string operation, params object[] args)
{
    if (Runtime.Trigger == TriggerType.Verification)
    {
        if (/*条件A*/)
                return true;
            else
                return false;
    }  
    if (Runtime.Trigger == TriggerType.Application)
    {
        if (operation == "FunctionA") return FunctionA(args);
    }  
}

public static bool FunctionA(params object[] args)
{
    //some code  
}
```

### 对比

下面是几种智能合约触发器的对比

|                  | Verification               | Application                     | VerificationR              | ApplicationR               |
| ---------------- | -------------------------- | ------------------------------- | -------------------------- | -------------------------- |
| 中文名           | 验证触发器                 | 应用触发器                      | 待定                       | 待定                       |
| 开发状态         | 已开发完成                 | 已开发完成                      | 已弃用                     | 已弃用                     |
| 如何触发         | 转账触发                   | 发送 InvocationTransaction 触发 | 接收转账时触发             | 接收转账时触发             |
| 交易与合约的顺序 | 先执行智能合约，后确认交易 | 先确认交易，后执行智能合约      | 先执行智能合约，后确认交易 | 先确认交易，后执行智能合约 |
| 返回值           | 布尔                       | 任意                            | 布尔                       | 任意                       |
| 智能合约存储区   | 只读                       | 读写                            | 只读                       | 读写                       |

