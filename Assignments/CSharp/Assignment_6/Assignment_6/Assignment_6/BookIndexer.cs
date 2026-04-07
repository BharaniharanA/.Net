using System;

namespace Assignment_6
{

    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine("Book: " + BookName + ", Author: " + AuthorName);
        }
    }

    public class BookShelf
    {
        public Books[] Books = new Books[5];
        public Books this[int index]
        {
            get
            {
                return Books[index];
            }
            set
            {
                Books[index] = value;
            }
        }
        public void DisplayAll()
        {
            foreach (var book in Books)
            {
                book.Display();
            }
        }
    }
    internal class BookIndexer
    {
        public static void Main(String[] args)
        {
            BookShelf shelf = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter the book name: ");
                string bookname = Console.ReadLine();
                Console.Write("Enter the author name: ");
                string authorname = Console.ReadLine();
                shelf[i] = new Books(bookname, authorname);
            }
            shelf.DisplayAll();
        }
    }


}
