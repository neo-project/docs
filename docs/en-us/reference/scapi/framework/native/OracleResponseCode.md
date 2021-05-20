# OracleResponseCode Enumeration

Defines response types of Oracle.

Namespace：[Neo.SmartContract.Framework.Native](../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum OracleResponseCode : byte
{
    Success = 0x00,

    ProtocolNotSupported = 0x10,
    ConsensusUnreachable = 0x12,
    NotFound = 0x14,
    Timeout = 0x16,
    Forbidden = 0x18,
    ResponseTooLarge = 0x1a,
    InsufficientFunds = 0x1c,

    Error = 0xff
}
```

##### Description

- Success: success

- ProtocolNotSupported: The protocol is not supported.

- ConsensusUnreachable: Consensus failed.

- NotFound: HTTP 404 request failed. The requested resource was not found on the server.

- Timeout: HTTP 408 request timeout.

- Forbidden: The HTTP 403 server already understands the request, but refuses to execute it.

- ResponseTooLarge: HTTP 413 Request Entity Too Large. The server refuses to process the current request because the size of the entity submitted by the request is larger than the server is willing or able to process.

- InsufficientFunds: system fee is insufficient.

- Error: other errors


You need to fill in the callback function name in [Oracle.Rqeuest](Oracle/Request.md). The order of the parameter data types of the callback function is fixed and must be `string url, byte[] userData, int code, byte[] result`. The code can be judged in the contract and different logic codes can be executed. Such as:

```c#
public static void Callback(string url, byte[] userData, int code, byte[] result)
{
    switch (code)
    {
        case OracleResponseCode.Success: 
            
            break;
        case OracleResponseCode.NotFound: 
            
            break;
    }
}
```



