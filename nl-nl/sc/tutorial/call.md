# Contract Call

```c#
[AppCall("XXXXXXXXXX")] // ScriptHash
public static extern int AnderContract (string arg);

public static void Main ()
{
     AnderContract ("Hello");
}
```

In een smart contract kan deze functie worden gebruik om een beroep te doen op andere smart contracts die reeds op de blockchain gevestigd zijn.
1. Voeg een declaratie toe d.m.v. `AppCall` met het script-hash van het op te roepen contract.
2. Roep het op in de node.
