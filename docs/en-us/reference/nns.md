# NNS API Reference

The Neo Name Service (NNS) is a distributed, open, and extensible naming system based on the Neo blockchain. It maps human-readable names to various complex data types, such as IP address, domain aliase, content hash, and so forth. The service is implemented as a new native contract, NameService, which is of many features of native contracts and NFT assets.

This document introduces APIs of the NNS contract. For details of each method, refer to  [NameService Class](scapi/fw/dotnet/neo/NameService.md).

## Name processing

The NNS works with fixed length 160-bit cryptographic hashes in place of human-readable names. The workflow is, NNS first derives the UTF8-encoded byte array from a user-registered domain string, and then hash it with Sha256 and RIPEMD160 respectively.

```c#
byte[] hash = GetKey(Utility.StrictUTF8.GetBytes(name));
```

## Committee duties 
### Register root domain name
The NNS root domain name is registered by the Neo committee, and the multi-party signature of the committee is verified during registration. Before your can register a domain name, you must ensure that the corresponding first-level domain name already exists, otherwise, an exception is thrown.

```c#
void AddRoot(string root)
```
### Set fee

The domain name registering and renewing requires  a certain fee, which defaults to 10 GAS. The fee is set by the Neo committee and the upper limit is 10,000 GAS. The multi-party signature of the committee should be provided for the signature verification.

```c#
void SetPrice(long price)
```
## Domain registry
NNS supports the registration of second-level domain names. When registering, the signature of the registrar (i.e. the domain name owner) needs to be verified. The default validity period of the registered domain is 1 year. Registering a domain name requires a certain fee, which is currently 10 GAS. The second-level domain name of the NNS system is implemented as `NFT Token`, which means you can operate the second-level domain name you own like operating NFT assets. Every time the system registers a second-level domain name, the account information of the domain name owner needs to be modified synchronously, and the system's total domain name value (TotalSupply) must be updated at the same time.

```c#
bool Register(string name, UInt160 owner)
```

## Domain renewal
NNS supports the renewal of second-level domain names. Anyone can renew the desired domain name to extend the validity period of the domain name and its sub-domains. Renewing a domain name requires a certain fee, which is currently 10 GAS. After the renewal, the validity period of the domain name is extended for one year.

```c#
uint Renew(string name)

```
## Administration
The domain name owners can specify an administrator, who is authorized to perform a series operations on the domain name, such as renewal, setting types, and so on. NNS supports the administrator setting of the second-level domain name. The signatures of the administrator and the domain name owner must be provided for verification.

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
Since the second-level domain name is implemented as [NFT](https://github.com/neo-project/proposals/pull/130) Token, it can transfer ownership like other NFT Tokens. The ownership transfer requires verification of the original domain name owner's  signature, while updating the account status of the sender and receiver.

```c#
bool Transfer(UInt160 to, byte[] tokenId)
```
## Handling of expired names
While persisting each block, NNS checks the expiration time key of the domain name in the system and deletes data for expired domain names, including deleting domain name data, domain name type data, updating domain name owner’s account, and updating the total number of system domain names.