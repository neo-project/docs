# Costruire una chain privata con un nodo NEO

In un tutorial precedente, hai imparato come configurare ed eseguire un nodo su Windows e Linux. Questo tutorial ti insegnerà come costruire una chain privata, e gli step necessari per estrarre NEO e GAS da queste chain private.

Lo sviluppo di una chain privata NEO richiede almeno quattro server per la realizzazione del consenso, dove ogni server corrisponde a un nodo di consenso e un wallet NEO dedicato.

## 1. Configurazione della macchina virtuale

Lo sviluppo di una chain privata NEO richiede almeno quattro server per la realizzazione del consenso, dove ogni server corrisponde a un nodo di consenso. Per scopi dimostrativi, sono state create quattro macchine virtuali Windows su Azure, la dimensione è Standard DS1 v2 (1 core, 3.5 GB RAM). Sarai capace di eseguire chain private su una LAN o macchina virtuale.

![image](/assets/privatechain_1.png)

Dopo aver creato, aprire la porta 10331-10334, il metodo specifico per il sistema nel `firewall` `advanced setting` `inbound rules`, per stabilire nuove regole, e aggiungere la porta 10331-10334.

> [!Nota]
> Se crei una macchina virtuale su un cloud server, accedere al background amministrativo della macchina virtuale, e configurare un gruppo di sicurezza rete.
>
> La configurazione in Azure è: `network interface` `network security group` `inbound security rules` `add` aggiungere la porta 10331-10334.

Una volta creata la macchina virtuale, salvare l'indirizzo IP delle quattro macchine virtuali per utilizzarlo in seguito.

## 2. Installazione del nodo NEO

Il processo di installazione del nodo NEO è stato descritto precedentemente in dettaglio. Per favore fare riferimento alle istruzioni di installazione (setup.md).

## 3. Creazione di un wallet

Primo, abbiamo creato quattro file wallet, denominati wallet1.db3 - wallet4.db3. Questo step può essere eseguito sia nella versione wallet PC sia nella versione wallet a linea di comando, la seguente figura e uno screenshot del client a linea di comando.

![image](/assets/privatechain_3.png)

Una volta che il wallet è stato creato e la sua chiave pubblica salvata, (per esempio salvata in un file .txt), copiare direttamente la chiave pubblica o usare il comando `list key` in [Comando CLI](cli.md) per vedere la chiave pubblica, e poi copiarla. 

Successivamente, copiare i quattro wallet nella directory dei quattro nodi della macchina viruale.

## 4. Modificare il file di configurazione del nodo

Apri il file di configurazione del nodo `protocol.json`.

prima modifica il valore `Magic`. Magic viene usato per identificare la fonte del messaggio nella rete, e specificare un Magic differente assicura che informazioni su reti differenti nel blocco NEO non vengano inviate ad altre reti, durante la trasmissione. 

> [!Nota]
> Il carattere Magic è unito, quindi nota che il valore che inserisci è nel range [0 - 4294967295].

Modifica `StandbyValidators`, e inserisci le 4 chiavi pubbliche registrare nello step 3, qui.

infine modifica `SeedList`, inserisci l'indirizzo IP registrato nel primo step, e il numero di porta invariato. Per esempio, ho modificato le seguenti configurazioni

```json
{
  "ProtocolConfiguration": {
    "Magic": 1704630,
    "AddressVersion": 23,
    "StandbyValidators": [
"02f27545181beb8f528d13bbb66d279db996ecb56ed9a324496d114acb48aa7a32",
      "02daa386d979ae6643869a365294055546023acb332ee1a74a5ae5d54774a97bac",
      "0306f12f7217569cdbe9dde9ff702d0040e0a4570873eee63291adaa658128e55c",
      "035781b4d55dc58187f61b5d9277afbaae425deacc5df57f9891f3a5c73ecb24df"
   ],
    "SeedList": [
      "13.75.112.62:10333",
      "137.116.173.200:10333",
      "168.63.206.73:10333",
      "137.116.171.134:10333"
   ],
    "SystemFee": {
      "EnrollmentTransaction": 0,
      "IssueTransaction": 0,
      "PublishTransaction": 0,
      "RegisterTransaction": 0
    }
  }
}
```

SystemFee è il sistema di commissioni, le commissioni correnti sono come segue (in unità di GAS):

Registrazione per book-keepers - 1000, Distribuzione di Asset - 500 Smart Contracts 500, Registrazione di Asset - 10000

Puoi impostare il tuo sistema di commissioni per la tua chain privata  qui.

Infine, modifica il `protocol.json` nella directory del client dei 4 nodi, rimpiazzando il precedente file protocol.json.

Poi nelle quattro macchine virtuali, inserisci i seguenti comandi per iniziare il nodo, apri il wallet e comincia il processo di consenso. Per favore fai riferimento al comando [CLI Command Reference](cli.md), se sei insicuro.

inizia nodo:

`Dotnet neo-cli.dll`

Apri il wallet:

`Open wallet wallet1.db3`

Nota: Non tutti i nodi devono aprire il wallet1, ogni nodo dovrebbe aprire il file corrispondente al proprio wallet. 

`Start consensus`

Se l'operazione precedente avviene con successo, i quattro nodi inizieranno il processo di consenso, come mostrato

![image](/assets/privatechain_8.png)

4 nodi possono ancora realizzare il consenso, anche se una macchina è spenta, come mostrato:

![image](/assets/privatechain_9.png)



## 5. Estrarre NEO e GAS

Installa la versione PC del client (Neo-GUI), modifica il file di configurazione protocol.json per connetterti alla chain privata.

Apri il wallet. Se l'angolo in basso a sinistra del numero di connessione non è zero, ed è stato sincronizzato fino allo stesso blocco, significa che il client è stato connesso con successo alla chain privata.

Apri il wallet wallet1.db3 nel client PC, aggiungi l'indirizzo multi firma, inserisci le quattro chiavi pubbliche in protocol.json, imposta il numero minimo di firme a 3 (numero dei nodi di consenso/2 + 1), come mostrato.

![image](/assets/privatechain_12.png)

Clicca OK. Al fine di ricostruire l'indice del wallet, clicca su  'wallet' nella barra menu, successivamente vedrai che l'indirizzo del contratto ha 100 milioni di quote NEO.

![image](/assets/privatechain_14.png)

> [!Nota]
> Tutti e 4 i wallets devono eseguire l'operazione di aggiunta di indirizzi multi firma, e ricostruzione dell'indice del wallet. 

Qui vogliamo inviare i NEO dall'indirizzo del contratto a un indirizzo normale. Per far ciò, apri uno dei quattro waller, clicca su `transaction`, `transfer` e inserisci l'indirizzo del destinatario, al fine di trasferire 100 millioni di NEO a questo indirizzo ricevente.

Il sistema ti notificherà che non vi sono state abbastanza firme per completare la transazione. Copia il codice nella tua clipboard, apri il secondo waller, clicca su `transaction`, `signature` e incolla il codice che hai appena copiato. Clicca `signature` e copia il codice. Apri il terzo wallet, clicca su `transaction`, `signature` e incolla il codice che hai appena copiato. Clicca il bottone `signature`. A questo punto noterai un pop-up che mostra un bottone `broadcast` nell'angolo in basso a destra, il che significa che tutte le firme necessarie per inviare la transazione sono state raccolte. Clicca `broadcast`. Una volta che la transazione di trasferimento inizia la trasmissione impiegherà all'incirca 15 secondi per essere rimessa con successo sull'account.

![image](/assets/privatechain_20.png)

L'operazione di estrazione del GAS è simile. Clicca `Advanced`, `Claim GAS`, `Claim` come mostrato. Ricorda l'indirizzo del wallet, ne avrai bisogno dopo.

![image](/assets/privatechain_21.png)

La prossima operazione è  simile al trasferimento di NEO. Copia il codice che ha insufficienti firme, apri il secondo wallet, clicca `transaction`, `signature`, e incolla il codice che hai appena copiato. Clicca `signature`, e copia il codice. Apri il terzo wallet, clicca su `transaction`, `signature` e incolla il codice che hai appena copiato. Clicca `signature` e poi `broadcast` per trasmettere la transazione per richiedere il tuo GAS. Una volta che la transazione di richiesta inizia a trasmettersi ci vorranno circa 15 secondi per essere rimessa con successo sull'account.

Dopo aver completato l'estrazione il GAS inserirà il primo indirizzo standard del wallet (es il primo indirizzo del wallet) da dove hai iniziato l'estrazione del GAS, come mostrato.

![image](/assets/privatechain_26.png)
