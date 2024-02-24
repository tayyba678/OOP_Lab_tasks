using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pd6task3.UI;
using pd6task3.DL;
using pd6task3.BL;


namespace pd6task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop coffeeShop = new CoffeeShop("Coffee Shop");
            string path = "C:\\Users\\Hp\\Music\\Semester2nd\\repos\\pd6task3\\pd6task3\\file.txt.txt";
            string path1 = "C:\\Users\\Hp\\Music\\Semester2nd\\repos\\pd6task3\\pd6task3\\CoffeeShop.txt.txt";
            int op;
            do
            {
                op = MenuUI.Menu();
                if(op==1)
                {
                    AddMenu(coffeeShop,path);
                }
                else if(op==2)
                {
                     AddCoffeeSHop(path1);
                }
                else if(op==3)
                {
                    Console.WriteLine("Enter the name of Coffee Shop to which you want to find the Cheapest Item");
                    string name=Console.ReadLine();
                    Console.WriteLine(CoffeeShop.CheapestItem(name,path));
                }
                else if(op==4)
                {
                   Console.WriteLine( CoffeeShop.DrinksOnly());
                }
                else if (op == 5)
                {
                    Console.WriteLine(CoffeeShop.FoodOnly());
                }
                else if( op==6)
                {
                    Console.WriteLine("Enter the order");
                    string order=Console.ReadLine();
                    Console.WriteLine(CoffeeShop.AddOrder(order));

                }
                else if (op == 7)
                {
                    Console.WriteLine(CoffeeShop.FulfillOrder());
                }
                else if (op == 8)
                {
                    Console.WriteLine("Orders List:");
                    Console.WriteLine(CoffeeShop.Order());
                }
                else if (op == 9)
                {
                    Console.WriteLine($"Total Payable Amount: {CoffeeShop.Amount()}");
                }
            } while (op != 10);
         
        }
        
        static void AddMenu(CoffeeShop coffeeShop,string path)
        {
            Console.WriteLine("Add name of menu Item: ");
            string item=Console.ReadLine();
            Console.WriteLine("Add Product Type (Juice or Drink: ");
            string type= Console.ReadLine();
            Console.WriteLine("Write the Product Price: ");
            float price=float.Parse(Console.ReadLine());
            MenuItems menu=new MenuItems(item,type,price);
            coffeeShop.MenuItem(menu);
            CoffeeShop.LoadMenuFromFiles(path);
        }
        static void AddCoffeeSHop(string path)
        {
            Console.WriteLine("Enter the name of Coffee SHop");
            string name=Console.ReadLine();
            CoffeeShop newCoffeeShop = new CoffeeShop(name);
            CoffeeShopDL.CoffeeShops.Add(newCoffeeShop);
            CoffeeShop.LoadCoffeeShopNamesFromFile(path);
        }
    }
}
