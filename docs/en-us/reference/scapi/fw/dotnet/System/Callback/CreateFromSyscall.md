# CreateFromSyscall(SyscallCallback)

Creates the callback function of syscall.

Namespace: [Neo.SmartContract.Framework.Services.System](../../system.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Callback CreateFromSyscall(SyscallCallback method);
```

Parameters:
- method: the type of callback function

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static object CreateFromSyscall()
    {
        return Callback.CreateFromSyscall(SyscallCallback.System_Binary_Itoa).Invoke(new object[2] { -1, 16});
    }
}
```

Response body:

```json
[{
    "type":"ByteString",
    "value":"Zg=="
}]
```

Response description:

- ByteString type: The return value of callback function

- Other: failed.

[Back](../Callback.md)