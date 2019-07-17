# Asset.Renew 方法 (byte[])

为资产续费。

该方法是 2.0 版新增的方法，2.0 版后区块链上注册的资产需要缴纳年费才可以使用，否则将会进入冻结状态。

当资产到期后需要为资产进行续费。当资产未冻结时，续费是从资产到期时间开始续费，当资产已冻结时，续费是从当前时间开始续费，所以不会出现续费后仍然欠费的状态。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern uint Renew(byte years)
```

参数：续费年限，一年等于 2,000,000 个区块，字节类型。

返回值：续费后该资产可以使用到的区块高度。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        //以NEO资产为例
        byte[] asset = { 197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 14, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155 };
        Asset ass = Blockchain.GetAsset(asset);
        uint blockIndex = ass.Renew(1);
    }
}
```



[返回上级](../Asset.md)