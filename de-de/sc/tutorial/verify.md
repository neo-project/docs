# Contract Authentifizierungs Tutorial

Dieses Tutorial basiert auf Visual Studio 2017, versichern Sie sich bitte das Sie Ihr Visual Studio auf die Version 2017 upgegraded haben. Zusätzlich basiert dieses Tutorial auf der Demo von Smart Contract 2.0, laden Sie bitte das **test network** von [GitHub](https://github.com/neo-project/neo-gui/releases) herunter und führen Sie dieses aus.

Zum Zeitpunkt der Erstellung dieses Dokuments lautet die Download Adresse des neuesten **test network** Client: [neo-gui-2.0.1](https://github.com/neo-project/neo-gui/releases/download/v2.0.1/neo-gui-windows.zip).

## Compile Contract Script

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

> [!Anmerkung]
> Wenn Sie nicht wissen wie man Smart Contract Scripts schreibt und generiert, shen Sie hier nach: [How to use C# to prepare Smart Contract](../getting-started.md)

Der obige Contract wird nach Test.avm compiled, der Contract Script (Test.avm binary Data) lautet: 52c56b6c766b00527ac461516c766b51527ac46203006c766b51c3616c7566

Später in diesem Tutorial werden Sie lernen wie Sie ein Contact Script für eine '.avm' Datei erhalten.

## Eine Wallet kreieren

Kreieren Sie eine neue Wallet gemäss dem folgenden Tutorial:

![Create a wallet](/assets/verify_1.png)

## Contract Script erhalten

Es gibt viele Wege das Contract Script zu erhalten, eine Möglichkeit ist es mit unten Stehendem C# Code direkt aus der '.avm' Datei auszulesen.

```c#
byte[] bytes = System.IO.File.ReadAllBytes("Test.avm");
string str = System.Text.Encoding.Default.GetString(bytes);
```

Wenn Sie das Contract Script nicht durch Programmieren erhalten wollen, bietet die 'Deploy Contract' Funktion des Client's eine einfache Möglichkeit den Contract Code zu erhalten:

Klicken Sie auf 'Advanced', 'Deploy Contract' und klicken Sie auf den 'Load' Knopf in der unteren rechten Ecke. Wählen Sie die zuvor erstellte 'Test.avm' Datei. Sie sollten das Contract Script in der 'Code' Box angezeigt bekommen, wie in der Abbildung zu sehen. Kopieren sie dieses.

![Obtaining the contract script](/assets/verify_5.png)

## Eine Contract Adresse kreieren

Nachdem Sie Ihre eigene Wallet kreiert haben, klicken Sie die rechte Maustaste und kreieren Sie eine Contract Adresse mit Ihrem generierten Contract Script:

![Create a contract address](/assets/verify_6.png)

Verbinden Sie die Contract Adresse mit Ihrem Account und füllen Sie die entsprechenden Parameter ein. Da unser Contract einen Parameter für die Signatur hat, müssen Sie '00' in 'Parameter List' einfüllen (für Details sehen Sie hier nach: [Parameter](Parameter.md)), und danach das Contract Script aus dem vorherigen Schritt in die 'Code' Box eingeben.

Der Grund um einen Account zu verknüpfen besteht darin, einen Contract mit einem Public-Private Key Paar zu verbinden, dass wenn ein Contract eine Signatur verlangt, der Client automatisch mit dem Private Key des verbundenen Accounts unterschreibt.

![Create a contract address](/assets/verify_7.png)

Nachdem Sie auf 'OK' klicken, ist der Smart Contract Authentifizierungs Account erfolgreich kreiert.

## Testen

Es folgt ein Test des Smart Contract Authentifizierungsaccount. Wenn Assets aus einem Smart Contract Account transferiert werden, werden die Consensus Nodes den Contract ausführen, wenn sie die Transaktion validieren. Wenn die Contractvalidierung erfolgreich ist (returns Resultat 'true'), dann ist die Transaktion bestätigt. Bis das Resultat 'true' erhalten wird, hat die Transaktion den Status unbestätigt. Die Test Methode besteht darin zuerst einige Assets an den Contract Authentifizierungs Account zu transferieren und dann wieder heraus zu transferieren.

> [!Anmerkung]
> Um die Genauigkeit des Tests zu garantieren, ist es am besten keine andere Assets in der Wallet zu haben, sonst können Sie nicht sicher sein ob die Assets aus einer Standardadresse oder aus einer Contractadresse kommen, ausser Sie verstehen den 'change finding algorithm' des Client's und wissen welche Transaktion von der Contract Adresse kommt.

### Assets an die Contract Adresse transferieren

Transferieren sie eine bestimmte Menge an Assets in Ihren Contract Account:

![Transfer asset to contract address](/assets/verify_9.png)

### Contract Assets transferieren

Transferieren Sie Assets aus Ihrem Smart Contract Account:

![Transfer the contract amount](/assets/verify_10.png)


> [!Anmerkung]
> Der Saldo an Assets im Client ist gleich der Summe des Saldo im Standard Account und des Saldo in der Contract Adresse, das heisst von allen Adressen kombiniert. Ob Sie die Assets in der Contract Adresse verwenden können, hängt vom Resultat der Ausführung des Smart Contracts ab, wenn der Contract erfolgreich ausgeführt wird (das Resultat ist 'true'), dann können Assets transferiert werden, sonst nicht.









