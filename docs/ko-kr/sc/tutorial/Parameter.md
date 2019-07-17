### 스마트 계약 매개 변수와 출력 값 (Smart Contract Parameters and return values)

스마트 계약의 전개 또는 수행에 있어서 사용자는 스마트 계약의 매개 변수를 지정해야 합니다. 
스마트 계약의 매개 변수는 바이트 형태(byte type)이며 아래와 같이 정의됩니다. 


```c#
     /// <summary>
     /// Indicates the parameter type of the smart contract
     /// </ summary>
     public enum ContractParameterType: byte
     {
         /// <summary>
         /// signature
         /// </summary>
         Signature = 0,
         Boolean = 1,
         /// <summary>
         /// Integer
         /// </summary>
         Integer = 2,
         /// <summary>
         /// 160-bit hash value
         /// </summary>
         Hash160 = 3,
         /// <summary>
         /// 256-bit hash value
         /// </summary>
         Hash256 = 4,
         /// <summary>
         /// byte array
         /// </summary>
         ByteArray = 5,
         PublicKey = 6,

         Void = 0xff
     }
```

예제로 아래와 같은 스마트 계약을 참고하세요: 
```c#
public class Lock : FunctionCode
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //more...
    }
}
```

위의 계산(enum)에 의하면, int는 1을 대표하며, bool은 2 공용 키(Public Key)는 6 그리고 signature는 0을 대표합니다.

PC 클라이언트에서 매개 변수를 채울 때는, 각각의 변수에 2개의 16진수를 사용합니다.
이렇게 하면 위의 함수는 다음과 같이 쓸 수 있습니다 :  02010600, return: 01.
