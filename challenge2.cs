using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Program
    {
        static List<Product> products = new List<Product>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("Products Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            ShowProducts();
                            break;
                        case 3:
                            ShowTotalStoreWorth();
                            break;
                        case 0:
                            Console.WriteLine("Exiting the program.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (choice != 4);
        }

        static void AddProduct()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter BrandName: ");
            string brandName = Console.ReadLine();

            Console.Write("Enter Country: ");
            string country = Console.ReadLine();
            Product product = new Product(id, name, price, category, brandName, country);

            products.Add(product);

            Console.WriteLine("Product added successfully!\n");
        }

        static void ShowProducts()
        {
            if (products.Count > 0)
            {
                Console.WriteLine("List of Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}, BrandName: {product.BrandName}, Country: {product.Country}");
                }
            }
            else
            {
                Console.WriteLine("No products added yet.\n");
            }
        }

        static void ShowTotalStoreWorth()
        {
            double totalWorth = 0;

            foreach (var product in products)
            {
                totalWorth += product.Price;
            }

            Console.WriteLine($"Total Store Worth: {totalWorth:C}\n");
        }
    }
}