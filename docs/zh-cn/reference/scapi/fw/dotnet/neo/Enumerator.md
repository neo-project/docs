# Enumerator 类

智能合约中的自定义枚举器。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public class Enumerator<TValue>
```

## 属性

|                                                        | 名称  | 说明                     |
| ------------------------------------------------------ | ----- | ------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Value | 获得枚举器当前位置的元素 |

## 方法

|                                                        | 名称                                | 说明                                                         |
| ------------------------------------------------------ | ----------------------------------- | ------------------------------------------------------------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Create(IEnumerable\<TValue\> entry) | 静态方法，创建枚举器                                         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Concat(Enumerator\<TValue\> value)  | 连接两个枚举器                                               |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | Next()                              | 获得枚举器中是否有下个元素，如果有则枚举器将当前位置定位 到下个元素 |