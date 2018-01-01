# Teste de *Smart Contracts*

Após a leitura do último documento, já estamos capacitados a usar C# no Visual Studio 2015 para preparar um *smart contract*. Agora veremos como podemos testar os *smart contracts* que escrevemos.

## Escrevendo os Testes

Por exemplo, você criou o seguinte *smart contract*, o qual é herdado da classe `FunctionCode`, contém três parâmetros e retorna um valor do tipo inteiro:


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

Após compilar, o arquivo `Test1.avm` é criado e podemos criar um projeto de teste para ele.

Primeiro, crie um projeto `C# Console App (.Net Framework)` com o Visual Studio, com o framework .NET 4.6.2 ou superior. Em seguida, adicione uma referência a `Neo.dll` e `neon.dll`.

> [!Note]
> Estes dois arquivos podem ser obtidos compilando [Neo](https://github.com/neo-project/neo) e [Neo-VM](https://github.com/neo-project/neo-vm)

> Alternativamente, você pode apenas adicionar os pacotes *NuGet* "NEO" e "Neo.VM" ao seu projeto. Para tal, clique com o botão direito do mouse no projeto do *smart contract* no `Solution Explorer`; vá em `Browse`, procure por 'NEO' e instale os pacotes necessários.

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
                sb.EmitPush(2); // corresponde ao parâmetro c
                sb.EmitPush(4); // corresponde ao parâmetro b
                sb.EmitPush(3); // corresponde ao parâmetro a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // inicia execução

            var result = engine.EvaluationStack.Peek().GetBigInteger(); // aqui configura o valor de retorno 'result'
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
```

Saída da compilação: `result` = 14, como esperado.

Note que, se você utilizar o código acima para passar os parâmetros, preste atenção ao topo da pilha que representa o primeiro parâmetro. Por conveniência, também é possível passar os parâmetros com o seguinte código:


```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
Se o valor de retorno do *smart contract* não é do tipo inteiro, mas é booleano ou outro tipo, altere `engine.EvaluationStack.Peek (). GetBigInteger ()` para retornar outros valores, como mostra a figura abaixo.

<p align="center"> <img src="/pt-br/assets/test_1.jpg"> </p>


------

### 📖 O documento ainda está em fase de aprimoramento

Este documento ainda sofrerá modificações, mas você pode ver outros documentos no [Github wiki](https://github.com/neo-project/neo/wiki) ou no nosso [website oficial](http://www.neo.org).

NEO é uma comunidade *open source*. Se você estiver interessado, você também pode contribuir para a documentação criando uma *Pull Request* no GitHub. Os documentos do projeto podem ser encontrados em [github.com/neo-project/docs](https://github.com/neo-project/docs). Obrigado pela participação!
