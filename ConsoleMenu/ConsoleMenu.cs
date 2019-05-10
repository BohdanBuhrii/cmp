using System;
using System.Collections.Generic;
using System.Text;
using Helper;
using UnixCommands.General;
using UnixCommands.Concrete.Cmp;

namespace ConsoleMenu
{
    public class ConsoleMenu
    {
        private Command CurrentCommand;



        public void Init()
        {
            while (true)
            {
                Console.Write("root >>>");
                string[] input = StringHelper.Split(Console.ReadLine(), ' ');




                if (input[0] == "cmp")
                {

                    CurrentCommand = new Cmp();
                    CurrentCommand.Option = input[1];

                    if (input.Length > 2)
                    {
                        CurrentCommand.parameters = new string[input.Length];
                        for (int i = 2; i < input.Length; i++)
                        {
                            CurrentCommand.parameters[i - 2] = input[i];
                        }
                    }
                    if (CurrentCommand.Execute() == 2) Console.WriteLine("Error");


                }
                else
                {
                    Console.WriteLine("Command " + input[0] + " not found");
                }
            }
        }
    }
}