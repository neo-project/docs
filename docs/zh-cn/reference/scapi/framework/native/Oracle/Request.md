# Request 方法

构建Oracle请求。

命名空间：[Neo.SmartContract.Framework.Native](../../native.md)

程序集：Neo.SmartContract.Framework

## 语法

```c#
public static extern void Request(string url, string filter, string callback, object userData, long gasForResponse);
```

参数：

- url: 请求的Url；
- filter: 过滤器，可用于过滤无用数据；
- callback:回调函数；
- userData: 用户自定义数据；
- long: 获取响应所需的费用

## 示例

```c#
namespace demo
{
    [DisplayName("Oracle Demo")]
    [ManifestExtra("Author", "Neo")]
    [ManifestExtra("Email", "dev@neo.org")]
    [ManifestExtra("Description", "This is a Oracle contract example")]
    public class OracleDemo: SmartContract
    {
        static readonly string PreResponseData = "ResponseData";

        /// <summary>
        /// 构建一个Request请求
        /// </summary>
        /// <param name="url">资源访问路径，e.g."http://127.0.0.1:8080/test"</param>
        /// <param name="filter">过滤器,e.g."$.value"; JSONPath, { "value": "hello world" }</param>
        /// <param name="callback">回调函数名,e.g."callback"</param>
        /// <param name="userData">用户自定义数据,e.g.new byte[0]</param>
        /// <param name="gasForResponse">响应执行费用,e.g.10000000</param>
        public static void Request(string url,string filter,string callback,byte[] userData,long gasForResponse) {
            Oracle.Request(url, filter, callback, userData, gasForResponse);
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="url">资源访问路径</param>
        /// <param name="userData">用户自定义数据</param>
        /// <param name="code">响应状态码</param>
        /// <param name="result">响应结果数据</param>
        public static void Callback(string url, byte[] userData, int code, byte[] result) {
            Storage.Put(Storage.CurrentContext, PreResponseData, result.ToByteString());
        }
        public static string GetData()
        {
            return Storage.Get(Storage.CurrentContext, PreResponseData);
        }
    }
}
```

[返回上级](../Oracle.md)
