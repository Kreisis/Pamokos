using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class AnswerMachine { 
        DateTime time;
        public string Answer { get; private set; }
        public AnswerMachine(string ats)
        {
            Answer = ats;
            time = DateTime.Now;
        }
}
    public class Bot
    {
        static string path = @"D:\Saugykla\Karolis Medekša\Pamokos\5_pamoka_11_08\chatBot.txt";
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public void AddToDictionary(string key, string value)
        {
            dictionary.Add(key, value);
            File.AppendAllText(path, Environment.NewLine + key + "~" + value);
        }

        private string[] lines;

        public Bot()
        {
            ReadLines();
        }

        public AnswerMachine GiveAnswer(string input)
        {
            if (dictionary.ContainsKey(input))
            {
                return new AnswerMachine(dictionary[input.ToLower()]);
            }
            else
            {
                return new AnswerMachine("Nfound");
            }
        }

        private void ReadLines()
        {
            lines = File.ReadAllLines(@"D:\Saugykla\Karolis Medekša\Pamokos\5_pamoka_11_08\chatBot.txt");
            foreach (string line in lines)
            {
                string[] ll = new string[2];
                ll = line.Split('~');
                dictionary.Add(ll[0].Trim().ToLower(), ll[1].Trim().ToLower());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bot botas = new Bot();
                      
            while (true)
            {
                string input;
                input = Console.ReadLine();
                AnswerMachine ansMachine;
                ansMachine = botas.GiveAnswer(input.ToLower());
                if (input.ToLower() == "quit")
                {
                    return;
                }
                if (ansMachine.Answer == "Nfound")
                {
                    string s;
                    Console.WriteLine("I don't understand you, would you like me to learn? (y/n)");
                    while (true)
                    {
                        s = Console.ReadLine();
                        if (s == "y" || s == "n")
                        {
                            break;
                        }
                    }
                    if (s == "y")
                    {
                        string value;
                        Console.WriteLine("What do you want me to say?");
                        value = Console.ReadLine();
                        botas.AddToDictionary(input.ToLower().Trim(), value.ToLower().Trim());
                    }
                    continue;
                }
                Console.WriteLine(ansMachine.Answer);
            }

            Console.ReadLine();
        }
    }
}
