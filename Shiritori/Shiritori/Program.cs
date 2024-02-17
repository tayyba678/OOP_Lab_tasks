using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words ");
            Shiritori myShiritori = new Shiritori();

            for (int i = 0; i < 100; i++)
            {
                string alp = Console.ReadLine();

                string result = myShiritori.Game(alp);
                if (result != null)
                {
                    Console.WriteLine(result);
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}