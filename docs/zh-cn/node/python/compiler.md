# Python 编译器

neo-boa 编译器可以将 Python 文件编译为.avm格式，在Neo虚拟机中运行，执行 NEO 区块链上的智能合约。

编译器支持Python语言的一个子集，目前适用于Python 3.4和3.5。

## 安装 neo-boa 编译器

运行以下命令安装 neo-boa 编译器：

```
pip install neo-boa

```

#### Docker

该项目包含一个 Dockerfile 来批量编译 Python 智能合约。 克隆存储库并导航到项目的 docker 子目录。 运行以下命令来构建容器：

```
docker build -t neo-boa .

```

neo-boa Docker 容器将包含 python 智能合约的主机上的目录作为输入，并将目录编译为 .avm 文件以作为输出。它可以这样执行：

```
docker run -it -v /absolute/path/input_dir:/python-contracts -v /absolute/path/output_dir:/compiled-contracts neo-boa

```

-v (volume) 命令将主机上的目录映射到容器内的目录。

## 基本用法

您可以参照如下示例 使用编译器：

```
from boa.compiler import Compiler

Compiler.load_and_save('path/to/your/file.py')

```

更多高级用法，参见 [boa.compiler.Compiler](http://neo-boa.readthedocs.io/en/latest/boa/compiler.html) 以及其它模块。