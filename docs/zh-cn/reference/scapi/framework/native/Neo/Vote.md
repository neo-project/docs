# NEO.Vote 方法

每个地址均有投票给一个地址的权利，候选人票数为所有向该账户投票的地址的NEO余额之和。初始块所有默认候选人均会向自己投票。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> - 投给非候选人的地址的票数会被统计但不会被计入票数，只有当该地址注册为候选人投票才会生效。
> - 投票需要验证投票者的签名。

## 语法

```c#
public static extern bool Vote(UInt160 account, ECPoint voteTo);
```

参数：

- account: 投票账户的脚本哈希;
- voteTo: 目标账户的公钥。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    private static readonly byte[] pubkey = "02e8ff17c567d62f274fe247cc884a2a6cd3b8fd0d779a8c5856289a560accacb4".HexToBytes();

    public static object Test()
    {
        bool result = NEO.Vote(account, (ECPoint)pubkey);
        return result;
    }
}
```
部署后，调用该合约，响应正文为：

```json
{
	"type":"Boolean",
	"value":"true"
}
```

响应说明：

- Boolean类型：true表示给候选人投票成功。

- 其他：失败。

[返回上级](../Neo.md)