# 鉴权合约示例教程



本教程是基于 Visual Studio 2017 中创建的示例，请保证 Visual Studio 升级到2017版本。另外本教程是基于智能合约2.0的演示，请从github中下载最新的的的源码进行编译。

## 编译合约脚本



```c#
using AntShares.SmartContract.Framework;
using AntShares.SmartContract.Framework.Services.AntShares;
using AntShares.SmartContract.Framework.Services.System;
namespace AntShares.SmartContract
{
    public class Test : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            return true;
        }
    }
}
```

若不清楚如何编写生成智能合约脚本，请参考[如何用c#编写智能合约](../getting-started.md)

合约脚本如下所示：

> [!Note]
> 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566
>



## 创建钱包



按照如下图所示的教程创建一个新的钱包：

![创建钱包](~/images/w1.jpeg)



## 创建合约地址



创建完自己的钱包后，点击鼠标右键，运用你生成的合约脚本创建合约地址：

![创建合约地址](~/images/w2.jpeg)



绑定合约地址到自己的账户，并填入相应的参数：

![创建合约地址](~/images/w3.jpeg)



## 转入资产到合约地址



转一定数量的资产到你的合约账户：

![转账到合约地址](~/images/w4.jpeg)



## 转出合约资产



从你的智能合约账户中转出资产：

![转出合约金额](~/images/w5.jpeg)






> [!Note]
> 可以看到资产的余额是包含了标准账户和合约地址中资产的加和，也就是说你的账号绑定的所有合约地址的资产都会加入到你的资产余额中，但是否能使用该合约地址中的资产是该根据智能合约的运行结果。