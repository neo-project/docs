# 部署智能合约

智能合约的部署是将智能合约部署到区块链中，供其它用户使用或者供其它智能合约调用。本文将介绍如何使用 Neo-CLI 和 Neo-GUI 在 Neo 区块链上部署智能合约。本文中的操作步骤是通用的，适用于包括 NEP5 资产在内的所有合约类型。

## 为什么需要部署？

当一个智能合约需要在区块链上存储数据或被其它智能合约调用（称为 appcall）时，需要部署。而仅由合约账户鉴权触发的合约，如锁仓合约、多方签名合约，不会被其它合约调用，所以无需部署。像 `return 1+1` 这样的合约，因为没有任何需要输入的参数，也无需部署。 

从编程语言的角度来说，当智能合约要作为一个类库使用时，才需要被部署。比如以下情况：

- 当一个智能合约有可变的传入参数，此时它必须作为一个类库，由调用者（Invocation 交易）或者其它的智能合约提供参数。
- 当一个智能合约使用存储区（Storage）时，必须作为一个类库。
- 当一个智能合约实现了 NEP-5（合约资产）时，需要将该合约部署到区块链上。

智能合约的部署是通过 Invocation 交易调用 API 来部署。通常的做法是通过 Neo-CLI 或 Neo-GUI 的智能合约发布功能来部署合约。

部署智能合约以及调用智能合约均会产生费用，详情请参见 [系统手续费](../fees.md)。

## 准备工作
在开始部署之前，请确认您已经完成以下工作：

- 已确认您的合约需要部署。
- 已编译好一个合约文件（\*.nef ）和合约描述文件（\*.manifest.json ）。
- 已安装 Neo-CLI 或 Neo-GUI 并完成区块同步。相关信息请参阅 [使用 Neo-CLI](../../node/cli/setup.md) 和 [使用 Neo-GUI](../../node/gui/install.md)。

## 使用 Neo-CLI 部署合约

在 Neo-CLI 中，部署合约的命令为：

 `deploy <nefFilePath> [manifestFile]`

-  `<nefFilePath>` ：必选参数，表示合约文件
- `[manifestFile]` ：可选参数，表示合约描述文件

### 示例

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

### 常见错误

`Engine faulted`

- 合约已经存在
- nef 文件和 manifest 文件不匹配
- nef 文件或 manifest 错误
- 手续费不足

## 使用 Neo-GUI 部署合约

1. 在 Neo-GUI 中点击 `合约` -> `部署合约`。
2. 选择合约文件（\*.nef ）和合约描述文件（\*.manifest.json ）。
3. 点击 `确认部署`。

