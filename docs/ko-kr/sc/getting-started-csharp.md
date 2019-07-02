---
typora-root-url: ..\..
---

### C#을 이용해서 NEO 스마트 계약(Smart Contract) 작성하기 

현재 스마트 계약을 개발하는 데 C#을 사용하길 권장합니다. (자바, 코트린, 고, 파이슨 자바스크립트를 포함한 다른 프로그래밍 언어들을 지원하고 향후 지원할 예정입니다)

여기에서는 C#개발 환경을 이용해서 NEO의 스마트 계약을 작성하는 간단한 설명을 통해 스마트계약의 프로젝트와 어떻게 컴파일 할 지에 대한 개념을 보여드리겠습니다.

   > [!주의]
   > 현재, 모든 프로젝트들은 비쥬얼 스튜디오 2017버전으로 업그레이드 되었습니다. 만약 2015버전을 쓰고 계시다면, 다음[VS2015를 위한 C#을 이용해 NEO의 인텔리전트 계약 작성하기](getting-started-2015.md)를 참조하시길 바랍니다. 

## 개발 툴 (Development Tools)

### 1. 비주얼 스튜디오 2017

여러분의 컴퓨터에 비주얼 스튜디오 2017을 설치하셨으면 ‘.NET 크로스 플랫폼 개발’을 확인하세요. 설치할 때 생략하셨을 수 있습니다. 

다운로드 와 인스톨 :

[Visual Studio download address](https://www.visualstudio.com/products/visual-studio-community-vs)

인스톨 과정은 매우 간단합니다. 다음 과정을 하나하나 따라 하시면 됩니다. 반드시 ‘.NET 크로스 플랫폼 개발’을 체크하셔서 설치하셔야 합니다. 그렇지 않을 경우 스텝#3의 neo-vm 프로젝트를 열수 없습니다. 설치 과정은 대략 10분에서 한 시간 정도 소요됩니다.  


![.NET 코어 크로스 플랫폼 개발 툴 셋 설치하기](https://github.com/neo-project/docs/blob/master/assets/install_core_cross_platform_development_toolset.png)

### 2. 네오 계약 플러그인 (NeoContractPlugin)

인스톨 하기 :

비주얼 스튜디오 2017을 실행하신 다음, ‘익스텐션과 업데이트’를 클릭하시고, 왼쪽 창의 ‘온라인’탭을 클릭하셔서 회면 위 오른쪽 탐색 창에서 NEO를 찾으신 다음에 네오계약플러그인(NeoContractPlugin)을 다운받으세요. (인터넷에 연결되어 있어야 합니다)

![네오스마트계약 플러그 인 다운로드 및 인스톨하기](https://github.com/neo-project/docs/blob/master/assets/download_and_install_smart_contract_plugin.png)

### 3. 네오 컴파일러 (neo-compiler)

인스톨 후 설정하는 과정:

깃허브(Github)에 있는 [네오컴파일러](https://github.com/neo-project/neo-compiler) 프로젝트를 다운받은 다음에 비주얼 스튜디오 2017을 실행시켜서 네온(neon)프로젝트를 퍼블리쉬하세요.


![네오 컴파일러 msil 프로젝트 퍼블리쉬하기](https://github.com/neo-project/docs/blob/master/assets/publish_neo_compiler_msil_project.png)

![퍼블리쉬 와 프로파일 세팅](https://github.com/neo-project/docs/blob/master/assets/publish_and_profile_settings.png)


릴리즈를 성공적으로 하셨으면 `bin\Release\PublishOutput` 폴더에 neon.exe파일이 생성됩니다. 

이제 이 폴더의 위치를 실행 경로(execution path)에 추가해야 합니다. 이 경로는 시스템 변수이기 때문에 여러분의 운영체제에서 커맨드 라인이나 터미널 창을 통해 확인하시길 바랍니다.

**윈도우 10 과 윈도우 8:**

 탐색하는 부분에서 시스템(제어판)을 찾아 클릭하시고 고급 시스템 설정(advanced system setting)링크를 클릭한 다음, 환경 변수(Environment Variables)를 클릭하세요. 시스템 변수 부분(System Variables)에서 경로 환경 변수(PATH environment variable) 고르신 다음 ‘편집’을 클릭하셔서 경로 환경 변수가 없을 경우 새로 만들기(new)를 클릭하세요.

시스템 변수 편집창(아니면 새로운 시스템 변수)에서 경로 환경 변수 값을 지정하고 Ok를 클릭하세요. 이제 열려있는 모든 창을 닫으면 됩니다. 

**윈도우 7:**

 데스크탑에서 컴퓨터 아이콘을 오른쪽 클릭한 다음 등록정보(Properties)를 고르고, 고급 시스템 설정을 클릭하세요.


환경 변수를 클릭해서 시스템 변수 부분에서 경로 환경 변수를 찾아 선택한 다음 편집을 클릭하세요. 만약 경로 환경 변수가 없으면 ‘새로 만들기’를 선택하세요
  
 시스템 변수 편집 창(또는 새로운 시스템 변수)에서 경로 환경 변수 값을 지정한 다음 ‘ok’를 클릭하시고 열려있는 모든 창을 닫으면 됩니다. 

![실행 환경 변수 편집](https://github.com/neo-project/docs/blob/master/assets/edit_environmental_variables.png)

이제 명령어 또는 파워쉘을 실행한 다음 neon.exe를 입력합니다. 만약 에러가 없다면, 아래에서  처럼 버전 번호가 나타나고 환경 변수 설정이 성공적으로 끝납니다.

![파워쉘 환경 변수 설정 업데이트가 똑바로 실행된 경우](https://github.com/neo-project/docs/blob/master/assets/powershell_enviornment_variabled_updated_correctly.png)


주의 : 윈도우7 SP1 사용자들은 다음과 같은 에러가 나올 수 있습니다. Unhandled Exception: System.DllNotFoundException : Unable to load DLL 'api-ms-win-core-console-l2-1-0.dll' : The specified module could not be found". 이때 필요한 'api-ms-win-core-console-l2-1-0.dll'파일은 오직 윈도우8이나 이후 버전에서 구할 수 있습니다. 해당 파일을 찾아서 C:\Windows\System32에 복사해 넣으면 이 문제를 해결할 수 있습니다. 
 
## 프로제트 작성하기 (Create project)

위의 그럼에서 나오는 설정이 성공적으로 설치되고 나면, 사용자는 비주얼 스튜디오2017을 이용해서 네오계약(NeoContract) 프로젝트를 작성할 수 있습니다. 

![새로운 스마트 계약 프로젝트](https://github.com/neo-project/docs/blob/master/assets/new_smart_contract_project.png)

프로젝트를 작성하면 자동적으로 C#파일을 생성합니다. 디폴트 클래스는 아래에서 나오는 것 처럼 기능코드(function code)에서 상속됩니다 : 

![스마트 계약 기능 코드](https://github.com/YTkim7/docs/blob/master/ko-kr/sc/assets/smart_contract_function_code.png?raw=true)


## 프로젝트 컴파일 하기 (Compile the Project)

이제 스마트 계약을 규정을 위한 시작 방법들을 추가하기 위한 모든 것들이 준비되었습니다.

```c#
public class Contract1: FunctionCode
{
    public static void Main ()// Note that the main method to capitalize
    {
        
    }
}
```

컴파일이 성공적으로 진행되었을 경우, 여러분은 ‘bin/Debug’폴더에서 NEO 스마트 계약이 생성한 ‘SmartContract1.avm’파일을 볼 수 있습니다. 

![스마트 계약 컴파일](https://github.com/neo-project/docs/blob/master/assets/compile_smart_contract.png)


이제 여러분은 NEO 스마트 계약 개발 환경의 설정을 성공적으로 마쳤습니다. 다른 내용은 [NEO스마트 계약 설명서](tutorial.md)를 참조하시기 바랍니다. 
