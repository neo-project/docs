# Compilatore Python per la macchina virtuale di NEO

Il compilatore `neo-boa` è uno strumento utilizzato per compilare i file Python nel formato `.avm` da essere usati nella [Macchina Virtuale Neo](https://github.com/neo-project/neo-vm/) utilizzata per eseguire contratti sulla [Blockchain Neo](https://github.com/neo-project/neo/).

Il compilatore supporta un sottoinsieme del linguaggio Python (nello stesso modo in cui un *boa costrittore* é un sottoinsieme delle specie di serpenti Python (Pitone)) e attualmente funziona con Python 3.4 e 3.5.

## Installazione del compilatore neo-boa

Eseguire il seguente comando per installare il compilatore neo-boa:

```
pip install neo-boa

```

#### Docker

Questo progetto contiene un Dockerfile per compilare in lotto gli smart contract in Python. Clona l'archivio e naviga nella sottodirectory del docker del progetto. Esegui il seguente comando per creare il container:

```
docker build -t neo-boa .

```

Il container neo-boa Docker prende una directory sull'host contenente gli smart contract in Python come input e una directory per compilare i files .avm come output. Può essere eseguito così:

```
docker run -it -v /absolute/path/input_dir:/python-contracts -v /absolute/path/output_dir:/compiled-contracts neo-boa

```

Il comando -v (volume) mappa le directory sull'host alle directory all'interno del container.

## Uso di base

Puoi usare il compilatore come nell'esempio seguente:

```
from boa.compiler import Compiler

Compiler.load_and_save('path/to/your/file.py')

```

Vedi [boa.compiler.Compiler](http://neo-boa.readthedocs.io/en/latest/boa/compiler.html) e altri moduli per usi più avanzati. 
