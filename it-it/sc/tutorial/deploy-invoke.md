# Implementare uno Smart Contract con Parametri

## 1 - Introduzione
Questo tutorial é progettato per spiegare come implementare e invocare uno smart contract sulla blockchain NEO usando la GUI del desktop. Il tutorial é generico ed é appropriato per tutti i tipi di contratti inclusi i token NEP5. Questo tutorial parte dall'assunto che il contratto é giá stato compilato in un file .avm. Se non é ancora stato compilato, si prega di fare riferimento agli altri tutorial. Viene fornita una versione compilata del contratto e la fonte usata in questo tutorial.

## 2 - Risorse Utili

In questo tutorial sono utilizzate le seguenti risorse, che possono essere riferimenti utili nello sviluppo di uno smart contract:

1. [Lock2](Lock2.md)
2. [Parametro](Parameter.md)
3. [Woolong NEP5 Smart Contract](assets/examples/woolong.cs.md)
4. [Developer GUI](https://github.com/CityOfZion/neo-gui-developer)
5. [Neo API](../api/neo.md)
6. [NEP5 Token Standard](https://github.com/neo-project/proposals/pull/4)

## 3 - Codice SC
Questo documento utilizzerá il codice esempio fornito nell'esempio Woolong per seguire il tutorial. Per svago, questo contratto genererá 1 Woolong per ogni evento invocato.

L'esempio é stato implementato in un testnet e puó essere trovato con il seguente hash dello script:
​    
	dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f
​	

## 4 - Implementare uno Smart Contract con Parametri

1. Per implementare uno smart contract (.avm) sulla blockchain, clicca sull'opzione menu **Advanced** sul wallet desktop NEO e seleziona **Deploy Contract**. Per contratti di sviluppo, raccomandiamo di utilizzare la GUI di sviluppo NEO.

<p align="center"><img style="vertical-align: middle" src="assets/img/deploy.png" width="500"></p>

2. Riempire tutti i campi nella sezione **Information** nella finestra che appare. Tutti i campi devono essere compilati per implementare il contratto. 
3. Carica il file .avm usando il tasto **Load**. Il **code field** verrá compilato con l'hash dello script. Copia il contenuto del campo **Code** per utilizzaro negli step successivi.
4. Compilare il campo **Metadata** in riferimento alla documentazione [Parametro](Parameter.md).

    **Il token Woolong di esempio é definito come:**  

    ```csharp
    public static object Main(string method, params object[] args)  
    ```

    quindi usiamo:  
    * **Parameter List:** 0710
    * **Return Type:** 05

5. Se il contratto richiede memoria (usare [Read/Write API](../api/neo.md#readwrite-api)), controlla il box **Need Storage**. Lo standard NEP5 utilizza memoria per mantenere gli account, quindi assicurati che sia spuntato quando si implementa un token NEP5.

6. Cliccare il bottone **Deploy**.


## 5 - Guardare lo Smart Contract   

1. Sulla finestra principale del wallet NEO, fare clic destro sull'area dell'indirizzo e selezionare (Create Contract Add > Custom)
2. Selezionare l'account al quale si vuole associare il contratto da **Related Account** 
3. Nel campo **Parameter List**, riempire i valori del **Parameter List** usati nello step 4 della sezione **Implementare uno Smart Contract con Parametri**.
4. Riempire il campo **Script** con il valore fornito nello step 3 di **Implementare uno Smart Contract con Parametri**.
5. Cliccare **Confirm** per caricare il contratto nella finestra del wallet.


## 6 - Invocare lo Smart Contract

Per invocare uno smart contract sulla blockchain di NEO, avrai bisogno dell'hash dello script dello smart contract.
1. Per acquisire l'hash del contratto, fare doppio clic sull'account del contratto riempito nella finestra dell'indirizzo come risultato della finesta **Watching the Smart Contract**.
2. Selezionare **View Contract** per aprire una finestra contenente le informazioni dello smart contract. Copia il valore nel campo **Script Hash**
3. Cliccare sull'opzione menu **Advanced** e selezionare **Invoke Contract**.
4. Riempire il campo **Script Hash** con il valore copiato nello step 2. Come esempio, é possibile invocare il Woolong usando l'hash dello script della **Sezione 3**
5. Le informazioni dello Smart Contract dovrebbero riempirsi automaticamente nei campi rimanenti **Invoke Function**
6. Per riempire i parametri in input, cliccare sul bottone **...** a finco del campo Parametri per aprire il menu parametro compilato.
7. Selezionare i parametri del campo sul lato sinistro e compilare i valori delle variabili nel campo in basso a destra.

  **Per esempio, invocare quanto segue:**
  * `6e616d65` quando stai chiamando Woolong, restituirá 'Woolong'.
    ```csharp
    if (method == "name") return name;
    ```
  * `73796d626f6c` restituirá 'WNG'.
    ```csharp
     if (method == "symbol") return symbol;
    ```
  * `62616c616e63654f66, 5fe459481de7b82f0636542ffe5445072f9357a1261515d6d3173c07c762743b` restituirá il saldo corrente di Woolong che lllwvlvwll possiede sulla testnet.
    ```csharp
    if (method == "balanceOf") return Storage.Get(Storage.CurrentContext, (byte[]) args[0]);
    ```

8. Cliccare **OK** per chiudere la finestra di input dei parametri.
9. Cliccare il bottone **Invoke** per invocare lo smart contract.

**Nota:** La GUI desktop standard corrente non supporta la visualizzazione dei resi. Usare la GUI di sviluppo è raccomandato quando si eseguono questi eventi.

 
