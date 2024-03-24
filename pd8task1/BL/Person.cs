using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8task3.BL
{
    internal class Person
    {
        protected string Name;
        protected string Address;
        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string GetName()
        {
           return this.Name;
        }
        public string GetAddress()
        {
            return this.Address;
        }
        public void SetAddress(string address)
        {
            this.Address = address;
        }
        public override string ToString()
        {
             string s="Person[name=?,address=?]";
            return s;
        }
    }
}
