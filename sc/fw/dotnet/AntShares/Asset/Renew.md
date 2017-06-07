# Asset.Renew 方法 (byte[])

为资产续费。

该方法是 2.0 版新增的方法，2.0 版后区块链上注册的资产需要缴纳年费才可以使用，否则将会进入冻结状态。

当资产到期后需要为资产进行续费。当资产未冻结时，续费是从资产到期时间开始续费，当资产已冻结时，续费是从当前时间开始续费，所以不会出现续费后仍然欠费的状态。

命名空间：[AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

程序集：AntShares.SmartContract.Framework

## 语法

```c#
public extern uint Renew(byte years)
```

参数：续费年限，一年等于 2,000,000 个区块，字节类型。

返回值：续费后该资产可以使用到的区块高度。

## 示例

```

```



[返回上级](../Asset.md)