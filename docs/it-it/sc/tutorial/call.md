# Chiamata al Contratto

```c#
[AppCall("XXXXXXXXXX")] // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

In uno smart contract, puoi usarla per chiamare altri smart contract che sono stati pubblicati sulla chain.
1. Aggiungere la dichiarazione usando AppCall e l'hash dello script del contratto da invocare.
2. Chiamalo nel codice.

