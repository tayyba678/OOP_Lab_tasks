using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        static List<string> BookLists = new List<string>();

        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            int choice = 0;
            do
            {
                choice = MenuOptions();
                if (choice == 1)
                {
                    AddBook(bookList);
                    Console.Clear();
                }
                else if (choice == 2)
                {
                    ViewAllBooks(bookList);
                    Console.Clear();
                }
                else if (choice == 3)
                {
                    GetAuthorDetails(bookList);
                    Console.Clear();
                }
                else if (choice == 4)
                {
                    SellCopies(bookList);
                    Console.Clear();
                }
                else if (choice == 5)
                {
                    Restock(bookList);
                    Console.Clear();
                }
                else if (choice == 6)
                {
                    Console.WriteLine($"Total Books: {bookList.Count}");
                    Console.Clear();
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a valid option.");
                    Console.Clear();
                }
            }
            while (choice != 7);

            }

        static void AddBook(List<Book> bookList)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publication Year: ");
            int publicationYear = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Quantity in Stock: ");
            int quantityInStock = int.Parse(Console.ReadLine());

            Book newBook = new Book(title, author, publicationYear, price, quantityInStock);
            bookList.Add(newBook);

            Console.WriteLine($"Book '{title}' added successfully!");
        }

        static void ViewAllBooks(List<Book> bookList)
        {
            foreach (var book in bookList)
            {
                Console.WriteLine(book.BookDetails());
            }
        }

        static void GetAuthorDetails(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();
            Book foundBook = null;
            foreach (var book in bookList)
            {
                if (book.Title == title)
                {
                    foundBook = book;
                    break;
                }
            }
            if (foundBook != null)
            {
                Console.WriteLine("Author: " + foundBook.Author);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        static void SellCopies(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();
            Book foundBook = null;
            foreach (var book in bookList)
            {
                if (book.Title == title)
                {
                    foundBook = book;
                    break;
                }
            }
            if (foundBook != null)
            {
                Console.Write("Enter number of copies to sell: ");
                int numberOfCopies = int.Parse(Console.ReadLine());
                foundBook.SellCopies(numberOfCopies);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        static void Restock(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();
            Book foundBook = null;
            foreach (var book in bookList)
            {
                if (book.Title == title)
                {
                    foundBook = book;
                    break;
                }
            }
            if (foundBook != null)
            {
                Console.Write("Enter number of additional copies to restock: ");
                int additionalCopies = int.Parse(Console.ReadLine());
                foundBook.Restock(additionalCopies);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    
    static int MenuOptions()
        {

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View all the Books");
            Console.WriteLine("3. GetAuthor Details");
            Console.WriteLine("4. Sell Copies of specific Book");
            Console.WriteLine("5. Restock a specific Book");
            Console.WriteLine("6. See the Count");
            Console.WriteLine("7. Exit");          
            Console.Write("Enter your choice: ");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }

    }
}