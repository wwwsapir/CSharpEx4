using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        public readonly string r_MenuName;
        private readonly Dictionary<MenuItem, Action> r_Items;
        private readonly List<Menu> r_SubMenusList = new List<Menu>();

        public string m_ExitOrBack;

        public Menu(string i_MenuName)  // Used to create a main menu or a sub-manu with an unknown number of items
        {
            r_MenuName = i_MenuName;
            r_Items = new Dictionary<MenuItem, Action>();
            SetFirstItem(); // Sets the first item to "Back" or "Exit"
        }

        protected virtual void SetFirstItem()   // Sets the first item name to "Back"
        {
            m_ExitOrBack = "Back";
        }

        public Dictionary<MenuItem, Action> Items 
        {
            get { return r_Items; }
        }

        private void printMenu()    // Presents the nemu on the screen
        {
            Console.Clear();
            // Present the exit/back option:
            Console.WriteLine(r_MenuName + ":");
            string firstLine = "0 : " + m_ExitOrBack;
            Console.WriteLine(firstLine);
            // Present the rest of the items:
            string currItemToShow;
            foreach (KeyValuePair<MenuItem, Action> item in r_Items)
            {
                currItemToShow = string.Format("{0} : {1}", item.Key.ItemNumberInMenu, item.Key.Description);
                Console.WriteLine(currItemToShow);
            }
        }

        private bool tryGetChoiceFromUser(out int i_UsersChoice)
        {
            Console.WriteLine("Please enter the number of the item you'd like to choose:");
            string input = Console.ReadLine();
            int currChoice;
            bool choiceValid = true;
            bool isFormatValid = int.TryParse(input, out currChoice);
            if (!isFormatValid || currChoice < 0 || currChoice > r_Items.Count)
            {
                choiceValid = false;
            }

            i_UsersChoice = currChoice;

            return choiceValid;
        }

        protected void ShowMenu()   // Protected - only operates as public from the MainMenu (son of Menu)
        {
            while (true)
            {
                printMenu();
                int userChoice;
                bool validInput;
                // Get input from user: 
                do
                {
                    validInput = tryGetChoiceFromUser(out userChoice);
                    if (!validInput)
                    {
                        Console.WriteLine("Input is not valid.");
                    }
                } while (!validInput);

                if (userChoice != 0)
                {
                    // Find the chosen item and let it know it has been chosen
                    foreach (KeyValuePair<MenuItem, Action> item in r_Items)
                    {
                        if (item.Key.ItemNumberInMenu == userChoice)
                        {
                            item.Key.Choose();
                        }
                    }
                }
                else
                {
                    // '0' was chosen - exit the loop
                    break;
                }
            }
        }

        // Adds an item to menu that operates a function that is not another menu
        public void AddActionMenuItem(string i_Description, Action i_FunctionToInvoke)
        {
            MenuItem newMenuItem = new MenuItem(i_Description, r_Items.Count + 1);
            newMenuItem.ItemChosenHandler += menuItem_Chosen;
            Items.Add(newMenuItem, i_FunctionToInvoke);
        }

        // Adds an item to the menu that operates another sub-menu and creates that sub-menu
        public Menu AddSubMenuItem(string i_Description)
        {
            r_SubMenusList.Add(new Menu(i_Description));
            MenuItem newMenuItem = new MenuItem(i_Description, r_Items.Count + 1);
            newMenuItem.ItemChosenHandler += menuItem_Chosen;
            r_Items.Add(newMenuItem, r_SubMenusList[r_SubMenusList.Count - 1].ShowMenu);

            return r_SubMenusList[r_SubMenusList.Count - 1];
        }
        
        // The action to do when an item is chosen
        private void menuItem_Chosen(MenuItem i_MenuItem)
        {
            Action functionToInvoke;
            r_Items.TryGetValue(i_MenuItem, out functionToInvoke);
            functionToInvoke.Invoke();
        }
    }
}
