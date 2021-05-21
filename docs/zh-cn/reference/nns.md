# NNS API 参考

NNS (Neo Name Service) 是一个基于 Neo 区块链的分布式、开源和可扩展的域名系统。它可将人类可读的域名名称映射为多种复杂的数据类型，包括IP地址、域名别名、文本内容等。

## 域名处理

NNS使用固定长度为160位的加密哈希值代替可读的域名字符串。具体操作为，对于用户注册的域名字符串，执行 ripemd160 哈希算法计算。

```
ByteString tokenKey = CryptoLib.ripemd160(name);
```

## 委员会职责

### 根域名注册

NNS根域名由NEO委员会注册，注册时需验证委员会的多方签名。用户注册域名时，需保证相应的根域名已经存在，否则，将抛出异常。

```
void AddRoot(string root)
```

### 费用设置

用户注册域名以及为域名续费时需花费一定的手续费，默认为10 GAS。该费用由NEO委员会设置，费用应是不大于10000 GAS的值。设置时需提供委员会的多方签名进行验签操作。

```
void SetPrice(long price)
```

### 合约更新

NNS合约支持更新操作，更新时需要提供委员会的多方签名进行验签操作。

```
void Update(ByteString nef, string manifest)
```

## 域名注册

当前，NNS支持二级域名的注册。注册时，需要验证注册者，即域名所有者的签名。域名成功注册时，默认的有效期是1年。注册域名需要一定的手续费，当前为10 GAS。

若待注册的域名已存在，需验证是否过期。若已过期，则注册失败；否则，更改该域名的所有者账户信息。若待注册域名不存在时，除修改域名所有者的账户信息外，同时更新系统的域名总量值（TotalSupply）。

```
bool Register(string name, UInt160 owner)
```

## 续费

NNS支持为二级域名执行续费操作，延长该域名及其子域名的有效期，任何人都可以为自己关注的域名进行续费操作。续费需要一定的手续费，当前为10 GAS。一旦续费成功，则相应域名的有效期将延长一年。

```
ulong Renew(string name)
```

## 管理员设置

域名所有者可以为域名设置管理员，授权其对域名执行一系列操作，包括设置或删除域名类型。NNS支持二级域名的管理员设置，需要同时提供管理员和域名所有者的签名进行验签。

```
void SetAdmin(string name, UInt160 admin)
```

## 类型设置

域名所有者或者管理员可以为域名设置相应的数据类型，当前支持`A (IPv4)`, `CNAME (别名)`, `TXT (文本类型)` 和 `AAAA (IPv6)`四种类型。待设置的域名包括但不限于二级域名，需要提供相应二级域名的所有者或管理员签名进行验签操作。

```
void SetRecord(string name, RecordType type, string data)
```

## 域名解析

用户可输入域名以及待解析的数据类型，解析出相应的域名数据。NNS会对输入的域名进行递归解析处理，且递归次数不超过3次。例如， 用户调用`SetRecord("test.neo", RecordType.CNAME, "test2.neo")`将域名`test.neo`设置为`test2.neo`的别名。同时调用`SetRecord("tes2.neo", RecordType.A, "127.0.0.1")`为域名`test2.neo`设置IPv4类型的数据`127.0.0.1`。 此时若用户调用解析函数`Resolve("test.neo", RecordType.A)`，则经过递归解析可获得IP `127.0.0.1`。

```
string Resolve(string name, RecordType type)
```

## 域名所有权转移

NNS可以执行所有权转移操作。所有权转移需要验证域名原所有者（发送者）签名，同时更新发送者与接收者账户状态。

```
bool Transfer(UInt160 to, ByteString tokenId, object data)
```

## 过期域名检测

NNS会在执行相应操作时，检查系统中域名的过期时间。对于已过期的域名只支持重新注册`Register`，进行其他操作如所有权转移，域名信息查询，续费，设置管理员，类型数据相关操作（设置、获取、删除）等均会抛出异常。