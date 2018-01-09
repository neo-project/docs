# Impostazioni e Registrazione

neo-python ha un modulo impostazioni che puoi usare per configurare diverse cose:

- La rete: MainNet, TestNet, reti private o configurazioni personalizzate
- Logging:

  - Smart contract eventi logging
  - Logfile (opzionalmente rotativo)
  - Loglevel

Per modificare le impostazioni, importa l'istanza delle impostazioni come questa:

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

Di default, `neo-python` usa la TestNet.

## Logging

neo-python usa le seguenti predefinite:

- Tutti gli eventi degli smart contracts sono registrati con loglevel INFO
- loglevel è configurato su INFO
- logging in un logfile è diasattivato (prompt.py logs a prompt.log)

### Eventi Smart Contract

Se si desidera disabilitare il logging di tutti gli eventi degli smart contracts, è possibile farlo:

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

### Accesso al codice personalizzato

neo-python usa [logzero](https://logzero.readthedocs.io/) per logging. Per usare alogger con l'esistente configurazione logging NEO, puoi semplicemente importare il logger da logzero:

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
