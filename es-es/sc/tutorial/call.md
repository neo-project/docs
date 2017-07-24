# Llamada de Contrato

```c#
[AppCall]("XXXXXXXXXX") // ScriptHash
public static extern int AnotherContract (string arg);

public static void Main ()
{
     AnotherContract ("Hello");
}
```

En un contrato inteligente, se puede utilizar esta para llamar a otros contratos inteligentes que han sido publicados en la cadena. 
1. Añadir una declaración con AppCall y el hash del script del contrato a invocar..
2. Llamarla en el código.
