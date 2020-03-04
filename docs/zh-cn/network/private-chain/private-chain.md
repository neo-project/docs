# 用虚拟机搭建私有链

本文将介绍如何使用四台虚拟机来搭建私有链，以及如何从自己的私有链中提取 NEO 和 GAS。                        

## 配置虚拟机

Neo 私有链的部署至少需要 4 台服务器才能取得共识，每台服务器对应一个共识节点。为了演示，我们在 Azure 上创建了 4 台 Windows 虚拟机，大小为 Standard DS1 v2 (1 核心，3.5 GB 内存)，你也可以在局域网中或虚拟机中部署私有链。

![](../assets/privatechain_1.jpg)

创建好后，要开通 10331-10334 端口，具体方法为在系统的 `防火墙`-> `高级设置`-> `入站规则` 中新建规则，然后添加端口 10331-10334。

> [!Note]
>
> 如果你在云服务器上创建的虚拟机，还要登录虚拟机的管理后台，设置网络安全组
>
> Azure 上的设置方法为：`网络`-> `入站端口规则` -> 添加端口 10331-10334。

创建好虚拟机后，将四台虚拟机的 IP 地址保存下来以备后用。

## 安装 Neo-CLI

分别在四台虚拟机上进行如下操作：

1. 参考 [安装 Neo-CLI](../../node/cli/setup.md) ，安装 Neo 客户端。
2. 下载 [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/SimplePolicy.zip) 插件并将解压后的 Plugins 文件夹拷贝到 neo-cli 目录下。

## 创建钱包

1. 在任意一台虚拟机上使用 Neo-CLI 或 Neo-GUI 创建四个钱包文件，下图以在 Neo-CLI 上创建为例。

   ![](../assets/privatechain_3.jpg)

2. 将四个钱包的公钥保存下来以备后用。可以直接复制上面的公钥或者用 [CLI 命令](../../node/cli/cli.md) 中的 `                                                                           list key` 命令查看公钥再复制。

3. 将四个钱包文件分别复制到四个虚拟机的 neo-cli 节点目录下。

## 修改节点配置文件

1. 配置每个节点的 `protocol.json `文件 ，修改以下参数：

   - `Magic` ：Magic 用于识别消息的来源网络，指定不同的 Magic 确保 Neo 区块链中的不同网络信息在传输过程中不会发送到其它网络。Magic 的类型为 uint，注意填写的数值要在 [0 - 4294967295] 区间内。
   - `StandbyValidators`：将创建好的四个钱包的公钥填写在这里。
   - `SeedList`：将四台虚拟机的 IP 地址填写在这里，端口号保持不变。

   ```json
   {
     "ProtocolConfiguration": {
       "Magic": 123456,
       "AddressVersion": 23,
       "SecondsPerBlock": 15,
       "LowPriorityThreshold": 0.001,     
       "StandbyValidators": [      "03072384ece95c4febe7211ee4833cd36cdf0f255ec5263b28a4be1f2af7a3d7f3",      "0208da33cee651a4dc119654b5b8067ade533e39e63a8b4fdbd160d97f80c4cfb4",      "026f0af815d5c3895205e9f54b9402329f3ecc4d249fc0c8500e9b3ea8a3ec9d5b",
    "03b4e070988627e2a5710b2c8c79f0f0be18821e1af5875b7beeb3fa8a921cde3f"
       ],
       "SeedList": [
         "13.75.112.62:10333",
         "137.116.173.200:10333",
         "168.63.206.73:10333",
         "137.116.171.134:10333"
       ],
       "SystemFee": {
         "EnrollmentTransaction": 10,
         "IssueTransaction": 5,
         "PublishTransaction": 5,
         "RegisterTransaction": 100
       }
     }
   }
   ```

2. 配置每个节点的 config.json 文件，以便打开钱包，开启共识：

   - `Path`：设置对应的钱包名称。
   - `Password`：钱包密码。
   - `StartConsensus`：设置为 true 开启共识。

   ```
   "UnlockWallet": {
     "Path": "1.json",
     "Password": "11111111",
     "StartConsensus": true,
     "IsActive": true
   }
   ```

## 启动私有链

在四台虚拟机上依次运行命令行，进入 neo-cli 目录并输入命令 `dotnet neo-cli.dll /rpc` 启动节点，这时程序会自动打开钱包并开启共识。

如果上述操作成功，可以运行 `show state` 来查看节点状态。若高度发生变化，则说明共识过程正常。4个节点的共识过程如图所示：

![](../../assets/privatechain_8.png)

4 个节点即使关掉一台依然可以达成共识，如图所示

![](../../assets/privatechain_9.png)

## 提取 NEO 和 GAS

在 Neo 网络的创世块中存放着 1 亿份 NEO，当私链搭建起来后，GAS 也将伴着新区块的生成而生成。你可以使用 Neo-CLI 或 Neo-GUI 从多方签名合约中提取出这部分 NEO 和 GAS 以便内部开发测试使用。

关于提取操作，请参考 [提取 NEO 和 GAS](private-chain2.md#提取-neo-和-gas)
