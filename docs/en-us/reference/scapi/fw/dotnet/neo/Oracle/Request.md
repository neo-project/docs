# Request Method

Initiates an Oracle request.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

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

[Back](../Oracle.md)