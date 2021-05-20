# NEO.UnRegisterCandidate 方法

取消注册为候选人。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 注销候选人需要验证候选人地址的签名，即只有候选人自己才能执行注册/注销操作。

## 语法

```c#
public static extern bool UnRegisterCandidate(ECPoint pubkey);
```

参数：

- pubkey: 要取消账户的公钥。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly byte[] pubkey = "02e8ff17c567d62f274fe247cc884a2a6cd3b8fd0d779a8c5856289a560accacb4".HexToBytes();

    public static object Test()
    {
        bool result = NEO.UnRegisterCandidate((ECPoint)pubkey);
        return result;
    }
}
```

部署后，调用该合约，响应正文为：

```json
{
	"Type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示注销候选人成功。

- 其他：失败。

[返回上级](../Neo.md)