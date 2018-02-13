# Wie man Python verwendet, um einen NEO Smart Contract zu schreiben

*Originaler Autor: [@localhuman](https://github.com/localhuman)*

neo-python, der Python Knoten und SDK für die NEO Blockchain, macht es Ihnen möglich, Smart Contracts auf der NEO Blockchain zu erstellen, zu testen, und diese auszuführen. Es liefert folgende Funktionsweisen:

- Einen auf Python basierten P2P Knoten ausführen
- Interaktives CLI um Knoten zu konfigurieren und die Blockchain zu untersuchen
- In Python geschriebene Smart Contracts, oder Smart Contracts im `.avm format`, compilen, testen, anwenden und ausführen
- [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) und [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) konforme Wallet Funktionsweisen
- RPC Client
- `Runtime.Log` und `Runtime.Notify` Eventüberwachung

## Installieren der Python Bibliothek

Sie müssen die libleveldb Bibliothek installieren. Installieren Sie [Python 3.5](https://www.python.org/downloads/release/python-354/), um sicher zu stellen, dass Ihre Version die selbe des derzeitigen Instandhalters ist. Beachten Sie, dass Python 3.6 aufgrund von Inkompatibilität mit dem `byteplay` Modul zur zeit nicht unterstützt wird.

**Für OSX**, geben Sie folgendes ein:

```python
brew install leveldb
```

Falls ein Problem wie dieses auftritt:

```python
    from ._plyvel import (  # noqa
    ImportError: dlopen(neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
    ERKSsPPS0_
    Referenced from: neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
    Expected in: flat namespace
```

Müssen Sie evtl. plyvel (python libleveldb library) deinstallieren, und mit folgenden cflags reinstallieren:

```python
pip uninstall plyvel
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel plyvel --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/leveldb/1.20_2/include/" --global-option="-L/usr/local/lib"
```

Auch können bei der Installation Fehler mit dem pycrypto Modul in OSX auftreten:

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

Dies kann möglicherweise durch Installation der gmp library durch homebrew und durch Ausführen von pip install mit der folgenden Kommandozeile behoben werden:

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

**Für Ubuntu/Debian**, geben Sie Folgendes ein:

```python
apt-get install libleveldb-dev python3.5-dev python3-pip libssl-dev
```

**Für Centos/Redhat/Fedora**, geben Sie Folgendes ein:

```python
yum -y install development tools python35 python35-devel python35-pip readline-devel leveldb-devel libffi-devel
```

Sie müssen vielleicht die epel repo für das leveldb-devel package aktivieren, was durch editieren von `/etc/yum.repos.d/epel.repo` erzielt wird.

> [!Notiz]
>
> Für jedes Betriebssystem, stellen Sie sicher, dass der `Chains` Ordner in Ihrem Projekt die richtigen Schreibrechte besitzt.

**Für Windows:**

Dies wurde bis jetzt noch nicht getestet. Installieren des Python packages plyvel scheint C++ compiler Unterstützung, verbunden mit Visual Studio und den Bibliotheken, zu benötigen.

## Die virtuelle Umgebung aufsetzen

1. Kopieren Sie das Repositorium <https://github.com/CityOfZion/neo-python/> und öffnen Sie das Projektverzeichnis.

2. Erstellen Sie eine virtuelle Umgebung von Python 3 und aktivieren Sie diese mit:

   ```python
   python3.5 -m venv venv
   source venv/bin/activate
   ```

3. Anforderungen installieren:

   ```python
   pip install -r requirements.txt
   ```

4. Installieren Sie einem Bezug zu dem `neo` Arbeitsverzeichnis, welches erlaubt, `import neo` von jedem Standort im Projekt auszuführen.

   ```python
   pip install -e
   ```

> [!Notiz]
>
> - Wenn Sie neo-python mit `git pull` updaten, stellen Sie sicher dass Sie auch die Abhängigkeiten mit `pip install -r requirements.txt` updaten.
>
>
> - Wenn Sie neo-python zum ersten Mal benutzen, müssen Sie die Blockchain synchronisieren, was lange dauern kann. In diesem Projekt ist `bootstrap.py` inkludiert, was automatisch ein Chain-Verzeichnis für Sie downloaded. Um für das TestNet zu starten, führen Sie `python bootstrap.py` aus; um für das Mainnet zu starten, `python bootstrap.py -m`.

## Den auf Python basierenden Knoten ausführen

Nachdem Sie die Anforderungen installiert haben und ihre Umgebung aktiviert haben, benutzen Sie die `prompt.py` Datei um den Knoten auszuführen und grundlegende Aktivität zu bekommen.

Das folgende Beispiel startet `prompt.py` auf dem TestNet:

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> state
Progress: 1054913 / 1237188

neo>
```

Mit der Hilfe sehen Sie alle verfügbaren Argumente:

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

Sie können einen Block in dem aktuellen Server durch Hash oder durch Blockindex abfragen:

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

## Weitere Informationen (Englisch)

- [Interacting with the NEO blockchain using Prompt](en-us/sc/python/prompt.md)
- [Settings and Loggings](en-us/sc/python/logging.md)
- [Interacting with Smart Contracts](en-us/sc/python/smartcont.md)
- [Tests](en-us/sc/python/tests.md)
- [Python Compiler for the NEO Virtual Machine](en-us/sc/python/compiler.md)

