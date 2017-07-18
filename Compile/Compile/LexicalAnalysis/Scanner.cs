using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile.LexicalAnalysis
{
    class Scanner
    {

        TokenChain tokenchain;
        ScannerState state;
        ScannerFile file;

        public Scanner(TokenChain tokenchain)           //上级编译器必须将token链传入
        {
            //TokenChain tokenchain = new TokenChain();
            this.tokenchain = tokenchain;
            file = new ScannerFile();
            state = ScannerState.Failed_To_Open_File;  //此时并没有打开文件
        }

        /// <summary>
        /// 通过url初始化scanner。
        /// </summary>
        public bool Init(string url)
        {
            if (file.Init(url))
            {
                tokenchain.Clear();
                state = ScannerState.Initialized;
                return true;
            }
            else
            {
                state = ScannerState.Failed_To_Open_File;
                AddError("源程序文件路径错误");
                return false;
            }

        }

        /// <summary>
        /// 调用自动机对源程序进行词法分析。
        /// </summary>
        public void LexicalAnalysis()
        {
            if (state == ScannerState.Initialized)
                Automata();
            else
            {
                state = ScannerState.Misuse;
                AddError("错误使用Scanner");
            }
        }

        void Automata()
        {
            state = ScannerState.Running;

            string tmpSem;
            char acceptChar;
            bool hasMistakes = false;
            while (file.NextLine())
            {
                while ((acceptChar = file.NextChar()) != '\0')
                {
                    tmpSem = "";
                    if (Char.IsDigit(acceptChar))
                    {
                        do
                        {
                            tmpSem += acceptChar;
                            acceptChar = file.NextChar();
                        } while (Char.IsDigit(acceptChar));
                        file.Back();
                        AddToken(tmpSem, TokenClassification.Num);

                    }
                    else if (Char.IsLetter(acceptChar) || acceptChar == '_')
                    {
                        do
                        {
                            tmpSem += acceptChar;
                            acceptChar = file.NextChar();
                        } while (Char.IsLetterOrDigit(acceptChar) || acceptChar == '_');
                        file.Back();
                        AddToken(tmpSem, TokenClassification.Ididentifier);
                    }
                    else
                    {
                        switch (acceptChar)
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case '{':
                            case '}':
                            case '[':
                            case ']':
                            case '(':
                            case ')':
                            case ';':
                            case ',':
                                tmpSem += acceptChar;
                                AddToken(tmpSem, TokenClassification.Sign);
                                break;
                            case '=':
                            case '<':
                            case '>':
                                tmpSem += acceptChar;
                                acceptChar = file.NextChar();
                                if (acceptChar == '=')
                                    tmpSem += acceptChar;
                                else file.Back();
                                AddToken(tmpSem, TokenClassification.Sign);
                                break;
                            case '!':
                                tmpSem += acceptChar;
                                acceptChar = file.NextChar();
                                if (acceptChar == '=')
                                {
                                    tmpSem += acceptChar;
                                    AddToken(tmpSem, TokenClassification.Sign);
                                }
                                else
                                {
                                    AddError("未定义字符'!'");
                                    file.Back();
                                }
                                break;
                            case ' ':
                            case '\t':
                                break;
                            default:
                                AddError("未定义字符'" +(int)acceptChar + "'");
                                hasMistakes = true;
                                break;
                        }
                    }
                }
            }
            if (hasMistakes)
                state = ScannerState.End_With_Lexical_Mistakes;
            else
                state = ScannerState.Success;
        }

        public bool IsRunnable() { return state == ScannerState.Initialized; }

        void AddToken(string sem, TokenClassification cl)
        {
            if(!tokenchain.AddToken(file.GetLineNum(), sem, cl))
            {
                //若未添加Token成功则进行错误处理
                //TODO
            }
        }

        void AddError(string error)
        {
            //TODO
            Console.WriteLine(error);
        }

    }
}
