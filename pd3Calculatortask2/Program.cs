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

            int ch;
            ch = Menu();

            while (ch != 0)
            {
                Console.Clear();

                if (ch >= 1 && ch <= 5)
                {
                    Console.WriteLine("Enter 1st number: ");
                    float n1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter 2nd number: ");
                    float n2 = float.Parse(Console.ReadLine());
                    Calculator num = new Calculator(n1, n2);

                    if (ch == 1)
                    {
                        Console.WriteLine(num.Add());
                    }
                    else if (ch == 2)
                    {
                        Console.WriteLine(num.Subtract());
                    }
                    else if (ch == 3)
                    {
                        Console.WriteLine(num.Multiply());
                    }
                    else if (ch == 4)
                    {
                        Console.WriteLine(num.Divide());
                    }
                    else if (ch == 5)
                    {
                        Console.WriteLine(num.Modulo());
                    }
                }
                else if (ch >= 6 && ch <= 11)
                {
                    Console.WriteLine("Enter any number: ");
                    float n = float.Parse(Console.ReadLine());
                    Calculator nums = new Calculator(n);

                    if (ch == 6)
                    {
                        Console.WriteLine(nums.SquareRoot());
                    }
                    else if (ch == 7)
                    {
                        Console.WriteLine(nums.Exponent());
                    }
                    else if (ch == 8)
                    {
                        Console.WriteLine(nums.Logarithm());
                    }
                    else if (ch == 9)
                    {
                        Console.WriteLine(nums.Sin());
                    }
                    else if (ch == 10)
                    {
                        Console.WriteLine(nums.Cos());
                    }
                    else if (ch == 11)
                    {
                        Console.WriteLine(nums.Tan());
                    }
                }

                Console.ReadKey();
                Console.Clear();
                ch = Menu();
            }
        }

            static int Menu()
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Modulo");
                Console.WriteLine("6. Square Root");
                Console.WriteLine("7. Exponential Function");
                Console.WriteLine("8. Logarithm");
                Console.WriteLine("9. Sin");
                Console.WriteLine("10. Cos");
                Console.WriteLine("11. Tan");
                Console.WriteLine("12. Exit");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 12)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 12.");
                }

                return option;
            }
        }
    }

