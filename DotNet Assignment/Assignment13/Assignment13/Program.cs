using System;
using System.Collections.Generic;

namespace Assignment13
{
    class Book
    {
        public string bookName;
        public double price;
        public string authorName;
        public string publicationName;
        public long noOfCopy;

        public Book()
        {

        }

        public Book(string bookName, double price, string authorName, string publicationName, long noOfCopy)
        {
            this.bookName = bookName;
            this.price = price;
            this.authorName = authorName;
            this.publicationName = publicationName;
            this.noOfCopy = noOfCopy;
        }
        
        public void Accept()
        {
            Console.WriteLine("\n Enter the detail of Book: ");
            Console.WriteLine("---------------------------------------------------------------------------\n");

            Console.Write("Book Name: ");
            bookName = Console.ReadLine();

            Console.Write("Book Author Name: ");
            authorName = Console.ReadLine();

            Console.Write("Book Publication Name: ");
            publicationName = Console.ReadLine();

            Console.Write("Book Price: ");
            price = Convert.ToDouble(Console.ReadLine());

            Console.Write("No of Copy: ");
            noOfCopy = Convert.ToInt64(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("\n Book Detail:-> ");
            Console.WriteLine("BookName: {0}",bookName);
            Console.WriteLine("Author Name: {0}",authorName);
            Console.WriteLine("Publication Name: {0}",publicationName);
            Console.WriteLine("Book Prices: {0}",price);
            Console.WriteLine("No of Copy: {0}",noOfCopy);
        }
    }

    class BookManagement
    {
        List<Book> bookList = new List<Book>();

        public void AddNewBook()
        {
            Book book = new Book();
            book.Accept();
            bookList.Add(book);
            Console.WriteLine("Book is successfully added");
        }

        public void DisplayBookDetail( string bookName)
        {
            foreach (var book in bookList)
            {
                if( book.bookName.Equals(bookName) )
                {
                    book.Display();
                    break;
                }
            }
        }

        public void DisplayBooksInRange( double start , double end)
        {
            Console.WriteLine("Books price Range {0} - {1} are: ",start,end);
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var book in bookList)
            {
                if ( book.price >= start  || book.price <= end )
                {
                    book.Display();
                }
            }
        }

        public void DisplayMaximumPriceOfBook()
        {
            double iMax = 0;
            foreach (var book in bookList)
            {
                if (book.price >= iMax)
                {
                    iMax = book.price;
                }
            }
            foreach (var book in bookList)
            {
                if (book.price == iMax)
                {
                    book.Display();
                }
            }
        }

        public void DisplayMinimumPricePriceOfBook()
        {
            double iMin = double.MaxValue;
            foreach (var book in bookList)
            {
                if (book.price <= iMin)
                {
                    iMin = book.price;
                }
            }

            foreach (var book in bookList)
            {
                if (book.price == iMin)
                {
                    book.Display();
                }
            }
        }

        public void DisplayBooksWrittenByAuthor( string authorName)
        {
            Console.WriteLine("Books Written by {0} are: ", authorName);
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var book in bookList)
            {
                if (book.authorName.Equals(authorName))
                {
                    book.Display();
                }
            }
        }

        public void DeleteSpecificBook( string bookName )
        {

            foreach (var book in bookList)
            {
                if (book.bookName.Equals(bookName))
                {
                    bookList.Remove(book);
                    break;
                }
            }
            Console.WriteLine("{0} is successfully removed",bookName);
        }

        public void DisplayBooksCopyLessThan( int iNo)
        {
            Console.WriteLine("Books who number of Copy is less then {0} ", iNo);
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var book in bookList)
            {
                if (book.noOfCopy <= iNo)
                {
                    book.Display();
                }
            }
        }

        public double TotalCost()
        {
            double totalCost = 0.0;
            double cost = 0.0;
            foreach (var book in bookList)
            {
                cost = book.price * book.noOfCopy;
                totalCost += cost;
            }
            return totalCost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            BookManagement bm = new BookManagement();
            do
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("1: Add new Book");
                Console.WriteLine("2: Display All Information About specific book");
                Console.WriteLine("3: Display all books in between that range");
                Console.WriteLine("4: Display book with maximum price");
                Console.WriteLine("5: Display book with minimum price");
                Console.WriteLine("6: Display all the books written by author");
                Console.WriteLine("7: Delete the specific book");
                Console.WriteLine("8: Display name of books whose number of copy is less than 5");
                Console.WriteLine("9: Calculate total cost of all books including price of all copies");
                Console.WriteLine("10: Exit");
                Console.WriteLine("---------------------------------------------------------------------------");

                Console.Write("\nWhat you want to do? ");
                choose =  Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (choose)
                {
                    case 1:
                        bm.AddNewBook();
                        break;

                    case 2:
                        Console.Write("Enter the name of Book: ");
                        string bookName = Console.ReadLine();
                        bm.DisplayBookDetail(bookName);
                        break;

                    case 3:
                        double iStart, iEnd;

                        Console.Write("Enter the Start Range of Book: ");
                        iStart = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter the End Range of Book: ");
                        iEnd = Convert.ToDouble(Console.ReadLine());

                        bm.DisplayBooksInRange(iStart, iEnd);
                        break;

                    case 4:
                        bm.DisplayMaximumPriceOfBook();
                        break;

                    case 5:
                        bm.DisplayMinimumPricePriceOfBook();
                        break;

                    case 6:
                        Console.Write("Enter the name of Author: ");
                        string bookAuthor = Console.ReadLine();
                        bm.DisplayBooksWrittenByAuthor(bookAuthor);
                        break;

                    case 7:
                        Console.Write("Enter the name of Book: ");
                        bookName = Console.ReadLine();
                        bm.DeleteSpecificBook(bookName);
                        break;

                    case 8:
                        bm.DisplayBooksCopyLessThan(5);
                        break;
                    case 9:
                        double totalCost = 0.0;
                        totalCost = bm.TotalCost();
                        Console.WriteLine("Total cost is: {0}\n", totalCost);
                        break;
                    case 10:
                        Console.WriteLine("Thank you for using");
                        break;
                    default:
                        Console.WriteLine("Wrong Choose");
                        break;
                }
                if(choose != 10)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.Write("Press Enter to see Menu");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (choose != 10);
        }
    }
}
