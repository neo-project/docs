---
typora-root-url: ..\..
---

### C#を使用してNeoスマートコントラクトを作成する方法

スマートコントラクトの開発には現在C#を推奨しています（ただし、Java、Kotlin、Go、C / C ++、Python、JavaScriptなどのプログラミング言語をサポートまたは計画しています）

このセクションでは、NeoスマートコントラクトのC#開発環境を設定するための簡単なチュートリアルと、スマートコントラクトプロジェクトの作成方法とコンパイル方法を紹介します。

   > [!注意]
   > 現在、すべてのプロジェクトがVisual Studio 2017バージョンにアップグレードされています。Visual Studio 2015を使用してスマートコントラクトを作成するには、[VS2015でC#を使用してNeoスマートコントラクトを作成する方法](getting-started-2015.md)を参照して下さい。

## 開発ツール

### 1. Visual Studio 2017

お使いのコンピュータにVisual Studio 2017をインストール済みであり、インストール時に「.NET Core クロスプラットフォームの開発」をチェックした場合は、このセクションをスキップできます。

ダウンロードとインストール：

[Visual Studioのダウンロード](https://www.visualstudio.com/products/visual-studio-community-vs)

インストールプロセスは非常に簡単です、操作画面に従って進み、「.NET Core クロスプラットフォームの開発」のインストールをチェックする必要があります。そうでなければ、ステップ#3でNeo.VMプロジェクトを開くことができません。インストールには、約10分から1時間かかります。

![install net core cross-platform development toolset](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPluginプラグイン

インストール方法：

Visual Studio 2017を開き、[ツール]メニューから[拡張機能と更新プログラム]をクリック、ウィンドウの左側にある[オンライン]タブをクリック、ウィンドウの右上にある検索ボックスで Neo を検索し、NeoContractPluginプラグインをダウンロードします（インターネットアクセスが必要です）。

![download and install NEO smart contract plugin](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

インストールと設定の手順：

Githubで[neo-compiler](https://github.com/neo-project/neo-compiler)プロジェクトをダウンロードし、Visual Studio 2017でソリューションを開き、AntShares.Compiler.MSILプロジェクトを「公開」します。

![publish NEO compiler msil project](/assets/publish_neo_compiler_msil_project.png)

![publish and profile settings](/assets/publish_and_profile_settings.png)


発行が成功すると、neon.exeファイルが`bin\Release\PublishOutput`に生成されます。

このディレクトリを実行パスに追加する必要があります。 パスは、オペレーティングシステムがコマンドラインまたはターミナルウィンドウから必要な実行ファイルを見つけるために使用するシステム変数です。

**Windows 10およびWindows 8：**

  検索で、「システム」を検索して[システム（コントロールパネル）]を選択します。
  [システムの詳細設定]をクリックします。[環境変数]をクリックします。 
  「システム環境変数」セクションで、「PATH」環境変数を探して選択します。 [編集]をクリックします。「PATH」環境変数が存在しない場合は、[新規]をクリックします。 
  「システム変数の編集（または新しいシステム変数）」ウィンドウで、「PATH」環境変数の値を指定します。 [OK]をクリックします。 [OK]をクリックして残りのウィンドウをすべて閉じます。

**Windows 7：**

  デスクトップの[コンピュータ]アイコンを右クリックします。
  コンテキストメニューから[プロパティ]を選択します。 
  [システムの詳細設定]をクリックします。[環境変数]をクリックします。 
  「システム環境変数」セクションで、「PATH」環境変数を探して選択します。 [編集]をクリックします。 「PATH」環境変数が存在しない場合は、[新規]をクリックします。 
  「システム変数の編集（または新しいシステム変数）」ウィンドウで、「PATH」環境変数の値を指定します。 [OK]をクリックします。 [OK]をクリックして残りのウィンドウをすべて閉じます。

![edit environmental variables](/assets/edit_environmental_variables.png)

次に、コマンドプロンプトまたはPowerShellを実行し、neonと入力します。エラーがなく、出力にバージョン番号が表示されている場合（図示）、環境変数の設定は成功しています。

![powershell environment variabled updated correctly](/assets/powershell_enviornment_variabled_updated_correctly.png)


注意してください。 Windows 7 SP1のユーザーは「未処理の例外：System.DllNotFoundException：DLL 'api-ms-win-core-console-l2-1-0.dll'を読み込めません：指定されたモジュールが見つかりませんでした」というエラーが発生する可能性があります。必要な 'api-ms-win-core-console-l2-1-0.dll'ファイルはWindows 8以降のバージョンにのみ存在します。このエラーは、 'api-ms-win-core-console-l2-1-0.dll'のコピーを取得し、それをC:\Windows\System32ディレクトリに置くことで解決できます。

## プロジェクトを作成

上記のインストール構成が成功したら、Visual Studio 2017でNeo.SmartContract.Templateプロジェクトを作成できます。

![new smart contract project](/assets/new_smart_contract_project.png)

プロジェクトを作成すると、次のように、FunctionCodeから継承されたデフォルトのクラスであるC#ファイルが自動的に生成されます。

![smart contract function code](/assets/smart_contract_function_code.png)

## プロジェクトをコンパイルする

スマートコントラクトを定義するエントリメソッドをすべて追加する準備が整いました。

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// C#のMainは大文字で始まります
    {
        
    }
}
```

正常にコンパイルすると、`bin/Debug`ディレクトリにあるSmartContract1.avmが表示されます。これはNeoスマートコントラクトとして生成されるファイルです。

![compile smart contract](/assets/compile_smart_contract.png)

Neoスマートコントラクト開発環境の設定を完了したので、[Neoスマートコントラクトチュートリアル](tutorial.md)を参照してください。


