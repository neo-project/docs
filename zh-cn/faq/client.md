# 客户端

## 为什么使用 NEO-GUI 转账后没有看到资产变化？

在 NEO-GUI 中点击“交易记录”查看该笔交易是否已确认，如果已确认，查看你的客户端是否已同步到最高区块高度以及重建钱包索引。

## 为什么下载了离线同步包后没有加速同步速度？

请参考 [快速同步区块](../network/syncblocks.md)，并确认：

- 您下载了正确的离线包
- 下载的压缩包文件（ chain.0.acc.zip 或 chain.xxx.acc.zip） 直接放置到了客户端 NEO-CLI 或 NEO-GUI 根目录下
- 您没有修改离线包文件名
- 您已安装了 [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ImportBlocks.zip) 插件

## 如何确认客户端已经完全同步？

使用区块链浏览器查看最近区块高度，然后查看您客户端中的钱包高度，如果高度一样，说明客户端已完全同步。

## 如何做观察钱包（watch only）？

可以在 NEO-GUI 中新建一个地址，然后右键导入监视地址，输入需要监视的地址，
然后就能在交易记录里面看到每一笔交易信息。导入后需要重建钱包索引。

## 是否可以在一次交易中给多个地址进行转账？

可以。请参考 [交易](../node/gui/transc.md)。

## 主网节点部署机器的配置要求是什么？

运行节点客户端的机器需要配置双核 CPU，8G 内存，以及最低 100G 以上的固态硬盘，硬盘需根据实际需要扩容，防止 inode 溢出。

## NEO-CLI 是否有后台启动方式？

可以制作一些脚本，比如在 Windows 上创建一个记事本文件，输入`dotnet neo-cli.dll /rpc` 然后保存为.cmd文件或者在 linux 上使用 screen 命令。