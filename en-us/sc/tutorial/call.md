# Contract Call

```c#
[AppCall("XXXXXXXXXX")] // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

In a smart contract, you can use this to call other smart contracts that have been published to the chain. 
1. Add a declaration using AppCall and the script hash of the contract to be invoked.
2. Call it in the code.
