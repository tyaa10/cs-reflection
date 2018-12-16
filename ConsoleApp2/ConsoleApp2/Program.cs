using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordsLib;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            do
            {
                do
                {
                    Console.Write("Input a number : ");
                    answer = Console.ReadLine();

                } while (!Processor.IsValidNumString(answer));

                Console.WriteLine(Processor.AddEnding(answer));

                do
                {
                    Console.Write("Continue? (y/n)? : ");
                    answer = Console.ReadLine();
                } while (!Processor.IsValidAnswer(answer));
            } while (Processor.IsAnswerYes(answer));
        }

        
    }
}
