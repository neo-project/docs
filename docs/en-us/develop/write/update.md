# Contract Update and Destroy

Smart contracts support to be updated or destroyed after release. Before you can do that you need to implement the Update and Destroy interfaces in the old contracts.

## Contract Update

In some cases you want to upgrade the smart contracts deployed on the blockchain or migrate the storage of a contract into another new contract, you need to update smart contracts. Neither the contract hash nor the storage is changed when the contract is upgraded.

### Implementing the Update interface
To enable the update function, you need to implement the `Update` method in the contract. In the contract template this method has been implemented by default, as follows:

```c#
public static bool Verify() => IsOwner();

public static void Update(ByteString nefFile, string manifest)
{
    if (!IsOwner()) throw new Exception("No authorization.");
    ContractManagement.Update(nefFile, manifest, null);
}
```

If you want to update the contract later, you must implement the `update` method in the contract prior to deployment. For more information, refer to [Deploying and Invoking Smart Contracts](../deploy/deploy.md).

### Updating the contract
1. Get the compiled NEF file and Manifest file of the new contract ready

2. Base64-encode the NEF file with the tool like [File to Base64 online](https://www.hitoy.org/tool/file_base64.php)

3. Compress and escape the Manifest file with the tool like [JSON compressed and escaped online](http://www.bejson.com/zhuanyi/)

4. Use the invoke command to call the update method of the contract


For information about invoking the contract, refer to [Invoking contracts](../deploy/invoke.md).

![](../../../zh-cn/develop/assets/update.png)

After the `update` method is executed, the contract is upgraded and neither the contract hash nor the storage area is changed.

## Contract Destruction

To destroy a contract, you need to reserve the destruction method in the contract.

To use the contract destroy feature, you need to implement the destroy method in the original contract. The `destroy` method has been implemented by default in the contract template as follows.

```c#
public static bool Verify() => IsOwner();

public static void Destroy()
{
    if (!IsOwner()) throw new Exception("No authorization.");
    ContractManagement.Destroy();
}
```

The Destroy method takes no arguments. When it is invoked, the contract and its storage, if any, are deleted. Then the contract is no longer available.



