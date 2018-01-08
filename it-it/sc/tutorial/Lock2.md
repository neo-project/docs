# Implementare un Lock Contract

Leggi i seguenti tutorial prima di leggere il seguente articolo:

[Come Scrivere Smart Contract NEO in C#](../getting-started-csharp.md)

[Tutorial Smart Contract NEO](../tutorial.md)

[Esempio Smart contract - Lock (lock)](Lock.md)

Assumendo che hai giá la conoscenza di base riguardo gli smart contracts, mosteremo come implementare un lock contract a un indirizzo usando il wallet.

In aggiunta, questo tutorial é basato sul demo di Smart Contract 2.0. Per favore scaricare l'ultimo **test network client** da [GitHub](https://github.com/neo-project/neo-gui/releases).

PS: In questo momento, l'ultimo **test network client** scaricabile é: [Neo GUI v2.2.0](https://github.com/neo-project/neo-gui/releases/tag/v2.2.0).

> [!Nota]
> Le seguenti operazioni saranno eseguite in **test network**. Perché la main network non ha ancora implementato Smart Contract 2.0, le seguenti operazioni nella main network falliranno.
> Al fine di usare la test net devi fare due cambiamenti nei files config: 
1. Estrai il client NEO GUI nella tua cartella. Noterai i files config.json, config.mainnet.json, config.testnet.json, protocol.json, protocol.mainnet.json, protocol.testnet.json. Di default, `config.json` e `protocol.json` sono identici al quelli della versione Mainnet.
2. Devi copiare il codice dai files della testnet nei files `config.json` e `protocol.json` potrai in tal modo accedere alla testnet invece della Mainnet (cioé copia e incolla `config.testnet.json` in `config.json`, e `protocol.testnet.json` in `protocol.json`).

## Creare un wallet

Questo step é veramente basico. Apri la versione del PC del client, clicca `wallet`, `create the wallet database `, seleziona la locazione di archiviazione del wallet e imposta il nome e la password del wallet.

![](../../../assets/lock2_1.png)

## Ottieni la chiave pubblica

Il nuovo wallet appena creato genererá automaticamente un account standard. Doppi clic destro sull'account, vedi la chiave privata, e copia la chiave pubblica dalla seconda linea, come mostrato in figura:

![](../../../assets/lock2_2.png)

> [!Attenzione]
> Per favore nota: Non divulgare la tua chiave privata.

Qui scriviamo un programma locale per trasformare la chiave pubblica in un array di byte, il C# é come segue:

```c#
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 这里替换为上一步复制的公钥
            byte[] b = HexToBytes("0285eab65f4a0126e4b85b4e5d8b7e303aff7efb360d595f2e3189bb90487ad5aa");
            foreach (var item in b)
            {
                Console.Write($"{item}, ");
            }
            Console.ReadLine();
        }

        static byte[] HexToBytes(string hexString)
        {
            hexString = hexString.Trim();
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
    }
}
```

Dopo averlo eseguito, lo schermo mostrerá l'array di byte creato dalla chiave pubblica. 

After running it, the screen will display the byte array created from the public key. Copy this down as we will be using it later.

## Write a smart contract

Create a smart contract project and write the following smart contract. 

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Lock : SmartContract
    {
        public static bool Main(byte[] signature)
        {
            Header header = Blockchain.GetHeader(Blockchain.GetHeight());
            if (header.Timestamp < 1499328600) // 2017-6-6 18:10
                return false;
            // Paste the public key byte array here
            return VerifySignature(new byte[] { 2, 133, 234, 182, 95, 74, 1, 38, 228, 184, 91, 78, 93, 139, 126, 48, 58, 255, 126, 251, 54, 13, 89, 95, 46, 49, 137, 187, 144, 72, 122, 213, 170 }, signature);
        }
    }
}
```

The lock contract has two important variables to change: the public key, and the lock time.

1. In the contract code, paste the previous copy of the public key byte array

2. Change the lock time in the sample code, which is a Unix timestamp. Calculate it yourself, you may want to use an online tool. [Unix timestamp online conversion](https://unixtime.51240.com/).

After replacing the two variables, compile the contract to get a Lock.avm file.

## Deploy lock Contract

To deploy the contract, we first need to obtain the contract script. There are many ways to do this. We can utilize the C# code below to read the .avm in order to get the bytecode.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

If you think writing a script for this is troublesome, the client's `Deploy Contract` function has a simple way to obtain the bytecode:

Click on `Advanced`, `Deploy Contract`, click on the `Load` button on the bottom right corner. Choose the `Lock.avm` file generated earlier. You should see the contract script displayed in the `Code` box, as seen in the figure. Copy this down again.

![](../../../assets/lock2_5.png)

In the client, under the `Account` tab, right click on the whitespace, select `Create Contract Add.`, `Custom`, and paste the contract script into the box:

![](../../../assets/lock2_7.png)


Here, we need to choose an associated account (to be specific, we are associating a pair of public/private keys). The association means that if the smart contract requires a signature operation, the client will use the associated private key to sign. In this step, we have to select the same public key as the first step, otherwise the signature does not match and execution of the contract will fail. Because there is a signature parameter in our contract, fill in 00 in the form of the parameter entry(To understand what to fill in for parameters, refer to [Parameter](Parameter.md)), and fill in the script code as shown earlier. Once done, we will see the contract address as shown in the figure.

![](../../../assets/lock2_8.png)



## Test

The following is a test of the smart contract authentication account. In transferring assets from a smart contract authentication account, the consensus node will execute the smart contract when verifying the transaction. If the contract validation is successful (the result is true), the transaction is confirmed. Otherwise the transaction will always be unconfirmed. Our testing method will be to first transfer some assets into the account address, then transfer them out.

> [! Note]
> In order to ensure the accuracy of the test, it is best not to have any other assets in the wallet, as you may not know if the assets are coming from a standard address or a contract address, unless you understand the client's change finding algorithm and know which transaction is coming from the contract address.

### Transfer assets to contract address

Open a wallet with assets on **testnet** and transfer a certain amount of assets to the contract account.

### Transfer assets out of contract address

Transfer assets from your smart contract account:

![Transfer contract amount](../../../assets/lock2_11.png)

If the above operation is correct, the following happens when the asset is transferred:

When the current time is less than the lockout time, the transfer will not be confirmed, ie the transfer will fail.

After clicking `Rebuild Index`, after about 5 minutes, the unacknowledged transfer will disappear and the assets will return to the previous state.

If the current time is greater than the lock time, the transfer will be successful.
