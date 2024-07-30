using LibraryManagementSystem_CLI_CB01801.APP;
using LibraryManagementSystem_CLI_CB01801.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.Domain
{
    public class BookManager
    {
        private SortedDictionary<int, Book> books = new SortedDictionary<int, Book>();

        public void AddBook(Book b)
        {
            books.Add(b.id, b);
        }

        public Book FindBook(int bookId)
        {
            if (books.ContainsKey(bookId))
            {
                return books[bookId];
            }
            else
            {
                string message = $"Book with ID {bookId} does not exist in the library.";
                LogError(message);
                throw new ArgumentOutOfRangeException(nameof(bookId), message);
            }
        }

        private void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>(books.Count);

            foreach (Book b in books.Values)
            {
                list.Add(b);
            }

            return list;
        }
    }
}
