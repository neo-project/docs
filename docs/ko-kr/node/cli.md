# CLI 명령어 참조 (Command Reference)

커맨드 라인을 열어서, 프로그램이 있는 폴더까지 이동합니다. 그런 다음 커맨드 라인 지갑(네오 노드)을 실행하기 위해 아래의 코드를 입력합니다. 

`dotnet neo-cli.dll`

이 설명서에서는 커맨드 라인 지갑의 모든 명령어들이 소개됩니다. 여러분은 지갑을 만들거나, 프라이빗 키(private key)를 내보내거나 들여보내거나, 컨센서스를 시작하고나 이전하는 등의 지갑의 조정에 있어 이 명령어들을 이용할 수 있습니다. 

먼저 커맨드 라인내의 여러 가지 명령어(command)들에 대해 알아보겠습니다. 커맨드 라인에서 ‘help’를 치고 리턴을 누르시면, 아래 화면과 같이 명령어들이 나옵니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/cli_2.png)

아래는 모든 명령어와 괄호에 대한 규칙을 설명합니다 : 
홑화살 괄호`<>`는 파라미터(parameter)를 가리킵니다.
대괄호`[]`는 부가적인(optional) 파라미터를 가리킵니다.
심볼 `|`는 파라미터 채우는 것을 나타냅니다. 어떤 형태든 가능합니다.
등호 `=` 표시는 부가적인 파라미터에 입력 값 없이 디폴트 값이 있는 것을 가리킵니다.

## 1. 콘솔 명령 (Console Instructions)

| 명령어      | 기능설명      |
| ------- | --------- |
| 버전 | 현재 소프트웨어 버전 |
| help    | 헬프(Help) 메뉴      |
| clear   | 클리어(Clear) 스크린      |
| exit    | 프로그램 나가기      |

## 2. 지갑 운영 (Wallet operation)

명령어 | 기능 설명 | 주석 |
| ---------------------------------------- | -------------------------------- | ------ |
| create wallet \<path> | 지갑파일 만들기 |
| open wallet \<path> | 지갑파일 열기 |
| rebuild wallet index | | 지갑파일 열어야 함 |
| list all the accounts in the wallet | | 지갑파일 열어야 함 |
| list asset | 지갑 안의 모든 자산 나열 | 지갑파일 열어야 함 |
| list key | 사용자 지갑내의 모든 퍼블릭 키 나열 | 지갑파일 열어야 함 |
| create address [n = 1] | 주소 만들기 / 주소 만들기 묶음 (batch) | 지갑파일 열어야 함 |
| import key \<wif\|path> | 프라이빗 키 가져오기 / 프라이빗 키 여러 개 가져오기 | 지갑파일 열어야 함 |
| export key \[address] [path] | 프라이빗 키 내보내기 | 지갑파일 열어야 함 |
| send \<id\|alias> \<address> \<value> [fee=0]| 특정 주소로 보내기 |지갑파일 열어야 함 |

아래 명령어들에 대한 자세한 설명이 있습니다.

👉 `인덱스 재건 (rebuild index)`

이 명령어는 지갑 인덱스를 재건하는 데 사용됩니다.
왜 지갑 인덱스를 재건해야 하나요?
지갑에는 지갑이 현재 싱크한 블록의 높이(height)를 기록하는 필드(field)가 있습니다. 새로운 블록이 생성될 때 마다, 지갑 클라이언트는 블록과 싱크해서 지갑내의 자산과 전송(transaction)을 업데이트합니다. 만약 현재 기록된 블록의 높이(height)가 100이라고 하고, 사용자가 명령어를 써서 프라이빗 키를 가져올 경우 지갑은 사용자의 자산을 블록높이 100에서부터 계산합니다. 만약 가져온 주소에 있는 ‘전송’이 블록 높이 100 이하에서 발생했을 경우, 그 ‘전송’과 해당 되는 자산은 그 지갑에 반영되지 않습니다. 이 경우 지갑 인덱스가 재건되어, 지갑으로 하여금 사용자의 자산을 블록높이 0부터 계산하게 해야 합니다. 

새로 만든 지갑은 지갑 인덱스를 재건할 필요가 없습니다. 지갑 인덱스를 재건하기 위해 단지 프라이빗 키만 가져오면 됩니다. 

👉 `주소 만들기 [n = 1]`

이 명령어는 새로운 주소를 만들 때 씁니다. 'create address 100' 이라고 입력하면 100개의 새로운 주소를 묶음으로 만듭니다. 이러한 묶음 만들기 (Batch Creation)로 만들어진 주소들은 자동적으로 내보내져서 address.txt 파일에 저장됩니다. 

👉 `키 [주소] 내보내기 [경로]`

사용자는 특정 프라이빗 키에 해당하는 내 보낼 주소를 지정할 수 있으며, 또한 내보내질 특정 파일을 지정할 수 있습니다.(아래 예를 참고하세요) 이 명령어는 지갑 패스워드 확인이 필요합니다.

키 내보내기

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b

Export key key.txt

Export key AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b key.txt

👉 `키 가져오기 <wif | 경로>`

프라이빗 키를 가져올 때, 사용자는 하나의 키만 가져올 지 올 수도 있고 다수의 키가 있는 파일을 가져올 수도 있습니다. 아래의 명령어들은 합법적(legal)입니다. 

Import key L4zRFphDJpLzXZzYrYKvUoz1LkhZprS5pTYywFqTJT2EcmWPPpPH

Import key key.txt

만약 프라이빗 키 포맷의 특정 파일이 있다면, 키 내보내기의 key.txt output을 참고하세요.

👉 `보내기(send) <id | alias> <address> <value> [fee = 0]`

총 네 개의 파라미터(parameter)들이 있습니다. 첫 번째 파라미터는 자산 ID이고 두 번째는 지불 주소(payment address), 세 번째는 이전 양(transfer amount)이고, 네 번째는 요금(fee)입니다(이 파라미터에 값이 없으면 디폴트 값은 0입니다). 명령어 실행 시 패스워드가 필요합니다. 예를 들면 다음 주소"AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b"로 100NEO를 이전하기 위해서 사용자는 아래의 명령어를 입력해야 합니다..

Send c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100

만약 여러분이 자산ID가 확실치 않다면, 지갑 내의 모든 자산을 볼 수 있는 list asset 명령어를 입력하세요.

## 3. 노드 정보 보기(View the node information)

명령어 | 기능 설명 |
| ---------- | ----------------------- |
show state | 블록 체인 싱크의 현 상태 표시
show node | 접속된 노드에 대한 주소와 포트 표시 |
show pool | 메모리 풀의 ‘전송’표시 (이 전송들은 zero confirmation 상태임)
## 4. 고급 명령어 (Advanced instructions)

명령어 | 기능 설명 |
| --------------- | ---- |
Start consensus | 컨센서스시작
컨센서스를 시작한다는 것은 해당 지갑이 권한을 가지고 있다는 것을 전제로 하며, 이 권한은 메인 넷 상에서 투표를 통해 부여됩니다. 만약 프라이빗 체인이 쓰이는 경우, 컨센서스의 퍼블릭 키는 `protocol.json`안에 세팅됩니다. 상세한 내용은 다음을 참조하세요. [프라이빗 체인](private-chain.md)
