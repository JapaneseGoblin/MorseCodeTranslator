using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MorseCodeTranslator
{
    internal class Crypter
    {
        private FileManager _manager;
        public static Dictionary<char, string> morseMap;

        public Crypter()
        {
            _manager = new FileManager();
            morseMap = _manager.GetMorseMap();
        }

        public string DeCrypt(string morseCode)
        {
            string result = "";

            if (Menu.symbolSet)
            {
                morseCode = new string(Revese(morseCode).ToArray());
            }

            foreach (string x in morseCode.Split(null))
            {
                string search = morseMap.FirstOrDefault(y => y.Value == x).Key.ToString();
                result += search;
            }

            if (result == "")
            {
                Console.WriteLine("| Wrong input!");
            }
            return result;
        }
        public string EnCrypt(string text)
        {
            string result = "";



            foreach (char x in text.ToLower())
            {
                string search = morseMap[x];
                result += search + " ";
            }

            if (result == "")
            {
                Console.WriteLine("| Wrong input!");
            }
            if (Menu.symbolSet)
            {
                return new string(Revese(result).ToArray());
            }

            return result;
        }

        public IEnumerable<char> Revese(string input)
        {
            foreach (char x in input.ToLower()) 
            {
                if (x == '-') 
                {
                    yield return '.';
                }
                else if (x == '.')
                {
                    yield return '-';
                }
                else
                {
                    yield return x;
                }
            }
        }
    }
}
