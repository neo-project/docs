# スマートコントラクトの例 - Lock (lock)

```c#
public class Lock : FunctionCode
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (timestamp > header.Timestamp) return false;
        return VerifySignature(pubkey, signature);
    }
}
```

このコントラクトでは、ブロックチェーンのシステム時刻が指定された時刻に達するまでコントラクトから取り出せないタイムスタンプを指定し、ブロックチェインのシステム時刻が指定された時刻を過ぎた後、契約者が資金を引き出すことができます。

現在の時刻は、ブロックチェーン内の最新ブロックの時刻によってコード内で取得されます（エラーは約15秒です）。 詳細については、[Blockchainクラス](../fw/dotnet/neo/Blockchain.md)、[Headerクラス](../fw/dotnet/neo/Header.md)を参照してください。
