# 安装

需要安装 libleveldb 库。安装 [Python 3.6](https://www.python.org/downloads/release/python-364/) 或 [Python 3.7](https://www.python.org/downloads/release/python-370/) 以免因为与当前维护者版本不同遇到问题。注意不支持 Python 3.5 及更低版本。

安装 `neo-python` 前需要安装平台相关项目。

## 平台相关操作

### Ubuntu/Debian 16.10+

Ubuntu 从16.10 开始在官方存储库中支持 Python 3.6 。

首先，请使用以下命令确保 Ubuntu 是最新的：

```
sudo apt-get update && sudo apt-get upgrade
```

你可以使用以下命令安装 Python 3.7 和所有系统依赖：

```
sudo apt-get install python3.7 python3.7-dev python3.7-venv python3-pip libleveldb-dev libssl-dev g++
```

你也可以使用以下命令直接安装 Python 3.6 和所有系统依赖：

```python
sudo apt-get install python3.6 python3.6-dev python3.6-venv python3-pip libleveldb-dev libssl-dev g++
```

### 旧版 Ubuntu（如16.04）

对于较旧的 Ubuntu 版本，你需要使用一个像 Felix Krull 的 [deadsnakes PPA](https://launchpad.net/~deadsnakes/+archive/ubuntu/ppa) 这样的外部存储库 (更多内容，阅读 [here](https://askubuntu.com/questions/865554/how-do-i-install-python-3-6-using-apt-get)):

(本文档中第三方软件链接的使用由您自行决定并承担风险，且您同意对计算机系统的任何损坏或此类活动导致的数据丢失承担全部责任。)

```python
apt-get install software-properties-common python-software-properties
add-apt-repository ppa:deadsnakes/ppa
apt-get update
apt-get install python3.6 python3.6-dev python3.6-venv python3-pip libleveldb-dev libssl-dev g++
```

### Centos/Redhat/Fedora

```python
# Install Python 3.6:
yum install -y centos-release-scl
yum install -y rh-python36
scl enable rh-python36 bash

# Install dependencies:
yum install -y epel-release
yum install -y readline-devel leveldb-devel libffi-devel gcc-c++ redhat-rpm-config gcc python-devel openssl-devel
```

### Windows

在 Windows 操作系统上安装 `neo-python` 需要进行特别的操作，还可能遇到一些常见问题需要解决，相关内容请查看 [Installation (Windows)](installwin.md)

### OSX

```
brew install leveldb
```

#### 关于 OSX 的常见问题

如果您遇到与此类似的问题： 

```python
from ._plyvel import (  # noqa
ImportError: dlopen(neo-python/venv/lib/python3.6/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
ERKSsPPS0_
Referenced from: neo-python/venv/lib/python3.6/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
Expected in: flat namespace
```

**解决方案**：更新到  plyvel 1.0.4: pip install -r requirements.txt

------

在 OSX 上安装 pycrypto 模块时可能会遇到问题： 

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

要解决此问题，可以使用 homebrew 安装 gmp 库，并使用以下命令行运行pip install： 

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

------

`import scrypt` / `Reason: image not found`

如果遇到如下错误： 

```python
import scrypt
File "/project_dir/venv/lib/python3.6/site-packages/scrypt.py", line 11, in
_scrypt = cdll.LoadLibrary(imp.find_module('_scrypt')[1])
File "/project_dir/venv/lib/python3.6/ctypes/init.py", line 429, in LoadLibrary
return self._dlltype(name)
File "/project_dir/venv/lib/python3.6/ctypes/init.py", line 351, in init
self._handle = _dlopen(self._name, mode)
OSError: dlopen(/project_dir/venv/lib/python3.6/site-packages/_scrypt.cpython-36m-darwin.so, 6): Library not loaded: /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib
Referenced from: /project_dir/venv/lib/python3.6/site-packages/_scrypt.cpython-36m-darwin.so
Reason: image not found
```

可以尝试以下命令：

```
brew reinstall openssl
```

## 从 PyPi 安装

在计算机上安装  `neo-python` 的最简单方法下载后使用 `pip ` 从 PyPi 安装。建议您先创建一个虚拟环境，将此安装与系统目录隔离，然后像往常一样安装：

```python
# create project dir
mkdir myproject
cd myproject

# create virtual environment and activate

python3.6 -m venv venv # this can also be python3 -m venv venv depending on your environment
source venv/bin/activate

(venv) pip install neo-python
```

## 从 Git 安装

从 <https://github.com/CityOfZion/neo-python/> clone 存储库并导航到项目目录。创建一个 Python 3 虚拟环境并激活：

```python
git clone https://github.com/CityOfZion/neo-python.git
cd neo-python

# if you want to use the development branch, switch now
git checkout development

# create virtual environment using Python 3.7 and activate or skip to the next step for Python 3.6
python3.7 -m venv venv
source venv/bin/activate

# create virtual environment using Python 3.6 and activate
python3.6 -m venv venv
source venv/bin/activate

# install the package in an editable form
(venv) pip install -e .
```

### 从 Git 更新 neo-python

如果要使用 `git pull` 更新 neo-python ，还需要使用 `pip install -r requirements.txt` 更新依赖。

## 同步区块链

第一次使用 neo-python 时需要同步区块链。这将花费较长时间。此项目包含的 `bootstrap.py`  可以自动下载一个链目录。

要同步测试网，运行 `np-bootstrap`。

要同步主网，运行 `np-bootstrap -m` 并等待同步完成 (3.3 GB 文件)。