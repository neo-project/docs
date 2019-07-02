# neo.Core.TX.Transaction

本文将详细介绍 `neo.Core.TX.Transaction` 模块。

**描述：**

交易基本类

**用法**：

从 neo.Core.Transaction 导入交易

>  `class neo.Core.TX.Transaction.ContractTransaction(*args, **kwargs)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#ContractTransaction)

>  `class neo.Core.TX.Transaction.Transaction(inputs=[], outputs=[], attributes=[], scripts=[])` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction)

`Deserialize(reader)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.Deserialize)

反序列化完整的对象。

**参数**：**reader** (*neo.IO.BinaryReader*) –

`static DeserializeFrom(reader)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.DeserializeFrom)

反序列化完整的对象。

**参数**: **reader** (*neo.IO.BinaryReader*) –

**返回值**：

**返回类型**：[Transaction](https://neo-python.readthedocs.io/en/latest/neo/Core/TX/Transaction.html#neo.Core.TX.Transaction.Transaction)

`static DeserializeFromBufer (buffer, offset=0)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.DeserializeFromBufer)

从指定的缓冲区反序列化对象实例。

**参数**：

**buffer** (*bytes**,* *bytearray**,* *BytesIO*) – （可选）用于创建数据流的数据。

**offset** – 不使用

**返回值**：

**返回类型**：[Transaction](https://neo-python.readthedocs.io/en/latest/neo/Core/TX/Transaction.html#neo.Core.TX.Transaction.Transaction)

`DeserializeUnsigned(reader)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.DeserializeUnsigned)

反序列化对象。

**参数**：**reader** (*neo.IO.BinaryReader*) –

**抛出**： `Exception` – 如果交易类型错误。

`DeserializeUnsignedWithoutType`(*reader*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.DeserializeUnsignedWithoutType)

不读取交易类型数据的反序列化对象。

**参数**：**reader** (*neo.IO.BinaryReader*) –

`GetHashData`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.GetHashData)

获取用于散列的数据。

**返回值**：

**返回类型**：bytes

`GetMessage`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.GetMessage)

获取用于散列的数据。

**返回值**：

**返回类型**：bytes

`GetScriptHashesForVerifying`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.GetScriptHashesForVerifying)

获取用于验证交易的脚本散列。

**抛出**：`Exception` – 如果交易中没有有效资产。

**返回值**：UInt160 类型脚本散列。

**返回类型**：list

`GetTransactionResults`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.GetTransactionResults)

获取交易的执行结果。

**返回值**：如果交易没有引用 list: TransactionResult 对象。

**返回类型**：无

`Hash`

获取交易的散列值。

**返回值**：

**返回类型**：UInt256

`NetworkFee`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.NetworkFee)

获取网络手续费

**返回值**：

**返回类型**：Fixed8

`References`

获取所有引用

**返回值**：Key (UInt256): input PrevHash Value (TransactionOutput): object.

**返回类型**：dict

`ResetHashData`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.ResetHashData)

复位本地保存的散列数据

`ResetReferences`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.ResetReferences)

复位本地保存的引用

`Scripts`

获取脚本

**返回值**：

**返回类型**：list

`Serialize`(*writer*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.Serialize)

序列化对象

**参数**：**writer** (*neo.IO.BinaryWriter*) –

`SerializeUnsigned`(*writer*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.SerializeUnsigned)

序列化对象

**参数**：**writer** (*neo.IO.BinaryWriter*) –

`Size`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.Size)

获取对象的总大小（以字节为单位）。

**返回值**：大小

**返回类型**：int

`SystemFee`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.SystemFee)

获取系统手续费。

**返回值**：目前为 0。

**返回类型**：Fixed8

`ToArray`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.ToArray)

获取 self 的字节数据。

**返回值**：

**返回类型**：byte

`ToJson`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.ToJson)

将对象成员转换为可以解析为JSON的字典编码。

**返回值**：

**返回类型**：dict

`Verify`(*mempool*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.Verify)

验证交易。

**参数**：**mempool** –

**返回值**：验证通过返回 True，否则返回 False。

**返回类型**：bool

`getAllInputs`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#Transaction.getAllInputs)

获取输入

**返回值**：

**返回类型**：list

`withdraw_hold`*= None*

交易的 docstring

> `class neo.Core.TX.Transaction.TransactionInput(prevHash=None, prevIndex=None)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionInput)

TransactionInput 的 docstring

`Deserialize`(*reader*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionInput.Deserialize)

反序列化全对象

**参数**：**reader** (*neo.IO.BinaryReader*) –

`Serialize`(*writer*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionInput.Serialize)

序列化对象

**参数**：**writer** (*neo.IO.BinaryWriter*) –

`ToJson`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionInput.ToJson)

将对象成员转换为可以解析为JSON的字典编码。

**返回值**：

**返回类型**：dict

`ToString`() [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionInput.ToString)

获取对象的字符串表示形式。

**返回**：PrevHash:PrevIndexReturn type:str

> `class neo.Core.TX.Transaction.TransactionOutput (AssetId=None, Value=None, script_hash=None)` [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionOutput)

`Address`

获取交易的公共地址。

**返回值**：代表地址的 base58 编码字符串。

**返回类型**：str

`AddressBytes`

获取交易的公共地址。

**返回值**：base58 编码的字符串。

**返回类型**：bytes

`AssetId`*= None*docstring for TransactionOutput

`Deserialize`(*reader*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionOutput.Deserialize)

反序列化完整对象

**参数**：**reader** (*neo.IO.BinaryReader*) –

`Serialize`(*writer*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionOutput.Serialize)

序列化对象

**参数**：**writer** (*neo.IO.BinaryWriter*) –

`ToJson`(*index*) [[source\]](https://neo-python.readthedocs.io/en/latest/_modules/neo/Core/TX/Transaction.html#TransactionOutput.ToJson)

将对象成员转换为可以解析为JSON的字典编码。 :param index: 交易输出的索引 :type index: int

**返回值**：

**返回类型**：dict