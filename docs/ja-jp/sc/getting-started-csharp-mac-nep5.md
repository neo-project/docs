# macOSにおいてC#を使用してnep5-tokenを作成する例


### 1. プロジェクトを作成

Visual Studio for Mac を起動し、新しいプロジェクト、.NET標準ライブラリを選択します。（.NET Core → ライブラリ）。

![](assets/mac4.png)

> [!Note]
> 新しいプロジェクトを作成するときは、.NET Coreバージョンの1.xを選択すると、次の「Neo.SmartContract.Framework」の追加が失敗するため、.NET Coreバージョンは2.0を選択します。
![](assets/mac5.png)

次に `依存関係`を右クリックし、`パッケージの追加...`をクリック。次に “neo”を検索し“Neo.SmartContract.Framework”を選択し、 `パッケージを追加`をクリック。

![](assets/mac6.png)

NEOスマートコントラクトのフレームワークを追加します。このパッケージの追加には数分かかります。

インストールが成功したら、次に以下のサンプルコードを上書きします：

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System;
using System.ComponentModel;
using System.Numerics;

namespace Neo.SmartContract
{
    public class ICO_Template : Framework.SmartContract
    {
        //Token Settings
        public static string Name() => "name of the token";
        public static string Symbol() => "SymbolOfTheToken";
        public static readonly byte[] Owner = "ATrzHaicmhRj15C3Vv6e6gLfLqhSD2PtTr".ToScriptHash();
        public static byte Decimals() => 8;
        private const ulong factor = 100000000; //decided by Decimals()
        private const ulong neo_decimals = 100000000;

        //ICO Settings
        private static readonly byte[] neo_asset_id = { 155, 124, 255, 218, 166, 116, 190, 174, 15, 147, 14, 190, 96, 133, 175, 144, 147, 229, 254, 86, 179, 74, 92, 34, 12, 205, 207, 110, 252, 51, 111, 197 };
        private const ulong total_amount = 100000000 * factor; // total token amount
        private const ulong pre_ico_cap = 30000000 * factor; // pre ico token amount
        private const ulong basic_rate = 1000 * factor;
        private const int ico_start_time = 1506787200;
        private const int ico_end_time = 1538323200;

        [DisplayName("transfer")]
        public static event Action<byte[], byte[], BigInteger> Transferred;

        [DisplayName("refund")]
        public static event Action<byte[], BigInteger> Refund;

        public static Object Main(string operation, params object[] args)
        {
            if (Runtime.Trigger == TriggerType.Verification)
            {
                if (Owner.Length == 20)
                {
                    // if param Owner is script hash
                    return Runtime.CheckWitness(Owner);
                }
                else if (Owner.Length == 33)
                {
                    // if param Owner is public key
                    byte[] signature = operation.AsByteArray();
                    return VerifySignature(signature, Owner);
                }
            }
            else if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "deploy") return Deploy();
                if (operation == "mintTokens") return MintTokens();
                if (operation == "totalSupply") return TotalSupply();
                if (operation == "name") return Name();
                if (operation == "symbol") return Symbol();
                if (operation == "transfer")
                {
                    if (args.Length != 3) return false;
                    byte[] from = (byte[])args[0];
                    byte[] to = (byte[])args[1];
                    BigInteger value = (BigInteger)args[2];
                    return Transfer(from, to, value);
                }
                if (operation == "balanceOf")
                {
                    if (args.Length != 1) return 0;
                    byte[] account = (byte[])args[0];
                    return BalanceOf(account);
                }
                if (operation == "decimals") return Decimals();
            }
            //you can choice refund or not refund
            byte[] sender = GetSender();
            ulong contribute_value = GetContributeValue();
            if (contribute_value > 0 && sender.Length != 0)
            {
                Refund(sender, contribute_value);
            }
            return false;
        }

        // initialization parameters, only once
        // 初始化参数
        public static bool Deploy()
        {
            byte[] total_supply = Storage.Get(Storage.CurrentContext, "totalSupply");
            if (total_supply.Length != 0) return false;
            Storage.Put(Storage.CurrentContext, Owner, pre_ico_cap);
            Storage.Put(Storage.CurrentContext, "totalSupply", pre_ico_cap);
            Transferred(null, Owner, pre_ico_cap);
            return true;
        }

        // The function MintTokens is only usable by the chosen wallet
        // contract to mint a number of tokens proportional to the
        // amount of neo sent to the wallet contract. The function
        // can only be called during the tokenswap period
        // 将众筹的neo转化为等价的ico代币
        public static bool MintTokens()
        {
            byte[] sender = GetSender();
            // contribute asset is not neo
            if (sender.Length == 0)
            {
                return false;
            }
            ulong contribute_value = GetContributeValue();
            // the current exchange rate between ico tokens and neo during the token swap period
            // 获取众筹期间ico token和neo间的转化率
            ulong swap_rate = CurrentSwapRate();
            // crowdfunding failure
            // 众筹失败
            if (swap_rate == 0)
            {
                Refund(sender, contribute_value);
                return false;
            }
            // you can get current swap token amount
            ulong token = CurrentSwapToken(sender, contribute_value, swap_rate);
            if (token == 0)
            {
                return false;
            }
            // crowdfunding success
            // 众筹成功
            BigInteger balance = Storage.Get(Storage.CurrentContext, sender).AsBigInteger();
            Storage.Put(Storage.CurrentContext, sender, token + balance);
            BigInteger totalSupply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
            Storage.Put(Storage.CurrentContext, "totalSupply", token + totalSupply);
            Transferred(null, sender, token);
            return true;
        }

        // get the total token supply
        // 获取已发行token总量
        public static BigInteger TotalSupply()
        {
            return Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
        }

        // function that is always called when someone wants to transfer tokens.
        // 流转token调用
        public static bool Transfer(byte[] from, byte[] to, BigInteger value)
        {
            if (value <= 0) return false;
            if (!Runtime.CheckWitness(from)) return false;
            if (from == to) return true;
            BigInteger from_value = Storage.Get(Storage.CurrentContext, from).AsBigInteger();
            if (from_value < value) return false;
            if (from_value == value)
                Storage.Delete(Storage.CurrentContext, from);
            else
                Storage.Put(Storage.CurrentContext, from, from_value - value);
            BigInteger to_value = Storage.Get(Storage.CurrentContext, to).AsBigInteger();
            Storage.Put(Storage.CurrentContext, to, to_value + value);
            Transferred(from, to, value);
            return true;
        }

        // get the account balance of another account with address
        // 根据地址获取token的余额
        public static BigInteger BalanceOf(byte[] address)
        {
            return Storage.Get(Storage.CurrentContext, address).AsBigInteger();
        }

        // The function CurrentSwapRate() returns the current exchange rate
        // between ico tokens and neo during the token swap period
        private static ulong CurrentSwapRate()
        {
            const int ico_duration = ico_end_time - ico_start_time;
            uint now = Runtime.Time;
            int time = (int)now - ico_start_time;
            if (time < 0)
            {
                return 0;
            }
            else if (time < ico_duration)
            {
                return basic_rate;
            }
            else
            {
                return 0;
            }
        }

        //whether over contribute capacity, you can get the token amount
        private static ulong CurrentSwapToken(byte[] sender, ulong value, ulong swap_rate)
        {
            ulong token = value / neo_decimals * swap_rate;
            BigInteger total_supply = Storage.Get(Storage.CurrentContext, "totalSupply").AsBigInteger();
            BigInteger balance_token = total_amount - total_supply;
            if (balance_token <= 0)
            {
                Refund(sender, value);
                return 0;
            }
            else if (balance_token < token)
            {
                Refund(sender, (token - balance_token) / swap_rate * neo_decimals);
                token = (ulong)balance_token;
            }
            return token;
        }

        // check whether asset is neo and get sender script hash
        private static byte[] GetSender()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput[] reference = tx.GetReferences();
            // you can choice refund or not refund
            foreach (TransactionOutput output in reference)
            {
                if (output.AssetId == neo_asset_id) return output.ScriptHash;
            }
            return new byte[]{};
        }

        // get smart contract script hash
        private static byte[] GetReceiver()
        {
            return ExecutionEngine.ExecutingScriptHash;
        }

        // get all you contribute neo amount
        private static ulong GetContributeValue()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            TransactionOutput[] outputs = tx.GetOutputs();
            ulong value = 0;
            // get the total amount of Neo
            // 获取转入智能合约地址的Neo总量
            foreach (TransactionOutput output in outputs)
            {
                if (output.ScriptHash == GetReceiver() && output.AssetId == neo_asset_id)
                {
                    value += (ulong)output.Value;
                }
            }
            return value;
        }
    }
}
```

次にこの部分を次のように編集します(好きな名前で大丈夫です)。
```c#
public static string Name() => "SimpleCoin";
public static string Symbol() => "SPC";
```

`Build`，`Build All` をクリックして、コードをコンパイルします。コンパイルが成功すると、bin/Debug/netstandard2.0/に.dllファイルが生成されます。 この .dllファイルは.NET IL言語ファイルで、後でneonコンパイラによって.avmスマートコントラクトファイルにコンパイルされます。

この例では、プロジェクトの名前はtest1です。コンパイル後、test1.dllが生成されます。このファイルは後で使用されます。

### 2. コンパイル

`ターミナル`を開き、以下のコマンドを実行します。

```
dotnet neon.dll test1.dll
```

これでコンパイルを実行することができます。ここの test1.dll はステップ2で作成したものです。

```
Neo.Compiler.MSIL console app v2.0.3.1
Find entrypoint:System.Void test1.Class1::Main()
convert succ
gen abi succ
write:test1.avm
write:test1.abi.json
SUCC
```

上記のメッセージが表示されればコンパイル完了です。ディレクトリに test1.avm ファイルが生成されます。

コンパイル時に次のエラーが表示される場合は以下を参照してください。

#### エラー1
```
Neo.Compiler.MSIL console app v2.0.3.1
LoadModule Error:System.Exception: can't parese event type from:System.Action`3<System.Byte[],System.Byte[],System.Numerics.BigInteger>.maybe it is System.Action<xxx> which is defined in mscorlib.dll，copy this dll in.
   at Neo.Compiler.MSIL.ILField..ctor(ILType type, FieldDefinition field) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/MSIL/ILModule.cs:line 127
   at Neo.Compiler.MSIL.ILType..ctor(ILModule module, TypeDefinition type) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/MSIL/ILModule.cs:line 73
   at Neo.Compiler.MSIL.ILModule.LoadModule(Stream dllStream, Stream pdbStream) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/MSIL/ILModule.cs:line 48
   at Neo.Compiler.Program.Main(String[] args) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/Program.cs:line 71
```

このエラーはWindowsのmscorlib.dllで定義されているSystem.Actionについてですが、Monoではおそらく別の場所にあり、参照できなくてエラーが出ています。なので、Mac上でC#を用いてスマートコントラクトを書く場合はSystem.Actionを使用しないことを推奨します。

以下のコードを次のように修正します
```c#
[DisplayName("transfer")]
public static event Action<byte[], byte[], BigInteger> Transferred;
[DisplayName("refund")]
public static event Action<byte[], BigInteger> Refund;
```

```c#
public delegate void MyAction<T, T1>(T p0, T1 p1);
public delegate void MyAction<T, T1, T2>(T p0, T1 p1, T2 p2);

[DisplayName("transfer")]
public static event MyAction<byte[], byte[], BigInteger> Transferred;
[DisplayName("refund")]
public static event MyAction<byte[], BigInteger> Refund;
```

詳細は、以下のWebサイトを参照してください：
[https://github.com/neo-project/examples-csharp/issues/11](https://github.com/neo-project/examples-csharp/issues/11)

#### エラー2
```
Neo.Compiler.MSIL console app v2.0.3.1
Convert Error:Mono.Cecil.AssemblyResolutionException: Failed to resolve assembly: 'Neo.SmartContract.Framework, Version=2.5.4.0, Culture=neutral, PublicKeyToken=null'
   at Mono.Cecil.BaseAssemblyResolver.Resolve(AssemblyNameReference name, ReaderParameters parameters)
   at Mono.Cecil.BaseAssemblyResolver.Resolve(AssemblyNameReference name)
   at Mono.Cecil.DefaultAssemblyResolver.Resolve(AssemblyNameReference name)
   at Mono.Cecil.MetadataResolver.Resolve(TypeReference type)
   at Mono.Cecil.MetadataResolver.Resolve(MethodReference method)
   at Mono.Cecil.ModuleDefinition.Resolve(MethodReference method)
   at Mono.Cecil.MethodReference.Resolve()
   at Neo.Compiler.MSIL.CctorSubVM.Parse(ILMethod from, NeoModule to) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/MSIL/CctorSubVM.cs:line 138
   at Neo.Compiler.MSIL.ModuleConverter.Convert(ILModule _in) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/MSIL/Converter.cs:line 86
   at Neo.Compiler.Program.Main(String[] args) in /Users/NanjoHiroki/Ginco/neo-compiler/neon/Program.cs:line 86
```
このエラーはコンパイル時にNeo.SmartContract.Frameworkを参照できない為に起こるエラーです。Neo.SmartContract.Framework.dllを同ディレクトリにおいてあげることによって解決できます。

まずはこちらからソースコードを[ダウンロード](https://github.com/neo-project/neo-devpack-dotnet)し、Visual Studio for Mac でソリューションを開き、Neo.SmartContract.Frameworkプロジェクトをビルドします。

ビルドが成功すると、bin\Debugディレクトリ以下にNeo.SmartContract.Framework.dllファイルが生成されます。

そのファイルをneon.dllと同じディレクトリに配置、再度`dotnet neon.dll test1.dll`を実行します。
