using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd6task3.BL
{
    internal class MenuItems
    {
        public string Name;
        public string Type;
        public float Price;
        public MenuItems(string name, string type, float price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }

}
