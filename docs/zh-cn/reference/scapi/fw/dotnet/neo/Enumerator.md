# Enumerator 类

智能合约中的自定义枚举器。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Enumerator<TValue>
```

## 属性

| 名称  | 说明                     |
| ----- | ------------------------ |
| Value | 获得枚举器当前位置的值 |

## 方法

| 名称                                | 说明                                                         |
| ----------------------------------- | ------------------------------------------------------------ |
| Create(IEnumerable\<TValue\> entry) | 静态方法，创建枚举器                                         |
| Concat(Enumerator\<TValue\> value)  | 连接两个枚举器                                               |
| Next()                              | 获得枚举器中是否有下个元素，如果有则枚举器将当前位置定位到下个元素 |