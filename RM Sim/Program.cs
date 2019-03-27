using System;
using System.Collections.Generic;
using System.IO;


namespace RMSim
{
    class Program
    {
        static void Main(string[] args)
        {
            RM rm = new RM();
            List<string> inputfiles=new List<string>();
            List<string> parsed=new List<string>();
            string line;
            
            while (true)
            {
                Console.WriteLine("type any letter to exit");            
                try
                {
                    using (StreamReader sr = new StreamReader("File.txt"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Length % 4 == 0)
                            {
                                for (int i = 0; i < line.Length; i += 2)
                                {
                                    parsed.Add(line.Substring(i, 2));
                                }
                            }
                            rm.ParseCommands(parsed.ToArray());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found or couldn't be read");
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
        }
    }
    class RM
    {
        //private int pc;
        private List<int> registers;
        enum RMCommands
        {
            ADD, SUB, MUL, DIV, LDA, LDK, STA, INP, OUT, HLT, JMP, JEZ, JNE, JLZ, JLE, JGZ, JGE
        }

        static Dictionary<string, RMCommands> Commandstrings = new Dictionary<string, RMCommands>
        {
            {"01", RMCommands.ADD },
            {"02", RMCommands.SUB },
            {"03", RMCommands.MUL },
            {"04", RMCommands.DIV },
            {"05", RMCommands.LDA },
            {"06", RMCommands.LDK },
            {"07", RMCommands.STA },
            {"08", RMCommands.INP },
            {"09", RMCommands.OUT },
            {"0A", RMCommands.HLT },
            {"0B", RMCommands.JMP },
            {"0C", RMCommands.JEZ },
            {"0D", RMCommands.JNE },
            {"0E", RMCommands.JLZ },
            {"0F", RMCommands.JLE },
            {"10", RMCommands.JGZ },
            {"11", RMCommands.JGE }
        };

        public RM()
        {
            registers = new List<int>();
            for (int i = 0; i < 128; i++)
            {
                registers.Add(0);
            }
        }
        public void ParseCommands(string[] commandlist)
        {
            for(int i=0; i<commandlist.Length-1; i+=2)
            {
                if(Commandstrings.ContainsKey(commandlist[i]))
                {
                    switch (Commandstrings[commandlist[i]])
                    {
                        case RMCommands.ADD:
                            registers[0] += registers[int.Parse(commandlist[i + 1])];
                            break;
                        case RMCommands.SUB:
                            registers[0] -= registers[int.Parse(commandlist[i + 1])];
                            break;
                        case RMCommands.MUL:
                            registers[0] *= registers[int.Parse(commandlist[i + 1])];
                            break;
                        case RMCommands.DIV:
                            registers[0] /= registers[int.Parse(commandlist[i + 1])];
                            break;
                        case RMCommands.LDA:
                            registers[0] = registers[int.Parse(commandlist[i + 1])];
                            break;
                        case RMCommands.LDK:
                            registers[0] =int.Parse(commandlist[i + 1]);
                            break;
                        case RMCommands.STA:
                            registers[int.Parse(commandlist[i + 1])] = registers[0];
                            break;
                        case RMCommands.INP:
                            Console.WriteLine("Input required");
                            registers[int.Parse(commandlist[i+1])] = int.Parse(Console.ReadLine());
                            break;
                        case RMCommands.OUT:
                            Console.WriteLine(registers[int.Parse(commandlist[i + 1])]);
                            break;
                        case RMCommands.HLT:
                            i = commandlist.Length + 1;
                            break;
                        case RMCommands.JMP:
                            i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                            break;
                        case RMCommands.JEZ:
                            {
                                if (registers[0] == 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;
                        case RMCommands.JNE:
                            {
                                if (registers[0] != 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;
                        case RMCommands.JLZ:
                            {
                                if (registers[0] < 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;
                        case RMCommands.JLE:
                            {
                                if (registers[0] <= 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;
                        case RMCommands.JGZ:
                            {
                                if (registers[0] > 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;
                        case RMCommands.JGE:
                            {
                                if (registers[0] >= 0)
                                {
                                    i = (int.Parse(commandlist[i + 1]) - 1) * 2;
                                }
                            }
                            break;                        
                    }
                }
            }
            Console.WriteLine("Program ended");
            Console.ReadKey();
        }
    }
}