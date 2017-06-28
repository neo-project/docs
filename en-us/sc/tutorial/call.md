# Contract call

```c#
[AppCall]("XXXXXXXXXX") // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

In a smart contract, if you want to call other smart contracts that have been published to the chain chain, you can do this in this way. First add a declaration to the C # by AppCall and the script hash of the contract to be invoked. And then you can call it in the code.
