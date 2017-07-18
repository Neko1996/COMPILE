using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Compile.LexicalAnalysis
{
    enum ScannerState
    {
        Initialized,                //已初始化
        Running,                    //正在运行
        Failed_To_Open_File,        //错误打开文件
        End_With_Lexical_Mistakes,  //结束，伴有词法错误
        Misuse,                     //错误使用
        Success,                    //成功
    }
}