using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        const string k_CurrentVersion = "Version: 16.1.4.0";
        public static void Main()
        {
            //Interfaces Test Menu:

            //throw new NotImplementedException();

            //Delegates Test Menu:
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

        }

        private static void showDate()
        {
            PromptMessage(DateTime.Today.ToShortDateString());
        }

        private static void showTime()
        {
            PromptMessage(DateTime.Now.ToShortTimeString());
        }

        private static void showVersion()
        {
            PromptMessage(k_CurrentVersion);
        }

        private static void countSpaces()
        {
            int spacesCounter = 0;
            string sentenceToCountSpaces = getSentenceFromUser();
            foreach (char character in sentenceToCountSpaces)
            {
                if (character == ' ')
                {
                    ++spacesCounter;
                }
            }

            string outputStr = string.Format("The number of spaces in the sentence is: {0}",
                spacesCounter);
            PromptMessage(outputStr);
        }

        private static void countWords()
        {
            string sentenceToCountWords = getSentenceFromUser();
            // Split the sentence by spaces to get all words
            string[] words = sentenceToCountWords.Split();
            int wordsNumber = words.Length;
            // Get rid of "ghost" words:
            foreach (string word in words)
            {
                if (word == "")
                {
                    --wordsNumber;
                }
            }

            // Show the final words count
            string outputStr = string.Format("The number of words in the sentence is: {0}",
                wordsNumber);
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
