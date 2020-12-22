# Crypto Class

Static class, which provides a method to verify signatures by ECDsa

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Crypto
```

## Methods

| Name                                   | Description   |
| ---------------------------------------- | --------------- |
| SHA256(byte[] value) | Computes the SHA256 hash of the byte array |
| RIPEMD160(byte[] value) | Computes the RIPEMD160 hash of the byte array |
| Hash160(byte[] value) | Computes the SHA256 hash of the byte array and then the RIPEMD160 hash of the previous hash value. |
| Hash256(byte[] value) | Computes the SHA256 hash of the byte array twice             |
| Secp256r1.Verify(byte[] message, byte[] pubkey, byte[] signature) | Verifies if the signature is correct based on the public key array and signature (r1 curve) |
| Secp256r1.CheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | Verifies if the signature is correct based on the public key array and signature (r1 curve) |
| Secp256k1.Verify(byte[] message, byte[] pubkey, byte[] signature) | Verifies if the signature is correct based on the public key array and signature (k1 curve) |
| Secp256k1.CheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | Verifies if the signature is correct based on the public key array and signature (k1 curve) |

# Constructor

Crypto is a static class and does not require a constructor.