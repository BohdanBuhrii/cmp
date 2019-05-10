using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnixCommands.General;

namespace UnixCommands.Concrete.Cmp
{
    public class Cmp : Command
    {
        public override int Execute()
        {
            try
            {
                switch (Option)
                {
                    case "-b":
                        return CmpOptions.PrintBytes(parameters[0], parameters[1]);

                    case "-i":
                        if (parameters[0].Contains(":"))
                        {
                            return CmpOptions.IgnoreInitialBytes(parameters[1], parameters[2],
                                Convert.ToInt32(parameters[0].Split(':')[0]), Convert.ToInt32(parameters[0].Split(':')[1]));
                        }
                        else
                        {
                            return CmpOptions.IgnoreInitialBytes(parameters[1], parameters[2], Convert.ToInt32(parameters[0]));
                        }

                    case "-l":
                        return CmpOptions.Verbose(parameters[0], parameters[1]);

                    case "-n":
                        return CmpOptions.BytesLimit(parameters[1], parameters[2], Convert.ToInt32(parameters[0]));

                    case "-s":
                        return CmpOptions.Silent(parameters[0], parameters[1]);

                    case "-v":
                        return CmpOptions.Version();

                    case "--help":
                        return CmpOptions.Help();

                    default:
                        //todo
                        Console.WriteLine("No such option " + Option);
                        Console.WriteLine("See cmp --help");
                        return 2;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return 2;
            }
        }

        //public override void Parse(string sourse)
        //{
        //    string[] args = sourse.Split(' ');
        //    if(args[0]=="cmp")
        //}
    }
}
