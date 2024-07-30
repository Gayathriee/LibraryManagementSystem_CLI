using LibraryManagementSystem_CLI_CB01801.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.Domain.UI
{
    public class Librarian_UI
    {
        private BookManager bookMgr;
        private LoanManager loanMgr;

        public Librarian_UI(BookManager bookMgr, LoanManager loanMgr)
        {
            this.bookMgr = bookMgr;
            this.loanMgr = loanMgr;
        }

        public List<Book> ViewAllBooks()
        {
            return bookMgr.GetAllBooks();
        }

        public List<Loan> ViewCurrentLoans()
        {
            return loanMgr.GetCurrentLoans();
        }
    }
}
