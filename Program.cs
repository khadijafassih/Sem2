using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask1
{
    internal class Program
    {
        static int Menu()
        {
            Console.WriteLine("1. Create the a Single Object of Calculator");
            Console.WriteLine("2. Change Values of Attributes");
            Console.WriteLine("3. Addition.");
            Console.WriteLine("4. Subtraction.");
            Console.WriteLine("5. Multiplication.");
            Console.WriteLine("6. Division.");
            Console.WriteLine("7. Modulo.");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }
        public static void Main()
        {
            Calculator calculator = new Calculator();
            int choice;
            while ((choice = Menu()) != 8)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter two numbers: ");
                        float value1 = float.Parse(Console.ReadLine());
                        float value2 = float.Parse(Console.ReadLine());
                        calculator = new Calculator(value1, value2);
                        break;
                    case 2:
                        Console.WriteLine("Enter new values for Value1 and Value2: ");
                        float newValue1 = float.Parse(Console.ReadLine());
                        float newValue2 = float.Parse(Console.ReadLine());
                        calculator.Value1 = newValue1;
                        calculator.Value2 = newValue2;
                        break;
                    case 3:
                        Console.WriteLine("Addition: " + calculator.Add());
                        break;
                    case 4:
                        Console.WriteLine("Subtraction: " + calculator.Subtract());
                        break;
                    case 5:
                        Console.WriteLine("Multiplication: " + calculator.Multiply());
                        break;
                    case 6:
                        Console.WriteLine("Division: " + calculator.Divide());
                        break;
                    case 7:
                        Console.WriteLine("Modulo: " + calculator.Modulo());
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    Console.Read();
                }
            }
        }
    }
}
    


