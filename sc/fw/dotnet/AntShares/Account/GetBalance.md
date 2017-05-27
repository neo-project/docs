# Account.GetBalance 方法 (byte[])

通过资产ID获得该账户中这种资产的余额。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public extern long GetBalance(byte[] asset_id)
```

参数：资产ID，即注册资产时的 RegistTransaction 的交易ID，32字节的byte数组。

返回值：账户中该资产余额，长整形，等于实际金额 × 10⁸。

## 示例

```

```



[返回上级](../Account.md)