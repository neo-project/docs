# OracleResponseCode 枚举

定义了 Oracle 响应代码的类型。

命名[Neo.SmartContract.Framework.Services.Neo](../neo.md)

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

在 [Oracle.Rqeuest](Oracle/Request.md) 需要填写回调函数，而在智能合约里，回调函数的第一个参数默认应该是 OracleResponseCode 类型，然后在合约中对其进行判断，执行方法内的逻辑代码。如：

```c#
public static void Callback(OracleResponseCode code, object data)
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



