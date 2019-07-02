# スマートコントラクトのユニットテスト

ここまでのドキュメントを読んで、Visual Studio 2015でC#を使用してスマートコントラクトの準備をすることが出来ました。スマートコントラクトを記述した後に、どのようにしてユニットテストを行えば良いでしょうか？

## ユニットテストを記述する

下記のスマートコントラクトを例とした場合、コントラクトは`FunctionCode`を継承し、3つのパラメータを受け取り、戻り値は`int`型になります。


```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Test1: FunctionCode
    {
        public static int Main (int a, int b, int c)
        {
            if (a> b)
                return a * sum (b, c);
            else
                return sum (a, b) * c;
        }

        public static int sum (int a, int b)
        {
            return a + b;
        }
    }
}
```

コンパイルをするとコントラクトの`Test1.avm`ファイルが作成されますので、ユニットテスト用のプロジェクトを作成して`Test1.avm`のテストを行います。

まず最初にVisual StudioでC# コンソールアプリ (.Net Framework)プロジェクトを作成します（.NET Framework 4.6.2以降が必要です）。続いて、`Neo.dll`と`neon.dll`への参照を追加します。

> [!注意]
> [Neo](https://github.com/neo-project/neo)と[neo-vm](https://github.com/neo-project/neo-vm)をコンパイルすることで、これら2つのファイルを入手出来ます。

> あるいは、"NEO"と"Neo.VM"のNuGetパッケージをプロジェクトに追加することも可能です。ソリューションエクスプローラー内のコントラクトプロジェクトを右クリックし、NuGetパッケージの管理へと進み、"NEO"と検索して必要なパッケージをインストールします。

```c#
using System;
using System.IO;
using System.Linq;
using Neo;
using Neo.VM;
using Neo.Cryptography;

namespace ConsoleApplication1
{
    class program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@ "C: \ ... \ Test1.avm"));

            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush(2); // パラメータ c に対応
                sb.EmitPush(4); // パラメータ b に対応
                sb.EmitPush(3); // パラメータ a に対応
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // 実行を開始

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // 戻り値をここで設定
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

コンパイル出力は予想通り "Execution result 14" となります。

注意： パラメータのを渡すのに上記のコードを使用した場合、スタックの先頭が最初のパラメータと対応することに注目してください。便宜上、次のコードでパラメータを渡すこともできます。

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
スマートコントラクトの戻り値がint型ではなく、boolまたは他の型の場合、 図に示すように、`engine.EvaluationStack.Peek().GetBigInteger()`を他の値に変更する必要があります。

[](/assets/test_1.jpg)

------

### 📖 このドキュメントは編集中です

このドキュメントは編集中であり、できるだけ早く完成させていただきます。 [Github wiki](https://github.com/neo-project/neo/wiki)の他のドキュメントを見るか、[NEO公式サイト](http://www.neo.org)を参照してください。

NEOはコミュニティによるオープンソースプロジェクトです。関心がある場合は、GitHubでプルリクエストを作成して開発者のドキュメントに貢献することもできます。プロジェクトのドキュメントは[github.com/neo-project/docs](https://github.com/neo-project/docs)で見つける事ができます。あなたの貢献に感謝します。
