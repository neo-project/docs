# NEF 和 Manifest 文件

Neo N3 使用 NEF（NEO Executable Format） 和 Manifest 文件来分别代替和扩充 Neo Legacy 的 AVM 和 ABI 文件。

当一个合约编译成功时，编译器会同时生成 NEF 文件和 Manifest 文件。当你部署合约或升级合约时，也需要使用这两个文件。

## NEF

NEF 文件包括以下字段：


| 字段     | 类型          | 说明                                                  |
| -------- | ------------- | ----------------------------------------------------- |
| Magic    | uint32        | 区块链的 Magic 值                                     |
| Compiler | byte[64]      | 编译器名称和版本号                                    |
| Reserve  | byte[2]       | 为将来预留的字段                                      |
| Tokens   | MethodToken[] | 编译器对静态合约调用的简化操作，开发者不用在意        |
| Reserve  | byte[2]       | 为将来预留的字段                                      |
| Script   | Byte[]        | 合约脚本                                              |
| Checksum | uint32        | 校验码，前面所有字段连一起，进行两次Sha246后取前4字节 |

## Manifest

在部署智能合约前，需要在 Manifest 文件中声明合约使用的功能和权限。合约运行时不能做出任何超出列表范围的行为。

Manifest 文件包括以下字段：

| 字段               | 类型                                            | 说明                                                         |
| ------------------ | ----------------------------------------------- | ------------------------------------------------------------ |
| Name               | string                                          | 合约名称                                                     |
| Groups             | ContractGroup[]<br>由公钥和对合约Hash的签名组成 | Groups代表一组相互信任的合约。在一个组内的合约之间是互相信任的，可以相互调用，用户界面不会给出任何警告。<br>一个组由一个公钥来标识，并且必须有对合约哈希的签名，以证明该合约确实包含在该组中。<br>例如一个DeFi项目的一系列互相调用的合约。 |
| SupportedStandards | string[]                                        | 支持的NEP标准，相当于 Neo Legacy 中的 NEP-10                    |
| Abi                | ContractAbi                                     | NEP-14 (NeoContract ABI)<br>描述智能合约的方法（名称、参数、返回值、偏移量、是否安全）、事件（名称、参数） |
| Permissions        | ContractPermission[]<br>由合约和方法名组成      | 该字段是一个包含一个权限对象的数组，它描述了这个合约将调用哪些其它合约的哪些方法。<br>其中合约可以是 ScriptHash，可以是Group，或通配符 *<br>方法是方法名或通配符 *<br>如果一个合约在运行时调用了一个没有在 manifest 中声明的合约或方法，则调用将失败。 |
| Trusts             | WildcardContainer\<UInt160>                     | Trusts 字段是一个数组，包含一组合约Hash或组公钥。它也可以用通配符*来分配。<br>如果一个合约是可信的，那么当合约调用时，用户界面将不会给出任何警告。 |
| Extra              | object                                          | 其它用户自定义的数据，如开发者、邮箱、网址、合约简介等       |

