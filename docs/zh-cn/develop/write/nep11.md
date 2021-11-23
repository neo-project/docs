# NEP-11 合约编写

NEP11 协议是 Neo 补充协议中的第 11 号协议，定义了 NFT（非同质化资产）的合约编写标准。本文将以 C# 代码为例，讲解如何编写一个简单的 NFT 合约。

## 定义 NFT 属性

开发者编写 NFT 合约最方便的方法是直接继承 `Nep11Token<Nep11TokenState>` 类。其中，`Nep11TokenState` 是保存 NFT 所有属性的类，这里除了默认的 Name 和 Owner，还可以添加自定义的属性，如图片、视频、类别、网址、攻击力、防御力等。

| 字段  | 示例                                       | 描述             |
| ----- | ------------------------------------------ | ---------------- |
| Name  | HarryPotter #001                           | NFT 名称         |
| Owner | 0x4578060c29f4c03f1e16c84312429d991952c94c | NFT 拥有者       |
| Type  | 0                                          | 类型（自定义）   |
| Image | https://neo.org/images/HarryPotter.jpg     | 图片（自定义）   |
| ATK   | 3000                                       | 攻击力（自定义） |
| DEF   | 3000                                       | 防御力（自定义） |

每个 NFT 资产都需要一个唯一的标识符号，如果你的合约中每个 NFT 资产名字都不相同，可以将 `Nep11TokenState` 中的 Name 字段当做 TokenID。如果有重名的 NFT 资产，需要自己添加一个新的字段，例如 ID 或 TokenID。

特别说明的是，为了使得钱包正确显示 NFT 的图片，建议合约开发者将图片字段命名为 **Image**。钱包的开发者也可根据 NFT 的 Image 属性来抓取 NFT 的图片。

TokenState 的示例代码如下：

```c#
public class MyTokenState : Nep11TokenState
{
    public string Image { get; set; }
    
    public MyTokenState(string name)
    {
        //TODO: Replace it with your own URL.
        Image = "https://neo.org/images/" + name + ".jpg";
    }
}
```

继承 `Nep11Token<Nep11TokenState>` 后，需要重写 Symbol 方法，如下：

```c#
public override string Symbol() => "MNFT";
```

## 分发方法

`Nep11Token` 基类中并不包含如何分发 NFT 的方法，开发者可以根据需求定制。本示例中为了让合约拥有者有权限发行 NFT 资产，创建了 `Airdrop` 方法，其功能是合约拥有者可以向指定地址空投一个 NFT。

```c#
public static bool Airdrop(UInt160 to, string name)
{
    if (!IsOwner()) throw new Exception("No authorization.");
    if (!to.IsValid) throw new Exception("Amount is invalid.");

    Mint(name, new MyTokenState(name));
    return true;
}
```

其中，Mint 方法继承于 Nep11Token，调用的时候，只需传入 NFT 的 TokenID（本示例中用 Name 表示） 和 TokenState 对象即可。

## 代码示例

完整的合约示例代码如下：

```c#
using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;
using System;

namespace Contract1
{
    [SupportedStandards("NEP-11")]
    public class Contract1 : Nep11Token<MyTokenState>
    {
        //TODO: Replace it with your own address.
        [InitialValue("NiNmXL8FjEUEs1nfX9uHFBNaenxDHJtmuB", ContractParameterType.Hash160)]
        static readonly UInt160 Owner = default;

        private static bool IsOwner() => Runtime.CheckWitness(Owner);

        public override string Symbol() => "MNFT";

        public static bool Airdrop(UInt160 to, string name)
        {
            if (!IsOwner()) throw new Exception("No authorization.");
            if (!to.IsValid) throw new Exception("Amount is invalid.");

            Mint(name, new MyTokenState(name));
            return true;
        }
    }

    public class MyTokenState : Nep11TokenState
    {
        public string Image { get; set; }

        public MyTokenState(string name)
        {
            //TODO: Replace it with your own URL.
            Image = "https://neo.org/images/" + name + ".jpg";
        }
    }
}

```

如果想让用户通过 GAS 购买 NFT，可以添加如下方法：

```c#
public static void OnNEP17Payment(UInt160 from, BigInteger amount, object _)
{
    
    if (Runtime.CallingScriptHash != GAS.Hash)
        throw new Exception("Please pay with GAS");
    amount /= 100000000;
    for (int i = 0; i < amount; i++)
    {
        //TODO: Please replace with your own naming logic. TokenId is not allowed to be the same
        var name = "HarryPotter #001";
        Mint(name, new MyTokenState(name));
    }
}
```

到此，一个简单的 NFT 合约就编写好了。

## 基类方法和事件

Nep11Token 基类还提供了以下方法和事件。

#### NEP-11 方法

| 名称        | 参数                                           | 返回值           | 说明                                                         |
| ----------- | ---------------------------------------------- | ---------------- | ------------------------------------------------------------ |
| symbol      | --                                             | String           | 返回合约符号，如 "MNFT"                                      |
| decimals    | --                                             | Integer          | 返回整数 0                                                   |
| totalSupply | --                                             | Integer          | NFT 总发行量。总发行量 = 铸币的总量 - 销毁的总量             |
| balanceOf   | Hash160（owner）                               | Integer          | 该用户持有的 NFT 的总量                                      |
| ownerOf     | ByteArray（tokenId）                           | Hash160          | 查询某个 NFT 的所有者                                        |
| properties  | ByteArray（tokenId）                           | Map              | 查询某个 NFT 的属性                                          |
| tokens      |                                                | InteropInterface | 查询所有已发行的 NFT                                         |
| tokensOf    | Hash160（owner）                               | InteropInterface | 查询某个人拥有的 NFT                                         |
| transfer    | Hash160（to） ByteArray（tokenId） Any（data） | Boolean          | 转账，通过 TokenId，将 NFT 转给他人，该方法需要 NFT 的所有者签名。 |

#### 事件

| 名称     | 参数                                                         | 说明     | 备注                                                  |
| -------- | ------------------------------------------------------------ | -------- | ----------------------------------------------------- |
| transfer | Hash160（from） Hash160（to） Integer（amount） ByteArray（tokenId） | 转账事件 | from 为 null 即铸币 to 为 null 即销毁 amount 始终为 1 |

## 相关参考

[NEP-11 规范](https://github.com/neo-project/proposals/blob/master/nep-11.mediawiki)

[基类 Nep11TokenState 源码](https://github.com/neo-project/neo-devpack-dotnet/blob/master/src/Neo.SmartContract.Framework/Nep11TokenState.cs)

[基类 Nep11Token 源码](https://github.com/neo-project/neo-devpack-dotnet/blob/master/src/Neo.SmartContract.Framework/Nep11Token.cs)

[NeoVerse 合约文档](https://github.com/chenzhitong/neoverse-readme)

