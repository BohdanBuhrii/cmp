using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            Cmp cmp = new Cmp();
            Console.WriteLine("output: " + cmp.PrintBytes(@"..\..\file1.txt", @"..\..\file2.txt").ToString());
            Console.Read();
        }
    }
}
