# 在 ubuntu 上如何用 C# 编写智能合约

   1. 创建library项目，引入智能合约类库,添加自己的代码。
   2. 编译neo-compiler/neoa编译生成编译器。
   3. 执行命令运行neoa转换获得avm文件。

## 1. 新建合约项目

### dotnet命令行创建libaray项目

    mkdir NeoContractDemo
    cd ./NeoContractDemo/
    dotnet new library
    rm ./Class1.cs
    vim NeoContractDemo.cs

    键入下面代码后ESC+wq!保存退出

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class NeoContractDemo: SmartContract
{
    public static bool Main()
    {
        return true;
    }
}
```

![](../../assets/create_neo_contract.png)

### 添加智能合约类库引用

    dotnet add package Neo.SmartContract.Framework --version 2.5.4

![](../../assets/neo_addpackage.png)

### 编译智能合约项目

    dotnet publish -o ../testlib

![](../../assets/build_neo_contract_project.png)

## 2. 编译neo-compiler

    cd ..
    git clone https://github.com/neo-project/neo-compiler.git
    cd  ./neo-compiler/neon
    dotnet publish -o ../../testlib

![](../../assets/build_neo_neoa.png)

## 3. 生成.avm文件

    cd ../../testlib
    dotnet neon.dll NeoContractDemo.dll
    mkdir ../output
    cp NeoContractDemo.avm ../output/NeoContractDemo.avm

![](../../assets/neo_contract_build_avm.png)


完整脚本参考：
[https://raw.githubusercontent.com/hunjixin/NeoContractBuildScriptOnUbuntu/master/SmartContract.sh]
