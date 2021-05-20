# NNS API 参考

NNS (Neo Name Service) 是一个基于 Neo 区块链的分布式、开源和可扩展的域名系统。它可将人类可读的域名名称映射为多种复杂的数据类型，包括IP地址、域名别名、文本内容等。它是Neo系统中内置的原生合约，实现为NFT资产类型，同时具有原生合约和NFT资产的多种特性。

## 域名处理

NNS使用固定长度为160位的加密哈希值代替可读的域名字符串。具体操作为，对于用户注册的域名字符串，首先计算获得UTF8编码下的字节数组，之后分别执行Sha256哈希以及RIPEMD160哈希计算。

```c#
byte[] hash = GetKey(Utility.StrictUTF8.GetBytes(name));
```

## 委员会职责
### 根域名注册
NNS根域名由NEO委员会注册，注册时需验证委员会的多方签名。用户注册域名时，需保证相应的一级域名已经存在，否则，将抛出异常。

```c#
void AddRoot(string root)
```
### 费用设置

用户注册域名以及为域名续费时需花费一定的手续费，默认为10 GAS。该费用由NEO委员会设置，费用应是不大于10000 GAS的值。设置时需提供委员会的多方签名进行验签操作。

```c#
void SetPrice(long price)
```
## 域名注册
当前，NNS支持二级域名的注册。注册时，需要验证注册者，即域名所有者的签名。域名成功注册时，默认的有效期是1年。注册域名需要一定的手续费，当前为10 GAS。NNS系统的二级域名实现为`NFT Token`，即用户可以像操作NFT资产一样操作所拥有的二级域名。系统每注册一个二级域名，需要同步修改域名所有者的账户信息，同时更新系统的域名总量值（TotalSupply）。

```c#
bool Register(string name, UInt160 owner)
```

## 续费
NNS支持为二级域名执行续费操作，延长该域名及其子域名的有效期，任何人都可以为自己关注的域名进行续费操作。续费需要一定的手续费，当前为10 GAS。一旦续费成功，则相应域名的有效期将延长一年。

```c#
uint Renew(string name)

```
## 管理员设置
域名所有者可以为域名设置管理员，授权其对域名执行一系列操作，如续费、设置类型等。NNS支持二级域名的管理员设置，需要同时提供管理员和域名所有者的签名进行验签。

```c#
void SetAdmin(string name, UInt160 admin)
```

## 类型设置
域名所有者或者管理员可以为域名设置相应的数据类型，当前支持`A (IPv4)`, `CNAME (别名)`, `TXT (文本类型)` 和 `AAAA (IPv6)`四种类型。待设置的域名包括但不限于二级域名，需要提供相应二级域名的所有者或管理员签名进行验签操作。

```c#
void SetRecord(string name, RecordType type, string data)
```
## 域名解析
用户可输入域名以及待解析的数据类型，解析出相应的域名数据。NNS会对输入的域名进行递归解析处理，且递归次数不超过3次。例如，
用户调用`SetRecord("test.neo", RecordType.CNAME, "test2.neo")`将域名`test.neo`设置为`test2.neo`的别名。同时调用`SetRecord("tes2.neo", RecordType.A, "127.0.0.1")`为域名`test2.neo`设置IPv4类型的数据`127.0.0.1`。
此时若用户调用解析函数`Resolve("test.neo", RecordType.A)`，则经过递归解析可获得IP `127.0.0.1`。

```c#
string Resolve(string name, RecordType type)
```
## 域名所有权转移
NNS将二级域名实现为[NFT](https://github.com/neo-project/proposals/pull/130) Token，因此具有NFT的所有特性，可以像其他NFT Token一样执行所有权转移操作。所有权转移需要验证域名原所有者（发送者）签名，同时更新发送者与接收者账户状态。

```c#
bool Transfer(UInt160 to, byte[] tokenId)
```
## 过期域名处理
NNS会在持久化每个区块时，检查系统中域名的过期时间键。对于已过期的域名，进行删除处理，包括删除域名数据、域名的类型数据、更新域名所有者的账户以及更新系统域名总量信息。