using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask1
{
    public class Calculator
    {
        public float Value1;
        public float Value2;

        public Calculator(float value1, float value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public Calculator()
        {
            this.Value1 = 0;
            this.Value1 = 0;
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
    }
}
