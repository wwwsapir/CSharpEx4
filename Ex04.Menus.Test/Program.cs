using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            // Interfaces Test Menu:
            interfaceMenuTest();

            // Delegates Test Menu:
            delegateMenuTest();
        }

        private static void interfaceMenuTest()
        {
            Interfaces.MainMenu firstMainMenu = new Interfaces.MainMenu("Main Menu");
            Interfaces.Menu dateTimeMenu = firstMainMenu.AddSubMenu("Show Data/Time");
            dateTimeMenu.AddOperation(new DateOperation(), "Show Date");
            dateTimeMenu.AddOperation(new TimeOperation(), "Show Time");

            Interfaces.Menu versionAndActionsMenu = firstMainMenu.AddSubMenu("Version and Actions");
            versionAndActionsMenu.AddOperation(new ShowVersionOperation(), "Show Version");

            Interfaces.Menu actionSubMenu = versionAndActionsMenu.AddSubMenu("Action");
            actionSubMenu.AddOperation(new CountSpacesOperation(), "Count Spaces");
            actionSubMenu.AddOperation(new CountWordsOperation(), "Count Words");

            firstMainMenu.Show();
            Console.Clear();
        }

        private static void delegateMenuTest()
        {
            Delegates.MainMenu firstMainMenu = new Delegates.MainMenu();

            // First Layer:
            Delegates.Menu dateTimeMenu = firstMainMenu.AddSubMenuItem("Show Date/Time");
            Delegates.Menu versionAndActionsMenu = firstMainMenu.AddSubMenuItem("Version and Actions");

            // Second Layer:
            dateTimeMenu.AddActionMenuItem("Show Date", new DateOperation().Operate);
            dateTimeMenu.AddActionMenuItem("Show Time", new TimeOperation().Operate);
            Delegates.Menu actionsMenu = versionAndActionsMenu.AddSubMenuItem("Actions");
            versionAndActionsMenu.AddActionMenuItem("Show Version", new ShowVersionOperation().Operate);

            // Third Layer:
            actionsMenu.AddActionMenuItem("Count Spaces", new CountSpacesOperation().Operate);
            actionsMenu.AddActionMenuItem("Count Words", new CountWordsOperation().Operate);

            // Show the menu:
            firstMainMenu.ShowMenu();
        }

        internal static string GetSentenceFromUser()
        {
            Console.WriteLine("Please enter a sentence:");

            return Console.ReadLine();
        }

        // clear screen and prompt message to user
        internal static void PromptMessage(string i_Message)
        {
            Console.Clear();
            Console.WriteLine(i_Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
