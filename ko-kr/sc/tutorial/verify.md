# 계약 증명 설명서 (Contract Authentificatin Tutorial)

이 설명서는 비주얼 스튜디오2017을 기반으로 합니다. 그러니 먼저 사용하시는 비주얼 
스튜디오를 2017버전으로 업그레이드하세요. 그리고 스마트 계약2.0의 데모를 기준으로 하니 
최신 버전의 **테스트 네트워크**를 [GitHub](https://github.com/neo-project/neo-gui/releases)
에서 다운 받으시길 바랍니다. 

이 문서가 작성되는 시점에 가장 최신 **테스트 네트워크**를 다운받으실 수 있는 링크는 
다음과 같습니다. 

[Neo-GUI-v2.0.1](https://github.com/neo-project/neo-gui/releases/tag/v2.0.1)

## 컴파일 '계약' 스크립트 (Compile Contract Script)

```c#
using NEO.SmartContract.Framework;
using NEO.SmartContract.Framework.Services.NEO;
using NEO.SmartContract.Framework.Services.System;
namespace NEO.SmartContract
{
    public class Test : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            return true;
        }
    }
}
```

> [!주의]

> 만약 계약 스크립트를 작성/생성에 관해 모를 경우 다음을 참조하세요.
> [C#을 이용해서 스마트 계약 작성 하기](../getting-started.md)

위의 '계약'을 컴파일 하면 Test.avm이 생성되며 해당 계약 스크립트(Test.avm 바이너리 데이터)는
다음과 같습니다 : 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

이 설명서 후반부에서는 .avm파일 작성을 위한 계약 스크립트를 획득하는 것에 대해 배우게
될 것입니다. 

## 지갑 만들기 (Create a Wallet)

아래를 참조해서 하나의 새로운 지갑을 만들어 보세요.

![Create a wallet](/assets/verify_1.png)

## '계약' 스크립트 획득하기 (Obtatining the Contract Script)

여러 경로로 '계약' 스크립트를 입수할 수 있습니다. 그 중 하나는  아래와 같이 C#코드를 
사용한 .avm파일로 부터 직접 읽어들이는 것입니다. 

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

만약 여러분이 코딩을 통해 스크립트 입수를 원하지 않는다면 '계약'코드를 획득하는 다른 
단순한 방법은 클라이언트의 "계약 이행"(Deployment Contract)를 통하는 것입니다. 

PC버전의 클라이언트에서, '고급'(Advanced), '계약 이행'을 차례대로 클릭해서 하단부 오른 쪽
코너에 있는 "Load"를 클릭해서 Test.avm파일을 선택하세요. 그러면 "코드"(Code)박스에 해당 '계약'의 스크립트가 아래 에서 보시는 것처럼 표시됩니다. 나중에 사용해야 하니
이 코드 스크립트를 복사하세요.

![Abtaining the contract script](/assets/verify_5.png)

## '계약' 주소 만들기 (Create a contract address)

여러분의 지갑을 만든 다음, 마우스 오른쪽 버튼을 클릭해서 여러분이 생성한 계약 스크립트에
맞는 계약 주소를 생성하세요.

 ![Create a contract address](/assets/verify_6.png)

해당 '계약' 주소를 여러분의 계정에 할당시킨 다음 해당되는 매개변수를 채워넣으세요. 우리가
사용하는 '계약'은 서명 변수를 가지고 있기 때문에 '매개변수 리스트'(Parameter List)안에 "00"을
채워넣어야 합니다. (상세내용은  [여기](Parameter.md)를 참조하세요) 그런 다음 "코드"(Code)박스에 이전 과정에서 생성된 '계약' 스크립트를 입력하세요.

계좌를 결합하는 이유는 '계약'을 한 쌍의 퍼블릭-개인 키와 묶기 위함입니다. 그렇게 함으로써
'계약'에 서명이 필요할 때, 클라이언트는 묶인 계정의 개인 키를 가지고 자동적으로 서명을 
수행합니다. 

![Create a contract address](/assets/verify_7.png)

'Ok'를 클릭하고 나면, 스마트 계약 증명 계정이 성공적으로 생성됩니다. 


## 테스트 (Testing)

아래는 스마트 계약 증명 계좌를 테스트하는 부분이며 이 과정은 스마트 계역 증명 계좌가 자산을 전송할 때 부터 컨센서스 노드(Consensus Node)가 해당 '계약'을 검증/실행 하는 때까지 다룹니다. 만약 해당 계약 검증이 성공적이면(결과가 참(True)) 해당 전송이 확인됩니다. '참'이라는 결과가 수신될 때까지, 해당 전송은 미확인 상태로 남아있게 됩니다. 테스트 방법은 먼저 자산을 해당
'계약' 증명 계좌로 전송하고 그다음 이행합니다. 

>[!주의]

> 테스트의 정확도를 확보하기 위해, 해당 지갑에 여타의 다른 자산을 두지 마세요. 그렇지 않을 경우 여러분이 클라이언트 검색 알고리즘에 대한 이해가 없고 그 전송이 해당 스마트 계약 주소에서 온다는 확인이 안되면 그 자산이 표준 계정에서 오는 지 아니면 해당 계정에서 오는 지 구분할 수 없습니다. 


### '계약' 주소로 자산 전송 (Transfer asset to contract address)

일정한 양의 자산을 여러분의 계약 계좌로 전송하세요.

![Transfer asset to contract address](/assets/verify_9.png)


### 계약 자산 전송 (Transfer contract assets)

여러분의 스마트 계약 계좌에서 자선을 전송하세요.

![Transfer the contract amount](/assets/verify_10.png)

>[!주의]

> 클라이언트의 자산 잔고는 표준 계좌와 해당 '계약' 계좌 자산 잔고들의 합(sum)입니다.  
> 이는 모든 주소의 자산들이 결합된 것을 의미합니다. 해당'계약' 계좌의 자산을 사용하고 
말고 여부는 해당 스마트 계약의 실행여부에 달려있습니다. 만약 해당 계약이 성공적이면 (결과가 참) 자산은 외부로 전송되며 그렇지 않으면 전송되지 않습니다. 

