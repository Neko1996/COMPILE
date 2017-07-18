using System;
using System.IO;
/***********************************************************
 * 2017.7.17 创建
 * 源程序读入文件，方法包含：
 * Init     初始化读入流
 * Back     缓冲区回退
 * NextChar 从缓冲区中读一个字符
 * NextLine 从读入流中读入一行到缓冲区中
 * 
*/
namespace Compile.LexicalAnalysis
{
    class ScannerFile
    {
        int index;          //索引
        int line;           //行号
        string buffer;      //缓冲区
        StreamReader sr;    //输入流

        //初始化函数
        internal bool Init(string fileURL)
        {
            index = 0;
            line = 0;
            buffer = null;
            try
            {
                sr = new StreamReader(fileURL);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        //回退
        internal void Back()
        {
            index--;
        }

        //判断是否有下一个字符
        internal bool HasNextChar()
        {
            if (index < buffer.Length)
                return true;
            else return false;
        }

        //从buffer中获取下一个字符
        internal char NextChar()
        {
            index++;
            if (index > buffer.Length) return '\0';
            else return buffer[index - 1];
        }

        //读入一行并存入缓冲区
        internal bool NextLine()
        {
            if ((buffer = sr.ReadLine()) != null)
            {
                line++;
                index = 0;
                return true;
            }
            return false;
        }

        //获得行号
        internal int GetLineNum()
        {
            return line;
        }
    }
}
