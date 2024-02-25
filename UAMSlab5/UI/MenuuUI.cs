using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSlab5
{
    class MenuUI
    {
        public static int Menus()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. View Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a specific Program");
            Console.WriteLine("6. Registered Subjects for a specific Students");
            Console.WriteLine("7. Calculate Fees for all registered Students");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

    }
}
