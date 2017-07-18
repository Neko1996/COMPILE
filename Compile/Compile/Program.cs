using Compile.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile
{
    class Program
    {
        static void Main(string[] args)
        {
            //基于C-语言的编译器综合测试程序
            DebugScanner();
        }

        static void DebugScanner()
        {
            TokenChain tc = new TokenChain();
            Scanner s = new Scanner(tc);
            s.Init("E:\\1.txt");
            s.LexicalAnalysis();
            Console.ReadLine();
        }
    }
}
