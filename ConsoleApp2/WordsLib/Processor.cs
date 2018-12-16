using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reg = System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsLib
{
    public class Processor
    {
        public static bool IsAnswerYes(string answer)
        {
            return answer == "yes" || answer == "y" || answer == "Yes" || answer == "Y";
        }
        public static bool IsValidAnswer(string answer)
        {
            return IsAnswerYes(answer) || answer == "n" || answer == "N" || answer == "No" || answer == "no";
        }

        public static bool IsValidNumString(string answer)
        {
            return reg.Regex.IsMatch(answer, "^[0-9]{1,1000}$");
        }

        public static string AddEnding(string str)
        {
            int number = Int32.Parse(str);
            if (IsException(number))
            {
                return "Voron";
            }
            int num10 = number % 10;

            switch (num10)
            {
                case 1:
                    return "Vorona";
                case 2:
                case 3:
                case 4:
                    return "Voroni";
                default:
                    return "Voron";
            }
        }
        public static bool IsException(int num)
        {
            return num % 100 <= Convert.ToInt32(GrammarExceptions._LAST_EXC) && num >= Convert.ToInt32(GrammarExceptions._FIRST_EXC);
        }
    }
}
