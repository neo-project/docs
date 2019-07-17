# Пример смарт-контракта - Lock (контракт блокировки)

```c#
public class Lock : SmartContract
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (header.Timestamp < timestamp)
            return false;
        return VerifySignature(signature，pubkey);
    }
}
```

Контракт реализует функцию, которая задает определенную метку времени. До наступления указанного времени никто не имеет права выводить какие-либо активы из контракта. По истечении данного времени владельцы контракта могут вывести активы.

Текущее время, полученное контрактом, - это время нового блока в блокчейне (погрешность составляет около 15 секунд). Подробнее см. в [Blockchain class](../reference/fw/dotnet/neo/Blockchain.md), [Header class](../reference/fw/dotnet/neo/Header.md).

Для того чтобы другие могли вызвать данный контракт, его можно развертывать в цепочке. Если вы хотите провести локальное развертывание контракта с блокировкой по времени, то см. [Lock Contract](Lock2.md)
