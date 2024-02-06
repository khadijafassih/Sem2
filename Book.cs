using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask4.BL
{
    public class Book
    {
        public string Title;
        public string Author;
        public int PublicationYear;
        public float Price;
        public int QuantityInStock;

        public Book(string title, string author, int publicationYear, float price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public string GetTitle()
        {
            return $"Title: {Title}";
        }

        public string GetAuthor()
        {
            return $"Author: {Author}";
        }

        public string GetPublicationYear()
        {
            return $"Publication Year: {PublicationYear}";
        }

        public string GetPrice()
        {
            return $"Price: {Price}";
        }

        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies > QuantityInStock)
            {
                Console.WriteLine($"Error: Not enough copies in stock. Only {QuantityInStock} copies available.");
            }
            else
            {
                QuantityInStock -= numberOfCopies;
            }
        }

        public void Restock(int additionalCopies)
        {
            QuantityInStock += additionalCopies;
        }

        public string BookDetails()
        {
            return $"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, Price: {Price}, Quantity in Stock: {QuantityInStock}";
        }
    }
}
