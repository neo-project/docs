# 鉴权合约示例教程

本教程是基于 Visual Studio 2017 中创建的示例，请保证 Visual Studio 升级到2017版本。另外本教程是基于智能合约2.0的演示，请从github中下载最新的的的源码。

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

> 生成脚本：52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566
>

## 创建钱包

​                                     ![创建钱包](~/images/w1.jpeg) 

## 创建合约地址

![创建合约地址](~/images/w2.jpeg)

  				     ![创建合约地址](~/images/w3.jpeg)

## 转账到合约地址

![转账到合约地址](~/images/w4.jpeg)

## 转出合约金额

![转出合约金额](~/images/w5.jpeg)