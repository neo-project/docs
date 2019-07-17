# Esempio di Smart Contract - HelloWorld

```c#
public class HelloWorld : SmartContract
{
    public static void Main()
    {
        Storage.Put(Storage.CurrentContext, "Hello", "World");
    }
}
```

La classe di memorizzazione é una classe statica che manipola l'archivio privato del contratto. Il metodo `Storage.Put()` permette di memorizzare i dati nell'area dell'archivio privato in un formato chiave-valore. Per dettagli, fare riferimento a [Archivio](../fw/dotnet/neo/Storage.md).


Per favore fare riferimento a [Github](https://github.com/neo-project/examples) per esempi completi.
