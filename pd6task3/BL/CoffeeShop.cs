using pd6task3.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace pd6task3.BL
{
    internal class CoffeeShop
    {
        public string Name;
        public static List<string> orders = new List<string>();
        public static List<MenuItems> menu = new List<MenuItems>();

        public CoffeeShop(string name)
        {
            Name = name;
        }

        public MenuItems MenuItem(MenuItems menus)
        {
            menu.Add(menus);
            return menus;
        }

        public static string AddOrder(string itemName)
        {
            MenuItems menuItem = null;
            foreach (var item in menu)
            {
                if (item.Name == itemName)
                {
                    menuItem = item;
                    break;
                }
            }
            if (menuItem != null)
            {
                orders.Add(itemName);
                return "Order added!";
            }
            else
            {
                return "This item is currently unavailable!";
            }
        }

        public static string FulfillOrder()
        {
            if (orders.Any())
            {
                string itemName = orders.First();
                orders.Remove(itemName);
                return $"The {itemName} is ready!";
            }
            else
            {
                return "All orders have been fulfilled!";
            }
        }

        public static List<string> Order()
        {
            foreach (string order in orders)
            {
                if (order.Any())
                    return orders;
            }

            return null;
        }

        public static void LoadCoffeeShopNamesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length > 0)
                    {
                        CoffeeShopDL.CoffeeShops.Add(new CoffeeShop(parts[0].Trim()));
                    }
                }
                Console.WriteLine("Coffee shop names loaded successfully!");
            }
            else
            {
                Console.WriteLine($"Error: File not found at {filePath}");
            }
        }

        public static void LoadMenuFromFiles(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0].Trim('\"');
                        string type = parts[1].Trim();
                        float price;
                        if (float.TryParse(parts[2].Trim(), out price))
                        {
                            MenuItems menuItem = new MenuItems(name, type, price);
                            menu.Add(menuItem);
                        }
                        else
                        {
                            Console.WriteLine($"Error parsing price for item: {name}. Skipping this item.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line format: {line}. Skipping this line.");
                    }
                }
                Console.WriteLine("Menu loaded successfully!");
            }
            else
            {
                Console.WriteLine($"Error: File not found at {filePath}");
            }
        }

        public static float Amount()
        {
            float sum = 0;
            foreach (MenuItems order in menu)
            {
                if (order.Price != 0)
                {
                    sum = sum + order.Price;
                    return sum;
                }
            }
            return 0;
        }
        public static MenuItems CheapestItem(string coffeeShopName, string menuFilePath)
        {
            LoadMenuFromFiles(menuFilePath);  
            if (menu != null && menu.Any())
            {
                MenuItems cheapestItem = menu.First();
                foreach (MenuItems menuItem in menu)
                {
                    if (menuItem.Price < cheapestItem.Price)
                    {
                        cheapestItem = menuItem;
                    }
                }

                Console.WriteLine($"Cheapest item at {coffeeShopName}: {cheapestItem.Name} - Type: {cheapestItem.Type}, Price: {cheapestItem.Price}");
                return cheapestItem;
            }
            else
            {
                Console.WriteLine($"No Items in Menu at {coffeeShopName}");
                return null;
            }
        }

        public static string DrinksOnly()
        {
            bool foundDrink = false;
            string drinkNames = "";
            foreach (MenuItems menus in menu)
            {
                if (menus.Type == "Drink")
                {
                    foundDrink = true;
                    drinkNames += menus.Name + ", ";
                }
            }

            if (foundDrink)
            {
                return drinkNames;
            }
            else
            {
                Console.WriteLine("No Drinks in Menu");
                return null;
            }
        }
        public static string FoodOnly()
        {
            bool foundDrink = false;
            string foodNames = "";
            foreach (MenuItems menus in menu)
            {
                if (menus.Type == "Food")
                {
                    foundDrink = true;
                    foodNames += menus.Name + ", ";
                }
            }

            if (foundDrink)
            {
                return foodNames;
            }
            else
            {
                Console.WriteLine("No Drinks in Menu");
                return null;
            }
        }
    }
}
