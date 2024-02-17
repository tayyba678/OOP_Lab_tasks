using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Shiritori
    {
        public string[] words = new string[100];
        public int currentIndex = 0;

        public string Game(string alp)
        {
            if (currentIndex > 0 && words[currentIndex - 1].Last() != alp[0])
            {
                DisplayWords();
                return "Game Over!";
            }

            words[currentIndex] = alp;
            currentIndex++;

            return null;
        }

        private void DisplayWords()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}