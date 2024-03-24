using Lab8task3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student("Khan", "ABC", "CS", 2023,10000);
            Console.WriteLine(std.GetName() +" "+ std.GetYear() +" "+ std.GetFee());
            Console.WriteLine(std.ToString());
            Console.Read();
        }
    }
}
