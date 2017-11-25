# Bereitstellen eines Smart Contracts mit Parametern

## 1 - Einführung
Dieses Tutorial ist dazu da um zu zeigen wie man mit dem Desktop GUI einen Smart Contract auf der NEO Blockchain bereit stellt und aufruft. Dies ist ein übergeordnetes Tutorial und eignet sich für alle Contract Typen, einschliesslich NEP5 Tokens. Bei diesem Tutorial gehen wir davon aus, dass der Contract schon in eine .avm Datei compiled wurde. Wenn Sie das noch nicht getan haben, lesen sie bitte zuerst die anderen Tutorials. Eine schon compiled Version des Contracts und die in diesem Tutorial verwendete Quelle werden bereitgestellt. 

## 2 - Nützliche Resourcen

Die folgenden Ressourcen werden in diesem Tutorial benutzt und können hilfreiche Referenzen beim Entwickeln eines Smart Contract sein:

1. [Lock2](Lock2.md)
2. [Parameter](Parameter.md)
3. [Woolong NEP5 Smart Contract](assets/examples/Woolong.cs.md)
4. [Developer GUI](https://github.com/CityOfZion/neo-gui-developer)
5. [Neo API](../api/neo.md)
6. [NEP5 Token Standard](https://github.com/neo-project/proposals/pull/4)

## 3 - SC Code

Dieses Dokument verwendet den Bespielcode des Wooloong Beispiels um durch das Tutorial zu gehen. Dieser Contract wird zum Spass 1 Woolong generieren für jeden Aufruf.

Das Beispiel wurde auf dem Testnet zur Verfügung gestellt und kann auf dem folgendem Script Hash zugegriffen werden:

	dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f
  

## 4- Einen Smart Contract mit Parametern zur Verfügung stellen

1. Um einen Smart Contract (.avm) auf der Blockchain zur Verfügung zu stellen, klicken Sie auf **Advanced** im Menu in der NEO Desktop Wallet und wählen Sie **Deploy Contract** an. Für development Contracts empfehlen wir die Nutzung von NEO development GUI.

<p align="center"><img style="vertical-align: middle" src="assets/img/deploy.png" width="500"></p>

2. Füllen Sie alle Felder im Abschnitt **Information** aus im Fenster das erscheint. Um den Vertrag bereitzustellen müssen alle Felder ausgefüllt werden.
3. Laden sie die .avm Datei indem Sie den **Load** Knopf drücken. Das **code field** Feld wird mit dem Script Hash ausgefüllt. Kopieren Sie den Inhalt des Feldes **Code**, Sie werden es in einem späteren Schritt noch brauchen.
4. Füllen sie die **Metadata** Felder aus, beziehen Sie sich dabei auf die [Parameter](Parameter.md) Dokumentation.
    **Der Woolong Beispieltoken ist definiert als:**
    
    ```csharp
    public static object Main(string method, params object[] args)  
    ```
    
    Also benutzen wir:
   * **Parameter List:** 0710
   * **Return Type:** 05
    
5. Falls der Contract Speicher benötigt (verwendet die [Read/Write API](../api/neo.md#readwrite-api)), kreuzen Sie das **Need Storage** Kästchen an. Der NEP5 Standard benutzt Speicher um Accounts zu halten, vergewissern Sie sich also dass Sie das angekreuzt haben wenn Sie einen NEP5 Token bereitstellen.
6. Klicken Sie auf den **Deploy** Knopf

## 5 - Beobachten des Smart Contract

1. Rechtsklicken Sie im Hauptfenster der NEO Wallet auf den Adressbereich und wählen Sie (Create Contract Add > Custom)
2. Wählen Sie den Account, welchen Sie mit dem Contract assoziieren wollen aus dem **Related Account** dropdown 
3. Füllen Sie im Feld **Parameter List** die **Parameter List** Werte ein vom Schritt 4 aus dem Abschnitt **Einen Smart Contract mit Parametern zur Verfügung stellen**
4. Füllen Sie im Feld **Script** die Werte aus dem Schritt 3 von **Einen Smart Contract mit Parametern zur Verfügung stellen** ein
5. Klicken Sie auf **Confirm** um den Contract ins Wallet Fenster zu laden.

## 6 - Aufrufen des Smart Contract

Um einen Smart Contract auf der NEO Blockchain aufzurufen brauchen Sie den Script Hash des Smart Contract
1. Um den Contract Hash zu erhalten, rechtsklicken Sie auf den Conract Account der als Ergebnis des Fensters **Watching the Smart Contract** im Adressfenster angezeigt wird.
2. Wählen Sie **View Contract** um ein Fenster zu öffnen, welches Informationen über den Smart Contract enthält. Kopieren Sie den Wert im **Script Hash** Feld.
3. Klicken Sie auf die Menuoption **Advanced** und wählen Sie **Invoke Contact**
4. Füllen Sie das **Script Hash** Feld mit dem Wert den Sie in Schritt 2 kopiert haben aus. Als Beispiel können Sie den Woolong Contract aufrufen mit dem Script Hash aus **Abschnitt 3**
5. Die Smart Contract Information sollte automatisch die übrigen **Invoke Function** Felder ausfüllen.
6. Klicken Sie auf den **...** Knopf neben dem Parameter Feld um das Parameter Menu zu öffnen und die Input Parameter auszufüllen.
7. Wählen Sie die Parameter im linken Feld an und füllen Sie die Werte der Variablen im unteren rechten Feld aus. 

   **Zum Beispiel um folgendes aufzurufen:**
  * `6e616d65` when calling the Woolong, will return 'Woolong'.
    ```csharp
    if (method == "name") return name;
    ```
  * `73796d626f6c` will return 'WNG'.
    ```csharp
     if (method == "symbol") return symbol;
    ```
  * `62616c616e63654f66, 5fe459481de7b82f0636542ffe5445072f9357a1261515d6d3173c07c762743b` will return the current balance of Woolong that lllwvlvwll holds on the testnet.
    ```csharp
    if (method == "balanceOf") return Storage.Get(Storage.CurrentContext, (byte[]) args[0]);
    ```
    
8. Klicken Sie auf **OK** um das Parameter Eingabefenster zu schliessen.
9. Klicken Sie auf den **Invoke** Knopf um den Smart Contract aufzurufen.

**Anmerkung:** Das aktuelle standard Desktop GUI unterstützt das Ansehen von Returns nicht. Es wird empfohlen das Developer GUI zu verwenden um die Ereignisse auszuführen.

