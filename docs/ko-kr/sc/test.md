# 스마트 계약 단위 테스트 (unit test)

이전의 문서들을 읽으셨으면 비주얼 스튜디오2015의 C#을 이용해서 스마트 계약을 작성하실 수 있습니다. 스마트 계약을 작성한 다음에 이 스마트 계약에 대한 단위 테스트는 어떻게 해야 할까요? 

## 단위 테스트 작성

예제로, 아래의 스마트 계약을 작성합니다. 이 계약은 기능코드(function code)에서 상속되며 3개의 파라미터를 가지며, 리턴 값은 정수(int)입니다.


```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Test1: FunctionCode
    {
        public static int Main (int a, int b, int c)
        {
            if (a> b)
                return a * sum (b, c);
            else
                return sum (a, b) * c;
        }

        public static int sum (int a, int b)
        {
            return a + b;
        }
    }
}
```

이제 컴파일 하면 ‘Test1.avm’파일이 만들어 집니다. 이제 단위 테스트 프로젝트를 만들어서 ‘Test1.avm’을 테스트 해봅시다.

먼저 .NET 프레임워크 4.6.2나 이후 버전과 비주얼 스튜디오로 C# 콘솔 앱(.Net Framework)프로젝트를 만들고, 레퍼런스에 ‘Neo.dll’과 ‘neon.dll’을 추가합니다. 

> [!주의]
> 위의 두 파일은 다음의 링크에서 다운 받아 컴파일 하면 생성됩니다 : 
 [Neo](https://github.com/neo-project/neo) 와 [neo-vm](https://github.com/neo-project/neo-vm).

> 다른 방법으론, 사용자 프로젝트에 NEO와 Neo.VM의 NuGet 패키지를 추가하면 됩니다. 사용자는 솔루션 탐색기(Solution Explorer )상의 계약 프로젝트를 오른쪽클릭해서 브라우즈로 이동, NEO를 찾아 필요한 패키지를 인스톨할 수 있습니다. 

 ```c#
using System;
using System.IO;
using System.Linq;
using Neo;
using Neo.VM;
using Neo.Cryptography;

namespace ConsoleApplication1
{
    class program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@ "C: \ ... \ Test1.avm"));

            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush(2); // corresponds to the parameter c
                sb.EmitPush(4); // corresponds to the parameter b
                sb.EmitPush(3); // corresponds to the parameter a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // start execution

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // set the return value here
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

컴파일 출력 : 실행 결과는 예상과 같이 14입니다.

주의 : 만약 변수(Parameters)를 전달하기 위해 위의 코드를 사용할 경우에는, 아래의 코드를 써서 사용자가 쉽게 변수를 전달하려면, 첫 번째 변수에 해당하는 스텍의 윗부분을 주목하세요. 


```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```

만약 위 스마트 계역의 리턴 값이 정수가 아니고 ‘bool’이나 다른 형태인 경우, 사용자는 그림에 나오는 것 같이 `engine.EvaluationStack.Peek (). GetBigInteger ()`를 다른 값으로 설정해야 합니다.

[](/assets/test_1.jpg)

------

### 📖 이 문서는 편집 중입니다. 

이 문서는 편집 중이며, 빠른 시일안에 최종본이 나올 예정입니다. 다른 문서들은 다음의 링크를 참조하세요 : 
[Github wiki](https://github.com/neo-project/neo/wiki) 또는 공식 홈페이지를 참조하시길 바랍니다. [NEO official website](http://www.neo.org)

네오는 오픈 소스 프로젝트입니다. 만약 여러분이 관심 있으면 개발자로써 Github에 pull request를 통해 참여하실 수 있습니다. 다음의 링크에서 프로젝트 내용을 확인하세요. 여러분들의 참여를 기다립니다. [github.com/neo-project/docs](https://github.com/neo-project/docs)
