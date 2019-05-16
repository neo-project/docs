# 合约迁移

当需要将原来已经部署使用的合约进行升级或者想将旧合约的存储区迁移到新合约的时候，需要用到合约迁移的功能。

本教程演示基于：

- Visual Studio 2017 中创建的示例
- 智能合约框架 NeoSmartContractPlugin v2.9.3
- 最新版 [Neo-GUI](https://github.com/neo-project/neo-gui/releases)

## 实现 Migrate 接口
要使用合约迁移的功能，需要在原有合约中实现迁移接口，如下所示：
```c#
       	...
	public static object Main(string method, params object[] args)
        {

            ...
            if (method == "migrate")
            {
                if (args.Length < 9) return false;
                byte[] script = (byte[])args[0];
                byte[] plist = (byte[])args[1];
                byte rtype = (byte)args[2];
                ContractPropertyState cps = (ContractPropertyState)args[3];
                string name = (string)args[4];
                string version = (string)args[5];
                string author = (string)args[6];
                string email = (string)args[7];
                string description = (string)args[8];
                return Migrate(script, 
                               plist, 
                               rtype, 
                               cps, 
                               name, 
                               version, 
                               author, 
                               email, 
                               description);
            }
            ...
        }
	private static Boolean Migrate(byte[] script, 
            byte[] plist, 
            byte rtype, 
            ContractPropertyState cps, 
            string name, 
            string version, 
            string author, 
            string email, 
            string description)
        {
            var contract = Contract.Migrate(script, 
                plist,
                rtype, 
                cps, 
                name, 
                version,
                author, 
                email, 
                description);
            return true;
        }
       	... // 省略了部分代码
```

如果希望未来对合约进行迁移，那么此合约在部署之前必须实现 Migrate 接口。关于部署合约，请参考 [部署和调用合约](../quickstart/deploy-invoke.md)。

## 进行合约迁移
首先准备好新合约的Script，然后通过 NEO-GUI 调用旧合约的 Migrate 的接口。

> [!Note]
>
> 要获取合约的 Script，可以在 NEO GUI 中点击`高级`>`部署合约`，然后`加载`合约, 复制合约的内容备用。

1. 在 NEO-GUI 中，点击 `高级` > `调用合约`，输入旧合约的 ScriptHash, 可以查看到已部署的旧合约信息。

   ![调用合约](assets/migrate_m1.png)

2. 点击 `调用`，输入调用 Migrate 接口所需要的参数。这里第一个参数为之前复制的新合约内容。

   ![输入参数](assets/migrate_m2.png)

3. 输入完成后点击 `试运行` 查看结果。

   可以看到返回1-True，手续费为 491 GAS。

   ![试运行](assets/migrate_m3.png)

4. 点击 `调用`，等待区块确认交易。
5. 确认后，在调用合约界面输入新的合约 ScriptHash，可以查看到新的合约内容。

   ![新合约](assets/migrate_m4.png)

6. 再输入旧合约 ScriptHash，发现已经查询不到了。

   ![旧合约](assets/migrate_m5.png)

此时旧合约的存储区已迁移到新的合约上，旧合约被销毁。
