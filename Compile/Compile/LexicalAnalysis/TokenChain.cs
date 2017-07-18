using Compile.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile
{
    using TokenType = Terminal;

    class TokenChain
    {
        List<Token> list = new List<Token>();

        public void Clear() { list.Clear(); }

        public bool AddToken(int line, string sem, TokenClassification type)
        {
            Token token = TokenFactor(line, sem, type);
            if (token != null) { list.Add(token); return true; }
            else { return false; }
        }

        static Token TokenFactor(int line, string sem, TokenClassification type)
        {
            if (type == TokenClassification.Ididentifier)
            {
                switch (sem)
                {
                    case "main": return new Token(line, sem, TokenType.Main);
                    case "if": return new Token(line, sem, TokenType.If);
                    case "else": return new Token(line, sem, TokenType.Else);
                    case "for": return new Token(line, sem, TokenType.For);
                    case "int": return new Token(line, sem, TokenType.Int);
                    case "void": return new Token(line, sem, TokenType.Void);
                    case "return": return new Token(line, sem, TokenType.Return);
                    default: return new Token(line, sem, TokenType.ID);
                }
            }
            else if (type == TokenClassification.Num) return new Token(line, sem, TokenType.NUM);
            else if (type == TokenClassification.Sign)
            {
                switch (sem)
                {
                    case "=": return new Token(line, sem, TokenType.Assign);
                    case "<=": return new Token(line, sem, TokenType.LowerEqual);
                    case "<": return new Token(line, sem, TokenType.Lower);
                    case ">": return new Token(line, sem, TokenType.Greater);
                    case ">=": return new Token(line, sem, TokenType.GreaterEqual);
                    case "==": return new Token(line, sem, TokenType.Equal);
                    case "!=": return new Token(line, sem, TokenType.Unequal);
                    case "+": return new Token(line, sem, TokenType.Plus);
                    case "-": return new Token(line, sem, TokenType.Minus);
                    case "*": return new Token(line, sem, TokenType.Multiply);
                    case "/": return new Token(line, sem, TokenType.Divide);
                    case ";": return new Token(line, sem, TokenType.EndSentence);
                    case ",": return new Token(line, sem, TokenType.Dot);
                    case "[": return new Token(line, sem, TokenType.RBL);
                    case "]": return new Token(line, sem, TokenType.RBR);
                    case "(": return new Token(line, sem, TokenType.CBL);
                    case ")": return new Token(line, sem, TokenType.CBR);
                    case "{": return new Token(line, sem, TokenType.FBL);
                    case "}": return new Token(line, sem, TokenType.FBR);
                    default: return null;
                }
            }
            else return null;

        }
    }
}
