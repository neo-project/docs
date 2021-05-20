# Crypto Class

Static class, which provides a method to verify signatures by ECDsa

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Crypto
```

## Methods

| Name                                   | Description   |
| ---------------------------------------- | --------------- |
| CheckSig(Cryptography.ECC.ECPoint, ByteString)          | Checks the signature for the current script container |
| CheckMultisig(Cryptography.ECC.ECPoint[], ByteString[]) | Checks the signatures for the current script container |

# Constructor

Crypto is a static class and does not require a constructor.