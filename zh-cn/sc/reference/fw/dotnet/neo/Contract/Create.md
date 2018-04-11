# Contract.Create 方法 (byte[], byte[], byte, bool, string, string, string, string, string)

在智能合约中调用此方法可以发布一个新的智能合约。

该方法是 PublishTransaction 在 2.0 版本的替代者。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract(byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string version, string author, string email, string description)
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
    public static void Main()
    {
        //这里填写合约脚本
        byte[] script = new byte[] { 116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 0, 148, 140, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 108, 118, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 116, 108, 118, 140, 107, 148, 109, 108, 117, 102 }; 
      
        byte[] parameter_list = { 2, 2 };
        byte return_type = 2;
        bool need_storage = false;
        string name = "加法合约示例";
        string version = "1";
        string author = "chris";
        string email = "chris@abc.com";
        string description = "这是一个加法合约，传入两个整型，合约对两个整型进行相加，返回一个整型";
      
        Blockchain.CreateContract(script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[返回上级](../Contract.md)