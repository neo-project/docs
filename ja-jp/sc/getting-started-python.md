# neo-pythonで始めるNEOスマートコントラクト

主な著者: [@localhuman](https://github.com/localhuman)

neo-pythonはNEOブロックチェーンのためのPythonノードとSDKです。neo-pythonを用い、NEOブロックチェーン上でスマートコントラクトを構築、テスト、実行することができます。neo-pythonが提供する主な機能は、以下の通りです。

- PythonベースP2Pノードの実行
- インタラクティブCLIを使用したノードの環境設定およびブロックチェーンの検査
- Pythonで書かれたスマートコントラクトあるいは .avm 形式のスマートコントラクトのコンパイル、テスト、デプロイ、そして実行。
- [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki)および[NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki)に対応したウォレット機能
- RPCクライアント
- `Runtime.Log`と`Runtime.Notify`のイベントモニタリング

## Pythonライブラリのインストール

まず、libleveldbライブラリをインストールする必要があります。[Python 3.5](https://www.python.org/downloads/release/python-354/)をインストールし、ご自身のPythonと現在のバージョンの違いによる問題が起こらないかを確認してください。bitplayモジュールとの不適合性により、Python 3.6は現在サポートされていないことに注意してください。

**OSXの場合**は、次を入力してください。

```python
brew install leveldb
```

もし以下と類似の表示が出た場合は、

```python
    from ._plyvel import (  # noqa
    ImportError: dlopen(neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
    ERKSsPPS0_
    Referenced from: neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
    Expected in: flat namespace
```

plyvel（python libleveldbライブラリ）をアンインストールし、次のcflagsを追加して再インストールします。

```python
pip uninstall plyvel
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel plyvel --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/leveldb/1.20_2/include/" --global-option="-L/usr/local/lib"
```

また、OSXにpycryptoモジュールをインストールした時に、次のような問題に出くわすかもしれません。

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

この場合、homebrewを使ってgmpライブラリをインストールし、次のコマンドラインとともにpipインストールを実行することで、直せる可能性があります。

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

**Ubuntu/Debian**の場合、次を入力します。

```python
apt-get install libleveldb-dev python3.5-dev python3-pip libssl-dev
```

**Centos/Redhat/Fedora**の場合、次を入力します。

```python
yum -y install development tools python35 python35-devel python35-pip readline-devel leveldb-devel libffi-devel
```

もしかしたら、leveldb-develパッケージ用のepel repoを有効にする必要があるかもしれません。これは、`/etc/yum.repos.d/epel.repo`を編集することで実行できます。

> [!注意]
> 
> これらすべての場合において、プロジェクトのChainsディレクトリが適切な書き込み権限を有していることを確認してください。

**Windows**の場合:

まだテストが行われていません。Pythonパッケージplyvelのインストールには、Visual Studioとライブラリに紐付いたC++コンパイラサポートが必要と思われます。

## 仮想環境のセットアップ

1. まず、<https://github.com/CityOfZion/neo-python/>にあるレポジトリのクローンを作り、プロジェクトディレクトリに通します。

2. 以下により、Python 3の仮想環境を作りアクティベートします。

   ```python
   python3 m venv venv
   source venv/bin/activate
   ```
　
   または、Python 3.5を確実にインストールします。
   
   ```python
   virtualenv -p /usr/local/bin/python3.5 venv
   source venv/bin/activate
   ```
   
3. インストール要件:

   ```python
   pip install -r requirements.txt
   ```
   
4. リファレンスを`neo`ワーキングディレクトリにインストールします。これは、プロジェクト内のどこからでも`import neo`でインポートすることを許可します（例：examples）:

   ```python
   pip install -e
   ```

> [!注意]
> 
> - `git pull`を使用してneo-pythonをアップデートする場合、`pip install -r requirements.txt`を実行して依存パッケージもアップデートしていることを確かめてください。
> 
> 
> 初めてneo-pythonを使用する場合、ブロックチェーンを同期する必要があります（時間がかかります）。このプロジェクトには、自動的にchainディレクトリをダウンロードするため、`bootstrap.py`が含まれます。テストネットのためにブートストラップを行うには、`python bootstrap.py`を実行します。メインネットのためにブートストラップを行うには、`python bootstrap.py -m`を実行します。

## Pythonベースノードの実行

要件をインストールし環境をアクティベートしたら、`prompt.py`ファイルを使ってノードを起動し、基本的な対話を行いましょう。

以下の例は、テストネット上で`prompt.py`を開始させます。

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> state
Progress: 1054913 / 1237188

neo>
```

すべての利用可能な実引数を表示し、確認することができます。

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

ハッシュあるいはブロックインデックスにより、現在のサーバー上で、ブロックを参照することができます。

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

## 参考文献

- [プロンプトの使用](python\prompt.md)
- [設定とロギング](python\logging.md)
- [スマートコントラクトとの相互作用](python\smartcont.md)
- [テスト](python\tests.md)
- [NEO仮想マシンのためのPythonコンパイラ](python\compiler.md)

