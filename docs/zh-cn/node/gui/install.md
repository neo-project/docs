# 安装

> [!Note]
>
> 如无特别说明，本文中的描述均假设 NEO-GUI 运行在测试网。有关测试网与主网的切换，请参阅 [测试网](../../network/testnet.md)。

## 下载与运行客户端

客户端无需安装，进入[客户端下载](https://neo.org/download)页面，下载后直接运行 neo-gui.exe 即可。使用过程中，如遇到任何问题导致客户端无法正常使用，请保留好客户端目录下的 error.log 文件，并与我们的技术人员联系。

> [!Note]
>
> 客户端适应系统为： Windows 7 SP1 / Windows 8 / Windows 10。
>
> 请确认你的 Windows 系统已安装 [.NET Framework 4.7.1](https://www.microsoft.com/net/download/framework) 。

## 安装插件

要使客户端能够进行离线同步，需要安装 ImportBlocks 插件：

1. 下载 [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.4/ImportBlocks.zip) 插件并解压。
2. 在 NEO-GUI 根目录新建 Plugins 文件夹（注意首字母大写），将解压出来的插件拷贝到其中。

## 快速同步区块数据

客户端运行时会自动同步区块数据，打开钱包时也会自动同步钱包数据，当同步完成后才可以正常使用客户端以及查看钱包内资产。由于区块链数据庞大，初次同步时等待时间通常很久，建议采用离线同步包进行同步，相关信息，请参见 [快速同步区块数据](../syncblocks.md)。