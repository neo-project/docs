# Json.Serialize方法

将对象序列化为Json字符串。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public extern static string Serialize(object obj);
```

参数：

- account: 所查询账户的脚本哈希

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Test()
    {
        var mapName = nameIndex;
        storageMap.Put(mapName, Json.Serialize(new Map<string, uint>()));
        var map = Json.Deserialize(storageMap.Get(mapName)) as Map<string, uint>;
		map["hello"] = 100;
        storageMap.Put(mapName, Json.Serialize(map));
    }
}
```

[返回上级](../Json.md)