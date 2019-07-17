# Asset.Renew Method (byte[])

Für die Erneuerung von Assets. 

Diese Methode ist neu in Version 2.0, nach der Registrierung muss man für das Asset eine jährliche Gebühr bezahlen. Falls diese Gebühr nicht bezahlt wird, wird das Asset in den frozen state versetzt.

Wenn das Asset abgelaufen ist, ist es notwendig das Asset zu erneuern. Wenn das Asset sich nicht im Zustand frozen befindet und erneuert wird, wird das Datum ab dem Ablaufdatum erneuert. Wenn sich das Asset im Zustand frozen befindet, wird eine Erneuerung ab dem Datum des Bezahlens durchgeführt. Dadurch kann es keinen Verzug beim Erneuern geben.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern uint Renew (byte years)
```

Parameter: Erneuerungszeitraum, ein Jahr ist gleich 2,000,000 Blocks, Byte Type.

Rückgabewert: Die Höhe der Blocks bis wohin das Asset nach der Erneuerung benutzt werden kann.

## Beispiel

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Taking NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Back](../Asset.md)
