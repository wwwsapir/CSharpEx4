using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class Program
    {
        const string k_CurrentVersion = "Version: 16.1.4.0";
        public static void Main()
        {
            //First Test Menu:
            Delegates.MainMenu firstMainMenu = new Delegates.MainMenu();
            //First Layer:
            Delegates.Menu dateTimeMenu = firstMainMenu.AddSubMenuItem("Show Date/Time");
            Delegates.Menu versionAndActionsMenu = firstMainMenu.AddSubMenuItem("Version and Actions");
            //Second Layer:
            dateTimeMenu.AddActionMenuItem("Show Date", showDate);
            dateTimeMenu.AddActionMenuItem("Show Time", showTime);
            Delegates.Menu actionsMenu = versionAndActionsMenu.AddSubMenuItem("Actions");
            versionAndActionsMenu.AddActionMenuItem("Show Version", showVersion);
            //Third Layer:
            actionsMenu.AddActionMenuItem("Count Spaces", countSpaces);
            actionsMenu.AddActionMenuItem("Count Words", countWords);
            //Show the menu:
            firstMainMenu.ShowMenu();

            //Second Test Menu:

        }

        private static void showDate()
        {
            PromptMessage(DateTime.Today.ToString());
        }

        private static void showTime()
        {
            PromptMessage(DateTime.Now.ToString());
        }

        private static void showVersion()
        {
            PromptMessage(k_CurrentVersion);
        }

        private static void countSpaces()
        {
            string sentenceToCountSpaces = getSentenceFromUser();
            string outputStr = string.Format("The number of spaces in the sentence is: {0}",
                sentenceToCountSpaces.Count(Char.IsWhiteSpace));
            PromptMessage(outputStr);
        }

        private static void countWords()
        {
            string sentenceToCountWords = getSentenceFromUser();
            string outputStr = string.Format("The number of words in the sentence is: {0}",
                sentenceToCountWords.Split().Length);
            PromptMessage(outputStr);
        }

        private static string getSentenceFromUser()
        {
            Console.WriteLine("Please enter a sentence:");
            return Console.ReadLine();
        }

        // clear screen and prompt message to user
        public static void PromptMessage(string i_Message)
        {
            Console.Clear();
            Console.WriteLine(i_Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
