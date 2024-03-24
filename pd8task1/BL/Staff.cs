using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8task3.BL
{
    internal class Staff: Person
    {
        private string School;
        private double Pay;
        public Staff(string Name, string Address, string school, double pay): base(Name, Address)
        {
            School = school;
            Pay = pay;
        }
        public string GetSchool()
        {
            return this.School;
        }
        public double GetPay()
        {
            return this.Pay;
        }
        public void SetSchool(string School)
        {
            this.School = School;
        }
        public void SetPay(double Pay)
        {
            this.Pay = Pay;
        }

        public new string ToString()
        {
            string s = "Person[name=?,address=?,school=?,pay=?]";
            return s;
        }
    }
}
