using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDTask2.BL;

namespace PDTask2
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
            Console.WriteLine("8. Square Root.");
            Console.WriteLine("9. Exponential Function.");
            Console.WriteLine("10.Logarithm.");
            Console.WriteLine("11.Sine.");
            Console.WriteLine("12.Cosine.");
            Console.WriteLine("13.Tangent.");
            Console.WriteLine("14.Exit.");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Calculator2 calculator2 = new Calculator2();
            int choice;
            while ((choice = Menu()) != 14)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter two numbers: ");
                        float value1 = float.Parse(Console.ReadLine());
                        float value2 = float.Parse(Console.ReadLine());
                        calculator2 = new Calculator2(value1, value2);
                        break;
                    case 2:
                        Console.WriteLine("Enter new values for Value1 and Value2: ");
                        float newValue1 = float.Parse(Console.ReadLine());
                        float newValue2 = float.Parse(Console.ReadLine());
                        calculator2.Value1 = newValue1;
                        calculator2.Value2 = newValue2;
                        break;
                    case 3:
                        Console.WriteLine("Addition: " + calculator2.Add());
                        break;
                    case 4:
                        Console.WriteLine("Subtraction: " + calculator2.Subtract());
                        break;
                    case 5:
                        Console.WriteLine("Multiplication: " + calculator2 .Multiply());
                        break;
                    case 6:
                        Console.WriteLine("Division: " + calculator2.Divide());
                        break;
                    case 7:
                        Console.WriteLine("Modulo: " + calculator2.Modulo());
                        break;
                    case 8:
                        Console.WriteLine("SquareRoot: " + calculator2.Sqrt());
                        break;
                    case 9:
                        Console.WriteLine("Exponential Function: " + calculator2.Exp());
                        break;
                    case 10:
                        Console.WriteLine("Logarithm: " + calculator2.Log());
                        break;
                    case 11:
                        Console.WriteLine("Sine: " + calculator2.Sin());
                        break;
                    case 12:
                        Console.WriteLine("Cosine: " + calculator2.Cos());
                        break;
                    case 13:
                        Console.WriteLine("Tangent: " + calculator2.Tan());
                        break;
                    case 14:
                        Console.WriteLine("Exiting Program...");
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