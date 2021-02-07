# RecordType 类

定义了 NameServices 的 DNS 记录的类型。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

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

具体使用参考 [NameService](NameService.md) 类的中的 SetRecord 和 GetRecord 方法。