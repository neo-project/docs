# Smart contract unit test

After reading the previous document, we have been able to use C# in Visual Studio 2015 to prepare a smart contract. How can we do unit tests after writing a smart contract?

## Write unit tests

For example, you create the following smart contract, the contract is inherited from the FunctionCode, contains three parameters, the return value is int.


```c#
using AntShares.SmartContract.Framework;
using AntShares.SmartContract.Framework.Services.AntShares;

namespace AntShares.SmartContract
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

After compiling, generate the contract's `Test1.avm` file. We can create unit test items and test `Test1.avm`.

First create a C# console project with Visual Studio. Then add a reference to `AntShares.dll` and `AntShares.VM.dll`.

> [!Note]
> These two files can be obtained by compiling [AntShares](https://github.com/antshares/antshares) and [AntShares.VM](https://github.com/AntShares/AntShares.VM).

```c#
using System;
using System.IO;
using System.Linq;
using AntShares;
using AntShares.VM;
using AntShares.Cryptography;

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
            Console.WriteLine($"result {result}");
            Console.ReadLine();
        }
    }
}
```

Output: Execution result 14, in line with expectations

Note: If you use the above code to pass the way, pay attention to the top of the stack corresponding to the first parameter, for the convenience of the parameters can also pass the code into the following code.

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = {3, 4, 2};
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
If the return value of the smart contract is not of type int, is bool or other type, you need to set `engine.EvaluationStack.Peek (). GetBigInteger ()` to other values, as shown in Figure

[](Http://docs.antshares.org/images/2017-05-16_15-39-07.jpg)

------

### 📖 The document is being edited

The document is being edited and we will complete it as soon as possible. You can view other documents on [Github wiki](https://github.com/AntShares/AntShares/wiki/) or come to our [i ant official website] Http://www.antshares.org) stroll.

Is an open source community project, if you are interested, you can also pull request the way to contribute to the development of documents, the development of the document project address [github.com/AntShares/docs](https://github.com/AntShares/docs), thank you for paying.
