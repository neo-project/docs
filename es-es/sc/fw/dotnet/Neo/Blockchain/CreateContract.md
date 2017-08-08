# Método CreateContract(byte[], byte[], byte, bool, string, string, string, string, string)

Al llamar a este método en un contrato inteligente se puede emitir un nuevo contrato inteligente.

El método actua como proxy para PublishTransaction en la versión 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../Neo.md)

Assembly: Neo.SmartContract.Framework

## Sintaxis

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Contract CreateContract (byte[] script, byte[] parameter_list, byte return_type, bool need_storage, string name, string author, string email, string description)
```

parámetros:

Script: código del contrato, de tipo array de bytes.

Parameter_list: Lista de parámetros, de tipo array de bytes. Para más información ver [Parámetros y valores de retorno de un contrato inteligente](../../../../tutorial/Parameter.md).

Return_type: valor de retorno, de tipo byte. Para más información ver [Parámetros y valores de retorno de un contrato inteligente](../../../../tutorial/Parameter.md).

Need_storage: la necesidad o no del almacenamiento permanente, de tipo boolean.

Name: el nombre del contrato inteligente, de tipo string.

Version: número de versión, de tipo string.

Author: nombre del autor, de tipo string.

Email: correo electrónico del autor, de tipo string.

Description: descripción del contrato inteligente, de tipo string.

Valor de retorno: El contrato inteligente publicado, de tipo [Contract](../Contract.md).

## Ejemplo

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // fill in the contract script here
        byte[] script = new byte[] {116, 107, 0, 97, 116, 0, 147, 108, 118, 107, 148, 121, 116, 81, 147, 108, 118, 107, 148, 121, 147, 116, 98, 108, 118, 107, 148, 114, 117, 98, 3, 0, 116, 0, 148, 140, 108, 118, 107, 148, 121, 97, 116, 140, 118, 108, 118, 108, 117, 108, 118, 140, 107, 148, 108, 117, 108, 118, 140, 107, 148, 109, 108, 117, 102}
      
        byte[] parameter_list = {2, 2};
        Byte return_type = 2;
        Bool need_storage = false;
        String name = "Addition contract example";
        String version = "1";
        String author = "chris";
        String email = "chris@abc.com";
        String description = "This is an addition contract, the incoming two integers, the contract adds to the two integers, returns an integer";
      
        Blockchain.CreateContract (script, parameter_list, return_type, need_storage, name, version, author, email, description);
    }
}
```



[Volver arriba](../Blockchain.md)
