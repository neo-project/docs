# Test

Puoi iniziare i test eseguendo questo comando.

```
python -m unittest discover neo
```

Si noti che alcuni dei test unitari usano un grande database blockchain (intorno a 800mb). Questo file non è tenuto nell'archivio.

Quando si eseguono i test la prima volta, la configurazione di prova cercherà di scaricare il file e ad estrarlo nella directory corretta.

**Per farla breve**: la prima volta che esegui i test, ci vorrà un po' di tempo per scaricare questi impianti. Dopodiché dovrebbe essere abbastanza veloce.

Per eseguire test con `coverage`, usa il seguente

```
coverage run -m unittest discover neo

```

In seguito, è possibile generare un report di copertura della riga di comando utilizzando quanto segue:

```
coverage report -m --omit=venv/*
```
