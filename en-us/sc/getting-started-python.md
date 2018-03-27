# Getting Started with neo-python

*Main author: [@localhuman](https://github.com/localhuman)*

neo-python, the python node and SDK for the NEO blockchain, enables you to build, test, and run smart contracts on the Neo blockchain. It provides the following main functionalities:

- This project aims to be a full port of the original C# [Neo Project](https://github.com/neo-project)
- Running a Python based P2P node
- Interactive CLI for configuring node and inspecting blockchain
- Compiling, testing, deploying and running Smart Contracts written in python or any Smart Contract in the `.avm format`
- [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) and [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) compliant wallet functionality
- RPC Client
- RPC server
- `Runtime.Log` and `Runtime.Notify` event monitoring

## What will it do
- Consensus nodes
- Full smart contract debugging and inspection

## Installing the Python library

You will need to install the libleveldb library. Install [Python 3.6](https://www.python.org/downloads/release/python-364/) to make sure you don’t run into any issues with your version of Python being different than the current maintainer’s version. Note that Python 3.5 and below are not supported.

Installation via `pip` is not currently available at this time

You should install platform specific items before installing from git.

## Install from Git
Clone the repository at https://github.com/CityOfZion/neo-python/ and navigate into the project directory. Make a Python 3 virtual environment and activate it via
```
python3.6 -m venv venv
source venv/bin/activate
```
## Updating neo-python from Git
If you are updating neo-python with `git pull`, make sure you also update the dependencies with `pip install -r requirements.txt`.

## Bootstrapping the Blockchain
If you use neo-python for the first time, you need to synchronize the blockchain, which may take a long time. Included in this project is `bootstrap.py` to automatically download a chain directory for you. To bootstrap for testnet, run `python bootstrap.py`, get a cup of coffee and wait. To bootstrap for mainnet, use `python bootstrap.py -m` and get 8 cups of coffee (3.3 GB file).

## Platform Specific Instructions

### OSX, 
enter the following:

```python
brew install leveldb
```
### Ubuntu/Debian 16.10+, 
Ubuntu starting at 16.10 supports Python 3.6 in the official repositories, and you can just install Python 3.6 and all the system dependencies like this:

```
apt-get install python3.6 python3.6-dev python3-pip python3-venv libleveldb-dev libssl-dev g++
```
### Older Ubuntu versions (eg. 16.04)
For older Ubuntu versions you’ll need to use an external repository like Felix Krull’s deadsnakes PPA at https://launchpad.net/~deadsnakes/+archive/ubuntu/ppa (read more [here](https://askubuntu.com/questions/865554/how-do-i-install-python-3-6-using-apt-get)):

(The use of the third-party software links in this documentation is done at your own discretion and risk and with agreement that you will be solely responsible for any damage to your computer system or loss of data that results from such activities.)
```
apt-get install software-properties-common python-software-properties
add-apt-repository ppa:deadsnakes/ppa
apt-get update
apt-get install python3.6 python3.6-dev python3.6-venv python3-pip libleveldb-dev libssl-dev g++
```

### Centos/Redhat/Fedora, enter the following:

```
# Install Python 3.6:
yum install -y centos-release-scl
yum install -y rh-python36
scl enable rh-python36 bash

# Install dependencies:
yum install -y epel-release
yum install -y readline-devel leveldb-devel libffi-devel gcc-c++ redhat-rpm-config gcc python-devel openssl-devel

```
### Windows
This has not been tested at this time. Installing the Python package plyvel seems to require C++ compiler support tied to Visual Studio and libraries. For further instructions check [readthedocs](http://neo-python.readthedocs.io/en/latest/installwindows.html#installation-windows)

## Further Install Notes

For all of these, make sure that the `Chains` directory in your project has the proper write permissions

### Common issues on OSX
If you’re having an issue similar to this:
```python
from ._plyvel import (  # noqa
ImportError: dlopen(neo-python/venv/lib/python3.6/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
ERKSsPPS0_
Referenced from: neo-python/venv/lib/python3.6/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
Expected in: flat namespace
```
**Solution:** Update to plyvel 1.0.4: `pip install -r requirements.txt`


You may also encounter issues when installing the pycrypto module on OSX:
```
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```
This may be fixed by installing the gmp library using homebrew and running pip install with the following commandline:
```brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```
If you encounter an error like this:
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
The solution probably is
```brew reinstall openssl```


## Running the python-based node

There are two main ways to use neo-python: `prompt.py` and running just the node with custom code.
### prompt.py
Start prompt.py on TestNet:
```
$ np-prompt
```
Show help with all available arguments:

```
$ python prompt.py -h
usage: np-prompt [-h] [-m | -p [host] | --coznet | -c CONFIG]
                 [-t {dark,light}] [-v] [--datadir DATADIR] [--version]

optional arguments:
  -h, --help            show this help message and exit
  -m, --mainnet         Use MainNet instead of the default TestNet
  -p [host], --privnet [host]
                        Use a private net instead of the default TestNet,
                        optionally using a custom host (default: 127.0.0.1)
  --coznet              Use the CoZ network instead of the default TestNet
  -c CONFIG, --config CONFIG
                        Use a specific config file
  -t {dark,light}, --set-default-theme {dark,light}
                        Set the default theme to be loaded from the config
                        file. Default: 'dark'
  -v, --verbose         Show smart-contract events by default
  --datadir DATADIR     Absolute path to use for database directories
  --version             show program's version number and exit
```
### Node with custom code
Take a look at the examples in the `/examples` directory: https://github.com/CityOfZion/neo-python/tree/development/examples

See also the sections about “Settings and Logging” and “Interacting with Smart Contracts”.

### Api server ( JSON and/or REST)
```
$ np-api-server --testnet --port-rpc 8080 --port-rest 8088
[I 180315 09:27:09 NotificationDB:44] Created Notification DB At /Users/thomassaunders/.neopython/Chains/Test_Notif
[I 180315 09:27:09 threading:864] [TestNet] Block 5644 / 53999
[I 180315 09:27:09 np-api-server:11] Starting json-rpc api server on http://0.0.0.0:8080
[I 180315 09:27:09 _observer:131] Site starting on 8080
[I 180315 09:27:09 _observer:131] Starting factory <twisted.web.server.Site object at 0x110619828>
[I 180315 09:27:09 np-api-server:11] Starting REST api server on http://0.0.0.0:8088

# view help
$ np-api-server -h
usage: np-api-server [-h]
                   (--mainnet | --testnet | --privnet | --coznet | --config CONFIG)
                   [--port-rpc PORT_RPC] [--port-rest PORT_REST]
                   [--logfile LOGFILE] [--syslog] [--syslog-local [0-7]]
                   [--disable-stderr] [--datadir DATADIR]

optional arguments:
  -h, --help            show this help message and exit
  --datadir DATADIR     Absolute path to use for database directories

Network options:
  --mainnet             Use MainNet
  --testnet             Use TestNet
  --privnet             Use PrivNet
  --coznet              Use CozNet
  --config CONFIG       Use a specific config file

Mode(s):
  --port-rpc PORT_RPC   port to use for the json-rpc api (eg. 10332)
  --port-rest PORT_REST
                        port to use for the rest api (eg. 80)

Logging options:
  --logfile LOGFILE     Logfile
  --syslog              Log to syslog instead of to log file ('user' is the
                        default facility)
  --syslog-local [0-7]  Log to a local syslog facility instead of 'user'.
                        Value must be between 0 and 7 (e.g. 0 for 'local0').
  --disable-stderr      Disable stderr logger
  ```

## Further Reading

- [Interacting with the NEO blockchain using Prompt](python/prompt.md)
- [Settings and Loggings](python/logging.md)
- [Interacting with Smart Contracts](python/smartcont.md)
- [Tests](python/tests.md)
- [Python Compiler for the NEO Virtual Machine](python/compiler.md)

