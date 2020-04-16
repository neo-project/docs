# Neo-GUI 介绍

Neo-GUI（GUI：Graphical User Interface 图形用户界面） 是 Neo 区块链上的全节点的应用程序，采用 Electron 跨平台技术，可在 Windows 10、macOS、Linux 系统上运行。整体界面分为以下四个模块：

| 区块链                | 钱包                           | 合约                             | 高级                             |
| --------------------- | ------------------------------ | -------------------------------- | -------------------------------- |
| [搜索](block.md#搜索) | [创建钱包](wallet.md#创建钱包) | [搜索合约](contract.md#搜索合约) | [选举](advanced.md#选举)         |
| [区块](block.md#区块) | [打开钱包](wallet.md#打开钱包) | [部署合约](contract.md#部署合约) | [投票](advanced.md#投票)         |
| [交易](block.md#交易) | [导入钱包](wallet.md#导入钱包) | [调用合约](contract.md#调用合约) | [签名](advanced.md#签名)         |
| [资产](block.md#资产) | [账户列表](wallet.md#账户列表) |                                  | [构造交易](advanced.md#构造交易) |
|                       | [交易记录](wallet.md#交易记录) |                                  | [数据转换](advanced.md#数据转换) |
|                       | [转账](wallet.md#转账)         |                                  | [插件管理](advanced.md#插件管理) |
|                       | [地址薄](wallet.md#地址薄)     |                                  |                                  |
|                       | [修改密码](wallet.md#修改密码) |                                  |                                  |

界面如下：

![](/assets/main.png)

## 下载与安装

Neo-GUI 是一个开源项目，可在 [GitHub](https://github.com/neo-ngd/Neo3-GUI/releases) 上下载对应系统版本的安装包。

> [!Note]
>
> 请确认你的 Windows 系统已安装 [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/current/runtime) 。

安装过程与其它软件类似，首先选择安装用户，点击 `下一步`。

![](/assets/setup1.png)

然后选择安装目录，点击 `安装`。

![](/assets/setup2.png)

![](/assets/setup3.png)

![](/assets/setup4.png)

最后点击 `完成` 即可。现在你已经完成了 Neo-GUI 的安装。 