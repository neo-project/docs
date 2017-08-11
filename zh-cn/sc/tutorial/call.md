# 合约调用

```c#
[Appcall]("XXXXXXXXXX")//ScriptHash
public static extern int AnotherContract(string arg);

public static void Main()
{
    AnotherContract("Hello");    
}
```

在智能合约中，如果想调用其它已发布到区块链上的智能合约可以通过这种方式。首先通过 AppCall 和要调用的合约的脚本散列来在 C# 中添加声明。然后就可以在代码中对其进行调用了。