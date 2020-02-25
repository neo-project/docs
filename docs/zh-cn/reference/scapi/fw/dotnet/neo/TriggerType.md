# TriggerType 枚举

定义了触发器类型。触发器可以使合约根据不同的使用场景执行不同的逻辑。

更多关于触发器的知识，请查看 [合约开发基础](../../../../../sc/write/basics.md)。

命名[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum TriggerType : byte
    {
        System = 0x01,
        Verification = 0x20,
        Application = 0x40,
        All = System | Verification | Application
    }
```

## System 触发器

此触发器目前仅用于原生合约NEO和GAS中。当节点收到新区块后触发，目前只会触发原生合约的执行。当节点收到新区块，持久化之前会调用所有原生合约的onPersist方法，只有触发方式为System才会继续执行。

该触发器不对普通合约的执行造成任何影响。

## Application 触发器

应用触发器的目的在于将该合约作为应用函数进行调用，应用函数可以接受多个参数，对区块链的状态进行更改，并返回任意类型的返回值。以下是一个简单的C#智能合约：

```c#
    public class Contract1 : SmartContract.Framework.SmartContract
    {
        public static Object Main(string operation, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "FunctionA") return FunctionA(args);
            }  
        }
        public static bool FunctionA(params object[] args)
        {
            //Do Something  
        }
    }
```
NEO3中所有交易都为合约的调用，当一笔交易被广播和确认后，智能合约由共识节点执行，普通节点在转发交易时不执行智能合约。智能合约执行成功不代表交易的成功，而交易的成功也不决定智能合约执行的成功。

## Verification 触发器

验证触发器的目的在于将该合约作为验证函数进行调用，验证函数可以接受多个参数，并且应返回有效的布尔值，标志着交易或区块的有效性。

当你想从 A 账户向 B 账户进行转账时，会触发验证合约，所有收到这笔交易的节点（包括普通节点和共识节点）都会验证 A 账户的合约，如果返回值为 true，即转账成功。如果返回 false，即转账失败。

如果鉴权合约执行失败，这笔交易将不会被写入区块链中。

下面的代码就是一个验证合约的简单示例，仅当触发器为验证触发器时执行验证部分的代码。当条件 A 满足时，返回 true，即转账成功。否则返回 false，转账失败。

```c#
    public class Contract1 : SmartContract.Framework.SmartContract
    {
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
    }
```
