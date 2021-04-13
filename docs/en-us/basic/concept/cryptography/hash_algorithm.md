# Hash Algorithm

Hash function, or hash algorithm, is a method creating digital finger print from any kind of data. Hash function compresses message or data into a digested version to shrink the data into a fixed data size. This function disorganizes and remixes data, rebuilding a data fingerprint as a hash value. Hash value is always represented by a short string consisting of random letters and digits.

Two different hash functions are used widely in the Neo system: SHA256 and RIPEMD160. The former is used to generate a longer hash value (32 bytes) and the latter is used to generate a shorter hash value (20 bytes). Usually when a hash value of an object is generated, hash functions are used twice. For example, when a hash of a block or transaction is generated, SHA256 is calculated twice; when a contract address is generated, the SHA256 hash of the script is calculated, then the NSPEMD160 hash of the previous hash is calculated. 

In addition, the block will also use a hash structure called a Merkle Tree. It computes the hash of each transaction and combines one with the next and then hashes again, repeating this process until there is only one root hash (Merkle Root). 

### RIPEMD160 

RIPEMD is a cryptographic hash function published by Hans Dobbertin, Antoon Bosselaers Bart Prenee from COSIC research team, University of Leuven in 1996.

RIPEMD160 is a 160-bit improvement based on RIPEMD. This algorithm produces a 160-bit hash, which can be presented in hexadecimal format. One feature of this algorithm is avalanche effect, i.e. any slight changes can result in a totally different hash value.

Neo generates 160-bit hash of contract script with RIPEMD160.

Example:

| String value | Hash value                              |
| ----------- | ---------------------------------------- |
| hello world | 98c615784ccb5fe5936fbc0cbe9dfdb408d92f0f |

Scenarios：

To generate contract hash.

### SHA256 

SHA256 is a kind of SHA-2 algorithm. SHA-2 is a cryptographic hash function algorithm standard produced by NSA. It belongs to SHA family. It is a successor of SHA-1. SHA-2 has 6 different algorithm standards, including SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224 and SHA-512/256.

For any length of message, SHA256 will generate a 256-bit hash value (can be represented by a hexdecimal string)

Example:

| String value | Hash value                                                       |
| ----------- | ------------------------------------------------------------ |
| Hello World | a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e |

Scenarios:

- Compute contract hash.

- Signing & Signature validation.

- Base58Check encoding / decoding.

- db3、NEP6 wallet secret key storage, export & validation.

### Murmur3 

Murmur is kind of non-cryptographic hash algorithm and suits for general hash indexing. It is proposed by Austin Appleby in 2008. Later several derived versions are released. Compared with other popular hash functions, Murmur's random distribution performance is better for keys with high regularity.

Features：

   1. Low collision probability.
   
   2. Fast computing rate.

   3. Good peformance for large files.

Example:

| String | Hash value |
| ---|---|
| Hello World |ce837619 |

Scenarios：

- Bloom filter

- leveldb storage

### Scrypt

Scrypt is a kind of secure-cryptographic algorithm based on PBKDF2-HMAC-SHA-256 algorithm. It's developed by Colin Percival, a famous FreeBSD hacker, for his backup service Tarsnap. The original design was to reduce CPU load, minimize CPU reliance, and use CPU idle time for calculations. Therefore, scrypt not only takes a long time to calculate, but also consumes a lot of memory, making it difficult to calculate multiple digests in parallel. So it is more difficult to use the rainbow table for brute-force-attacks.

Neo mainly uses Scrypt algorithm to generate encrypted secret keys complying with NEP-2 standard. Parameters are defined as follows:

- N: CPU/RAM cost. Generally it is a power of 2. Default value is 16384.

- p: Parallelization parameter, a positive integer that ranges from 1 to 255. Bigger value represents a heavier reliance upon concurrent computation. Default value is 8.

- r: Block size，theoretically ranges from 1 to 255. Bigger value represents a heavier reliance upon RAM & bandwidth. Default value is 8.

Example:

| Data | Parameters  | Hash value  |
|---|---|---|
| Hello World | key:"I love code"<br>N:16384<br>p:8<br>r:8 | 17b94895fab004e035b3630a718b498f6<br>647458351f04b84b4a2c0bf1db963630fa<br>7bfd1c29663c7bf3556fd7ba6131e5ddfd6<br>40b9f6a2a9ad75d3d59b65f932 |

> [!NOTE]
>
> The hash value above is in single line.

Scenarios：

- NEP2 format secret key export.

- Password verification for NEP6 wallet.

For more information, refer to <https://en.wikipedia.org/wiki/Scrypt>.
