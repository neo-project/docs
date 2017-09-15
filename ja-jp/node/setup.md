# NEOノードのインストールとデプロイ

以前の記事ではNEOネットワークにおけるノードのための2つのクライアントについて説明しています。1つは[Neo-CLI](https://github.com/neo-project/neo-cli/releases)（デベロッパーが使用するためのコマンドラインクライアント）、もう1つは[Neo-GUI](https://github.com/neo-project/neo-gui/releases)（高度なユーザのためのグラフィカルインターフェースクライアント）です。

コンセンサスノードをデプロイするには、Windows、Linux、Dockerで実行するクロスプラットフォームプログラムである`Neo-CLI`を使用します。

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

> [!注意]
> 現在のところ、NEOノードはMac OSでは正しく動作しません。将来的にはMac OSをサポートしますので、更なるアップデートをお待ちください。

## 実行環境

NEOノードを実行するには、[.NET Core Runtime](https://www.microsoft.com/net/download/core#/runtime)バージョン1.0.1以降のインストールが必要です。

### Windowsシステムのインストール方法

Windowsシステムでは、.NET Coreのインストールが非常に便利で、直接ダウンロードと実行ができます。

### Linuxシステムのインストール方法

以下は、.NET CoreがRed Hat Enterprise Linux 7 Serverにおいてどのようにインストールされるかについて示しています。

> [!注意]
> 他のLinuxカーネルディストリビューションのインストール方法については、 [.NET Core installation tutorial](https://www.snetnet/core#linuxredhat)を参照してください。


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

インストールが完了した後は、.NET Core環境が正常にインストールされたかどうかを確認するために、下記コマンドを実行することができます。

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

最後に"Hello World!"が出力できれば、.NET Coreのインストールは成功です。


## NEOノードのインストール

1. Githubの[Neo-CLI](https://github.com/neo-project/neo-cli/releases)パッケージをダウンロードし、解凍します。

> [!注意]
> Githubから直接、Neo-CLIのソースをダウンロードしてコンパイルする場合、コンパイル後に`dotnet neo-cli.dll`が正常に動作しない場合は、neo-cli.dllと同じディレクトリにlibleveldb.dllとsqlite3.dllをコピーする必要があります。これらの2ファイルは最初の手順にてパッケージ内にダウンロードできます。

2. コマンドラインを開き、プログラムのディレクトリに移動し、次のコードを入力してNEOノードを開始します。

```
dotnet neo-cli.dll
```

Neo-CLIは、外部アクセスのための一連のAPIを提供します。APIを公開しながらノードを開始したい場合、次のコマンドを実行します。
```
dotnet neo-cli.dll /rpc
```
3. ノードのAPIにアクセスするための外部プログラムが必要な場合は、ファイアウォールのポート：10331-10334, 20331-20334を開く必要があります。
