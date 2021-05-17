# Contract.GetCallFlags 方法

获取合约的调用权限 Flag

命名空间：[Neo.SmartContract.Framework.Services](../../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern byte GetCallFlags();
```

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
        public static int GetCallFlags()
        {
            return Contract.GetCallFlags();
        }
}
```



[返回上级](../Contract.md)
