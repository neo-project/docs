# Before You Begin

In the sections that follow, we will work you through an example of how to release an NEP-5 asset on NEO blockchain, which includes the tasks of development environment set-up and configuration, smart contract compilation, smart contract deployment, and smart contract invocation on private chain.

This tutorial is based on the usage of the two full-node NEO clients: NEO-GUI and NEO-CLI. NEO-CLI will be used to set up a private chain accessible by nodes and NEO-GUI will be used to release smart contracts. Detailed information about the clients can be found in [NEO Node Introduction](../../node/introduction.md).

## System environment

NEO-GUI runs in the following environments: 

Windows 7 SP1 / Windows 8 / Windows 10 

[.NET Framework 4.7.1](https://www.microsoft.com/net/download/framework) must be installed for system versions prior to Windows 10. 

NEO-CLI runs in the following environments: 

- Linux (ubuntu 16.04 and above)
- Windows 10 

> [!NOTE]
>
> Windows 10 is a recommended choice since NEO-GUI and NEO-CLI will be running at the same time.
>
> This tutorial only describes the occurrences on Windows 10. Readers using other systems may refer to relevant chapters in [NEO Documentation](../../index.md) since environment and dependencies may differ in different systems.

### Download clients 

- NEO-GUI

  Download the latest Release version at [GitHub](https://github.com/neo-project/neo-gui/releases) and run neo-gui.exe.

- NEO-CLI

  Take Windows 10 for example:

  Users are not required to install a client. You may get the latest Release version from [GitHub](https://github.com/neo-project/neo-cli/releases) by downloading the source code from [GitHub](https://github.com/neo-project/neo-cli.git) or using the following command:

  ```
  $ git clone https://github.com/neo-project/neo-cli.git
  ```

## What's next?

[Setting up local network](enviroment.md)