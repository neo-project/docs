# Iterator 类

用来表示枚举器的类。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Iterator<TKey, TValue>
```

## 属性

|                                                        | 名称                       | 说明                 |
| ------------------------------------------------------ | -------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Key](Iterator/Key.md)     | 获得当前游标的 Key   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Value](Iterator/Value.md) | 获得当前游标的 Value |

## 方法

|                                                        | 名称                       | 说明                                                         |
| ------------------------------------------------------ | -------------------------- | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Next()](Iterator/Next.md) | 游标向下移动，返回游标状态（true: 没有到末尾 false: 到末尾） |

## 构造方法

通过 [Storage.Find(...)](Storage.md) 来构造 Iterator\<TKey, TValue> 对象。