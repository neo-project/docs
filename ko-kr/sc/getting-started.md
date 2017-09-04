### C#을 이용해서 Neo 스마트 계약 (smart contract)작성하는 방법

스마트 계약을 개발하는 데 있어 현재 C# (Java, Kkotlin, Go, C/C++, Python, Javascript또는 다른 언어를 지원하지만) 을 추천합니다. 

여기에서 Neo 스마트 계약 작성을 위한 C# 개발 환경(development environment)을 구성하는 간단한 설명을 다룰 것이며, 
개발자는 어떻게 컴파일 하는 지 그리고 어떻게 스마트 계약을 작성할 지에 대한 개념을 알 수 있습니다. 

 > [!Note]  
 > 현재 모든 프로젝트들은 비주얼 스튜디오 2017로 업그래이드 되었습니다. 만약 인텔리전트 계약(intelligent contract)작성에
비주얼 스튜디오 2015를 사용코자한다면, 여기를 참조하세요. 
[VS2015를 이용해 C#으로 ANS 스마트 계약 적성하기](https://github.com/CityOfZion/docs/blob/develop/en-us/sc/getting-started-2015.md)

## 개발 툴(Development Tools)

### 1. 비주얼 스듀디오 2017
이미 컴퓨터에 비주얼 스튜디오 2017버전을 인스톨 했고, .NET과 .NET 크로스 플랫폼 개발(Cross Platform Development)를 설치했다면
이부분은 생략가능합니다. 아래 링크에서 다운로드 받아 인스톨 하세요

[비주얼 스튜디오 다운로드 주소](https://www.visualstudio.com/products/visual-studio-community-vs)

인스톨 과정은 매우 단순합니다. 아래 절차를 따라 하나 하나 진행하면 되며 사용자는 반드시 .NET Core Cross-platform development의 인스톨을 
확인해야 합니다, 그렇지 않을 경우 Step#3에서 NeoVM을 열 수 없습니다. 이 인스톨 과정은 대략 10분에서 1시간이 소요될 수 있습니다.

![그림 1](/assets/install_core_cross_platform_development_toolset.png)

### 2. NeoContractPlugin 플러그인

인스톨 방법 : 

비주얼 스튜디오 2017을 실행 한 뒤, 도구(tools)를 열어, 확장 및 업데이트(Extension and Updates)를 클릭한 뒤, 온라인(Online)탭을 클릭하면 왼쪽에 창이 새로 뜨는데, 그 창의 오른쪽 위에 있는 박스에서 Neo를 찾아 NeoContractPlugin을 다운받습니다. (이부분에서 인터넷 연결이 필요함)

![그림 2](/assets/download_and_install_smart_contract_plugin.png)

### 3. neo-compiler

설치와 설정 과정은 다음과 같습니다 : 

[neo-compiler](https://github.com/neo-project/neo-compiler)을 Github에서 다운로드 한다음, 비주얼 스튜디오 2017에서  솔류션(Solution)탭을 열어 neon 프로젝트를 퍼블리쉬(publish)합니다. 

![그림 3](/assets/publish_neo_compiler_msil_project.png)
![그림 4](/assets/publish_and_profile_settings.png)

해당 릴리즈(release)가 성공적이면, 'bin\Release\PublishOutput' 에 'neon.exe'가 만들어집니다. 

이제 이 디렉토리를 실행 경로 (execution path)에 추가합니다. 이 경로는 각자의 컴퓨터마다 다르기 때문에 커맨드 라인이나 터미널 창을 통해 확인합니다. 

**윈도우10과 윈도우8 :**

찾기에서 제어판을 찾은 다음에 고급 시스템 설정(Advanced system setting)을 클릭한 뒤, 환경 변수(Environment variables)를 클릭한 다음 
경로 환경 변수 (PATH environment variable)을 찾아 고릅니다. 편집(Edit) 을 클릭합니다. 만약 경로 환경 변수 
(PATH environment variable)가 없으면 새로 만들기 (new)를 선택합니다. 시스템 환경 변수(System Variables) 편집 창에서 
특정 경로 환경 변수를 지정한 다음에 ok를 클릭합니다. 
다른 모든 창은 ok를 누르면서 다 닫습니다. 


**윈도우7 :**

데스크 탑에서 컴퓨터 아이콘을 오른쪽 클릭한 다음, 등록정보(Properties)를 클릭한 뒤, 고급 시스템 설정(Advanced system setting)을 고른 뒤
환경 변수(Environment variables)를 누릅니다. 환경 변수 부분에서 경로 환경 변수를 찾아 고른 뒤 편집(eidt)를 클릭합니다.
만약 경로 환경 변수 (PATH environment variable)가 없으면 새로 만들기 (new)를 선택합니다. 시스템 환경 변수(System Variables) 편집 창에서 
특정 경로 환경 변수를 지정한 다음에 ok를 클릭합니다. 
다른 모든 창은 ok를 누르면서 다 닫습니다. 

![그림 5](/assets/edit_environmental_variables.png)

이제 커맨드 창이나 파워 쉘을 실행단 다음, neon을 입력합니다. 만약 에러 메세지가 없으면 아래와 같이 버전 번호가 나타나며, 환경 변수 설정이 성공적으로 마무리 됩니다. 

![그림 6](/assets/powershell_enviornment_variabled_updated_correctly.png)

(주의) 윈도우7 SP1을 사용하는 경우 다음과 같은 에러 메세지가 나올 수 있습니다."Unhandled Exception: System.DllNotFoundException: Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll': The specified module could not be found".  이 때 필요한 파일인  'api-ms-win-core-console-l2-1-0.dll' 은 우윈도우8 이나 그 이후 버전에서만 찾을 수 있습니다. 이 에러는 해당 파일을 구한 뒤, C:\Windows\system32에 복사해 넣으면 해결될 수 있습니다. 

### 프로젝트 작성하기 (Create Project)

위의 인스톨 과정을 성공적으로 마친 다음, 사용자는 비주얼 스튜디오2017을 이용하여 Neo.SmartContract.Template 프로젝트를 작성할 수 있습니다. 

![그림 7](/assets/new_smart_contract_project.png)

프로젝트를 작성하면, 자동적으로 C#파일이 생성되는데, 아래 그림에서와 같이 디폴트 클래스(Default Class)는 펑션코드(Function Code)에서 상속됩니다. 

![그림 8](/assets/smart_contract_function_code.png)

### 프로젝트 컴파일하기 (Compile Project)

스마트 계약(Smart Contract)을 규정할 도입 부분을 추가할 모든 사전 준비사항이 끝났습니다.

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

사용자가 스마트 계약을 성공적으로 컴파일 했으면 bin/Debug 디렉토리에서 SmartContract1.avm 을 볼수 있는데, 이는 Neo smart contract로써 생성된 파일입니다. 

![그림 9](/assets/compile_smart_contract.png)

Neo smart contract 개발 환경 설정은 모두 끝났습니다. 더 궁금한 사항은 Neo smart contract tutorial을 참조하길 바랍니다. 




 





 

