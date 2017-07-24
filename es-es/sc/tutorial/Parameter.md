# Parámetros y valores de retorno de un contrato inteligente

En la llamada o release del contrato inteligente es necesario especificar los parámetros, estos son de tipo byte, definidos como sigue.

```c#
     /// <summary>
     /// Indicates the parameter type of the smart contract
     /// </ summary>
     public enum ContractParameterType: byte
     {
         /// <summary>
         /// signature
         /// </ summary>
         Signature = 0,
         Boolean = 1,
         /// <summary>
         /// Integer
         /// </ summary>
         Integer = 2,
         /// <summary>
         /// 160-bit hash value
         /// </ summary>
         Hash160 = 3,
         /// <summary>
         /// 256-bit hash value
         /// </ summary>
         Hash256 = 4,
         /// <summary>
         /// byte array
         /// </ summary>
         ByteArray = 5,
         PublicKey = 6,

         Void = 0xff
     }
```

