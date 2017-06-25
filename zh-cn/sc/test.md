# 智能合约的单元测试

阅读上一篇文档后，我们已经可以用 C# 在 Visual Studio 2015 中编写智能合约了。当编写好了一段智能合约后，我们怎样才能进行单元测试呢。

## 编写单元测试

比如你创建了下面的智能合约，该合约是继承自 FunctionCode 的，包含三个参数，返回值为 int 型。


```c#
using AntShares.SmartContract.Framework;
using AntShares.SmartContract.Framework.Services.AntShares;

namespace AntShares.SmartContract
{
    public class Test1 : FunctionCode
    {
        public static int Main(int a, int b, int c)
        {
            if (a > b)
                return a * sum(b, c);
            else
                return sum(a, b) * c;
        }

        public static int sum(int a, int b)
        {
            return a + b;
        }
    }
}
```

编译通过后，生成该合约的 `Test1.avm` 文件。我们可以创建单元测试项目，对 `Test1.avm` 进行测试。

首先用 Visual Studio 创建一个 C# 控制台项目，添加对 AntShares.dll 和 AntShares.VM.dll 的引用。

> [!Note]
> 这两个文件可以通过编译 [AntShares](https://github.com/antshares/antshares) 和 [AntShares.VM](https://github.com/AntShares/AntShares.VM) 获得。

```c#
using System;
using System.IO;
using System.Linq;
using AntShares;
using AntShares.VM;
using AntShares.Cryptography;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@"C:\……\Test1.avm")); 
            
            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush(2); //对应形参c
                sb.EmitPush(4); //对应形参b
                sb.EmitPush(3); //对应形参a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); //开始执行

            var result = engine.EvaluationStack.Peek().GetBigInteger(); //在这里设置返回值
            Console.WriteLine($"执行结果 {result}");
            Console.ReadLine();
        }
    }
}
```

输出：执行结果 14，符合预期

注意：如果用上面的代码的方式传参，要注意栈顶元素对应第一个形参，为了方便也可以将传参数的代码换成下面的代码。

```c#
using (ScriptBuilder sb = new ScriptBuilder())
{
    int[] parameter = { 3, 4, 2 };
    parameter.Reverse().ToList().ForEach(p => sb.EmitPush(p));
    engine.LoadScript(sb.ToArray());
}
```
如果智能合约的返回值不是 int 类型，是 bool 或者其它类型，需要将 `engine.EvaluationStack.Peek().GetBigInteger()` 设置为其它值，如图

![](http://docs.antshares.org/images/2017-05-16_15-39-07.jpg)

------

### 📖该文档正在编辑中

该文档正在编辑中，我们会尽快完成，你可以在 [Github wiki](https://github.com/AntShares/AntShares/wiki/) 上查看其它文档，或者来我们的 [小蚁官方网站](http://www.antshares.org) 逛逛。

小蚁是一个开源的社区项目，如果你感兴趣，你也可以通过 pull request 的方式来贡献开发文档，开发文档的项目地址为 [github.com/AntShares/docs](https://github.com/AntShares/docs) ，感谢您的付出。