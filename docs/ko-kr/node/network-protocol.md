# 네트워크 프로토콜

네오는 P2P네트우크 구조를 채용했습니다. 이는 한 노드가 다른 노드와 TCP/IP 프로토콜을 통해 통신하는 방식입니다. 네오 네트워크에는 두가지 다른 형태의 노드가 있습니다 : 피어(peer)노드와 검증(validating)노드입니다.(네오 백서의 북키퍼 참조) 피어 노드는 광역전송(Broadcast)을 할 수 있으며 전송이나 블록의 이전/수신이 가능하며 검증 노드는 블록을 만들 수 있습니다.  

네오의 네트워크 프로토콜은 대략 비트코인의 경우와 유사하나, 블록이나 전송 같은 데이터 구조는 매우 다릅니다. 

관례
----

1. 바이트 규칙 (Byte Order)

    네오의 모든 정수 형태는 최소 끝(Little Endian) 형식이며 IP주소와 포트번호는 빅 앤디언(big Endian) 형식입니다.
1. 해쉬 (Hash)

   네오는 두개의 다른 해쉬 함수를 사용합니다 : SHA256과 RIPEMD165입니다. SHA256은 긴 해쉬 값(long hash value )을 생생하는 데 사용되며 RIPEMD160은 짧은 해쉬 값(short hash value )을 생성하는 데 쓰입니다. 일반적으로 해쉬 함수를 두 번 써서 개체(object)의 해쉬 값을 얻을 수 있습니다. 예를 들면, SHA256를 두 번 사용해서 블록이나 전송(transaction)의 해쉬 값을 만듭니다. 계약 주소(contract address )를 만들 경우 먼저 SHA256함수를 쓰고 그 다음 RIPEMD160함수를 사용합니다.  

   덧붙이자면, 블록은 Merkle 트리(tree)라 불리는 해쉬 구조를 사영합니다. 이는 각 전송의 해쉬 값을 계산하고 또 다른 것과 결합한 다음에 다시 해쉬 과정을 수행합니다. 오직 하나의 루트 해쉬(Merkle Hash)가 만들어 질 때까지 이과정을 반복합니다. 

1. 변수 길이 형태 (Variable Length Type)

   + 변량(Variant): 변수 길이 정수(Variable length integer)는 값의 형태에 맞춰 공간을 절약하게 인코딩 되야 합니다.

      |값|길이|포맷|
      |---|---|---|
      |< 0xfd|1|uint8|
      |<= 0xffff|3|0xfd + uint16|
      |<= 0xffffffff|5|0xfe + uint32|
      |> 0xffffffff|9|0xff + uint64|

   + Varstr: 변수 길이 스트링(Variable length string), 스트링 다음에 오는 변수 길이 정수로 구성되며, 스트링은 UTF8로 인코딩 되야 합니다.

      |크기(size)|필드(Field)|데이터 형태(Data type)|상세설명(Description)|
      |---|---|---|---|
      |?|length|variant|바이에서 스트링의 길이|
      | length |string|uint8[length]|스트링 자체|

   + 배열(Array): 배열은 구성 요소의 순서(sequence of elements) 다음에 오는 변수 길이 정수로 구성되어 있습니다.

1. 고정 소수점 수 (Fixed-point Number)

   가격이나 양과 같은 네오의 데이는 64비트 고정 소수점 수로 되어 있으며 정확한 소수(decimal)부분은 다음과 같습니다. 10<sup>-8</sup>，range：[-2<sup>63</sup>/10<sup>8</sup>, +2<sup>63</sup>/10<sup>8</sup>)

데이터 형태 (Data Type)
-------

1. 블록체인

   블록체인은 한 방향으로 연결된 나열의 시리즈와 연결된 일종의 논리 구조입니다. 전체 네트워크의 데이터(전송이나 자산등의)를 저장하는 데 사용됩니다.

1. 블록

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |4|버전|uint32|현재 블록의 버전은 0|
   |32|PrevBlock|uint256|이전 블록의 해쉬 값|
   |32|MerkleRoot|uint256|전송 리스트의 루트 해쉬|
   |4|Timestamp|uint32|타임 스탬프|
   |4|Height|uint32|블록의 높이|
   |8|Nonce|uint64|무작위 숫자|
   |20|Next miner|uint160| Next miner의 계약 주소(Contract address)|
   |1|-|uint8|1로 고정됨|
   |?|Script|script| 블록을 검증하는 데 스크립트를 사용함|
   |?*?|transaction|tx[]|전송 리스트|

   블록의 해쉬 값을 계산할 때, 전체 블록을 계산하는 대신, 블록 헤드의 처음 일곱 필드만 계산되는 게 이 필드들은 버전, PrevBlock, MerkleRoot, Timestamp, 그리고 높이, nonce, Nextminer입니다. MerkleRoot는 이미 모든 전송의 해쉬 값을 포함하고 있으며, 전송의 변경은 블록의 해쉬 값에 영향을 줍니다.  


   블록 헤드의 데이터 구조:

   |사이즈|필드|데이터 형식|상세설명|
   |---|---|---|---|
   |4|Version|uint32|현재 블록 버전은 0|
   |32|PrevBlock|uint256|이전 블록의 해쉬 값|
   |32|MerkleRoot|uint256|전송 리스트의 루트 해쉬|
   |4|Timestamp|uint32|Time-stamp|
   |4|Height|uint32|블록 높이|
   |8|Nonce|uint64|무작위 숫자|
   |20|NextMiner|uint160|next miner의 계약주소|
   |1|-|uint8|1로 고정됨|
   |? |Script|스크립트|블록을 검증하는 데 스크립트를 사용함|
   |1|-|uint8|0으로 고정|

   각 블록의 타임-스탬프(time-stamp)는 이전 블록의 타임 스탬프보다 나중이어야 합니다. 일반적으로 두 블록의 타임 스탬프 차이는 15초이며 약간의 오차는 허용됩니다. 현재 블록의 높이는 반드시 정확하게 이전 블록에서 1을 더한 값이어야 합니다. 

1. 전송 (Transaction)

   |크기|필드|데이터 형태|상세설명|
   |---|---|---|---|
   |1|type|uint8|전송형태|
   |1|version|uint8|트레이딩 버전, 현재0|
   |?|-|-|전송 형태에 따른 데이터|
   |?*?|Attributes|tx_attr[]|거래의 부가적인 특징|
   |34*?|Inputs|tx_in[]|인풋|
   |60*?|Outputs|tx_out[]|아웃풋|
   |?*?|Scripts|스크립트[]|전송을 검증하는 데 사용되는 스크립트 리스트|

   네오 시스템의 모든 프로세스들은 전송의 형태로 기록됩니다. 몇가지 형태의 전성 기록들이 있습니다 : 

   |값|이름|시스템 수수료|상세설명|
   |---|---|---|---|
   |0x00|MinerTransaction|0|바이트 수수료 할당|
   |0x01|Issue Transaction|500\|0|자산의 배급(Issuance)|
   |0x02|Claim Transaction|0|GAS 할당|
   |0x20|Enrollment Transaction|1000|검증자(validator) 기재|
   |0x40|Register Transaction|10000|자산 등록|
   |0x80|Contract Transaction|0|계약 전송|
   |0xd0|Publish Transaction|500 * n|(불용, Not usable) 스마트 계약의 특별 전송|
   |0xd1|Invocation Transaction|0|호출된 스마트 계약의 특별 전송|

  퍼블릭 필드에 덧붙여져, 각 형태 의 전송은 고유의 배타적인 필드를 가지고 있습니다. 다음은 이러한 배타적인 필드의 상세 설명입니다. 

   + 마이너전송 (MinerTransaction)

      |크기|필드|데이터형태|상세설명|
      |---|---|---|---|
      |4|Nonce|uint32|무작위 숫자|

      각 블록의 처음 전송은 마이너전송이 되어야 합니다. 현재 블록의 전송 수수료는 검증자에게 보상금으로 사용됩니다.

      전송에서의 무작위 숫자는 해쉬 충돌을 방지하기 위해 사용됩니다.

   + 전송발행 (IssueTransaction)

      전송 발행에 대한 특별 필드는 없습니다.

      자산 관리자는 네오 블록체인에 등록된 자산을 전송발행을 통해 생성할 수 있으며, 어떤 주소로도 보낼 수 있습니다.

      발행된 자산이 NEO인 경우 전송 수수료는 무료입니다.

      전송에서의 무작위 숫자는 해쉬 충돌을 방지하기 위해 사용됩니다.

   + 요청전송(ClaimTransaction)

      |크기|필드|데이터형태|상세설명|
      |---|---|---|---|
      |34*?|Claim|tx_in[]|배포를 위한 NEO|

   + 기재전송 (EnrollmentTransaction)

      |크기|필드|데이터형태|상세설명|
      |---|---|---|---|
      |33|Public key|ec_point|검증자의 퍼블릭키|

      해당 전송은 기재 양식(form)을 대표하며, 그 전송의 후원자가 검증자로써 서명할 수 있음을 가리킵니다. 

      서명의 과정은 다음과 같습니다 : 전송의 기재전송 형태를 구성하고 예치금을 해당 퍼블릭키의 주소로 보냅니다. 
(The way to sign up is: To construct an EnrollmentTransaction type of transaction, and send a deposit to the address of the PublicKey.)

      등록을 취소하는 방법입니다 : 예치금을 해당 퍼블릭키의 주소에서 소비합니다.


   + 등록전송 (RegisterTransaction)

      > [!경고]
      비활성화 되었고 스마트 계약을 위한 Neo.Asset.Create로 대체되었습니다.

      참조 [대안 닷넷 스마트 계약 프레임워크](../sc/fw/dotnet/neo/Asset/Create.md)

      참조 [대안 스마트 계약 API](../sc/api/neo.md)

   + 계약전송 (ContractTransaction)

      계약 전송에는 특별한 특성(attribute)이 없습니다. 이는 한 지갑에서 다른 지갑으로 NEO를 보내는 형식의 매우 평범한 전송입니다. 이 전송에서는 전송 필드의 ‘인풋’과 ‘아웃풋’의 필드가 일반적으로 중요합니다. (예를 들면 얼만큼의 NEO를 어느 주소로 보낼 건지)

   + 발행전송 (PublishTransaction)

      > [!경고]
      비활성화 되었고 스마트 계약을 위한 Neo.Contract.Create로 대체되었습니다.

      참조 [대안 닷넷 스마트 계약 프레임워크](../sc/fw/dotnet/neo/Contract/Create.md)

      참조 [대안 스마트 계약 API](../sc/api/neo.md)

   + 전송 호출 (Invoking a Transaction)

      | 크기   | 필드     | 데이터형태    | 상세설명              |
      | ---- | ------ | ------- | --------------- |
      | -    | -      | -       | 전송을 위한 퍼블릭 필드      |
      | ?    | Script | uint8[] | 스마트 계약에 의한 호출     |
      | 8    | GAS    | int64   | 스마트 계약을 실행하기 위한 비용 |
      | -    | -      | -       | 전송을 위한 퍼블릭 필드 |

1. 전송 특성 (Transaction Attributes)

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |1|Usage|uint8|사용법|
   |0\|1|Length|uint8|데이터의 길이(특별한 상황은 생략됨)|
   |Length|Data|uint8[길이]|외부 데이터|

   가끔 전송이 외부 사용을 위한 데이터를 포함하는 경우가 있는데, 이러한 데이터는 전송 특성 필드에 위치합니다. 

   각 전송 특성은 서로 다른 용도를 가지고 있습니다 :

   |값|이름|상세설명|
   |---|---|---|
   |0x00|contract hash|계약의 해쉬 값|
   |0x02-0x03|ECDH02-ECDH03|ECDH 키 교환을 위한 퍼블릭 키|
   |0x20|Script|전송의 추가 검증|
   |0x30|Vote|투표를 위한
   |0x80|CertUrl|증명서의 URL주소|
   |0x81|DescriptionUrl|상세 설명의 URL주소|
   |0x90|Description|간단한 설명|
   |0xa1-0xaf|Hash1-Hash15|커스텀 해쉬 값을 저장하기 위해 사용|
   |0xf0-0xff|Remark-Remark15|리마크|

   계약 해쉬, ECDH 시리즈, 해쉬 시리즈의 데이터 길이는 32바이트로 고정되어 있으며 길이 필드는 생략됩니다 ;

   CertUrl, DescriptionUrl, 상세 설명(Description), 리마크 시리즈의 데이터 길이는 반드시 지정되어야 하며, 길이는 255를 넘어선 안됩니다 ;

1. 전송 인풋 (Input of Transaction)

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |32|PrevHash|uint256|이전 전송의 해쉬|
   |2|PrevIndex|uint16|이전 전송의 지수|

1. 전송 아웃풋 (Output of Transaction)

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |32|AssetId|uint256|자산 id|
   |8|Value|int64|값|
   |20|ScriptHash|uint160|수취인 주소|

   각 전송은 65536까지 아웃풋을 가질 수 있습니다.

1. 검증 스크립트 (Validation Script)

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |?|StackScript|uint8[]|스크립트 코드 스택|
   |?|RedeemScript|uint8[]|계약 스크립트 코드|

   스택 스크립트(Stack script)는 오직 PUSH작업을 위해 사용되며, 이는 서명 같은 데이터를 스택 내부에 넣는데 사용됩니다. 스크립트 해석기는 스택 스크립트 코드를 먼저 실행한 다음 계약 스크립트 코드를 실행합니다.

   전송에서, 스크립트 코드의 해쉬 값은 전송 아웃풋과 일치해야 하며 이는 검증하는 방법의 일부분입니다. 후반부에서 스크립트 실행 과정을 자세히 설명하겠습니다.

네트워크 메시지 (Network Message)
-------

모든 네트워크 메시지는 이 구조로 보내 집니다.
All network messages are sent in this structure:

|크기|필드|데이터형태|상세설명|
|---|---|---|---|
|4|Magic|uint32|프로토콜 id|
|12|Command|char[12]|커맨드|
|4|length|uint32|부다금의 길이(Length of payload)|
|4|Checksum|uint32|검사 합계(checksum)|
|length|Payload|uint8[length]|메시지 내용|

매직 값 설정 (Defined Magic value) :

|값|상세설명|
|---|---|
|0x00746e41|생산 모드(Production mode)|
|0x74746e41|태스트 모드|

명령어는 utf8 코드이며 길이는 12바이트이고 추가(extra) 부분은 0으로 채워져 있습니다.

검사합계는 부담금의 SHA256해쉬를 두밴 실행한 해당 값의 처음 4바이트입니다.

서로 다른 주문(order)에 맞춰 부담금은 다른 상세 포맷을 가집니다. 아래를 참조하세요 :
According to different orders Payload has different detailed format, see below:

1. 버전 (version)

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |4|Version|uint32|프로토콜 버전, 현재 0|
   |8|Services|uint64|노드가 제공한 서비스, 현재 1|
   |4|Timestamp|uint32|현재시간|
   |2|Port|uint16|서버가 청취(listen)하는 포트, 사용되지 않으면 0|
   |4|Nonce|uint32|노드를 퍼블릭 IP와 구분하기 위해 사용|
   |?|UserAgent|varstr|클라이언트 ID|
   |4|StartHeight|uint32|블록체인의 높이|
   |1|Relay|bool|수신할 지 전달할 지 여부


   노드가 연결 요청을 수신하면, 즉시 버전을 선언합니다. 서로 버전을 확인하기 전에는 더 이상의 통신은 없습니다.

1. verack

   노드가 버전 메시지를 수산하면 즉시 verack을 통해 회신합니다.

   이 메시지에는 부담금(payload)이 없습니다.

1. getaddr

   연결 수를 늘리기 위해 새로운 활동중인 노드의 배치를 만들기 위한 요청.

   이 메시지에는 부담금(payload)이 없습니다.

1. addr

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |30*?|AddressList|net_addr[]|네트워크의 다른 노드 주소|

   getaddr 메시지를 수신하면 노드는 회신의 형태로 addr 메시지를 돌려보내고 네트워크 상의 알고있는 노드에 대한 정보를 제공합니다.

1. getheaders

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|노드가 요청한 가장 최신 블록의 해쉬|
   |32|HashStop|uint256|노드가 요청한 지난 블록의 해쉬|

   HashStart 에서 HashStop을 포함하는 대부분 2000개 블록 헤더 패키지를 노드에게 요청합니다. 그 후 블록 해쉬를 획득하기 위해 여러분은 getheaders 메시지를 다시 보내야 합니다. 이 매세지는 해당 전송이 없는 블록체인을 빨리 다운로드 받는데 사용합니다.  

1. headers

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |?*?|Headers|header[]|블록의 헤드|

   Getheader 메시지를 수신한 후 노드는 헤더 메시지를 회신의 형태로 돌려보내고 네트워크 상에 알고 있는 노드에 대한 정보를 제공합니다. 

1. getblocks

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |32*?|HashStart|uint256[]|노드가 요청한 가장 최신 블록의 해쉬|
   |32|HashStop|uint256| 노드가 요청한 지난 블록의 해쉬|

   HashStart 에서 시작해서 HashStop까지의 inv 메시지를 노드에 요청합니다. HashStart 에서 시작해서 HashStop까지의 블록의 개수는 500까지 입니다. 만약 여러분이 그것보다 더 많은 블록 해쉬를 획득하시려면 getblocks 메시지를 회신해야 합니다. 

1. inv

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|인벤토리의 데이터|

   이 메시지를 통해 노드는 개체(object) 정보를 네트워크에 뿌릴 수 있습니다(broadcast). 이 메시지는 자동으로 보내 지거나 getblocks 메시지에 대한 대답으로 사용됩니다.  

   개체 정보는 리스트에 포함되어 있습니다 :

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |4|Type|uint32|개체 형태|
   |32|Hash|uint256|개체의 해쉬|

   개체 형태 :

   |값|이름|상세설명|
   |---|---|---|
   |0x01|TX|전송(Transaction)|
   |0x02|Block|블록|
   |0xe0|Consensus|컨센서스 데이터|

1. getdata

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |36*?|Inventories|inv_vect[]|인벤토리의 데이터|

   노드에 특정 개체를 요청하기 : 일반적으로 inv패킷이 수신된 후 그리고 알려진 요소(known element)가 제거된 후에 보내 집니다.

1. block

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |?|Block|block|블록|

    getdata 메시지에 회신하기 위해 노드에게 블록을 보냅니다.

1. tx

   |크기|필드|데이터형태|상세설명|
   |---|---|---|---|
   |?|Transaction|tx|전송(Transaction)|

   getdata 메시지에 회신하기 위해 노드에게 전송을 보냅니다.

   |크기|필드|데이터형태|상세설명|
   |----|---------|--------- |----------------- |
   |32 *?|HashStart|uint256[]|노드는 가장 최신 블록의 해쉬를 알고 있음|
   |32|hashStop|uint256|바로 이전 블록을 요청|
