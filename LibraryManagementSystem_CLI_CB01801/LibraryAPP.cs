using LibraryManagementSystem_CLI_CB01801.APP;
using LibraryManagementSystem_CLI_CB01801.Domain;
using LibraryManagementSystem_CLI_CB01801.Domain.UI;
using LibraryManagementSystem_CLI_CB01801.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB010801
{
    public class LibraryAPP
    {


        private const int BORROW_BOOK = 1;
        private const int RETURN_BOOK = 2;
        private const int RENEW_LOAN = 3;
        private const int VIEW_ALL_BOOKS = 4;
        private const int VIEW_CURRENT_LOANS = 5;
        private const int EXIT = 6;

        private static Librarian_UI libUI;
        private static Member_UI memUI;

        private readonly AppScreen screen;

        static void Main(string[] args)
        {
            InitialiseData();
            AppScreen.Welcome();
            ViewAllBooks();
            DisplayMenu();

            int choice = GetMenuChoice();

            while (choice != EXIT)
            {
                PerformAction(choice);
                DisplayMenu();
                choice = GetMenuChoice();

            }

        }
        private static void PerformAction(int choice)
        {
            switch (choice)
            {
                case BORROW_BOOK:
                    BorrowBook();
                    break;
                case RETURN_BOOK:
                    ReturnBook();
                    break;
                case RENEW_LOAN:
                    RenewLoan();
                    break;
                case VIEW_ALL_BOOKS:
                    ViewAllBooks();
                    break;
                case VIEW_CURRENT_LOANS:
                    ViewCurrentLoans();
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }

        private static void InitialiseData()
        {
            BookManager bookMgr = new BookManager();
            LoanManager loanMgr = new LoanManager();
            MemberManager memberMgr = new MemberManager(bookMgr, loanMgr);

            libUI = new Librarian_UI(bookMgr, loanMgr);
            memUI = new Member_UI(loanMgr, memberMgr);

           
            Member emmaJohnson = new Member("Emma Johnson", "emma.johnson@email.com", "Department of Education");
            Member alexHarper = new Member("Alex Harper", "alex.harper@email.com", "Department of Business Management");
            Member kylePerera = new Member("Kyle Perera", "kyle.perera@email.com", "Department of Computer Science");

            memberMgr.AddMember(emmaJohnson);
            memberMgr.AddMember(alexHarper);
            memberMgr.AddMember(kylePerera);


            bookMgr.AddBook(new Book("J.K. Rowling", "9780545010221", "The Philosopher's Stone"));
            bookMgr.AddBook(new Book("Victor Ostrovsky", "9780306812708", "By Way of Deception"));
            bookMgr.AddBook(new Book("David Copperfield", "9780142437836", "David Copperfield"));
            bookMgr.AddBook(new Book("Carolyn Keene", "9780306812708", "The Secret of the Old Clock"));
        }
        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n{0}. {1}", BORROW_BOOK, "Borrow a book");
            Console.WriteLine("{0}. {1}", RETURN_BOOK, "Return a book");
            Console.WriteLine("{0}. {1}", RENEW_LOAN, "Renew a loan");
            Console.WriteLine("{0}. {1}", VIEW_ALL_BOOKS, "View all books");
            Console.WriteLine("{0}. {1}", VIEW_CURRENT_LOANS, "View current loans");
            Console.WriteLine("{0}. {1}", EXIT, "Exit");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static int GetMenuChoice()
            
        {
            
            int option = ReadInteger("\nPlease Select an Option from the Menu");
            while (option < 1 || option > 6)
            {
                Utility.PrintMessage("Invalid input, Try again.", false);
                option = ReadInteger("\nPlease select an option");
            }
            return option;
           

        }

        private static int ReadInteger(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.Write(prompt + ": ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static void BorrowBook()
        {
            int memberId = ReadInteger("\nEnter member ID");
            int bookId = ReadInteger("Enter book ID");

            Utility.PrintDotAnimation();
            Console.Clear();
            try
            {
                memUI.BorrowBook(memberId, bookId);

                Utility.PrintMessage("\nBook borrowed Successfully!", true);
            }
            catch (Exception)
            {

                Utility.PrintMessage("Invalid input, Try again.", false);
            }
        }


        private static void ReturnBook()
        {
            int memberId = ReadInteger("\nMember ID");
            int bookId = ReadInteger("Book ID");
            try
            {
                memUI.ReturnBook(memberId, bookId);
                Utility.PrintMessage("\nBook returned Successfully!", true);
            }
            catch (Exception)
            {
                Utility.PrintMessage("\nInvalid input, Try again.", false);

            }
        }

        private static void RenewLoan()
        {
            int memberId = ReadInteger("\nMember ID");
            int bookId = ReadInteger("Book ID");
            Console.WriteLine(
                "\nLoan has {0}been renewed",
                memUI.RenewLoan(memberId, bookId) ? "" : "not ");
        }

        private static void ViewAllBooks()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Book> books = libUI.ViewAllBooks();
            Console.WriteLine("\nBooks Available");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t{0, -4} {1, -30} {2, -30} {3, -20}    {4}", "ID", "Title", "Author", "ISBN", "Status");
            foreach (Book b in books)
            {
                DisplayBook(b);
            }
            
        }

        private static void DisplayBook(Book b)
        {
            Console.WriteLine(
                "\t{0, -4} {1, -30} {2, -30} {3, -20}    {4}",
                b.id,
                b.Title,
                b.Author,
                b.ISBN,
                b.Status);
        }

        private static void ViewCurrentLoans()
        {
            List<Loan> loans = libUI.ViewCurrentLoans();
            Console.WriteLine("\nCurrent loans");
            Console.WriteLine("\t{0, -30} {1, -20} {2, -12} {3, -12} {4, -10}", "Title", "Borrower", "Loan date", "Due date", "Renewals");
            foreach (Loan loan in loans)
            {
                DisplayLoan(loan);
            }
        }

        private static void DisplayLoan(Loan loan)
        {
            Console.WriteLine(
                "\t{0, -30} {1, -20} {2, -12} {3, -12}    {4}",
                loan.Book.Title,
                loan.Member.name,
                loan.LoanDate.ToString("dd/MM/yyyy"),
                loan.DueDate.ToString("dd/MM/yyyy"),
                loan.NumberOfRenewals);
        }
    }
}
