# RecordType 枚举

定义域名的类型。

命名空间：Neo.SmartContract

程序集：Neo.SmartContract.Framework

## 语法

```c#
public enum RecordType : byte
{
    // 域名指向一个IPv4地址
    A = 1,     
    // 域名指向另一个域名，实现与被指向域名相同的访问效果     
    CNAME = 5,
    // 文本字符串
    TXT = 16,
    // 域名指向一个IPv6地址
    AAAA = 28,
}
```

