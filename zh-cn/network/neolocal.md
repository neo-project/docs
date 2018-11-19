# 快速搭建本地网络

你可以在本地搭建个人的区块链网络用于协助开发。使用 [NEO-Local](https://github.com/CityOfZion/neo-local) 项目可以帮助你快速完成搭建，你可以使用它运行测试、执行命令和检查状态，同时控制链的操作。

> [!Note]
>
> 该项目仅用于开发目的，其 docker 镜像中使用的 NEO 组件可能不是最新的。所以请始终使用测试网测试你所编写的智能合约。

**使用 Docker** 
该项目使用 Docker 和 Docker-compose，可运行在 MacOS、Linux 和 Windows 系统上。关于 Docker 的更多信息，请参见其 [官网](https://www.docker.com/)。

[![img](https://github.com/neo-project/docs/raw/df3f3750862af288a789f05df456d2ce77175d04/assets/neolocal.png)](https://github.com/neo-project/docs/blob/df3f3750862af288a789f05df456d2ce77175d04/assets/neolocal.png)

## Neo-local 组件

 NEO-local 将启动以下容器： 

- 4 个共识节点 -  一个完整的工作网络
- 区块浏览器 - Neoscan
- 通知服务器（Neo-python）
- 开发工具（Neo-python）
- 包含 GAS 的钱包
- 开发者 faucet（用于获取额外的 GAS）

### 简单配置 

安装完 docker 和 docker-compose 后，进行如下配置： 

1. 克隆项目仓库：<https://github.com/CityOfZion/neo-local>
2. 打开命令行或 powershell，进入项目目录：`cd ./neo-local `.
3. 运行 `docker-compose up `.
4. 完成设置后，使用浏览器访问`http://localhost:4000` 查看是否一切正常运行。

详细信息，参见 [Neo-local wiki](https://github.com/CityOfZion/neo-local/wiki) 。