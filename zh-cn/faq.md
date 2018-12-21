# 常见问题

## 一般问题

**NEO 是什么？**

NEO 是利用区块链技术和数字身份进行资产数字化，利用智能合约对数字资产进行自动化管理，实现“智能经济”的一种分布式网络。NEO 网络中内置了两种通证，管理通证 NEO 和燃料通证 GAS。

**NEO 有哪些开发社区？**

NEO 非常重视社区的发展，拥有庞大的全球开发者社区，长期以来为 NEO 的开发提供支持，目前代表性的社区有：

- **CoZ**，NEO 生态最早的开发者社区：https://github.com/CityOfZion
- **NEL**，NEO 生态首个中文开发者社区：https://github.com/NewEconoLab
- **NeoResearch**，南美开发者社区：https://github.com/NeoResearch
- **NSPCC**，俄罗斯圣彼得堡开发者社区：https://www.nspcc.ru/en/
- **KeyMakers**，NEO 日本社区：https://github.com/keymakers

**什么是 GAS？如何提取 GAS？**

GAS 代表了 NEO 区块链的使用权，NEO 网络中的资产发行以及智能合约的运行和存储需要花费一定量的 GAS。GAS 初期为 0，会随着新区快的生成而产生。只要获得 NEO，GAS 便会在系统中按照算法自动生成。GAS 有两种状态，可提取和不可提取。当账户中的 NEO 花费后（即转出），其产生的 GAS 会转变成可提取状态。NEO 持有人可以在任意时间发起一笔认领交易，将这些可提取的 GAS 认领到 NEO 的地址上。

**是否可以通过给自己转账将 GAS 变为可提取状态？** 

可以。如果钱包里只有一个地址也可以。

**NEO 采用什么共识机制？**

NEO 使用 一种改进的拜占庭容错机制 （dBFT），可以对由 𝑛 个共识节点组成的共识系统，提供 𝑓 = ⌊ (𝑛−1) / 3 ⌋ 的容错能力。在这个机制当中，存在两种节点：记账节点和普通节点。普通节点基于持有 NEO 的比例来投票选出记账节点，当需要通过一项共识时，在这些记账节点中随机推选出一名议长拟定方案，然后由其他记账节点根据拜占庭容错算法进行投票，如果大于等于 2/3 的节点同意发言人方案，则共识达成；否则，重新推选议长，重复投票过程。

**如何成为 NEO 的共识节点？ 成为共识节点有什么激励吗？**

NEO 的共识节点由 NEO 持有者投票选出。详细信息可参考 [这里](https://neo-ngd.github.io/reference/如何成为NEO共识节点.html)。

**有哪些 NEO 的区块链浏览器可以使用？**

您可以访问 http://ndapp.org/ ，在 Explorer 页签下选择所需要的区块链浏览器使用。

**普通资产和 NEP-5 资产的区别是什么？**

NEO 中主要有两种资产，一种是全局资产，例如：NEO、GAS 等，使用 UTXO 模型来管理资产。另一种是合约资产，例如 NEP-5 类型的资产，使用 BALANCE 模型来管理资产。NEO 和 GAS 是 UTXO 资产，直接可以进行交易。NEP-5 是合约资产，利用合约的性质进行调用从而交易。使用 NEO-GUI 可以注册与发行新的 UTXO 资产，而要发行 NEP-5 资产，需要编写智能合约。

**如何在 NEO-CLI 中查看 NEP-5 资产？**

使用 NEO-CLI 中的 `list asset` 只能显示 UTXO 资产，想要看到 NEP-5 资产，需要调用 API `getbalance`。

**NEP-5 和 NEP-6 区别？**

NEP-5 是一种通证标准，是针对在 NEO 的智能合约中发布通证的规范。而 NEP-6 是一种钱包标准，包括钱包的格式，里面参数的定义，钱包地址的创建规则等。NEP-6 标准适用于现在的几个版本，包括 2.7.6。NEO 客户端支持两种格式的钱包，一种是 sqlite 钱包（格式为.db3），另一种是 NEP-6 钱包（格式为.json）。考虑到处理速度，强烈建议交易所使用 sqlite 钱包。

## 客户端

**为什么使用 NEO-GUI 转账后没有看到资产变化？**

在 NEO-GUI 种点击“交易记录”查看该笔交易是否已确认，如果已确认，查看你的客户端是否已同步到最高区块高度以及重建钱包索引。

**为什么下载了离线同步包后没有加速同步速度？**

请参考 http://docs.neo.org/zh-cn/network/syncblocks.html ，并确认：

- 您下载了正确的离线包
- 下载的压缩包文件（ chain.0.acc.zip 或 chain.xxx.acc.zip） 直接放置到了客户端 NEO-CLI 或 NEO-GUI 根目录下
- 您没有修改离线包文件名
- 您已安装了 [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ImportBlocks.zip) 插件

**如何确认客户端已经完全同步？**

使用区块链浏览器查看最近区块高度，然后查看您客户端中的钱包高度，如果高度一样，说明客户端已完全同步。

##### **如何做观察钱包（watch only）？**

可以在 NEO-GUI 中新建一个地址，然后右键导入监视地址，输入需要监视的地址，
然后就能在交易记录里面看到每一笔交易信息。导入后需要重建钱包索引。

##### **是否可以在一次交易中给多个地址进行转账？**

可以。请参考 [交易](http://docs.neo.org/zh-cn/node/gui/transc.html)。

**主网节点部署机器的配置要求是什么？**

运行节点客户端的机器需要配置双核 CPU，8G 内存，以及最低 100G 以上的固态硬盘，硬盘需根据实际需要扩容，防止 inode 溢出。

**NEO-CLI 是否有后台启动方式？**

可以制作一些脚本，比如在 Windows 上创建一个记事本文件，输入`dotnet neo-cli.dll /rpc` 然后保存为.cmd文件或者在 linux 上使用 screen 命令。

## 开发相关

**如何申请测试币？**

访问 https://neo.org/testcoin/apply 并填写申请表单。如果申请成功，你将在三到五个工作日内收到通知。

##### **有哪些方法可以搭建私链：**

要搭建私链，有以下方法可供选择：

- 在云服务器上使用虚拟机搭建私链，详情参见 [用虚拟机搭建私有链](network/private-chain/private-chain.md)。
- 在一台 windows服务器上快速搭建，详情参见 [快速搭建私有链](network/private-chain/private-chain2.md)。
- 使用 neo-local 快速搭建，详情参见 [快速搭建本地网络](network/neolocal.md)。

还可以参见 [社区文档](http://docs.neo.org/communitydoc_cn.html)，学习更多私链搭建方法。

##### **可以使用哪些语言开发智能合约？**

NEO 支持多种主流编程语言，可以使用 C#、Python、Go、JS 和 Jave 进行开发。目前在 NEO 生态中，C# 与 Python具有非常完善的基础设施，提供多种编译器可供开发者选择。

**如何获取 NEP-5 资产的 TXID?**

目前建议使用区块链浏览器 https://scan.nel.group 进行查看：

1. 进入浏览器后，点击页面上方导航栏中的 Assets。 
2. 在 Assets 列表中选择 NEP-5。
3. 在列表中点击要查看的资产，可进入详情页面查看到该资产的 TXID。

**搭建私链后，从多方签名合约中提取资产， 为什么签名时显示钱包中没有对象的私钥？**

搭建私链后，在 (n/2+1) 个共识节点的钱包中都需要进行相同的操作：添加多方签名地址和重建钱包索引。

## 智能合约

**为什么我发布 neon 时提示无法还原 NuGet 包？即使我尝试使用 Visual Studio 2017 进行还原，仍然会出现同样的错误。**

可根据以下步骤解决该问题：

1. 在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 neo-compiler 项目的根目录。
2. 打开 Power Shell 或命令提示符（CMD）。
3. 转到 neo-compiler 根目录，运行 `nuget restore` 。

**为什么我发布 neon 项目出现如下错误提示：无法复制文件”obj\Release\netcoreapp1.0\win10-x64\neon.dll“，原因是找不到该文件？**

这可能是 VS 2017 （如 15.4，15.5）的一个 Bug，此时需要手动将 `\obj\Release\netcoreapp1.0\neon.dll` 文件复制到 `\obj\Release\netcoreapp1.0\win10-x64\` 文件夹中，然后重新发布即可。

**为什么我创建 NeoContract 项目后, 代码中有很多画红线的地方，提示找不到 Neo 命名空间，而且在项目的引用中有感叹号？**

在 VS 中右击解决方案文件，点击 `还原 NuGet 程序 包` ，这时在 “输出” 面板会看到 “正在还原 NuGet 程序包...”。所有程序包已经还原成功后，如果代码仍然报错，并且右侧 “引用” 中仍有个感叹号，可以尝试双击感叹号。如果仍然无法解决问题，可以尝试下面的办法：

1. 在 [这里](https://www.nuget.org/downloads) 下载 nuget.exe，然后将其复制到 NeoContract 项目的根目录。
2. 打开 Power Shell 或命令提示符（CMD）。
3. 转到 NeoContract 项目的根目录，运行 `nuget restore` 即可。

**为什么当我在 Windows 7 中发布 neon 设置好环境变量后，运行 neon 时提示缺少  api-ms-win-core-console-l2-1-0.dll 文件？**

发布时的平台错了，neon 项目默认的发布平台为 win10-x64，所以发布到 Windows7 时才会提示缺少 dll 文件。这时，需要用文本编译器打开 neon.csproj 文件，将 `<RuntimeIdentifiers>win10-x64</RuntimeIdentifiers>` 更改为 `<RuntimeIdentifiers>win7-64</RuntimeIdentifiers>` 然后用 VS 重新发布该项目即可。或者可以直接用命令 `dotnet publish -r win7-x64 -c debug` 来发布。

详细 RID 可以参考 [.NET Core Runtime IDentifier (RID) catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) 。

**为什么我设置好环境变量后，在 CMD 中输入 neon 却提示找不到 neon？**

这是因为修改环境变量后没有重新启动 CMD，CMD 读取的环境变量还是之前没有修改过的。解决办法：重启 CMD。

**已经发布了 neon 并将 neon.exe 所在目录添加到了 path， 为什么编译 NeoContract 时卡在 Start NeoContract converter 这一步？**

这是因为修改环境变量后没有重新启动 Visual Studio，Visual Studio 读取的环境变量还是之前没有修改过的，所以找不到 neon。

解决办法：重启 Visual Studio。如果仍未解决就重启系统。

**我用旧版本的 neon 编译的智能合约，代码写的没有问题，为什么在测试网或主网上运行失败？**

NEO 智能合约需要的 开发框架、编译器、NeoVM 版本要求一致。否则用旧版本的开发框架和编译器编译的代码有可能在新版 NeoVM 中运行出错。已发布到区块链上的智能合约不受此影响。

当你准备开始智能合约时，确保你的开发框架（如NeoContractPlugin）和编译器（如 neon）是最新版本。

**为什么用 neoj 编译的时候出现错误提示：无法找到 org.neo.smartcontract.framework.jar?**

你需要将 neo-devpack-java-master 打包成 jar 包并放入 neoj 的 \neoj\bin\Release\netcoreapp1.1\win10-x64\publish\

本文部分内容摘自文章：[NEO Contract Development - Common Pitfalls using Windows 7](https://steemit.com/neo/@cybourgeoisie/neo-contract-development-common-pitfalls-using-windows-7) 感谢 **cybourgeoisie** 的贡献。
