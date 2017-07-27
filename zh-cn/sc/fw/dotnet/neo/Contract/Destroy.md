# Contract.Destroy 方法 ()

销毁智能合约。发布到区块链上的智能合约不能通过外部对其进行销毁，如果要销毁合约的话，需要在编写合约时编写其销毁的逻辑。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Destroy()
```

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        var height = Blockchain.GetHeight();
        var block = Blockchain.GetBlock(height);
        if(block.Timestamp > 1514736000) //北京时间2018-1-1
        {
            Neo.SmartContract.Framework.Services.Neo.Contract.Destroy();
        }
    }
}
```



[返回上级](../Contract.md)