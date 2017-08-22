# API 참조 (Reference)


Neo-CLI의 각 노드는 각 노드에서 오는 블록체인을 받기 위한 API 인터페이스를 제공합니다. 이를 통해 블록체인 어플리케이션 개발을 쉽게 할 수 있습니다. 이 인터페이스는 [JSON-RPC](http://wiki.geekdream.com/Specification/json-rpc_2.0.html)을 통해 제공되는데, 기저 프로토콜로써 HTTP/HTTPS를 이용합니다. RPC서비스를 제공하는 노드를 시작하기 위해, 먼저 아래의 명령문을 실행해 보겠습니다. , 

`dotnet neo-cli.dll /rpc`

HTTPS를 통해 RPC서버에 접근하려면, 여러분께서는 노드 시작/도메인 네임, 인증서, 패스워드 설정을 하기 전에 config.json 파일의 설정(configuration)을 변경해야 합니다.  

```json
{
  "ApplicationConfiguration": {
    "DataDirectoryPath": "Chain",
    "NodePort": 10333,
    "WsPort": 10334,
    "UriPrefix": [ "https://*:10331", "http://*:10332" ],
    "SslCert": "YourSslCertFile.xxx",
    "SslCertPassword": "YourPassword"
  }
}                                          
```

JSON-RPC 서버를 시작하면, 매인/테스트 넷(Main and Test net))에 맞춰 아래의 포트들을 모니터합니다.

P2P와 웹소켓(WebSocket) 정보에 대해서는 다음을 참고하세요 : [Node/Introduction](introduction.md)

|                | （메인 넷） | （테스트 넷） |
| -------------- | ------------ | ------------- |
| JSON-RPC HTTPS | 10331        | 20331         |
| JSON-RPC HTTP  | 10332        | 20332         |

## 명령어(Command) 리스트

| 명령어                                       | 참조                                      | 설명                         | 커멘트       |
| ---------------------------------------- | --------------------------------------- | -------------------------- | -------- |
| [getbalance](api/getbalance.md)          | \<asset_id>                             |해당 자산(asset)숫자에 맞춰 지갑의 자산 잔액(balance)을 반환.   | 지갑을 열어야 함   |
| [getbestblockhash](api/getbestblockhash.md) |                                         | 메인체인의 가장 큰(최신, tallest)블록의 해쉬를 획득           |          |
| [getblock](api/getblock.md)              | \<hash> [verbose=0]                     | 특정 해쉬 값에 맞춰 해당되는 블록 정보를 반환         |          |
| [getblock](api/getblock2.md)             | \<index> [verbose=0]                    | 특정지수(index)에 맞춰 해당되는 블록 정보를 반환          |          |
| [getblockcount](api/getblockcount.md)    |                                         | 메인체인에서 블록의 숫자를 획득                 |          |
| [getblockhash](api/getblockhash.md)      | \<index>                                | 특정지수에 기반한 해당 블록의 해쉬 값을 반환         |          |
| [getconnectioncount](api/getconnectioncount.md) |                                         | 해당 노드에 대해 현재 접속 숫자(number of connection)를 획득                 |          |
| [getrawmempool](api/getrawmempool.md)    |                                         | 메모리 내의 미확인(unconfirmed)된 전송 리스트 획득            |          |
| [getrawtransaction](api/getrawtransaction.md) | \<txid> [verbose=0]                     | 특정해쉬 값에 기반한 해당되는 전송 정보를 반환         |          |
| [gettxout](api/gettxout.md)              | \<txid> \<n>                            | 특정해쉬와 지수에 기반한 해당되는 전송 출력(Output, change)을 반환 |          |
| [sendrawtransaction](api/sendrawtransaction.md) | \<hex>                                  | 네트워크에 ‘전송’(transaction)을 뿌림(Broadcast). [네트워크 프로토콜]문서 참조(network-protocol.md).                       |          |
| [sendtoaddress](api/sendtoaddress.md)    | \<asset_id> \<address> \<value> [fee=0] | 특정주소에 전달                     | 지갑을 열어야 함   |
| submitblock                              | \<hex>                                  | 새로운 블록을 제출                      | 컨센서스 노드가 되야 함 |

## ‘겟’(GET) 요청(request) 예(example)

일반적인 JSON-RPC ‘겟’ 요청 형식은 다음과 같습니다. 

아래는 메인 체인에서 블록의 숫자를 어떻게 획득하는 지에 대한 예입니다. 

URL 요청:

```
http://somewebsite.com:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1
```

해당 요청을 보낸 후 여러분은 아래와 같은 회신을 받습니다 :

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909129
}
```

## ‘포스트’(POST) 요청 예

일반적인 JSON-RPC의 ‘포스트’요청 은 다음과 같습니다 : 

아래는 메인 체인에서 블록의 숫자를 어떻게 획득하는 지에 대한 예입니다.

URL 요청:

```
http://somewebsite.com:10332
```

Body 요청：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockcount",
  "params":[],
  "id": 1
}
```


해당 요청을 보낸 후 여러분은 아래와 같은 회신을 받습니다 :

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": 909122
}
```

## 테스트 툴 (Test tools)

테스트를 진행하기 위해서 포스트맨(postman)의 크롬 익스텐션(extension)을 사용할 수 있습니다,
(크롬의 익스텐션을 설치하기 위해선 인터넷 연결이 필요합니다)
아래는 테스트의 스크린 샷입니다. 

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/api_2.jpg)

![image](https://github.com/neo-project/docs/blob/master/assets/api_3.jpg)
