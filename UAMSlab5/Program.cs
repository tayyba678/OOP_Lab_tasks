using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSlab5;

namespace UAMSlab5
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = MenuUI.Menus();
                if (choice == 1)
                {
                    StudentUI.AddStudent();
                }
            }

        }

    }
}

