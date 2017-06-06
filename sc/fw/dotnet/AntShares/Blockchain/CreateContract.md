# CreateContract 方法 (byte[], byte[], byte, bool, string, string, string, string, string)

在智能合约中调用此方法可以发布一个新的智能合约。

该方法是 PublishTransaction 在 2.0 版本的替代者。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

参数：

script：合约代码，字节数组。

parameter_list：参数列表，字节。

return_type：返回值，字节。

need_storage：是否需要持久化存储区，布尔值。

name：智能合约的名称，字符串类型。

version：版本号，字符串类型。

author：作者姓名，字符串类型。

email：作者邮箱，字符串类型。。

description：智能合约的描述，字符串类型。

返回值：发布的智能合约，[Contract](../Contract.md) 类型。

## 示例

```

```



[返回上级](../Blockchain.md)