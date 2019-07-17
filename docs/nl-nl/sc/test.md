# Smart contract Unit Testen

In de vorige stappen hebben we met C# in Visual Studio een smart contract geschreven. Hoe kunnen we unit testen uitvoeren na het schrijven van een smart contract?

## Unit testen schrijven

Stel, je maakt het volgende smart contract; het contract is gebaseerd op FunctionCode, bevat drie parameters en de `return` is `int`.


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

Na compileren is `Test1.avm` aangemaakt. We kunnen nu een unit test-project maken om deze te testen.

Maak een C# Console App (.Net Framework)-project m.b.v. Visual Studio (met .NET Framework 4.6.2 of later). Voeg als referenties `Neo.dll` en `neon.dll` toe.

> [!Note]
> Deze twee bestanden kunnen worden verkregen door [Neo](https://github.com/neo-project/neo) en [neo-vm](https://github.com/neo-project/neo-vm) te compileren.
> Een alternatief is het toevoegen van NuGet-packages "NEO" en "Neo.VM" aan je project. Dit doe je door met de rechter muisknop op het contract project te klikken in de Solution Explorer, ga naar Browse, zoek op NEO en installeer de vereiste pakketten.

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
                sb.EmitPush(2); // overeeenkomstig met parameter c
                sb.EmitPush(4); // overeeenkomstig met parameter b
                sb.EmitPush(3); // overeeenkomstig met parameter a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // start execution

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // bepaal hier de return value
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

De compileer-output: Execution result 14, zoals verwacht.

> [!Note]
> Als je bovenstaande code gebruikt om de parameters in te voeren, let er dan op dat de bovenkant van de stack overeenkomt met de eerste parameter. Voor het gemak kunnen de parameters ook m.b.v. de volgende code worden ingevoerd:

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```

Als de `return` van het smart contract niet in het type `int` is, maar `bool` of een ander type, moet `engine.EvaluationStack.Peek().GetBigInteger()` andere waarden krijgen, zoals in de afbeelding hieronder:

[](/assets/test_1.jpg)

------

### 📖 Dit document is nog in aanmaak

Het document wordt nog steeds bewerkt en wordt zo spoedig mogelijk afgerond. Je kan andere documenten bekijken op de [GitHub wiki](https://github.com/neo-project/neo/wiki) of op de [NEO-website](http://www.neo.org) kijken.

NEO is een community-gedreven open source project. Als je wilt contribueren, kan je een Pull Request aanmaken op GitHub. De documentatie van het project kan worden gevonden op [github.com/neo-project/docs](https://github.com/neo-project/docs). Alvast bedankt voor je bijdrage!
