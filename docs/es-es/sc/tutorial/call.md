# Ejemplo de contrato inteligente - Llamada a un contrato

```c#
[AppCall]("XXXXXXXXXX") // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

Dentro de un contrato inteligente puedes hacer una llamada a otro contrato que ha sido publicado en la blockchain.

Opciones:

1. Añadir una declaración usando AppCall y el script hash del contrato a invocar.
2. Llamar al contrato desde código.

