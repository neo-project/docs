# Tests

Puoi iniziare i test eseguendo questo comando.

```
python -m unittest discover neo
```

Nota che alcuni dei test unitari usano un gigante impianto database blockchain (intorno a 800mb). questo file non è tenuto nell'archivio.

Quando si eseguono i test la prima volta, l'installazione di prova proverà a scaricare il file e ad estrarlo nella directory corretta.

**Per farla breve**: la prima volta che esegui i test, ci vorrà un po 'di tempo per scaricare questi impianti. Dopodiché dovrebbe essere abbastanza veloce.

Per eseguire test con `coverage`, usa il seguente

```
coverage run -m unittest discover neo

```

Dopodichè, è possibile generare un report di copertura della riga di comando utilizzando quanto segue:

```
coverage report -m --omit=venv/*
```
