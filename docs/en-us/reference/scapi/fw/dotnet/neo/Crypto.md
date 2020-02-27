# Crypto Class

Static class, which provides a method to verify signatures by ECDsa

Namespace：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Crypto
```

## Methods

| Name                                   | Description   |
| ---------------------------------------- | --------------- |
| ECDsaVerify(byte[] message, byte[] pubkey, byte[] signature) | Verify if the signature is correct based on the text, public key array, and the signature |
| ECDsaCheckMultiSig(byte[] message, byte[][] pubkey, byte[][] signature) | Verify if the multi-party signatures are correct based on the text, public key array, and the signature |

# Constructor

Crypto is a static class and does not require a constructor.