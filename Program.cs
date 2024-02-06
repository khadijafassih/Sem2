using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDTask4.BL;

namespace PDTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>
            {
                new Book("Pride and Prejudice", "Jane Austen", 1813, 19.99F, 100),
                new Book("Hamlet", "William Shakespeare", 1603, 15.50F, 50),
                new Book("War and Peace", "Leo Tolstoy", 1869, 25.99F, 75)
            };

            while (true)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books Information");
                Console.WriteLine("3. Get Author Details of a Specific Book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the count of the Books Present in your BookList");
                Console.WriteLine("7. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Publication Year: ");
                        int publicationYear = int.Parse(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        float price = float.Parse(Console.ReadLine());
                        Console.Write("Enter Quantity in Stock: ");
                        int quantityInStock = int.Parse(Console.ReadLine());
                        bookList.Add(new Book(title, author, publicationYear, price, quantityInStock));
                        break;
                    case 2:
                        foreach (Book book in bookList)
                        {
                            Console.WriteLine(book.BookDetails());
                        }
                        break;
                    case 3:
                        Console.Write("Enter Title: ");
                        string searchTitle = Console.ReadLine();
                        bool bookFound = false;
                        foreach (Book book in bookList)
                        {
                            if (book.Title == searchTitle)
                            {
                                Console.WriteLine(book.GetAuthor());
                                bookFound = true;
                                break;
                            }
                        }

                        if (!bookFound)
                        {
                            Console.WriteLine("Book not found.");
                        }

                        break;
                    case 4:
                        Console.Write("Enter Title: ");
                        string sellTitle = Console.ReadLine();
                        Book sellBook = null;

                        foreach (Book book in bookList)
                        {
                            if (book.Title == sellTitle)
                            {
                                sellBook = book;
                                break;
                            }
                        }
                        if (sellBook != null)
                        {
                            Console.Write("Enter number of copies to sell: ");
                            int sellCopies = int.Parse(Console.ReadLine());
                            sellBook.SellCopies(sellCopies);
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    case 5:
                        Console.Write("Enter Title: ");
                        string restockTitle = Console.ReadLine();
                        Book restockBook = null;

                        foreach (Book book in bookList)
                        {
                            if (book.Title == restockTitle)
                            {
                                restockBook = book;
                                break;
                            }
                        }

                        if (restockBook != null)
                        {
                            Console.Write("Enter number of additional copies to restock: ");
                            int additionalCopies = int.Parse(Console.ReadLine());
                            restockBook.Restock(additionalCopies);
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    case 6:
                        Console.WriteLine($"Number of books in the list: {bookList.Count}");
                        break;
                    case 7:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

