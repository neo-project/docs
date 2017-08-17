# 在 Azure（中国）一键部署 NEO 节点

NEO 从主网上线以来就在 Azure（中国）的镜像市场部署了镜像，该镜像为 **开源**、**免费**，用户只需支付基础服务器的费用即可运行 NEO 节点，该镜像由 NEO 团队开发维护。

## 准备工作

创建 Azure （中国）的账号：

登录 Azure （中国）网站：[www.azure.cn](https://www.azure.cn/)  创建一个 Azure 账号。

* 注：该账号为世纪互联运营的 Azure（中国）账号，与 Azure（全球）账号及微软账号不通用。

新用户在 Azure（中国）中可以申请 1 元试用活动，您只需要缴纳 1 元人民币，就可以获得 1,500 元 Azure 服务使用额度，有效期一个月。详情请点击 [1 元试用订阅详情](https://www.azure.cn/offers/ms-mc-azr-44p/)。

![](~/images/2017-08-17_11-02-21.png)

## 一键部署

创建好账户后，打开 [Azure 镜像市场](https://market.azure.cn/) 在搜索中搜索 **NEO** 即可找到 NEO 的 Azure 镜像。

![](~/images/2017-08-17_11-08-03.png)

点击进去可以查看使用详情。点击 **立即部署** 会跳转到 **创建 Azure 虚拟机** 界面，在该页面中设置好虚拟机的基础设置后，点击页面最下方的 **立即部署** 即开始部署镜像。 

![](~/images/2017-08-17_11-18-37.png)

本镜像中包含： .NET Core 1.0.4 runtime (LTS)，Neo CLI v2.0.1，Neo GUI v2.0.1 

![](~/images/azure.png)