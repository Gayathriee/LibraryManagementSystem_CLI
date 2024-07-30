using LibraryManagementSystem_CLI_CB01801.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.Domain
{
    public class LoanManager
    {
        List<Loan> loans = new List<Loan>();

        public void CreateLoan(Member m, Book b, DateTime loanDate)
        {
            loans.Add(new Loan(m, b, loanDate));
        }

        public void EndLoan(int memberId, int bookId)
        {
            Loan loan = FindLoan(memberId, bookId);

            if (loan != null)
            {
                loan.returnDate = DateTime.Now;
            }
        }

        public Loan FindLoan(int memberId, int bookId)
        {
            Loan foundLoan = null;

            for (int i = 0; foundLoan == null && i < loans.Count; i++)
            {
                if (loans[i].Book.id == bookId &&
                    loans[i].Member.id == memberId &&
                    loans[i].returnDate.ToBinary() == 0)
                {
                    foundLoan = loans[i];
                }
            }

            return foundLoan;
        }

        public List<Loan> GetCurrentLoans()
        {
            List<Loan> list = new List<Loan>();

            foreach (Loan loan in loans)
            {
                if (loan.returnDate.ToBinary() == 0)
                {
                    list.Add(loan);
                }
            }

            return list;
        }

        public bool RenewLoan(int memberId, int bookId)
        {
            Loan loan = FindLoan(memberId, bookId);

            if (loan != null)
            {
                bool loanWasRenewed = loan.Renew();

                if (loanWasRenewed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
