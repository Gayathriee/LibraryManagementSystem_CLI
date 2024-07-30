using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.APP
{
    public class Loan
    {
        private static int nextId = 1;
        public int id { get; }
        public Member Member { get; }
        public Book Book { get; }
        public DateTime DueDate { get; private set; }
        public DateTime LoanDate { get; }

        private DateTime _returnDate;
        public DateTime returnDate
        {
            get
            {
                return _returnDate;
            }
            set
            {
                _returnDate = value;
                Book.MarkasAvaialble();
                Member.DecrementNumberOfLoans();
            }
        }
        public int NumberOfRenewals { get; private set; }


        
        public Loan(Member m, Book b, DateTime loanDate)
        {
            id = nextId++;
            Member = m;
            Book = b;
            Book.MarkAsOnLoan();
            Member.IncrementNumberOfLoans();
            LoanDate = loanDate;
            DueDate = LoanDate.AddDays(14);
            NumberOfRenewals = 0;
        }
        public bool Renew()
        {
            if (NumberOfRenewals < 3)
            {
                DueDate = DueDate.AddDays(14);
                NumberOfRenewals++;
                return true;
            }

            return false;
        }
    }


}
