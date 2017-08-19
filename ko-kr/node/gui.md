# 클라이언트 사용법 설명서 (Client usage instructions)

## 개요

### 소개

이 클라이언트와 호환되는 윈도우 버전은 다음과 같습니다 : Win7 sp1 / Win8 / Win10.

이 클라이언트는 설치과정이 필요 없습니다. 다운로드 받아 neo-gui.exe를 더블 클릭해서 실행시키면 됩니다. 이 과정 중에 문제가 생기면 클라이언트를 정상적으로 실행시킬 수 없습니다. 이 경우 클라이언트 디렉토리의 error.log 파일을 보관하시고 저희 기술진에 연락하셔서 문제를 푸시기 바랍니다. 

> [!주의]
> 이전 버전의 윈도우10의 경우 다음 파일을 설치하셔야 합니다. [.NET Framework 4.6.2](https://www.microsoft.com/net/download/framework).

### 싱크하기

클라이언트 사용 전에 반드시 전체 싱크가 되어야 합니다. 클라이언트 왼쪽 하단 부분에 있는 숫자가 블록의 싱크 상태를 나타냅니다. 앞/뒤가 같아져야 합니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_1.png)

### 용어집(Glossary)

#### 지갑(Wallet)

지갑 파일엔 여러분의 NEO, GAS에 대한 참고 값과 계정 정보가 *.db3 파일 형태로 저장됩니다. 이 파일은 매우 중요하기 때문에 백업을 반드시 하시기 바랍니다.  

> [!중요]
>
> 지갑 파일과 지갑 패스워드를 잃어버릴 경우, 여러분의 자산을 찾을 수 없습니다. 때문에 지갑 파일과 패스워드는 반드시 안전하게 보관하시길 바랍니다.

#### 계정 (Account)

이는 네오 블록에서 자산의 추적에 쓰입니다. 

계정 정보에는 다음과 같은 것들이 포함됩니다 : 주소, 프라이빗 키, 퍼블릭 키, 타입(type)

(1) 주소: 은행 계정이나 은행 카드의 번호와 같은 개념이며, 자산을 받을 때 사용됩니다.

(2) 타입: Neo.Wallets.SignatureContract(네오.지갑.서명.계약) 은 주소가 하나의 퍼블릭 키와 1of1 다중 서명 주소로 구성 되어있음을 나타냅니다. Neo.Wallets.MultiSigContract (네오.지갑,다중서명 계약)은 주소가 여러 개의 퍼블릭 키와 m of n 의 다중 서명 주소로 구성 되었음을 나타내며 이는 스마트 계약에 사용됩니다.

(3) 프라이빗 키(Private key): 256비트의 난수로 구성되어 있으며, 사용자가 보관하고 외부로 알려지면 안됩니다. 이 키는 사용자 계정과 그 계정내의 자산의 소유권을 대표합니다.

(4) 퍼블릭 키 : 각각의 프라이빗 키는 짝을 이루는 퍼블릭 키가 있습니다. (주 : 퍼블릭 키와 프라이빗 키는 계정(account)을 오른쪽 클릭하면 화면에 표시됩니다.)


> [!중요]
> 그 어떤 경우에도 프라이빗 키가 다른 사람에게 공개되면 안됩니다. 만약 그렇게 되면 자산을 잃어버릴 수 있습니다.

#### 자산(Assets)

계정 내의 자산과 자산 정보가 있으며 다음을 포함합니다 : 자산 (NEO, GAS, 사용자가 만든 자산), 타입, 잔액 과 발행인.

#### 전송 기록 (Transaction Record)

계정과 관련된 모든 전송 기록입니다.

#### 이전(Transfer)

자산을 수신인 주소로 이전합니다. 이전되는 자산이 NEO인 경우 양쪽 다 서명이 필요합니다. 다란 형태의 자산은 양쪽의 서명 없이 이전됩니다.

#### 거래(Trade)

자산 교환이 일어나기 전에 양자간 확인 있으면 온라인 자산 거래가 수행됩니다.

#### 서명(Signature)

서명자에 의한 정보의 서명. 
전송은 재산의 배분과 자산의 이전을 포함하기 때문에, 양자간 동의의 증거로써 서명이 사용됩니다.

#### 등록된 자산 (Registered assets)

네오 블록체인 내에 사용자가 발행한 자산을 생성할 수 있습니다. 사용자는 자산의 형태, 이름, 총량을 정의할 수 있고 해당 자산의 관리자 계정을 설정할 수 있습니다. 이런 자산을 만든 때는 수수료로 일정양의 NEO를 소모되며, 현재 가격은 10,000GAS입니다. (테스트 네트워크 요금은 메인 네트워크 요금의 1%입니다)

#### 자산 배분 (Distribute assets)

자산을 만든 사람이 정한 총 자산 한계 내에서, 사용자는 특정 주소로 자산을 발행(issue)할 수 있습니다. 자산 배분에는 스몰 코인(GAS)으로 지불되는 수수료가 필요한데, 현재 수수료는 500GAS입니다. (테스트 넷의 수수료는 메인 넷 수수료의 1%입니다.) 

#### 선거 (Election)

네오 검증자(NEO validator)가 되고 싶은 사람들은 선거에 등록해야 합니다. 일정량의 보증금을 NEO로 냄으로써 검증자의 자격을 취득할 수 있습니다. 현재 이 기능은 적용되고 있지 않으며 추후 업데이트 될 것입니다.

#### 투표 (Vote)

네오를 소유한 사람들은 검증자 후보들에 대한 투표권을 가지게 되며, 이 투표 결과에 따라 검증자가 결정됩니다. 현재 이 기능은 적용되고 있지 않으며 추후 업데이트 될 것입니다.

#### 광역 전송 (네트워크에 뿌리기, Broadcast)

서명을 완료한 후 해당 전송 정보는 전체 네트워크에 뿌려지며, 노드에 의해 확인됨으로써 전송이 완료됩니다. 그 때 이 기능은 서명을 통해 나타납니다(appear).

#### 주소 모니터 (Monitor address)

상대방의 주소를 모니터링 목적으로 가져오기를 하면, 사용자는 해당 주소의 자산을 볼 수 있습니다.

## 지갑 (Wallet)
### 지갑 데이터베이스 만들기 (Create the wallet database)

(1) ‘지갑(Wallet)’을 클릭하고 ‘지갑 데이터베이스 만들기(create the wallet database)’를 클릭하면 ‘새지갑(new wallet)’페이지가 나타납니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_2.png)

(2) ‘탐색(Browse)’를 클릭 한 후 지갑 파일이 저장될 위치를 선택합니다. 그리고 파일 이름을 정한 후 ‘저장(Save)’를 클릭합니다.

![image](https://github.com/neo-project/docs/blob/master/es-es/node/assets/gui/gui_3.png)

(3) ‘패스워드(password)’를 입력한 후 ‘패스워드 재입력(repeat password)’을 한 다음 저장하면 여러분 자신만의 패스워드가 생성됩니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_4.png)

(4) ‘Ok’를 클릭하면 지갑이 성공적으로 생성되며, 디폴트 값으로 표준 계정도 같이 만들어 집니다. 유념하실 부분은 체인지 메커니즘의 역할 때문에, 디폴트 값으로 자산의 나머지 부분은 처음 주소로 이전됩니다. 그렇기 때문에 해당 프라이빗 키와 지갑을 백업해두어야 합니다. 

### 지갑 데이터베이스 열기 (Open the wallet database)
(1)	매번 클라이언트가 실행될 때마다, 사용자는 ‘지갑 파일 열기(open wallet database)’를 클릭해서 지갑을 열어야 합니다. 다음 그림을 참고하세요 :

![image](https://github.com/neo-project/docs/blob/master/assets/gui_5.png)

(2) ‘탐색(Browse)’를 클릭하고(디폴트 값은 가장 최근에 사용한 지갑 파일입니다) 패스워드를 입력한 후 ‘Ok’를 누르면 지갑이 열립니다. 유념하실 부분은 지갑에서 에러가 표시되면 ‘리페어 모드(repair mode)’를 고르세요.

### 패스워드 변경 (Change Password)

지갑의 패스워드를 변경합니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_6.png)

패스워드를 변경했으면 지갑을 반드시 다시 백업하시기 바랍니다. 왜냐하면 예전 백업본의 패스워드는 변경되지 않았기 때문입니다.

### 지갑 인덱스 재건 (Rebuild the wallet index)

이 기능은 예외적인 경우에 지갑 파일의 에러를 고치는 것입니다. 아래 해당되는 경우, 지갑 인덱스를 재건할 필요가 있을 수 있습니다. 

1. 프라이빗 키를 가져오기 한 후.

2. 오랜 시간 동안 전송이 승인 안 되는 경우.

3. 지갑 자산에 에러가 표시되고 블록체인 정보가 맞지 않는 경우.

현재 블록 높이가 매우 높기 때문에, 지갑 인덱스를 재건하는 데는 일 분에서 수분까지 소요되니 기다리시기 바랍니다. 

### 계정 복구 (Restore the account)

이 기능은 지갑 파일과 해당 자산이 삭제 되었을 때, 해당 주소를 복구하는 것입니다. 유념하실 부분은 클라이언트 내에서 작업을 삭제하지 않으셔야 자산이 사라지는 경우를 방지할 수 있습니다.

## 거래 (Trade)

### 이전 (Transfer)

#### 토큰 자산 이전 (Token Asset Transfer)

(1) ‘전송(transaction)’을 클릭 한 후, ‘이전(transfer)’, ‘+’, 그리고 이전 정보를 입력하세요.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_10.png)

(2) ‘Ok’를 클릭하세요.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_11.png)

(3) ‘Ok’를 클릭하면 아래처럼 나옵니다.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/i.png)

#### 자본 자산 이전 (Equity asset transfer)

(1) ‘전송(transaction)’을 클릭 한 후, ‘이전(transfer)’, ‘+’, 그리고 이전 정보를 입력하세요.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/j.png)

(2) ‘Ok’를 클릭하세요.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/k.png)

(3) ‘Ok’를 클릭하면 아래처럼 나오는데, 서명할 부분이 나타납니다 :

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/l.png)

(4) 서명 기능에 대해서는 [서명](#sign)을 참고하세요.

#### 묶음 이전 (Batch transfer)

이 기능은 같은 자산을 여러 주소로 이전하는 데 사용됩니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_14.png)

데이터 포맷은 ‘주소 이전 양(address transfer amount)’의 형식입니다. (빈칸으로 구분)

![image](https://github.com/neo-project/docs/blob/master/assets/gui_15.png)

유념하실 부분은 데이터 포맷은 위와 같은 형식으로 엄격히 사용해야 하며 그렇지 않고 빈칸이 추가로 들어가게 되는 경우 이전(transfer)이 실패합니다.

#### 리마크 (사용자가 전송 정보에 쓰는 별도 노트 같은 것, Remarks)

이 기능은 네오 블록 체인상에 해당 전송 정보를 기록하는 데 사용됩니다. 현재 전송 정보는 [네오 블록체인 브라우져](https://www.antchain.xyz/)  에서 확인할 수 있습니다. 

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/o.png)

현재 메시지 포맷에는 규칙이 없습니다.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/p.png)

해당 전송에 대한 리마크는 브라우져를 통해 확인할 수 있습니다. 

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/oo.png)

### 거래

#### 거래 착수하기 (Initiating a deal)

(1) 상대방으로 보낼 자산의 상세 내용을 정하기 위해, 전송 시작 전에, 해당 자산의 거래를 할 양 측에서 전송 요청을 착수해야 합니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_18.png)

(2) 전송 요청을 하기 위해 ‘Ok’를 클릭합니다. 우리는 상대방에게서 오는 상세 계약 조건을 알아보기 위해 전송 요청을 사용할 수 있습니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_19.png)

#### 거래의 합병 (Merging of the deal)

(1) 전송 요청 착수 창을 닫으면, 전송 요청을 합병하는 인터페이스로 이동합니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_20.png)

(2) 이 인터페이스에서는 상대방의 전송 요청을 볼 수 있습니다. 상대방의 요청이 적법(legitimacy)한 지 확인(verify)하는 확인(verification)을 클릭하세요. 상대방 요청의 적법성 여부에 따라, 여러분은 승인하거나 거절할 수 있습니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_24.png)

(3) 여러분이 승인하는 경우, 양측 모두 다 서명한 뒤 전 네트워크에 뿌려집니다(broadcast). 자세한 내용은 [서명] ](#sign)을 참고하세요. <a id="sign"> </a>

### 서명 (Signature)
(1) 여기에는 상대방이 보낸 전송이 입력 박스에 붙여(paste)집니다. ‘서명(sign)’을 클릭하면 출력 데이터(output data)가 만들어집니다. 동시에 ‘광역전송(broadcast)’버튼이 표시됩니다.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/u.png)

(2) ‘광역전송(broadcast)’버튼을 클릭하면 ‘전송(transaction)’이 보내지고, 이 거래는 마무리되고 해당 ‘전송’이 확인됩니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_30.png)

<a  id="offline"></a>

## 고급 (Advanced)

### 오프라인 싱크 패킷 (Offline synchronous packet)

**다운로드**

아래에서 다운받을 수 있습니다. 
[https://www.neo.org/client/chain.acc.zip](https://www.neo.org/client/chain.acc.zip "chain.acc.zip")

URL을 입력하면 이 같은 패킷을 다운받을 수 있습니다. ![](https://github.com/YTkim7/docs/blob/master/ko-kr/node/assets/chain.acc.zip.png)

**추가 (Add)**

패킷의 압축을 풀고(unzip) 아래 그림처럼 폴더에 넣으세요.

![](https://github.com/neo-project/docs/blob/master/assets/gui_58.png)

**싱크**

클라이언트를 실행하면, 여러분은 클라이언트가 빠르게 싱크하는 것을 볼 수 있습니다. 아래 그림을 참조하세요.

![](https://github.com/neo-project/docs/blob/master/assets/gui_59.png)

**완료 (Complete)**

싱크가 어느 정도 이루어지면, chain.acc는 사라지고 싱크 속도는 느려집니다. 아래 그림을 참조하세요.

![](https://github.com/neo-project/docs/blob/master/assets/gui_60.png)





### 가스 추출 (Extractation of GAS)

GAS는 새로운 블록마다 생성되며, 네오 소유자들의 주소에 기록됩니다. (자산의 잔액에 맞는 숫자로 생성됩니다) 언제라도 네오 소유자는 해당 주소의 NEO 양에 맞는 GAS를 청구할 수 있습니다. 현재는 PC버전의 클라이언트만 GAS를 생성할 수 있습니다. 

절차는 아래와 같습니다. 

(1) 모든 NEO를 지갑으로 이전(transfer)합니다. (NEO를 현재 지갑으로 바로 보낼 수 있습니다) GAS 요청이 확정되면, GAS를 출금할 수 있습니다. (이 과정에 대한 상세 기술적인 내용은 백서를 참조하시기 바랍니다)

(2) ‘고급(advanced)’, ‘가스 요청(Claim GAS), ‘모두 요청(Claim All)’ 순서로 클릭합니다.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_37.png)

### 인증서 요청 (Request a certificate)

이 기능은 단지 인증서 신청(application) 파일만 생성합니다. 사용자는 관련된 디지털 인증 기관에 가서 인증서를 신청해야 합니다. 

‘고급(Advnaced)’, ‘인증서 요청(Request certificate)’을 클릭하시고 아래에 나오는 것 같이 양식을 채워 넣으세요.

![image](https://github.com/neo-project/docs/blob/master/assets/gui_39.png)

아래 그림처럼 생성된 파일이 나타납니다.

![image](https://github.com/neo-project/docs/blob/master/zh-cn/node/assets/y.png)

### 등록 자산 (Registered assets)

두 가지의 자산이 있습니다. 토큰 그리고 할당. 아래 예는 토큰의 경우입니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_43.png)

유념하실 부분은 자산을 등록하는 데에는 많은 수수료가 듭니다. (메인 넷 수수료는 10000GAS이며 테스트 넷은 100NEO입니다). 주의하시길 바랍니다.

### 자산 배분 (Distribute assets)

![image](https://github.com/neo-project/docs/blob/master/assets/gui_46.png)

자산 배분에는 많은 수수료가 필요합니다. (메인 네트워크 수수료는 500NEO, 테스트 네트워크는 5 NEO) 이점을 유념하셔서 가급적이면 한번에 배분하시길 바랍니다.

### 계약 전개 (Deploy Contract)

추가 예정

### 계약 발동 (Invoke Contract)

추가 예정

### 선거 (Election)

이 기능은 네오 블록체인 검증자(validator) 후보로 등록하는 데 사용됩니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/gui_57.png)

선거에는 고액의 수수료가 필요합니다. (메인 네트워크 수수료는 1000GAS, 테스트 네트워크는 10GAS) 이점 유념하시기 바라며, 아직 이 기능은 사용 가능하지 않습니다. 추후 업데이트될 예정입니다. 

### 4.8 부가기능 (Option)

아직 없음.

## 도움말 (Help)

### 도움말 보기 (View help)

아직 없음

### 공식 웹 사이트 (Official website)

클릭하시면 네오 공식 웹 사이트로 이동합니다. 

### 개발자 툴 (Developers tools)

추가 예정

### 네오에 대해 (About NEO)

네오 클라이언트의 현재 버전이 나타납니다.
