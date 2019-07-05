# 智能合约参数和返回值

在智能合约发布或调用时，需要指定智能合约的参数，智能合约参数是 byte 类型，定义如下。

```c#
/// <summary>
/// 表示智能合约的参数类型
/// </summary>
public enum ContractParameterType : byte
{
    /// <summary>
    /// 签名
    /// </summary>
    Signature = 0,
    Boolean = 1,
    /// <summary>
    /// 整数
    /// </summary>
    Integer = 2,
    /// <summary>
    /// 160位散列值
    /// </summary>
    Hash160 = 3,
    /// <summary>
    /// 256 位散列值
    /// </summary>
    Hash256 = 4,
    /// <summary>
    /// 字节数组
    /// </summary>
    ByteArray = 5,
    PublicKey = 6,
    String = 7,
    
     /// <summary>
     /// 对象数组
     /// </summary>        
    Array = 10,
    InteropInterface = 0xf0,
    Void = 0xff
}
```

如智能合约定义为：

```c#
public class Lock : SmartContract
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        // 略……
    }
}
```

通过上表可查到，int 为 2，bool 为 1，公钥字节数组为 6，签名字节数组为 0。

在 NEO-GUI 客户端发布智能合约填写参数时，每个参数用两位 16 进制字符表示，所以上面的智能合约的形参列表表示为：02010600，返回值为：01。