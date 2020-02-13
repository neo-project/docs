# Before You Begin

In the sections that follow, we will work you through an example of how to release an NEP-5 asset on Neo blockchain, which includes the tasks of development environment set-up and configuration, smart contract compilation, smart contract deployment, and smart contract invocation on private chain.

This tutorial is based on the usage of the two full-node Neo clients: Neo-GUI and Neo-CLI. Neo-CLI will be used to set up a private chain accessible by nodes and Neo-GUI will be used to release smart contracts. Detailed information about the clients can be found in [Neo Node Introduction](../../node/introduction.md).

## System environment

Neo-GUI runs in the following environments: 

Windows 7 SP1 / Windows 8 / Windows 10 

[.NET Framework 4.7.1](https://www.microsoft.com/net/download/framework) must be installed for system versions prior to Windows 10. 

Neo-CLI runs in the following environments: 

- Linux (ubuntu 16.04 and above)
- Windows 10 

> [!NOTE]
>
> Windows 10 is a recommended choice since Neo-GUI and Neo-CLI will be running at the same time.
>
> This tutorial only describes the occurrences on Windows 10. Readers using other systems may refer to relevant chapters in [Neo Documentation](../../index.md) since environment and dependencies may differ in different systems.

### Download clients 

- Neo-GUI

  Download the latest Release version at [GitHub](https://github.com/neo-project/neo-gui/releases) and run neo-gui.exe.

- Neo-CLI

  Take Windows 10 for example:

  Download the latest [Neo-CLI](https://github.com/neo-project/neo-cli/releases) package according to your operating system on Github and unzip it.

## What's next?

[Setting up local network](enviroment.md)