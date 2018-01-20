# Metodo (byte[]) Asset.Renew 

Per il rinnovo dell'asset.

Il metodo nella versione 2.0 è nuovo; dopo la registrazione, gli asset dovranno pagare una commissione annuale, altrimenti entrerà nello stato di congelamento.

Quando l'asset scade, è necessario rinnovare l'asset. Quando l'asset non è congelato, la commissione di rinnovo estenderà la data da quella di scadenza dell'asset. Quando l'asset è congelato, la commissione di rinnovo sarà considerata dal punto di pagamento. Perciò, non ci saranno arretrati dopo aver pagato la commissione di rinnovo.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public extern uint Renew (byte years)
```

Parametri: Periodo di rinnovo, un anno equivale a 2,000,000 blocchi, tipologia di byte.

Valore restituito: L'altezza del blocco fino alla quale è possibile utilizzare l'asset dopo il rinnovo. 

## Esempio

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



[Indietro](../Asset.md)
