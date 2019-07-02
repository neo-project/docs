---
typora-root-url: ..\..
---

### Javaを使ってNEOスマートコントラクトを書く方法

スマートコントラクトは、Java、C#、Python、Kotlinなどの高級言語で書かれており、AVM(NEO仮想マシンのバイトコード)にコンパイルされ、NEOネットワーク上で実行することができます。

現在、スマートコントラクトの開発にはC#をお勧めしています。Javaのコンパイラは、まだ開発中ですが、現在のバージョン(neoj)は基本的なメソッドを処理できます。

このセクションでは、NEOスマートコントラクトのJava開発環境の設定をガイドするチュートリアルと、スマートコントラクトのプロジェクト作成方法およびコンパイル方法のアイディアを含みます。

注意: このプロセスは、以下のステップを含みます。
1. NEOフレームワークライブラリ(JAR)の一部である、FunctionCodeまたはVerificationCodeを拡張するクラスのJavaコード(.java)を記述します。
2. 通常のJavaコンパイラを使用して、コードをJavaのバイトコードにコパイルします。(.class)
3. JVMコードをAVMコードに変換するneoj(C#)コンパイラをビルドします。(Windowsではneoj.exe)
4. neojを使って.classファイルをコンパイルします。(.avm)
5. NEO Node GUIをダウンロードして、NEOのテストネットワークに接続します。
6. .avmスクリプトをデプロイしてスマートコントラクトをネットワークに発行します。
7. .avmスクリプトを呼び出してスマートコントラクトを実行します。

### 詳細な手順

## ツール

これらの手順を実施する最も効果的な方法は、必要なすべてのツールをダウンロードしてコンパイルすることです。

1. NEOのノードGUIをダウンロードします。これを執筆した時点では、ベータ版のデベロッパーGUIを使用することをおすすめします。便利な追加のデバッグ機能があるためです。[CoZ NEO GUI](https://github.com/CityOfZion/neo-gui-developer)は、テストネットにデフォルトでプリセットされており、完全に同期するまで(最大で数時間)待つ必要があります。
2. NEOフレームワークライブラリのJARをダウンロードします。現在の最新バージョンはこちらです。[Antshares.SmartContract.Framework JAR](https://github.com/neo-project/neo-compiler/blob/master/neoj/AntShares.SmartContract.Framework.jar)
3. JavaのIDE、例えばIntelliJあるいはEclipseをダウンロードします。(オプションですがおすすめです。)
4. C#のIDEをダウンロードします。現在、neojコンパイラは広く配布するリリースフォーマットでないため、手動でビルドする必要があります。無料のVisual Studio2017を入手することをおすすめします。

## 開発ツール

### 1. Visual Studio 2017

既にVisual Studio 2017をPCにインストールし、インストール時に.NETクロスプラットフォーム開発をチェックした場合は、このセクションをスキップできます。

ダウンロードとインストール：

[Visual Studioのダウンロード](https://www.visualstudio.com/products/visual-studio-community-vs)

インストールプロセスは非常に簡単ですが、注意しながら一つ一つの操作をプロンプトに従い`.NET Core cross-platform development`をインストールする必要があります。そうでなければ、neo-vmプロジェクトをステップ3で開くことが出来ません。インストールには10分から1時間ほどかかります。

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. neo-compiler

インストールと設定の手順：

Githubの[neo-compiler](https://github.com/neo-project/neo-compiler)をダウンロードし、Visual Studioでソリューションを開き、neojプロジェクトを発行します。

neojコンパイラを発行します（JavaバイトコードからAVMバイトコードに変換します）。

![publish NEO compiler neoj](/assets/publish_neo_compiler_neoj.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)

リリースが成功した後は、neoj.exeファイルが、`bin\Release\PublishOutput`に生成されます。

このディレクトリを、実行PATHに追加する必要があります。PATHは、OSがコマンドラインあるいはターミナルウィンドウから、必要な実行ファイルを見つけるために使用するシステム環境変数です。

**Windows 10 および Windows 8:**

検索して次を選択をします: システム(コントロールパネル)の[システムの設定詳細]のリンクをクリックします。[環境変数]をクリックします。システム環境変数のセッションで、PATH環境変数を見つけて選択します。[編集]をクリックします。PATH環境変数が存在しない場合、[新規]をクリックします。システム環境変数の[編集]（または[新規]）のウィンドウで、PATH環境変数の値を指定します。[OK]をクリックします。[OK]をクリックして、残りのウィンドウをすべて閉じます。

**Windows 7:**

デスクトップから、コンピュータアイコンを右クリックします。コンテキストメニューからプロパティを選択します。[詳細設定]のリンクをクリックします。[環境変数]をクリックします。システム環境変数のセクションで、PATH環境変数を見つけて選択します。PATH環境変数が存在しない場合、[新規]をクリックします。システム環境変数の[編集]（または[新規]のシステム環境変数）のウィンドウで、PATH環境変数の値を指定します。[OK]をクリックします。[OK]をクリックして残りのウィンドウをすべて閉じます。

![edit environmental variables](/assets/edit_environmental_variables.png)

コマンドまたはPowerShellを実行し、neoj.exeと入力します。エラーがなく、出力にバージョン番号(図に示すように)が表示されている場合、環境変数の設定は成功です。

![powershell enviornment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


注意: Windpws 7 SP1ユーザが"Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found"というエラーが発生する可能性があります。必要な'api-ms-win-core-console-l2-1-0.dll'ファイルは、Windows 8以降のバージョンにのみ存在します。このエラーは、'api-ms-win-core-console-l2-1-0.dll'のコピーを取得し、それをC:\Windows\System32のディレクトリに置くことで解決できます。

## プロジェクトの作成

上記のインストールが完了したら、（例えばEclipseまたはIntelliJを使用して）Javaプロジェクトを作成することができます。

AntShares.SmartContract.Framework.jar（NEOコンパイラプロジェクト）を外部ライブラリとして追加する必要があります。


## プロジェクトのコンパイル

これでスマートコントラクトを定義するエントリメソッドを追加する準備が整いました。

```Java
import AntShares.SmartContract.Framework.FunctionCode;
import AntShares.SmartContract.Framework.Services.AntShares.Storage;

public class HelloWorld extends FunctionCode{

    public static byte[] Main(String[] args){
        Storage.Put(Storage.getCurrentContext(), "Greeting to the World", "Hello World!");
        return Storage.Get(Storage.getCurrentContext(),"Greeting to the World");
    }

}
```

プロジェクトをビルドすると、outフォルダに`HelloWorld.class`が出力されます。

続いて、neojを使用します。cmd.exeを実行し、次のコマンドを実行します。
> neoj.exe HelloWorld.class

成功すると、スマートコントラクトのバイトコードとして使用できるHelloWorld.avmが作成されます。

更なる情報とJavaの例を見るには、[Java Examples](https://github.com/neo-project/examples-java)を参照してください。

## スマートコントラクトのデプロイ

この段階まで来れば、スマートコントラクトを書くのは、どの言語を使用しても手順は同じです。このチュートリアルに従ってください: [ロック・コントラクトのデプロイ](http://docs.neo.org/ja-jp/sc/tutorial/Lock2.html)
