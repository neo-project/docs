# Ejemplo de contrato inteligente - Lock (lock)

```c#
public class Lock : FunctionCode
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (timestamp > header.Timestamp) return false;
        return VerifySignature(pubkey, signature);
    }
}
```

El contrato implementa una función que que especifica un timestamp que no se puede obtener del contrato hasta que el tiempo del sistema de la blockchain alcance un tiempo determinado, una vez alcanzado el tiempo especificado por la blockchain, el titular del contrato puede retirar los fondos.

El tiempo actual es obtenido en el código por el tiempo del último bloque de la blockchain (el error es de unos 15 segundos). Para más detalles, ver [clase Blockchain](../fw/dotnet/AntShares/Blockchain.md), [clase Header](../fw/dotnet/AntShares/Header.md).
