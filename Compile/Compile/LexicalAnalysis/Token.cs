using Compile.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compile
{
    using TokenType = Terminal;

    enum TokenClassification
    {
        Num,
        Ididentifier,
        Sign
    }

    class Token
    {
        TokenType type;
        string sem;
        int line;

        internal Token(int line, string sem, TokenType type)
        {
            this.line = line;
            this.sem = sem;
            this.type = type;
        }
    }
}
