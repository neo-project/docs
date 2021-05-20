# NNS API Reference

The Neo Name Service (NNS) is a distributed, open, and extensible naming system based on the Neo blockchain. It maps human-readable names to various complex data types, such as IP address, domain aliase, content hash, and so forth. 

## Name processing

The NNS works with fixed length 160-bit cryptographic hashes in place of human-readable names. For user-registered domain strings, NNS hashes them with the ripemd160 algorithms.

```c#
ByteString tokenKey = CryptoLib.ripemd160(name);
```

## Committee duties 
### Register root domain name
The NNS root domain name is registered by the Neo committee, and the multi-party signature of the committee is verified during registration. Before your can register a domain name, you must ensure that the corresponding root domain name already exists, otherwise, an exception is thrown.

```c#
void AddRoot(string root)
```
### Set fee

The domain name registering and renewing requires  a certain fee, which defaults to 10 GAS. The fee is set by the Neo committee and the upper limit is 10,000 GAS. The multi-party signature of the committee should be provided for the signature verification.

```c#
void SetPrice(long price)
```
### Update contract

You can update the NNS contract by providing committee's multi-party signatures for signature verification.

```
void Update(ByteString nef, string manifest)
```

## Domain registry

NNS supports the registration of second-level domain names. When registering, the signature of the registrar (i.e. the domain name owner) needs to be verified. The default validity period of the registered domain is 1 year. Registering a domain name requires a certain fee, which is currently 10 GAS.

If the domain name to be registered already exists, you need to verify if it has expired. If yes, the registration will fail; otherwise, change the account information of the domain name owner. If the domain name to be registered does not exist, modify the account information of the domain name owner, and update TotalSupply of the domain name in the system at the same time

```c#
bool Register(string name, UInt160 owner)
```

## Domain renewal
NNS supports the renewal of second-level domain names. Anyone can renew the desired domain name to extend the validity period of the domain name and its sub-domains. Renewing a domain name requires a certain fee, which is currently 10 GAS. After the renewal, the validity period of the domain name is extended for one year.

```c#
ulong Renew(string name)
```
## Administration
The domain name owners can specify an administrator, who is authorized to perform a series operations on the domain name, including  setting and removing domain types, and so on. NNS supports the administrator setting of the second-level domain name. The signatures of the administrator and the domain name owner must be provided for verification.

```c#
void SetAdmin(string name, UInt160 admin)
```

### Type setting
The domain name owner or administrator can set the data type for the domain name. Currently the four types `A (IPv4)`, `CNAME (alias)`, `TXT (text type)`, and `AAAA (IPv6)` are supported. The domain name to be set is not limited to the second-level domain name. The signature of the second-level domain name's owner or administrator needs to be provided for verification.

```c#
void SetRecord(string name, RecordType type, string data)
```
### Name resolving
You can input the domain name and the data type to resolve the corresponding domain name data. NNS will recursively resolve the entered domain name no more than three times.

For example, invoke `SetRecord("test.neo", RecordType.CNAME, "test2.neo")` and set the domain name`test.neo` to the alias of `test2.neo`. Then invoke`SetRecord("tes2.neo", RecordType.A, "127.0.0.1")` and set an IPv4 type data 127.0.0.1 to `test2.neo`. If you invoke the function  `Resolve("test.neo", RecordType.A)`，the IP `127.0.0.1` can be obtained after recursive resolution.

```c#
string Resolve(string name, RecordType type)
```
## Name transfer
NNS supports ownership transfer, which requires verification of the original domain name owner's  signature while updating the account status of the sender and receiver.

```c#
bool Transfer(UInt160 to, byte[] tokenId)
```
## Handling of expired names
NNS will check the domain name expiration time in the system when doing certain operations. For expired domain names, only re-registration (`Register`) is supported. Other operations such as ownership transfer, domain information inquiry, renewal, setting administrator, type data related operations (set, get, delete), etc. will throw an exception.