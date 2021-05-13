# RecordType Class

Defines types recored by DNS of NameServices.

Namespace：[Neo.SmartContract.Framework.Service](../Neo.SmartContract.Framework.Service.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Policy
```

```c#
public enum RecordType : byte
{
    #region [RFC 1035](https://tools.ietf.org/html/rfc1035)
    A = 1,
    CNAME = 5,
    TXT = 16,
    #endregion

    #region [RFC 3596](https://tools.ietf.org/html/rfc3596)
    AAAA = 28,
    #endregion
}
```

For more information see the methods SetRecord and GetRecord in [NameService](NameService.md) class.