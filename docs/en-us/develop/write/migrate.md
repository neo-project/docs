# Contract Migration and Destruction

Smart contracts support to be migrated or destroyed after release. Before you can do that you need to reserve the specific interfaces in the old contracts.

## Contract Migration

In some cases you want to upgrade the smart contracts deployed on the blockchain or migrate the storage of a contract into another new contract, you need to migrate smart contracts.

### Implementing the Update interface
To enable migration function, you need to implement the update interface in the contract, as shown below:

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

If you want to migrate the contract later, you must implement the `update` interface in the contract prior to deployment. For more information, refer to [Deploying and Invoking Smart Contracts](../deploy/deploy.md).

### Migrating the contract
Firstly, get your new contract ready and then invoke the `update` interface.

For information about invoking the contract, refer to [Invoking contracts](../deploy/invoke.md).

After the `update` interface is implemented, the contract storage is migrated to the new contract and the old contract is destroyed.

## Contract Destruction

To destroy a contract, you need to reserve the destruction interface in the contract.

The contract destruction mainly calls the `Neo.Contract.Destroy` method:

```c#
Contract.Destroy();
```

The `Destroy` method accepts no parameters, and it will delete contract and the storage area.

