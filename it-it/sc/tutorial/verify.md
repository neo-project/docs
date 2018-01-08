# Tutorial Autenticazione del Contratto

Questo tutorial é basato su Visual Studio 2017, per favore assicurati che il tuo Visual Studio sia aggiornato alla versione 2017. Inoltre, questo tutorial é basato sul dome di Smart Contract 2.0, Per favore scarica ed esegui il **test network** da [GitHub](https://github.com/neo-project/neo-gui/releases).

Al momento della stesura di questo documento, l'ultimo client **test network** indirizzo di download: [neo-gui-2.0.1](https://github.com/neo-project/neo-gui/releases/download/v2.0.1/neo-gui-windows.zip).

## Compilare gli script del contratto

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
namespace Neo.SmartContract
{
    public class Test : SmartContract
    {
        public static bool Main(byte[] signature)
        {
            return true;
        }
    }
}
```

> [!Nota]
> Se non sai come scrivere e generare scripts per smart contract, vedi  [Come usare C# per preparare uno Smart Contract](../getting-started.md)
>

Il contratto precedente sará compilato in Test.avm, Il suo contratto script (Test.avm dati binari) é:
 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

Imparerai come ottenere lo script del contratto per un file `.avm` successivamente in questo tutorial.

## Creare un wallet

Crea un nuovo wallet secondo il tutorial mostrato sotto:

![Creare un wallet](/assets/verify_1.png)

## Ottenere lo script del contratto

Ci sono molti modi per ottenere lo script del contratto, un modo é quello di leggerlo direttamente dal file `.avm` usando il codice C# seguente.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

Se non vuoi ottenere lo script del contratto tramite codice, allora il client `Deploy Contract` fornisce un modo semplice per ottenere il codice del contratto:

Cliccare su `Advanced`, `Deploy Contract`, cliccare sul bottone `Load` nell'angolo in basso a destra. Scegliere il file `Test.avm` generato precedentemente. Dovresti vedere lo script del contratto visualizzato nel box `Code`, come mostrato in figura. copialo.

![Ottenere lo script del contratto](/assets/verify_5.png)

## Creare un indirizzo del contratto

After creating your own wallet, click the right mouse button, and create a contract address with your generated contract script:

![Create a contract address](/assets/verify_6.png)

Bind the contract address to your account and fill in the corresponding parameters. Because our contract has a parameter for signature, you have to fill in `00` in `Parameter List` (for details, please see [Parameter](Parameter.md)), and then enter the contract script from previous step in the `Code` box. 

The reason to associate an account is to bind a contract with a public-private key pair, so when the contract needs to be signed, the client will automatically sign with the private key of the bound account. 

![Create a contract address](/assets/verify_7.png)

After clicking `OK`, the smart contract authentication account is created successfully.

## Testing

The following is a test of the smart contract authentication account, when transferring assets out of a smart contract account, the consensus nodes will execute the contract when validating the transaction. If the contract validation is successful (returns result `true`), then the transaction is confirmed. Until result `true` is received, the transaction will have status unconfirmed. The test method is to first transfer some assets to the contract authentication account, and then transfer it out.

> [!Note]
> In order to ensure the accuracy of the test, do not have any other assets in the wallet. Otherwise you may not know whether the asset was transferred from the standard account or transferred from the contract account, unless you understand the client's change search algorithm and can confirm that the transaction is transferred from the smart contract address.


### Transfer asset to contract address

Transfer a set amount of assets into your contract account:

![Transfer asset to contract address](/assets/verify_9.png)

### Transfer contract assets

Transfer assets out from your smart contract account:

![Transfer the contract amount](/assets/verify_10.png)



> [!Note]
> The balance of the assets in the client is the sum of the balance in the standard account and the balance in the contract address, that is, assets of all addresses combined. Whether or not you can use the assets in the contract address depends on the result of the smart contract execution, if the contract is successful (the result is `true`) then the asset can be transferred out, otherwise it cannot be transferred.
