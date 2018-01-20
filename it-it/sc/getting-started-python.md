# Introduzione di neo-python

*Autore Principale: [@localhuman](https://github.com/localhuman)*

neo-python, il nodo python e l'SDK per la blockchain NEO, permette di costruire, testare, ed eseguire smart contract sulla blockchain Neo. Fornisce le seguenti funzionalità principali:

- Esecuzione di un nodo P2P basato su Python
- CLI interattiva per la configurazione del nodo e l'ispezione della blockchain
- Compilare, testare, implementare ed eseguire Smart Contract scritti in python o qualsiasi Smart Contract in `.avm format`
- Funzionalitá del wallet conforme a [NEP2](https://github.com/neo-project/proposals/blob/master/nep-2.mediawiki) e [NEP5](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki) 
- Client RPC 
- Monitoraggio degli eventi `Runtime.Log` e `Runtime.Notify` 

## Installazione della libreria Python

Occorre installare la libreria libleveldb. Installa [Python 3.5](https://www.python.org/downloads/release/python-354/) per essere sicuro di non incombere in alcun problema con la tua versione di Python che potrebbe essere diversa dalle versioni correntemente mantenute. Nota che Python 3.6 non è attualmente supportato a causa della sua incompatibilità con il modulo byteplay.

**Per OSX**, inserire quanto segue:

```python
brew install leveldb
```

Se stai avendo un problema simile a questo:

```python
    from ._plyvel import (  # noqa
    ImportError: dlopen(neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so, 2): Symbol not found: __ZN7leveldb2DB4OpenERKNS_7Options
    ERKSsPPS0_
    Referenced from: neo-python/venv/lib/python3.5/site-packages/plyvel/_plyvel.cpython-35m-darwin.so
    Expected in: flat namespace
```

Dovresti disinstallare plyvel (la libreria Python libleveldb), e reinstallarla con i seguenti cflags:

```python
pip uninstall plyvel
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel plyvel --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/leveldb/1.20_2/include/" --global-option="-L/usr/local/lib"
```

Potresti incontrare problemi anche mentre stai installando il modulo pycrypto su OSX:

```python
src/_fastmath.c:36:11: fatal error: 'gmp.h' file not found
# include <gmp.h>
          ^~~~~~~
330 warnings and 1 error generated.
error: command 'clang' failed with exit status 1
```

Ciò può essere risolto installando la libreria gmp usando homebrew ed eseguendo pip install con la seguente linea di comando:

```python
brew install gmp
CFLAGS='-mmacosx-version-min=10.7 -stdlib=libc++' pip install --no-use-wheel pycrypto --no-cache-dir --global-option=build_ext --global-option="-I/usr/local/Cellar/gmp/6.1.2/include/" --global-option="-L/usr/local/lib"
```

**Per Ubuntu/Debian**, inserire quanto segue:

```python
apt-get install libleveldb-dev python3.5-dev python3-pip libssl-dev
```

**Per Centos/Redhat/Fedora**, inserire quanto segue:

```python
yum -y install development tools python35 python35-devel python35-pip readline-devel leveldb-devel libffi-devel
```

Potresti aver bisogno di abilitare epel repo per il pacchetto leveldb-devel, ed é possibile farlo modificando `/etc/yum.repos.d/epel.repo`.

> [!Nota]
>
> Assicurati che la directory `Chains` nel tuo progetto abbia gli adeguati permessi di scrittura. 

**Per Windows:**

Attualmente non testato. L'installazione del pacchetto Python plyvel sembra richiedere il supporto del compilatore C++ legato a Visual Studio e librerie.

## Configurazione dell'ambiente virtuale

1. Clonare l'archivio <https://github.com/CityOfZion/neo-python/> e navigare nella directory del progetto. 

2. Creare un ambiente virtuale Python 3 e attivarlo tramite:

   ```python
   python3 m venv venv
   source venv/bin/activate
   ```

   o per installare esplicitamente Python 3.5:

   ```python
   virtualenv -p /usr/local/bin/python3.5 venv
   source venv/bin/activate
   ```

3. Requisiti di installazione:

   ```python
   pip install -r requirements.txt
   ```

4. Installare un riferimento alla directory funzionante `neo`, la quale permette di `import neo` da qualsiasi parte nel progetto (esempi):


   ```python
   pip install -e
   ```

> [!Nota]
>
> - Se stai aggiornando neo-python con `git pull`, assicurati di aggiornare le dipendenze con `pip install -r requirements.txt`.
>
>
> - Se stai usando neo-python per la prima volta, occorre sincronizzare la blockchain, questo potrebbe richiedere molto tempo. Incluso nel progetto vi è `bootstrap.py` per scaricare automaticamente la directory della chain per te. Per il bootstrap della testnet, esegui `python bootstrap.py`; Per il bootstrap della mainnet, usa `python bootstrap.py -m`.

## Esecuzione del nodo basato su Python

Dopo aver installato i requisiti e aver attivato l'ambiente, usa il file `prompt.py` per eseguire il nodo così come alcune interattività di base.

Il seguente esempio avvia `prompt.py` sulla TestNet:

```python
python prompt.py
NEO cli. Type 'help' to get started

neo> state
Progress: 1054913 / 1237188

neo>
```

Puoi visualizzare l'aiuto per vedere tutti gli argomenti disponibili:

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

Puoi interrogare un blocco nel server corrente tramite l'hash o l'indice del blocco:

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

## Ulteriori letture

- [Interagire con la blockchain di NEO usando il Prompt](python\prompt.md)
- [Impostazioni e Registrazioni](python\logging.md)
- [Interagire con gli Smart Contracts](python\smartcont.md)
- [Tests](python\tests.md)
- [Compilatore Python per la Macchina Virtuale di NEO](python\compiler.md)
