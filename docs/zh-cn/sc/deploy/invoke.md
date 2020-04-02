# 调用合约

当一个智能合约已经部署到区块链上，如何调用其中的方法呢？

首先，我们要知道调用哪个合约。所以需要知道被调用合约的脚本散列（Script Hash）。脚本散列是合约的唯一标识，合约中任何脚本的修改都会导致脚本散列的不同。

## 合约详情查询

### 在 Neo-CLI 中查询合约

可以通过 [getcontractstate 方法](../../reference/rpc/latest-version/api/getcontractstate.md) 查询合约详情。

### 在 Neo-GUI 中查询合约

点击 `合约`、`搜索合约`，输入 `脚本散列`，点击 `搜索` 即可。

在 Neo-GUI 中会更直观地显示合约的基本信息、入口点、方法、通知等信息，也能查看 manifest 文件和 nef 文件。

## 调用合约

### 在 Neo-CLI 中通过命令调用

使用 invoke 命令调用智能合约，命令如下：

```
invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]
```

参数说明：

- `scripthash` ：要调用的合约脚本散列

- `operation` ：合约内方法名，后面可以输入传入参数，以空格隔开

- `contractParameters` 为调用参数，需要传入 JSON 格式的字符串，如果是 ByteArray，需要提前进行 Base64编码。

  示例：地址 `NfKA6zAixybBHHpmaPYPDywoqDaKzfMPf9` 可转换为 16 进制大端序的 ScriptHash `0xe4b0b6fa65a399d7233827502b178ece1912cdd4` 也可转换为 Base64 编码的 ScriptHash `1M0SGc6OFytQJzgj15mjZfq2sOQ=`。JSON 格式的参数如下：

  ```
  [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
  [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
  ```

- `witnessAddress` 为附加签名地址，只支持标准账户（单签地址），填写后 Neo-CLI 会为调用交易附加该地址的签名。

示例输入：

```
invoke 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26 name
```

示例输出：

```
Invoking script with: '10c00c046e616d650c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0103609
Evaluation Stack: [{"type":"ByteArray","value":"TXlUb2tlbg=="}]

relay tx(no|yes):
```

其中 VM State 为 `HALT` 表示虚拟机执行成功， VM State 为 `FAULT` 表示虚拟机执行时遇到异常退出。

Gas Consumed 表示调用智能合约时消耗的系统手续费。

Evaluation Stack 表示合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。

示例输入：

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"ByteArray","value":"1M0SGc6OFytQJzgj15mjZfq2sOQ="}]
```

示例输出：

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

示例输入：

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"0xe4b0b6fa65a399d7233827502b178ece1912cdd4"}]
```

或

```
invoke 0x230cf5ef1e1bd411c7733fa92bb6f9c39714f8f9 balanceOf [{"type":"Hash160","value":"d4cd1219ce8e172b50273823d799a365fab6b0e4"}]
```

示例输出：

```
Invoking script with: '0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14f9f81497c3f9b62ba93f73c711d41b1eeff50c2341627d5b52'
VM State: HALT
Gas Consumed: 0.0355309
Evaluation Stack: [{"type":"Integer","value":"9999999900000000"}]

relay tx(no|yes): no
```

> [!Note]
>
> 当输入 invoke 命令后，节点并不是直接调用合约中的 `operation` 方法。而是调用该合约的 `main` 方法，并将 `operation` 和 `contractParameters` 作为实参传入。如果 main 方法里没有对 `operation` 和 `contractParameters` 做处理，将不能返回预期的结果。

### 在 Neo-CLI 中通过 API 调用

在 Neo-CLI 中可以通过 [invokefunction](../../reference/rpc/latest-version/api/invokefunction.md) 和 [invokescript](../../reference/rpc/latest-version/api/invokescript.md) 来调用合约。其中后者比较难以操作，这里主要介绍 invokefunction 方法。

> [!Note]
>
> 你可以使用 [Postman](https://www.postman.com/) 来更方便地测试，下面是测试截图
>
> ![](./../../assets/api_3.jpg)

与上文的 invoke 命令很类似，invokefunction 也有三个参数。

- scripthash：智能合约脚本散列。注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。

- operation：操作名称（字符串）。与 invoke 命令中的 `operation` 相同。

- params：传递给智能合约操作的参数。与 invoke 命令中的 `contractParameters ` 参数相同。

  如：

  ```json
  {
    "type": "String",
    "value": "Hello"
  }
  ```

  ```json
  {
    "type": "Hash160",
    "value": "39e7394d6231aa09c097d02391d5d149f873f12b"
  }
  ```

  > [!Note]
  >
  > 注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序脚本散列；如果数据类型为 ByteArray，则输入小端序脚本散列。

调用示例：

请求 `POST http://127.0.0.1:10332`

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokefunction",
  "params": [
    "0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "0xe4b0b6fa65a399d7233827502b178ece1912cdd4"
      }
    ]
  ]
}
```

响应

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "0c14d4cd1219ce8e172b50273823d799a365fab6b0e411c00c0962616c616e63654f660c14266f539addd5bd84340e6cb13dc11e2411d0f4b741627d5b52",
        "state": "HALT",
        "gas_consumed": "3553180",
        "stack": [
            {
                "type": "Integer",
                "value": "10000000000000000"
            }
        ]
    }
}
```

其中 script 就是合约的调用脚本，可以翻译为下方（因为 NeoVM 是基于栈的虚拟机，执行时从下向上执行）：

```
PUSHDATA1 0xe4b0b6fa65a399d7233827502b178ece1912cdd4
PUSHDATA1 balanceOf
PUSHDATA1 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
SYSCALL System.Contract.Call
```

关于 Script 转为易读的 OpCode，可以参考 [OpCodeConverter](https://github.com/chenzhitong/OpCodeConverter)  项目。

其中 VM State 为 `HALT` 表示虚拟机执行成功， VM State 为 `FAULT` 表示虚拟机执行时遇到异常退出。

Gas Consumed 表示调用智能合约时消耗的系统手续费。

Evaluation Stack 表示合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。

> [!Note]
>
> 当输入 invokefunction 命令后，节点并不是直接调用合约中的 `operation` 方法。而是调用该合约的 `main` 方法，并将 `operation` 和 `params` 作为实参传入。如果 main 方法里没有对 `operation` 和 `params` 做处理，将不能返回预期的结果。

### 在 Neo-GUI 中调用合约

点击 `合约`、`调用合约`，输入 `脚本散列`，点击 `搜索` 即可。

然后 Neo-GUI 会根据合约列出当前合约的方法和参数列表。选择方法，填写参数，点击试运行，即可显示试运行结果。所谓试运行是指在本地创建了一个 NeoVM，模拟运行，并不会对区块链产生影响。

Neo-GUI 试运行的结果与 Neo-CLI 中的类似，这里就不重复阐述了。

如果想在区块链上调用，则需要在 `试运行` 成功后点击 `调用` 按钮。

## 附加签名

在现实世界，我们写一个收条或者合同，需要签名，可能是一个人签名，也可能是两个或者更多人签名。在智能合约中也是如此，一个调用合约的交易可以有多个签名，其中一个是交易的发起者对支持手续费的签名，其余的都是附加签名。

合约的某些方法通常只能允许指定的人调用，其它人调用将会失败。大部分合约都需要这样的权限管理。

在合约编写时，我们通常使用 `Runtime.CheckWitness(owner)` 来进行鉴权，其中 `owner` 是允许调用的人，参数类型为 ByteArray。

比如在进行合约升级时，这里的 `owner` 是合约管理员。在进行转账时，这里的 `owner` 是转出人（付款人）。

当合约中写了 `Runtime.CheckWitness(owner)` 时，调用合约时就要传入 `owner` 的签名。这个签名就是附加签名了。

在 Neo-CLI 中，我们可以通过 `invoke` 命令附加签名。

```
invoke <scriptHash> <operation> [contractParameters=null] [witnessAddress=null]
```

在 Neo-GUI 中，在调用合约时，可以点击下方的 `附加签名`，选择 `公钥` 然后点击  `签名` 来进行附加签名。

> [!Note]
>
> 调用合约时，所有 `Runtime.CheckWitness()` 的地方都需要附加签名吗？大部分是，但有一个例外。在通过转账命名来调用 NEP-5 合约的 transfer 方法时，钱包会自动对 from 字段进行附加签名。

## 合约之间的互相调用

在 Neo2 中合约之间可以通过静态调用和动态调用，而且相对比较麻烦。在 Neo3 中，所有的合约都可以动态调用，而且合约编写非常简单。

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

scriptHash 为被调用合约的脚本散列，ByteArray 类型，小端序。

method 为被调用合约的方法，如 `name`、`balanceOf`、`transfer` 等，字符串类型。

params 为被调用合约的方法的参数列表，数组类型。

