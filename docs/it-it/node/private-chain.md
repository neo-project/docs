# Costruire una chain privata con un nodo NEO

In un precedente tutorial, hai imparato come configurare ed eseguire un nodo su Windows e Linux. Questo tutorial ti insegnerà come costruire una chain privata, e gli step necessari per estrarre NEO e GAS da queste chain private.

Lo sviluppo di una chain privata NEO richiede almeno quattro server per la realizzazione del consenso, dove ogni server corrisponde a un nodo di consenso e un wallet NEO dedicato.

## 1. Configurazione della macchina virtuale

Lo sviluppo di una chain privata NEO richiede almeno quattro server per la realizzazione del consenso, dove ogni server corrisponde a un nodo di consenso. Per scopi dimostrativi, sono state create quattro macchine virtuali Windows su Azure, la dimensione è Standard DS1 v2 (1 core, 3.5 GB RAM). Sarai capace di eseguire chain private su una LAN o macchina virtuale.

![image](/assets/privatechain_1.png)

Dopo la creazione, aprire la porta 10331-10334, il metodo specifico per il sistema nel `firewall` `advanced setting` `inbound rules`, per stabilire nuove regole, in seguito aggiungere la porta 10331-10334.

> [!Nota]
> Se viene creata una macchina virtuale su un cloud server, accedere al background amministrativo della macchina virtuale e impostare un gruppo di sicurezza rete.
>
> La configurazione in Azure è: `network interface` `network security group` `inbound security rules` `add` aggiungere la porta 10331-10334.

Una volta creata la macchina virtuale, salvare gli indirizzi IP delle quattro macchine virtuali per un uso successivo.

## 2. Installazione del nodo NEO

Il processo di installazione del nodo NEO è stato dettagliatamente descritto in precedentenza. Si prega di fare riferimento alle istruzioni di installazione (setup.md).

## 3. Creazione di un wallet

Innanzitutto, abbiamo creato quattro file wallet, denominati wallet1.db3 - wallet4.db3. Questo step può essere eseguito sia nella versione wallet PC sia nella versione wallet a linea di comando, la seguente figura è uno screenshot del client a linea di comando.

![image](/assets/privatechain_3.png)

Una volta creato un wallet e salvata la sua chiave pubblica corrispondente, (per esempio salvata in un file .txt), copiare direttamente la chiave pubblica o usare il comando `list key` in [Comando CLI](cli.md) per vedere la chiave pubblica, e poi copiarla. 

Successivamente, copiare i quattro wallet nella directory dei quattro nodi della macchina viruale.

## 4. Modifica del file di configurazione del nodo

Aprire il file di configurazione del nodo `protocol.json`.

Prima modificare il valore `Magic`. Magic viene usato per identificare la fonte del messaggio nella rete, e specificare un Magic diverso assicura che le diverse informazioni di rete nel blocco NEO non vengano inviate ad altre reti durante la trasmissione. 

> [!Nota]
> Il carattere Magic è un unità, quindi tenere presente che il valore inserito rientri nell'intervallo [0 - 4294967295].

Modificare `StandbyValidators`, e inserire le 4 chiavi pubbliche registrare nello step 3, qui.

Infine modificare `SeedList`, inserire l'indirizzo IP registrato nel primo step, e il numero di porta rimane invariato. Come esempio, sono state modificate le seguenti configurazioni

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

SystemFee è la commissione di sistema, la commissione attuale è la seguente (in unità di GAS):

Registrazione per book-keeper - 1000, Distribuzione di Asset - 500 Smart Contract 500, Registrazione di Asset - 10000

E' possibile impostare il sistema di commissione per la propria chain privata qui.

Infine, modificare il `protocol.json` modificato nella directory del client dei 4 nodi, rimpiazzando il precedente file protocol.json.

Quindi, nelle quattro macchine virtuali, inserire i seguenti comandi per avviare il nodo, aprire il wallet e avviare il processo di consenso. Si prega di fare riferimento al comando [Riferimento ai Comandi CLI](cli.md), in caso di insicurezza.

Avviare il nodo:

`Dotnet neo-cli.dll`

Aprire il wallet:

`Open wallet wallet1.db3`

Nota: Non tutti i nodi devono aprire il wallet1, ogni nodo dovrebbe aprire il file corrispondente al proprio wallet. 

`Start consensus`

Se l'operazione precedente avviene con successo, i quattro nodi inizieranno il processo di consenso, come mostrato

![image](/assets/privatechain_8.png)

4 nodi possono ancora realizzare il consenso, anche se una macchina è spenta, come mostrato:

![image](/assets/privatechain_9.png)



## 5. Estrazione di NEO e GAS

Installare la versione PC del client (Neo-GUI), modificare il file di configurazione protocol.json per connettersi alla chain privata.

Aprire il wallet. Se l'angolo in basso a sinistra del numero di connessione non è zero, ed è stato sincronizzato fino allo stesso blocco, significa che il client è stato connesso con successo alla chain privata.

Aprire il wallet wallet1.db3 nel client PC, aggiungere l'indirizzo multi firma, inserire le quattro chiavi pubbliche in protocol.json, impostare il numero minimo di firme a 3 (numero dei nodi di consenso/2 + 1), come mostrato.

![image](/assets/privatechain_12.png)

Cliccare OK. Al fine di ricostruire l'indice del wallet, cliccare su 'wallet' nella barra dei menu, successivamente vedrai che l'indirizzo del contratto ha 100 milioni di quote NEO.

![image](/assets/privatechain_14.png)

> [!Nota]
> Tutti e 4 i wallet devono eseguire l'operazione di aggiunta di indirizzi multi firma, e di ricostruzione dell'indice del wallet. 

Qui vogliamo inviare i NEO dall'indirizzo del contratto a un indirizzo normale. Per far ciò, aprire uno dei quattro wallet, cliccare su `transaction`, `transfer` e inserire l'indirizzo del destinatario, al fine di trasferire 100 millioni di NEO a questo indirizzo ricevente.

Il sistema ti notificherà che non vi sono state abbastanza firme per completare la transazione. Copiare il codice nella tua clipboard, apri il secondo wallet, cliccare su `transaction`, `signature` e incollare il codice appena copiato. Cliccare `signature` e copiare il codice. Aprire il terzo wallet, cliccare su `transaction`, `signature` e incollare il codice copiato. Cliccare il bottone `signature`. A questo punto noterai una finestra di pop-up che mostra un bottone `broadcast` nell'angolo in basso a destra, ciò significa che tutte le firme necessarie per inviare la transazione sono state raccolte. Cliccare `broadcast`. Una volta che la transazione di trasferimento inizia la trasmissione impiegherà all'incirca 15 secondi per essere rimessa con successo sull'account.

![image](/assets/privatechain_20.png)

L'operazione di estrazione del GAS è simile. Cliccare `Advanced`, `Claim GAS`, `Claim` come mostrato. Ricorda l'indirizzo del wallet, ne avrai bisogno in seguito.

![image](/assets/privatechain_21.png)

La prossima operazione è simile al trasferimento di NEO. Copiare il codice che ha insufficienti firme, aprire il secondo wallet, cliccare `transaction`, `signature`, e incollare il codice appena copiato. Cliccare `signature`, e copiare il codice. Aprire il terzo wallet, cliccare su `transaction`, `signature` e incollare il codice appena copiato. Cliccare `signature` e poi `broadcast` per trasmettere la transazione per richiedere il proprio GAS. Una volta che la transazione di richiesta inizia la trasmissione ci vorranno circa 15 secondi per la corretta rimessa sull'account.

Dopo aver completato l'estrazione il GAS inserirà il primo indirizzo standard del wallet (es. il primo indirizzo del wallet) da dove é cominciata l'estrazione del GAS, come mostrato.

![image](/assets/privatechain_26.png)
