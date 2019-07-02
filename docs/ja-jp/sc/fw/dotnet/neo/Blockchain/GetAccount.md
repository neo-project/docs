# Blockchain.GetAccount メソッド (byte[])

コントラクトスクリプトハッシュのハッシュに基づいた、アカウント（アドレス）を返します。

名前空間: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

アセンブリ: Neo.SmartContract.Framework

## 構文

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Account GetAccount(byte[] script_hash)
```

パラメータ: 長さが20のバイト配列のスクリプトハッシュ。

戻り値: [Account](../Account.md)。

## 例

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        byte[] scriptHash = {36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73};
        Account acc = Blockchain.GetAccount(scriptHash);
    }
}
```
あらかじめスクリプトハッシュを取得し、パラメータとしてスマートコントラクトに渡すことができます。次のコードでは、SDKを使用してアドレスをスクリプトハッシュに変換しています。

```c#
Static void Main(string[] args)
{
    byte[] scriptHash = Neo.Wallets.Wallet.ToScriptHash("AK4if54jXjSiJBs6jkfZjxAastauJtjjse").ToArray();
}
```



[戻る](../Blockchain.md)
