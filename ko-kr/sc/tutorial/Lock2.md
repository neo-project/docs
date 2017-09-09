# 자물쇠 계약 사용하기 (Deploying Lock Contract)

이 설명을 읽기 전에 아래 설명서들을 먼저 읽으시길 바랍니다.

[C#으로 NEO 스마트 계약 작성하는 법](../ getting-started.md)

[NEO 스마트 계약 설명서](../ tutorial.md)

[스마트 계약 예재 - 자물쇠(lock)](Lock.md)

이제부터 독자들이 스마트 계약에 대한 기본지식은 가지고 있다고 가정하겠습니다. 여기서는 주소를 가지고 있는
지갑에 대해 어떻게 자물쇠 계약을 실행하는 지에 대해 설명하겠습니다.

덧붙여서, 이 설명서는 스마트 계약 2.0에 기반을 두고 있습니다. [GitHub](https://github.com/neo-project/neo-gui/releases)
에서 최신 버젼의 **테스트 네트워크 클라이언트**를 다운 받으시길 바랍니다.

추신 : 현재 시점에서 가장 최신 버젼의 **테스트 네트워크 클라이언트**의 위치는 다음과 같습니다 :
[Neo-GUI-v2.0.1](https://github.com/neo-project/neo-gui/releases/tag/v2.0.1).

> [!노트]

> 아직 메인 네트워크에는 스마트 계약2.0이 적용되지 않았기 때문에 아래에서 나오는 것들은 **테스트 네트워크**상에서
실행될 것입니다. 만약 메인 네트워크에서 실행시킬 경우 작동하지 않습니다.

## 지갑 만들기

이 과정은 매우 간단합니다. PC버젼의 클라이언트를 열어서 '지갑'(wallet)을 클릭한 다음 '지갑 데이터베이스'를 클릭하세요,
그런 다음 지갑 저장 장소를 선택하시고 지갑 이름과 암호를 설정하시길 바랍니다.

![그림 락2-1](/assets/lock2_1.png)

## 퍼블릭 키 (Public Key) 얻기

새롭게 만들어진 지갑은 자동적으로 표준 계정을 생성하며 계정(account)을 오른쪽 클릭한 다음 개인 키(Private Key)를 확인하고
아래에서 나오는 것처럼 두번째 줄에서 퍼블릭 키를 복사하세요


![그림 락2-2](/assets/lock2_2.png)



> [!주의]
> 개인 키를 절대 표시하기 하지 마시고 모자이크 처리하세요.

여기서 여러분은 퍼블릭 키를 바이트 어레이(Byte Array)로 변경하는 로컬 프로그램을 작성할 것입니다.
C#코드는 아래와 같습니다.


```c#
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 这里替换为上一步复制的公钥
            byte[] b = HexToBytes("0285eab65f4a0126e4b85b4e5d8b7e303aff7efb360d595f2e3189bb90487ad5aa");
            foreach (var item in b)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();
        }

        static byte[] HexToBytes(string hexString)
        {
            hexString = hexString.Trim();
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
    }
}
```

이 코드를 실행하면 화면에 퍼블릭 키로부터 변환된 바이트 어레이가 출력됩니다. 나중에 사용해야 하니 복사해두시길
바랍니다.


## 스마트 계약 작성하기

다음의 스마트 계약 을 작성해서 스마트 계약 프로젝트 하나를 생성하겠습니다. 여기의 계약은 VerificationCode로 부터
상속되며 작성 목적은 지갑 파일 주소안의 연락처 계정에 대해 계약 인증 계정 생성입니다.


```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Lock : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            Header header = Blockchain.GetHeader(Blockchain.GetHeight());
            if (header.Timestamp < 1499328600) // 2017-6-6 18:10
                return false;
            // Paste the public key byte array here
            return VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature);
        }
    }
}
```

이 자물쇠 계약에서는 두가지 중요한 변수를 변경해야 하는데, 하나는 퍼블릭 키이며 나머지 하나는 자물쇠 시간(Lock time)입니다.


1. 계약 코드에서 퍼블릭 키의 바이트 어레이 변환 복사한 것을 붙여 넣으세요

2. 샘플 코드안의 자물쇠 시간을 변경하세요, 해당 자물쇠 시간은 유닉스 타임스탬프(Unix Timestamp)입니다. 온라인 툴을
사용하시려면 여러분이 계산하시면 됩니다. [유닉스 타임스탬프 온라인 변환](https://unixtime.51240.com/).


두 변수를 변경한 다음 해당 계약을 컴파일 하면 Lock.avm 파일이 만들어 집니다.



## 잠금 계약 실행 (Deploy Lockout contract)


계약을 실행시키기 위해 먼저 계약 스크립트(Contract Script)를 얻어야 합니다. 얻는 방법은 많으나 여기서는 아래의
바이트코드를 얻기위한 .avm파일을 읽어 C#코드를 활용하도록 하겠습니다.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

만약 스크립트 작성이 어렵게 느껴지시면 클라이언트의 '계약 실행'(Deploy Contract) 기능 중 바이트코드를
쉽게 얻는 방법이 있습니다.

고급(Advanced), '계약 실행'(Deploy Contract)을 차례대로 클릭한 다음 하단 오른쪽 코너에 있는 '로드'(Load)버튼을
클릭하세요. 먼저 만들어진 'Lock.avm'파일을 고르세요. 그림에 나오는 것 처럼 코드 박스에 계약 스크립트가 나오는 것을
볼 수 있습니다. 이걸 다시 복사하세요.

![그림 락2-3](/assets/lock2_5.png)


클라이언트의 계정 (Account) 탭을 아래에 있는 빈공간을 오른쪽 클릭한다음 '계약 추가 생성'(Create Contract Add),
'커스텀'(Custom)을 차례대로 클릭하시고 먼저 복사해 두었던 계약 스크립트를 상자안에 붙이시기 바랍니다.



![그림 락2-4](/assets/lock2_7.png)

여기서 하나의 조합 계정을 골라야 합니다.(좀 더 자세히 말하면. 퍼블릭/개인 키들을 조합할 필요가 있습니다.)
이 조합이 의미는 만약 해당 스마트 계약이 서명 실행을 필요로 하면 클라이언트는 서명하기 위해 조합 된
개인 키를 사용할 것을 뜻합니다. 이 과정에서 처음 과정으로 동일한 퍼블릭 키를 골라야 합니다. 그렇지 않으면
서명이 일치하지 않아 스마트 계약은 실행이 되지 않습니다. 이 계약에 서명 매개변수가 있기 때문에 매개변수 기입
형식 안에 00을 채워 넣으세요.(매개변수에 무엇을 채워 넣어야 하는 지 이해하기 위해서는 다음을 참조하세요.
[Parameter](Parameter.md). 먼저 나왔던 스크립트 코드를 채워넣으세요. 이 과정을 하고 나면, 아래 그림에서 처럼
해당 계약 주소를 볼 수 있을 것입니다.

![그림 락2-5](/assets/lock2_8.png)


## 테스트

아래는 스마트 계약 증명 계정을 테스트하는 부분입니다. 하나의 스마트 계약 증명 계정에서 자산을 전송할 때, 계약을 인증하고
나면 컨센서스 노드(Consensus Node)는 해당 스마트 계약을 실행합니다. 만약 검증이 성공적이면(결과가 참), 해당 전송이
확인됩니다. 그렇지 않으면 해당 전송은 미확인 상태로 남아 있을 것입니다. 여기서 다룰 테스트 방법은 한 계정에서 다른
계정으로 자산을 전송한 다음에 다시 반대 과정을 수행하는 것입니다.

> [! 노트]

> 테스트의 정확도를 확보하기 위해, 지갑에 아무 자산도 두지 마시길 바랍니다. 그렇지 않을 경우 여러분은 여러분이
해당 클라이언트의 변경점 찾기 알고리즘을 이해하지 못하고 그 계약 주소에서 오는 해당 전송을 모른다면 그 자산이 표준
주소에서 오는 것인지 다른 모르는 주소에서 오는 것인 지 알 수가 없습니다.


## 계약 주소로 자산 전송하기 (Transfer Assets to Contract Address)

**테스트넷**상의 지갑, 자산(assets) 순서로 열어서 특정양의 자산을 계약 계정으로 전송하세요.


## 계약 주소에서 자산을 다시 가져오기

여러분의 스마트 계약 계좌에서 자산을 전송하세요.

![그림 락2-5](/assets/lock2_11.png)

만약 위의 과정이 정확하면 자산이 전송되었을 때 아래처럼 나타납니다.

만약 현재 시간이 잠금 시간보다 적다면 해당 전송은 확인되지 않습니다. 즉 전송이 실패합니다.


'리빌드 인덱스'(Rebuild Index)를 클릭한 다음 5분이 지난 후에 미확인 전송은 사라지며, 해당 자산은 원래의 상태로
되돌아 갑니다.

현재 시간이 잠금 시간보다 클 경우, 전송은 성공적으로 수행됩니다.





