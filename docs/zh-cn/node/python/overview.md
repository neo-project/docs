*本文翻译自：https://neo-python.readthedocs.io/en/latest/index.html*

# 概述

## neo-python 目前功能

- 此项目的目标是成为原始 C# [NEO 项目](https://github.com/neo-project) 的全功能移植
- 运行基于 Python 的 P2P 节点
- 提供可交互 CLI 用于配置节点和检测区块链
- 编译、测试、部署以及运行以 python 编写的智能合约或任意 `.avm` 格式的合约
- 符合 [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) 和 [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 标准的钱包功能
- RPC 客户端
- RPC 服务器
- 通知服务器 （用于查看 NEP5 通证的转账）
- `Runtime.Log` 与 `Runtime.Notify` 事件监控

## 入门指南

请按照 [安装](install.md) 章节的说明进行开始操作。

此项目的主要功能包含在 cli 应用程序的 `np-prompt` 命令中。详情请参见  [使用命令行与 NEO 区块链交互](prompt.md)

我们发布了一个 Youtube [视频](https://youtu.be/oy6Z_zd42-4) 帮助你快速上手。在[CityOfZion](https://www.youtube.com/channel/UCzlQUNLrRa8qJkz40G91iJg) 的 Youtube 频道下还有其它视频可供参考。

## 相关项目

- [neo-python-rpc](https://github.com/CityOfZion/neo-python-rpc): NEO RPC Python 客户端 
- [neo-boa](https://github.com/CityOfZion/neo-boa): 使用 Python 编写智能合约