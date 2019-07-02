# Parámetros y valores de retorno de un contrato inteligente

En la llamada de contrato inteligente es necesario especificar los parámetros, estos son de tipo byte, definidos a continuación:

```c#
namespace Neo.Core
{
    /// <summary>
    /// Parameter List
    /// </summary>
    public enum ContractParameterType : byte
    {
        /// <summary>
        /// Signature
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
        /// Byte array
        /// </summary>
        ByteArray = 5,
        PublicKey = 6,

        Array = 16,

        Void = 0xff
    }
}

```
Por ejemplo, para el siguiente contrato inteligente:


```c#
public class Lock : FunctionCode
{
    public static bool Main(int a, bool b, byte[] pubkey, byte[] signature)
    {
        //...
    }
}
```
Usando la enumeración anterior:

|Parámetro retorno|Tipo de parámetro|Valor|Hexadecimal|
 |---|---|---|---|
 |`bool Main`| Boolean | 1 | 01 |

|Parámetro función|Tipo de parámetro|Valor|Hexadecimal|
 |---|---|---|---|
 |`int a`| Integer | 2 | 02 |
 |`bool b`| Boolean | 1 | 01 |
 |`byte-array pubkey`| PublicKey | 6 | 06 |
 |`byte-array signature`| Signature| 0| 00 |

 

Al desplegar un contrato inteligente a través del cliente PC, `NEO-gui` hay que añadir 2 caracteres hexadecimales por cada parámetro. Los parámetros de la función anterior seria: **02010600** y el de retorno: **01**


