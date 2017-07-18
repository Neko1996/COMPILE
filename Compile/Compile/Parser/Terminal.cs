
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Compile.Parser
{
    enum Terminal
    {
        /*关键字*/
        Else,
        If,
        Int,
        Return,
        Void,
        For,
        Main,
        /*正则表达式定义的其他标记*/
        ID,
        NUM,
        /*专用符号 */
        Assign,               //  =
        LowerEqual,            //  <=
        Lower,                 //  <
        Greater,               //  >
        GreaterEqual,          //  >=
        Equal,                 //  ==
        Unequal,              //  !=
        Plus,                  //  +
        Minus,                 //  -
        Multiply,              //  *
        Divide,                //  /
        EndSentence,           //  ;
        Dot,                    //  ,
        RBL,                   //  [
        RBR,                   //  ]
        CBL,                   //  (
        CBR,                   //  )
        FBL,                   //  {
        FBR,                   //  }
        /*特殊符号*/
        None,
    }
}