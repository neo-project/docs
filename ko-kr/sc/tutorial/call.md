# 계약 호출 (Contract Call)


```c#
[AppCall]("XXXXXXXXXX") // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```



스마트 계약에서 사용자는 이 방법은 통해 블록체인 상에 퍼블리쉬 된 다른 스마트 계약을 호출할 수 있습니다.

1. AppCall과 발동하길 원하는 계약의 스크립트 해쉬를 통해 C#에 선언을 추가합니다. 

2. 위의 예를 참조해서 해당 계약을 코드내에서 이송(call)합니다. 
