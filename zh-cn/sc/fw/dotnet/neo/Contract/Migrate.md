# Contract.Migrate 方法 (byte[], byte[], byte, bool, string, string, string, string, string)

迁移/更新智能合约，该方法与 Contract.Create 类似，只不过它是在 Contract.Create 基础上添加了对智能合约私有化存储区的迁移操作，该方法在执行时会将 **当前** 合约的持久化存储区中的所有内容迁移到新创建的合约中。

如果在智能合约中没有涉及到持久化存储区的操作，则 Contract.Migrate 方法与 Contract.Create 方法相同。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract Migrate(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
```

参数：

script：合约代码，字节数组。

parameter_list：参数列表，字节数组，可参考 [智能合约参数和返回值](../../../../tutorial/Parameter.md)。

return_type：返回值，字节，可参考 [智能合约参数和返回值](../../../../tutorial/Parameter.md)。

need_storage：是否需要持久化存储区，布尔值。

name：智能合约的名称，字符串类型。

version：版本号，字符串类型。

author：作者姓名，字符串类型。

email：作者邮箱，字符串类型。。

description：智能合约的描述，字符串类型。

返回值：发布的智能合约，[Contract](../Contract.md) 类型。

## 示例

```c#
public class Contract1 : FunctionCode
{
    public static void Main(byte[] signature)
    {
        if(VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature))
          {
                    //这里填写合约脚本
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = true;
        string name = "加法合约示例";
        string version = "1";
        string author = "chris";
        string email = "chris@neo.org";
        string description = "在这里写智能合约描述";
      
        Contract.Migrate(script, parameter_list, return_type, need_storage, name, version, author, email, description);
          }

    }
}
```



[返回上级](../Contract.md)