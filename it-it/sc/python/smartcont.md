# Interagire con gli Smart Contract

Un caso d'uso comune per implementare neo-python è interagire con gli smart contract. Gli eventi tipici degli smart contract includono `Runtime.Notify`, `Runtime.Log`, esecuzione con successo o esecuzione fallita e `Storage.GET/PUT/DELETE`.

## Tipi di eventi

Questa è una lista del tipo di eventi degli smart contract che possono attualmente essere gestiti con neo-python:

```python
RUNTIME_NOTIFY = "SmartContract.Runtime.Notify"
RUNTIME_LOG = "SmartContract.Runtime.Log"

EXECUTION = "SmartContract.Execution.*"
EXECUTION_INVOKE = "SmartContract.Execution.Invoke"
EXECUTION_SUCCESS = "SmartContract.Execution.Success"
EXECUTION_FAIL = "SmartContract.Execution.Fail"

STORAGE = "SmartContract.Storage.*"
STORAGE_GET = "SmartContract.Storage.Get"
STORAGE_PUT = "SmartContract.Storage.Put"
STORAGE_DELETE = "SmartContract.Storage.Delete"

```

Quando tali eventi si verificano in blocchi ricevuti, un'istanza `SmartContractEvent` è inviata attraverso `neo.EventHub`.

## SmartContractEvent

I gestori di eventi ricevono sempre un singolo argomento, un'istanza di `neo.EventHub.SmartContractEvent`, che include tutte le informazioni sull'evento corrente. Lo `SmartContractEvent` ha le seguenti proprietà:

| Proprietà            | Tipo di dato | Descrizione                              |
| ------------------- | ---------- | ---------------------------------------- |
| `event_type`        | str        | Uno dei tipi di evento in `neo.EventHub.SmartContractEvent` |
| `contract_hash`     | UInt160    | Hash del contratto                    |
| `tx_hash`           | UInt256    | Hash della transazione                  |
| `block_number`      | int        | Numero di blocco al quale questo evento è stato ricevuto  |
| `event_payload`     | object[]   | Un elenco di oggetti, a seconda dei tipi di dati emessi dallo smart contract (es. con `Runtime.Notify`). |
| `execution_success` | bool       | Se l'invocazione del metodo ha avuto successo |
| `test_mode`         | bool       | Se questo evento è stato inviato da un TestInvoke locale invece di essere ricevuto dalla blockchain |

## neo.contrib.smartcontract.SmartContract

Gli sviluppatori possono facilmente iscriversi a questi eventi utilizzando `neo.contrib.smartcontract.SmartContract`. Questo è un esempio di ascolto per eventi `Runtime.Notify` di uno smart contract con l'hash `6537b4bd100e514119e3a7ab49d520d20ef2c2a4`:

```python
from neo.contrib.smartcontract import SmartContract

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_notify
def sc_notify(event):
    print("SmartContract Runtime.Notify event:", event)

    # Make sure that the event payload list has at least one element.
    if not len(event.event_payload):
        return

    # The event payload list has at least one element. As developer of the smart contract
    # you should know what data-type is in the bytes, and how to decode it. In this example,
    # it's just a string, so we decode it with utf-8:
    print("- payload part 1:", event.event_payload[0].decode("utf-8"))

```

I seguenti decoratori sono attualmente disponibili:

| Decoratore       | Eventi Smart contract                  |
| --------------- | -------------------------------------- |
| `@on_any`       | Tutti gli eventi                           |
| `@on_notify`    | `Runtime.Notify`                       |
| `@on_log`       | `Runtime.Log`                          |
| `@on_storage`   | Storage PUT, GET e DELETE            |
| `@on_execution` | Invocazione del metodo, successo e fallimento |

Ecco un altro esempio, che mostra come ascoltare tutti gli eventi e come distinguere tra i tipi di eventi nel codice:

```python
from neo.contrib.smartcontract import SmartContract
from neo.EventHub import SmartContractEvent

smart_contract = SmartContract("6537b4bd100e514119e3a7ab49d520d20ef2c2a4")

@smart_contract.on_all
def handle_sc_event(event):
    print("SmartContract Runtime.Notify event:", event)

    # Check if it is a Runtime.Notify event
    if event.event_type == SmartContractEvent.RUNTIME_NOTIFY:
        # Exit if an empty payload list
        if not len(event.event_payload):
            return

        # Decode the first payload item and print it
        print("- payload part 1:", event.event_payload[0].decode("utf-8"))
```
