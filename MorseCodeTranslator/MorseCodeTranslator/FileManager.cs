using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    internal class FileManager
    {
        private Dictionary<char, string> morseMap;
        public FileManager()
        {
            morseMap = new Dictionary<char, string>();

            string fileName = "basicCharset.txt";

            foreach (var x in File.ReadAllLines(fileName, Encoding.UTF8))
            {
                var inputs = x.Split(';').ToList();
                var character = char.Parse(inputs[0]);
                var code = inputs[1];
                morseMap[character] = code;
            }
        }

        public Dictionary<char, string> GetMorseMap()
        {
            return morseMap;
        }
    }
}
