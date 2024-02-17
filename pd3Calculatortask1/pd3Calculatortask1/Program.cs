using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd3Calculatortask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st number: ");
            float n1=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number: ");
            float n2=float.Parse(Console.ReadLine());
            Calculator num = new Calculator(n1, n2);

            Console.Clear();

            int ch;
            do
            {

                ch = Menu();
                if (ch==1)
                {
                    Console.WriteLine(num.Add());
                    Console.ReadKey();
                    Console.Clear();
                }
                if (ch == 2)
                {
                    Console.WriteLine(num.Subtract());
                    Console.ReadKey();
                    Console.Clear();
                }
                if (ch == 3)
                {
                    Console.WriteLine(num.Multiply());
                    Console.ReadKey();
                    Console.Clear();
                }
                if (ch == 4)
                {
                    Console.WriteLine(num.Divide());
                    Console.ReadKey();
                    Console.Clear();
                }
                if (ch == 5)
                {
                    Console.WriteLine(num.Modulo());
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (ch != 6);

        }
        static int Menu()
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Modulo");
            Console.WriteLine("6. Exit");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
