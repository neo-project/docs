# Request Method

Initiates an Oracle request.

Namespace: [Neo.SmartContract.Framework.Native](../../native.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern void Request(string url, string filter, string callback, object userData, long gasForResponse);
```

Parameters：

- url: The request Url
- filter: Filter, used to filter useless data
- callback: Callback function
- userData: Additional data provided by the user
- long: The cost of getting a response

## Example

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
        /// Create a request.
        /// </summary>
        /// <param name="url">URL，e.g."http://127.0.0.1:8080/test"</param>
        /// <param name="filter">Filter,e.g."$.value"; JSONPath, { "value": "hello world" }</param>
        /// <param name="callback">Callback method,e.g."callback"</param>
        /// <param name="userData">User data,e.g.new byte[0]</param>
        /// <param name="gasForResponse">Gas for response,e.g.10000000</param>
        public static void Request(string url,string filter,string callback,byte[] userData,long gasForResponse) {
            Oracle.Request(url, filter, callback, userData, gasForResponse);
        }

        /// <summary>
        /// Callback method
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="userData">User data</param>
        /// <param name="code">Response status</param>
        /// <param name="result">Result data</param>
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

[Back](../Oracle.md)