# 调用合约

当一个智能合约部署到区块链上后，我们就可以通过合约的脚本哈希（Script Hash）来调用该合约。脚本哈希是合约的唯一标识，合约中任何脚本的修改都会导致脚本哈希的不同。

## 合约详情查询

使用 Neo-CLI 或 Neo-GUI 可以查询合约的详细信息，如合约的基本信息、入口点、方法、通知等。

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
   invoke <scriptHash> <operation> [contractParameters=null]    [witnessAddress=null]
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
invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]
```

在 Neo-GUI 中，在调用合约时，可以点击下方的 `附加签名`，选择 `公钥` 然后点击  `签名` 来进行附加签名。

> [!Note]
>
> 在通过转账命令调用 NEP-5 合约的 transfer 方法时，钱包会自动对 from 字段进行附加签名。此时不需要手动添加。

## 合约之间的互相调用

在 Neo3 中，所有的合约都可以动态调用，且合约编写更加简单。

```c#
public class Contract1 : SmartContract
{
    delegate object Dyncall(string method, object[] args);

    //0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 的小端序
    //HexToBytes()、ToScriptHash() 只能对常量进行操作，不能写在 Main 方法里
    //scriptHash 也可以改为从参数传入或从存储区中读取
    static byte[] ScriptHash = "f9f81497c3f9b62ba93f73c711d41b1eeff50c23".HexToBytes();

    public static object Main(string operation, object[] args)
    {
        if (operation == "name")
        {
            return Contract.Call(ScriptHash, "name", new object[0]);
        }
        if (operation == "totalSupply")
        {
            return Contract.Call(ScriptHash, "totalSupply", new object[0]);
        }
        return true;
    }
}
```

关键语句 `Contract.Call(scriptHash, method, params)`。

- scriptHash：被调用合约的脚本散列，ByteArray 类型，小端序。

- method：被调用合约的方法，如 `name`、`balanceOf`、`transfer` 等，字符串类型。

- params：被调用合约的方法的参数列表，数组类型。
