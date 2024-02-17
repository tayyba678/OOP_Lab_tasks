using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pd3Calculatortask1
{
     class Calculator
    {
        public float Number1;
        public float Number2;
        public Calculator(float Number1, float Number2)
        {
            this.Number1 = Number1;
            this.Number2 = Number2;
        }
        public Calculator(float Number1)
        {
            this.Number1 = Number1;
        }
        public float Add()
        {
            return this.Number1 + this.Number2;
        }
        public float Subtract()
        {
            return this.Number1 - this.Number2;
        }
        public float Multiply()
        {
            return this.Number1 * this.Number2;
        }
        public float Divide()
        {
            if(this.Number1 <= Number2 || this.Number2 ==0) 
            {
                return 0;
            }
            return this.Number1 / this.Number2;
        }
        public float Modulo()
        {
            return this.Number1 % this.Number2;
        }
        public double SquareRoot()
        {
            return Math.Sqrt(this.Number1);
        }
        public double Exponent() 
        {
            return Math.Exp(this.Number1);
        }
        public double Logarithm()
        {
            return Math.Log(this.Number1);
        }
        public double Sin()
        {
            return Math.Sin(this.Number1);
        }
        public double Cos()
        {
            return Math.Cos(this.Number1);
        }
        public double Tan()
        {
            return Math.Tan(this.Number1);
        }
    }
}
