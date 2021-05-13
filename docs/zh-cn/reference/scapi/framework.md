# Neo.SmartContract.Framework

## 类

| 名称            | 说明                                      |
| --------------- | ----------------------------------------- |
| ByteString      | 对 byte 数组进行了封装                    |
| ECPoint         | 表示曲线密码学（ECC）结构的（X，Y）坐标对 |
| ExecutionEngine | 表示用于执行脚本的虚拟机                  |
| List            | 类似 .net 中的 List                       |
| Map             | 类似 .net 中的 Dictionary                 |
| Nep11Token      | 数字资产的抽象类                          |
| Nep17Token      | NFT 资产的抽象类                          |
| UInt160         | UInt160                                   |
| UInt256         | UInt256                                   |


## 扩展方法

| 名称         | 说明                                                         |
| ------------ | ------------------------------------------------------------ |
| ToByteString | 1. 将字节转换为byte[]，将字节视为BigInteger（结尾为0x00）。<br/>2、将sbyte转换为byte[]。<br/>3、将字符串转换为byte[]。例子。"hello" -> [0x68656c6c6f]; "" -> []; "Neo" -> [0x4e656f]<br/>4. 将字节[]转换为字符串。例子。[0x68656c6c6f] -> "hello"; [] -> ""; [0x4e656f] -> "Neo"</>。 |
| Within       | 当且仅当 a<=x 并且 x<b，则返回真。 例：x=5 a=5 b=15 为真；x=15 a=5 b=15 为假 |
| Concat       | 连接两个字节数组                                             |
| Range        | 复制子数组，要求从指定位置开始，并具有指定的长度             |
| Take         | 从序列的开头返回指定数量的相邻元素                           |
| Last         | 从序列的结尾返回指定数量的相邻元素                           |
| Reverse      | 将元素的顺序颠倒过来                                         |
| Sqrt         | 计算平方根                                                   |

## 枚举

| 名称                  | 说明                   |
| --------------------- | ---------------------- |
| ContractParameterType | 底层类型，开发者可忽略 |
| OpCode                | 底层类型，开发者可忽略 |
| StackItemType         | 底层类型，开发者可忽略 |

