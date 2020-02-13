# 准备工作

本文将以在 Neo 区块链上发布一个 NEP-5 资产为例，一步步带领开发者完成开发环境的搭建和配置，编写智能合约以及在私链上部署和调用合约。

Neo 有两个全节点客户端：Neo-GUI 和 Neo-CLI。本教程将使用 Neo-CLI 搭建私链供节点连接，使用 Neo-GUI 发布智能合约，关于客户端的详细信息，可参考 [Neo节点介绍](../../node/introduction.md)。

## 系统环境

Neo-GUI 支持以下环境：

Windows 7 SP1 / Windows 8 / Windows 10

Windows 10 之前版本的系统需要安装 [.NET Framework 4.7.1](https://www.microsoft.com/net/download/framework)

Neo-CLI 支持以下环境：

- Linux (ubuntu 16.04 及以上)
- Windows 10

> [!NOTE]
>
> 由于同时涉及到 Neo-GUI 和 Neo-CLI ，建议直接使用 Windows 10 的系统。
>
> 本教程中的描述均发生于 Windows 10 系统上，由于部分环境和依赖项的配置在不同系统上都有差异，如读者使用其他系统，请参考 [开发环境](../devenv/getting-started-csharp-mac.md) 中对应章节。

## 下载客户端

- Neo-GUI

  进入 [GitHub](https://github.com/neo-project/neo-gui/releases) 下载最新的Release版本，直接运行 neo-gui.exe 即可。

- Neo-CLI

  以 Windows 10为例：

  在 GitHub 上下载系统对应的 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 程序包并解压。


## 继续阅读

[搭建本地网络](enviroment.md)