# Update 方法 (byte[], string)

迁移/更新智能合约，该方法与 Contract.Create 类似，只不过它是在 Contract.Create 基础上添加了对智能合约私有化存储区的迁移操作，该方法在执行时会将 当前合约的持久化存储区中的所有内容迁移到新创建的合约中。

如果在智能合约中没有涉及到持久化存储区的操作，则 Contract.Update 方法与 Contract.Create 方法相同。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Update(byte[] script, string manifest)
```

参数：

- script：合约代码，字节数组；
- manifest：定义合约特性与权限，Json字符串。

返回值：发布的智能合约，[Contract](../Contract.md) 类型。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main(byte[] signature)
    {
        //这里填写合约脚本
        byte[] script = new byte[] {87, 0, 2, 12, 1, 26, 64};
        string manifest = "{\"groups\":[],\"features\":{\"storage\":false,\"payable\":false},\"abi\":{\"hash\":\"0x51d24ad1f61af44c019cffb41534821b644b602d\",\"entryPoint\":{\"name\":\"main\",\"parameters\":[{\"name\":\"method\",\"type\":\"String\"},{\"name\":\"args\",\"type\":\"Array\"}],\"returnType\":\"ByteArray\"},\"methods\":[],\"events\":[]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"safeMethods\":[],\"extra\":null}";
      
        Blockchain.Update(script, manifest);
    }
}
```



[返回上级](../Contract.md)
