# Request 方法 (string, string, string, object, long)

发起Oracle请求。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Request(string url, string filter, string callback, object userData, long gasForResponse);
```

参数：

- url: 请求的Url；
- filter: 过滤器，可用于过滤无用数据；
- callback:回调函数；
- userData: 用户提供的额外数据；
- long: 获取响应所需的费用

## 示例

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        string url = "http://127.0.0.1:8080/test";
        string filter = "$.value";  // JSONPath, { "value": "hello world" }
        string callback = "callback";
        object userdata = "userdata"; // arbitrary type
        long gasForResponse = 10000000; // minimum fee 

        Oracle.Request(url, filter, callback, userdata, gasForResponse);
    }

    public static void Callback(string url, string userdata, int code, string result)
    {
        object ret = Json.Deserialize(result); // [ "hello world" ]
        object[] arr = (object[])ret;
        string value = (string)arr[0];

        Runtime.Log("userdata: " + userdata);
        Runtime.Log("response value: " + value);
    }
}
```

[返回上级](../Oracle.md)
