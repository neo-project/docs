# 네오 노드에서 프라이빗 체인 구축 (Build a private chain with a NEO node)

이전 설명서에서 여러분들은 어떻게 윈도우와 리눅스에서 노드를 만들고 전개(deploy)하는 지 배웠습니다. 이번 설명서에서는 어떻게 프라이빗 체인이나 연합 체인을 구축하는 지, 그리고 이러한 체인들에서 어떻게 NEO와 GAS를 추출하는 지 배우게 될 것입니다. 

네오 프라이빗 체인의 전개에 동의(consensus)를 얻기 위해서는 적어도 4개의 서버가 필요하며, 각각의 서버는 컨센서스 노드와 전용 지갑에 대응 되야 합니다. 
node and a dedicated NEO wallet.

## 1. 가상 머신 설정 (Configuration of the virtual machine)

네오 프라이빗 체인의 전개에 동의(consensus)를 얻기 위해서는 적어도 4개의 서버가 필요하며 각각이 서버는 컨센서스 노드에 대응해야 합니다. 시연 목적으로 여기서 Aszure상에 네 개의 윈도우 가상 머신을 생성할 것이며, 사이즈는 Standard DS1 v2(1 Core, 3.5 GB RAM)입니다. 여러분은 프라이빗 체인을 LAN상이나 가상 머신에 전개 할 수 있습니다.

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_1.png)

가상 머신 생성 후, 10331-10334 포트를 개방하기 위해, ‘방화벽’의 ‘고급 설정’, ‘인바운드 룰’을 열어 새로운 룰을 만든 후 포트 10331-10334를 추가하세요.

> [!주의]
> 만약 가상 머신을 클라우드 서버에 생성하게 되면, 가상 머신 관리자 백그라운드에 로그인 해서 네트워크 보안 그룹을 설정하세요
>
> Azure 셋업 방법은 다음과 같습니다 : ‘네트워크 인터페이스(network interface)’, ‘네트워크 보안 그룹(network security group)’, ‘인바운드 보안 룰(inbound security rules)’ ‘추가’ 에서 포트 10331-10334를 추가하세요.
가상 머신이 만들어 지면 나중에 사용하기 위해 가상 머신 4개의 IP주소를 저장하세요.

## 2. 네오 노드 설치 (Installation of the NEO node)

네오 노드의 설치 과정은 위의 문서에 상세히 설명되어 있습니다. 해당 문서를 참조하시길 바랍니다. [설치](setup.md)

## 3. 지갑 생성 (Create a wallet)

먼저 4개의 지갑 파일을 만들어야 합니다. 이름은 wallet1.db1 – wallet4.db3로 하겠습니다. 이 과정은 PC버전 지갑과 커맨드 라인(command line) 지갑 양쪽에서 수행되며, 아래 그럼은 커맨드 라인 클라이언트의 스크린 샷입니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_3.png)

지갑이 생성되면 대응되는 퍼블릭 키가 저장됩니다.(txt 파일 형태) 해당 키를 직접 복사하거나 [CLI 커맨드](cli.md) 커맨드 라인에서 ‘list key’를 입력해서 해당 키 값들을 복사하시기 바랍니다.

이 다음,  4개의 지갑을 복사해서 4개의 가상 머신 노드 디렉토리에 붙여 넣겠습니다. 

## 4. 노드 설정 파일 변경하기 (Modify the node's configuration file)

노드 설정 파일인 `protocol.json` 을 열어서, 먼저 ‘마법(Magic)’값을 변경합니다. 마법은 소스네트워크의 메시지를 확인하는 데 사용됩니다. 사로 다른 마법을 설정함으로써, 전송 중 다른 네트워크에 보내지 않은 네오 블록 상의 다른 네트워크 정보를 안전하게 지켜줍니다. 

> [!주의]
> 마법의 형태는 단위입니다. 여러분이 입력할 값은 다음 범위 안에 있어야 합니다. 
[0 - 4294967295].

`StandbyValidators`를 변경해, 3번 과정에서 나온 4개의 퍼블릭 키를 채워 넣으세요

마지막으로 `SeedList`을 변경해서 처음 과정에서 나온 IP주소를 채워 넣으시고 포트 넘버는 그대로 두세요. 예를 들어 저는 아래의 설정으로 변경하겠습니다.

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```
SystemFee는 시스템 수수료이며 현재의 수수료는 아래와 같습니다. (GAS단위):
북키퍼 등록 – 1000, 자산 배분 – 500, 스마트 계약 - 500, 자산 등록 - 10000

여러분은 여러분의 프라이빗 체인의 시스템 수수료를 설정할 수 있습니다. 

마지막으로 변경된 `protocol.json`을 변경해서 4 노드 클라이언트 디렉토리의 이전 버전의protocol.json파일을 변경하세요

그 다음 4개의 가상 머신에서 아래의 명령어를 입력해 노드를 시작하고, 지갑을 열고 컨센서스 프로세스를 시작합니다. 잘 모르시겠으면 해당 커맨드는 [CLI 커맨드 참조](cli.md)를 참고하시길 바랍니다.

노드 시작하기 :

`Dotnet neo-cli.dll`

지갑 열기 :

`지갑 파일wallet1.db3 열기`

주의 : 모든 노드가 wallet1을 열면 안됩니다. 각 노드는 해당하는 지갑파일을 열어야 합니다.

`컨센서스 시작하기`

위의 과정이 성공적으로 수행되면, 4개의 노드들은 컨센서스 프로세스를 아래처럼 시작합니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_8.png)

그림에서처럼 하나의 머신이 꺼지더라도 4개의 노드는 컨세서스를 이룰 수 있습니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_9.png)



## 5. NEO와 GAS 추출 (Extracting NEO and GAS)

PC버전의 클라이언트 (Neo-GUI)를 인스톨한 후에, 프라이빗 체인에 접속하기 위해 설정 파일인 protocol.json을 변경합니다.

지갑을 열어서, 왼쪽 아래 부분의 커낵션 숫자가 ‘0’이 아니면, 같은 블록에 싱크된 상태이며, 이는 클라이언트가 성공적으로 프라이빗 체인에 접속했음을 의미합니다. 

지갑 파일 wallet1.db3를 PC 클라이언트에서 열어 다자간 서명 주소(multi-party signature address )를 추가하시고 protocol.json에 4개의 퍼블릭 키를 입력합니다. 그리고 최소 서명의 수를 그림에서처럼 3으로 설정합니다. (컨센서스 노드의 숫자/2 +1)

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_12.png)

‘Ok’를 클릭합니다. 지갑 인덱스를 재건(rebuild)하기 위해, 메뉴 바에서 ‘지갑(wallet)’을 클릭하면, 여러분은 해당 계약 주소에 1억개의 NEO가 있는 걸 확인할 수 있습니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_14.png)

> [!주의]
> 4개의 모든 지갑은 다자간 서명 주소를 추가하는 작업을 해야 하며, 지갑 인덱스를 재건해야 합니다.

이제 우리는 계약 주소(contract address)에서 보통 주소(normal address)로 NEO를 보내고 싶습니다. 그러기 위해서 4개의 지갑 중 아무 지갑을 열어서 해당 주소로 1억개의 NEO를 보내기 위해  ‘전송(transaction)’, ‘이전(transfer)’를 클릭한 후 수신 주소를 입력합니다.

그런고 나면 시스템은 다음과 같은 메시지를 표시합니다. "transaction structure is completed, but there is not enough signature(전송 형식은 완료되었으나 충분한 서명이 없음)". 해당 코드를 복사한 후 두 번째 지갑을 열어, ‘전송(transaction)’, ‘이전(transfer)’을 클릭한 후 복사한 코드를 붙여 넣습니다. ‘서명(sign)’을 클릭한 후 코드를 복사하고, 세 번째 지갑을 열어 ‘전송(transaction)’, ‘이전(transfer)’을 클릭한 후 방금 복사한 코드를 붙여 넣습니다. ‘서명(sign)’을 클릭합니다. 이 때 팝업(pop-up)창이 나오면서 ‘브로드캐스트(Broadcast, 광역 전성)’ 버튼이 나타나는 데, 이는 해당 전송을 위한 모든 서명절차가 완료되었음을 의미합니다. (해당 계약에 필요한 최소 서명 숫자가 완료되었음) 이제 ‘브로드캐스트’를 클릭하면 해당 전송은 네트워크에 뿌려집니다(broadcast). 광역 전송이 시작되면, 수신 계좌에 송금액이 표시될 때 까지 15초가 소요됩니다. 


![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_20.png)

GAS 추출 방법도 비슷합니다. ‘고급(Advanced)’를 클릭하고, ‘GAS 요청(Claim GAS)’, ‘요청(Claim)’을 그림에서 나온 것처럼 클릭하세요. (지갑 주소를 기억하시길 바랍니다. 나중에 필요합니다)

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_21.png)

다음 과정은 NEO 이전과 유사합니다. 서명이 충분하지 않은 코드를 복사하고, 두 번째 지갑을 열어서, ‘전송(transaction)’을 클릭한 뒤 ‘이전(transfer)’를 클릭해서 아까 그 코드를 붙여 넣습니다. ‘서명(sign)’을 클릭한 뒤 코드를 복사하고, 세 번째 지갑을 열어 전송(transaction)’을 클릭한 뒤 ‘이전(transfer)’를 클릭해서 아까 그 코드를 붙여 넣습니다. ‘서명(sign)’을 클릭한 뒤 ‘브로드캐스트’를 클릭해서 광역전송을 요청중인 GAS 전송을 광역 전송합니다. 요청된 전송이 브로드캐스팅 되면, 해당 계좌에 송금액이 나올 때까지 15초가 소요됩니다. 

성공적으로 추줄이 되면, 그 GAS는 아래에서처럼 여러분이 처음 추출을 착수한 지갑의 첫 번째 표준 주소(최상단 주소)로 입력됩니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/privatechain_26.png)
