# Iterator\<TKey, TValue>.Next 方法 ()

游标在集合中向下移动，返回游标状态（true: 没有到末尾 false: 到末尾）

命名空间：[Neo.SmartContract.Framework.Services](../../services.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern bool Next();
```

返回值：游标是否到集合的末尾

## 示例

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        var iterator = Storage.Find(new byte[] { 0x01 });
		while (iterator.Next())
		{
    		var k = iterator.Key;
    		var v = iterator.Value;
    		……
		}
    }
}
```



[返回上级](../Iterator.md)