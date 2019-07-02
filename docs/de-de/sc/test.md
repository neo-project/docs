# Smart Contract Unit Test

Nachdem Sie das vorherige Dokument gelesen haben, sind wir in der Lage mit C# in Visual Studio 2015 einen Smart Contract vorzubereiten. Wie können wir Unit Tests machen nachdem wir einen Smart Contract geschrieben haben?

## Unit Tests schreiben

Wenn Sie zum Beispiel folgenden Smart Contract kreieren, welcher 3 Parameter enthält, ist der return-Wert int.


```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace Neo.SmartContract
{
    public class Test1: SmartContract
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

Generieren Sie die 'Test1.avm' Datei nach dem Compiling. Wir können ein Unit Test Projekt erstellen und 'Test1.avm' testen.

Kreieren Sie zuerst ein C# Console App (.Net Framework) Projekt mit Visual Studio, mit .NET Framework 4.6.2 oder neuer. Fügen Sie danach eine Referenz zu 'Neo.dll' und 'neon.dll' hinzu.

> [!Anmerkung]
> Diese 2 Dateien erhalten Sie durch das kompilieren von [Neo](https://github.com/neo-project/neo) und [neo-vm](https://github.com/neo-project/neo-vm).

> Alternativ können sie auch einfach die NuGet packages "NEO" und "Neo.VM" zu Ihrem Projekt hinzufügen, indem sie im Solution Explorer mit Rechtsklick auf Ihr Contract Projekt klicken, gehen Sie dann zu Browse, suchen Sie NEO und installieren Sie die benötigten Packages.

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
                sb.EmitPush(2); // corresponds to the parameter c
                sb.EmitPush(4); // corresponds to the parameter b
                sb.EmitPush(3); // corresponds to the parameter a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // start execution

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // set the return value here
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

Compile Output: Execution result 14, wie erwartet

Anmerkung: Wenn Sie obigen Code benutzen um Parameter weiter zu geben, achten Sie auf den oberen Teil des Stack, der dem ersten Parameter entspricht. Sie können Parameter auch mit folgendem Code weiter geben:


```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```

Wenn der return-Wert des Smart Contract nicht vom Typ int ist, sondern bool oder ein anderer Typ, müssen Sie `engine.EvaluationStack.Peek (). GetBigInteger ()` auf andere Werte einstellen, wie in der Abbildung gezeigt.

[](/assets/test_1.jpg)

------

### 📖 Dieses Dokument ist noch nicht fertiggestellt. Wir werden es so schnell wie möglich fertig stellen.



