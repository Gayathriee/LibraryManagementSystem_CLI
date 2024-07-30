using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.Interface
{
    public class AppScreen
    {
        internal static void Welcome()
        {
            //CLEARS THE CONSOLE SCREEN
            Console.Clear();

            //SETS THE TITLE FOR THE Console
            Console.Title = "LibraryApp.comGH©";

            //Setting the text color to white
            Console.ForegroundColor = ConsoleColor.Cyan;

            //welcome message
            Console.WriteLine("\n\n-------------------------------------------------WELCOME TO MY LIBRARY-------------------------------------------------");

            //Setting the text color to white
            Console.ForegroundColor = ConsoleColor.Red;

            //prompt user 
            Console.WriteLine("Please insert your Library card");

            //Setting the text color to white
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Note: CB010801");
            Utility.PressEnterToContinue();
        }
    }
}
