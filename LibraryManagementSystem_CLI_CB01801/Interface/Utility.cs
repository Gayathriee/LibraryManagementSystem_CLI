using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem_CLI_CB01801.Interface
{
    public class Utility
    {
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\n\nPress Enter to Continue...");
            Console.ReadLine();
        }

        public static void PrintMessage(string m, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(m);
            Console.ForegroundColor = ConsoleColor.White;
            PressEnterToContinue();

        }
        public static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.WriteLine(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }
    }
    
}
