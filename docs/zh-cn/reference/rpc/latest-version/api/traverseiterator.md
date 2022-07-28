# traverseiterator 方法

通过 [invokefunction](./invokefunction.md) 或 [invokescript](./invokescript.md) 中返回的 `session` 和 `Iterator id` 来获取 Iterator 的具体值。

> [!Note]
>
> - 此方法是查询 Iterator 类型数据的方法，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。
> - 要使用此方法，`RpcServer` 插件的 `config.json` 文件中 `SessionEnabled` 字段的值必须为 `true`，并且需要先调用 [invokefunction](./invokefunction.md) 或 [invokescript](./invokescript.md) 获取到 `Iterator id` 和 `session`。

## 参数说明

- session：缓存区 id。

- iterator id：Iterator 数据存储 id。

- count：每次返回的值数量，不能超过 `RpcServer` 插件的 `config.json` 文件中 `MaxIteratorResultItems` 字段的值。

> [!Note]
>
> session 是 [invokefunction](./invokefunction.md) 或 [invokescript](./invokescript.md) 返回值中的 `session`；iterator id 是 [invokefunction](./invokefunction.md) 或 [invokescript](./invokescript.md) 返回值中 `stack` 中的 `id`；session 和 iterator id 的有效期是 `RpcServer` 插件的 `config.json` 文件中 `SessionExpirationTime` 字段设置的值，单位为秒。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "traverseiterator",
  "params": [
    "c5b628b6-10d9-4cc5-b850-3cfc0b659fcf",
    "593b02c6-138d-4945-846d-1e5974091daa",
    10
  ]
}


```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "type": "ByteString",
            "value": "AAUPmAOGDBtFrjhmByyKoaxgy9LvzyEh8qUiEU1gxTE="
        },
        {
            "type": "ByteString",
            "value": "ABX1SHTkVThVWpKlyFr3OO8swQXWfnRuqw99TTvi2UU="
        },
        {
            "type": "ByteString",
            "value": "ACj/5pqjP2Mko/2c0GSUKxkJlIyC3cwUbgETEZ5+5YI="
        },
        {
            "type": "ByteString",
            "value": "AF16dMuw8CAZBr/sgdJnW8XWrDDDxifHsa8myh+zsD0="
        },
        {
            "type": "ByteString",
            "value": "AF9luS6mW+nVUNwwlkKqqRLjgoXaIlk98NuhzLTZ2sI="
        },
        {
            "type": "ByteString",
            "value": "AHg1cOvi+r1ORjQcs9VD5bpBDCFtpzp/G4g0BMfsneo="
        },
        {
            "type": "ByteString",
            "value": "AM9ZDm7y7R4M5AicSk06sRv+AEmRPToxjoiHo5aeCfo="
        },
        {
            "type": "ByteString",
            "value": "AOqjq4sfaUcMBtXWVHKh6HqXZA3bOSiNc1VjIEi1auY="
        },
        {
            "type": "ByteString",
            "value": "AOsx7QOiuKZCB2bFBR1s/SjJnfvdbyVvC5ZvaTCFe2U="
        },
        {
            "type": "ByteString",
            "value": "APHR02jt/M9nkLF9z+5yRnRE8efjVhMvjIjDHAQeGV0="
        }
    ]
}
```

响应说明：

返回结果是遍历 Iterator 中前 `count` 个数据，继续请求会从第 `count + 1` 个开始继续遍历。 