using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Book
    {

        public string Title;
        public string Author;
        public int PublicationYear;
        public double Price;
        public int Quantity;

        public Book(string title, string author, int publicationYear, double price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            Quantity = quantityInStock;
        }
        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies > Quantity)
            {
                Console.WriteLine("Error: Not enough copies in stock.");
            }
            else
            {
                Quantity -= numberOfCopies;
                Console.WriteLine($"Sold {numberOfCopies} copies of {Title}.");
            }
        }
        public void Restock(int additionalCopies)
        {
            Quantity += additionalCopies;
            Console.WriteLine($"Restocked {additionalCopies} copies of {Title}.");
        }

        public string BookDetails()
        {
            string msg= "Title: " + Title + ", Author: " + Author + ", Publication Year: " + PublicationYear +
                   ", Price: $" + Price + ", Quantity in Stock: " + Quantity;
            return msg;
        }
    }
}
