# NEO SDK（ソフトウェア開発キット）

NEO SDKを使用することで、ウォレットクライアント、ゲームなど、NEOに基づいた様々なアプリケーションを開発できます。NEO SDKを使用すると、NeoVMに移行することなく既存の環境でプロジェクトを実行できます。NeoVMでの開発に関する情報は、[スマートコントラクト](ja-jp/sc/introduction.md)を参照してください。

このドキュメントはNEO 2.7.1に適合します。NEO SDKでのアプリケーション開発は、Visual Studio 2017と連携して行う方がより簡単です。

## ダウンロード

1. Visual Studio 2017で、新しいプロジェクトを作成します。
2. プロジェクト名を右クリックし、[Manage NuGet program package]を選択します。
3. [NEO]を検索し、NEOパッケージをインストールします。

別の方法として、[NuGetパッケージ](https://www.nuget.org/packages/Neo/2.7.1)をダウンロードして手動でインストールすることもできます。

## プロジェクト構成

NEO SDKは、下記のもので構成されています。

**NEO SDKの主要プロジェクト：**

NEO：https://github.com/neo-project/neo

NeoVM：https://github.com/neo-project/neo-vm

**NEO SDK従属：**

.NETFramework 4.7

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 

​	Replicon.Cryptography.SCrypt (>= 1.1.6.13) 

.NETStandard 2.0

​	Microsoft.AspNetCore.Server.Kestrel (>= 2.0.0) 

​	Microsoft.AspNetCore.Server.Kestrel.Https (>= 2.0.0) 

​	Microsoft.AspNetCore.WebSockets (>= 2.0.0) 

​	Microsoft.EntityFrameworkCore.Sqlite (>= 2.0.0) 

​	Microsoft.Extensions.Configuration.Json (>= 2.0.0) 
