# 调用合约

当一个智能合约部署到区块链上后，我们就可以通过合约的脚本哈希（Script Hash）来调用该合约。脚本哈希是合约的唯一标识，合约中任何脚本的修改都会导致脚本哈希的不同。

## 合约详情查询

使用 Neo-CLI 或 Neo-GUI 可以查询合约的详细信息，如合约的基本信息、方法、通知等。

### 使用 Neo-CLI 查询

使用RPC API [getcontractstate 方法](../../reference/rpc/latest-version/api/getcontractstate.md) 查询合约详情。

### 使用 Neo-GUI 查询

1. 在 Neo-GUI 中点击 `合约` ->`搜索合约`
2. 输入合约哈希，点击 `搜索` 。

Neo-GUI 中会更直观地显示合约信息，也能查看 manifest 和 nef 文件。

## 调用合约

### 使用 Neo-CLI 调用

在 Neo-CLI 中可以选择以下一种方式调用智能合约：

- 使用 invoke 命令调用智能合约，命令如下：

   ```
   invoke <scriptHash> <operation> [contractParameters=null] [sender=null] [signerAccounts=null] [maxGas=20]
   ```

   详情请参考 [invoke](../../node/cli/cli.md#invoke) 命令。

- 使用 RPC API [invokefunction](../../reference/rpc/latest-version/api/invokefunction.md) 或 [invokescript](../../reference/rpc/latest-version/api/invokescript.md) 来调用合约。推荐使用 invokefunction 方法。

### 使用 Neo-GUI 调用

1. 在 Neo-GUI 中点击 `合约 `->`调用合约`。

2. 输入合约哈希，点击 `搜索` 。

   Neo-GUI 中将会列出当前合约的方法和参数列表。

3. 选择方法，填写参数，点击`试运行`，即可查看试运行结果。

   所谓试运行是指在本地创建了一个 NeoVM，模拟运行，并不会对区块链产生影响。

4.  试运行成功后，如果想在区块链上调用，点击 `调用` 按钮。

## 附加签名

有些合约在调用时需要多个签名，其中一个是交易的发起者对支持手续费的签名，其余的都是附加签名。

在合约编写时，我们通常使用 `Runtime.CheckWitness(owner)` 来鉴权调用者地址，其中 `owner` 是允许调用的地址，参数类型为 ByteArray，未指定的地址调用合约将失败。比如在进行合约升级时，这里的 `owner` 是合约管理员。在进行转账时，这里的 `owner` 是转出人（付款人）。

当合约中写了 `Runtime.CheckWitness(owner)` 时，调用合约时就要传入 `owner` 的签名。这个签名就是附加签名了。

在 Neo-CLI 中，我们可以通过 `invoke` 命令附加签名。

```
invoke <scriptHash> <operation> [contractParameters=null] [sender=null] [signerAccounts=null] [maxGas=20]
```

在 Neo-GUI 中，在调用合约时，可以点击下方的 `附加签名`，选择 `公钥` 然后点击  `签名` 来进行附加签名。

> [!Note]
>
> 在通过转账命令调用 NEP-17 合约的 transfer 方法时，钱包会自动对 from 字段进行附加签名。此时不需要手动添加。

## 合约之间的互相调用

在 Neo N3 中，所有的合约都可以动态调用，且合约编写更加简单。

```c#
public class Contract1 : SmartContract
    {
        delegate object Dyncall(string method, object[] args);

        //如果是小端序，使用 ByteArray 格式
        //[InitialValue("694425c17f1ebb7c65de3026c831eb4c49d6d7be", ContractParameterType.ByteArray)]
        //private static readonly UInt160 ScriptHash;

        //如果是大端序，使用 Hash160 格式
        [InitialValue("0xbed7d6494ceb31c82630de657cbb1e7fc1254469", ContractParameterType.Hash160)]
        public static UInt160 ScriptHash;

        public static object Main(string operation, object[] args)
        {
            if (operation == "name")
            {
                return Contract.Call(ScriptHash, "name", CallFlags.ReadOnly, new object[0]);
            }
            if (operation == "totalSupply")
            {
                return Contract.Call(ScriptHash, "totalSupply", CallFlags.ReadOnly, new object[0]);
            }
            return true;
        }
    }
```

关键语句 `Contract.Call(scriptHash, method, flags, params)`。

- scriptHash：被调用合约的脚本散列，ByteArray 类型，小端序。

- method：被调用合约的方法，如 name 、 balanceOf 、 transfer 等，字符串类型。

- flags：调用合约方法时允许的权限，参考 ([CallFlags 枚举](https://docs.neo.org/docs/zh-cn/reference/scapi/framework/services/CallFlags.html#%E5%8F%82%E6%95%B0%E8%AF%B4%E6%98%8E))。

- params：被调用合约的方法的参数列表，数组类型。

### 权限相关字段

在合约的 Manifest 文件中定义了三个与权限相关的字段，参见下表。通过 Groups 和 Trusts 字段，钱包会根据合约之间是否可信，或者合约是否在同一组中来决定是否给用户安全警告。而 Permissions 和签名作用域决定了合约之间能否互相调用。关于签名作用域，请参考 [invokefunction 方法](../../reference/rpc/latest-version/api/invokefunction.md) 的参数说明。

| 字段          | 类型                          | 说明                                                         |
| ------------- | ----------------------------- | ------------------------------------------------------------ |
| `Groups`      | `ContractGroup[]`             | 定义一组相互信任的合约，由公钥和对合约Hash的签名组成。       |
| `Permissions` | `ContractPermission[]`        | 该字段是一个包含一个权限对象的数组，定义了该合约想要调用的其它合约及其方法。其中合约可以是 ScriptHash， Group，或通配符 *。方法是方法名或通配符 *。没有在 manifest 中声明的合约或方法将无法被合约调用。 |
| `Trusts`      | `WildcardContainer\<UInt160>` | 定义该合约信任的其它合约，合约可以是 ScriptHash，Group，或通配符 *。如果一个合约是可信的，当合约调用时，用户界面将不会给出任何警告。 |

下表以 A 合约调用 B 合约时为例，详细说明了在各种设置场景下，合约的调用行为和钱包行为。

| 场景                                                         | 钱包提示                                                     | 钱包设置签名作用域                                | 合约预期行为 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------- | ------------ |
| A 合约的 Permissions 不包括 B 合约                           | 无                                                           | 默认                                              | 禁止调用     |
| A 合约的 Permissions 包括 B 合约<br/>A 合约和 B 合约在同一 Groups 且 Groups 签名验证通过 | 无                                                           | 在默认基础上增加 CustomGroups                     | 允许调用     |
| A 合约的 Permissions 包括 B 合约<br/>B 合约的 Trusts 包括 A 合约 | 无                                                           | 在默认基础上增加CustomContract                    | 允许调用     |
| A 合约的 Permissions 包括 B 合约<br/>B 合约的 Trusts 不包括 A 合约 | 提示 A 将调用 B 合约，可能有风险，询问是否将签名授权给 B 合约 | 设置为默认，并根据用户决定是否增加 CustomContract | 由用户决定   |
| A 合约的 Permissions 包括一个 Groups B                       | 提示 A 将调用 B 组中的任意合约，可能有风险，询问是否将签名授权给 B 组 | 设置为默认，并根据用户决定是否增加 CustomGroups   | 由用户决定   |
| A 合约的 Permissions 中合约为通配符 \*，方法为 m<br/>{"contract":"\*", "method": "m"} | 提示 A 将调用任意合约的 m 方法，可能有风险，询问是否将签名授权给 B 合约 | 根据用户决定，设置为默认或 Global                 | 由用户决定   |
| A 合约的 Permissions 中合约为通配符 \*，方法为通配符 \*<br/>{"contract":"\*", "method": "\*"} | 提示 A 将调用任意合约的任意方法，可能有风险，询问是否将签名设置为 全局 | 根据用户决定，设置为默认或 Global                 | 由用户决定   |

钱包的默认签名作用域建议为 CalledByEntry。

