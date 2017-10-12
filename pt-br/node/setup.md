# Interfaces

O NEO conta com o [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (interface de linha de comando) e com o [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (interface gráfica de usuário).

O uso do Neo-GUI não requer instalação e é melhor descrito na sua [documentação](node/gui.md).

# Instalação e implementação de Nó

Para a implementação de um Nó *full* é necessário o [Neo-CLI](https://github.com/neo-project/neo-cli/releases), um software multi-plataforma que roda em Windows, Linux e Docker.


|                                   | Neo-CLI |
| --------------------------------- | ----------------- |
| Windows 7 SP1 x64                 | ✅                 |
| Windows Server 2008 R2 SP1        | ✅                 |
| Red Hat Enterprise Linux 7 Server | ✅                 |
| Ubuntu 14.04, 16.04, 16.10        | ✅                 |
| Debian 8                          | ✅                 |
| Fedora 23, 24                     | ✅                 |
| CentOS 7.1 & Oracle Linux 7.1     | ✅                 |
| openSUSE 13.2, 42.1               | ✅                 |
| Docker                            | ✅                 |



## Pré-requisitos do sistema

Para rodar um nó NEO é necessário instalar o [Runtime .NET Core](https://www.microsoft.com/net/download/core#/runtime) versão 1.0.1 ou acima. 


### Instalação **.Net Core** para Windows:

Em sistemas Windows, basta fazer o download do arquivo executável (*.exe*) no link acima e executá-lo seguindo as instruções de instalação. 


### Instalação **.Net Core** para Linux:

As instruções a seguir são para a distribuição/versão **Red Hat Enterprise Linux 7 Server**. 

> Para outras distribuições/versões do Linux, por favor consulte a [introdução ao .NET Core](https://docs.microsoft.com/pt-br/dotnet/core/get-started)


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

Após finalizar a instalação, você pode executar o seguinte comando para verificar se a instalação do ambiente .NET Core foi bem sucedida. 

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

Se você ver a mensagem final "Hello World!", é porque o .NET Core foi instalado com sucesso.


## Instalação do Nó

1. Faça o download do pacote [Neo-CLI](https://github.com/neo-project/neo-cli/releases) e extraia o conteúdo em uma pasta a sua escolha.

> :memo:
> Se você tentar fazer o download e compilar o código fonte do Neo-CLI diretamente do Github, você verá que o comando `dotnet neo-cli.dll` não funcionará corretamente após a compilação e você precisará copiar os arquivos `libleveldb.dll` e `sqlite3.dll` para o mesmo diretório em que estiver neo-cli.dll. Estes dois arquivos podem ser baixados no primeiro passo do pacote.

2. Abra o cmd do windows, navegue até o diretório em que os arquivos do Neo-CLI foram extraídos e execute o seguinte comando para rodar o nó NEO:

```
dotnet neo-cli.dll
```

> :memo:
> Se você estiver utilizando o Windows 7, pode ser necessário realizar [esta atualização](https://support.microsoft.com/pt-br/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot). Reinicie seu computador em seguida.


O Neo-CLI possui uma serie de APIs para acesso remoto. Se você quiser inicializar o nó com a API, você pode utilizar o comando
```
dotnet neo-cli.dll /rpc
```
3. Para permitir o acesso remoto à API é necessário abrir o firewall do Windows nas portas: 10331-10334, 20331-20334
