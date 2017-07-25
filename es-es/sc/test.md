# Pruebas unitarias de Contratos Inteligentes

Después de leer la documentación previa, hemos habilitado el uso de C# en Visual Studio 2017 para crear contratos inteligentes. ¿Cómo podemos realizar pruebas unitarias después de crear un contrato inteligente?

## Crear pruebas unitarias

Por ejemplo, crea el siguiente contrato inteligente, este hereda de FunctionCode, contiene tres parámetros y devuelve un valor de tipo int.


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

Después de compilar, se genera el fichero de contrato `Test1.avm`. Ahora podemos crear un proyecto de prueba unitaria y probar `Test1.avm`.

Primero, crea un proyecto de aplicación de consola en C# (.Net Framework) desde Visual Studio, para .NET Framework 4.6.2 o superior, después añade la referencia a `Neo.dll` y `Neo.VM.dll`.

> [!Nota]
> Esos dos ficheros se pueden obtener al compilar [Neo](https://github.com/neo-project/neo) y [Neo.VM](https://github.com/neo-project/neo-vm).

> Alternativamente, puedes añadir añadir al proyecto los paquetes "Neo" y "Neo.VM" desde NuGet. Para realizar esto haz clic con el botón derecho sobre el proyecto del contrato en el Explorador de Soluciones, ves al Buscador y buscar neo e instala los paquetes necesarios.

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

Resultado de la compilación: Resultado de la ejecución 14, lo esperado

Nota: Si usas el código de arriba para pasar los parámetros, presta atención a la parte superior de la pila correspondiente al primer parámetro, para mayor comodidad también puedes pasarlos mediante el siguiente código.

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
Si el valor de retorno del contrato inteligente no es de tipo int, pero es de tipo bool u otro tipo, necesitas cambiar `engine.EvaluationStack.Peek (). GetBigInteger ()` para que retorne otros valores tal y como se muestra en la imagen

![](http://docs.antshares.org/images/2017-05-16_15-39-07.jpg)

------

### 📖 El documento está siendo editado

El documento está siendo editado y lo completaremos lo antes posible. Puedes ver otros documentos en la [wiki de Github](https://github.com/neo-project/neo/wiki/) o visita nuestro [sitio web oficial](http://www.neo.org) y echa un vistazo.

Neo es un proyecto de código abierto, si estás interesado, puedes contribuir en la documentación del desarrollo creando una solicitud Pull en GitHub, la documentación del proyecto se puede encontrar en [github.com/neo-project/docs](https://github.com/neo-project/docs), gracias por tu ayuda.
