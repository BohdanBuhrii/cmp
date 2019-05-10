using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixCommands.General
{
    public abstract class Command
    {
        public string Option;
        public string[] parameters;
        public abstract int Execute();
        //public abstract void Parse(string source);
    }
}
