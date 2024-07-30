using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.APP
{
    public class Book
    {
        private static int nextId = 1;
        public static readonly string BookAvailable = "Available";
        public static readonly string Loaned = "On Loan";
        public string Author { get; }
        public int id { get; }
        public string ISBN { get; }
        public string Status { get; private set; }
        public string Title { get; }
        public Book(string author, string isbn, string title)
        {
            id = nextId++;
            Author = author;
            ISBN = isbn;
            Title = title;
            Status = BookAvailable;
        }


        //to check the book availability
        public void MarkasAvaialble()
        {
            
            Status = BookAvailable;
        }

        public void MarkAsOnLoan()
        {
            
            Status = Loaned;
        }
    }
}
