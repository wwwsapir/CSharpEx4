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

        protected virtual void SetFirstItem()   // Sets the first item to "Back"
        {
            m_ExitOrBack = "Back";
        }

        public Dictionary<MenuItem, Action> Items 
        {
            get { return r_Items; }
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine(r_MenuName + ":");
            string firstLine = "0 : " + m_ExitOrBack;
            Console.WriteLine(firstLine);
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
            bool choiceValid;
            bool isFormatValid = int.TryParse(input, out currChoice);
            if (!isFormatValid || currChoice < 0 || currChoice > r_Items.Count)
            {
                choiceValid = false;
            }

            i_UsersChoice = currChoice;

            return true;
        }

        protected void ShowMenu()   // Protected - only operates from the MainMenu (son)
        {
            while (true)
            {
                printMenu();
                int userChoice;
                bool validInput;
                do
                {
                    validInput = tryGetChoiceFromUser(out userChoice);
                } while (!validInput);

                if (userChoice != 0)
                {
                    foreach (KeyValuePair<MenuItem, Action> item in r_Items)
                    {
                        if (item.Key.ItemNumberInMenu == userChoice)
                        {
                            item.Key.OnItemChosen();
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void AddActionMenuItem(string i_Description, Action i_FunctionToInvoke)
        {
            MenuItem newMenuItem = new MenuItem(i_Description, r_Items.Count + 1);
            newMenuItem.ReportChosenDelegates += OnItemChosen;
            Items.Add(newMenuItem, i_FunctionToInvoke);
        }

        public Menu AddSubMenuItem(string i_Description)
        {
            const bool v_SubMenu = true;

            r_SubMenusList.Add(new Menu(i_Description));
            MenuItem newMenuItem = new MenuItem(i_Description, r_Items.Count + 1);
            newMenuItem.ReportChosenDelegates += OnItemChosen;
            r_Items.Add(newMenuItem, r_SubMenusList[r_SubMenusList.Count - 1].ShowMenu);

            return r_SubMenusList[r_SubMenusList.Count - 1];
        }

        private void OnItemChosen(MenuItem i_MenuItem)
        {
            const bool v_SubMenu = true;

            Action functionToInvoke;
            r_Items.TryGetValue(i_MenuItem, out functionToInvoke);
            functionToInvoke.Invoke();
        }
    }
}
