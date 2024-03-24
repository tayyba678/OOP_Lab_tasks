using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8task3.BL
{
    class Student :Person
    {
        private string Program;
        private int Year;
        private double Fee;
        public Student(string Name, string Address,string program, int year, double fee):base(Name,Address)
        {
            Program = program;
            Year = year;
            Fee = fee;
        }
        public int GetYear()
        {
            return this.Year;
        }
        public double GetFee()
        {
            return this.Fee;
        }
        public void SetYear(int Year)
        {
            this.Year = Year;
        }
        public void SetFee(double Fee)
        {
            this.Fee = Fee;
        }
        public new string ToString()
        {
            string s = "Person[name=?,address=?,program=?,year=?,fee=?]";
            return s;
        }
    }
}
