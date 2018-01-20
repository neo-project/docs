# NEO仮想マシンのためのPythonコンパイラ

`neo-boa`コンパイラは、Neo仮想マシン上で利用するためにPythonファイルを`.avm`フォーマットにコンパイルするツールです。[Neo仮想マシン](https://github.com/neo-project/neo-vm/)を用いることにより、[Neoブロックチェーン]((https://github.com/neo-project/neo/))上でコントラクトを実行することができます。

本コンパイラはPython言語のサブセットをサポートし、現在、Python 3.4と3.5で動作します。

## neo-boaコンパイラのインストール

neo-boaコンパイラをインストールするために次のコマンドを実行します。

```
pip install neo-boa

```

#### Docker

このプロジェクトは、Pythonスマートコントラクトを一括コンパイルするDockerfileを含みます。レポジトリのクローンを作り、プロジェクトのdockerのサブディレクトリに移動してください。コンテナを作るために次のコマンドを実行します。

```
docker build -t neo-boa .

```

neo-boa Dockerコンテナは、インプットとして、Pythonスマートコントラクトを含むホスト上のディレクトリをとり、アウトプットとして、.avmファイルをコンパイルするためのディレクトリをとります。これは、次のように実行されます。

```
docker run -it -v /absolute/path/input_dir:/python-contracts -v /absolute/path/output_dir:/compiled-contracts neo-boa

```

-v (volume) コマンドは、ホスト上のディレクトリを、コンテナ内のディレクトリにマップします。

## 基本的な利用方法

次の例のようにコンパイラを使用することが出来ます。

```
from boa.compiler import Compiler

Compiler.load_and_save('path/to/your/file.py')

```

さらに発展的な利用法と他のモジュールは[boa.compiler.Compiler](http://neo-boa.readthedocs.io/en/latest/boa/compiler.html)を参照してください。
