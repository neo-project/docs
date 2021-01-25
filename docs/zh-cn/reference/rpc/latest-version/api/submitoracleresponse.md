# submitoracleresponse 方法

预言机（Oracle）的节点向预言机（Oracle）提交数据。普通开发者用不到该方法。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases)、 [OracleService](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

oracle_publickey：Oracle 节点的公钥。

request_Id：Oracle 请求 ID。

tx_sign：交易签名。

message_sign：消息签名。