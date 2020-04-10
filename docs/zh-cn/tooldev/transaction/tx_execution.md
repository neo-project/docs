# 交易流程

交易，是区块链网络交互操作的唯一方式，包括发布资产，转账，部署智能合约，合约调用等等，都是基于交易的方式进行操作处理。

## 一般流程

![](..\images\tx_execution\tx_flow_graph.jpg)

一笔交易，在NEO-CLI、NEO-GUI或通过RPC请求被创建，经钱包签名，构建出完整的交易数据，并通过节点进行验证和全网广播。

共识节点收到该笔交易后，校验并放入到内存池。在某次共识阶段，议长打包该交易到新块中。最后，伴随着新块的全网广播，该交易被全网节点执行处理。 整个流程可以简化成下图：

![](..\images\tx_execution\tx_process_flow.jpg)

1. 交易构建： 用户发起一笔交易

2. 交易签名： 完成对交易签名，解锁交易输入

3. 交易广播： 广播交易

4. 交易打包： 共识议长打包交易到新块中

5. 交易处理： 经共识出块广播，交易被全网节点执行处理

### 创建交易

用户可通过NEO-CLI、NEO-GUI或通过RPC请求创建交易，最后经钱包，构建出完整的交易。

1. 通过NEO-CLI指令
  
  ```bash
   send <id|alias> <address> <value> 
  ```
  
  其中
  - id|alias：资产ID或名称
  - address：对方地址
  - value: 转账金额

  ```bash
   deploy <nefFilePath> [manifestFilePath] 
  ```

  其中
  - nefFilePath: NeoVM 的可执行文件 .nef 的路径
  - manifestFilePath: .manifest.json 文件的路径。当与.nef同一路径下时，可缺省不填

  ```bash
   invoke <scriptHash> <operation> [contractParameters] [witnessAddress]
  ```

  其中
  - scriptHash: 合约脚本哈希
  - operation：合约内方法名
  - contractParameters：合约方法参数，方法无参时，可缺省不填
  - witnessAddress：见证人地址

2. 通过NEO-RPC调用

  - sendfrom：从指定地址，向指定地址转账

  - sendtoaddress：向指定地址转账

  - sendmany：批量转账命令，并且可以指定找零地址

   具体用法请参考[API 参考](../../reference/rpc/latest-version/api.md)。
  
3. 通过NEO-GUI界面

  具体操作请参考 [交易](../../node/gui/transc.md)。

钱包构建完整交易接口定义：

```c#
public Transaction MakeTransaction(TransferOutput[] outputs, UInt160 from = null);
```

其中
  - outputs：转账信息，包括资产ID，转账金额以及发送方地址哈希
  - from：转账的付款账户

```c#
public Transaction MakeTransaction(byte[] script, UInt160 sender = null, TransactionAttribute[] attributes = null, Cosigner[] cosigners = null)
```

其中
  - script：交易的合约脚本
  - sender：发送方的地址哈希
  - attributes：交易属性
  - cosigners：交易签名信息，可限定签名作用范围

**钱包生成完整交易步骤**：

1. 若涉及NEP-5资产转账时，调用合约`transfer`方法进行NEP-5资产的转账。
    1. 若指定了转账账户，则查询该账户下对应资产的余额。若余额小于待转金额，转账失败，交易构建失败
    2. 否则，对钱包所有非Lock且非WatchOnly账户的指定资产按照<账户，余额>进行分组
        1. 若所有账户的总资产小于待转金额，转账失败，交易构建失败
        2. 否则，查找满足转账金额的最少资产的账户进行转账
2. 计算总的GAS消耗，包括手续费 和 用户支付的网络费
    1. 若指定了转账账户，查找该账户下GAS余额。若小于总的GAS消耗，交易构建失败
    2. 否则，对钱包所有非Lock且非WatchOnly账户的GAS资产按照<账户，余额>进行分组
        1. 若存在账户的余额不小于总的GAS消耗，交易构建成功
        2. 否则，交易构建失败

### 签名验证

在前面的章节提到，一个账户地址，实际上代表的就是一段`SysCall "Neo.Crypto.CheckSig"`或者`SysCall "Neo.Crypto.CheckMultiSig"`[合约代码](../wallets.md#地址)，执行时需要提供签名参数。在NEO交易验证时，需要对涉及的脚本进行执行验证，故在执行前，需提供相应的脚本所需参数，如交易签名参数。这些参数与对应的脚本，最终被封装在交易的[见证人(Witness)](./transaction.md#witness)列表中。

交易签名，实际上是添加地址脚本的签名参数，构建完整可执行的见证人(Witness)，其签名步骤如下：

**签名步骤**：

1. 封装交易为`ContractParametersContext`对象（`ContractParametersContext`是对要进行签名验证的对象包装，负责添加合约脚本参数，构建完整的见证人）。

2. 对于交易待验证脚本的ScriptHashes的每个对象，取得相应的账户，若对应帐户为空，或该账户没有密钥串，则跳过；

3. 用该密钥串对交易的未签名的序列化数据进行`ECDsa`方法签名；

4. 添加签名参数，存放到参数列表对应位置上，具体步骤如下：

    1. 若输入脚本是多重签名，则根据输入脚本合约Contract创建`ContextItem`（`ContextItem`是对一个脚本合约的参数封装）。
      
        1. 解析地址脚本字节码中包含的待签名地址公钥，若签名地址不在其中，则签名失败。

        2. 保存该签名

        3. 当最少签名数满足时，按照签名对应的公钥在脚本中的保序映射关系(order-preserving mapping, 若地址A在地址B前面，则A的签名参数在B的签名参数前面)，依次插入签名参数。（多重签名情况下，还需要别的账户地址进行签名，补充签名参数）
        
    2. 若输入脚本不是多重签名，判断contract.ParameterList中是否存在唯一的0x00（类型ContractParameterType.Signature）：

        1. 若不存在，返回false；

        2. 若存在多个抛异常；
        
        3. 将contract的Parameters的index位置赋值为signature

5. 若所有的脚本参数已齐全，则得到交易的见证人列表。（如，多重签名情况下，还需要别的账户地址进行签名，补充签名参数）

**交易验证**

1. **合法性验证**

   1. 交易签名账户是否是黑名单账户

   2. 交易发送方余额是否不小于交易手续费

   3. 签名账户数是否等于见证人个数

   4. 交易大小是否不超过最大交易限制
   
   5. 虚拟机验证交易签名执行的指令费用是否不小于0

2. **交易脚本校验**

   1. 获取交易中待校验脚本的签名账户hash列表：

   2. 获取交易的见证人列表。若对应脚本hash的验证脚本不存在，则就是hash指向的脚本。

   3. 分别加载验证脚本与执行脚本，通过NVM进行执行，若执行返回False，则校验失败。

需要对交易进行验证的地方：

1. 节点收到一笔交易时。

2. 节点产生/转发一笔交易时。

3. 节点持久化区块后对剩余待验证交易的验证。

4. 共识过程中，对于尚未校验的待打包交易，进行校验。

> [!NOTE]
>
> - 对需要验证的脚本，提供好参数，最后通过NVM进行执行，若都返回True, 则脚本通过验证。
> - 每一个地址，都是一段`SysCall "Neo.Crypto.CheckSig"`代码段，执行的时候，都需要签名参数。类似的多签合约地址，调用的是`SysCall "Neo.Crypto.CheckMultiSig"`方法，需要指定数量的签名参数。
> - 当遇到自定义的地址脚本时，需要按照对方的脚本形参，提前准备好参数（不一定是签名参数）进行验证。

### 广播推送

钱包所在节点，将进行P2P广播该交易。

![![tx_p2p_flow](../images/tx_execution/tx_p2p_flow.jpg)](..\images\tx_execution\tx_p2p_flow.jpg)

**广播步骤**：

1. 若本地节点启动了共识模块，则触发[共识模块的新交易事件](../consensus/consensus_protocol.md#6_tx_handler)。

2. 本地节点在广播交易前，会先对交易进行校验，并添加到内存池中：

    1. 若交易已经在内存池或区块链中，则校验失败。

    2. 进行交易自身的检查，包括合法性检查和校验脚本执行。

    3. 加载[插件](https://github.com/neo-project/neo-plugins/blob/master/SimplePolicy/SimplePolicyPlugin.cs#L18)进行过滤。

    4. 若上述校验通过，则添加到内存池。

3. 本地节点发送`inv`消息，并附带上交易的hash数据。

4. 若远程节点已收到过该hash对应的数据，或在短时间内，已经重复获取该inv消息时，则不处理；否则，进入步骤5。

5. 远程节点向外广播`getdata`消息，附带上`inv`消息中的hash数据。

6. 本地节点收到`getdata`消息后，则发送`tx`消息并携带上交易数据给对方。

7. 远程节点收到交易数据后, 回到步骤1执行，进行转发广播。

### 交易打包

共识过程中，议长将打包该交易进行提案投票，最后将新块广播到网络上。

1. 议长将内存池交易全部取出，并进行插件过滤和排序。

2. 将过滤后的交易，打包到新的提案块中，进行共识投票。

3. 若有超过 `N-f` 个节点投票赞同，则新块完成出块，进行广播新块。

### 交易处理

节点接收到新块后，验证块，最后进行持久化块操作。

**Core.Blockchain对block的处理**

随着对区块的持久化操作，每种交易的最终处理，也在该过程进行处理:

1. 若涉及到资产转账，则更新相应账户的资产变动。

2. 若账户有参与验证人投票时，更新 validators , validators_count的对应投票数。

11. 删除非冻结用户且资产为零，非验证人的账户信息

12. 持久化各数据
