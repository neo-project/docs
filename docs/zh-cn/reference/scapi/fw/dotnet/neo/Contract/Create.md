# Contract.Create 方法 (byte[], string)

在智能合约中调用此方法可以发布一个新的智能合约。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern Contract Create(byte[] script, string manifest)
```

参数：

- script：合约代码，字节数组；
- manifest：定义合约特性与权限，Json字符串。

返回值：发布的智能合约，[Contract](../Contract.md) 类型。

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        //这里填写合约脚本
        byte[] script = new byte[] {0x41, 0xeb, 0x43, 0xf4, 0xf4};
        string manifest = "{\"groups\":[],\"features\":{\"storage\":true,\"payable\":false},\"abi\":{\"hash\":\"0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b\",\"entryPoint\":{\"name\":\"Main\",\"parameters\":[{\"name\":\"operation\",\"type\":\"String\"},{\"name\":\"args\",\"type\":\"Array\"}],\"returnType\":\"Any\"},\"methods\":[{\"name\":\"getSysFeeAmount\",\"parameters\":[{\"name\":\"index\",\"type\":\"Integer\"}],\"returnType\":\"Integer\"},{\"name\":\"name\",\"parameters\":[],\"returnType\":\"String\"},{\"name\":\"symbol\",\"parameters\":[],\"returnType\":\"String\"},{\"name\":\"decimals\",\"parameters\":[],\"returnType\":\"Integer\"},{\"name\":\"totalSupply\",\"parameters\":[],\"returnType\":\"Integer\"},{\"name\":\"balanceOf\",\"parameters\":[{\"name\":\"account\",\"type\":\"Hash160\"}],\"returnType\":\"Integer\"},{\"name\":\"transfer\",\"parameters\":[{\"name\":\"from\",\"type\":\"Hash160\"},{\"name\":\"to\",\"type\":\"Hash160\"},{\"name\":\"amount\",\"type\":\"Integer\"}],\"returnType\":\"Boolean\"},{\"name\":\"onPersist\",\"parameters\":[],\"returnType\":\"Boolean\"},{\"name\":\"supportedStandards\",\"parameters\":[],\"returnType\":\"Array\"}],\"events\":[{\"name\":\"Transfer\",\"parameters\":[{\"name\":\"from\",\"type\":\"Hash160\"},{\"name\":\"to\",\"type\":\"Hash160\"},{\"name\":\"amount\",\"type\":\"Integer\"}],\"returnType\":\"Signature\"}]},\"permissions\":[{\"contract\":\"*\",\"methods\":\"*\"}],\"trusts\":[],\"safeMethods\":[\"getSysFeeAmount\",\"name\",\"symbol\",\"decimals\",\"totalSupply\",\"balanceOf\",\"supportedStandards\"],\"extra\":null}";
      
        Contract contract = Blockchain.Create(script, manifest);
    }
}
```



[返回上级](../Contract.md)