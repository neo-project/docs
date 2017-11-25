# Contract Call

```c#
[AppCall("XXXXXXXXXX")] // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

Sie können diese Funktion in einem Smart Contract benutzen um andere Smart Contracts, welche auf der Blockchain veröffentlicht worden sind, aufzurufen.
1. Fügen Sie eine Deklaration mit AppCall und dem Scrip Hash des aufzurufenden Contracts hinzu
2. Rufen Sie es im Code auf.
