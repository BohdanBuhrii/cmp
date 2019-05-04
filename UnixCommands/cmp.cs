using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixCommands
{
    public class Cmp
    {
        private readonly string version = "1.0";
        //private int output;

        //-b, --print-bytes      	print differing bytes
        public int PrintBytes()//todo
        {
            return 0;
        }

        //-i, --ignore-initial=SKIP skip first SKIP bytes of both inputs
        //-i, --ignore-initial=SKIP1:SKIP2 skip first SKIP1 bytes of FILE1 and first SKIP2 bytes of FILE2
        public int IgnoreInitialBytes()//todo
        {
            return 0;
        }

        //-l, --verbose output byte numbers and differing byte values
        public int Verbose()//todo
        {
            return 0;
        }

        //-n, --bytes=LIMIT compare at most LIMIT bytes
        public int BytesLimit()//todo
        {
            return 0;
        }

        //-s, --quiet, --silent suppress all normal output
        public int Silent()//todo
        {
            return 0;
        }

        //-v, --version output version information and exit
        public string Version()
        {
            return version;
        }

        //--help display help and exit
        public string Help()
        {
            return File.ReadAllText(@"..\..\Help.txt");
        }
    }
}
