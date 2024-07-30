using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.APP
{
    public class Member
    {
        private static int nextID;
        public int id { get; }
        public string name { get; }
        public string email { get; }
        public string department {  get; }

        public int numberOfLoans { get; private set; }

        public Member(string name, string email, string department)
        {
            this.id = nextID++;
            this.name = name;
            this.email = email;
            this.department = department;
            this.numberOfLoans = 0;
        }

       

        public bool DecrementNumberOfLoans()
        {
            if (numberOfLoans > 0)
            {
                numberOfLoans--;
                return true;
            }
            return false;
        }

        public bool IncrementNumberOfLoans()
        {
            if (numberOfLoans < 6)
            {
                numberOfLoans++;
                return true;
            }
            return false;
        }
    }
}
