# getrawtransaction 方法

根据指定的散列值，返回对应的交易信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- txid：交易 ID。

- verbose：可选参数，verbose 默认值为 0。
  - verbose 为 0 时返回的是交易的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 1 时返回的是对应交易的详细信息，用 Json 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0001fea4517673890000000000c863240000000000d4192000028a45f89ca928a5381de89efff2b93f7d66eea2a800fa9536fc792ce9b312f5784473717aa367e29de101005d0300a95cd21c0100000c1418ce11c9b14a89125247433c203a4d800ff520b10c14fa9536fc792ce9b312f5784473717aa367e29de113c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b523802420c40c8bbb4e871a321544cf6c42c5b5d18cb7eafcfa8d0fcde2c054469ae0dbd8b566dc7ced0b65a4d598c9a7ce8cbebeda04260a3248fc6d9a634b30136d2042bd5290c2102a9ea6842cc0cb3b0f2317b07c850de3d1e2b243a98ed2d56a3ff4ca66aaf330b0b4195440d78420c40f3120275f82c19813671c7f19c9d030094ad57dece03d6246c8199df98f8b53e37fa2642cd5241b87331b450a2f25e2e1d8a4187c48bb752304c71a30e6001c12b110c2102a9ea6842cc0cb3b0f2317b07c850de3d1e2b243a98ed2d56a3ff4ca66aaf330b110b41138defaf"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "hash": "0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295",
        "size": 384,
        "version": 0,
        "nonce": 1369767425,
        "sender": "NYX6FuequzNvtajBpKtHkiy6ggKFTmtDjv",
        "sysfee": "9007990",
        "netfee": "2384840",
        "validuntilblock": 2103764,
        "signers": [
            {
                "account": "0xa8a2ee667d3fb9f2ff9ee81d38a528a99cf8458a",
                "scopes": "FeeOnly"
            },
            {
                "account": "0xe19de267a37a71734478f512b3e92c79fc3695fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AwCpXNIcAQAADBQYzhHJsUqJElJHQzwgOk2AD/UgsQwU+pU2/Hks6bMS9XhEc3F6o2fineETwAwIdHJhbnNmZXIMFLyvQdaEx9StbuDZnalwe50fDI5mQWJ9W1I4",
        "witnesses": [
            {
                "invocation": "DEDIu7TocaMhVEz2xCxbXRjLfq/PqND83iwFRGmuDb2LVm3HztC2Wk1ZjJp86Mvr7aBCYKMkj8bZpjSzATbSBCvV",
                "verification": "DCECqepoQswMs7DyMXsHyFDePR4rJDqY7S1Wo/9MpmqvMwsLQZVEDXg="
            },
            {
                "invocation": "DEDzEgJ1+CwZgTZxx/GcnQMAlK1X3s4D1iRsgZnfmPi1Pjf6JkLNUkG4czG0UKLyXi4dikGHxIu3UjBMcaMOYAHB",
                "verification": "EQwhAqnqaELMDLOw8jF7B8hQ3j0eKyQ6mO0tVqP/TKZqrzMLEQtBE43vrw=="
            }
        ],
        "blockhash": "0xecb6531e97a837db58f676ffc0b3038e638a483a5bd5729356cca48b9bd2748a",
        "confirmations": 98,
        "blocktime": 1595556303116,
        "vmstate": "HALT"
    }
}
```



