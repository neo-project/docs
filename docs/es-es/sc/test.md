# Pruebas unitarias en contratos inteligentes

Pruebas unitarias en contratos inteligentes.

## Crear pruebas unitarias

A modo de ejemplo, vamos a crear el siguiente contrato inteligente (este hereda de FunctionCode). El contrato tiene tres parámetros y devuelve un valor de tipo int.


```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Test1: FunctionCode
    {
        public static int Main (int a, int b, int c)
        {
            if (a> b)
                return a * sum (b, c);
            else
                return sum (a, b) * c;
        }

        public static int sum (int a, int b)
        {
            return a + b;
        }
    }
}
```

Después de compilar, se genera el fichero de contrato, en mi ejemplo `Test1.avm`. Ahora podemos crear un proyecto de prueba unitaria y probar `Test1.avm`.

Primero, crea un proyecto de aplicación de consola en C# (.Net Framework) desde Visual Studio, para .NET Framework 4.6.2 o superior, después añade la referencia a `Neo.dll` y `Neo.VM.dll`.

> [!NOTE]
> Esos dos ficheros se pueden obtener al compilar [Neo](https://github.com/neo-project/neo) y [Neo.VM](https://github.com/neo-project/neo-vm).
> Tambien se puede añadir añadir al proyecto los paquetes "Neo" y "Neo.VM" desde NuGet. Para eso, clic con el botón derecho sobre el proyecto del contrato en el `Explorador de Soluciones`, ves al Buscador y busca Neo e instala los paquetes necesarios.

```c#
using System;
using System.IO;
using System.Linq;
using Neo;
using Neo.VM;
using Neo.Cryptography;

namespace ConsoleApplication1
{
    class program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@ "C: \ ... \ Test1.avm"));

            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush(2); // corresponde al parámetro c
                sb.EmitPush(4); // corresponde al parámetro b
                sb.EmitPush(3); // corresponde al parámetro a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // iniciar la ejecución

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // definir aquí el valor de retorno
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

El resultado de la compilación es: 14, lo esperado

> [!NOTE]
> Si usas el código de arriba para pasar los parámetros presta atención a la parte superior de la pila correspondiente 
> al primer parámetro, para mayor comodidad también puedes pasarlos mediante el siguiente código.

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
Si el valor de retorno del contrato inteligente no es de tipo int, pero es de tipo bool u otro tipo, necesitas cambiar `engine.EvaluationStack.Peek().GetBigInteger ()` para que retorne otros valores tal y como se muestra en la imagen

<img style="vertical-align: middle" src="/assets/test_1.jpg">

