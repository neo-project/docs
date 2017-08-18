# 네오 노드의 설치와 전개 (Installation and deployment of NEO node)

앞서의 문서는 네오 네트워크의 노드를 위한 두 클라이언트에 대한 설명이었습니다. 하나는 [Neo-CLI](https://github.com/neo-project/neo-cli/releases) (개발자를 위한 커맨드 라인 클라이언트)이고 다른 하나는 [Neo-GUI](https://github.com/neo-project/neo-gui/releases) (고급 사용자를 위한 GUI클라이언트)입니다. 

컨센서스 노드 전개를 위해서는 윈도우와 리눅스 그리고 Docker에서 작동하는 크로스 플랫폼 프로그램인 ‘Neo-CLI’를 사용해야합니다. 

|                                   | Neo-CLI |
| --------------------------------- | ----------------- |
| Windows 7 SP1 x64                 | ✅                 |
| Windows Server 2008 R2 SP1        | ✅                 |
| Red Hat Enterprise Linux 7 Server | ✅                 |
| Ubuntu 14.04, 16.04, 16.10        | ✅                 |
| Debian 8                          | ✅                 |
| Fedora 23, 24                     | ✅                 |
| CentOS 7.1 & Oracle Linux 7.1     | ✅                 |
| openSUSE 13.2, 42.1               | ✅                 |
| Docker                            | ✅                 |

> [!주의]
> 현재 네오 노드는 Mac OS에서 정상적으로 작동하지 않습니다. 추후 Mac OS용 업데이트가 있을 예정이니 기다려 주시기 바랍니다. 


## 환경 실행 (Run the environment)

네오 노드를 실행하기 위해서는 [닷넷 코어 런타임 1.0.1](https://www.microsoft.com/net/download/core#/runtime) 또는 이후 버전을 설치해야 합니다. 

### 윈도우 시스템 인스톨 방법

윈도우 환경에서는 닷넷 코어 설치가 매우 쉽습니다. 여러분은 직접 다운로드 받아 실행하시면 됩니다. 

### 리눅스 시스템 설치 방법

다음은 레드햇 엔터프라이즈 리눅스 7 서버에 닷넷 코어를 인스톨하는 방법입니다.

> [!주의]
> 다른 버전의 리눅스 커널 배포판에 대한 설치방법은 다음을 참조하시기 바랍니다. [닷넷 코어 설치 설명서](https://www.snetnet/core#linuxredhat)


```
subscription-manager repos --enable = rhel-7-server-dotnet-rpms
yum install scl-utils
```

```
yum install rh-dotnetcore11
scl enable rh-dotnetcore11 bash
```

설치과정이 완료되면 여러분은 아래 명령어를 실행해서 닷넷 코어 환경이 성공적으로 설치되었는지 확인할 수 있습니다.

```
dotnet new console -o hwapp
cd hwapp
dotnet restore
dotnet run
```

결과적으로 “Hello World!” 출력 값을 보실 수 있으면 닷넷 코어가 성공적으로 설치된 것입니다.


## 네오 노드 설치

1. [Neo-CLI](https://github.com/neo-project/neo-cli/releases) 패키지를 깃허브에서 다운 받아 압축을 풉니다.


> [!주의]
> 여러분이 직접 Neo-CLI의 소스를 깃허브에서 다운로드 받아 컴파일 하시면, 컴파일 후 `dotnet neo-cli.dll`이 비정상적으로 실행되는 것을 보실 수 있습니다. 여러분은 libleveldb.dll 과 sqlite3.dll 두 파일을 찾아 dotnet neo-cli.dll과 같은 디렉토리에 복사해 두어야 합니다. 이 두 파일은 첫 번째 다운로드 패키지에서 찾을 수 있습니다. 

2. 커맨드 라인을 열어서 프로그램이 있는 디렉토리로 이동한 다음 아래 명령어를 실행해서 네오 노드를 시작하세요.

```
dotnet neo-cli.dll
```

Neo-CLI는 외부 접속을 위한 일련의 API들을 제공합니다. 만약 여러분이 API를 실행 주에 노드를 시작하고 싶다면 다음 코드를 실행하시기 바랍니다.
```
dotnet neo-cli.dll /rpc
```
3. 외부 프로그램이 노드 API에 접근하도록 하기 위해선 다음의 포트들이 방화벽에서 열려 있어야 합니다 : 10331-10334, 20331-20334
