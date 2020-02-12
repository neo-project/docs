# NEO 命名空间

NEO命名空间提供了原生合约部署以及数字签名验证的API。

**Native API**：
| API                           | 说明                         |
| -- | --|
|Neo.Native.Deploy|部署并初始化所有原生合约|

**Crypto API**：

| API                           | 说明                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | 根据公钥，验证当前脚本容器的签名                   |
| Neo.Crypto.ECDsaCheckMultiSig       | 根据公钥，验证当前脚本容器的多个签名                    |

参考：以上 API 的源码位于 NEO 项目中的 [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) 和 [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs) 文件。
