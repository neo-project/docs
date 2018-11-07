# 在 Windows 系统中安装

以下安装说明针对带有 MSYS2 环境和 Visual Studio 2017 的 Windows 7 x64 系统，也适用于大多数 Windows 发行版。你也可以选择使用 Ubuntu 安装一个 Linux 子系统（ 更多信息参见 [这里](https://medium.com/@gubanotorious/installing-and-running-neo-python-on-windows-10-284fb518b213)）。

> [!Note]
>
> 从 Microsoft Store 安装的 Ubuntu 是 Ubuntu 16.04。你需要从这里下载 Ubuntu 18.04：<https://www.microsoft.com/en-us/p/ubuntu-1804/9n9tngvndl3q?activetab=pivot%3aoverviewtab>

## 构建 LevelDB

在 Windows 系统中安装 leveldb 最简单的办法是使用 VC++ 打包工具。如果你使用的是 windows x64 系统，还需要先设置环境变量：`set VCPKG_DEFAULT_TRIPLET=x64-windows`。

```
git clone https://github.com/Microsoft/vcpkg
cd vcpkg
.\bootstrap-vcpkg.bat
.\vcpkg integrate install
.\vcpkg install leveldb
```

## 安装 python 依赖项

安装 [Anaconda package manager](https://www.anaconda.com/download/)，并激活 python 虚拟环境。

```
conda create -n neo python=3.6.4
activate neo
```

（可选）激活 Visual Studio 构建环境，如下所示：

```
"e:\Program Files\Microsoft Visual Studio\2017\Community\VC\Auxiliary\Build\vcvars64.bat"
```

### 构建 plyvel (1.0.4)

确认编译器可以访问 .lib 和 leveldb 头文件，然后将它们复制到 MSVC 构建工具目录下：

从 `vcpkg\installed\x64-windows\include\` 复制到 `e:\Program Files\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.12.25827\include` 

从 `vcpkg\installed\x64-windows\lib\libleveldb.lib` 复制到 `e:\Program Files\Microsoft Visual Studio\2017\Community\VC\Tools\MSVC\14.12.25827\lib\x64\leveldb.lib`

然后克隆存储库并进入所需版本，安装 cython，从 C++ 文件构建 python 扩展，最后安装 plyvel，如下所示：

```python
git clone https://github.com/wbolster/plyvel
cd plyvel
git checkout e3887a5fae5d7b8414eac4c185c1e3b0cebbdba8
pip install cython
cython --cplus --fast-fail --annotate plyvel/_plyvel.pyx
python setup.py build_ext --inplace --force
python setup.py install
```

### 构建 peewee (2.10.2)

```
git clone https://github.com/coleifer/peewee
cd peewee
git checkout 761f9144a0e17381147a81658019cffe14c118ca
python setup.py install
```

### 构建 mmh3 (2.5.1)

```
git clone https://github.com/hajimes/mmh3
cd mmh3
git checkout a73b373858dedfdb6d362f5ca985ae1bb6bc2161
python setup.py install
```

### 从 Anaconda 安装依赖项

某些依赖项无法正确地从 pip 安装，但可以从 Anaconda 安装。

```
conda install twisted==17.9.0
conda install pycrypto==2.6.1
```

## 安装 neo-python

导航到 neo-python 目录并安装其它依赖项，使用以下命令：

```
pip install -r requirements.txt
```

检查安装： `python prompt.py`

## 故障排除

以下列出了在安装过程中可能遇到的问题和解决方案。

### LINK : fatal error LNK1181: cannot open input file ‘leveldb.lib’

确保编译器可以访问 .lib 与 leveldb 头文件。

### error LNK2001: unresolved external symbol __imp_PathFileExistsW

找到库 shlwapi.lib，它可能在你的文件系统中。 将其合并到 leveldb.lib：`lib.exe /OUT:newleveldb.lib leveldb.lib ShLwApi.Lib` 并替换原始文件。

### ImportError: No module named ‘winrandom’

导航到你的 python 发行版包目录，例如： `e:\Programs\Anaconda3\envs\neo\Lib\site-packages`。

在 Crypto\Random\OSRNG\nt.py 中将 `import winrandom` 修改为 `from . import winrandom` 。

### ImportError: No module named ‘win32api’

安装模块： `pip install pypiwin32`