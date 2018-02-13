# Getting Started with neo-python

*Main author: [@localhuman](https://github.com/localhuman)*

neo-python, the python node and SDK for the NEO blockchain, enables you to build, test, and run smart contracts on the Neo blockchain. It provides the following main functionalities:

- Running a Python based P2P node
- Interactive CLI for configuring node and inspecting blockchain
- Compiling, testing, deploying and running Smart Contracts written in python or any Smart Contract in the `.avm format`
- [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) and [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) compliant wallet functionality
- RPC Client
- `Runtime.Log` and `Runtime.Notify` event monitoring

## Installing the Python library

You need to install the libleveldb library. Install [Python 3.5](https://www.python.org/downloads/release/python-354/) to make sure you don't run into any issues with your version of Python being different than the current maintainer's version. Note that Python 3.6 is not currently supported due to incompatibilities with the byteplay module.

**For OSX**, enter the following:

```python
brew install leveldb
```

If you're having an issue similar to this:

```python
    from ._plyvel import (  # noqa
    ImportError: dlopen(neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
    ERKSsPPS0_
    Referenced from: neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
    Expected in: flat namespace
```

You may need to uninstall plyvel (python libleveldb library), and reinstall with the following cflags:

```python
pip uninstall plyvel
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel plyvel --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/leveldb/1.20_2/include/" --global-option="-L/usr/local/lib"
```

You may also encounter issues when installing the pycrypto module on OSX:

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

This may be fixed by installing the gmp library using homebrew and running pip install with the following command line:

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

**For Ubuntu/Debian**, enter the following:

```python
apt-get install libleveldb-dev python3.5-dev python3-pip libssl-dev
```

**For Centos/Redhat/Fedora**, enter the following:

```python
yum -y install development tools python35 python35-devel python35-pip readline-devel leveldb-devel libffi-devel
```

You may need to enable the epel repo for the leveldb-devel package, which you can do by editing `/etc/yum.repos.d/epel.repo`.

> [!Note]
>
> For all of these, make sure that the `Chains` directory in your project has the proper write permissions.

**For Windows:**

This has not been tested at this time. Installing the Python package plyvel seems to require C++ compiler support tied to Visual Studio and libraries.

## Setting up the virtual environment

1. Clone the repository at <https://github.com/CityOfZion/neo-python/> and navigate into the project directory. 

2. Make a Python 3 virtual environment and activate it via:

   ```python
   python3.5 -m venv venv
   source venv/bin/activate
   ```

3. Install requirements:

   ```python
   pip install -r requirements.txt
   ```

4. Install a reference to the `neo` working directory, which allows to `import neo` from anywhere in the project (eg. examples):

   ```python
   pip install -e
   ```

> [!Note]
>
> - If you are updating neo-python with `git pull`, make sure you also update the dependencies with `pip install -r requirements.txt`.
>
>
> - If you use neo-python for the first time, you need to synchronize the blockchain, which may take a long time. Included in this project is `bootstrap.py` to automatically download a chain directory for you. To bootstrap for testnet, run `python bootstrap.py`; To bootstrap for mainnet, use `python bootstrap.py -m`.

## Running the python-based node

After installing requirements and activating your environment, use the `prompt.py` file to run the node as well as some basic interactivity.

The following example starts `prompt.py` on TestNet:

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> state
Progress: 1054913 / 1237188

neo>
```

You can show help to see all available arguments:

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

You can query for a block in the current server by hash or by block index:

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

## Further Reading

- [Interacting with the NEO blockchain using Prompt](python\prompt.md)
- [Settings and Loggings](python\logging.md)
- [Interacting with Smart Contracts](python\smartcont.md)
- [Tests](python\tests.md)
- [Python Compiler for the NEO Virtual Machine](python\compiler.md)

