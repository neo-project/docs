# Policy.GetExecFeeFactor Method

Gets NeoVM execution fee. 

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern uint GetExecFeeFactor();
```

Return:

- vm execution fee

## Example

```c#
public static void Test()
{
    var factor = Policy.GetExecFeeFactor();
}
```
[Back](../Policy.md)

