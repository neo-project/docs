# 签名和验证

CGAS 执行的过程大体上可以分两步，第一步是执行交易中的验证脚本，也就是 Verification 触发器，如果验证失败了，交易将不会确认。这步由所有收到该交易的节点执行，执行时间在生成区块之前。

第二步是执行智能合约，也就是 Application 触发器。这步由所有同步区块的节点，在同步区块后执行。

第一步相关的脚本叫 Witness，其中包含验证脚本（verification）和调用脚本（invocation）。NeoVM 执行的时候，验证脚本就是智能合约执行的代码，调用脚本包含验证脚本所需的参数，一般是签名。

在 Witness 中可以包含多组调用和验证脚本。具体可参考 [CGAS GitHub](https://github.com/neo-ngd/CGAS-Contract)。

下面以 refund 第一步的交易为示例进行分析。

refund 第一步时的交易结构:

> [!Note]
>
> - Type: InvocationTransaction
>
> - Input: 来自 CGAS 合约地址
>
> - Output: 转到 CGAS 合约地址 (与 input 相同)
>
> - Script: 调用 refund 方法，设置参数为退回者的 Script Hash
>
> - Scripts: 需要两个 witness: 1、CGAS 合约的 witness; 2、用户的 witness（附加见证人）

```c#
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x306daa4ab2b2ef73ff4fd8f9121fc926f5e21653080602b6841ad3f17f80777c",
        "size": 7205,
        "type": "InvocationTransaction",
        "version": 0,
        "attributes": [
            {
                "usage": "Script",
                "data": "e8e3ce08268d16d867101feaf8c0ea130a923aba"
            }
        ],
        "vin": [
            {
                "txid": "0x48bd784d0ed6000cba64d0e303117e4c10081e3268afcf3b07e8b353a7594772",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "5",
                "address": "AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "5",
                "address": "AScKxyXmNtEnTLTvbVhNQyTJmgytxhwSnM"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "520131",
                "verification": ""
            },
            {
                "invocation": "404c53a9ca937470df9dcbbb71cf00e2b4d75761e4667ccfd820e40829887c4444c7911ed509e564b2bac30e41c92c43f7df2dd2a25ea1c8e2bc10aec3d3208251",
                "verification": "21037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630dac"
            }
        ],
        "script": "14e8e3ce08268d16d867101feaf8c0ea130a923aba51c106726566756e646776db3192722022eb7841038246dc8fa636dcf274f1",
        "gas": "0",
        "blockhash": "0xd04d56259a6c92e290ab009e2062fbd078c3c371036d74dd745b379a4d55a899",
        "confirmations": 14,
        "blocktime": 1536907058
    }
}
```

## CheckWitness() 和附加见证人

注意到这段交易中是有 attributes 的，因为在智能合约代码中有 CheckWitness()，如果验证的是当前的合约的权限，并不需要在交易属性中添加 script，只限于验证的签名不是合约本身，比如 refund 第一步，用户是通过 from 参数传进来的，而 from 的 script hash 不等于 CGAS script hash，这时需要在交易属性中添加 from 的 script hash 作为附加见证人。

另外一点，verification 部分是可以省略的（如上面的示例中的第一个验证脚本），如果省略的话节点会自动根据链上的 script hash 进行补充。这就需要知道总共有哪些 script hash，并且知道 witness 中的各项的排列顺序。目前 witness 中的各项的排列顺序为：按照 script hash 从小到大排序。

这样，系统知道了总共的 script hash（当前合约的 script hash 加上交易属性中列出来的 script hash）又知道所有调用和验证脚本，以及这些调用和验证脚本和 Script hash 的匹配顺序，就可以执行代码了。

## OpCode 脚本

讲完了 CheckWitness() 和交易属性，那么来看下第一组调用脚本，上面的示例是 520131，这是什么意思呢。首先将 52 放入调用栈，然后放入 01，再放入 31。

取数据的时候按照 [OpCode](https://github.com/neo-project/neo-vm/blob/master/src/neo-vm/OpCode.cs) 中的注释来理解，52 的意思是 Push 2。

16 进制的 01 的意思是后面这是一个数组，长度为 1（0x01 对应 10 进制的 1），之后 1 字节的数据是数据本身，并非指令。

16 进制的 31 对应 ASCII 码中的字母 ‘1’

所以第一个参数是数字 2，第二个参数是字符串 “1”。

通过这个顺序将两个参数放入调用栈，读取的时候按照栈的顺序，先取出来第一个参数是字符串 “1”，再取出来第二个参数是数字 2。

**示例1**

有了上面的例子，下面来看下第二组的调用脚本：

```
404c53a9ca937470df9dcbbb71cf00e2b4d75761e4667ccfd820e40829887c4444c7911ed509e564b2bac30e41c92c43f7df2dd2a25ea1c8e2bc10aec3d3208251
```

首先是 16 进制的 40，对应 10 进制的 64，后面 64 位是个字节数组（其实是签名）。

**示例2**

再看一下第二组的验证脚本：

```
21037ebe29fff57d8c177870e9d9eecb046b27fc290ccbac88a0e3da8bac5daa630dac
```

首先是 16 进制的 21，对应 10 进制的 33，后面 33 位是个字节数组（其实是公钥），最后一个 0xac 意思是 CHECKSIG，意思是验证签名，就这么简单。

## 阅读下节

下节我们将介绍 [如何调用CGAS合约](7_invocation.md)。

如果要返回上节了解铸币和退款函数，点击[这里](5_minttokens_and_refund.md)。

