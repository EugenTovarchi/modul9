using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul9_HW
{
    internal class MyExceptions
    {
        Exception[] exceptions =
            {
            new MyCustomException("У объекта отсутсвует фамилия!"),
            new RankException(),
            new OverflowException(),
            new IndexOutOfRangeException(),
            new ArgumentOutOfRangeException(),
        };
    }
    internal class MyCustomException : Exception 
    {
        public MyCustomException(string message) : base(message) { }
    }
}
