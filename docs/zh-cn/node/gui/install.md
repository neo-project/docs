# 安装 Neo-GUI

Neo-GUI 是 Neo 区块链上的全节点的应用程序，采用 Electron 跨平台技术，可在 Windows 10、macOS、Linux 系统上运行。

其主要功能如下；

- 查看与搜索区块链信息
- 钱包基本操作，包括创建钱包、导入钱包、转账交易等
- 部署与调用智能合约
- 选举与投票共识节点

## 下载与安装

Neo-GUI 是一个开源项目，可在 [GitHub](https://github.com/neo-ngd/Neo3-GUI/releases) 上下载对应系统版本的安装包，根据安装提示完成安装即可。

> [!Note]
>
> 请确认你的 Windows 系统已安装 [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/current/runtime) 。

## 连接网络

完成安装后，需要将Neo-GUI接入Neo测试网或搭建好的私链，具体操作办法情参考：

- [切换到测试网](../../network/testnet.md#切换到测试网)
- 搭建私链中的

成功接入网络后，运行Neo-GUI, 将看到主页面上方显示的区块同步数据不断增长。