# 部署与调用合约

在本节我们将部署并调用上一节编写好的 NEP-5 合约。

## 部署合约

在开始部署之前，请确认您已经完成以下工作：

- 已确认您的合约需要部署。
- 已编译好一个合约文件（\*.nef ）和合约描述文件（\*.manifest.json ）。

### 使用 Neo-CLI 部署合约

在 Neo-CLI 中，部署合约的命令为：

 `deploy <nefFilePath> [manifestFile]`

-  `<nefFilePath>` ：必选参数，表示合约文件
-  `[manifestFile]` ：可选参数，表示合约描述文件

**示例**

```
deploy NEP5.nef
```

或

```
deploy NEP5.nef NEP5.manifest.json
```

输入完命令后，程序会部署此智能合约并且自动支付手续费。

```
neo> deploy NEP5.nef
Script hash: 0xb7f4d011241ec13db16c0e3484bdd5dd9a536f26
Gas: 3

Signed and relayed transaction with hash=0xe03aade81fb96c44e115a1cc9cfe984a9df4a283bd10aa0aefa7ebf3e296f757
```

更多智能合约部署信息请参考 [部署智能合约](../deploy/deploy.md)。

## 调用合约

### 在 Neo-CLI 中通过命令调用

使用 invoke 命令调用智能合约，命令如下：

   ```
invoke <scripthash> <command> [optionally quoted params separated by space]
   ```

参数说明：

   - `scripthash` ：要调用的合约脚本散列
   - `command` ：合约内方法名，后面可以输入传入参数，以空格隔开
   - `[optionally quoted params separated by space]` 为调用参数，目前只能传入字符串格式的参数。

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

   > [!Note]
   >
   > 当输入 invoke 命令后，节点并不是直接调用合约中的 `command` 方法。而是调用该合约的 `main` 方法，并将 `command` 和 `params` 作为实参传入。如果 main 方法里没有对 `command` 和 `params` 做处理，将不能返回预期的结果。

更多智能合调用信息请参考 [调用智能合约](../deploy/dinvoke.md)。



