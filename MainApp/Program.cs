using System;
using AppLibrary;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            Console.WriteLine("Welcome to your health tracker!");
            while (isRunning)
            {
                isRunning = UserInterface();
            }

        }
        static bool UserInterface()
        {
            Console.WriteLine("What would you like to do? Make a selection: Enter 1 to Update Enter 2 to Delete Enter 3 to View Results Enter 0 to Quit");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return false;
                case "1":
                    Sql.Update();
                    break;
                case "2":
                    Sql.Delete();
                    break;
                case "3":
                    Sql.Query();
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;

            }
            return true;
        }
    }
}
