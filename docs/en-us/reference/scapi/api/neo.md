# NEO NameSpace

NEO namespace provides APIs for deploying native contracts and verifying digital signature.

**Native API**：
| API                           | Description                         |
| -- | --|
|Neo.Native.Deploy|Deploy and initialize all native contracts|

**Crypto API**：

| API                           | Description                         |
| -- | -- |
| Neo.Crypto.ECDsaVerify            | Verify signature of the current script container by public key                   |
| Neo.Crypto.ECDsaCheckMultiSig       | Verify the multiple signature of the current script container by public key                    |

Note：The source code for the above API can be found under `NEO` in the [src/neo/SmartContract/InteropService.Native.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Native.cs) and [src/neo/SmartContract/InteropService.Crypto.cs](https://github.com/neo-project/neo/blob/master/src/neo/SmartContract/InteropService.Crypto.cs).
