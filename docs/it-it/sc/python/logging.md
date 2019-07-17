# Impostazioni e Logging

neo-python ha un modulo impostazioni che puoi usare per configurare diverse variabili:

- La rete: MainNet, TestNet, reti private o configurazioni personalizzate
- Logging:

  - Logging di eventi degli smart contract
  - Logfile (facoltativamente rotativo)
  - Loglevel

Per modificare le impostazioni, importa l'istanza delle impostazioni come segue:

```
from neo.Settings import settings

```

## Configurare la rete

È possibile utilizzare i seguenti metodi di impostazioni per configurare la rete:

```
settings.setup_mainnet()
settings.setup_testnet()
settings.setup_privnet()
settings.setup(config_file)

```

Di default `neo-python` usa la TestNet.

## Logging

neo-python usa le seguenti caratteristiche di default:

- Tutti gli eventi degli smart contracts sono registrati con loglevel INFO
- Loglevel è configurato su INFO
- Il logging in un logfile è disattivato (prompt.py logs a prompt.log)

### Eventi Smart Contract

Se si desidera disabilitare il logging di tutti gli eventi degli smart contract, è possibile farlo:

```
settings.set_log_smart_contract_events(False)

```

### Cambiare il loglevel

Per cambiare il loglevel (es. per mostrare anche DEBUG logs, o per mostrare solo ERRORS):

```
import logging

# Show everything, including debug logs:
settings.set_loglevel(logging.DEBUG)

# Only show errors:
settings.set_loglevel(logging.ERROR)

```

### Configurare un logfile

Per abilitare il logging in un logfile:

```
# Just a single logfile, with no limits or rotation:
settings.set_logfile(your_logfile_path)

# To enable rotation with a maximum of 10MB per file and 3 rotations:
settings.set_logfile(your_logfile_path, 1e7, 3)

```

### Logging in codice personalizzato

neo-python usa [logzero](https://logzero.readthedocs.io/) per il logging. Per usare un logger con l'esistente configurazione logging NEO, puoi semplicemente importare il logger da logzero:

```
from logzero import logger

# These log messages are sent to the console
logger.debug("hello")
logger.info("info")
logger.warn("warn")
logger.error("error")

# This is how you'd log an exception
try:
    raise Exception("this is a demo exception")
except Exception as e:
    logger.exception(e)
```
