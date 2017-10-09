# Contract Authenticatie Handleiding

Deze handleiding is bedoeld voor Visual Studio 2017 en op de demo van Smart Contract 2.0. Download het **testnetwerk** van [GitHub](https://github.com/neo-project/neo-gui-releases). Op het moment van schrijven is de laatste **testnetwerk** versie: [neo-gui-2.0.1](https://github.com/neo-project/neo-gui/releases/download/v2.0.1/neo-gui-windows.zip).

At the time of writing this document, the latest **test network** client download address: [neo-gui-2.3.2](https://github.com/neo-project/neo-gui/releases/download/v2.3.2/neo-gui-windows.zip).

## Compileren van contract script

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
namespace Neo.SmartContract
{
    public class Test : VerificationCode
    {
        public static bool Verify(byte[] signature)
        {
            return true;
        }
    }
}
```

> [!Note]
> Als je niet weet hoe smart contract scripts geschreven en gegenereerd worden, lees dan eerst [hoe gebruik ik C# om een smart contract te maken](../getting-started.md).
>

Bovenstaand contract wordt gecompileerd tot Test.avm, met als contract script (de binaire data van Test.avm): 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

Later in de handleiding wordt uitgelegd hoe het contract script voor een `.avm`-bestand te verkrijgen is.

## Wallet aanmaken

Maak een nieuwe wallet aan volgens de handleiding hieronder:

![Create a wallet](/assets/verify_1.png).

## Het contract script verkrijgen

Er zijn vele manieren om het contract script te verkrijgen. Een hiervan is om het direct uit het `.avm`-bestand te lezen met behulp van onderstaande C#-code.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

Als je niet het contract script wilt verkrijgen d.m.v. coderen, is de `Deploy Contract`-functie van de client een simpele andere methode om de contract code in te zien:

Klik op `Advanced`, `Deploy Contract` en klik op de `Load`-knop in de hoek rechtsonderin. Kies het `Test.avm`-bestand wat eerder is aangemaakt. Het contract script zou te zien moeten zijn in de `Code`-box, zoals te zien in het figuur. Kopiëer deze.

![Obtaining the contract script](/assets/verify_5.png)

## Contract address aanmaken

Klik na het aanmaken van de wallet met de rechter muisknop op de wallet, klik op `Create Contract Add.` en op `Custom...`:

![Create a contract address](/assets/verify_6.png)

Verbind het contract-adres met de aangemaakte account en vul de benodigde parameters in. Omdat ons contract een parameter heeft voor `signature`, moet `00` worden ingevuld in `Parameter List` (kijk voor details [Parameters](Parameter.md)). Voer hier de contract script in die in de vorige stap uit de `Code`-box is gekopiëerd.

De reden dat het script moet worden geassocieerd met een account, is om het contract te verbinden met een public-private key-paar; op deze manier zal de client automatisch het contract signeren met de private key van de verbonden account wanneer dit nodig is.

![Create a contract address](/assets/verify_7.png)

Klik op `OK`; de smart contract authenticatie-account is nu aangemaakt.

## Testen

Hieronder volgt een test van de smart contract authenticatie-account. Als assets uit een smart contract-account worden overgemaakt, zullen de consensus nodes het contract uitvoeren bij het valideren van de transactie. Als het contract succesvol gevalideerd is (`return true`), dan is de transactie bevestigd. Tot het resultaat `true` ontvangen is, zal de transactie de status 'onbevestigd' hebben. Als test worden eerst wat assets naar de contract-authenticatie-account overgemaakt, en vervolgens weer overgemaakt vanuit de account.

> [!Note]
> Om zeker te zijn van de geldigheid van de test is het van belang dat er geen andere assets in de wallet aanwezig zijn, anders kan het onbekend zijn of de asset vanuit de standaard-account was overgemaakt, of vanuit de contract-account (tenzij je het 'change search'-algoritme van de client kent en er zeker van kan zijn dat de transactie wordt uitgevoerd vanuit het smart contract-adres).

### Asset overmaken naar contract address

Maak een bepaalde hoeveelheid assets over naar de contract-account:

![Transfer asset to contract address](/assets/verify_9.png)

### Contract assets overmaken

Maak de assets over vanuit de contract-account:

![Transfer the contract amount](/assets/verify_10.png)

> [!Note]
> Het saldo van de assets in de client is de som van het saldo in de standaard-account + contract-account, oftewel: de som van alle adressen bij elkaar opgeteld. Het wel of niet kunnen gebruiken van assets in het smart contract hangt van het resultaat van de test af; als het contract succesvol uitgevoerd is (met als resultaat `true`), kan de asset overgemaakt worden uit de account, anders niet.
