# Callback class

Callback related methods.

Namespace: [Neo.SmartContract.Framework.Services.System](../System.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Callback
```

## Attributes

| Name                                                         | Description                                             |
| ------------------------------------------------------------ | ------------------------------------------------------- |
| [Invoke(object[])](Callback/Invoke.md)                       | Invokes the callback function                           |
| [Create(Func<TResult>)](Callback/Create2.md)                 | Gets the script hash of the smart contract entry point. |
| [Create(Func<T, TResult>)](Callback/Create.md)               | Gets the script hash executed by the smart contract     |
| [CreateFromMethod(UInt160, string)](Callback/CreateFromMethod.md) | Gets the script hash executed by the smart contract     |
| [CreateFromSyscall(SyscallCallback)](Callback/CreateFromSyscall.md) | Gets the script hash executed by the smart contract     |

