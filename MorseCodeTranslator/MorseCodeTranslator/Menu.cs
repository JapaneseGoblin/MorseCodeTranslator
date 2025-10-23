using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    internal class Menu
    {
        public static bool symbolSet { get; set; } = false;

        public void MenuController()
        {
            Console.WriteLine("--------Menu--------");
            Console.WriteLine("| 1. Set Charset   |");
            Console.WriteLine("| 2. Decrypt text  |");
            Console.WriteLine("| 3. Encrypt text  |");
            Console.WriteLine("--------------------");
            Console.Write("| Choice: ");
            int choice = IntInput();
            switch (choice)
            {
                case 1:
                    symbolSet = YesNo();
                    break;
                case 2:
                    Console.Write("| Enter the text to be decrypted: ");
                    string text = Console.ReadLine();

                    string decrypted = new Crypter().DeCrypt(text);
                    Console.WriteLine($"| {decrypted}");
                    break;
                case 3:
                    Console.Write("| Enter the text to be encrypted: ");
                    string text1 = Console.ReadLine();

                    string encrypted = new Crypter().EnCrypt(text1);
                    Console.WriteLine($"| {encrypted}");
                    break;
                default:
                    break;
            }

            Console.ReadKey();
            Console.Clear();
            MenuController();
        }

        public int IntInput()
        {
            Console.WriteLine("| Select from 1, 2, 3!");

            string rawInput = Console.ReadLine();
            int number;

            if (rawInput != null && 
                rawInput.Length == 1 && 
                int.TryParse(rawInput, out number) && 
                number <= 3 && number >= 1)
            {
                    return number;
            }
            else
            {
                Console.WriteLine("| Wrong input!");
            }
            return IntInput();
        }

        public bool YesNo()
        {
            Console.Write("| Do you want to use reversed morse?(yes/no)");
            string input = Console.ReadLine().ToLower();

            bool result = input switch
            {
                "yes" => true,
                "no" => false,
                _ => false,
            };

            if (result == null)
            {
                Console.WriteLine("| Wrong input!");
                return YesNo();
            }
            Console.WriteLine("| Successful character set selection!");
            return result; 

        }
    }
}
