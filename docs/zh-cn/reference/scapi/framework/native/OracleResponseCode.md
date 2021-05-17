# OracleResponseCode 枚举

定义了 Oracle 响应代码的类型。

命名空间：[Neo.SmartContract.Framework.Native](../native.md)

程序集：Neo.SmartContract.Framework

## 语法

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

## 说明

Success：成功

ProtocolNotSupported：协议不支持

ConsensusUnreachable：共识不成功

NotFound：HTTP 404 请求失败，请求所希望得到的资源未被在服务器上发现

Timeout：HTTP 408 请求超时

Forbidden：HTTP 403 服务器已经理解请求，但是拒绝执行它。

ResponseTooLarge：HTTP 413 Request Entity Too Large 服务器拒绝处理当前请求，因为该请求提交的实体数据大小超过了服务器愿意或者能够处理的范围

InsufficientFunds：手续费不足

Error：其它错误

## 使用方法

在 [Oracle.Rqeuest](Oracle/Request.md) 需要填写回调函数名称，回调函数的形参数据类型的顺序必须为：

`string url, byte[] userData, int code, byte[] result`。

在合约中可以对code进行判断，执行不同的逻辑代码。如：

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



