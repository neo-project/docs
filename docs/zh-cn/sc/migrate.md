# 合约迁移与销毁

合约支持在发布之后进行迁移或销毁，但需要在合约里预留某些接口。

## 合约迁移

当需要将原来已经部署使用的合约进行升级或者想将旧合约的存储区迁移到新合约的时候，需要用到合约迁移的功能。

### 实现 Update 接口
要使用合约迁移的功能，需要在原有合约中实现迁移接口，如下所示：

```c#
public static object Main(string method, params object[] args)
{
    ...
    if (method == "update") return Update((byte[])args[0], (string)args[1]);
    ...
}

[DisplayName("update")]
public static bool Update(byte[] script, string manifest)
{
    if (!Runtime.CheckWitness(Owner)) return false;
    Contract.Update(script, manifest);
    return true;
}
```

如果希望未来对合约进行迁移，那么此合约在部署之前必须实现 `update` 接口。关于部署合约，请参考 [部署和调用合约](deploy/deploy.md)。

### 进行合约迁移
首先准备好新合约，然后通过 Neo-CLI 调用旧合约的 Migrate 的接口。

关于调用合约，请参考 [调用合约](deploy/invoke.md)。

执行 Update 方法后，合约的存储区已迁移到新的合约上，旧合约被销毁。

## 合约销毁

智能合约支持在发布之后进行销毁操作，但需要在旧合约内预留销毁接口。

合约销毁主要调用了 Neo.Contract.Destroy 方法:

```c#
Contract.Destroy();
```

Destroy 方法不需要参数，调用该方法后，合约将会被删除，如果合约有存储区，则存储区也将被删除。之后合约将不可用。

