# Python Compiler for the NEO Virtual Machine

The `neo-boa` compiler is a tool for compiling Python files to the `.avm` format for usage in the [Neo Virtual Machine](https://github.com/neo-project/neo-vm/) which is used to execute contracts on the [Neo Blockchain](https://github.com/neo-project/neo/).

The compiler supports a subset of the Python language ( in the same way that a *boa constrictor* is a subset of the Python snake species) and currently works for Python 3.4 and 3.5.

## Installing the neo-boa compiler

Run the following command to install the neo-boa compiler:

```
pip install neo-boa

```

#### Docker

This project contains a Dockerfile to batch compile Python smart contracts. Clone the repository and navigate into the docker sub directory of the project. Run the following command to build the container:

```
docker build -t neo-boa .

```

The neo-boa Docker container takes a directory on the host containing python smart contracts as an input and a directory to compile the .avm files to as an output. It can be executed like this:

```
docker run -it -v /absolute/path/input_dir:/python-contracts -v /absolute/path/output_dir:/compiled-contracts neo-boa

```

The -v (volume) command maps the directories on the host to the directories within the container.

## Basic Usage

You may use the compiler like in the following example:

```
from boa.compiler import Compiler

Compiler.load_and_save('path/to/your/file.py')

```

See [boa.compiler.Compiler](http://neo-boa.readthedocs.io/en/latest/boa/compiler.html) and other modules for more advanced usage.