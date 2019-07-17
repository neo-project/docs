# システムの手数料

## トランザクションの手数料

現在、トランザクションの手数料はありません。しかし、ユーザは優先度のためにトランザクションの手数料を支払うことを選択することができます。

## スマートコントラクトの手数料

スマートコントラクトの手数料体系は、以下の表にあります。

最初の10GASは常に無料です。それゆえ合計10GAS以下の手数料は、サービス料を必要としません。

以下の手数料は、最低料金です。ユーザは優先度を得るために特別料金を支払うことを選択することができます。

すべてのスマートコントラクトの手数料は、サービス料とみなされ、すべてのNEOホルダーへの再分配のためのプールに入れられます。分配はNEOの量に比例します。

### システムコールの手数料

| SysCall                               | 手数料[Gas]    |
|:--------------------------------------|:------------|
| Runtime.CheckWitness                  | 0.2           |
| Blockchain.GetHeader                  | 0.1           |
| Blockchain.GetBlock                   | 0.2           |
| Blockchain.GetTransaction             | 0.1           |
| Blockchain.GetAccount                 | 0.1           |
| Blockchain.GetValidators              | 0.2           |
| Blockchain.GetAsset                   | 0.1           |
| Blockchain.GetContract                | 0.1           |
| Transaction.GetReferences             | 0.2           |
| Account.SetVotes                      | 1             |
| Validator.Register                    | 1000          |
| Asset.Create（システムアセット）        | 5000          |
| Asset.Renew（システムアセット）[毎年]  | 5000          |
| Contract.Create                       | 100~1000   |
| Contract.Migrate                      | 100~1000   |
| Storage.Get                           | 0.1           |
| Storage.Put [per KB]                  | 1             |
| Storage.Delete                        | 0.1           |
| (デフォルト)                           | 0.001         |

*最低 1 GASへの追加

上記表内APIの説明は[NEO Namespace]を参照(reference/api/neo.md)

スマートコントラクトの作成、又は移動のコストはまず100 GASの手数料が必要です。もしストレージ領域が必要ならば手数料は400 GAS加算です。そしてダイナミックコールが必要ならば手数料は500 GAS加算です。

### 命令の手数料

| 命令                                   | 手数料 [Gas]   |
|:--------------------------------------|:-----------|
| OpCode.PUSH16 [or less]               | 0             |
| OpCode.NOP                            | 0             |
| OpCode.APPCALL                        | 0.01          |
| OpCode.TAILCALL                       | 0.01          |
| OpCode.SHA1                           | 0.01          |
| OpCode.SHA256                         | 0.01          |
| OpCode.HASH160                        | 0.02          |
| OpCode.HASH256                        | 0.02          |
| OpCode.CHECKSIG                       | 0.1           |
| OpCode.CHECKMULTISIG [署名あたり]      | 0.1           |
| (デフォルト)                           | 0.001         |
