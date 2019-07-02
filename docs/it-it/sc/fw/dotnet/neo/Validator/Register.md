# Metodo Validator.Register (byte[])

Registrarsi come bookkeeper. Questa è solo la registrazione, avrai bisogno di voti per essere selezionato.

Questo metodo sostituisce RegisterTransaction nella versione 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## sintassi

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Validator Register(byte[] pubkey)
```

Parametri:

pubkey：Chiave pubblica come  array di byte di lunghezza 33.

Valore restituito: [Validatore](../Validator.md)

## Esempio

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = new byte[] { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        var result = Validator.Register(pubKey);
    }
}
```



[Indietro](../Validator.md)
