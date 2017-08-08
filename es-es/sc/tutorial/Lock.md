# Ejemplo de contrato inteligente - Lock (Bloqueo de contrato)

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class Lock : FunctionCode
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (timestamp > header.Timestamp) 
            return false;
        return VerifySignature(pubkey, signature);
    }
}
```

El contrato implementa una función que que especifica una determinada marca de tiempo (timestamp). Antes del tiempo especificado, nadie está autorizada a retirar cualquier activo del contrato. Una vez alcanzado el tiempo indicado, los propietarios del contratos puede retirar los activos.

La hora actual se obtiene en el código a través del ultimo bloque de la blockchain (puede haber un error/diferencia de 15 segundos). Para más detalles, consultar [clase Blockchain](../fw/dotnet/Neo/Blockchain.md), [clase Header](../fw/dotnet/Neo/Header.md).

Este contrato hereda de `FunctionCode`, por lo que este contrato puede ser desplegado en la blockchain para que otros puedan invocarlo. Si desea implementar un contrato de tiempo de ejecución local, consulta [Lock2](Lock2.md)
