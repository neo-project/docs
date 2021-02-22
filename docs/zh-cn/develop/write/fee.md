# 智能合约收费机制

在 Neo 3 中，手续费分为 系统手续费 和 网络手续费

其中，智能合约执行，包括自身脚本的执行和调用其它合约的脚本，所需的费用为系统手续费。

承载智能合约部署、调用的交易以及执行验证（Verify）方法所需的费用为网络手续费。

通常来讲调用一个智能合约的手续费会同时包括系统手续费和网络手续费。

系统手续费（System Fee）包括以下几项：

- 操作码执行（OpCode）费用

- 系统调用（SysCall）费用

- 原生合约 CPU 使用费用

- 存储区使用费用

网络手续费（Network Fee）包括以下几项：

- 网络字节费
- 验证脚本执行所需的费用

## 存储区使用费用

按写入字节收费，单价为 0.001 GAS / byte

最终价格：

- 根据写入的 key 判断初次写入还是修改数据

- 首次写入存储区，原价，（key.Length + value.Length）× 单价

- 非首次写入存储区，且新数据大小 ≤ 旧数据大小：不收取 key 的费用，value 部分首字节正常计费，剩余字节 2.5 折 计费

- 非首次写入存储区，且新数据大小 > 旧数据大小：不收取 key 的费用，value 部分旧数据大小按照上一条计费，新增数据的大小按照原价计费

- 删除，不收费

示例：

写入 key = `key`, value= `hello world`，共 14 字节，收费 **0.014** GAS

修改 value 为 `hello neo3` 共 10 字节，收费 ((10-1)/4 + 1)×0.001 = **0.003** GAS

修改 value 为 `hello neo3.0` 共 12 字节，收费 0.003 + (12-10)×0.001 = **0.005** GAS

修改 value 为 `hello neo3.0 preview5` 共 21 字节，收费 0.005 + (21-12)×0.001 = **0.014** GAS

删除  value，收费 **0** GAS

## 其它费用细节请参考：

[操作码执行费用](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.OpCodePrices.cs)

[系统调用费用 - Contract](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[系统调用费用 - Crypto](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Crypto.cs)

[系统调用费用 - Contract](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Contract.cs)

[系统调用费用 - Iterator](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Iterator.cs)

[系统调用费用 - Runtime](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Runtime.cs)

[系统调用费用 - Storage](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

[原生合约 CPU 使用费用](https://github.com/neo-project/neo/tree/master/src/neo/SmartContract/Native)

[存储区使用费用](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/ApplicationEngine.Storage.cs)

[网络手续费收费规则](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/Native/PolicyContract.cs)

需要注意的是，在 Neo3 中手续费是动态变化的，上述链接列举的是基础费用。委员会可以决定在基础费用上乘上一个倍率变为最终费用。