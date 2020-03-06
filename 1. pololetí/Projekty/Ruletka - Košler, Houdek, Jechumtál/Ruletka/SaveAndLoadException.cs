using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruletka
{
    class SaveAndLoadException : Exception
    {
        public SaveAndLoadException()
        {
        }
        public SaveAndLoadException(string message)
            : base (message)
        {
        }
        public SaveAndLoadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
