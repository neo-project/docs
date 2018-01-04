# 如何开始（neo-python）

*作者：[@localhuman](https://github.com/localhuman)*

neo-python，NEO区块链的python节点和SDK，能帮助您在NEO区块链上构建、测试和运行智能合约。其主要功能如下：

- 运行一个基于Python的P2P节点
- 提供用于配置节点和检查区块链的交互式CLI
- 编译、测试、部署和运行python编写的智能合约以及任何.avm格式的智能合约
- 符合[NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) 和 [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 标准的钱包功能
- RPC 客户端
- `Runtime.Log` 和 `Runtime.Notify` 事件监视

## 安装 Python 库

您需要安装 libleveldb 库。建议安装 [Python 3.5](https://www.python.org/downloads/release/python-354/) 以免遇到因为与当前维护者版本不同而出现的问题。由于不兼容字节播放模块，当前不支持Python 3.6。

**对于 OSX**，输入以下命令：

```python
brew install leveldb
```

如果遇到以下类似问题：

```python
    from ._plyvel import (  # noqa
    ImportError: dlopen(neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
    ERKSsPPS0_
    Referenced from: neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
    Expected in: flat namespace
```

可以卸载 plyvel（python libleveldb 库）然后使用以下 cflags 重新安装：

```python
pip uninstall plyvel
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel plyvel --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/leveldb/1.20_2/include/" --global-option="-L/usr/local/lib"
```

如果在OSX上安装 pycrypto 时遇到以下问题：

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

可以使用 homebrew 安装 gmp库，并使用以下命令运行pip install：

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

**对于 Ubuntu/Debian**，输入以下命令：

```python
apt-get install libleveldb-dev python3.5-dev python3-pip libssl-dev
```

**对于 Centos/Redhat/Fedora**，输入以下命令：

```python
yum -y install development tools python35 python35-devel python35-pip readline-devel leveldb-devel libffi-devel
```

您可能需要为 leveldb-devel 包启用epel存储库，可以编辑`/etc/yum.repos.d/epel.repo `来启用。

> [!Note]
>
> 对于以上系统，请确保项目中的Chains目录具有正确的写入权限。

**对于 Windows:**

尚未测试。安装 Python 包 plyvel 可能需要 C ++ 编译器支持绑定到Visual Studio和库。

## 建立虚拟环境

1. 克隆 <https://github.com/CityOfZion/neo-python/> 上的存储库并导航到项目目录。

2. 创建一个 Python 3 虚拟环境并使用以下命令激活：

   ```python
   python3 m venv venv
   source venv/bin/activate
   ```

   或显示安装 Python 3.5:

   ```python
   virtualenv -p /usr/local/bin/python3.5 venv
   source venv/bin/activate
   ```

3. 安装需求文件

   ```python
   pip install -r requirements.txt
   ```

4. 安装一个对neo工作目录的引用，以允许从项目的任何地方导入neo，例如

   ```python
   pip install -e
   ```

> [!Note]
>
> - 如果使用`git pull`更新 neo-python，请同样使用 `pip install -r requirements.txt`更新依赖关系。
>
>
> - 如果是第一次使用 neo-python，则需要同步区块链，这可能需要很长时间。 包含在这个项目中的bootstrap.py将自动下载一个链式目录。要在测试网引导程序，运行 `python bootstrap.py`；要在主网引导程序，使用 `python bootstrap.py -m`.

## 运行基于 python 的节点

在安装需求并激活环境之后，使用`prompt.py`文件来运行节点和基本的交互功能。

以下示例在测试网启动`prompt.py`：

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> state
Progress: 1054913 / 1237188

neo>
```

您可以使用`help`命令查看所有可用参数：

```python
python prompt.py -h
usage: prompt.py [-h] [-m] [-p] [-c CONFIG] [-t {dark,light}] [--version]

optional arguments:
-h, --help            show this help message and exit
-m, --mainnet         Use MainNet instead of the default TestNet
-p, --privnet         Use PrivNet instead of the default TestNet
-c CONFIG, --config CONFIG
                        Use a specific config file
-t {dark,light}, --set-default-theme {dark,light}
                        Set the default theme to be loaded from the config
                        file. Default: 'dark'
--version             show program's version number and exit
```

您可以通过散列或区块索引查询当前服务器中的区块：

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> block 122235
{
    "index": 122235,
    "script": "",
    "merkleroot": "1d5a895ea34509a83becb5d2f9391018a3f59d670d94a2c3f8deb509a07464bd",
    "previousblockhash": "98ae05cb68ab857659cc6c8379eb7ba68b57ef1f5317904c295341d82d0a1713",
    "tx": [
        "1d5a895ea34509a83becb5d2f9391018a3f59d670d94a2c3f8deb509a07464bd"
    ],
    "version": 0,
    "time": 1479110368,
    "hash": "74671375033f506325ef08d35632f74083cca564dc7ea6444c94d3b9dec3f61b",
    "consensus data": 16070047272025254767,
    "next_consensus": "59e75d652b5d3827bf04c165bbe9ef95cca4bf55"
}
neo>
```

## 扩展阅读

- [使用命令行与NEO区块链交互](python\prompt.md)
- [设置和日志](python\logging.md)
- [与智能合约交互](python\smartcont.md)
- [测试](python\tests.md)
- [python编译器](python\compiler.md)

