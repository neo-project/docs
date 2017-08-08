# 스마트 계약 예제 - HelloWorld

```c#
public class HelloWorld : FunctionCode
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

이 저장 클래스 (Storage Class)는 개인적인 계약 저장 지역(Privete Contract Storage Zone)을 수정하는 정적 클래스(Static Class)입니다. 이 저장 .Put () 방법은 사용자가 키 밸류 (Key Value)내의 개인 저장 공간에 정보를 저정하게 해줍니다. 상세 내용은 다음을 참조하세요.

 [Storage class](../fw/dotnet/neo/Storage.md)

완성된 코드를 보시려먼 [Github](https://github.com/neo-project/examples)를 참조하시길 바랍니다. 

