# Smart Contract met Parameters Deployen

## 1 - Introductie

Deze handleiding zal het deployen (*beschikbaar maken*) en invoken (*aanroepen*) van smart contracts op de NEO blockchain d.m.v. de desktop-GUI behandelen. Deze handleiding is basaal opgezet en is van toepassing voor alle contracttypes, inclusief NEP5-tokens. Deze handleiding gaat ervan uit dat het contract al is gecompileerd tot een `.avm`-bestand. Als dit niet het geval is, loop dan a.u.b. eerst de andere handleidingen door. Een gecompileerde versie van het contract, en de broncode die in deze handleiding worden gebruikt, zijn bijgevoegd. 

## 2 - Nuttige Downloads

De volgende middelen worden in deze handleiding gebruikt en kunnen handig zijn bij het ontwikkelen van een smart contract:

1. [Lock2](Lock2.md)
2. [Parameter](Parameter.md)
3. [Woolong NEP5 Smart Contract](assets/examples/Woolong.cs.md)
4. [Developer GUI](https://github.com/CityOfZion/neo-gui-developer)
5. [Neo API](../api/neo.md)
6. [NEP5 Token Standard](https://github.com/neo-project/proposals/pull/4)

## 3 - SC Code

Dit document zal enkel voorbeeldcode van het Woolong-voorbeeld gebruiken. Voor de grap zal dit contract 1 Woolong genereren elke keer dat het wordt aangeroepen. 

Het voorbeeld is beschikbaar gemaakt op het TestNet en kan worden opgeroepen m.b.v. de volgende script-hash: 
​    
	dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f
​	

## 4 - Smart Contract met Parameters Deployen

1. Om het smart contract (`.avm`) op de blockchain te plaatsen, klik je op de **Advanced** menuoptie in Neo-GUI en selecteer je **Deploy Contract**. 

<p align="center"><img style="vertical-align: middle" src="assets/img/deploy.png" width="500"></p>

2. Vul alle velden in het **Information**-gedeelte in. Alles moet ingevuld zijn voordat het contract uitgezonden kan worden.
3. Laad het `.avm`-bestand d.m.v. de **Load**-knop. Het **Code**-gebied zal de script-hash bevatten. Kopiëer deze voor een latere stap.
4. Vul de **Metadata**-velden in (zie [Parameters](Parameter.md)).
Populate the **Metadata** fields referencing the [Parameter](Parameter.md) documentation.

    **De Woolong voorbeeldtoken is gedefiniëerd als:**  

    ```csharp
    public static object Main(string method, params object[] args)  
    ```

    We gebruiken:  
    * **Parameter List:** 05
    * **Return Type:** 05  

5. Als het contract opslag nodig heeft (gebruik maakt van [read/write API](../api/neo.md#readwrite-api)), vink dan **Need Storage** aan. De NEP5-standaard maakt gebruik van opslag om accounts bij te houden; vink deze dus altijd aan bij het maken van een NEP5 token. 

6. Klik op **Deploy**.

## 5 - Het Smart Contract Bekijken

1. Klik, in het hoofdvenster van de NEO wallet, met de rechter muisknop op het adres en kies **Create Contract Add. > Custom**.
2. Selecteerd de account die je gekoppeld wilt hebben aan het contract m.b.v. het **Related Account**-dropdown menu.
3. Vul de **Parameter List** in met de waardes die in stap 4 zijn gebruikt.
4. Vul het **Script** veld in
Populate the **Script** field with the value provided in Step 3 of **Deploy Smart Contract w/ Parameters**.
5. Click **Confirm** to load the contract into the wallet window.


## 6 - Invoking the Smart Contract

To invoke a smart contract on the NEO blockchain, you will need the smart contract script hash. 
1. To acquire the contract hash, right click on the contract account populated in the address window as a result of the **Watching the Smart Contract** window.
2. Select **View Contract** to open a window containing information about the smart contract.  Copy the value in the **Script Hash** field.
3. Click on the **Advanced** menu option and select **Invoke Contract**.
4. Populate the **Script Hash** field with the value copied in Step 2.  As an example, you can invoke the Woolong using the script hash in **Section 3**
5. The Smart Contract information should automatically populate in the remaining **Invoke Function** fields.
6. To populate the input parameters, click on the **...** button next the the Parameters field to open the parameter population menu.
7. Select the parameters on the left field and populate the variable values in the lower right field.

  **For example, invoking the following:**
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

8. Click **OK** to close the parameter input window.
9. Click the **Invoke** button to invoke the smart contract.

**Note:** The current standard desktop GUI does not support viewing returns.  Using the developer GUI is recommended when executing the events.

 
