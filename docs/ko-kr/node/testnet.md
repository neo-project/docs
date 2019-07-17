# 테스트 네트워크 (Test network)

테스트 넷은 유저가 프로그램을 개발/실행/테스트 할 수 있는 환경입니다. 테스트 넷 상의 테스트 프로그램들은 테스트 넷 GAS 요금을 초래합니다. (메인 넷의 GAS가 아님!!). 공식 웹 사이트에 있듯이 테스트 넷 상의 NEO와 GAS는 무료로 사용 가능합니다.

테스트 넷 상의 모든 블록체인들은 메인 넷과 관련이 없습니다. 만약 여러분이 간단한 스마트 계약을 개발하거나, 자신을 등록코자 할 경우 테스트 넷 상에서 충분히 진행할 수 있습니다. 테스트가 완료된 후, 메인 넷으로 옮겨 온라인에서 실행할 수 있습니다. 

개발자 분들은 테스트 넷 상의 GAS를 (여기)(https://www.neo.org/Testnet/Create) 서 신청하세요

If you are a developer, you can ask for GAS on the TestNet here: https://www.neo.org/Testnet/Create

## 테스트 넷 특징 (TestNet characteristics)

1. 자산 등록, 자산 배분, 계약 실행 등 (실제 돈을 사용하지 않음)
2. 광역 전개 가능한 인터넷 환경 (Globalized deployment in the Internet environment)
3. 네트워크 블록 테스트 ; 블록체인 브라우저에서 전송 및 다른 정보를 손쉽게 확인 가능.
4. 누구나 사용할 수 있는 테스트 환경에서 스마트 계약 전개
5. 테스트 넷에서 실제 환경에서의 상업적인 어플리케이션은 사용 할 수 없음.

## 클라이언트 다운로드 (Client Downloads)

테스트 네트워크의 클라이언트는 메인 네트워크의 클라이언트와 같습니다. 클라이언트의 설정파일을 변경하면 해당 클라이언트는 테스트 넷 용도로 변환됩니다..

참조: [네오 노드 소개](introduction.md).

|      | Neo-GUI                        | Neo-CLI                        |
| ---- | ---------------------------------------- | ---------------------------------------- |
| 배포 | [공식 웹 사이트](https://www.neo.org/download) or [Github](https://github.com/neo-project/neo-gui/releases) | [Github](https://github.com/neo-project/neo-cli/releases) |
| 소스코드 | [Github](https://github.com/neo-project/neo-gui) | [Github](https://github.com/neo-project/neo-cli) |

## 테스트 네트워크 변경 방법 (Method of switching to test network)

1. 아래 나오는 것처럼 `protocol.testnet.json` 폴더 아래 있는 프로그램 폴더의 내용물들을 복사 해서 ` protocol.json`아래 붙여넣기 합니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/testnet_1.png)

2. 그림에 나오는 것처럼 `neo-gui.exe.testnet.config`폴더에 있는 내용물들을 복사헤서 `neo-gui.exe.config`에 붙여넣기 합니다. 

![image](https://github.com/neo-project/docs/blob/master/assets/testnet_2.png)

주의 : 노드가 CLI로 실행 중이면, `config.testnet.json` 의 내용물을 ` config.json`.에 복사해 넣습니다. 
