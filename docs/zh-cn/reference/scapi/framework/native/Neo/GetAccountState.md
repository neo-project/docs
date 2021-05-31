# NEO.GetAccountState 方法

获取指定账户最新的投票情况。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```
public static extern NeoAccountState GetAccountState(DataCache snapshot, UInt160 account)
```

## 示例

```
public class Contract1 : SmartContract.Framework.SmartContract
{
    private static readonly UInt160 account = "NXsG3zwpwcfvBiA3bNMx6mWZGEro9ZqTqM".ToScriptHash();
    
    public static object Test()
    {
        return NEO.GetAccountState(account);
    }
}
```

部署后，调用该合约，响应正文为：

```
[
      {
        "type": "Struct",
        "value": [
          {
            "type": "Integer",
            "value": "900"
          },
          {
            "type": "Integer",
            "value": "9774"
          },
          {
            "type": "ByteString",
            "value": "AsNeyvySxknpefBTobcD9O\u002BQiieFUIdCtmzAWZvxQPA4"
          }
        ]
      }
]
```

响应说明：

- 第一个值：账户当前余额，等同于投出的票数。
- 第二个值：最近一次更新时的区块高度。
- 第三个值：被投方的公钥。
