using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask2.BL
{
    public class Calculator2
    {

        public float Value1;
        public float Value2;

        public Calculator2(float value1, float value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public Calculator2()
        {
            this.Value1 = 0;
            this.Value2 = 0;
        }
        public Calculator2(float number)
        {
            Value1 = number;
        }
        public float Add()
        {
            float sum = Value1 + Value2;
            return sum;
        }
        public float Subtract()
        {
            float subtract = Value1 - Value2;
            return subtract;
        }
        public float Multiply()
        {
            float Product = Value1 * Value2;
            return Product;
        }
        public float Divide()
        {
            if (Value2 == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return 0;
            }
            return Value1 / Value2;
        }
        public float Modulo()
        {
            float Modulo = Value1 % Value2;
            return Modulo;
        }
        public float Sqrt()
        {
            if (Value1 < 0)
            {
                Console.WriteLine("Error: Square root of negative number is not allowed.");
                return 0;
            }
            return (float)Math.Sqrt(Value1);
        }
        public float Exp()
        {
            return (float)Math.Pow(Value2, Value1);
        }
        public float Log()
        {
            if (Value1 <= 0)
            {
                Console.WriteLine("Error: Logarithm of zero or negative number is not allowed.");
                return 0;
            }
            return (float)Math.Log(Value1);
        }
        public float Sin()
        {
            float ans = (float)Math.Sin(Value2);
            return ans * (180 / (float)(Math.PI));
        }
        public float Cos()
        {
            return (float)Math.Cos(Value2);
        }
        public float Tan()
        {
            return (float)Math.Tan(Value2);
        }
    }
}

